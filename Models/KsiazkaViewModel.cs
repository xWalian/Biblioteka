using System.ComponentModel;

namespace Biblioteka.Models
{
    public class KsiazkaViewModel
    {
        [DisplayName("Id")]
        public int id_ksiazka { get; set; }
        [DisplayName("Id_kategorii")]
        public int id_kategoria { get; set; }
        [DisplayName("autor")]
        public string autor { get; set; }
        [DisplayName("tytul")]
        public string tytul { get; set; }
        [DisplayName("wydawnictwo")]
        public string wydawnictwo { get; set; }
        [DisplayName("rok_wydania")]
        public int rok_wydania { get; set; }
        [DisplayName("ilosc")]
        public int ilosc { get; set; }

    }
}
