using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProbaW.Models;
namespace ProbaW
{
    public class Context
    {
        public string ConnectionString { get; set; }

        public Context(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Models.Soba> GetAllRoom()
        {
            List<Models.Soba> list = new List<Models.Soba>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from soba ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Soba()
                        {
                            IdSoba = Convert.ToInt32(reader["idSoba"]),
                            OznakaSoba = Convert.ToInt32(reader["oznakaSobe"]),
                            IdTipSobe = Convert.ToInt32(reader["idTipSobe"])

                        });
                    }
                }
            }
            return list;


        }

        public List<Models.Zauzece> DajSveZauzece()
        {
            List<Models.Zauzece> list = new List<Models.Zauzece>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select idGost,idSoba,datumOd,datumDo from zauzece ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Zauzece()
                        {
                            IdGost = Convert.ToInt32(reader["idGost"]),
                            IdSoba = Convert.ToInt32(reader["idSoba"]),
                            DatumOd = Convert.ToDateTime(reader["datumOd"]),
                            DatumDo = Convert.ToDateTime(reader["datumDo"]),

                        });
                    }
                }
            }
            return list;


        }
        public List<Models.Rezervacija>DajSveGoste()
        {
            List<Models.Rezervacija> list = new List<Models.Rezervacija>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from gost ", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Rezervacija()
                        {
                            
                            IdGost = Convert.ToInt32(reader["idGost"]),
                            BrojPasosa = Convert.ToInt32(reader["brojPasosa"]),
                            Jmbg = Convert.ToInt32(reader["jmbg"]),
                            Prezime= (reader["prezime"]).ToString(),
                            Ime = (reader["ime"]).ToString(),
                            /*DatumRodjenja = Convert.ToDateTime(reader["datumRodjenja"])*/

                        });
                    }
                }
            }
            return list;
        }

    }
}
