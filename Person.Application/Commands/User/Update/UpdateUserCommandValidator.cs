using FluentValidation;

namespace Person.Application.Commands.User.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.PersonalNumber).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.GenderId).InclusiveBetween(1, 2);
            RuleFor(x => x.IsActive).NotNull().NotEmpty();
        }
    }
}
