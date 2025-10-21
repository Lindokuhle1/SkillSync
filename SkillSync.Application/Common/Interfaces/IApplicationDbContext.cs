using Microsoft.EntityFrameworkCore;  // <-- correct EF Core namespace
using SkillSync.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SkillSync.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Skill> Skills { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
