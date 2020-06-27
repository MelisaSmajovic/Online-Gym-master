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
    public class Izlazservice:IIzlazService
    {
            private readonly DB_TeretanaContext _context;
            private readonly IMapper _mapper;
            public Izlazservice(DB_TeretanaContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public List<OnlineGym_Model.Izlazi> Get(IzlazSearchRequest search)
            {
                var query = _context.Set<Database.Izlazi>().Include(c => c.Narudzbe).AsQueryable();

                if (search?.Datum.HasValue == true)
                {
                    DateTime date = new DateTime();
                    date = search.Datum.Value;
                    query = query.Where(x => x.Datum.Date.CompareTo(date.Date) == 0);

                }
                if (search?.Zakljucen.HasValue == true)
                {
                    query = query.Where(x => x.Zakljucen == search.Zakljucen);
                }
        
                if (search?.NarudzbaId.HasValue == true)
                {
                    query = query.Where(x => x.NarudzbaId == search.NarudzbaId);
                }

                query = query.OrderBy(x => x.Datum); 
                var list = query.ToList();

                return _mapper.Map<List<OnlineGym_Model.Izlazi>>(list);
            }
            public OnlineGym_Model.Izlazi GetById(int id)
            {
                var query = _context.Set<Database.Izlazi>().Include(c => c.Narudzbe).AsQueryable();
                var entity = query.Where(x => x.IzlazId == id).FirstOrDefault();
                return _mapper.Map<OnlineGym_Model.Izlazi>(entity);
            }
            public OnlineGym_Model.Izlazi Insert(IzlazUpsertRequest request)
            {
                var entity = _mapper.Map<Database.Izlazi>(request);
                _context.Izlazi.Add(entity);
                _context.SaveChanges();
                return _mapper.Map<OnlineGym_Model.Izlazi>(entity);
            }
            public OnlineGym_Model.Izlazi Update(IzlazUpsertRequest request)
            {
                var entity = _mapper.Map<Database.Izlazi>(request);
                _context.Izlazi.Update(entity);
                _context.SaveChanges();
                return _mapper.Map<OnlineGym_Model.Izlazi>(entity);
            }
        }
    }
