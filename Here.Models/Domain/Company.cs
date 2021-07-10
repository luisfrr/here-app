
using Here.Models.DbHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.Models.Domain
{
  public class Company : ISoftDeleted, IAuditEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string BusinessName { get; set; }
    public string Activity { get; set; }
    public string RFC { get; set; }
    public string Street { get; set; }
    public string InteriorNumber { get; set; }
    public string OutdoorNumber { get; set; }
    public int? PostalCode { get; set; }
    public string Location { get; set; }
    public int? StateId { get; set; }
    public int? CountryId { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Url { get; set; }
    public string Image { get; set; }
    public string LegalAgent { get; set; }
    public string AgentPhone { get; set; }
    public string AgentEmail { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
  }
}
