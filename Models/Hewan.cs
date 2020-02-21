using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iQurban.Models
{
    public class Hewan
    {
        public int HewanID { get; set; }
        public string Jenis_Hewan { get; set; }
        public string Grade { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Berat { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Harga { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Additional_Price { get; set; }
    }
}
