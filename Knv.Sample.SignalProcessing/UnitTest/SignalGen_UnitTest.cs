
namespace Knv.Sample.SignalProcessing.UnitTest
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

            var deltaT = 1.0 / (samples / 2);

            for (int i = samples / 2; i < samples; i++)
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
            double freq = 1;
            int samples = 256;
            double amp = 1;

            double samplingClockRate = samples;
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

        [Test]
        public void I2S_SineGen()
        {
            double freq = 100;
            int samples = 44100;
            double amp = 32767;

            short[] samplesBuffer = new short[samples];
            double deltaT = 1.0 / samples;

            for (int i = 0; i < samples; i++)
                samplesBuffer[i] = (short)(amp * Math.Sin(2.0 * Math.PI * freq * i * deltaT));

            var swf = new SignalWiewerForm();
            swf.Chart.Legends.Clear();
            swf.Chart.Titles.Add("i2s_array");
            for (int i = 0; i < samplesBuffer.Length; i++)
                swf.Chart.Series[0].Points.AddXY(i, samplesBuffer[i]);


            var path = Tools.ArrayToFile_C_Uint16(samplesBuffer, "i2s_array");

            Tools.OpenLogByNpp(path);

            swf.ShowDialog();
        }


        [Test]
        public void I2S_DataOrder()
        {
            int[] samplesBuffer = new int[] { 1, 2, 3 };
            var path = Tools.ArrayToFile_C_Uint32(samplesBuffer, "i2s_array");
            Tools.OpenLogByNpp(path);

        }

    }
}
