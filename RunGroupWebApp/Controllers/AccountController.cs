using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.ViewModels;

namespace RunGroupWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginviewmodel)
        {
            if (!ModelState.IsValid) return View(loginviewmodel);
            var user = await _userManager.FindByEmailAsync(loginviewmodel.EmailAddress);
            if (user != null)
            {
                //user is found, check password
                var passwordCheck= await _userManager.CheckPasswordAsync(user,loginviewmodel.Password);
                if (passwordCheck)
                {
                    //password is correct, sign in 
                    var result= await _signInManager.PasswordSignInAsync(user, loginviewmodel.Password,false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Race");
                    }
                }
                //password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginviewmodel);
            }
            //user not found
            TempData["Error"] = "Wrong credentials, Try Again";
            return View(loginviewmodel);
        }
    }
}
