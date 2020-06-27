using AutoMapper;
using OnlineGym_Model.Requests;
using OnlineGym_WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public class ObavijestService : BaseCRUDService<OnlineGym_Model.Obavijest, ObavijestSearchRequest, Database.Obavijest, ObavijestUpsertRequest, ObavijestUpsertRequest>
    {
        public ObavijestService(DB_TeretanaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<OnlineGym_Model.Obavijest> Get(ObavijestSearchRequest request)
        {
            var query = _context.Set<Database.Obavijest>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv));
            }

            if (request?.ObavijestId.HasValue==true)
            {
                query = query.Where(x => x.ObavijestId==request.ObavijestId);
            }

            if (request?.DatumObjave.HasValue == true)
            {
                DateTime date = new DateTime();
                date = request.DatumObjave.Value;
                query = query.Where(x => x.DatumObjave.Date.CompareTo(date.Date) == 0);
            }

            query = query.OrderByDescending(x => x.DatumObjave);
            var list = query.ToList();
            return _mapper.Map<List<OnlineGym_Model.Obavijest>>(list);
        }

        public override OnlineGym_Model.Obavijest GetById(int id)
        {
            var entity = _context.Obavijest.Find(id);
            return _mapper.Map<OnlineGym_Model.Obavijest>(entity);
        }

        public override OnlineGym_Model.Obavijest Insert(ObavijestUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Obavijest>(request);
            _context.Obavijest.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<OnlineGym_Model.Obavijest>(entity);
        }

        public override OnlineGym_Model.Obavijest Update(int id, ObavijestUpsertRequest request)
        {
            var entity = _context.Obavijest.Find(id);
            _context.Obavijest.Attach(entity);
            _context.Obavijest.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<OnlineGym_Model.Obavijest>(entity);
        }
    }
}
