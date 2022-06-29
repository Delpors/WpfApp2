using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ZarplataSpravki
{
    /// <summary>
    /// Логика взаимодействия для EditRowEmployeeDB.xaml
    /// </summary>
    public partial class EditRowEmployeeDB : Window
    {
        AppContext appContext = new AppContext();
        Employee editInstitut = new Employee();
        Employees employees = new Employees();

        public int dataGridColumn;
        public EditRowEmployeeDB()
        {
            InitializeComponent();
        }

        public void EditData(Employee dataGridSelrctedItem)
        {
            _FIO_Edit.Text = dataGridSelrctedItem.FIO;
            _Post_Edit.Text = dataGridSelrctedItem.Post;
            _Oklad_Edit.Text = Convert.ToString(dataGridSelrctedItem.Oklad);
            _Neoblag_Summa_Edit.Text = Convert.ToString(dataGridSelrctedItem.Neoblag_Summa);

            dataGridColumn = dataGridSelrctedItem.id;    

            ShowDialog();
        }

        //Сохраннение измененной информации в БД
        private void Button_SaveEditRow_Click(object sender, RoutedEventArgs e)
        {
            editInstitut = appContext.Employees.Where(i=>i.id == dataGridColumn).FirstOrDefault();

            editInstitut.FIO = _FIO_Edit.Text.Trim();
            editInstitut.Post = _Post_Edit.Text.Trim();
            editInstitut.Oklad = Convert.ToInt32(_Oklad_Edit.Text);  
            editInstitut.Neoblag_Summa = Convert.ToInt32(_Neoblag_Summa_Edit.Text);  
                    
            appContext.SaveChanges();
            Close();
        }

        private void Button_ConselEmplEdit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
