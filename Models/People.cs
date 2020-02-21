using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iQurban.Models
{
    public class People
    {
        public int ID { get; set; }

        public string Id_Kartu_Keluarga { get; set; }
        public string NIK { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Tanggal_Lahir { get; set; }
        public string Tempat_Lahir { get; set; }
        public string Alamat { get; set; }
        public string Phone { get; set; }
        public string Handphone { get; set; }
        public string Email { get; set; }
    }
}
