using AutoMapper;
using OnlineGym_WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public class SistemPreporukeTeretane:ISistemPreporukeTeretane
    {
        private readonly DB_TeretanaContext _context;
        private readonly IMapper _mapper;
        List<OnlineGym_Model.Teretana> ostaleTeretane = new List<OnlineGym_Model.Teretana>();
        public SistemPreporukeTeretane(DB_TeretanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<OnlineGym_Model.Teretana> GetPreporukaByTeretana(OnlineGym_Model.Teretana teretana)
        {
            UcitajTeretane(teretana.TeretanaId);
            List<OnlineGym_Model.Teretana> listaPreporuka = new List<OnlineGym_Model.Teretana>();
            foreach(var t in ostaleTeretane)
            {
                if(t.GradId==teretana.GradId)
                {
                    listaPreporuka.Add(t);
                }
            }
            return listaPreporuka;
        }
            public List<OnlineGym_Model.Teretana> Get(int gradId)
        {
            if (gradId != 0)
            {
                var query = _context.Set<Database.Teretana>().AsQueryable();

                query = query.Where(x => x.GradId == gradId);
                query = query.OrderBy(x => x.Naziv);

                var list = query.ToList();

                return _mapper.Map<List<OnlineGym_Model.Teretana>>(list);
            }
            else
            {
                return null;
            }
        }
        public void UcitajTeretane(int teretanaId)
        {  
                List<Database.Teretana> listaTeretana = _context.Teretana.Where(p => p.TeretanaId != teretanaId).ToList();
                foreach (var trt in listaTeretana)
                {
                    OnlineGym_Model.Teretana tempTeretana = _mapper.Map<OnlineGym_Model.Teretana>(trt);
                    ostaleTeretane.Add(tempTeretana);
                }             
            
        }
    }
}

