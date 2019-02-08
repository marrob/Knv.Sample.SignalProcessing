
namespace Konvolucio.MSIG181018.Commands
{
    using System;
    using System.Windows.Forms;

    class FileOpenCommand : ToolStripMenuItem
    {
        readonly IApp _app;

        public FileOpenCommand(IApp app)
        {
            //    Image = Resources.Delete32x32;
            DisplayStyle = ToolStripItemDisplayStyle.Text;

            Size = new System.Drawing.Size(50, 50);
            Text = "Open";
            _app = app;
            //   _diagnosticsView = diagnosticsView;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //ofd.Filter = AppConstants.FileFilter;

            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            //if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    _app.FileOpen(ofd.FileNames[0]);
        }
    }
}
