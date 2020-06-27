using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class NarudzbaUpsertRequest
    {
        public int? NarudzbaId { get; set; }
        public bool? Procesirana { get; set; } //provjeri hoce li okej staviti da je procesirana false prilikom kreiranja narudzbe na mobilnoj!!!
        public DateTime Datum { get; set; }
        public int? ClanID { get; set; }
        public string BrojNarudzbe { get; set; }
        public int? KorisnikId { get; set; }
    }
}
