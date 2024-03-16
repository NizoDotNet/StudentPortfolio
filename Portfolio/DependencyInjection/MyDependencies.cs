﻿using Portfolio.Entities;
using Portfolio.Repository;
using Portfolio.Services;
using Portfolio.AutoMapperProfile;
using Portfolio.Helper;

namespace Portfolio.DependencyInjection;

public static class MyDependencies
{
    public static void AddMyDependencies(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Subject>, SubjectService>();
        services.AddScoped<IRepository<LabWork>, LabWorkService>();
        services.AddScoped<IRepository<Class>, ClassService>();
        
        services.AddAutoMapper(typeof(AutoMapperProfile.AutoMapperProfile));
        services.AddSingleton(new AddToCollection());
    }
}
