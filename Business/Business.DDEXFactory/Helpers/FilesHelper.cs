using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

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
     

        public static string GetMD5HashSum(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    byte[] bytes = md5.ComputeHash(stream);
                    string str = BitConverter.ToString(bytes);
                    str = str.Replace("-", "").ToLower();
                    return str;
                    //return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "‌​").ToLower();
                }
            }
        }
    }
}