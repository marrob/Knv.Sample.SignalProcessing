
namespace Knv.MSIG181018.UnitTest
{
    using System;
    using NUnit.Framework;


    [TestFixture]
    public class SignalGen_UnitTest
    {
        [Test]
        public void SineGenWithSaplingTime()
        {
            int samples = 1000;
            double[] samplesBuffer = new double[samples];
            var deltaT = 1.0 / samples; //ennyi lesz a felbontása a generált jelnek

            for (int i = 0; i < samples; i++)
                samplesBuffer[i] = Math.Sin(2.0 * Math.PI * i * deltaT);

            var swf = new SignalWiewerForm();
            swf.Chart.Legends.Clear();

            for (int i = 0; i < samplesBuffer.Length; i++)
                swf.Chart.Series[0].Points.AddXY(i, samplesBuffer[i]);

            swf.ShowDialog();
        }


        [Test]
        public void HalfSinePulse()
        {

            /*
             * HalfSine Pulse, a minták közepétől kezdödik
             */

            int samples = 1000;
            double[] samplesBuffer = new double[samples];

            var deltaT = 1.0 / (samples/2);

            for (int i = samples/2; i < samples; i++)
                samplesBuffer[i] = Math.Sin(-1 * Math.PI * i * deltaT);

            var swf = new SignalWiewerForm();
            swf.Chart.Legends.Clear();
            swf.Chart.Titles.Add("HalfSinePulse");

            for (int i = 0; i < samplesBuffer.Length; i++)
                swf.Chart.Series[0].Points.AddXY(i, samplesBuffer[i]);

            swf.ShowDialog();
        }

        [Test]
        public void HalfSinePulseFor12bitDAC()
        {

            int samples = 1000;
            double[] samplesBuffer = new double[samples];

            var deltaT = 1.0 / (samples / 2);

            for (int i = samples / 2; i < samples; i++)
                samplesBuffer[i] = 4096 * Math.Sin(-1 * Math.PI * i * deltaT);

            var swf = new SignalWiewerForm();
            swf.Chart.Legends.Clear();
            swf.Chart.Titles.Add("HalfSinePulseFor12bitDAC");

            for (int i = 0; i < samplesBuffer.Length; i++)
                swf.Chart.Series[0].Points.AddXY(i, samplesBuffer[i]);

            swf.ShowDialog();
        }


        [Test]
        public void SineGenWithFreqSamplesAmp()
        {
            double freq = 50;
            int samples = 256;
            double amp = 1;

            double samplingClockRate = freq * samples;
            double[] samplesBuffer = new double[samples];
            double deltaT = 1 / samplingClockRate;

            for (int i = 0; i < samples; i++)
                samplesBuffer[i] = amp * Math.Sin(2.0 * Math.PI * freq * i * deltaT);

            var swf = new SignalWiewerForm();
            swf.Chart.Legends.Clear();
            swf.Chart.Titles.Add("SineGenWithFreqSamplesAmp");
            for (int i = 0; i < samplesBuffer.Length; i++)
                swf.Chart.Series[0].Points.AddXY(i, samplesBuffer[i]);

            swf.ShowDialog();
        }

    }
}
