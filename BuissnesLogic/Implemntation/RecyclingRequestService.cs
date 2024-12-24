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
    public class RecyclingRequestService : IRecyclingRequestService
    {
        private readonly IRecyclingRequestReposatory _requestRepository;
        private readonly IWasteTypeReposatory _wasteTypeRepository;
        private readonly IUserReposatory _userRepository;
        private readonly IMapper _mapper;

        public RecyclingRequestService(
            IRecyclingRequestReposatory requestRepository,
            IWasteTypeReposatory wasteTypeRepository,
            IUserReposatory userRepository,
            IMapper mapper)
        {
            _requestRepository = requestRepository;
            _wasteTypeRepository = wasteTypeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddRecyclingRequestAsync(AddRequestDto requestDto)
        {
            // البحث عن WasteTypeId باستخدام اسم النفايات
            var wasteType = await _wasteTypeRepository.GetAll();
            var matchingWasteType = wasteType.FirstOrDefault(w => w.WasteName == requestDto.WasteName);

            if (matchingWasteType == null)
                throw new Exception($"Waste type '{requestDto.WasteName}' not found.");

            // البحث عن UserId باستخدام رقم الهاتف
            var users = await _userRepository.GetAll();
            var matchingUser = users.FirstOrDefault(u => u.PhoneNumber == requestDto.UserPhone);

            if (matchingUser == null)
                throw new Exception($"User with phone number '{requestDto.UserPhone}' not found.");

            // إنشاء الكيان الجديد
            var recyclingRequest = _mapper.Map<RecyclingRequest>(requestDto);
            recyclingRequest.WasteTypeId = matchingWasteType.Id;
            recyclingRequest.UserId = matchingUser.Id;

            await _requestRepository.Add(recyclingRequest);
        }

        public async Task<IEnumerable<LastActivityDTO>> GetAllActivity()
        {
            var requests = await _requestRepository.GetAll();
            return _mapper.Map<IEnumerable<LastActivityDTO>>(requests);
        }

        public async Task<IEnumerable<GetRequestDto>> GetAllRecyclingRequestsAsync()
        {
            var requests = await _requestRepository.GetAll();
            return _mapper.Map<IEnumerable<GetRequestDto>>(requests);
        }

        public async Task<decimal> GetTotalQuantityAsync()
        {
            return await _requestRepository.GetTotalQuantityAsync();
        }
    }
}

