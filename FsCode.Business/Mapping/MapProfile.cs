using AutoMapper;
using FsCodeBusiness.Dtos.Get;
using FsCodeBusiness.Dtos.Post;
using FsCodeBusiness.Dtos.Put;
using FsCodeDomain.Entities;

namespace FsCodeBusiness.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Reminder, ReminderGet>().ReverseMap();
            CreateMap<Reminder, ReminderPost>().ReverseMap();
            CreateMap<Reminder, ReminderPut>().ReverseMap();
        }
    }
}
