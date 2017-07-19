using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Business.DDEXFactory.Helpers
{
    public static class FilesHelper
    {
        public static void ExecuteFile(string fileName, string arguments = "")
        {
            try
            {
                using (var proc = new Process())
                {
                    proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(fileName);
                    proc.StartInfo.FileName = fileName;
                    proc.StartInfo.Arguments = arguments;
                    proc.StartInfo.CreateNoWindow = false;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.Start();
                    proc.WaitForExit();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
