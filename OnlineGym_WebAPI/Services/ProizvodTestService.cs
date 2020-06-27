using AutoMapper;
using OnlineGym_WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Services
{
    public class ProizvodTestService : IProizvodTestService
    {
        private readonly DB_TeretanaContext _context;
        private readonly IMapper _mapper;
        public ProizvodTestService(DB_TeretanaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OnlineGym_Model.Proizvod> Get()
        {
            var entity = _context.Proizvod.ToList();

            return _mapper.Map<List<OnlineGym_Model.Proizvod>>(entity);

        }

        public OnlineGym_Model.Proizvod GetById(int id)
        {
            var entity = _context.Proizvod.Find(id);

            return _mapper.Map<OnlineGym_Model.Proizvod>(entity);
        }
    }
}
