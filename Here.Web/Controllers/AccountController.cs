using Here.Models.Domain;
using Here.Web.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Here.Web.Controllers
{
  [Authorize]
  public class AccountController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private List<AuthenticationScheme> ExternalLogins { get; set; }

    public AccountController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [AllowAnonymous]
    public IActionResult Login(string returnUrl = null)
    {
      if (User.Identity.IsAuthenticated)
      {
        return LocalRedirect("~/Home/Index");
      }

      ViewData["returnUrl"] = returnUrl;

      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
    {
      returnUrl ??= Url.Content("~/Home/Index");

      ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

      if (ModelState.IsValid)
      {
        // This doesn't count login failures towards account lockout
        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

        if (result.Succeeded)
        {

          return LocalRedirect(returnUrl);
        }
        if (result.RequiresTwoFactor)
        {
          return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        }
        if (result.IsLockedOut)
        {
          //_logger.LogWarning("User account locked out.");
          ModelState.AddModelError(string.Empty, "Account locked out. Please, contact the administrator.");
          return View(model);
        }
        else
        {
          ModelState.AddModelError(string.Empty, "Invalid login attempt.");
          return View(model);
        }
      }

      // If we got this far, something failed, redisplay form
      return View(model);
    }

    public async Task<IActionResult> Logout(string returnUrl = null)
    {
      await _signInManager.SignOutAsync();
      //_logger.LogInformation("User logged out.");
      if (returnUrl != null)
      {
        return LocalRedirect(returnUrl);
      }
      else
      {
        return LocalRedirect("~/Account/Login");
      }
    }
  }
}
