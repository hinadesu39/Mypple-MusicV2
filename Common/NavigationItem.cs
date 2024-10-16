﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Common
{
    public partial class NavigationItem : ObservableObject
    {

        [ObservableProperty]
        private string content;
        [ObservableProperty]
        private string toolTip;
        [ObservableProperty]
        private Type viewModelType;
        [ObservableProperty]
        private bool isNavigated;
        [ObservableProperty]
        private ObservableCollection<NavigationItem> subNavigationItems;
        [ObservableProperty]
        private Dictionary<string, object> parameters;

        public NavigationItem(string content, string toolTip, Type viewModelType = null, Dictionary<string, object> parameters = null)
        {
            this.Content = content;
            this.ToolTip = toolTip;
            this.viewModelType = viewModelType;
            this.parameters = parameters;
        }
    }
}
