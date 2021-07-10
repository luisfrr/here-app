using Here.Models.DbHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.Models.Domain
{
  public class Employee : ISoftDeleted, IAuditEntity
  {
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string SecondLastName { get; set; }
    public string Phone { get; set; }
    public string SecondPhone { get; set; }
    public string Email { get; set; }
    public string PersonalEmail { get; set; }
    public string RFC { get; set; }
    public string CURP { get; set; }
    public string Imagen { get; set; }
    public string QR { get; set; }
    public int ShiftId { get; set; }
    public int CompanyId { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
  }
}
