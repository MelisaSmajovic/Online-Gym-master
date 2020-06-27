using AutoMapper;
using OnlineGym_WebAPI.Database;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineGym_WebAPI.Services
{
    public class NarudzbaStavkaService : INarudzbaStavkaService
    {
        private readonly DB_TeretanaContext _context;
        private readonly IMapper _mapper;
        public NarudzbaStavkaService(DB_TeretanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  List<OnlineGym_Model.NarudzbeStavke> Get(NarudzbaStavkaSearchRequest search)
        {
            var query = _context.Set<Database.NarudzbeStavke>().Include(x => x.Proizvod).Include(n=>n.Narudzba).AsQueryable();


            if (search?.NarudzbeStavkeId.HasValue == true)
            {
                query = query.Where(x => x.NarudzbeStavkeId == search.NarudzbeStavkeId);
            }
            if (search?.KategorijaId.HasValue == true)
            {
                query = query.Where(x => x.Proizvod.KategorijaProizvodaId == search.KategorijaId);
            }
            if (search?.NarudzbaId.HasValue == true)
            {
                query = query.Where(x => x.NarudzbaId == search.NarudzbaId);
            }

            query = query.OrderBy(x => x.NarudzbeStavkeId);

            var list = query.ToList();

            return _mapper.Map<List<OnlineGym_Model.NarudzbeStavke>>(list);
        }

        public OnlineGym_Model.NarudzbeStavke Insert(NarudzbaStavkaUpsertRequest request)
        {
            var entity = _mapper.Map<Database.NarudzbeStavke>(request);
            _context.NarudzbeStavke.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<OnlineGym_Model.NarudzbeStavke>(entity);
        }
        public bool Delete(int id)
        {
           
                var entity = _context.NarudzbeStavke.Find(id);

                _context.NarudzbeStavke.Remove(entity);
                _context.SaveChanges();
                return true;
          
        }
    }
}
