using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    public string? ReturnUrl { get; set; }

    public void OnGet(string? returnUrl)
    {
        ReturnUrl = returnUrl;
    }

    public IActionResult OnPost(string? returnUrl)
    {
        // Authentication will be implemented later.

        return Redirect(
            returnUrl ?? "http://localhost:5173");
    }
}
