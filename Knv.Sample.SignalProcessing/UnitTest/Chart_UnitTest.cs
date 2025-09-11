
namespace Knv.Sample.SignalProcessing.UnitTest
{
    using System;
    using Knv.Sample.SignalProcessing.Data;
    using System.Diagnostics;
    using NUnit.Framework;
    using System.Windows.Forms.DataVisualization.Charting;


    [TestFixture]
    public class Chart_UnitTest
    {

        [Test]
        public void MultipleSignals()
        {
            var wavestore = new WaveformStorage();
            SignalCreator.CreateSample3(wavestore.Waveforms);

            wavestore.SaveToCsv("D:\\char_unit_test_from_signal_processing.csv");

            var swf = new SignalWiewerForm();

            swf.Chart.Series.Clear();
            swf.Chart.Titles.Clear();

            swf.Chart.Titles.Add("Signals");


            for (int wave = 0; wave < wavestore.Waveforms.Count; wave++)
            {
                var series = swf.Chart.Series.Add(wavestore.Waveforms[wave].Name);
                series.ChartType = SeriesChartType.Spline;

                for (int yIndex = 0; yIndex < wavestore.Waveforms[wave].YArray.Length; yIndex++)
                    series.Points.Add(wavestore.Waveforms[wave].YArray[yIndex]);

            }
            swf.ShowDialog();
        }

        [Test]
        public void LinearSignal()
        {
            var buffer = new double[100];

            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = i;


            var swf = new SignalWiewerForm();
            swf.Chart.Series.Clear();
            swf.Chart.Titles.Clear();
            swf.Chart.Titles.Add("Signals");
            swf.Chart.Series.Add("Linear");
            swf.Chart.Series["Linear"].ChartType = SeriesChartType.Spline;
            swf.Chart.Legends.Clear();

            for (int i = 0; i < buffer.Length; i++)
                swf.Chart.Series[0].Points.AddXY(i, buffer[i]);

            swf.ShowDialog();
        }
    }
}
