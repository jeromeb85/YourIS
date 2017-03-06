using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YourIS.Models.Mdm
{
    public class Supplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int SupplierVersion { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
