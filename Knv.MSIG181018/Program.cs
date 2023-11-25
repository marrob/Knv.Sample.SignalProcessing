namespace Knv.MSIG181018
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading;
    using System.Diagnostics;
    using Properties;
    using Common;
    using System.IO;
    using Data;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new App();
        }
    }

    public interface IApp
    {

    }

    class App : IApp
    {
        IMainForm MainForm = new MainForm();
        SynchronizationContext SyncContext;

        FileSystemWatcher _fileWatcher;
        WaveformStorage Storage = new WaveformStorage();

        //Data.DataImporter _importer = new Data.DataImporter();


        public App()
        {
            if(Settings.Default.ApplictionSettingsSaveCounter == 0)
            {
                Settings.Default.Upgrade();
                Settings.Default.ApplictionSettingsUpgradeCounter++;
            }
            Settings.Default.ApplictionSettingsSaveCounter++;
            Settings.Default.PropertyChanged += (s, e) =>
            {
                Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "(): " +
                    e.PropertyName + ", NewValue: " + Settings.Default[e.PropertyName]);
            };

            Settings.Default.SettingsLoaded += (s, e) =>
            {
                 Debug.WriteLine("SettingsLoaded");
            };

            Settings.Default.SettingChanging += (s, e) =>
            {
                Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            };

            MainForm.Version = Application.ProductVersion;
            MainForm.Text = AppConstants.SoftwareTitle + " - " + Application.ProductVersion;
            MainForm.Shown += (o, e) =>
            {
                SyncContext = SynchronizationContext.Current;
                MainForm.LayoutRestore();
            };
            MainForm.FormClosed += (s, e) =>
            {
                MainForm.LayoutSave();
                Settings.Default.Save();
            };


            var fileMenu = new ToolStripMenuItem("File");
            fileMenu.DropDown.Items.AddRange(
                 new ToolStripItem[]
                 {
                     new Commands.FileOpenCommand(null),
                 });



            var helpMenu = new ToolStripMenuItem("Help");
            helpMenu.DropDown.Items.AddRange(
                 new ToolStripItem[]
                 {
                     new Commands.HowIsWorkingCommand(),
                     new Commands.UpdatesCommands(),
                 });

            MainForm.MenuBar = new ToolStripItem[]
                {
                    fileMenu,
                    helpMenu,
                };

            
            Application.Run((MainForm)MainForm);
        }


        /// <summary>
        /// File Open 
        /// </summary>
        public void FileOpen(string path)
        {

            string ext = Path.GetExtension(path);
            string name = Path.GetFileName(path);
            string dir = Path.GetDirectoryName(path);
            if (ext == ".csv")
            {
                var stopwatch = new Stopwatch();
                stopwatch.Restart();

                MainForm.StatusLoadTime = "";
                _fileWatcher.Path = dir;
                _fileWatcher.Filter = name;
                MainForm.Text = name + " - " + AppConstants.SoftwareTitle + " - " + Application.ProductVersion;
                _fileWatcher.EnableRaisingEvents = true;

                Storage.LoadCsv(path);


                stopwatch.Stop();

                MainForm.StatusLoadTime = "Load : " + Storage.LoadedTimeMs.ToString() + "ms/" + stopwatch.ElapsedMilliseconds.ToString() + "ms";
              //  MainForm.LastModified = "Last write : " + File.GetLastWriteTime(path).ToString(AppConstants.GenericTimestampFormat);
                //_mainForm.RowCoulmn = "Row : " + imported.RowCount.ToString() + "  " + "Col : " + imported.ColumCount.ToString();
            }
        }
    }
}
