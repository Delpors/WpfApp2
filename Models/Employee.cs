
using System.Collections.ObjectModel;

namespace ZarplataSpravki
{
    public class Employee : OnNotifyPropertyChanged
    {
        private int _id;
        private string fio;
        private string post;
        private int oklad;
        private int neobl_summa;
        private Institut inst;
        private ObservableCollection<Employee> items { get; set; }

        public int id { get => _id; set => SetProperty(ref _id, value); }
        public string FIO { get => fio; set => SetProperty(ref fio, value); }
        public string Post { get => post; set => SetProperty(ref post, value); }
        public int Oklad { get => oklad; set => SetProperty(ref oklad, value); }
        public int Neoblag_Summa { get => neobl_summa; set => SetProperty(ref neobl_summa, value); }
        public int? Institutid { get; set; }
        public Institut Institut { get => inst; set => SetProperty(ref inst, value); }

        public Employee() { }
        public Employee(string FIO, string Post, int Oklad, int Neoblag_Summa, Institut institut)
        {

            this.FIO = FIO;
            this.Post = Post;
            this.Oklad = Oklad;
            this.Neoblag_Summa = Neoblag_Summa;
            Institut = institut;
                
        }


    }
}
