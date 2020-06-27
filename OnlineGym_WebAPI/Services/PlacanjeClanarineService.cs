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
    public class PlacanjeClanarineService : BaseCRUDService<OnlineGym_Model.PlacanjeClanarine, PlacanjeClanarineSearchRequest, Database.PlacanjeClanarine, PlacanjeClanarineUpsertRequest, PlacanjeClanarineUpsertRequest>
    {
        public PlacanjeClanarineService(DB_TeretanaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<OnlineGym_Model.PlacanjeClanarine> Get(PlacanjeClanarineSearchRequest search)
        {
            var query = _context.Set<Database.PlacanjeClanarine>().Include(c=>c.Clan).Include(t=>t.Teretana).Include(p=>p.TipClanarine).AsQueryable();


            if (search?.ClanId.HasValue == true)
            {
                query = query.Where(x => x.ClanId == search.ClanId);
            }
            if (search?.TeretanaId.HasValue == true)
            {
                query = query.Where(x => x.TeretanaId == search.TeretanaId);
            }
            if (search?.MjesecUplate != 0)
            {
                query = query.Where(x => x.DatumUplate.Month == search.MjesecUplate);
            }
            if (search?.GodinaUplate != 0)
            {
                query = query.Where(x => x.DatumUplate.Year == search.GodinaUplate);
            }
            if (search?.TipClanarineId.HasValue == true && search.TipClanarineId!=0)
            {
                query = query.Where(x => x.TipClanarineId == search.TipClanarineId);
            }
            else
            {
                query = query.Where(x => x.TipClanarineId == 1 || x.TipClanarineId == 2 || x.TipClanarineId == 3);

            }
            query = query.OrderBy(x => x.PlacanjeClanarineId);

            var list = query.ToList();

            return _mapper.Map<List<OnlineGym_Model.PlacanjeClanarine>>(list);
        }
    }
}
