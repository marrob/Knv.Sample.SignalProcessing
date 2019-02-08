

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

    public partial class ChartTestForm : Form
    {
        public ChartTestForm()
        {
            InitializeComponent();

        }

        [TestFixture]
        class UnitTest_Signals
        {
            [Test]
            public void Test1()
            {                var form = new ChartTestForm();
      

                var wavestore = new WaveformStorage();
                SignalCreator.CreateSample3(wavestore.Waveforms);


                wavestore.SaveToCsv("D:\\proba.csv");


                var chart = form.chart1;

                chart.Series.Clear();
                chart.Titles.Clear();

                chart.Titles.Add("Signals");

                for (int wave = 0; wave < wavestore.Waveforms.Count; wave++)
                {
                    var series = chart.Series.Add(wavestore.Waveforms[wave].Name);

                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

                    for (int yIndex = 0; yIndex < wavestore.Waveforms[wave].YArray.Length; yIndex++)
                    {
                        series.Points.Add(wavestore.Waveforms[wave].YArray[yIndex]);
                    }
                }


                form.ShowDialog();
            }
        }
    }
}

