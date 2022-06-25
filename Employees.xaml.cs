using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ZarplataSpravki
{
    /// <summary>
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Page

    {
        readonly AppContext appContext;

        public string ComboBoxSelInst;

        public ObservableCollection<Employee> EmployeeCollection;

        public Employees()
        {
            InitializeComponent();

            appContext = new AppContext();

            EmployeeCollection = new ObservableCollection<Employee>(appContext.Employees.ToList());
            EmploeesDataGrid.ItemsSource = EmployeeCollection;

            EmployeeCombobox.ItemsSource = new ObservableCollection<Institut>(appContext.Instituts.ToList());
            EmployeeCombobox.DisplayMemberPath = "Institut_name";
        }

        private void Button_CloseEmpPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("StartPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_AddEmployee(object sender, RoutedEventArgs e)
        {
            AddEmployee button = new AddEmployee
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            button.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            button.ShowDialog();

            EmployeeCollection = new ObservableCollection<Employee>(appContext.Employees.ToList());
            EmploeesDataGrid.ItemsSource = EmployeeCollection;
        }
        
        private void Button_Click_EditEmployee(object sender, RoutedEventArgs e)
        {

            //получение значения выделенной строки
            EditRowEmployeeDB editData = new EditRowEmployeeDB();
            Employee dataGridSelrctedItem = (Employee)EmploeesDataGrid.SelectedItem;

            editData.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (dataGridSelrctedItem != null)
            {
                editData.EditData(dataGridSelrctedItem);
            }

            EmployeeCollection=new ObservableCollection<Employee>(appContext.Employees.ToList());
            EmploeesDataGrid.ItemsSource = EmployeeCollection;
        }

        private void Button_Click_DelEmployee(object sender, RoutedEventArgs e)
        {

            //получение значения выделенной строки
            DeleteDataDB deletData = new DeleteDataDB();
            Employee employeeDelete = (Employee)EmploeesDataGrid.SelectedItem;

            if (employeeDelete != null)
            {
                deletData.DeleteDataEmployee(employeeDelete.id);
            }

            //Обновляет страницу
            EmployeeCollection = new ObservableCollection<Employee>(appContext.Employees.ToList());
            EmploeesDataGrid.ItemsSource = EmployeeCollection;

        }
    }
}
