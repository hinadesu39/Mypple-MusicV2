using System.Collections.ObjectModel;
using Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Serilog;

namespace Mypple_MusicV2.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private ILogger logger;
        private INavigationService navigationService;
        private bool isBackgroundOperation;

        [ObservableProperty]
        private ObservableCollection<NavigationItem> navigationItems;

        [ObservableProperty]
        private BaseViewModel currentViewModel;

        [ObservableProperty]
        private bool isDrawerRightOpen;

        public MainViewModel() { }

        public MainViewModel(ILogger logger, INavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            Init();
        }

        [RelayCommand]
        public void Navigate(NavigationItem navigationItem)
        {
            CurrentViewModel = null;
            if (!isBackgroundOperation && navigationItem.ViewModelType != null)
                navigationService.NavigationTo(navigationItem.ViewModelType, navigationItem.Parameters);
        }

        [RelayCommand]
        public void GoBack()
        {
            if (navigationService.CanNavigateBack())
            {
                isBackgroundOperation = true;

                SetIsNavigatedState(false);

                navigationService.NavigateBack();

                SetIsNavigatedState(true);

                isBackgroundOperation = false;
            }
        }

        private void Init()
        {
            navigationService.CurrentViewModelChanged += () =>
            {
                CurrentViewModel = navigationService.CurrentViewModel;
            };

            NavigationItems = new ObservableCollection<NavigationItem>();
            NavigationItems.Add(
                new NavigationItem("\uE74f", "最近添加", typeof(RecentlyAddedViewModel))
            );
            NavigationItems.Add(new NavigationItem("\uE895", "艺人", typeof(ArtistViewModel)));
            NavigationItems.Add(new NavigationItem("\uEa0b", "专辑", typeof(AlbumViewModel)));
            NavigationItems.Add(new NavigationItem("\uE612", "歌曲", typeof(MusicViewModel)));
            NavigationItems.Add(
                new NavigationItem("\uEa86", "播放列表")
                {
                    SubNavigationItems = new ObservableCollection<NavigationItem>()
                    {
                        new NavigationItem("\uE602", "所有播放列表", typeof(AllPlayListViewModel)),
                        new NavigationItem("\uE621", "喜爱的歌曲", typeof(FavoriteMusicViewModel)),
                        new NavigationItem(
                            "\uEa86",
                            "进击的巨人",
                            typeof(PlayListViewModel),
                            new Dictionary<string, object>() { { "111", 1 } }
                        ),
                        new NavigationItem(
                            "\uEa86",
                            "游戏的小曲",
                            typeof(PlayListViewModel),
                            new Dictionary<string, object>() { { "111", 2 } }
                        ),
                    },
                }
            );
        }

        private void SetIsNavigatedState(bool state)
        {
            foreach (var item in NavigationItems)
            {
                if (item.SubNavigationItems != null)
                {
                    foreach (var subItem in item.SubNavigationItems)
                    {
                        if (subItem.ViewModelType == CurrentViewModel.GetType())
                            subItem.IsNavigated = state;
                    }
                }
                else
                {
                    if (item.ViewModelType == CurrentViewModel.GetType())
                        item.IsNavigated = state;
                }
            }
        }
    }
}
