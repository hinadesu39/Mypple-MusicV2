using Mypple_MusicV2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mypple_MusicV2.UserControls
{
    /// <summary>
    /// PlaybackControlBar.xaml 的交互逻辑
    /// </summary>
    public partial class PlaybackControlBar : UserControl
    {
        public PlaybackControlBar()
        {
            InitializeComponent();
            var mainView = Application.Current.MainWindow as MainView;
            btn_Min.Click += (s, e) =>
            {
                mainView.WindowState = WindowState.Minimized;
            };
            btn_Max.Click += (s, e) =>
            {
                if (mainView.WindowState == WindowState.Maximized)
                {
                    mainView.WindowState = WindowState.Normal;
                    btn_Max.Content = "\uE65D";
                }
                else
                {
                    mainView.WindowState = WindowState.Maximized;
                    btn_Max.Content = "\uE601";
                }
            };
            btn_Close.Click += (s, e) =>
            {
                mainView.Close();
            };
        }
    }
}
