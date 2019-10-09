using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using BacteriaRegressionLibrary.BusinessLogic;

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

            var bacteria = BacteriaImporter.Import(15);

            Series1.Title = $"{bacteria[3].ASV} vs {bacteria[12].ASV}";
            Series2.Title = $"{bacteria[0].ASV} vs {bacteria[1].ASV}";

            // BacteriaChart.Series.

            for (int i = 0; i < bacteria[3].Measurements.Count; i++)
            {
                ValuesA.Add(new ObservablePoint(bacteria[3].Measurements[i], bacteria[12].Measurements[i]));
                ValuesB.Add(new ObservablePoint(bacteria[0].Measurements[i], bacteria[1].Measurements[i]));
            }

            DataContext = this;
        }

        public ChartValues<ObservablePoint> ValuesA { get; set; } = new ChartValues<ObservablePoint>();
        public ChartValues<ObservablePoint> ValuesB { get; set; } = new ChartValues<ObservablePoint>();
    }
}
