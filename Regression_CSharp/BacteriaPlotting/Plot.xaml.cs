using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;

namespace BacteriaPlotting
{
    /// <summary>
    /// Interaction logic for Plot.xaml
    /// </summary>
    public partial class Plot : UserControl
    {
        public Plot()
        {
            InitializeComponent();

            var r = new Random();
            ValuesA = new ChartValues<ObservablePoint>();

            for (var i = 0; i < 20; i++)
            {
                ValuesA.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
            }

            DataContext = this;
        }

        public ChartValues<ObservablePoint> ValuesA { get; set; }
    }
}
