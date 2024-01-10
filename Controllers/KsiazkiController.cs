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
            }
            return View(ListaKsiazek);
        }
        public IActionResult DodajKsiazke()
        {
            return View();
        }
        public IActionResult ZapiszKsiazke(Ksiazka ksiazka)
        {
            if(ModelState.IsValid)
            {
                string connectionString = "";
                string insertQuery = "INSERT INTO ksiazki (id_kategoria, autor, tytul, wydawnictwo, rok_wydania, ilosc) VALUES " +
                     "(@id_kategoria, @autor, @tytul, @wydawnictwo, @rok_wydania, @ilosc);";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using(SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id_kategoria", ksiazka.id_kategoria);
                        command.Parameters.AddWithValue("@autor", ksiazka.autor);
                        command.Parameters.AddWithValue("@tytul", ksiazka.tytul);
                        command.Parameters.AddWithValue("@wydawnictwo", ksiazka.wydawnictwo);
                        command.Parameters.AddWithValue("@rok_wydania", ksiazka.rok_wydania);
                        command.Parameters.AddWithValue("@ilosc", ksiazka.ilosc);

                        command.ExecuteNonQuery();

                    }
                }
                return RedirectToAction("ListaKsiazek");
            }
            return View("DodajKsiazke", ksiazka);
        }
        public IActionResult WyszukajKsiazki(string searchQuery)
        {
            string connectionString = "";
            string query = "SELECT * FROM ksiazki WHERE id_kategoria LIKE @searchQuery OR tytul LIKE @searchQuery OR" +
                " autor LIKE @searchQueryOR wydawnictwo LIKE @searchQuery OR rok_wydania LIKE @searchQuery;";
            List<Ksiazka> listaKsiazek = new List<Ksiazka>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query,))
            }
        }
    }
   
}
