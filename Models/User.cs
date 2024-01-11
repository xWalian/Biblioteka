namespace Biblioteka.Models
{
    public class Uzytkownik
    {
        public int id_uzytkownik { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string data_urodzenia { get; set; }
        public string miasto { get; set; }
        public string email { get; set; }
        public string rodzaj {  get; set; }
        public Uzytkownik() {  }
        
    }
}
