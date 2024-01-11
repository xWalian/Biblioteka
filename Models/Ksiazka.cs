using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Ksiazka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ksiazka { get; set; }
        [Column(TypeName = "int")]
        public int id_kategoria { get; set; }
        [Column(TypeName = "Varchar(60)")]
        public string autor { get; set; }
        [Column(TypeName = "Varchar(60)")]
        public string tytul {  get; set; }
        [Column(TypeName = "Varchar(60)")]
        public string wydawnictwo {  get; set; }
        [Column(TypeName = "int")]
        public int rok_wydania {  get; set; }
        [Column(TypeName = "int")]
        public int ilosc {  get; set; }
        
    }
}
