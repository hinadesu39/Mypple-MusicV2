using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mypple_MusicV2.Models
{
    public partial class Music : ObservableObject
    {
        [ObservableProperty]
        private Guid id;
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private Uri audioUrl;
        [ObservableProperty]
        private Uri? musicPicUrl;
        [ObservableProperty]
        private string localPicUrl;
        [ObservableProperty]
        private double duration;
        [ObservableProperty]
        private Guid artistId;
        [ObservableProperty]
        private string artist;
        [ObservableProperty]
        private Guid albumId;
        [ObservableProperty]
        private string album;
        [ObservableProperty]
        private string type;
        [ObservableProperty]
        private string lyric;
        [ObservableProperty]
        private int publishTime;
        [ObservableProperty]
        private PlayStatus status;

        public enum PlayStatus
        {
            StartPlay, //正在播放
            PausePlay, //暂停播放
            StopPlay //彻底关闭
        }
    }
}
