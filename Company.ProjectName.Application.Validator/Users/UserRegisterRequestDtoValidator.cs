using Company.ProjectName.Application.DTO;
using Company.ProjectName.Infrastructure.Interface;
using FluentValidation;

namespace Company.ProjectName.Application.Validator.Users
{
    public class UserRegisterRequestDtoValidator : AbstractValidator<UserRegisterRequestDto>
    {
        //private readonly IUsersRepository _usersRepository; 

        public UserRegisterRequestDtoValidator(IUsersRepository usersRepository)
        {
            //_usersRepository = usersRepository;
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(u => u.LastName).NotNull().NotEmpty();
            RuleFor(u => u.UserName).NotNull().NotEmpty();//.Must(ExistUserName).WithMessage("{PropertyName} no es valido, porfavor reintente");
            RuleFor(u => u.Password).NotNull().NotEmpty();
            RuleFor(u => u.PasswordConfirm).NotNull().NotEmpty();
            RuleFor(x => x.PasswordConfirm).Equal(x => x.Password)
                 .WithMessage("Passwords must match");
        }

        //private bool ExistUserName(string UserName)
        //{

        //    var ccc = _usersRepository.Exist(UserName) > 0;
        //    return !ccc;
        //}
    }
}
