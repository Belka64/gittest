using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nemetos.BCH.Importers.UrlInfo.Domain;
using LogQuery = MSUtil.LogQueryClassClass;
using LogRecordSet = MSUtil.ILogRecordset;
using LogRecord = MSUtil.ILogRecord;
using IISW3CInputFormat = MSUtil.COMIISW3CInputContextClassClass;

namespace Nemetos.BCH.Importers.UrlInfo
{
    public class LogParserWrapper
    {
        public List<Results> GetUrlCount(string url, IEnumerable<IisLogFile> logFiles, bool dontMerge)
        {
            var iisLogFiles = logFiles as IList<IisLogFile> ?? logFiles.ToList();
            List<Results> results = new List<Results>();
            Parallel.ForEach(iisLogFiles, logPath =>
            {
                var query = string.Format(@"Select 
                                        COUNT(*)
                                        FROM {0}
                                        WHERE cs-uri-stem = '{1}'", logPath.FilePath, url);
                LogQuery logQuery = new LogQuery();
                LogRecordSet recordSet = logQuery.Execute(query, new IISW3CInputFormat());
                for (; !recordSet.atEnd(); recordSet.moveNext())
                {
                    LogRecord logRecord = recordSet.getRecord();
                    if (!logRecord.isNull(0))
                    {
                        lock (this)
                        {
                            results.Add(new Results(logPath.LogDate.ToString(), logRecord.getValue(0).ToString()));
                        }
                    }
                }
            });
            return results;
        }
    }
}