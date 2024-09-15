using Common;
using CommunityToolkit.Mvvm.ComponentModel;
using Serilog;
using System.Collections.ObjectModel;

namespace Mypple_MusicV2.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private ILogger logger;

        [ObservableProperty]
        private List<NavigationItem> navigationItems;

        [ObservableProperty]
        private ObservableCollection<NavigationItem> playListItems;

        public MainViewModel()
        {
            
        }

        public MainViewModel(ILogger logger)
        {
            this.logger = logger;

            Init();
        }

        private void Init()
        {
            NavigationItems = new List<NavigationItem>();
            NavigationItems.Add(new NavigationItem("\uE74f", "最近添加"));
            NavigationItems.Add(new NavigationItem("\uE895", "艺人"));
            NavigationItems.Add(new NavigationItem("\uEa0b", "专辑"));
            NavigationItems.Add(new NavigationItem("\uE612", "歌曲"));

            PlayListItems = new ObservableCollection<NavigationItem>();
            PlayListItems.Add(new NavigationItem("\uE602", "所有播放列表"));
            PlayListItems.Add(new NavigationItem("\uE621", "喜爱的歌曲"));
        }
    }
}
