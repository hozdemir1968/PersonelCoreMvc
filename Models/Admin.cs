using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelCoreMvc.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Column(TypeName ="VarChar(25)")]
        public string User { get; set; }

        [Column(TypeName = "VarChar(10)")]
        public string Password { get; set; }
    }
}
