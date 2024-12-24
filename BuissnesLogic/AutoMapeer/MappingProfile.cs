using AutoMapper;
using BuissnesLogic.DTO;
using DataAcsessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.AutoMapeer
{
   public class MappingProfile :Profile
    {

        public MappingProfile()
        {
           
            CreateMap<AddUserDto, User>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<AddCollectorDto, Collector>().ReverseMap();
            CreateMap<Collector, GetCollectorDto>().ReverseMap();
            CreateMap<AddWasteTypeDto, WasteType>().ReverseMap();
            CreateMap<WasteType, GetWasteTypeDto>().ReverseMap();
            CreateMap<AddRequestDto, RecyclingRequest>().ReverseMap();
            CreateMap<RecyclingRequest, GetRequestDto>().ReverseMap();
            CreateMap<RecyclingRequest, LastActivityDTO>().ReverseMap();
            

        }
    }
}
