using AutoMapper;
using OnlineGym_WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public class GradService:IGradService
    {
        private readonly DB_TeretanaContext _context;
        private readonly IMapper _mapper;

        public GradService(DB_TeretanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OnlineGym_Model.Gradovi> Get()
        {            
            var query = _context.Grad.AsQueryable();      
            query = query.OrderBy(x => x.GradId);
            var list = query.ToList();

            return _mapper.Map<List<OnlineGym_Model.Gradovi>>(list);
        }
    }
}
