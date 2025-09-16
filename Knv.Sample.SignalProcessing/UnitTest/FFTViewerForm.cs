
namespace Knv.Sample.SignalProcessing.UnitTest
{
    using System.Windows.Forms;
    using Data;
    using NUnit.Framework;


    public partial class FFTViewerForm : Form
    {
        public FFTViewerForm()
        {
            InitializeComponent();
        }

        [TestFixture]
        class UnitTest_Signals
        {
            [Test]
            public void Test1()
            {
                var form = new FFTViewerForm();
                var form2 = new SignalWiewerForm();
                var wfs = new WaveformStorage();

                wfs.Waveforms.Add(SignalTools.Generator(length:128, frequency: 1000, sampleRate:5000));
                var complexSignal = wfs.Waveforms[0].FftBruteForce();
                var sepectrum = wfs.Waveforms[0].GetPowerSpectrum();

                /*---------*/
                var chart = form.chart1;
                chart.Series.Clear();
                chart.Titles.Clear();
                chart.Titles.Add("Signals");
                var series = chart.Series.Add("");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                for (int i = 0; i < wfs.Waveforms[0].YArray.Length; i++)
                    series.Points.Add(wfs.Waveforms[0].YArray[i]);
              
                /*---------*/
                chart = form.chart2;
                chart.Series.Clear();
                chart.Titles.Clear();
                chart.Titles.Add("FFT-Imaginary");
                series = chart.Series.Add("");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                for (int i = 0; i < complexSignal.Length; i++)
                    series.Points.Add(complexSignal[i].Imaginary);

                /*---------*/
                chart = form.chart3;
                chart.Series.Clear();
                chart.Titles.Clear();
                chart.Titles.Add("FFT-Real");
                series = chart.Series.Add("");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                for (int i = 0; i < complexSignal.Length; i++)
                    series.Points.Add(complexSignal[i].Real);

                /*---------*/
                chart = form.chart4;
                chart.Series.Clear();
                chart.Titles.Clear();
                chart.Titles.Add("Power spectrum");
                series = chart.Series.Add("");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                for (int i = 0; i < sepectrum.Length; i++)
                    series.Points.Add(sepectrum[i]);

                var bins = wfs.Waveforms[0].GetFftBins();

                for (int i = 0; i < bins.Length; i++)
                {
                    var cl = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                    cl.FromPosition = i + 1.5;
                    cl.ToPosition = i + 0.5;
                    cl.Text = bins[i].ToString("0.00");
                  
                    chart.ChartAreas[0].AxisX.CustomLabels.Add(cl);
                }
                form2.Show();
                form.ShowDialog();
            }
        }

        private void FFTViewerForm_Load(object sender, System.EventArgs e)
        {

        }

        private void chart1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
