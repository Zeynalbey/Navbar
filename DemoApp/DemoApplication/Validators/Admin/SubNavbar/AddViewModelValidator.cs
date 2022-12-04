
using DemoApplication.ViewModels.Admin.Subnavbar;
using DemoApplication.ViewModels.Admin.SubNavbar;
using FluentValidation;

namespace DemoApplication.Validators.Admin.SubNavbar
{
    public class AddViewModelValidator :AbstractValidator<AddviewModel>
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
