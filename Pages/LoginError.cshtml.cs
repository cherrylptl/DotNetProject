using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginErrorModel : PageModel
{
    public List<String> errors { get; set; } = new List<String>();
    public User? user;

    private readonly ILogger<LoginErrorModel> _logger;

    public LoginErrorModel(ILogger<LoginErrorModel> logger)
    {
        _logger = logger;
    }


    public void OnGet(User user)

    {
        // user = _user;
        if (user.UserName.Length < 3)
        {
            errors.Add("User name has to be minimum 3 letters");
        }
        if (user.UserPassword.Length < 3)
        {
            errors.Add("Password has to be minimum 3 letters");
        }
        else
        {
            errors.Add("Invalid User Name or Password");
        }

    }
}

