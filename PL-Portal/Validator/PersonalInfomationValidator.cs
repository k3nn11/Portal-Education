using FluentValidation;
using Data.Models;

namespace Pl_Portal.Validator
{
    public class PersonalInfomationValidator : AbstractValidator<PersonalInformation>
    {
        public PersonalInfomationValidator() 
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("This field is required");
            RuleFor(i => i.Email).EmailAddress().NotEmpty().WithMessage("Enter valid email address");
            RuleForEach(i => i.Skills).SetValidator(new SkillValidator());
            RuleFor(i => i.Phone).NotEmpty().WithMessage("This field is required");
            RuleFor(i => i.User).SetValidator(new UserValidator());

        }

    }
}
