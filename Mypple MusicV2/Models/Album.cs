using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        [ObservableProperty]
        private ObservableCollection<Music> musics;

        public static IEnumerable<Album> FakeMany(int count) => albumFaker.Generate(count);

        public static readonly Faker<Album> albumFaker = new Faker<Album>()
            .RuleFor(x => x.Id, Guid.NewGuid)
            .RuleFor(x => x.Type,x=>x.Person.FullName)
            .RuleFor(x => x.PublishTime,x=>x.Random.Int(1800,2024))
            .RuleFor(x => x.Title, x => x.Person.FirstName)
            .RuleFor(x => x.Artist, x => x.Person.LastName)
            .RuleFor(x => x.Musics, new ObservableCollection<Music>(Music.FakeMany(4)));

    }
}
