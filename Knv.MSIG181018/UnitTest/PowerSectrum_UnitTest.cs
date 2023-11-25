
namespace Knv.MSIG181018.UnitTest
{
    using System;
    using Knv.MSIG181018.Data;
    using System.Diagnostics;
    using NUnit.Framework;


    [TestFixture]
    public class PowerSectrum_UnitTest
    {

        [Test]
        public void PowerSpectrumWithCustomLabel()
        {

            var wavestore = new WaveformStorage();

            SignalCreator.TestSignal(wavestore.Waveforms);
            Waveform waveform = wavestore.Waveforms[0];
            var complexSignal = waveform.FftBruteFroce();
            var sepectrum = waveform.GetPowerSpectrum();


            var swf = new SignalWiewerForm();
            /*---------*/
            swf.Chart.Series.Clear();
            swf.Chart.Titles.Clear();
            swf.Chart.Titles.Add("Power spectrum");
            swf.Chart.Legends.Clear();
            var series = swf.Chart.Series.Add("");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            for (int i = 0; i < complexSignal.Length; i++)
                series.Points.Add(sepectrum[i]);

            var bins = waveform.GetFftBins();

            var width = swf.Chart.Width;
            Debug.Write("Width:" + width);

            for (int i = 0; i < bins.Length; i++)
            {
                var cl = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                cl.FromPosition = i + 1.5;
                cl.ToPosition = i + 2.5;
                cl.Text = bins[i].ToString("0.00");

                swf.Chart.ChartAreas[0].AxisX.CustomLabels.Add(cl);
            }
            swf.ShowDialog();
        }
    }
}
