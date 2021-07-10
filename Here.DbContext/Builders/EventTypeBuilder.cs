using Here.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.DbContext.Builders
{
  public class EventTypeBuilder
  {
    public EventTypeBuilder(EntityTypeBuilder<EventType> builder)
    {
      builder.HasKey(eventType => eventType.Id);

      builder.Property(eventType => eventType.Name).IsRequired().HasMaxLength(50);
    }
  }
}
