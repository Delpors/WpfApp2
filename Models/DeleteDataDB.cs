using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarplataSpravki
{
    internal class DeleteDataDB
    {
        public void deleteDataInstitut(int ValueColumn) { 
            AppContext appContext = new AppContext();

            if (ValueColumn != 0)
            {
                appContext.Instituts.Remove(appContext.Instituts.Where(o => o.id == ValueColumn).FirstOrDefault());

                appContext.SaveChanges();

            }            
        }
        public void DeleteDataEmployee(int ValueColumn)
        {
            AppContext appContext = new AppContext();

            if (ValueColumn != 0)
            {
                appContext.Employees.Remove(appContext.Employees.Where(o => o.id == ValueColumn).FirstOrDefault());

                appContext.SaveChanges();

            }
        }
    }
}
