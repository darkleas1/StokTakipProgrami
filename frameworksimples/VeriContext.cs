using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frameworksimples
{
    public class VeriContext:DbContext
    {
        public VeriContext():base("stokConnection")
        {
                
        }
        //Kategoriler
        public DbSet<Beyazesya> Beyazesyalar { get; set; }
        public DbSet<Elektronik> Elektronikler { get; set; }
        public DbSet<Spor> Sporlar { get; set; }
        public DbSet<Temizlik> Temizlikler { get; set; }

        //Alt Kategoriler 
        // public DbSet<Beyazesya> Telefon { get; set; }
        //public DbSet<Elektronik> Tablet { get; set; }
        // public DbSet<Spor> Bilgisayar { get; set; }
        // public DbSet<Temizlik> Leptop { get; set; }
        // public DbSet<Beyazesya> Klimalar { get; set; }
        //public DbSet<Elektronik> Koltuk { get; set; }
        // public DbSet<Spor> Masa { get; set; }
        // public DbSet<Temizlik> Temizlikler { get; set; }
    }
}
