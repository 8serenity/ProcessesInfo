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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace ProcessesInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();




        }

        private void ShowProcesses_Click(object sender, RoutedEventArgs e)
        {
            List<InfoProcessModel> infoModels = new List<InfoProcessModel>();
            var processes = Process.GetProcesses();

            infoModels = processes.Select(x => new InfoProcessModel()
            {
                Id = x.Id,
                Name = x.ProcessName,
                NumberOfThreads = x.Threads.Count
            }).ToList();

            InfoProcesses.ItemsSource = infoModels;
            //Select(x => new UserQueryView()
            //{
            //    Id = x.Id,
            //    QueryText = x.QueryText,
            //    DateWritten = x.DateWritten,
            //    QueryStatus = x.QueryStatus
            //})

        }
    }

    public class InfoProcessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfThreads { get; set; }
    }
}
