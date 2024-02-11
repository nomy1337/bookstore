using EventManager.Models;
using FluentValidation;

namespace EventManager.Validators
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.StartTime)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.EndTime)
                .NotEmpty()
                .NotNull()
                .GreaterThan(x => x.StartTime)
                .WithMessage("End time must be greater than start time.");
            RuleFor(x => x.Location)
                .NotEmpty();
        }
    }
}
