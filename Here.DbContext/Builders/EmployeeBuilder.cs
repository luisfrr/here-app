using Here.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.DbContext.Builders
{
  public class EmployeeBuilder
  {
    public EmployeeBuilder(EntityTypeBuilder<Employee> builder)
    {
      builder.HasKey(employee => employee.Id);

      builder.Property(employee => employee.Code).IsRequired().HasMaxLength(15);
      builder.Property(employee => employee.Name).IsRequired().HasMaxLength(50);
      builder.Property(employee => employee.LastName).IsRequired().HasMaxLength(50);
      builder.Property(employee => employee.SecondLastName).IsRequired().HasMaxLength(50);
      builder.Property(employee => employee.CompanyId).IsRequired();

      builder.Property(employee => employee.Email).HasMaxLength(128);
      builder.Property(employee => employee.PersonalEmail).HasMaxLength(128);
      builder.Property(employee => employee.RFC).HasMaxLength(13);
      builder.Property(employee => employee.CURP).HasMaxLength(18);
      builder.Property(employee => employee.Imagen).HasMaxLength(256);
      builder.Property(employee => employee.QR).HasMaxLength(256);
    }
  }
}
