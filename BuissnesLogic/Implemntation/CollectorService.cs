using AutoMapper;
using BuissnesLogic.DTO;
using BuissnesLogic.ServiceIntrface;
using DataAcsessLayer.Entity;
using DataAcsessLayer.repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.Implemntation
{
    public class CollectorService : ICollectorService
    {

        private readonly IRepository<Collector> _Repository;
        private readonly IMapper _mapper;
        public CollectorService(IRepository<Collector> repository, IMapper mapper)
        {
            _Repository = repository;
            _mapper = mapper;
        }

        public async Task AddCollectorAsync(AddCollectorDto Collector)
        {
            var newCollector = _mapper.Map<Collector>(Collector);
            await _Repository.Add(newCollector); // استخدم await بشكل صحيح
        }

        public async Task<IEnumerable<GetCollectorDto>> GetAllCollectorAsync()
        {
            var Coolectors = await _Repository.GetAll();
            return _mapper.Map<IEnumerable<GetCollectorDto>>(Coolectors);
        }
    }
}
