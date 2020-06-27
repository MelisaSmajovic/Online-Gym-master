using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineGym_Model;
using OnlineGym_Model.Requests;
using OnlineGym_WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public class SistemPreporukeProizvodi : ISistemPreporukeProizvodi
    {
        private readonly DB_TeretanaContext _context;
        Dictionary<int, List<Database.RecenzijeProizvoda>> proizvodi = new Dictionary<int, List<Database.RecenzijeProizvoda>>();
        List<OnlineGym_Model.Proizvod> ostaliProizvodi = new List<OnlineGym_Model.Proizvod>();
        private readonly IMapper _mapper;
        public SistemPreporukeProizvodi(DB_TeretanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<OnlineGym_Model.Proizvod> Get(OnlineGym_Model.Proizvod proizvod)
        {
            if (proizvod.ProizvodId != 0)
            {

                UcitajProizvode(proizvod.ProizvodId);
                List<Database.RecenzijeProizvoda> ocjenePosmatranogProizvoda = _context.RecenzijeProizvoda.Where(p => p.ProizvodId == proizvod.ProizvodId).OrderBy(p => p.ClanId).ToList();
         

                List<Database.RecenzijeProizvoda> zajednickeOcjene1 = new List<Database.RecenzijeProizvoda>();
                List<Database.RecenzijeProizvoda> zajednickeOcjene2 = new List<Database.RecenzijeProizvoda>();

                List<OnlineGym_Model.Proizvod> preporuceniProizvodi = new List<OnlineGym_Model.Proizvod>();

                foreach (var p in proizvodi)
                {
                    foreach (Database.RecenzijeProizvoda o in ocjenePosmatranogProizvoda)
                    {
                        if (p.Value.Where(x => x.ClanId == o.ClanId).Count() > 0) 
                        {
                            zajednickeOcjene1.Add(o);
                            zajednickeOcjene2.Add(p.Value.Where(x => x.ClanId == o.ClanId).First());

                        }

                    }
                    double slicnost = GetSlicnost(zajednickeOcjene1, zajednickeOcjene2);
                    if (slicnost > 0.5) 
                    {
               
                        var entityTemp = _context.Proizvod.Find(p.Key);
                        OnlineGym_Model.Proizvod ProizvodTemp = _mapper.Map<OnlineGym_Model.Proizvod>(entityTemp);
                        preporuceniProizvodi.Add(ProizvodTemp); 
                    }
                    zajednickeOcjene1.Clear();
                    zajednickeOcjene2.Clear();
                }

                return preporuceniProizvodi;
    
            }
            else
            {
                List<OnlineGym_Model.Proizvod> preporuceniProizvodii = new List<OnlineGym_Model.Proizvod>();
                var query = _context.Set<Database.Proizvod>().AsQueryable();
                query = query.Where(x => x.ProizvodId != proizvod.ProizvodId && x.ProsjecnaOcjena > 4);
                var list = query.ToList();
                foreach (Database.Proizvod item in list)
                {
                    OnlineGym_Model.Proizvod temp = _mapper.Map<OnlineGym_Model.Proizvod>(item);
                    preporuceniProizvodii.Add(temp);
                }
                return preporuceniProizvodii;
            }
        }

        public double GetSlicnost(List<Database.RecenzijeProizvoda> zajednickeOcjene1, List<Database.RecenzijeProizvoda> zajednickeOcjene2)
        {
            if (zajednickeOcjene1.Count != zajednickeOcjene2.Count)
                return 0;

            double brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;

            for (int i = 0; i < zajednickeOcjene1.Count; i++)
            {
                brojnik = (double)(zajednickeOcjene1[i].Ocjena * zajednickeOcjene2[i].Ocjena); 
                nazivnik1 = (double)(zajednickeOcjene1[i].Ocjena * zajednickeOcjene1[i].Ocjena); 
                nazivnik2 = (double)(zajednickeOcjene2[i].Ocjena * zajednickeOcjene2[i].Ocjena);

            }
            nazivnik1 = Math.Sqrt(nazivnik1); 
            nazivnik2 = Math.Sqrt(nazivnik2);

            double nazivnik = nazivnik1 * nazivnik2;
            if (nazivnik == 0)
                return 0;
            return brojnik / nazivnik;
        }
        public void UcitajProizvode(int proizvodId)
        {
            if (proizvodId == 0)
            {
                List<Database.Proizvod> sviProizvodi = _context.Proizvod.ToList();
                foreach (var prz in sviProizvodi)
                {
                    OnlineGym_Model.Proizvod tempProizvod = _mapper.Map<OnlineGym_Model.Proizvod>(prz);
                    ostaliProizvodi.Add(tempProizvod);
                }
            }
            else
            {
                List<Database.Proizvod> listaProizvoda = _context.Proizvod.Where(p => p.ProizvodId != proizvodId).ToList();


                var query = _context.Set<Database.Proizvod>().AsQueryable();
                query = query.Where(x => x.ProizvodId != proizvodId);
                var list = query.ToList();


                List<Database.RecenzijeProizvoda> ocjene;


                foreach (Database.Proizvod p in listaProizvoda)
                {
                    ocjene = _context.RecenzijeProizvoda.Where(r => r.ProizvodId == p.ProizvodId).OrderBy(r => r.ClanId).ToList();

                    if (ocjene.Count > 0)
                        proizvodi.Add(p.ProizvodId, ocjene);
                }
            }
        }

        public List<OnlineGym_Model.Proizvod> GetPreporukaByClan(OnlineGym_Model.Clan request)
        {
            UcitajProizvode(0);
            List<OnlineGym_Model.Proizvod> preporuceniProizvodi = new List<OnlineGym_Model.Proizvod>();
            List<int> kategorijeKupljenih = new List<int>();

            List<Database.Narudzbe> narudzbe = _context.Narudzbe.Where(c => c.ClanId == request.ClanId).Include(c => c.NarudzbeStavke).ToList();


            if (narudzbe.Count() > 0)
            {

                List<Database.NarudzbeStavke> stavke = new List<Database.NarudzbeStavke>();
                foreach (var n in narudzbe)
                {
                    foreach (var s in n.NarudzbeStavke)
                    {
                        Database.NarudzbeStavke stavkaTemp = _context.NarudzbeStavke.Where(t => t.NarudzbeStavkeId == s.NarudzbeStavkeId).Include(t => t.Proizvod).FirstOrDefault();
                        stavke.Add(s);
                    }
                }

                bool dodanaKategorija = false;
                foreach (var st in stavke)
                {
                    if (kategorijeKupljenih.Count() > 0)
                    {
                        for (int i = 0; i < kategorijeKupljenih.Count(); i++)
                        {
                            if (st.Proizvod.KategorijaProizvodaId == kategorijeKupljenih[i])
                                dodanaKategorija = true;
                        }
                    }
                    if (dodanaKategorija == false)
                        kategorijeKupljenih.Add(st.Proizvod.KategorijaProizvodaId);
                }

                foreach (var product in ostaliProizvodi)
                {
                    for (int j = 0; j < kategorijeKupljenih.Count(); j++)
                    {
                        if (product.KategorijaProizvodaId == kategorijeKupljenih[j])
                            preporuceniProizvodi.Add(product);
                    }
                }
                return preporuceniProizvodi;
            }
            else
            {
                foreach (var os in ostaliProizvodi)
                {
                    if (os.ProsjecnaOcjena >= 4)
                        preporuceniProizvodi.Add(os);
                }
                return preporuceniProizvodi;
            }
        }
    }
}
