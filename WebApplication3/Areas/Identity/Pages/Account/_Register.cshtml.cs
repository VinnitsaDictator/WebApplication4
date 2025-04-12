using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models;

namespace WebApplication3.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public string ReturnUrl { get; set; } // Добавлено свойство ReturnUrl

        public class InputModel
        {
        

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "The password must be at least {2} characters long.", MinimumLength = 6)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm password is required.")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }
        }






        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
            Console.WriteLine("Custom Register.cshtml is being used");
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid");
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}, Errors: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
                }
                return Page();
            }

            var user = new User
            {
                UserName = Input.Email,
                Email = Input.Email,
                
            };

            var result = await _userManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                Console.WriteLine("User created successfully");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(ReturnUrl ?? "/");
            }

            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Error: {error.Description}");
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }



    }
}
