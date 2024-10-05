using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mypple_MusicV2.Models
{
    public partial class Artist : ObservableObject
    {
        [ObservableProperty]
        private Guid id;

        [ObservableProperty]
        private Uri? artistPicUrl;

        [ObservableProperty]
        private string localPicUrl;

        [ObservableProperty]
        private string name;
    }
}
