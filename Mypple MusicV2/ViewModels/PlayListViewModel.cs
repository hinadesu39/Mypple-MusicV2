using Common;
using CommunityToolkit.Mvvm.ComponentModel;
using Mypple_MusicV2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mypple_MusicV2.ViewModels
{
    public partial class PlayListViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Music> testMusic;

        public PlayListViewModel()
        {
            TestMusic = new ObservableCollection<Music>();
            for (int i = 0; i < 2000; i++)
            {
                TestMusic.Add(new Music()
                {
                    Title = "222",
                    Album = "111",
                    Artist = "111",
                    Type = "True",
                    Duration = 180
                });
            }
        }
        public override void OnNavigationTo(Dictionary<string, object>? parameters = null)
        {
            base.OnNavigationTo(parameters);
        }
    }
}
