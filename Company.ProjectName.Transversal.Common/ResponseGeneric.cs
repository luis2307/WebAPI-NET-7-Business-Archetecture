using FluentValidation.Results;
using System.Net;

namespace Company.ProjectName.Transversal.Common
{
    public class ResponseGeneric<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; } = true;
        public IEnumerable<ValidationFailure> Errors { get; set; }
        public T Result { get; set; }

    }
}
