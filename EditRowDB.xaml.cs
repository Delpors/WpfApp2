using System.Linq;
using System.Windows;

namespace ZarplataSpravki
{
    /// <summary>
    /// Логика взаимодействия для EditRowDB.xaml
    /// </summary>
    public partial class EditRowDB : Window 
    {
        AppContext appContext = new AppContext();
        Institut editInstitut = new Institut();

        public string dataGridColumn;
        public EditRowDB()
        {
            InitializeComponent();
        }
        
        //Присваивает значения из DataGrid обратно полям текстбоксов
        public void editData(Institut dataGridSelrctedItem)
        {
            _INN_institut_Edit.Text = dataGridSelrctedItem.InnInstitut;
            _Name_institut_Edit.Text = dataGridSelrctedItem.Institut_name;
            _Director_Edit.Text = dataGridSelrctedItem.Institut_director;
            _Buh_Edit.Text = dataGridSelrctedItem.Institut_buh;

            dataGridColumn = _INN_institut_Edit.Text;

            ShowDialog();
        }

        //Сохраннение измененной информации в БД
        private void Button_SaveEditRow_Click(object sender, RoutedEventArgs e)
        {
            editInstitut = appContext.Instituts.Where(i=>i.InnInstitut == dataGridColumn).FirstOrDefault();

            editInstitut.InnInstitut = _INN_institut_Edit.Text.Trim();
            editInstitut.Institut_name = _Name_institut_Edit.Text.Trim();
            editInstitut.Institut_director = _Director_Edit.Text.Trim();  
            editInstitut.Institut_buh = _Buh_Edit.Text.Trim();           
         
            appContext.SaveChanges();
            Close();

        }

    }
}
