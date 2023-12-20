using Microsoft.EntityFrameworkCore;
using WebAPI_CrudTarget.Models;

namespace WebAPI_CrudTarget.DataContext
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<ProjetoModel> Projetos { get; set; }
    }
}
