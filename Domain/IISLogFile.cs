using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Nemetos.BCH.Importers.UrlInfo.Domain
{
    public class IisLogFile
    {
        public IisLogFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException();
            }
            this.FilePath = filePath;
            this.LogDate = this.GetDateFromFilePath(filePath);
        }

        public string FilePath { get; private set; }

        public DateTime LogDate { get; private set; }

        private DateTime GetDateFromFilePath(string filePath)
        {
            Match match = Regex.Match(filePath, @"\d\d\d\d\d\d");
            if (match.Success)
            {
                return DateTime.ParseExact(match.Value, "yyMMdd", CultureInfo.InvariantCulture);
            }
            throw new ArgumentException(string.Format("The path {0} maybee isnt log file", filePath));
        }
    }
}