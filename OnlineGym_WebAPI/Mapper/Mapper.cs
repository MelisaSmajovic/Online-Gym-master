using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnik, OnlineGym_Model.Korisnik>();
            CreateMap<Database.Korisnik, OnlineGym_Model.Requests.KorisniciSearchRequest>().ReverseMap();

            CreateMap<Database.KorisniciUloge, OnlineGym_Model.KorisnikUloge>();
            CreateMap<Database.KorisniciUloge, OnlineGym_Model.Requests.KorisnikUlogaSearchRequest>().ReverseMap();
            CreateMap<Database.KorisniciUloge, OnlineGym_Model.Requests.KorisnikUlogaUpsertRequest>().ReverseMap();

            CreateMap<Database.Uloga, OnlineGym_Model.Uloga>();
          

            CreateMap<Database.Clan, OnlineGym_Model.Clan>();
            CreateMap<Database.Clan, OnlineGym_Model.Requests.ClanSearchRequest>().ReverseMap();
            CreateMap<Database.Clan, OnlineGym_Model.Requests.ClanUpsertRequest>().ReverseMap();

            CreateMap<Database.Proizvod, OnlineGym_Model.Proizvod>();
            CreateMap<Database.Proizvod, OnlineGym_Model.Requests.ProizvodSearchRequest>().ReverseMap();

            CreateMap<Database.Teretana, OnlineGym_Model.Teretana>();
            CreateMap<Database.Teretana, OnlineGym_Model.Requests.TeretanaSearchRequest>().ReverseMap();

            CreateMap<Database.KategorijaProizvoda, OnlineGym_Model.KategorijeProizvoda>();
            CreateMap<Database.VrstaProizvoda, OnlineGym_Model.VrsteProizvoda>();

            CreateMap<Database.TipClanarine, OnlineGym_Model.TipClanarine>();


            CreateMap<Database.Grad, OnlineGym_Model.Gradovi>();

            CreateMap<Database.Obavijest, OnlineGym_Model.Obavijest>();
            CreateMap<Database.Obavijest, OnlineGym_Model.Requests.ObavijestSearchRequest>().ReverseMap();


            CreateMap<Database.Izlazi, OnlineGym_Model.Izlazi>();
            CreateMap<Database.Izlazi, OnlineGym_Model.Requests.IzlazSearchRequest>().ReverseMap();
            CreateMap<Database.Izlazi, OnlineGym_Model.Requests.IzlazUpsertRequest>().ReverseMap();

            CreateMap<Database.Narudzbe, OnlineGym_Model.Narudzbe>();
            CreateMap<Database.Narudzbe, OnlineGym_Model.Requests.NarudzbaSearchRequest>().ReverseMap();
            CreateMap<Database.Narudzbe, OnlineGym_Model.Requests.NarudzbaUpsertRequest>().ReverseMap();
            CreateMap<Database.NarudzbeStavke, OnlineGym_Model.NarudzbeStavke>();
            CreateMap<Database.NarudzbeStavke, OnlineGym_Model.Requests.NarudzbaStavkaSearchRequest>().ReverseMap();
            CreateMap<Database.NarudzbeStavke, OnlineGym_Model.Requests.NarudzbaStavkaUpsertRequest>().ReverseMap();

            CreateMap<Database.RecenzijeProizvoda, OnlineGym_Model.RecenzijeProizvoda>();
            CreateMap<Database.RecenzijeTeretane, OnlineGym_Model.RecenzijeTeretane>();

            CreateMap<Database.ClanTeretana, OnlineGym_Model.ClanTeretana>();
            CreateMap<Database.ClanTeretana, OnlineGym_Model.Requests.ClanTeretanaUpsertRequest>().ReverseMap();

            CreateMap<Database.PlacanjeClanarine, OnlineGym_Model.PlacanjeClanarine>();
            CreateMap<Database.PlacanjeClanarine, OnlineGym_Model.Requests.PlacanjeClanarineSearchRequest>().ReverseMap();
            CreateMap<Database.PlacanjeClanarine, OnlineGym_Model.Requests.PlacanjeClanarineUpsertRequest>().ReverseMap();    

            CreateMap<Database.Korisnik, OnlineGym_Model.Requests.KorisniciInsertRequest>().ReverseMap();

            CreateMap<Database.Proizvod, OnlineGym_Model.Requests.ProizvodUpsertRequest>().ReverseMap()
                .ForMember(x => x.RecenzijeProizvoda, opt => opt.Ignore())
                .ForMember(x => x.NarudzbeStavke, opt => opt.Ignore())
                .ForMember(x => x.KategorijaProizvoda, opt => opt.Ignore())
                .ForMember(x => x.ProizvodId, opt => opt.Ignore());

            CreateMap<Database.Teretana, OnlineGym_Model.Requests.TeretanaUpsertRequest>().ReverseMap()
            .ForMember(x => x.RecenzijeTeretane, opt => opt.Ignore())
            .ForMember(x => x.PlacanjeClanarine, opt => opt.Ignore())
              .ForMember(x => x.TeretanaId, opt => opt.Ignore())
                .ForMember(x => x.Grad, opt => opt.Ignore())
            .ForMember(x => x.ClanTeretana, opt => opt.Ignore());        
          
            CreateMap<Database.RecenzijeTeretane, OnlineGym_Model.Requests.RecenzijeTeretaneUpsertRequest>().ReverseMap();
            CreateMap<Database.RecenzijeProizvoda, OnlineGym_Model.Requests.RecenzijeProizvodaUpsertRequest>().ReverseMap();

        }

    }
}
