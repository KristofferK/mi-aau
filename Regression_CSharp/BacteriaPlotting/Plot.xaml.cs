﻿using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using BacteriaRegressionLibrary.BusinessLogic;
using LiveCharts.Wpf;
using System.Collections.Generic;
using LiveCharts.Helpers;
using BacteriaRegressionLibrary.Models;
using System.Windows;

namespace BacteriaPlotting
{
    /// <summary>
    /// Interaction logic for Plot.xaml
    /// </summary>
    public partial class Plot : UserControl
    {
        public List<Bacterium> AvailableBacteria { get; set; }
        public Bacterium Bacteria1 { get; set; }
        public Bacterium Bacteria2 { get; set; }

        public Plot()
        {
            InitializeComponent();

            ResetSeries();

            var bacteria = BacteriaImporter.Import(15);
            AvailableBacteria = bacteria;
            ShowBacteria(bacteria[3], bacteria[12]);
            ShowBacteria(bacteria[12], bacteria[3]);

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

        private void BtnMatchBacteria_Clicked(object sender, RoutedEventArgs e)
        {
            if (Bacteria1 == null || Bacteria2 == null)
            {
                MessageBox.Show("Please select bacteria to match");
                return;
            }
            ShowBacteria(Bacteria1, Bacteria2);
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
