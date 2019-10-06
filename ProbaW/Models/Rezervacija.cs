using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProbaW.Models
{
    public class Rezervacija
    {
        private Context context;
        protected DateTime _datumRodjenja;
        public int IdGost { get; set; }
        public int BrojPasosa { get; set; }
        public int Jmbg { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }

        [Display(Name = "DatumRodjenja")]
        [DataType(DataType.Date)]
        //[DisplayFormat( ApplyFormatInEditMode = true, DataFormatString =" {0:yyyy-MM-dd hh:MM tt}")]
        [DisplayFormat( ApplyFormatInEditMode = true, DataFormatString ="{0:dd.MM.yyyy.}")]
        public DateTime DatumRodjenja
        {

            get{ return _datumRodjenja; }
            set{ _datumRodjenja = value; }

        }
        public Rezervacija()
        {

        }
        public DateTime Konvertor()
        {
             string datum= _datumRodjenja.ToString();
            string konvert = Convert.ToDateTime(datum).ToString("dd.mm.yyyy");
            _datumRodjenja= DateTime.ParseExact(konvert, "dd.mm.yyyy", CultureInfo.InvariantCulture);
            return _datumRodjenja;

        }
       
    }
}
