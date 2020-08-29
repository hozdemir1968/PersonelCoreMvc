using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelCoreMvc.Models
{
    public class Bolum
    {
        public int ID { get; set; }
        public string Ad { get; set; }

        public IList<Personel> Personels { get; set; }
    }
}
