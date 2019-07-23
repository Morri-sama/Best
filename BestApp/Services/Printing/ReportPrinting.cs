using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestApp.Services.Printing
{
    public class ReportPrinting : IDisposable
    {
        private readonly List<LocalReport> _localReports;
        private readonly PrinterSettings _printerSettings;

        private ReportPrinting()
        {
            _printerSettings = new PrinterSettings()
            {
                PrinterName = Properties.Settings.Default.PrinterName
            };
        }

        public ReportPrinting(LocalReport localReport) : this()
        {
            _localReports = new List<LocalReport>
            {
                localReport
            };
        }

        public ReportPrinting(List<LocalReport> localReports) : this()
        {
            _localReports = localReports;
        }

        public void Print()
        {
            foreach (var report in _localReports)
            {
                Warning[] warnings;
                var streams = new List<Stream>();
                var currentPageIndex = 0;

                report.Render("Image", Export(report), (name, fileNameExtension, encoding, mimeType, willSeek) =>
                {
                    var stream = new MemoryStream();
                    streams.Add(stream);
                    return stream;
                }, out warnings);

                foreach (Stream stream in streams)
                {
                    stream.Position = 0;
                }

                if (streams == null || streams.Count == 0)
                    throw new Exception("Error: no stream to print.");

                var printDocument = new PrintDocument
                {
                    DefaultPageSettings = new PageSettings(_printerSettings),
                    PrinterSettings = _printerSettings
                };


                if (!printDocument.PrinterSettings.IsValid)
                {
                    throw new Exception("SSSSSS");
                }
                else
                {
                    printDocument.PrintPage += (sender, e) =>
                    {
                        Metafile pageImage = new Metafile(streams[currentPageIndex]);
                        Rectangle adjustedRect = new Rectangle(
                            e.PageBounds.Left - (int)e.PageSettings.HardMarginX,
                            e.PageBounds.Top - (int)e.PageSettings.HardMarginY,
                            e.PageBounds.Width,
                            e.PageBounds.Height);
                        e.Graphics.FillRectangle(Brushes.White, adjustedRect);
                        e.Graphics.DrawImage(pageImage, adjustedRect);
                        currentPageIndex++;
                        e.HasMorePages = (currentPageIndex < streams.Count);
                        e.Graphics.DrawRectangle(Pens.Red, adjustedRect);
                    };
                    printDocument.EndPrint += (Sender, e) =>
                    {
                        if (streams != null)
                        {
                            foreach (Stream stream in streams)
                            {
                                stream.Close();
                            }

                            streams = null;
                        }
                    };

                    printDocument.Print();
                }
            }
        }

        private string Export(LocalReport localReport)
        {
            PageSettings pageSettings = new PageSettings();


            string deviceInfo =
                $@"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>{pageSettings.PaperSize.Width * 100}in</PageWidth>
                <PageHeight>{pageSettings.PaperSize.Height * 100}in</PageHeight>
                <MarginTop>{pageSettings.Margins.Top * 100}in</MarginTop>
                <MarginLeft>{pageSettings.Margins.Left * 100}in</MarginLeft>
                <MarginRight>{pageSettings.Margins.Right * 100}in</MarginRight>
                <MarginBottom>{pageSettings.Margins.Bottom * 100}in</MarginBottom>
                </DeviceInfo>";

            return deviceInfo;
        }

        public void Dispose()
        {

        }
    }
}
