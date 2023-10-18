using MauiDemonstrationApp.Models;
using MauiDemonstrationApp.ViewModels;
using System.Collections.ObjectModel;

namespace MauiDemonstrationApp.Views.Customers;

public partial class CustomerListPage : ContentPage
{
    private readonly CustomerRepository _repository;

    public CustomerListPage(CustomerRepository repository)
    {
        InitializeComponent();

        _repository = repository;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(() => InitializeAsync());
    }

    private async Task InitializeAsync()
    {
        var customers = await _repository.GetAll();

        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            ListViewCustomers.ItemsSource = new ObservableCollection<CustomerViewModel>(customers.Select(s => new CustomerViewModel(s)));
        });
    }

    private async void AddItem(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("customer");
    }

    private async void EditItem(object sender, EventArgs e)
    {
        var button = sender as BindableObject;
        var viewModel = button.BindingContext as CustomerViewModel;

        await Shell.Current.GoToAsync("customer", new Dictionary<string, object>
        {
            ["customer"] = viewModel
        });
    }

    private async void RemoveItem(object sender, EventArgs e)
    {
        var button = sender as BindableObject;
        var viewModel = button.BindingContext as CustomerViewModel;

        bool answer = await DisplayAlert("Customer exclusion", $"Are you sure about {viewModel.Name} exclusion?", "Yes", "No");

        if (answer)
        {
            await Task.Run(async () =>
            {
                await _repository.Delete(viewModel.ToModel());

                await InitializeAsync();
            });
        }
    }
}