using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourIS.Models.Account
{
    public class Environement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
