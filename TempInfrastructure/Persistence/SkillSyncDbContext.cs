using Microsoft.EntityFrameworkCore;
using SkillSync.Application.Common.Interfaces;
using SkillSync.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SkillSync.Infrastructure.Persistence
{
    public class SkillSyncDbContext : DbContext, IApplicationDbContext
    {
        public SkillSyncDbContext(DbContextOptions<SkillSyncDbContext> options)
           : base(options)
        {
        }

        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<JobPost> JobPosts => Set<JobPost>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Skill>().ToTable("Skills");
            modelBuilder.Entity<JobPost>().ToTable("JobPosts"); // optional table name
        }
    }
}
