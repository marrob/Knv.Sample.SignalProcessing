using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Knv.Sample.SignalProcessing.Data
{
    public partial class WaveFormStorageViewerForm : Form
    {
        readonly WaveformStorage _wfs;

        public WaveFormStorageViewerForm(WaveformStorage wfs)
        { 
            InitializeComponent();
            _wfs = wfs;
            DrawSeriesWaveform(_wfs.Waveforms[0]);
        }


        public WaveFormStorageViewerForm()
        {
            InitializeComponent();
            DrawSeriesWaveform(_wfs.Waveforms[0]);
        }

        void DrawSeriesWaveform(Waveform wf)
        { 
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add(wf.Name);
            var series = chart1.Series.Add("");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            for (int i = 0; i < _wfs.Waveforms[0].YArray.Length; i++)
                series.Points.Add(wf.YArray[i]);

        }
    }
}
