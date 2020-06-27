using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class ClanUpsertRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public string PasswordPotvrda { get; set; }
        public string StariPassword { get; set; }
        public int GradId { get; set; }
        public DateTime DatumRegistracije { get; set; }
    }
}
