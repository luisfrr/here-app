using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.Models.DbHelpers
{
  public interface IAuditEntity
  {
    public string CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
  }
}
