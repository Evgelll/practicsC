using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using CRM.Models;
using Newtonsoft.Json;

namespace CRM.Services
{
    public class AuthService
    {
        private const string UsersFilePath = "users.json";

        public async Task<ObservableCollection<UserModel>> LoadUsersAsync()
        {
            if (File.Exists(UsersFilePath))
            {
                string json = await File.ReadAllTextAsync(UsersFilePath);
                return JsonConvert.DeserializeObject<ObservableCollection<UserModel>>(json);
            }

            // Если файла нет, создаем начальных пользователей
            var initialUsers = new ObservableCollection<UserModel>
            {
                new UserModel { Username = "admin", Password = "admin123", Role = UserRole.Admin.ToString() },
                new UserModel { Username = "manager", Password = "manager123", Role = UserRole.Manager.ToString() }
            };
            await SaveUsersAsync(initialUsers);
            return initialUsers;
        }

        public async Task<bool> RegisterUserAsync(string username, string password, UserRole role)
        {
            var users = await LoadUsersAsync();
            if (users.Any(u => u.Username == username))
            {
                return false; 
            }

            users.Add(new UserModel { Username = username, Password = password, Role = role.ToString() });
            await SaveUsersAsync(users);
            return true;
        }

        public async Task<UserModel> AuthenticateUserAsync(string username, string password)
        {
            var users = await LoadUsersAsync();
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        private async Task SaveUsersAsync(ObservableCollection<UserModel> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            await File.WriteAllTextAsync(UsersFilePath, json);
        }
    }
}