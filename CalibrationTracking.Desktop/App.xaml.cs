using CalibrationTracking.Application;
using CalibrationTracking.Desktop.Departments.Windows;
using CalibrationTracking.Desktop.Employees.Windows;
using CalibrationTracking.Desktop.Login.Windows;
using CalibrationTracking.Infrastructure;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace CalibrationTracking.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private readonly IHost _host;
        private readonly IConfigurationRoot _configuration;

        public App()

        {
            string path = Path.GetFullPath(Directory.GetCurrentDirectory());

            _configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder().SetBasePath(path)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            _host = Host.CreateDefaultBuilder().ConfigureServices((context, services) => ConfigureServicesAsync(services)).Build();
        }

        private async Task ConfigureServicesAsync(IServiceCollection services)
        {
            services.AddInfrastructure(_configuration);
            services.AddApplication();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<LoginWindow>();
            services.AddSingleton<DepartmentAddOrEditWindow>();
            services.AddSingleton<EmployeeAddOrEditWindow>();
            services.AddSingleton<EmployeeListWindow>();
            services.AddSingleton<EmployeesWindow>();


        }

        private async Task InitiliazeDataBase()
        {
            var initializer = _host.Services.GetRequiredService<IDatabaseInitializer>();
            await initializer.InitialiseAsync();
            await initializer.SeedAsync();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            base.OnStartup(e);


            await InitiliazeDataBase();
            var window = _host.Services.GetRequiredService<EmployeeAddOrEditWindow>();

            window.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}