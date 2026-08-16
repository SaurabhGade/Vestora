using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vestora.BO.Users;
using Vestora.DTO.Users;

namespace Vestora.Auth.Pages;

public class RegisterModel : PageModel
{
    private readonly IUserBO _userBO;

    public RegisterModel(IUserBO userBO)
    {
        _userBO = userBO;
    }

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [BindProperty]
    public string? MiddleName { get; set; }

    [BindProperty]
    [Required]
    public string LastName { get; set; } = string.Empty;

    [BindProperty]
    public string? PhoneNumber { get; set; }

    [BindProperty]
    public DateOnly? DateOfBirth { get; set; }

    public IActionResult OnGet()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return Redirect("http://localhost:5173/");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var request = new RegisterRequestDTO
        {
            Email = Email,
            Password = Password,
            FirstName = FirstName,
            MiddleName = MiddleName,
            LastName = LastName,
            PhoneNumber = PhoneNumber,
            DateOfBirth = DateOfBirth
        };

        var result = await _userBO.RegisterAsync(
            request,
            cancellationToken);

        if (!result.Success)
        {
            ModelState.AddModelError(
                string.Empty,
                result.Message);

            return Page();
        }

        return Redirect(
            $"/Login?registered=true");
    }
}