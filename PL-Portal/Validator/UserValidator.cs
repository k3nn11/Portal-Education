using FluentValidation;
using Data.Models;
namespace Pl_Portal.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleForEach(i => i.Courses).SetValidator(new CourseValidator());
            RuleFor(i => i.Information).SetValidator(new PersonalInfomationValidator());
            //RuleFor(i => i.Login).SetValidator(new Login
        }

    }
}
