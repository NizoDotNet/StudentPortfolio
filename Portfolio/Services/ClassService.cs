﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Entities;
using Portfolio.Repository;

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

    public async Task RemoveSubjectRange(IList<int> ids)
    {
        var labWorks = await _db
            .LabWorks
            .Where(c => ids.Contains(c.Id))
            .ToListAsync();   


        _db.LabWorks.RemoveRange(labWorks);
        await _db.SaveChangesAsync();
    }
}
