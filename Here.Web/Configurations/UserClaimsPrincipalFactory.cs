using Here.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Here.Web.Configurations
{
  public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
  {
    private readonly UserManager<ApplicationUser> _userManager;

    public UserClaimsPrincipalFactory(
        UserManager<ApplicationUser> userManager,
        IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
    {
      _userManager = userManager;
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
    {
      var identity = await base.GenerateClaimsAsync(user);

      var roles = await _userManager.GetRolesAsync(user);

      identity.AddClaim(new Claim(ClaimTypes.Uri, user.Image ?? string.Empty));
      identity.AddClaim(new Claim(ClaimTypes.Surname, string.Format("{0} {1}", user.Name, user.LastName)));
      identity.AddClaim(new Claim(ClaimTypes.Role, roles.FirstOrDefault().ToString()));

      return identity;
    }
  }
}
