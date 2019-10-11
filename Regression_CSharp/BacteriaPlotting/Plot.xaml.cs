using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using BacteriaRegressionLibrary.BusinessLogic;
using LiveCharts.Wpf;
using System.Collections.Generic;
using LiveCharts.Helpers;
using BacteriaRegressionLibrary.Models;
using System.Windows;
using System.Windows.Media;
using System.Linq;
using BacteriaRegressionLibrary.BusinessLogic.Regression;

namespace BacteriaPlotting
{
    /// <summary>
    /// Interaction logic for Plot.xaml
    /// </summary>
    public partial class Plot : UserControl
    {
        public List<Bacterium> AvailableBacteria { get; set; }
        public Bacterium Bacterium1 { get; set; }
        public Bacterium Bacterium2 { get; set; }

        public Plot()
        {
            InitializeComponent();

            ResetSeries();

            AvailableBacteria = BacteriaImporter.Import(25);
            ShowBacteria(AvailableBacteria[3], AvailableBacteria[12]);
            ShowBacteria(AvailableBacteria[12], AvailableBacteria[3]);

            Bacterium1 = AvailableBacteria[3];
            Bacterium2 = AvailableBacteria[12];

            DataContext = this;
        }

        private void ShowBacteria(Bacterium b1, Bacterium b2)
        {
            var merged = BacteriaMerger.MergeBacteria(b1, b2);
            BacteriaChart.Series.Add(new ScatterSeries
            {
                Title = merged.ToString(),
                Values = new ChartValues<ObservablePoint>(merged.Points.Select(e => new ObservablePoint(e.Item1, e.Item2)))
            });
            
            var biggestX = merged.Points.Select(e => e.Item1).Max();
            var regressionResult = new Regression(new LinearRegression()).PerformRegression(merged);
            var startY = regressionResult.Regression.Transform(0);
            var endY = regressionResult.Regression.Transform(biggestX);

            BacteriaChart.Series.Add(new LineSeries
            {
                Title = $"Regression line ({merged.ToString()})",
                Values = new ChartValues<ObservablePoint>
                {
                    new ObservablePoint(0, startY),
                    new ObservablePoint(biggestX, endY)
                },
                Fill = Brushes.Transparent
            });
        }

        private void BtnMatchBacteria_Clicked(object sender, RoutedEventArgs e)
        {
            if (Bacterium1 == null || Bacterium2 == null)
            {
                MessageBox.Show("Please select bacteria to match");
                return;
            }
            ShowBacteria(Bacterium1, Bacterium2);
        }

        private void BtnClearBacteria_Clicked(object sender, RoutedEventArgs e)
        {
            ResetSeries();
        }

        private void ResetSeries()
        {
            BacteriaChart.Series = new SeriesCollection();
        }
    }
}
