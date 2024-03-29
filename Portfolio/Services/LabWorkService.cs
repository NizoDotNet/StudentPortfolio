﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Entities;
using Portfolio.Repository;

namespace Portfolio.Services;

public class LabWorkService(ApplicationDbContext db) : IRepository<LabWork>
{
    private readonly ApplicationDbContext _db = db;

    public async Task CreateAsync(LabWork entity)
    {
        await _db.LabWorks.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var labwork = await _db.LabWorks
            .FirstOrDefaultAsync(x => x.Id == id);

        if (labwork != null)
        {
            _db.LabWorks.Remove(labwork);
            await _db.SaveChangesAsync();   
        }
    }

    public async Task<IEnumerable<LabWork>> GetAllAsync()
    {
        return await _db.LabWorks
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<LabWork> GetAsync(int id)
    {
        return await _db.LabWorks
            .Include(c => c.Users)
            .FirstOrDefaultAsync(c => c.Id == id);  
    }

    public async Task UpdateAsync(int id, LabWork entity)
    {
        var lab = await _db.LabWorks.FirstOrDefaultAsync(c => c.Id == id);    
        if(lab != null)
        {
            lab.Completed = entity.Completed;
            lab.Name = entity.Name;
            await _db.SaveChangesAsync();

        }
    }
    public async Task SaveChangesAsync() => await _db.SaveChangesAsync();

}
