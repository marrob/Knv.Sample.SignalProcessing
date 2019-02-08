


namespace Konvolucio.MSIG181018.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Data;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Net.Configuration;
    using System.Net.Mail;
    using NUnit.Framework;
    using System.Numerics;
    using System.Threading;
    using NUnit.Framework.Constraints;
    using System.Diagnostics;

    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        [TestFixture]
        class UnitTest_Signals
        {
            [Test]
            public void Test1()
            {
                var form = new Form3();

                var wavestore = new WaveformStorage();

                SignalCreator.TestSignal(wavestore.Waveforms);
                Waveform  waveform = wavestore.Waveforms[0];
                var complexSignal = waveform.FftBruteFroce();
                var sepectrum = waveform.GetPowerSpectrum();
                var chart = form.chart1;


                /*---------*/
                chart = form.chart1;
                chart.Series.Clear();
                chart.Titles.Clear();
                chart.Titles.Add("Power spectrum");
                var series = chart.Series.Add("");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                for (int i = 0; i < complexSignal.Length; i++)
                    series.Points.Add(sepectrum[i]);

                var bins = waveform.GetFftBins();

                var width = chart.Width;
                Debug.Write("Width:" + width);

                for (int i = 0; i < bins.Length; i++)
                {
                    var cl = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
                    cl.FromPosition = i + 1.5;
                    cl.ToPosition = i + 2.5;
                    cl.Text = bins[i].ToString("0.00");
                  
                    chart.ChartAreas[0].AxisX.CustomLabels.Add(cl);
                }
                form.ShowDialog();
            }
        }
    }
}
