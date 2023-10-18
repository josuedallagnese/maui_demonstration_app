using MauiDemonstrationApp.Models;
using MauiDemonstrationApp.ViewModels;
using MauiDemonstrationApp.ViewModels.Validations;

namespace MauiDemonstrationApp.Views.Customers;

public partial class CustomerPage : ContentPage, IQueryAttributable
{
    private readonly CustomerViewModelValidation _validation = new();
    private readonly CustomerRepository _repository;

    public CustomerPage(CustomerRepository repository)
    {
        InitializeComponent();

        _repository = repository;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("customer"))
        {
            var customer = query["customer"] as CustomerViewModel;

            Task.Run(() => GetCustomer(customer.Id));
            return;
        }

        BindingContext = new CustomerViewModel();
    }

    private async Task GetCustomer(int id)
    {
        var customer = await _repository.Get(id);

        BindingContext = new CustomerViewModel(customer);
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var customer = BindingContext as CustomerViewModel;

        var validation = _validation.Validate(customer);

        if (validation.IsValid)
        {
            await _repository.AddOrUpdate(customer.ToModel());

            await Navigation.PopAsync();

            return;
        }

        var errors = string.Join(Environment.NewLine, validation.Errors.Select(s => s.ErrorMessage));

        await DisplayAlert("Invalid data", errors, "Ok");
    }
}