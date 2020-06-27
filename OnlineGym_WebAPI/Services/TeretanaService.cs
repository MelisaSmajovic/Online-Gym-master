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
    public class TeretanaService : BaseCRUDService<OnlineGym_Model.Teretana, TeretanaSearchRequest, Database.Teretana, TeretanaUpsertRequest, TeretanaUpsertRequest>
    {
        public TeretanaService(DB_TeretanaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<OnlineGym_Model.Teretana> Get(TeretanaSearchRequest search)
        {
            var query = _context.Set<Database.Teretana>().Include(t=>t.Grad).AsQueryable();

            if (search?.GradId.HasValue == true)
            {
                query = query.Where(x => x.GradId == search.GradId);
            }

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
            }
            query = query.OrderBy(x => x.TeretanaId);

            var list = query.ToList();

            return _mapper.Map<List<OnlineGym_Model.Teretana>>(list);
        }
    
    }
}
