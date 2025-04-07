using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CRM.Data;
using CRM.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace CRM.Services
{
    public class ClientRepository
    {
        private readonly CRMContext _context;

        public ClientRepository()
        {
            _context = new CRMContext();
            InitializeDatabase(); // Инициализация базы данных при создании экземпляра
        }

        private void InitializeDatabase()
        {
            Debug.WriteLine("Инициализация базы данных в ClientRepository...");
            _context.Database.EnsureCreated(); // Создаем базу данных и таблицы, если их нет

            // Проверяем, пуста ли таблица Clients, и заполняем начальными данными
            if (!_context.Clients.Any())
            {
                Debug.WriteLine("Таблица Clients пуста, добавляем начальных клиентов...");
                _context.Clients.Add(new ClientModel { FullName = "Иван Иванов", PhoneNumber = "+375441234567", Email = "ivan@example.com", ClientType = "Физическое лицо" });
                _context.Clients.Add(new ClientModel { FullName = "Мария Петрова", PhoneNumber = "+375447654321", Email = "maria@example.com", ClientType = "VIP" });
                _context.SaveChanges();
                Debug.WriteLine("Начальные клиенты добавлены в таблицу Clients");
            }
            else
            {
                Debug.WriteLine("Таблица Clients уже содержит данные");
            }
        }

        public async Task<ObservableCollection<ClientModel>> GetAllClientsAsync()
        {
            var clients = await _context.Clients.ToListAsync();
            return new ObservableCollection<ClientModel>(clients);
        }

        public async Task AddClientAsync(ClientModel client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(ClientModel client)
        {
            var existingClient = await _context.Clients.FindAsync(client.FullName);
            if (existingClient != null)
            {
                existingClient.FullName = client.FullName;
                existingClient.PhoneNumber = client.PhoneNumber;
                existingClient.Email = client.Email;
                existingClient.ClientType = client.ClientType;
                existingClient.InteractionHistory = client.InteractionHistory;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteClientAsync(ClientModel client)
        {
            var existingClient = await _context.Clients.FindAsync(client.FullName);
            if (existingClient != null)
            {
                _context.Clients.Remove(existingClient);
                await _context.SaveChangesAsync();
            }
        }
    }
}