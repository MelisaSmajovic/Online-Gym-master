using OnlineGym_WebAPI.Database;
using OnlineGym_Model;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace OnlineGym_WebAPI.Services
{
    public class ProizvodService : BaseCRUDService<OnlineGym_Model.Proizvod, ProizvodSearchRequest, Database.Proizvod, ProizvodUpsertRequest, ProizvodUpsertRequest>
    {
        public ProizvodService(DB_TeretanaContext context, IMapper mapper) : base(context, mapper)
        {
        }
    
        public override List<OnlineGym_Model.Proizvod> Get(ProizvodSearchRequest search)
        {
            var query = _context.Set<Database.Proizvod>().Include(x => x.VrstaProizvoda).Include(k=>k.KategorijaProizvoda).AsQueryable();

            if (search?.KategorijaProizvodaId.HasValue == true)
            {
                query = query.Where(x => x.KategorijaProizvodaId == search.KategorijaProizvodaId);
            }
            if (search?.VrstaProizvodaId.HasValue == true)
            {
                query = query.Where(x => x.VrstaProizvodaId == search.VrstaProizvodaId);
            }
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
            }
            query = query.OrderBy(x => x.Naziv);

            var list = query.ToList();

            return _mapper.Map<List<OnlineGym_Model.Proizvod>>(list);
        }

    }
}
