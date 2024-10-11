using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        [ObservableProperty]
        private ObservableCollection<Album> albums;

        public static IEnumerable<Artist> FakeMany(int count) => artistFaker.Generate(count);

        public static readonly Faker<Artist> artistFaker = new Faker<Artist>()
            .RuleFor(x => x.Id, Guid.NewGuid)
            .RuleFor(x => x.Name, x => x.Person.FirstName)
            .RuleFor(x => x.Albums, new ObservableCollection<Album>(Album.FakeMany(3)));
    }
}
