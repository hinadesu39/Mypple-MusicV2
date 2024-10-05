using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Mypple_MusicV2.Models
{
    public partial class Album : ObservableObject
    {
        [ObservableProperty]
        private Guid id;

        [ObservableProperty]
        private Uri? albumPicUrl;

        [ObservableProperty]
        private string localPicUrl;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private Guid artistId;

        [ObservableProperty]
        private string artist;

        [ObservableProperty]
        private string type;

        [ObservableProperty]
        private int publishTime;
    }
}
