using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbaW.Models
{
    public class Zauzece
    {
        private Context context;
        public int IdGost { get; set; }
        public int IdSoba { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public Zauzece()
        {

        }
    }
}
