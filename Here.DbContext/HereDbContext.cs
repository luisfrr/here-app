using Here.DbContext.Builders;
using Here.Models.DbHelpers;
using Here.Models.Domain;
using Here.Common.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Here.Common.Extensions;

namespace Here.DbContext
{
	public class HereDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, string>
  {
    public HereDbContext(DbContextOptions<HereDbContext> options)
      : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        IConfiguration configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json").Build();

        optionsBuilder
          .UseMySql(configuration.GetConnectionString("HereDbConnection"),
            ServerVersion.AutoDetect(configuration.GetConnectionString("HereDbConnection"))
          );
      }

      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      // Soft Deleted Filter
      SoftDeletedFilter(ref builder);

      new ApplicationUserBuilder(builder.Entity<ApplicationUser>());
      new ApplicationRoleBuilder(builder.Entity<ApplicationRole>());
      new CompanyBuilder(builder.Entity<Company>());
      new EmployeeBuilder(builder.Entity<Employee>());
      new ShiftBuilder(builder.Entity<Shift>());
      new RuleBuilder(builder.Entity<Rule>());
      new EventTypeBuilder(builder.Entity<EventType>());
      new EventBuilder(builder.Entity<Event>());

      // Initial Data
      SeedData(ref builder);
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<Rule> Rules { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<Event> Events { get; set; }

    public override int SaveChanges()
    {
      // Audit Entity Happens
      AuditEntity();

      return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
      // Audit Entity Happens
      AuditEntity();

      return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
      CancellationToken cancellationToken = default)
    {
      // Audit Entity Happens
      AuditEntity();

      return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      // Audit Entity Happens
      AuditEntity();

      return base.SaveChangesAsync(cancellationToken);
    }

    private void AuditEntity()
    {
      var modifiedEntries = ChangeTracker.Entries()
        .Where(x => x.Entity is IAuditEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

      var user = string.Empty;

      foreach(var entry in modifiedEntries)
      {
        var entity = entry.Entity as IAuditEntity;

        if(entity != null)
        {
          var date = DateTime.Now;
          string userId = user;

          if(entry.State == EntityState.Added)
          {
            entity.CreatedAt = date;
            entity.CreatedBy = !string.IsNullOrEmpty(entity.CreatedBy) ? entity.CreatedBy: userId;
          }
          else if(entity is ISoftDeleted && ((ISoftDeleted)entity).IsDeleted)
          {
            entity.DeletedAt = date;
            entity.DeletedBy = userId;
          }

          Entry(entity).Property(x => x.CreatedAt).IsModified = false;
          Entry(entity).Property(x => x.CreatedBy).IsModified = false;

          entity.UpdatedAt = date;
          entity.UpdatedBy = userId;
        }
      }
    }

    private void SoftDeletedFilter(ref ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ApplicationUser>().HasQueryFilter(x => !x.IsDeleted);
      modelBuilder.Entity<ApplicationRole>().HasQueryFilter(x => !x.IsDeleted);
      modelBuilder.Entity<Company>().HasQueryFilter(x => !x.IsDeleted);
      modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.IsDeleted);
      modelBuilder.Entity<Shift>().HasQueryFilter(x => !x.IsDeleted);
      modelBuilder.Entity<Rule>().HasQueryFilter(x => !x.IsDeleted);
      modelBuilder.Entity<EventType>().HasQueryFilter(x => !x.IsDeleted);
      modelBuilder.Entity<Event>().HasQueryFilter(x => !x.IsDeleted);
    }

    private void SeedData(ref ModelBuilder modelBuilder)
    {
      // Seed Event Types
      var count = 1;
      var eventTypesList = new List<EventType>();
      foreach(EventTypes eventType in Enum.GetValues(typeof(EventTypes)))
      {
        eventTypesList.Add(new EventType
        {
          Id = count,
          Name = EnumsExtension.GetDescription(eventType),
          CreatedBy = "HereDbContext",
          CreatedAt = DateTime.Now
        });

        count++;
      }

      if(eventTypesList.Count > 0)
      {
        modelBuilder.Entity<EventType>().HasData(eventTypesList.ToArray());
      }

      // Seed Roles
      var rolesList = new List<ApplicationRole>();
      foreach (Roles role in Enum.GetValues(typeof(Roles)))
      {
        rolesList.Add(new ApplicationRole
        {
          Name = EnumsExtension.GetDescription(role),
          NormalizedName = EnumsExtension.GetDescription(role).ToUpper(),
          Description = "Default System Role",
          IsDeleted = false,
          CreatedBy = "HereDbContext",
          CreatedAt = DateTime.Now
        });
      }

      if (rolesList.Count > 0)
      {
        modelBuilder.Entity<ApplicationRole>().HasData(rolesList.ToArray());
      }
    }
  }
}
