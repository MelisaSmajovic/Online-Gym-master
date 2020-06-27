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
    public class ClanTeretanaService : BaseCRUDService<OnlineGym_Model.ClanTeretana, ClanTeretanaSearchRequest, Database.ClanTeretana, ClanTeretanaUpsertRequest, ClanTeretanaUpsertRequest>
    {
        public ClanTeretanaService(DB_TeretanaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<OnlineGym_Model.ClanTeretana> Get(ClanTeretanaSearchRequest search)
        {
            var query = _context.Set<Database.ClanTeretana>().Include(x => x.Teretana).Include(t=>t.Clan).AsQueryable();

        
            if (search?.ClanId.HasValue == true && search?.TeretanaId.HasValue == true)
            {
                query = query.Where(x => x.ClanId == search.ClanId && x.TeretanaId==search.TeretanaId);
                query = query.OrderBy(x => x.ClanTeretanaId);

                var list = query.ToList();

                return _mapper.Map<List<OnlineGym_Model.ClanTeretana>>(list);
            }
            else
            {
                if (search?.ClanId.HasValue == true)
                {
                    query = query.Where(x => x.ClanId == search.ClanId);
                }
                if (search?.TeretanaId.HasValue == true)
                {
                    query = query.Where(x => x.TeretanaId == search.TeretanaId);
                }

                query = query.OrderBy(x => x.ClanTeretanaId);

                var list = query.ToList();

                return _mapper.Map<List<OnlineGym_Model.ClanTeretana>>(list);
            }
        }

    }
}
