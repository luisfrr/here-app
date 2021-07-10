using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.Models.DbHelpers
{
  public interface ISoftDeleted
  {
    public bool IsDeleted { get; set; }
  }
}
