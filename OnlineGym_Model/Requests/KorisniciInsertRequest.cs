using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineGym_Model.Requests
{
   public class KorisniciInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }
        [EmailAddress]
        [Required]
        [MinLength(5)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string KorisnickoIme { get; set; }
        public string StariPassword { get; set; }
        public string Password { get; set; }
        public string PasswordPotvrda { get; set; }
        public byte[] Fotografija { get; set; }
        public byte[] FotografijaThum { get; set; }
        public List<int> Uloge { get; set; } = new List<int>();
    }
}
