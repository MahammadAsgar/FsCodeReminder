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
            CreateMap<Reminder, ReminderPost>().ReverseMap();
            CreateMap<Reminder, ReminderPut>().ReverseMap();
            CreateMap<Reminder, ReminderGet>()
                .ForMember(x => x.SendAt, y => y.MapFrom(z => z.SendAt.ToString("MM/dd/yyyy"))).ReverseMap();
        }
    }
}
