using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Nemetos.BCH.Importers.UrlInfo.Domain;

namespace Nemetos.BCH.Importers.UrlInfo
{
    public partial class UrlInfo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GetInfoAboutUrlButtonClick(object sender, EventArgs e)
        {
            var logFilesFetcher = new LogFilesFetcher(this.pathTextBox.Text);
            LogParserWrapper logParserWrapper = new LogParserWrapper();
            IEnumerable<IisLogFile> iisLogs = logFilesFetcher.GetIisLogFiles(this.startDateCalendar.SelectedDate, this.endDateCalendar.SelectedDate);
            var countCollection = logParserWrapper.GetUrlCount(this.urlTextbox.Text, iisLogs, true);
            this.Response.Write(countCollection.Sum(x => Convert.ToInt32(x.Count)));


            
            ResultGrid.DataSource = countCollection;
            ResultGrid.DataBind();
        }
    }
}