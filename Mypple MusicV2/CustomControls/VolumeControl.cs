using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mypple_MusicV2.CustomControls
{
    public class VolumeControl : ToggleButton
    {
        public double VolumeValue
        {
            get { return (double)GetValue(VolumeValueProperty); }
            set { SetValue(VolumeValueProperty, value); }
        }

        public static readonly DependencyProperty VolumeValueProperty =
            DependencyProperty.Register("VolumeValue", typeof(double), typeof(VolumeControl), new PropertyMetadata(1.0));


        static VolumeControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumeControl), new FrameworkPropertyMetadata(typeof(VolumeControl)));
        }
    }
}
