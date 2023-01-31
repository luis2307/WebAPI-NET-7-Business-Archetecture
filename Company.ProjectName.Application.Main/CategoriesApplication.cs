using AutoMapper;
using Company.ProjectName.Application.DTO;
using Company.ProjectName.Application.Interface;
using Company.ProjectName.Domain.Interface;
using Company.ProjectName.Transversal.Common;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Company.ProjectName.Application.Main
{
    public class CategoriesApplication : ICategoriesApplication
    {
        private readonly ICategoriesDomain _categoriesDomain;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public CategoriesApplication(ICategoriesDomain categoriesDomain, IMapper mapper, IDistributedCache distributedCache)
        {
            _categoriesDomain = categoriesDomain;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<Response<IEnumerable<CategoriesDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CategoriesDto>>();
            var cacheKey = "categoriesList";

            try
            {
                var redisCategories = await _distributedCache.GetAsync(cacheKey);
                if (redisCategories != null)
                {
                    response.Result = JsonSerializer.Deserialize<IEnumerable<CategoriesDto>>(redisCategories);
                }
                else
                {
                    var categories = await _categoriesDomain.GetAllAsync();
                    response.Result = _mapper.Map<IEnumerable<CategoriesDto>>(categories);
                    if (response.Result != null)
                    {
                        var serializedCategories = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response.Result));
                        var options = new DistributedCacheEntryOptions()
                            .SetAbsoluteExpiration(DateTime.Now.AddHours(8))
                            .SetSlidingExpiration(TimeSpan.FromMinutes(60));

                        await _distributedCache.SetAsync(cacheKey, serializedCategories, options);
                    }
                }

                if (response.Result != null)
                {
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Consulta Exitosa!!!";
                }

            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = e.Message;
            }
            return response;
        }
    }
}
