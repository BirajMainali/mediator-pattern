using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatrPattern.Entities;
using MediatrPattern.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediatrPattern.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AddSafeDeleteGlobalQuery(builder);
            base.OnModelCreating(builder);
        }

        public DbSet<Employee> Employee { get; set; }

        public void SetGlobalQuery<T>(ModelBuilder builder) where T : GenericModel
        {
            builder.Entity<T>().HasQueryFilter(e => e.RecStatus.Equals('A'));
        }

        private static readonly MethodInfo SetGlobalQueryMethod = typeof(ApplicationDbContext)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        private void AddSafeDeleteGlobalQuery(ModelBuilder builder)
        {
            foreach (var type in builder.Model.GetEntityTypes())
            {
                if (type.BaseType != null || !typeof(ISoftDelete).IsAssignableFrom(type.ClrType)) continue;
                var method = SetGlobalQueryMethod.MakeGenericMethod(type.ClrType);
                method.Invoke(this, new object[] {builder});
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;
                if (entry.State != EntityState.Deleted || entity is not ISoftDelete) continue;
                entry.State = EntityState.Modified;
                entity.GetType().GetProperty("RecStatus")?.SetValue(entity, 'D');
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;
                if (entry.State != EntityState.Deleted || entity is not ISoftDelete) continue;
                entry.State = EntityState.Modified;
                entry.GetType().GetProperty("RecStatus")?.SetValue(entity, 'D');
            }

            return base.SaveChanges();
        }
    }
}