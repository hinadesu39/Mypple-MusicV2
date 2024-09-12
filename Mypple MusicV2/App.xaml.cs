using Microsoft.Extensions.DependencyInjection;
using Mypple_MusicV2.ViewModels;
using Mypple_MusicV2.Views;
using Serilog;
using System.Windows;

namespace Mypple_MusicV2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static new App Current => (App)Application.Current;

        public IServiceProvider ServiceProvider { get; }

        public App()
        {
            ServiceProvider = ConfigServices();
            InitializeComponent();
        }

        private IServiceProvider? ConfigServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILogger>(
                _ =>
                    new LoggerConfiguration().MinimumLevel
                        .Debug()
                        .WriteTo.File("log.txt")
                        .CreateLogger()
            );

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainView>(sp => new MainView() { DataContext = sp.GetService<MainViewModel>() });
            return services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetService<MainView>();
            mainWindow!.Show();
        }
    }
}
