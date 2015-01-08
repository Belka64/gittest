using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nemetos.BCH.Importers.UrlInfo.Domain;
111111111
namespace Nemetos.BCH.Importers.UrlInfo
{
    public class LogFilesFetcher
    {
        public List<IisLogFile> IisLogFiles { get; private set; }

        public LogFilesFetcher(string logPath)
        {
            this.IisLogFiles = new List<IisLogFile>();
            List<string> filePaths = Directory.GetFiles(logPath, "*.log").ToList();
            foreach (var filePath in filePaths)
            {
                this.IisLogFiles.Add(new IisLogFile(filePath));
            }
        }

        public IEnumerable<IisLogFile> GetIisLogFiles(DateTime startDate, DateTime endDate) { return this.IisLogFiles.Where(x => x.LogDate >= startDate && x.LogDate <= endDate); }
    }
}