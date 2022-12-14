using AutoMapper;
using CalibrationTracking.Application;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.CustomeMessageBox;
using CalibrationTracking.Desktop.Main.Windows;
using CalibrationTracking.Desktop.Services.CustomeMessageBox;
using CalibrationTracking.Infrastructure;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace CalibrationTracking.Desktop
{

    public static class UserControlHelper
    {
        public static IMediator Mediator { get; internal set; }
        public static IMapper Mapper { get; internal set; }
        public static IDialogService? DialogService { get; internal set; }


      
    }

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

            _host = Host.CreateDefaultBuilder().ConfigureServices((context, services) => ConfigureServices(services)).Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(_configuration);
            services.AddApplication();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<CalibrationAddOrEditWindow>();
            services.AddSingleton<ScanBarcodeWindow>();
            services.AddSingleton<IDialogService, DialogService>();


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

            UserControlHelper.Mediator = (IMediator?)_host.Services.GetRequiredService<IMediator>();
            UserControlHelper.Mapper = (IMapper?)_host.Services.GetRequiredService<IMapper>();
            UserControlHelper.DialogService = (IDialogService?)_host.Services.GetRequiredService<IDialogService>();

            await InitiliazeDataBase();
            var window = _host.Services.GetRequiredService<MainWindow>();



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