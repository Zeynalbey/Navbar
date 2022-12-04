using DemoApplication.ViewModels.Admin.Navbar;
using FluentValidation;

namespace DemoApplication.Validators.Admin.Navbar
{
    public class UpdateViewModelValidator: AbstractValidator<NavbarUpdateViewModel>
    {
        public UpdateViewModelValidator()
        {

            RuleFor(n => n.Name)
                .NotNull()
                .WithMessage("Name can't be empty")
                .NotEmpty()
                 .MinimumLength(3)
                  .WithMessage("Minimum length should be 3")
                   .MaximumLength(50)
                 .WithMessage("Maximum length should be 50");


        }
    }
}
