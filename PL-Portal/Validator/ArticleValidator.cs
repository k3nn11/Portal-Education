using FluentValidation;
using Data.Models;

namespace Pl_Portal.Validator
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator() 
        {
            RuleFor(n => n.Title).NotEmpty().WithMessage("This field is required");
            RuleFor(n => n.Description).NotEmpty().WithMessage("This field is required");
            RuleFor(n => n.DateOfPublication).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(n => n.Resource).NotEmpty().WithMessage("This field is required");
           // RuleFor(n => n.States).NotEmpty().WithMessage("This field is required");
        }
    }
}
