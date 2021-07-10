using Here.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.DbContext.Builders
{
  public class RuleBuilder
  {
    public RuleBuilder(EntityTypeBuilder<Rule> builder)
    {
      builder.HasKey(rule => rule.Id);

      builder.Property(rule => rule.Name).IsRequired().HasMaxLength(128);
      builder.Property(rule => rule.Start).IsRequired();
      builder.Property(rule => rule.End).IsRequired();
      builder.Property(rule => rule.ShiftId).IsRequired();
    }
  }
}
