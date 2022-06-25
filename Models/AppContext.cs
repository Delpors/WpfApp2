using System.Data.Entity;

namespace ZarplataSpravki
{
    internal class AppContext : DbContext
    {
        public AppContext() : base("DefaultConnection") { }
        public DbSet<Institut> Instituts { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
