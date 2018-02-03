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
using System.Windows.Threading;

namespace Wpf.Charts
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var state = new ViewModels.ViewModelBase<MainWindowState>().Restore();
            DataContext = state;

            Width = Properties.Settings.Default.Width;
            Height = Properties.Settings.Default.Height;

        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (WindowState != WindowState.Minimized)
            {
                Properties.Settings.Default.Width = this.ActualWidth;
                Properties.Settings.Default.Height = this.ActualHeight;
            }
            else if (WindowState == WindowState.Minimized)
            {
                Properties.Settings.Default.Width = this.Width;
                Properties.Settings.Default.Height = this.Height;
            }

            Properties.Settings.Default.Save();

            var state = DataContext as IDisposable;
            state.Dispose();
        }
    }
}
