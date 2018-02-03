using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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

            #region Add TimeSeries
            {
                state.Chart = new Models.TimeChart(new Models.TimeSeries(1, "1"), state.DefaltColor);
            }
            #endregion

            #region Set UI Controls
            {
                Width = Properties.Settings.Default.Width;
                Height = Properties.Settings.Default.Height;

                ComboBox.ItemsSource = typeof(Colors).GetProperties();
            }
            #endregion

            #region Set Timer
            {
                m_Timer = new DispatcherTimer(DispatcherPriority.Normal);
                m_Timer.Interval = new TimeSpan(0, 0, 1);

                m_Timer.Tick += state.UpdateTimeSeriesCollection;
                m_Timer.Start();
            }
            #endregion

            DataContext = state;
        }

        private DispatcherTimer m_Timer;
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
            Properties.Settings.Default.Top = Top;
            Properties.Settings.Default.Left = Left;
            Properties.Settings.Default.Save();

            var state = DataContext as IDisposable;
            state.Dispose();
        }
    }
}
