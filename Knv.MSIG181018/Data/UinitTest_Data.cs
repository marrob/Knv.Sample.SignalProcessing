
namespace Knv.MSIG181018.Data
{
    using NUnit.Framework;
    [TestFixture]
    class UinitTest_Data
    {

 

        [Test]
        public void First()
        { 
            Assert.Pass();
        }

        [Test]
        public void CsvFileParsing()
        {
            var signal = new WaveformStorage();
            signal.LoadCsv(AppConstants.MediaPath + "001.csv");
            Assert.Pass();
        }

        [Test]
        public void CsvFileParsing2()
        {
            var signal = new WaveformStorage();
            signal.LoadCsv(AppConstants.MediaPath + "002.csv");
            Assert.Pass();
        }
    }
}
