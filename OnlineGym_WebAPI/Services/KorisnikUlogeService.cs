using AutoMapper;
using OnlineGym_WebAPI.Database;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public class KorisnikUlogeService : BaseCRUDService<OnlineGym_Model.KorisnikUloge, KorisnikUlogaSearchRequest, Database.KorisniciUloge, KorisnikUlogaUpsertRequest, KorisnikUlogaUpsertRequest>
    {
        public KorisnikUlogeService(DB_TeretanaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<OnlineGym_Model.KorisnikUloge> Get(KorisnikUlogaSearchRequest search)
        {
            var query = _context.Set<Database.KorisniciUloge>().AsQueryable();

            query = query.Where(x => x.KorisnikId == search.KorisnikId);



            query = query.OrderBy(x => x.UlogaId);

            var list = query.ToList();

            return _mapper.Map<List<OnlineGym_Model.KorisnikUloge>>(list);
        }

    }
}
