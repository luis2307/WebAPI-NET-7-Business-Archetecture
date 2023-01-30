using Company.ProjectName.Application.DTO;
using FluentValidation;

namespace Company.ProjectName.Application.Validator.Users
{
    public class UserRegisterRequestDtoValidator : AbstractValidator<UserRegisterRequestDto>
    {
        public UserRegisterRequestDtoValidator()
        {
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(u => u.LastName).NotNull().NotEmpty();
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
            RuleFor(u => u.PasswordConfirm).NotNull().NotEmpty();

            RuleFor(x => x.PasswordConfirm).Equal(x => x.Password)
               .WithMessage("Passwords must match"); 
        }
    }
}
