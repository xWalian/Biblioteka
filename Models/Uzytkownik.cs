using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Biblioteka.Models
{
    public class Uzytkownik : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_uzytkownik { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        public string imie { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        public string nazwisko { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_urodzenia { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        public string miasto { get; set; }
        [Microsoft.Build.Framework.Required]
        [EmailAddress]
        [Column(TypeName = "nvarchar(60)")]
        public string email { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string haslo { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string rodzaj { get; set; }
    }
}
