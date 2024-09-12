using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BaseViewModel : ObservableObject
    {
        public virtual void OnNavigationTo(Dictionary<string, object>? parameters)
        {

        }

        public virtual void OnNavigationFrom()
        {

        }
    }
}
