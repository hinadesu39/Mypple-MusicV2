using Bogus;
using Common;
using CommunityToolkit.Mvvm.ComponentModel;
using Mypple_MusicV2.Models;
using Mypple_MusicV2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mypple_MusicV2.ViewModels
{
    public partial class ArtistViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Artist> artists;

        public ArtistViewModel()
        {
            Artists = new ObservableCollection<Artist>(Artist.FakeMany(20));
        }
    }
}
