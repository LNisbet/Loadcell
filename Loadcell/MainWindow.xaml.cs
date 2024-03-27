using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using Loadcell.Core;

namespace LoadCell
{
    public partial class MainWindow : Window , INotifyPropertyChanged
    {

        //ISensor loadcell = new MockSensor();
        public string value = "";
        float[] log = new float[100];
        public ISeries[] Series { get; set; }
    = new ISeries[]
    {
                new LineSeries<float>
                {
                    Values = new float[] { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null
                }
    };

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            ReadData();
        }
        private async void ReadData()
        {
            while (true)
            {
                await Task.Delay(2000);

                //float val = loadcell.Value;
                //value = Convert.ToString(val);
                
                var arr = log;
                Array.Copy(arr, 0, log, 1, log.Length - 1);
                //log[0] = val;
                //TestChart.Series = new LineSeries<float> { Values = log, Fill = null },0;
                Value_TextBlock.Text = value;
            }
        }
        private void PlotGraph()
        {

        }

        private void Test_Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Convert.ToString(log[0]) + ", " + Convert.ToString(log[1]) + ", " + Convert.ToString(log[2]));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
