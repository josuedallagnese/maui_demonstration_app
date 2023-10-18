using FluentValidation;

namespace MauiDemonstrationApp.ViewModels.Validations
{
    public class CustomerViewModelValidation : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidation()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
        }
    }
}
