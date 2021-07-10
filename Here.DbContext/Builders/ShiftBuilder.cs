using Here.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.DbContext.Builders
{
  public class ShiftBuilder
  {
    public ShiftBuilder(EntityTypeBuilder<Shift> builder)
    {
      builder.HasKey(shift => shift.Id);

      builder.Property(shift => shift.Name).IsRequired().HasMaxLength(128);
      builder.Property(shift => shift.Start).IsRequired();
      builder.Property(shift => shift.End).IsRequired();
      builder.Property(shift => shift.CompanyId).IsRequired();
    }
  }
}
