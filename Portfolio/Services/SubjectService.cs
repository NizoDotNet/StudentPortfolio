﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Entities;
using Portfolio.Repository;

namespace Portfolio.Services;

public class SubjectService : IRepository<Subject>
{
    private readonly ApplicationDbContext _db;

    public SubjectService(ApplicationDbContext db)
    {
        this._db = db;
    }
    public async Task CreateAsync(Subject entity)
    {
        await _db.Subjects.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var sub = await _db
            .Subjects
            .FirstOrDefaultAsync(x => x.Id == id);
        if (sub != null)
        {
            _db.Subjects.Remove(sub);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Subject>> GetAllAsync()
    {
        return await _db
            .Subjects
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Subject> GetAsync(int id)
    {
        return await _db
            .Subjects
            .Include(c => c.Teacher)
            .Include(c => c.LabWorks)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(int id, Subject entity)
    {
        var sub = await _db
            .Subjects
            .FirstOrDefaultAsync(x => x.Id == id);  
        if(sub != null)
        {
            sub.Name = entity.Name;
        }
    }
}