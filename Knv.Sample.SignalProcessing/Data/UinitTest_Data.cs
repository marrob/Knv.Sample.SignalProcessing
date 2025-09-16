
namespace Knv.Sample.SignalProcessing.Data
{
    using NUnit.Framework;

    [TestFixture]
    class UinitTest_Data
    {
        [Test]
        public void WaveformStorage_UnitTest()
        { 
            var wfs = new WaveformStorage();
            wfs.Waveforms.Add(new Waveform() { Name = "Sine Wave", DeltaX = 1.0 / 50000 });
            wfs.Waveforms[0].YArray = new double[]
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

            wfs.Waveforms.Add(new Waveform() { Name = "Cosine Wave", DeltaX = 1.0 / 50000 });
            wfs.Waveforms[1].YArray = new double[]
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

            new WaveFormStorageViewerForm (wfs).ShowDialog();
            Assert.Pass();
        }

        [Test]
        public void SignalTools_Generator_UnitTest()
        {
            var wfs = new WaveformStorage();
            wfs.Waveforms.Add(SignalTools.Generator(length:1000, frequency: 1000, sampleRate: 50000));
            new WaveFormStorageViewerForm(wfs).ShowDialog();
            Assert.Pass();
        }

        [Test]
        public void CsvFileParsing_001csv()
        {
            var wfs = new WaveformStorage();
            wfs.LoadCsv($"..\\..\\..\\Media\\001.csv");
            new WaveFormStorageViewerForm(wfs).ShowDialog();
            Assert.Pass();
        }

        [Test]
        public void CsvFileParsing_002csv()
        {
            var wfs = new WaveformStorage();
            wfs.LoadCsv($"..\\..\\..\\Media\\002.csv");
            new WaveFormStorageViewerForm(wfs).ShowDialog();
            Assert.Pass();
        }

        [Test]
        public void CsvFileParsing_003csv()
        {
            var wfs = new WaveformStorage();
            wfs.LoadCsv($"..\\..\\..\\Media\\1KHz_4Vpp_R10V_2000SMP_SPS50KHz.csv");
            new WaveFormStorageViewerForm(wfs).ShowDialog();
            Assert.Pass();
        }
    }
}
