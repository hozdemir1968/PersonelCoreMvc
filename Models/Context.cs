using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelCoreMvc.Models
{
    public class Context:DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=HASAN-PC; database=PersonelDB; integrated security=true");
        }
        public DbSet<Bolum> Bolums { get; set; }
        public DbSet<Personel> Personels { get; set; }
    }
}
