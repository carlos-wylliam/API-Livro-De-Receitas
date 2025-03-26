using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY)
                .EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage(ResourceMessagesException.PASSWORD_EMPTY)
                .MinimumLength(6).WithMessage(ResourceMessagesException.PASSWORD_EMPTY);
        }
    }
}
