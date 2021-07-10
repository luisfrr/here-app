using Here.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.DbContext.Builders
{
  public class ApplicationUserBuilder
  {
    public  ApplicationUserBuilder(EntityTypeBuilder<ApplicationUser> builder)
    {
      builder.HasKey(user => user.Id);
      builder.Property(user => user.Name).IsRequired().HasMaxLength(100);
      builder.Property(user => user.LastName).IsRequired().HasMaxLength(100);
      builder.Property(user => user.Image).HasMaxLength(256);
    }
  }
}
