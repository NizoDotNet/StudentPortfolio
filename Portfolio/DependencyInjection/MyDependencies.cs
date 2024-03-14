using Portfolio.Entities;
using Portfolio.Repository;
using Portfolio.Services;
using Portfolio.AutoMapperProfile;

namespace Portfolio.DependencyInjection;

public static class MyDependencies
{
    public static void AddMyDependencies(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Subject>, SubjectService>();
        services.AddScoped<IRepository<LabWork>, LabWorkService>();
        services.AddAutoMapper(typeof(AutoMapperProfile.AutoMapperProfile));
    }
}
