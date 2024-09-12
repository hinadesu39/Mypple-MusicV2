using CommunityToolkit.Mvvm.ComponentModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mypple_MusicV2.ViewModels
{
    internal class MainViewModel:ObservableObject
    {
        private ILogger logger;

        public MainViewModel(ILogger logger)
        {
            this.logger = logger;
            logger.Debug("Hello World");
        }
    }
}
