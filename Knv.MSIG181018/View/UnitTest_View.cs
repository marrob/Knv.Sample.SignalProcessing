
namespace Knv.MTOO180701.View
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
    using System.Windows.Forms;

    [TestFixture]
    class UnitTest_View
    {
        [Test]
        public void FormWiveTest()
        {
            Form form = new Form();
            form.ShowDialog();

        }

    }
}
