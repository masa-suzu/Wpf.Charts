using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using LiveCharts;
using LiveCharts.Defaults;

namespace Wpf.Charts.Models
{
    
    public class TimeSeries: ChartValues<ObservableValue>
    {
        public TimeSeries(int seed)
        {
            m_rand = new Random(seed);

            this.AddRange(CreatePoints());
        }
        public void Update()
        {
            this.Add(new ObservableValue(m_rand.NextDouble()));
            this.RemoveAt(0);
        }

        private ChartValues<ObservableValue> CreatePoints()
        {
            var points = Enumerable.Range(0, 20).Select(
                    index => m_rand.Next(100));
            var d = new ChartValues<ObservableValue>();
            foreach (var item in points)
            {
                d.Add(new ObservableValue(item));
            }
            return d;
        }

        private Random m_rand;

    }
}
