using Microsoft.EntityFrameworkCore;
using La_Mia_Pizzeria.Models;


namespace La_Mia_Pizzeria.Database
{
    public class PizzaContext : DbContext
    {
        public DbSet<PizzaModel> Pizze { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EFPizzeria;" +
                "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
