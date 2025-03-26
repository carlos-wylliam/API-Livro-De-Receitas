using CommomTestUtilities.Requests;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Exceptions;
using Shouldly;

namespace Validators.Test.User.Register
{
    public class RegisterUserValidatorTest
    {
        private readonly RegisterUserValidator _validator = new RegisterUserValidator();

        [Fact]
        public void Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var result = _validator.Validate(request);

            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Error_Name_Empty()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;

            var result = _validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldContain(e => e.ErrorMessage == ResourceMessagesException.NAME_EMPTY);
        }

        [Fact]
        public void Error_Email_Empty()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Email = string.Empty;

            var result = _validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldContain(e => e.ErrorMessage == ResourceMessagesException.EMAIL_EMPTY);
        }
    }
}
