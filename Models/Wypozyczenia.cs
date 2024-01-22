using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Wypozyczenia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column(TypeName ="int")]
        public int id_ksiazka {  get; set; }
        [Column(TypeName = "int")]
        public int id_uzytkownik { get; set; }
        [Column(TypeName = "date")]
        public DateTime data_wypozyczenia { get; set; }

    }
}
