using AutoMapper;
using Portfolio.Entities;
using Portfolio.Models.Class;
using Portfolio.Models.LabWork;
using Portfolio.Models.Subject;

namespace Portfolio.AutoMapperProfile;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        
        CreateMap<AddSubjectDto, Subject>().ReverseMap();
        CreateMap<SubjectDto, Subject>().ReverseMap();
        CreateMap<ClassDto, Class>().ReverseMap();
        CreateMap<LabWorkDto, LabWork>().ReverseMap();
        CreateMap<AddLabWorkDto, LabWork>().ReverseMap();

    }
}
