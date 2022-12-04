using DemoApplication.ViewModels.Admin.Navbar;
using FluentValidation;

namespace DemoApplication.Validators.Admin.Navbar
{
    public class AddViewModelValidator :AbstractValidator<AddViewModel>
    {
        public AddViewModelValidator()
        {

            RuleFor(n => n.Name)
                .NotNull()
                .WithMessage("Name can't be empty")
                .NotEmpty()
                 .MinimumLength(3)
                  .WithMessage("Min length is 3")
                   .MaximumLength(50)
                 .WithMessage("Max length is 50");



            
        }
    }
}
