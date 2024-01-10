using Biblioteka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Biblioteka.Controllers
{
    public class KsiazkiController : Controller
    {
        public IActionResult ListaKsiazek()
        {
            string connectionString = "";
            string query = "SELECT * FROM ksiazki";
            List<Ksiazka> listaKsiazek = new List<Ksiazka>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id_ksiazka = Convert.ToInt32(reader["id_ksiazka"]);
                            int id_kategoria = Convert.ToInt32(reader["id_kategoria"]);
                            string autor = reader["autor"].ToString();
                            string tytul = reader["tytul"].ToString();
                            string wydawnictwo = reader["wydawnictwo"].ToString();
                            int rok_wydania = Convert.ToInt32(reader["rok_wydania"]);
                            int ilosc = Convert.ToInt32(reader["ilosc"]);

                            Ksiazka ksiazka = new Ksiazka(id_ksiazka, id_kategoria, autor, tytul, wydawnictwo, rok_wydania, ilosc);
                            listaKsiazek.Add(ksiazka);
                        }
                    }
                }

                return View(ListaKsiazek);
            }
        }
    }
}
