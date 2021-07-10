using Here.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.DbContext.Builders
{
  public class ApplicationRoleBuilder
  {
    public ApplicationRoleBuilder(EntityTypeBuilder<ApplicationRole> builder)
    {
      builder.HasKey(role => role.Id);

      builder.Property(role => role.Name).IsRequired().HasMaxLength(128);
      builder.Property(role => role.Description).HasMaxLength(256);
    }
  }
}
