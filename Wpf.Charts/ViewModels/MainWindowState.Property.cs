using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

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
        public Models.TimeSeries DataList1 { get; }
        [XmlIgnore]
        public Models.TimeSeries DataList2 { get; }
        [XmlIgnore]
        public Models.TimeSeries DataList3 { get; }
        [XmlIgnore]
        public Models.TimeSeries DataList4 { get; }
        [XmlIgnore]
        public Models.TimeSeries DataList5 { get; }

    }
}
