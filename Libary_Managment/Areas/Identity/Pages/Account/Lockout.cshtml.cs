using Microsoft.AspNetCore.Identity;
using Libary_Managment.Data;
using static Libary_Managment.Data.ApplicationDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc; // Adjust namespace for ApplicationUser

[AllowAnonymous]
public class LockoutModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    public LockoutModel(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(string returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        return LocalRedirect(returnUrl ?? Url.Content("~/Home/Index"));
    }
}
