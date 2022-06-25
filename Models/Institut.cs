using System.Collections.Generic;

namespace ZarplataSpravki
{
    public class Institut
    {
        public int id { get; set; }
        public string InnInstitut { get; set; }
        public string Institut_name { get; set; }
        public string Institut_director { get; set; }
        public string Institut_buh { get; set; }

        public List<Employee> Employees { get; set; }
        public Institut() { }

        public Institut(string InnInstitut, string Institut_name, string Institut_director, string Institut_buh)
        {
            this.InnInstitut = InnInstitut;
            this.Institut_name = Institut_name;
            this.Institut_director = Institut_director;
            this.Institut_buh = Institut_buh;
        }
    }
}
