using EDCore.Data.Entities.Modals;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Repository.Interfaces;

public interface IGenericsRepo<T> where T: BaseClass
{
    public Task<T> Get(int id);
    public Task<IEnumerable<T>> GetAll();
    public Task Add(T entity);
    public Task Update(T entity);
    public Task Delete(int id);
}
        