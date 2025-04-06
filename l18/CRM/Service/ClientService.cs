using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CRM.Models;
using Newtonsoft.Json;
using System.IO;

namespace CRM.Services
{
    public class ClientService
    {
        private const string DataFilePath = "crm_data.json";

        public async Task<ObservableCollection<ClientModel>> LoadClientsAsync()
        {
            if (File.Exists(DataFilePath))
            {
                string json = await File.ReadAllTextAsync(DataFilePath);
                var data = JsonConvert.DeserializeObject<CRMData>(json);
                return new ObservableCollection<ClientModel>(data.Clients);
            }

            var initialClients = new ObservableCollection<ClientModel>
            {
                new ClientModel { FullName = "Иван Иванов", PhoneNumber = "+375441234567", Email = "ivan@example.com", ClientType = "Физическое лицо" },
                new ClientModel { FullName = "Мария Петрова", PhoneNumber = "+375447654321", Email = "maria@example.com", ClientType = "VIP" }
            };
            await SaveDataAsync(new CRMData { Clients = initialClients, Orders = new ObservableCollection<OrderModel>() });
            return initialClients;
        }

        public void AddClient(ObservableCollection<ClientModel> clients, ClientModel client)
        {
            clients.Add(client);
            SaveClientsAsync(clients);
        }

        public void UpdateClient(ClientModel original, ClientModel updated)
        {
            original.FullName = updated.FullName;
            original.PhoneNumber = updated.PhoneNumber;
            original.Email = updated.Email;
            original.ClientType = updated.ClientType;
            SaveClientsAsync(new ObservableCollection<ClientModel> { original }); // Сохранение всех клиентов
        }

        public void DeleteClient(ObservableCollection<ClientModel> clients, ClientModel client)
        {
            clients.Remove(client);
            SaveClientsAsync(clients);
        }

        private async void SaveClientsAsync(ObservableCollection<ClientModel> clients)
        {
            var data = new CRMData
            {
                Clients = clients,
                Orders = new ObservableCollection<OrderModel>() // Пока заказы не обновляем
            };
            await SaveDataAsync(data);
        }

        private async Task SaveDataAsync(CRMData data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            await File.WriteAllTextAsync(DataFilePath, json);
        }
    }

    // Класс для структуры данных в JSON
    public class CRMData
    {
        public ObservableCollection<ClientModel> Clients { get; set; }
        public ObservableCollection<OrderModel> Orders { get; set; }
    }
}