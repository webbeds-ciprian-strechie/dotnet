using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarStoreApp.LoggerLib
{
    class FileLogger : ILogger
    {
        private string filePath = Directory.GetCurrentDirectory();

        private const string logFile = "CarStoreLog.txt";
        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath + '/' + logFile, true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}
