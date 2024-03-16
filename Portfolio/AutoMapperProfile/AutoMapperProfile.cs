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
        
        CreateMap<AddSubjectViewModel, Subject>().ReverseMap();
        CreateMap<SubjectViewModel, Subject>().ReverseMap();
        CreateMap<ClassViewModel, Class>().ReverseMap();
        CreateMap<LabWorkViewModel, LabWork>().ReverseMap();
        CreateMap<AddLabWorkViewModel, LabWork>().ReverseMap();

    }
}
