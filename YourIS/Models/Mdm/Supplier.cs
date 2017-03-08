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
        public int Id { get; set; }        
        public string Name { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
