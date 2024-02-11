using EventManager.Models;
using FluentValidation;

namespace EventManager.Validators
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.JoinDate)
                .NotEmpty()
                .NotNull();
        }
    }
}
