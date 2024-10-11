using Common;
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
            services.AddSingleton<INavigationService,NavigationService> ();

            services.AddSingleton<AlbumViewModel>();
            services.AddSingleton<AlbumView>(sp => new AlbumView() { DataContext = sp.GetService<AlbumViewModel>() });

            services.AddSingleton<AllPlayListViewModel>();
            services.AddSingleton<AllPlayListView>(sp => new AllPlayListView() { DataContext = sp.GetService<AllPlayListViewModel>() });

            services.AddSingleton<ArtistViewModel>();
            services.AddSingleton<ArtistView>(sp => new ArtistView() { DataContext = sp.GetService<ArtistViewModel>() });

            services.AddSingleton<FavoriteMusicViewModel>();
            services.AddSingleton<FavoriteMusicView>(sp => new FavoriteMusicView() { DataContext = sp.GetService<FavoriteMusicViewModel>() });

            services.AddSingleton<LyricViewModel>();
            services.AddSingleton<LyricView>(sp => new LyricView() { DataContext = sp.GetService<LyricViewModel>() });

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainView>(sp => new MainView() { DataContext = sp.GetService<MainViewModel>() });

            services.AddSingleton<MusicViewModel>();
            services.AddSingleton<MusicView>(sp => new MusicView() { DataContext = sp.GetService<MusicViewModel>() });

            services.AddSingleton<RecentlyAddedViewModel>();
            services.AddSingleton<RecentlyAddedView>(sp => new RecentlyAddedView() { DataContext = sp.GetService<RecentlyAddedViewModel>() });

            services.AddSingleton<PlayListViewModel>();
            services.AddSingleton<PlayListView>(sp => new PlayListView() { DataContext = sp.GetService<PlayListViewModel>() });
            return services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetService<MainView>();
            mainWindow!.Show();
        }
    }
}
