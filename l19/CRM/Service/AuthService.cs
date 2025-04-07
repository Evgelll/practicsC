using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CRM.Data;
using CRM.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace CRM.Services
{
    public class AuthService
    {
        private readonly CRMContext _context;

        public AuthService()
        {
            _context = new CRMContext();
            InitializeDatabase(); // Инициализация базы данных при создании экземпляра
        }

        private void InitializeDatabase()
        {
            Debug.WriteLine("Инициализация базы данных в AuthService...");
            _context.Database.EnsureCreated(); // Создаем базу данных и таблицы, если их нет

            // Проверяем, пуста ли таблица Users, и заполняем начальными данными
            if (!_context.Users.Any())
            {
                Debug.WriteLine("Таблица Users пуста, добавляем начальных пользователей...");
                _context.Users.Add(new UserModel { Username = "admin", Password = "admin123", Role = UserRole.Admin.ToString() });
                _context.Users.Add(new UserModel { Username = "manager", Password = "manager123", Role = UserRole.Manager.ToString() });
                _context.SaveChanges();
                Debug.WriteLine("Начальные пользователи добавлены в таблицу Users");
            }
            else
            {
                Debug.WriteLine("Таблица Users уже содержит данные");
            }
        }

        public async Task<ObservableCollection<UserModel>> LoadUsersAsync()
        {
            return new ObservableCollection<UserModel>(await _context.Users.ToListAsync());
        }

        public async Task<bool> RegisterUserAsync(string username, string password, UserRole role)
        {
            var users = await LoadUsersAsync();
            if (users.Any(u => u.Username == username))
            {
                return false;
            }

            _context.Users.Add(new UserModel { Username = username, Password = password, Role = role.ToString() });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserModel> AuthenticateUserAsync(string username, string password)
        {
            Debug.WriteLine($"Проверка пользователя: username={username}");
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Debug.WriteLine("Пользователь найден и пароль совпадает");
            }
            else
            {
                Debug.WriteLine("Пользователь не найден или пароль неверный");
            }
            return user;
        }
    }
}