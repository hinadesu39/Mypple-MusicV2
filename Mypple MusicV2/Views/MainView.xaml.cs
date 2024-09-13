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
using System.Windows.Shapes;

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
            btn_Min.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };
            btn_Max.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    btn_Max.Content = "\uE65D";
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    btn_Max.Content = "\uE601";
                }
            };
            btn_Close.Click += (s, e) =>
            {
                this.Close();
            };
        }
    }
}
