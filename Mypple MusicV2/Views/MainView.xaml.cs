using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Common.WindowAccentCompositor;

namespace Mypple_MusicV2.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            this.SourceInitialized += Window_SourceInitialized;
        }

        private unsafe void Window_SourceInitialized(object sender, EventArgs e)
        {
            var hwndSource = (HwndSource)PresentationSource.FromVisual(this);
            var backdropType = (int)2;   // 0 到 4 分别是 '自动', '无', '云母(Mica)效果', '亚克力(Acrylic)效果', '云母备选(Mica Alt)效果'

            DwmSetWindowAttribute(hwndSource.Handle, DwmWindowAttribute.SYSTEMBACKDROP_TYPE, (nint)(void*)&backdropType, sizeof(int));
        }
    }
}
