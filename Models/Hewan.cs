using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iQurban.Models
{
    public class Hewan
    {
        public int Id_Hewan { get; set; }
        public string Jenis_Hewan { get; set; }
        public string Grade { get; set; }
        public decimal Berat { get; set; }
        public decimal Harga { get; set; }
        public decimal Additional_Price { get; set; }
    }
}
