using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Wpf.Charts.Models;

namespace Wpf.Charts.Models
{
    public class TimeChart
    {
        public TimeChart(TimeSeries ts, Color color)
        {
            Source = ts;

            var brush = new SolidColorBrush(color);
            Series = new SeriesCollection();
            AxesY = new AxesCollection();

            Series.Add(new LineSeries
            {
                Values = ts,
                Stroke = brush
            });
            AxesY.Add(new Axis()
            {
                Title = ts.Label,
                Foreground = brush
            });

            Color = color;

        }
        public SeriesCollection Series { get; set; }
        public AxesCollection AxesY { get; set; }

        public TimeSeries Source{ get;set;}
        public Color Color
        {
            get { return m_color; }
            set
            {
                if(m_color == value) { return; }

                m_color = value ;

                var brush = new SolidColorBrush(Color);

                var ls = Series.FirstOrDefault() as LineSeries;
                ls.Stroke = brush;

                AxesY.FirstOrDefault().Foreground = brush;
            }
        }
        private Color m_color;
    }
}
