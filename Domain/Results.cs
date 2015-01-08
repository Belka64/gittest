using System;

namespace Nemetos.BCH.Importers.UrlInfo.Domain
{
    public class Results
    {
        public Results(string day, string count)
        {
            this.Day = day;
            this.Count = count;
        }

        public string Day { get; set; }

        public string Count { get; set; }
    }
}