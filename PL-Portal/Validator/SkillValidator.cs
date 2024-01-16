using FluentValidation;
using Data.Models;
using System.Data;

namespace Pl_Portal.Validator
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator() 
        {
            RuleFor(i => i.Title).NotEmpty().WithMessage("This field is required");
            RuleFor(i => i.Description).NotEmpty().MaximumLength(50).WithMessage("This field is required");

        }
    }
}
