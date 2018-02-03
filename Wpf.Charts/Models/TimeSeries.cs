using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;

namespace Wpf.Charts.Models
{
    public class TimeSeries : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TimeSeries(int seed)
        {
            DataList = CreatePoints(seed);
        }
        public ObservableCollection<DataPoint> DataList
        {
            get { return m_DataList; }
            set
            {
                if (Equals(m_DataList, value)) return;

                m_DataList = value;
                PropertyChanged.Raise(() => DataList);
            }
        }
        private ObservableCollection<DataPoint> m_DataList;
        private ObservableCollection<DataPoint> CreatePoints(int seed)
        {
            var rand = new Random(seed);
            var points = Enumerable.Range(0, 11).Select(
                    index => new DataPoint(index, rand.Next(100)));
            return new ObservableCollection<DataPoint>(points);
        }
    }
}
