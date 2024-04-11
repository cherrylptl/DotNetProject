using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    private readonly ILogger<LoginModel> _logger;
    public User? user;

    public LoginModel(ILogger<LoginModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnPost(User user)
    {
        Console.WriteLine("User Name: " + user.UserName);
        Console.WriteLine("Password: " + user.UserPassword);

        List<User> users = UserRepository.ReadUsersFromJson();
        foreach (var s in users)
        {
            Console.WriteLine($"User ID: {s.UserId}, Username: {s.UserName}, Password: {s.UserPassword}");
        }

        // User Authentication
        User? authenticatedUser = users.FirstOrDefault(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword);

        if (authenticatedUser != null)
        {
            // Authentication successful
            return RedirectToPage("Home");
        }
        else
        {
            // Authentication failed
            return RedirectToPage("LoginError", user);
        }
    }
}
