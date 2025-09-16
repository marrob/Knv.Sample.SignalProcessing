
namespace Knv.Sample.SignalProcessing.UnitTest
{
    using System;
    using Knv.Sample.SignalProcessing.Data;
    using System.Diagnostics;
    using NUnit.Framework;

    //commit test
    [TestFixture]
    public class PowerSpectrum_UnitTest
    {
        [Test]
        public void PowerSpectrumWithCustomLabel()
        {

            var waveStore = new WaveformStorage();

            SignalCreator.TestSignal(waveStore.Waveforms);
            Waveform waveform = waveStore.Waveforms[0];
            var complexSignal = waveform.FftBruteForce();
            var spectrum = waveform.GetPowerSpectrum();


            var swf = new SignalWiewerForm();
            //---
            swf.Chart.Series.Clear();
            swf.Chart.Titles.Clear();
            swf.Chart.Titles.Add("Power spectrum");
            swf.Chart.Legends.Clear();
            var series = swf.Chart.Series.Add("");
            
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
           
            for (int i = 0; i < spectrum.Length; i++)
                series.Points.Add(spectrum[i]);

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


        [Test]
        public void PowerSpectrumWithCustomLabelx()
        {

            var waveStore = new WaveformStorage();

            SignalCreator.TestSignal(waveStore.Waveforms);
            Waveform waveform = waveStore.Waveforms[0];
            var complexSignal = waveform.FftBruteForce();
            var spectrum = waveform.GetPowerSpectrum();


            var swf = new SignalWiewerForm();
            //---
            swf.Chart.Series.Clear();
            swf.Chart.Titles.Clear();
            swf.Chart.Titles.Add("Power spectrum");
            swf.Chart.Legends.Clear();
            var series = swf.Chart.Series.Add("");

            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            for (int i = 0; i < spectrum.Length; i++)
                series.Points.Add(spectrum[i]);

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
