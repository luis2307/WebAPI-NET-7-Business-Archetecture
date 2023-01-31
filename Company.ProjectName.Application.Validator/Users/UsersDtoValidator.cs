using Company.ProjectName.Application.DTO;
using FluentValidation;

namespace Company.ProjectName.Application.Validator.Users
{
    public class UsersDtoValidator : AbstractValidator<LoginRequestDto>
    {
        public UsersDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }

}