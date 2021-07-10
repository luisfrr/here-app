using Here.Models.DbHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.Models.Domain
{
  public class Event : ISoftDeleted, IAuditEntity
  {
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public int EventTypeId { get; set; }
    public DateTime EventDate { get; set; }
    public DateTime? StartShift { get; set; }
    public DateTime? EndShift { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
  }
}
