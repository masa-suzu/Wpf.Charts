using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
using Wpf.Charts.Models;
using Wpf.Charts.ViewModels;

namespace Wpf.Charts
{
    public partial class MainWindowState : INotifyPropertyChanged
    {
        public MainWindowState()
        {
            m_base = new ViewModels.ViewModelBase<MainWindowState>();
        }

        public MainWindowState(
            double maxHeight, 
            double maxWidth, 
            ResizeMode resizeMode,
            Color color)
        {
            MaxHeight = maxHeight;
            MaxWidth = maxWidth;
            ResizeMode = resizeMode;
            DefaltColor = color;
        }
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

        public Color DefaltColor
        {
            get
            {
                if(m_Chart == null) { return m_Color; }

                else
                {
                    return m_Chart.Color;
                }
            }
            set { m_Color = value; }
        }
        private Color m_Color;

        [XmlIgnore]
        public TimeChart Chart {
            get { return m_Chart; }
            set
            {
                m_Chart = value;
            }
        }
        private TimeChart m_Chart;

        public void UpdateTimeSeriesCollection(object sender, EventArgs e)
        {
            Chart.Source.Update();
            if (Chart.Color == Colors.Red)
            {
                Chart.Color = Colors.Blue;
            }
            else if (Chart.Color == Colors.Blue)
            {
                Chart.Color = Colors.Red;
            }
        }
    }
}
