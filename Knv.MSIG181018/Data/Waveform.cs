

namespace Knv.MSIG181018.Data
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Numerics;

    public class Waveform : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public double Offeset { get; set;}

        /// <summary>
        /// A jel frekveciája
        /// </summary>
        public double Freq { get; set; }
        /// <summary>
        /// Két minta közötti idő sec-ben.
        /// </summary>
        public double DeltaX { get; set; }
        /// <summary>
        /// Minták
        /// </summary>
        public double[] YArray { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public Waveform()
        {

        }
    

        /// <summary>
        /// Brute Forece FFT Calcualtor
        /// </summary>
        /// <returns></returns>
        public Complex[] FftBruteFroce()
        {
            var N = YArray.Length;
            var Xre = new double[N];
            var Xim = new double[N];
            var complexArray = new Complex[N];
            for (int k = 0; k < N; ++k)
            {

                for (int n = 0; n < N; ++n) Xre[k] += YArray[n] * Math.Cos(n * k * 2 * Math.PI / N);
                for (int n = 0; n < N; ++n) Xim[k] -= YArray[n] * Math.Sin(n * k * 2 * Math.PI / N);
                complexArray[k] = new Complex(Math.Round(Xre[k], 3), Math.Round(Xim[k], 3));
            }
            return complexArray;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex FftLight(double[] x)
        {
            double[] sinTable_16 =
            {
                0,
                0.382683432,
                0.707106781,
                0.923879533,
                1,
                0.923879533,
                0.707106781,
                0.382683432,
                0.0,
                -0.382683432,
                -0.707106781,
                -0.923879533,
                -1,
                -0.923879533,
                -0.707106781,
                -0.382683432,
            };
            double[] cosTable_16 =
            {
                1.0 ,
                0.923879533,
                0.707106781,
                0.382683432,
                0.0,
                -0.382683432,
                -0.707106781,
                -0.923879533,
                -1.0,
                -0.923879533,
                -0.707106781,
                -0.382683432,
                0.0,
                0.382683432,
                0.707106781,
                0.923879533,
            };

            Byte dft_index = 0;
            const Byte DFT_LEN = 64;

            double Re = 0;
            double Im = 0;
            int N = x.Length;

            for (int n = 0; n < N; n++)
            {
                double _cos = cosTable_16[dft_index & 15];
                double _sin = sinTable_16[dft_index & 15];

                Re += x[dft_index] * _cos;
                Im += x[dft_index] * _sin; ;

                dft_index++;
                dft_index &= (DFT_LEN - 1);
            }
            return new Complex(Math.Round(Re, 4), Math.Round(Im, 4));
        }


        /// <summary>
        /// 
        /// SmapleRate / SampleLength
        /// 
        /// SampleRate: 5KHz
        /// SampleLength: 128 p.cs.
        /// 
        /// 5KHz/128 = 39Hz/bin
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetFftBin()
        {
            return (1.0 / DeltaX) / YArray.Length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double[] GetFftBins()
        {
            var bins = new double[YArray.Length];

            for (int i = 0; i < bins.Length; i++)
            {
                bins[i] = i * GetFftBin();
            }

            return bins;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double[] GetPowerSpectrum()
        {
            var complexSignal = FftBruteFroce();
            var spectrum = new double[complexSignal.Length];
            var index = 0;
            foreach (var signal in complexSignal)
                spectrum[index++] = Complex.Abs(signal);
            return spectrum;
        }

        /// <summary>
        /// 
        /// </summary>
        public double Effective()
        {

            return 0;
        }
    }

    public class WaveformCollection : BindingList<Waveform>
    {

    }





}
