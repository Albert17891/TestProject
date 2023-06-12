using FluentValidation;

namespace MovieApp.Web.Models.Request.Validation;

public class MovieUptadeRequestValidation:AbstractValidator<MovieUpdateRequest>
{
    public MovieUptadeRequestValidation()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("id is required");

        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Name cannot be null");

        RuleFor(x => x.Description)
            .NotNull()
            .WithMessage("Description cannot be null");
    }
}
