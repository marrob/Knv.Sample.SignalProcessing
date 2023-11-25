

namespace Knv.MSIG181018.Data
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SignalCreator
    {

        public SignalCreator()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public static void CreateSample1(WaveformCollection waveforms)
        {
            Generator(256/*p.cs*/, 5.0/*Hz*/, 100.0/*Hz*/, waveforms);
        }

        public static void Generator(int length, double frequency, double sampleRate, WaveformCollection waveforms)
        {
            /*
            * This data was generated using the function definition:
            *
            *   sin(2 * pi * freq * time)
            *   
            *   freq = 5Hz
            *   sampling rate = 100Hz
            *   
            *   0. => sin( 2 * pi  0/100 * 5) = 0.
            *   1. => sin( 2 * pi  1/100 * 5) = 0.3090
            *   2. => sin( 2 * pi  1/100 * 5) = 0.5877 
            *
            * */

            var wave = new Waveform();
            wave.Name = "wave1";
            wave.Freq = frequency; /*Hz*/
            wave.DeltaX = 1 / sampleRate; /*sec*/

            wave.Timestamp = new DateTime(1985, 01, 23, 07, 30, 33);

            wave.YArray = new double[length];

            for (int pointIndex = 0; pointIndex < length; pointIndex++)
            {
                wave.YArray[pointIndex] = Math.Sin(2 * Math.PI * (pointIndex / sampleRate) * frequency);
            }

            for (int i = 0; i < wave.YArray.Length; i++)
                wave.YArray[i] = Math.Round(wave.YArray[i], AppConstants.RoundDigits);

            waveforms.Add(wave);

        }

        /// <summary>
        /// 
        /// </summary>
        public static void CreateSample2(WaveformCollection waveforms)
        {
            var wave1 = new Waveform();
            wave1.Name = "Sine Wave";
            wave1.Timestamp = new DateTime(1985, 01, 23, 07, 30, 33);
            wave1.DeltaX = 1; /*sec*/
            wave1.YArray = new double[] { 0, 0.707, 1, 0.707, 0, -0.707, -1, -0.707 };
            waveforms.Add(wave1);
        }

        /// </summary>
        public static void TestSignal(WaveformCollection waveforms)
        {
            Generator(
                        length: 128/*p.cs*/,
                        frequency: 1000 /*Hz*/, 
                        sampleRate: 5000 /*Hz*/, 
                        waveforms: waveforms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="waveforms"></param>
        public static void CreateSample3(WaveformCollection waveforms)
        {
            Generator(1, 5, Math.PI / 20, 0, 0, waveforms);
            Generator(1, 5, Math.PI / 20, Math.PI, 0, waveforms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amplitude"></param>
        /// <param name="cycleNum">The periodic count. eg.:1,2,3...n</param>
        /// <param name="resolution">Period resolution  in radian. min: 2*Math.PI , or Math.PI/20 </param>
        /// <param name="phase">Phase in radian. eg.: Math.PI/2 = 90degree </param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static void Generator(   double amplitude,
                                            int cycleNum,
                                            double resolution,
                                            double phase,
                                            double offset,
                                            WaveformCollection waveforms)
        {

            var wave = new Waveform();
            
            wave.Name = "Sine Wave" +  Guid.NewGuid().ToString() ;
            wave.Timestamp = new DateTime(1985, 01, 23, 07, 30, 33);
            wave.DeltaX = 1; /*sec*/

            double[] sequence = new double[0];
            int index = 0;
            for (int cycle = 0; cycle < cycleNum; cycle++)
            for (double p = 0; p <= (2 * Math.PI); p += resolution)
            {
                Array.Resize(ref sequence, index + 1);
                sequence[index++] = amplitude * Math.Sin(p + phase) + offset;
                
            }

            wave.YArray = new double[index + 1];
            sequence.CopyTo(wave.YArray, 0);

            for (int i = 0; i < wave.YArray.Length; i++)
                wave.YArray[i] = Math.Round(wave.YArray[i], AppConstants.RoundDigits);
   
            waveforms.Add(wave);
        }


    
    }
}
