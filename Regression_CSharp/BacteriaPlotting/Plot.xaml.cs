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

            

            var r = new Random();
            ValuesA = new ChartValues<ObservablePoint>();

            for (int i = 0; i < bacteria[3].Measurements.Count; i++)
            {
                ValuesA.Add(new ObservablePoint(bacteria[3].Measurements[i], bacteria[12].Measurements[i]));
            }

            DataContext = this;
        }

        public ChartValues<ObservablePoint> ValuesA { get; set; }
    }
}
