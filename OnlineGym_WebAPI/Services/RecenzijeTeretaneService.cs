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
    public class RecenzijeTeretaneService : BaseCRUDService<OnlineGym_Model.RecenzijeTeretane, RecenzijeTeretaneSearchRequest, Database.RecenzijeTeretane, RecenzijeTeretaneUpsertRequest, RecenzijeTeretaneUpsertRequest>
    {
        public RecenzijeTeretaneService(DB_TeretanaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<OnlineGym_Model.RecenzijeTeretane> Get(RecenzijeTeretaneSearchRequest request)
        {
            var query = _context.Set<Database.RecenzijeTeretane>().Include(x => x.Teretana).Include(n => n.Clan).AsQueryable();
         
            if (request?.TeretanaId.HasValue == true && request?.ClanId.HasValue==true)
            {
                query = query.Where(x => x.TeretanaId == request.TeretanaId && x.ClanId==request.ClanId);
            }

           else if (request?.TeretanaId.HasValue == true)
            {
                query = query.Where(x => x.TeretanaId == request.TeretanaId);
            }

            query = query.OrderBy(x => x.TeretanaId);
            var list = query.ToList();
            return _mapper.Map<List<OnlineGym_Model.RecenzijeTeretane>>(list);
          
        }

        public override OnlineGym_Model.RecenzijeTeretane GetById(int id)
        {
            var entity = _context.RecenzijeTeretane.Find(id);

            return _mapper.Map<OnlineGym_Model.RecenzijeTeretane>(entity);
        }

        public override OnlineGym_Model.RecenzijeTeretane Insert(RecenzijeTeretaneUpsertRequest request)
        {
            var entity = _mapper.Map<Database.RecenzijeTeretane>(request);

          

            _context.RecenzijeTeretane.Add(entity);
            _context.SaveChanges();
            UpdateProsjecnaOcjena(request.TeretanaId);

         

            return _mapper.Map<OnlineGym_Model.RecenzijeTeretane>(entity);
        }

        public override OnlineGym_Model.RecenzijeTeretane Update(int id, RecenzijeTeretaneUpsertRequest request)
        {
            var entity = _context.RecenzijeTeretane.Find(id);
            _context.RecenzijeTeretane.Attach(entity);
            _context.RecenzijeTeretane.Update(entity);

      

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<OnlineGym_Model.RecenzijeTeretane>(entity);
        }

        private void UpdateProsjecnaOcjena(int TeretanaId) {
            var entity = _context.Teretana.Find(TeretanaId);
            double avg = _context.RecenzijeTeretane.Where(x => x.TeretanaId == TeretanaId).Select(x => x.Ocjena).Average()??0;

            entity.ProsjecnaOCjena = avg;
            _context.Teretana.Update(entity);
            _context.SaveChanges();
        }
    }
}
