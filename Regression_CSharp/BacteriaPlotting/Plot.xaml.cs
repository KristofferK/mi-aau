using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using BacteriaRegressionLibrary.BusinessLogic;
using LiveCharts.Wpf;
using System.Collections.Generic;
using LiveCharts.Helpers;
using BacteriaRegressionLibrary.Models;

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

            BacteriaChart.Series.RemoveAt(0);

            var bacteria = BacteriaImporter.Import(15);
            ShowBacteria(bacteria[3], bacteria[12]);
            ShowBacteria(bacteria[0], bacteria[1]);

            DataContext = this;
        }

        private void ShowBacteria(Bacterium b1, Bacterium b2)
        {
            var series = new ScatterSeries
            {
                Title = $"{b1.ASV} vs {b2.ASV}",
                Values = new ChartValues<ObservablePoint>()
            };

            for (int i = 0; i < b1.Measurements.Count; i++)
            {
                series.Values.Add(new ObservablePoint(b1.Measurements[i], b2.Measurements[i]));
            }

            BacteriaChart.Series.Add(series);
        }
    }
}
