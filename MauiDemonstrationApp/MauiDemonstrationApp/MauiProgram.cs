using MauiDemonstrationApp.Core;
using MauiDemonstrationApp.Models;
using MauiDemonstrationApp.Views;
using MauiDemonstrationApp.Views.Customers;
using Microsoft.Extensions.Logging;

namespace MauiDemonstrationApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-brands-400.ttf", "FaBrands");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Database
            builder.Services.AddSingleton<DatabaseProvider>();
            builder.Services.AddTransient<CustomerRepository>();

            // Views
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CustomerPage>();
            builder.Services.AddTransient<CustomerListPage>();

            return builder.Build();
        }
    }
}