using FluentValidation;
using Data.Models;
namespace Pl_Portal.Validator
{
    public class VideoValidator :AbstractValidator<Video>
    {
        public VideoValidator() 
        {
            RuleFor(i => i.Title).NotEmpty().WithMessage("This field is required");
            RuleFor(i => i.Quality).NotEmpty().WithMessage("This field is required");
            RuleFor(i => i.Duration).NotEmpty().WithMessage("This field is required");
            RuleFor(i => i.Description).NotEmpty().MaximumLength(50).WithMessage("This field is required");
        }
    }
}
