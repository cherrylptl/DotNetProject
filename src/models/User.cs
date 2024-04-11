using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class User
{

    public User(int userId, string userName, string userpassword)
    {
        this.UserId = userId;
        this.UserName = userName;
        this.UserPassword = userpassword;

    }
    public User()
    {
    }

    public required int UserId { get; set; }

    [Required(ErrorMessage = "User name is required"), StringLength(50, MinimumLength = 3, ErrorMessage = "User name has to be minimum 3 letters to maximum 20 letters")]

    public required string UserName { get; set; }

    [Required(ErrorMessage = "Phone number is required"), StringLength(50, MinimumLength = 3, ErrorMessage = "Password has to be minimum 3 letters to maximum 20 letters")]

    public required string UserPassword { get; set; }

}
