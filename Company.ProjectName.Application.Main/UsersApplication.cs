using AutoMapper;
using BCrypt.Net;
using Company.ProjectName.Application.DTO;
using Company.ProjectName.Application.Interface;
using Company.ProjectName.Application.Validator.Users;
using Company.ProjectName.Domain.Entity;
using Company.ProjectName.Domain.Interface;
using Company.ProjectName.Transversal.Common;
using FluentValidation;
using System.Net;

namespace Company.ProjectName.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _usersDtoValidator;
        private readonly UserRegisterRequestDtoValidator _userRegisterDtoValidator;

        public UsersApplication(IUsersDomain usersDomain, IMapper iMapper, UsersDtoValidator usersDtoValidator, UserRegisterRequestDtoValidator userRegisterDtoValidator)
        {
            _usersDomain = usersDomain;
            _mapper = iMapper;
            _usersDtoValidator = usersDtoValidator;
            _userRegisterDtoValidator = userRegisterDtoValidator;
        }
        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();
            var validation = _usersDtoValidator.Validate(new LoginRequestDto() { UserName = username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username);
                bool validPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
                user.Password = string.Empty;
                if (validPassword)
                {
                    response.Result = _mapper.Map<UsersDto>(user);
                    response.IsSuccess = true;
                    response.Message = "Autenticación Exitosa!!!";
                    response.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Password Incorrecta";
                    response.StatusCode = HttpStatusCode.BadRequest;
                    return response;
                }
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = false;
                response.Message = "Usuario no existe";
                response.StatusCode = HttpStatusCode.BadRequest;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.StatusCode = HttpStatusCode.UnprocessableEntity;
            }
            return response;
        }

        public Response<UsersDto> Register(UserRegisterRequestDto usersDto)
        {
            var resp = new UsersDto();
            var response = new Response<UsersDto>();

            var validation = _userRegisterDtoValidator.Validate(

            usersDto
            );


            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                resp.FirstName = usersDto.FirstName;
                resp.LastName = usersDto.LastName;
                resp.UserName = usersDto.UserName;



                var userExist = _usersDomain.Exist(usersDto.UserName);
                if (userExist)
                {
                    response.IsSuccess = false;
                    response.Message = "Usuario ya existe!";
                    response.StatusCode = HttpStatusCode.BadRequest;
                    return response;
                }
                else
                {

                    var user = _mapper.Map<Users>(usersDto);
                    user.UserId = Guid.NewGuid();
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    var Saved = _usersDomain.Register(user);

                    if (Saved)
                    {
                        resp.UserId = user.UserId;
                        response.Result = resp;
                        response.IsSuccess = true;
                        response.Message = "Usuario Creado Correctamente";
                        response.StatusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Error al registrar, re intente más tarde";
                        response.StatusCode = HttpStatusCode.BadRequest;
                        return response;
                    }
                }
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = false;
                response.Message = "Error al registrar, re intente más tarde";
                response.StatusCode = HttpStatusCode.BadRequest;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.StatusCode = HttpStatusCode.UnprocessableEntity;
            }
            return response;
        }
    }
}
