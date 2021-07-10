using Here.Models.DbHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.Models.Domain
{
  public class Rule : ISoftDeleted, IAuditEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public int ShiftId { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
  }
}
