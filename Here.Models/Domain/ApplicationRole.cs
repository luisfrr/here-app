using Here.Models.DbHelpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.Models.Domain
{
  public class ApplicationRole : IdentityRole, ISoftDeleted, IAuditEntity
  {
    public string Description { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
  }
}
