using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace z1;
public class UserService
{
    private const string UsersFilePath = "users.json";
    public List<UserModel> Users { get; private set; }

    public UserService()
    {
        Users = LoadUsers();
    }

    public void Register(string username, string password, string role)
    {
        var hashedPassword = HashPassword(password);
        var user = new UserModel { Username = username, Password = hashedPassword, Role = role };
        Users.Add(user);
        SaveUsers();
    }

    public bool Authenticate(string username, string password, out string role)
    {
        var hashedPassword = HashPassword(password);
        var user = Users.Find(u => u.Username == username && u.Password == hashedPassword);
        role = user?.Role; // Вернет null, если пользователь не найден
        return user != null;
    }

    private List<UserModel> LoadUsers()
    {
        if (File.Exists(UsersFilePath))
        {
            var json = File.ReadAllText(UsersFilePath);
            return JsonSerializer.Deserialize<UserDataModel>(json)?.Users ?? new List<UserModel>();
        }
        return new List<UserModel>();
    }

    private void SaveUsers()
    {
        var data = new UserDataModel { Users = Users };
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(UsersFilePath, json);
    }

    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}

public class UserDataModel
{
    public List<UserModel> Users { get; set; }
}