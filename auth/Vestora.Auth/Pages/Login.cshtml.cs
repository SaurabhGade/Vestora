using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vestora.Auth.Pages;

public class LoginModel : PageModel
{
    /// <summary>
    /// Author: Saurabh Gade
    /// Date: Aug 16 2026
    /// Initial Cookie-based Authentication setup
    /// </summary>

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; set; }
    private readonly IConfiguration m_objIConfiguration;
    private readonly ILogger<LoginModel> m_objILogger; // 1. Add the logger variable
    public LoginModel(IConfiguration i_objIConfiguration, ILogger<LoginModel> i_objILogger)
    {
        m_objIConfiguration = i_objIConfiguration;
        m_objILogger = i_objILogger;
    }
    public IActionResult OnGet()
    {
        m_objILogger.LogInformation("Checking if the user already has a valid cookie");

        if (User.Identity?.IsAuthenticated == true)
        {
            string? sPath = m_objIConfiguration["RedirectURL:RedirectToUI"];

            if (string.IsNullOrEmpty(sPath))
            {
                m_objILogger.LogWarning("RedirectToUI is missing from appsettings. Defaulting to '/'");
                sPath = "/"; // Assign the default fallback
            }

            // Using structured logging {RedirectPath}
            m_objILogger.LogInformation("User is authenticated. Redirecting to: {RedirectPath}", sPath);

            return Redirect(sPath);
        }

        // If not authenticated, render the Login.cshtml HTML
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        m_objILogger.LogInformation("========== LOGIN POST ==========");
        m_objILogger.LogInformation("Email: {Email}", Email);
        m_objILogger.LogInformation("Password supplied: {Password}", !string.IsNullOrEmpty(Password));

        if (!ModelState.IsValid)
        {
            m_objILogger.LogInformation("ModelState is INVALID");

            foreach (var error in ModelState.Values
                         .SelectMany(v => v.Errors))
            {
                m_objILogger.LogInformation("ERROR: {error.ErrorMessage}", error.ErrorMessage);
            }

            return Page();
        }

        m_objILogger.LogInformation("ModelState is VALID");

        var validEmail =
            Email.Equals(
                "admin@vestora.com",
                StringComparison.OrdinalIgnoreCase);

        var validPassword =
            Password == "2026@Admin";

        m_objILogger.LogInformation($"Email valid: {validEmail}");
        m_objILogger.LogInformation($"Password valid: {validPassword}");

        if (!validEmail || !validPassword)
        {
            ModelState.AddModelError(
                string.Empty,
                "Invalid email or password.");

            return Page();
        }

        m_objILogger.LogInformation("Credentials valid.");

        var claims = new List<Claim>
    {
        new(
            ClaimTypes.NameIdentifier,
            "1"),

        new(
            ClaimTypes.Name,
            Email),

        new(
            ClaimTypes.Email,
            Email)
    };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);

        var authenticationProperties =
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc =
                    DateTimeOffset.UtcNow.AddHours(8)
            };

        m_objILogger.LogInformation("Attempting SignInAsync...");

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            authenticationProperties);

        m_objILogger.LogInformation("SignInAsync successful.");
        string? sPath = m_objIConfiguration["RedirectURL:RedirectToUI"];
        return Redirect(sPath ?? "/");
    }

}