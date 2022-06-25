using System.Windows;

namespace ZarplataSpravki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            MainFrame.Content = new StartPage();

        }

        private void Spisok_Uchrezhdeniy_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new institution();
        }

        private void Sotrudniki_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Employees();

        }
    }
}
