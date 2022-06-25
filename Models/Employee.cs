
namespace ZarplataSpravki
{
    public class Employee
    {

        public int id { get; set; }
        public string FIO { get; set; }
        public string Post { get; set; }
        public int Oklad { get; set; }
        public int Neoblag_Summa { get; set; }
        public int? Institutid { get; set; }
        public Institut Institut { get; set; }


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
