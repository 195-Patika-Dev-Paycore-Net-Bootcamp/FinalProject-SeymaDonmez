using FluentValidation;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Service.Constants;

namespace PaycoreFinalProject.Service.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        ////Product nesnesinin doğrulama sınıfıdır.
        public UserValidator()
        {
            RuleFor(u => u.Email).EmailAddress().NotEmpty().NotNull().WithMessage(Messages.UserEmailFormatErrorMassage); ;
            RuleFor(u => u.FirstName).NotEmpty().NotNull().WithMessage(Messages.FirstNameErrorMessage);
            RuleFor(u => u.LastName).NotEmpty().NotNull().WithMessage(Messages.LastNameErrorMessage);
            RuleFor(u => u.Password).MinimumLength(8).MaximumLength(20);
        }
    }
}
