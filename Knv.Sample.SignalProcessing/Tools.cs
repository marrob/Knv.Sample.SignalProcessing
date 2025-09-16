namespace Knv.Sample.SignalProcessing

{
    using NUnit.Framework;
    using System;
    using System.Diagnostics;
    using System.IO;


    public static class Tools
    {

        public static void SignalToFile(double[] data, string title, string directory)
        {
            var dt = DateTime.Now;
            var fileName = $"{title}_{dt:yyyy}{dt:MM}{dt:dd}_{dt:HH}{dt:mm}{dt:ss}.csv";

            if (!File.Exists(directory))
                Directory.CreateDirectory(directory);

            var path = $"{directory}\\{fileName}";
            using (var sw = new StreamWriter(path))
            {
                foreach (var value in data)
                    sw.WriteLine($"\"{value:#.000}\"");
            }
        }

         

        public static string ArrayToFile_C_Uint16(short[] data, string title)
        {

            var dt = DateTime.Now;
            var fileName = $"{title}_{dt:yyyy}{dt:MM}{dt:dd}_{dt:HH}{dt:mm}{dt:ss}.csv";
            var path = $"{TestContext.CurrentContext.TestDirectory}\\{fileName}";
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("#include \"main.h\"");
                sw.WriteLine($"//Total Bytes: 2xLength:{2 * data.Length}");
                sw.WriteLine($"uint16_t {title}[] = {{");
                int column_cnt = 2;
                for (int i = 0; i < data.Length; i++)
                {
                    sw.Write($"0x{data[i]:X4}, 0x0000, ");
                    if (column_cnt >= 6)
                    {
                        sw.Write("\r\n");
                        column_cnt = 0;
                    }
                    column_cnt++;
                }
                sw.WriteLine("};");
            }
            return path;
        }


        public static string ArrayToFile_C_Uint32(int[] data, string title)
        {

            var dt = DateTime.Now;
            var fileName = $"{title}_{dt:yyyy}{dt:MM}{dt:dd}_{dt:HH}{dt:mm}{dt:ss}.csv";
            var path = $"{TestContext.CurrentContext.TestDirectory}\\{fileName}";
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("#include \"main.h\"");
                sw.WriteLine($"//Total Bytes: 4xLength:{4*data.Length}");
                sw.WriteLine($"uint16_t {title}[] = {{");
                int column_cnt = 4;
                for (int i = 0; i < data.Length; i++)
                {
                    UInt16 low = (UInt16)data[i];
                    UInt16 high = (UInt16)(data[i]>>16);

                    sw.Write($"0x{high:X4}, 0x{low:X4}, 0x0000, 0x0000,");
                    if (column_cnt >= 6)
                    {
                        sw.Write("\r\n");
                        column_cnt = 0;
                    }
                    column_cnt++;
                }
                sw.WriteLine("};");
            }
            return path;
        }


        public static void OpenLogByNpp(string path)
        {
            if (System.IO.File.Exists(path))
            {
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "notepad++.exe";
                myProcess.StartInfo.Arguments = $"{path}";
                myProcess.Start();
                return;
            }
        }

        public static UInt16 CalcCrc16Ansi(UInt16 initValue, byte[] data)
        {
            UInt16 remainder = initValue;
            UInt16 polynomial = 0x8005;
            for (long i = 0; i < data.LongLength; ++i)
            {
                remainder ^= (UInt16)(data[i] << 8);
                for (byte bit = 8; bit > 0; --bit)
                {
                    if ((remainder & 0x8000) != 0)
                        remainder = (UInt16)((remainder << 1) ^ polynomial);
                    else
                        remainder = (UInt16)(remainder << 1);
                }
            }
            return (remainder);
        }
    }
}
