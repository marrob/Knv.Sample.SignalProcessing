
namespace Konvolucio.MSIG181018.Data
{
    using System;
    using System.Collections.Generic;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Linq;
    using System.Net.Configuration;
    using System.Net.Mail;
    using System.Text;
    using NUnit.Framework;
    using System.Numerics;
    using System.Threading;
    using NUnit.Framework.Constraints;
    using System.Diagnostics;
    using Common;


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
