
using Infraestructure.Interfaces;
using Infraestructure.Services;
using System.Windows;


namespace Epicor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            IUserServices rs = new UserServices();
            dgData.ItemsSource = rs.TotalOpenReportsByUsers();
        }
    }
}
