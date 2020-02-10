using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iQurban.Models
{
    public class Order
    {
        public int id_Order { get; set; }
        public int Id_Hewan { get; set; }
        public int Order_Number { get; set; }
        public DateTime Tanggal_Order { get; set; }
        public int Jumlah { get; set; }
        public string Status { get; set; }
        public string Keterangan { get; set; }
    }
}
