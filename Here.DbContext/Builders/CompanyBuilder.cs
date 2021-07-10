using Here.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.DbContext.Builders
{
  public class CompanyBuilder
  {
    public CompanyBuilder(EntityTypeBuilder<Company> builder)
    {
      builder.HasKey(company => company.Id);

      builder.Property(company => company.Name).IsRequired().HasMaxLength(128);
      builder.Property(company => company.LegalAgent).IsRequired().HasMaxLength(128);
      builder.Property(company => company.AgentPhone).IsRequired().HasMaxLength(50);
      builder.Property(company => company.AgentEmail).IsRequired().HasMaxLength(50);

      builder.Property(company => company.Activity).HasMaxLength(128);
      builder.Property(company => company.RFC).HasMaxLength(128);
      builder.Property(company => company.Street).HasMaxLength(128);
      builder.Property(company => company.InteriorNumber).HasMaxLength(128);
      builder.Property(company => company.Location).HasMaxLength(128);
      builder.Property(company => company.Phone).HasMaxLength(50);
      builder.Property(company => company.Email).HasMaxLength(50);
      builder.Property(company => company.Url).HasMaxLength(128);
      builder.Property(company => company.Image).HasMaxLength(256);
    }
  }
}
