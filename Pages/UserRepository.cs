using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class UserRepository
{
    private static readonly string JSON_FILE_PATH = "data/user.json";

    public static List<User> ReadUsersFromJson()
    {
        List<User> users = new List<User>();

        if (File.Exists(JSON_FILE_PATH))
        {
            string userText = File.ReadAllText(JSON_FILE_PATH);
            users = JsonConvert.DeserializeObject<List<User>>(userText)!;
        }

        return users;
    }
}
