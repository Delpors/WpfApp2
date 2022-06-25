using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ZarplataSpravki
{
    /// <summary>
    /// Логика взаимодействия для institution.xaml
    /// </summary>
    public partial class institution : Page
    {
        AppContext appContext;
        private readonly ObservableCollection<Institut> institutsDB;
        
        public institution()
        {
            InitializeComponent();

            //Соединение с базой данных
            appContext = new AppContext();
            //Копирование содержимого таблицы из БД в лист
            institutsDB = new ObservableCollection<Institut>(appContext.Instituts.ToList());
            //Копирование содержимого листа в DataGrid
            organizatinDataGrid.ItemsSource = institutsDB;            
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("StartPage.xaml", UriKind.RelativeOrAbsolute));
        }

        //добавить организацию
        private void AddInstitution(object sender, RoutedEventArgs e)
        {
            AddInstitut button = new AddInstitut();
            button.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            button.ShowDialog();

            ////Обновляет страницу
            organizatinDataGrid.ItemsSource = new ObservableCollection<Institut>(appContext.Instituts.ToList());
        }

            //удаление строк
        private void Button_Delet_Row_Click(object sender, RoutedEventArgs e)
        {
            //получение значения выделенной строки
            DeleteDataDB deletData = new DeleteDataDB();
            Institut institut = (Institut)organizatinDataGrid.SelectedItem;

            if (institut != null)
            {
                deletData.deleteDataInstitut(institut.id);
            }

            //Обновляет страницу
            organizatinDataGrid.ItemsSource = new ObservableCollection<Institut>(appContext.Instituts.ToList());
        }

        //Изменить выделенную строку
        private void Button_Edit_Row_Click(object sender, RoutedEventArgs e)
        {
            //получение значения выделенной строки
            EditRowDB editData = new EditRowDB();
            Institut dataGridSelrctedItem = (Institut)organizatinDataGrid.SelectedItem;

            if (dataGridSelrctedItem != null)
            {
                editData.editData(dataGridSelrctedItem);
            }

            //Обновляет страницу
            organizatinDataGrid.ItemsSource = new ObservableCollection<Institut>(appContext.Instituts.ToList());
        }

    }

}
