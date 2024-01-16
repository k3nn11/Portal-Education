using FluentValidation;
using Data.Models;
namespace Pl_Portal.Validator
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator() 
        {
            RuleFor(i => i.Title).NotEmpty().WithMessage("This field is required");
            RuleFor(i => i.Description).NotEmpty().MaximumLength(1000).WithMessage("Description is required");
            RuleFor(i => i.NumberOfPages).NotEmpty().GreaterThan(1).WithMessage("NumberOfPges is required");
           // RuleFor(i => i.Authors).NotEmpty().WithMessage(" Authors is required");
            RuleFor(i => i.Format).NotEmpty().WithMessage("Format is required");
        }
    }
}
