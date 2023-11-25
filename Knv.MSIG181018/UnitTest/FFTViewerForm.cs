
namespace Knv.MSIG181018.UnitTest
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

                var wavestore = new WaveformStorage();

                SignalCreator.TestSignal(wavestore.Waveforms);
                Waveform  waveform = wavestore.Waveforms[0];
                var complexSignal = waveform.FftBruteFroce();
                var sepectrum = waveform.GetPowerSpectrum();

                /*---------*/
                var chart = form.chart1;
                chart.Series.Clear();
                chart.Titles.Clear();
                chart.Titles.Add("Signals");
                var series = chart.Series.Add("");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                for (int i = 0; i < waveform.YArray.Length; i++)
                    series.Points.Add(waveform.YArray[i]);
              
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
                for (int i = 0; i < complexSignal.Length; i++)
                    series.Points.Add(sepectrum[i]);

                var bins = waveform.GetFftBins();

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
