using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ProbaW.Models;

namespace ProbaW.Controllers
{
    public class HomeController : Controller
    {
        MySqlConnection con = new MySqlConnection();
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        public IActionResult Index()
        {
            
            return View();
        }
       
        public IActionResult About()
        {
            Context context = HttpContext.RequestServices.GetService(typeof(Context)) as Context;
            //List<Soba> list = new List<Soba>();
            List<Soba> list = context.GetAllRoom();
            return View(list);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public void connectionString()
        {
            con.ConnectionString = "SERVER=localhost;PORT=3306;DATABASE=hotel;UID=root;PASSWORD=''";
        }
        [HttpPost]
        public IActionResult Verify(Nalog acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from login where korisnickoIme='"+acc.KorisnickoIme+"'and lozinka='"+acc.Lozinka+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Admin");
            }
            else
            {
                con.Close();
                return View("Error");
            }
            
            
        }
        public IActionResult soba()
        {
            return View();
        }
        public IActionResult Rezevacija(Rezervacija r)
        {
           
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO gost(brojPasosa,jmbg,prezime,ime,datumRodjenja) VALUES('"+r.BrojPasosa+"','"+r.Jmbg+"','"+r.Prezime+"','"+r.Ime+"','" + r.DatumRodjenja+ "')";
            com.ExecuteNonQuery();
            con.Close();
            
            return View();
        }
        [HttpPost]
        public IActionResult rezervisi(Rezervacija r)
        {
           
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Zauzece()
        {
            Context context = HttpContext.RequestServices.GetService(typeof(Context)) as Context;
            //List<Soba> list = new List<Soba>();
            List<Zauzece> list = context.DajSveZauzece();
            return View(list);
            
        }
        
        public IActionResult Izmena(Izmena i)
        {
            
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "UPDATE zauzece SET id='"+i.Id+"',idGost='"+i.IdGost+"',idSoba='"+i.IdSoba+"',datumOd='"+i.DatumOd+"',datumDo='"+i.DatumDo+"'WHERE id='"+i.Id+"'";
            com.ExecuteNonQuery();
            con.Close();
            
            return View();
        }
        public IActionResult Brisanje(Brisanje b)
        {

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "DELETE FROM `zauzece` WHERE id='"+b.Id+"'";
            com.ExecuteNonQuery();
            con.Close();

            return View();
        }
        
        public IActionResult DodajZauzece()
        {
            /*
            Zauzece z=new Models.Zauzece();
            Rezervacija r = new Rezervacija();
            int id = r.Id;
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO zauzece(idGost,idSoba,datumOd,datumDo) VALUES('" + z.IdGost + "','" + z.IdSoba + "','" + z.DatumOd + "','" + z.DatumDo + "' )";
            com.ExecuteNonQuery();
            con.Close();
            */
            return View();
        }
        public IActionResult SviGosti()
        {
            Context context = HttpContext.RequestServices.GetService(typeof(Context)) as Context;
            //List<Soba> list = new List<Soba>();
            List<Rezervacija> list = context.DajSveGoste();
            return View(list);
            
        }

        
    }
}