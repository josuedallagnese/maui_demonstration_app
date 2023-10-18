using MauiDemonstrationApp.Views;
using MauiDemonstrationApp.Views.Customers;

namespace MauiDemonstrationApp
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            Routes.Add("home", typeof(MainPage));
            Routes.Add("customers", typeof(CustomerListPage));
            Routes.Add("customer", typeof(CustomerPage));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}