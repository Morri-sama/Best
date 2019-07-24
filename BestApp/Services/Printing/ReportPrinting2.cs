using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace BestApp.Services.Printing
{
    public class ReportPrinting2 : IDisposable
    {
        private readonly List<LocalReport> _localReports;
        private readonly PrinterSettings _printerSettings;

        private ReportPrinting2()
        {
            _printerSettings = new PrinterSettings()
            {
                PrinterName = Properties.Settings.Default.PrinterName
            };
        }

        public ReportPrinting2(LocalReport localReport) : this()
        {
            _localReports = new List<LocalReport>
            {
                localReport
            };
        }

        public ReportPrinting2(List<LocalReport> localReports) : this()
        {
            _localReports = localReports;
        }

        public void Print()
        {
            foreach (var report in _localReports)
            {
                string mimeType, encoding, extension;

                Warning[] warnings;
                string[] streams;

                var renderBytes = report.Render
                    (
                        "PDF",
                        null,
                        out mimeType,
                        out encoding,
                        out extension,
                        out streams,
                        out warnings
                    );



                var printQueue = LocalPrintServer.GetDefaultPrintQueue();
                using (var job = printQueue.AddJob())
                using (var stream = job.JobStream)
                {
                    stream.Write(renderBytes, 0, renderBytes.Length);
                }

            }

        }

        public void Dispose()
        {

        }
    }
}
