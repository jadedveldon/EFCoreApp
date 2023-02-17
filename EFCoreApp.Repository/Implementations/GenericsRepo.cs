using EDCore.Data.Entities.Modals;
using EFCoreApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Repository.Implementations;

public class GenericsRepo<T> : IGenericsRepo<T> where T : BaseClass
{
    private readonly MasterContext context;
    private readonly DbSet<T> entities;

    public GenericsRepo(MasterContext context)
    {
        this.context = context;
        this.entities = context.Set<T>();
    }
    public async Task<T> Get(int id)
    {
        try
        {
            return await entities.FindAsync(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        try
        {
            return await entities.ToListAsync();
        }
        catch (Exception) 
        {
            throw;
        }
    }

    public async Task Add(T entity)
    {
        try
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        catch(Exception)
        {
            throw;
        }
        
    }

    public async Task Update(T entity)
    {
        try
        {
            entities.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            var entity = await Get(id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
