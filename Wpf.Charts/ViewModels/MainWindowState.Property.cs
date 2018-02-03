using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
using Wpf.Charts.Models;

namespace Wpf.Charts
{
    public partial class MainWindowState :INotifyPropertyChanged
    { 
        public event PropertyChangedEventHandler PropertyChanged;

        public double MaxHeight
        {
            get { return _Height; }
            set
            {
                if (Equals(_Height, value)) return;

                //if (value >= 600) { value = 600; }
                if (value <= Properties.Settings.Default.MinHeight)
                { value = Properties.Settings.Default.MinHeight; }

                _Height = value;
                PropertyChanged.Raise(() => MaxHeight);
            }
        }
        public double MaxWidth
        {
            get { return _Width; }
            set
            {
                if (Equals(_Width, value)) return;

                //if (value >= 300) { value = 300; }
                if (value <= Properties.Settings.Default.MinWidth)
                { value = Properties.Settings.Default.MinWidth; }

                _Width = value;
                PropertyChanged.Raise(() => MaxWidth);
            }
        }
        private double _Height;
        private double _Width;

        public ResizeMode ResizeMode
        {
            get { return _ResizeMode; }
            set
            {
                if (Equals(_ResizeMode, value)) return;

                _ResizeMode = value;
                PropertyChanged.Raise(() => _ResizeMode);
            }
        }
        private ResizeMode _ResizeMode;

        [XmlIgnore]
        public SeriesCollection Series { get; set; }
        private List<TimeSeries> m_TimeSeriesCollection { get; set; }

        public void AddTimeSeries(TimeSeries series)
        {
            Series.Add(new LineSeries
            {
                Values = series
            });
            m_TimeSeriesCollection.Add(series);
        }

        public void UpdateTimeSeriesCollection(object sender, EventArgs e)
        {
            foreach (var item in m_TimeSeriesCollection)
            {
                item.Update();
            }
        }
    }
}
