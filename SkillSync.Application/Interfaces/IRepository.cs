using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillSync.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();    // Return type must be Task<IEnumerable<T>>
        Task<T?> GetByIdAsync(Guid id);        // Must use Guid as the primary key type
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);             // Delete by Guid
    }
}
