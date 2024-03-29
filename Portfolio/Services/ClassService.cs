﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Entities;
using Portfolio.Repository;
using System.Linq;

namespace Portfolio.Services;

public class ClassService(ApplicationDbContext db) : IClassRepository
{
    private readonly ApplicationDbContext _db = db;

    public async Task CreateAsync(Class entity)
    {
        if (entity != null)
        {
            await _db
                .Classes
                .AddAsync(entity);
            
            await _db.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var cls = await _db
            .Classes
            .FirstOrDefaultAsync(c => c.Id == id);
        
        if(cls != null)
        {
            _db.Classes.Remove(cls);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Class>> GetAllAsync()
    {
        return await _db
            .Classes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Class> GetAsync(int id)
    {
        return await _db
            .Classes
            .Include(c => c.Subjects)
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task UpdateAsync(int id, Class entity)
    {
        var cls = await _db.Classes.FirstOrDefaultAsync(c => c.Id == id);
        if(cls != null)
        {
            cls.Subjects = entity.Subjects;
            cls.Students = cls.Students;
            cls.Name = cls.Name;
            
            await _db.SaveChangesAsync();
        }
    }
    public async Task SaveChangesAsync() => await _db.SaveChangesAsync();

    public async Task RemoveSubjectsRangeAsync(Class cls, IList<int> ids)
    {
        var subjects = cls
            .Subjects
            .Where(c => ids.Contains(c.Id))
            .ToList();
        

        foreach (var subject in subjects)
        {
            cls.Subjects.Remove(subject);
        }
        await _db.SaveChangesAsync();
    }

    public async Task<Class> GetAsync(int id, bool includeCollections = true)
    {
        if(includeCollections) return await GetAsync(id);

        var cls = await _db.Classes.FirstOrDefaultAsync(c => c.Id == id);
        return cls;
    }
}
