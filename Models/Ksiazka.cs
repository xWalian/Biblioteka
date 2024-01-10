namespace Biblioteka.Models
{
    public class Ksiazka
    {
        public int id_ksiazka { get; set; }
        public int id_kategoria { get; set; }
        public string autor { get; set; }
        public string tytul {  get; set; } 
        public string wydawnictwo {  get; set; }
        public int rok_wydania {  get; set; }
        public int ilosc {  get; set; }
        
        public Ksiazka(int id_ksiazka, int id_kategoria, string autor, string tytul, string wydawnictwo, int rok_wydania, int ilosc)
        {
            this.id_ksiazka = id_ksiazka;
            this.id_kategoria = id_kategoria;
            this.autor = autor;
            this.tytul = tytul;
            this.wydawnictwo = wydawnictwo;
            this.rok_wydania = rok_wydania;
            this.ilosc = ilosc;
        }

    }
}
