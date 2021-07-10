using Here.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.DbContext.Builders
{
  public class EventBuilder
  {
    public EventBuilder(EntityTypeBuilder<Event> builder)
    {
      builder.HasKey(e => e.Id);

      builder.Property(e => e.EmployeeId).IsRequired();
      builder.Property(e => e.EventTypeId).IsRequired();
      builder.Property(e => e.EventDate).IsRequired();
    }
  }
}
