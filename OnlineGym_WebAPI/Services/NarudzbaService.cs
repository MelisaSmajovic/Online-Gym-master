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
    public class NarudzbaService : INarudzbaService
    {
        private readonly DB_TeretanaContext _context;
        private readonly IMapper _mapper;
        public NarudzbaService(DB_TeretanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OnlineGym_Model.Narudzbe> Get(NarudzbaSearchRequest search)
        {
            var query = _context.Set<Database.Narudzbe>().Include(c=>c.Clan).AsQueryable();
            if (search?.Datum.HasValue == true)
            {
                DateTime date = new DateTime();
                date = search.Datum.Value;
                query = query.Where(x => x.Datum.Date.CompareTo(date.Date) == 0);
            }
            if (search?.Procesirana.HasValue == true)
            {
                query = query.Where(x =>x.Procesirana==search.Procesirana);
            }
            if (search?.ClanId.HasValue == true)
            {
                query = query.Where(x => x.ClanId == search.ClanId);
            }
            if (search?.NarudzbaId.HasValue == true)
            {
                query = query.Where(x => x.NarudzbaId == search.NarudzbaId);
            }

            query = query.OrderBy(x => x.Datum);
            var list = query.ToList();

            return _mapper.Map<List<OnlineGym_Model.Narudzbe>>(list);
        }

        public int GetMaxNarudzbaId() {
            int maxId = _context.Narudzbe.Max(x => x.NarudzbaId);
            return maxId;
        }
        public OnlineGym_Model.Narudzbe GetById(int id)
        {
            var query = _context.Set<Database.Narudzbe>().Include(c => c.Clan).AsQueryable();
            var entity = query.Where(x=>x.NarudzbaId==id).FirstOrDefault();

            return _mapper.Map<OnlineGym_Model.Narudzbe>(entity);
        }
        public OnlineGym_Model.Narudzbe Insert(NarudzbaUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Narudzbe>(request);
            _context.Narudzbe.Add(entity);
            _context.SaveChanges();
             return _mapper.Map<OnlineGym_Model.Narudzbe>(entity);
        }
        public OnlineGym_Model.Narudzbe Update(NarudzbaUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Narudzbe>(request);
            _context.Narudzbe.Update(entity);
            _context.SaveChanges();
            return _mapper.Map<OnlineGym_Model.Narudzbe>(entity);
        }
    }
}
