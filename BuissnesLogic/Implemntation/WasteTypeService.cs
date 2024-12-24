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
    public class WasteTypeService : IWasteTypeService
    {
        private readonly IWasteTypeReposatory _Repository;
        private readonly IMapper _mapper;
        public WasteTypeService(IWasteTypeReposatory repository, IMapper mapper)
        {
            _Repository = repository;
            _mapper = mapper;
        }
        public async Task AddWasteTypeAsync(AddWasteTypeDto wasteType)
        {
            var newWasteType = _mapper.Map<WasteType>(wasteType);
            await _Repository.Add(newWasteType);
        }

        public async Task DeleteWasteTypeAsync(int id)
        {
            await _Repository.Delete(id);
        }

        public async Task<IEnumerable<GetWasteTypeDto>> GetAllWasteTypesAsync()
        {
            var WasteType = await _Repository.GetAll();
            return _mapper.Map<IEnumerable<GetWasteTypeDto>>(WasteType);
        }

        public async Task UpdateWasteAsync(GetWasteTypeDto wasteType)
        {
            var existingWasteType = await _Repository.GetById(wasteType.Id);
            if (existingWasteType == null)
            {
                throw new Exception("Waste type not found.");
            }

            // تحديث الحقول بالقيم الجديدة
            _mapper.Map(wasteType, existingWasteType);

            // تحديث البيانات في قاعدة البيانات
            await _Repository.Update(existingWasteType);
        }

       
    }
}
