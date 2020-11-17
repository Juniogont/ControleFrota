using ControleFrota.MDL.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFrota.BLL.Data
{
    public class ControleFrotaContext : DbContext
    {
        public ControleFrotaContext(DbContextOptions<ControleFrotaContext> opcoes)
          : base(opcoes)
        {
        }
        public ControleFrotaContext()
      : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Server = DESKTOP-G9N4BMQ\SQLEXPRESS; Database = ControleFrotaDb; Trusted_Connection = True; ");
        public DbSet<Veiculo> Veiculos { get; set; }

      
    }
}
