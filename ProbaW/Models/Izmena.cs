using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbaW.Models
{
    public class Izmena
    {
        public int Id { get; set; }
        public int IdGost { get; set; }
        public int IdSoba { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
    }
}
