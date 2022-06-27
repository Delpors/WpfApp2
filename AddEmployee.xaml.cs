using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ZarplataSpravki
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        readonly AppContext appContext = new AppContext();

        Employee employee;

        Institut instSelEmployee; 

        Employees employees=new Employees();    

        public AddEmployee()
        {
            InitializeComponent();

            AddEmployeeCombobox.ItemsSource = new ObservableCollection<Institut>(appContext.Instituts.ToList());
            AddEmployeeCombobox.DisplayMemberPath = "Institut_name";
        }

        public void SetParamEmployee()
        {
            instSelEmployee = appContext.Instituts.Find(((Institut)AddEmployeeCombobox.SelectedItem).id);

            employee = new Employee
            {
                FIO = _FIO.Text.Trim(),

                Post = _Post.Text.Trim(),
                
                Oklad = Convert.ToInt32(_Oklad.Text),

                Neoblag_Summa = Convert.ToInt32(_Neoblag_Summa.Text)
            };

            employee = new Employee(employee.FIO, employee.Post, employee.Oklad, employee.Neoblag_Summa, instSelEmployee);          
        }

        private void Click_AddEmployee(object sender, RoutedEventArgs e)
        {
            if (AddEmployeeCombobox.SelectedItem != null)
            {
                try
                {
                    SetParamEmployee();

                    appContext.Employees.Add(employee);
                    appContext.SaveChanges();
   
                    Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите учреждение где работает сотрудник", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Click_CloseEmployee(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
