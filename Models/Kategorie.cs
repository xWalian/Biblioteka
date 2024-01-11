using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Kategorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_kategoria {  get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public string nazwa_kategorii { get; set; }
        
    }
}
