using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineGym_Model.Requests;
using OnlineGym_WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    
        public class RecenzijeProizvodaService : BaseCRUDService<OnlineGym_Model.RecenzijeProizvoda, RecenzijeProizvodaSearchRequest, Database.RecenzijeProizvoda, RecenzijeProizvodaUpsertRequest, RecenzijeProizvodaUpsertRequest>
        {
            public RecenzijeProizvodaService(DB_TeretanaContext context, IMapper mapper) : base(context, mapper)
            {
            }



            public override List<OnlineGym_Model.RecenzijeProizvoda> Get(RecenzijeProizvodaSearchRequest request)
        {
            var query = _context.Set<Database.RecenzijeProizvoda>().Include(x => x.Proizvod).Include(n => n.Clan).AsQueryable();
           
            if (request?.ProizvodId.HasValue == true && request?.ClanId.HasValue == true)
            {
                query = query.Where(x => x.ProizvodId == request.ProizvodId && x.ClanId == request.ClanId);
            }

            else if (request?.ProizvodId.HasValue == true && request?.ClanId.HasValue == false)
                {
                    query = query.Where(x => x.ProizvodId == request.ProizvodId);
                }

            query = query.OrderBy(x => x.RecenzijaProizvodaId);
            var list = query.ToList();

            return _mapper.Map<List<OnlineGym_Model.RecenzijeProizvoda>>(list);
        }

        public override OnlineGym_Model.RecenzijeProizvoda GetById(int id)
        {
            var entity = _context.RecenzijeProizvoda.Find(id);

            return _mapper.Map<OnlineGym_Model.RecenzijeProizvoda>(entity);
        }

        public override OnlineGym_Model.RecenzijeProizvoda Insert(RecenzijeProizvodaUpsertRequest request)
        {
            var entity = _mapper.Map<Database.RecenzijeProizvoda>(request);


            _context.RecenzijeProizvoda.Add(entity);
            _context.SaveChanges();

          
            UpdateProsjecnaOcjena(request.ProizvodId);

            return _mapper.Map<OnlineGym_Model.RecenzijeProizvoda>(entity);
        }

        public override OnlineGym_Model.RecenzijeProizvoda Update(int id, RecenzijeProizvodaUpsertRequest request)
        {
            var entity = _context.RecenzijeProizvoda.Find(id);
            _context.RecenzijeProizvoda.Attach(entity);
            _context.RecenzijeProizvoda.Update(entity);

         

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<OnlineGym_Model.RecenzijeProizvoda>(entity);
        }
        private void UpdateProsjecnaOcjena(int ProizvodId)
        {
            var entity = _context.Proizvod.Find(ProizvodId);
            double avg = _context.RecenzijeProizvoda.Where(x => x.ProizvodId == ProizvodId).Select(x => x.Ocjena).Average() ?? 0;
        
            entity.ProsjecnaOcjena = avg;
            _context.Proizvod.Update(entity);
            _context.SaveChanges();
   
        }
    }
}
