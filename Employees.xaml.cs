using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        
        public Employee employee { get; set; }
        public string ComboBoxSelInst;
        public ObservableCollection<Employee> EmployeeCollection { get; set; }

        public Employees()
        {
            InitializeComponent();

            DataContext = this;
            appContext = new AppContext();

            EmployeeCollection = new ObservableCollection<Employee>(appContext.Employees.ToList());
            
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

            EmploeesDataGrid.ItemsSource=new ObservableCollection<Employee>(appContext.Employees.ToList());  

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
        }

        private void Button_Click_DelEmployee(object sender, RoutedEventArgs e)
        {

            //получение значения выделенной строки
            DeleteDataDB deletData = new DeleteDataDB();
            Employee employeeDelete = (Employee)EmploeesDataGrid.SelectedItem;

            if (employeeDelete != null)
            {
                if(deletData.DeleteDataEmployee(employeeDelete.id))
                    EmploeesDataGrid.ItemsSource = new ObservableCollection<Employee>(appContext.Employees.ToList());
            }
        }
    }
}
