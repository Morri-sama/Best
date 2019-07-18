using BestApp.Reports.Diploma;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BestApp.Views.Reporting
{
    /// <summary>
    /// Interaction logic for ReportViewerWindow.xaml
    /// </summary>
    public partial class ReportViewerWindow : Window
    {
        public ReportViewerWindow()
        {
            InitializeComponent();

            _reportViewer.ShowContextMenu = false;

            DiplomaViewModel diplomaViewModel = new DiplomaViewModel()
            {
                City = "Москва",
                ParticipantFullName = "Хуесос Геннадьевич",
                TeacherName = "Пидарас Пидарасов"
            };

            List<DiplomaViewModel> diplomaDatas = new List<DiplomaViewModel>();
            diplomaDatas.Add(diplomaViewModel);

            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "DataSetMain";


            _reportViewer.LocalReport.DataSources.Add(reportDataSource1);

            _reportViewer.LocalReport.ReportEmbeddedResource = "BestApp.Reports.Diploma.Diploma.rdlc";
            _reportViewer.LocalReport.DataSources[0].Value = diplomaDatas;

            _reportViewer.RefreshReport();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //_reportViewer.Reset();

            //DiplomaData diplomaData = new DiplomaData()
            //{
            //    City = "Хуй",
            //    DiplomaNumber = 121212,
            //    Grade = "asasa",
            //    Nomination = "asasa",
            //    Participant = "adada",
            //    Teacher = "asasa"
            //};

            //List<DiplomaData> diplomaDatas = new List<DiplomaData>();
            //diplomaDatas.Add(diplomaData);

            //ReportDataSource reportDataSource1 = new ReportDataSource();
            //reportDataSource1.Name = "DataSet";


            //_reportViewer.LocalReport.DataSources.Add(reportDataSource1);

            //_reportViewer.LocalReport.ReportEmbeddedResource = "BestApp.Reports.Diploma.Diploma.rdlc";
            //_reportViewer.LocalReport.DataSources[0].Value = diplomaDatas;

            //_reportViewer.RefreshReport();
        }
    }
}
