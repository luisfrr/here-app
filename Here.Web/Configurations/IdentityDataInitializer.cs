using Here.Common.Extensions;
using Here.Common.Shared;
using Here.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Here.Web.Configurations
{
  public static class IdentityDataInitializer
  {

    public static void SeedDefaultUser(UserManager<ApplicationUser> userManager,
      RoleManager<ApplicationRole> roleManager)
    {
      if (roleManager
        .RoleExistsAsync(EnumsExtension.GetDescription(Roles.SUPERUSER))
        .Result)
      {

        if(userManager.FindByEmailAsync("").Result == null)
        {
          string username = Environment.GetEnvironmentVariable("HEREAPP_OVERWATCH_USER");
          string password = Environment.GetEnvironmentVariable("HEREAPP_OVERWATCH_PASS");

          if (string.IsNullOrEmpty(username))
            throw new Exception("No se ha encontrado la variable de entorno: HEREAPP_OVERWATCH_USER");

          if (string.IsNullOrEmpty(password))
            throw new Exception("No se ha encontrado la variable de entorno: HEREAPP_OVERWATCH_PASS");


          ApplicationUser user = new ApplicationUser()
          {
            Name = "Luis",
            LastName = "Rogel",
            UserName = username,
            Email = username,
            EmailConfirmed = true,
            Image = "https://res.cloudinary.com/lfrr/image/upload/v1537596250/IMG_20180613_093848_347.jpg",
            PhoneNumber = string.Empty,
            IsDeleted = false,
            CreatedBy = "IdentityDataInitializer"
          };

          IdentityResult result = userManager.CreateAsync(user, password).Result;

          if (result.Succeeded)
            userManager.AddToRoleAsync(user, EnumsExtension.GetDescription(Roles.SUPERUSER)).Wait();

        }
      }
    }

  }
}
