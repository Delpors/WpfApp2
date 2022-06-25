using System;
using System.Windows;


namespace ZarplataSpravki
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AddInstitut : Window
    {
        AppContext appContext;
        Institut institut;
        public AddInstitut()
        {

            InitializeComponent();
            appContext = new AppContext();
        }


        private void AddInstitutButton(object sender, RoutedEventArgs e)
        {
            institut = new Institut
            {
                InnInstitut = _INN_institut.Text.Trim(),
                Institut_name = _Name_institut.Text.Trim(),
                Institut_director = _Director.Text.Trim(),
                Institut_buh = _Buh.Text.Trim()
            };

            try
            {   //Проверка пустая строка или нет
                if (!String.IsNullOrEmpty(_INN_institut.Text))
                {
                    appContext.Instituts.Add(institut);

                    appContext.SaveChanges();

                    Close();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Введенные данные не уникальны");
            }

        }
    }
}
