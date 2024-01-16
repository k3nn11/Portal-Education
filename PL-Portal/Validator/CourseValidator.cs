using FluentValidation;
using Data.Models;
namespace Pl_Portal.Validator
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator() 
        {
            RuleFor(m => m.Title).NotEmpty().WithMessage("This field is requird");
            RuleFor(m => m.Description).NotEmpty().MinimumLength(50).WithMessage("This field is required");
            RuleForEach(m => m.Videos).SetValidator(new VideoValidator());
            RuleForEach(m => m.Articles).SetValidator(new ArticleValidator());
            RuleForEach(m => m.Books).SetValidator(new BookValidator());
            RuleForEach(m => m.Users).SetValidator(new UserValidator());
            RuleForEach(m => m.Skills).SetValidator(new SkillValidator());
            RuleFor(m => m.State).NotEmpty().WithMessage("This field is required");

        }
    }
}
