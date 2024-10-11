using Bogus;
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

        public static IEnumerable<Music> FakeMany(int count) => musicFaker.Generate((new Random()).Next(count,20));

        public static readonly Faker<Music> musicFaker = new Faker<Music>()
            .RuleFor(x => x.Id, Guid.NewGuid)
            .RuleFor(x => x.Title, x => x.Person.FirstName)
            .RuleFor(x => x.Artist, x => x.Person.LastName)
            .RuleFor(x => x.Duration, x => x.Random.Double(180, 300));         
    }
}
