using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class ClientService
{
    private NamedPipeServer _pipeServer;
    public ObservableCollection<ClientModel> Clients { get; private set; }
    private const string DataFilePath = "crm_data.json";

    public ClientService()
    {
        _pipeServer = new NamedPipeServer();
        Clients = new ObservableCollection<ClientModel>();
        LoadData();
    }

    public async Task LoadClientsAsync()
    {
        var data = await Task.Run(() => LoadData());
        if (data != null)
        {
            foreach (var client in data.Clients)
            {
                Clients.Add(client);
            }
        }
    }

    public void AddClient(ClientModel client)
    {
        Clients.Add(client);
        Task.Run(async () =>
        {
            await _pipeServer.SendMessageAsync($"Новый клиент: {client.FullName}");
        });
        SaveData();
    }

    public void EditClient(ClientModel client)
    {
        SaveData(); // Обновление данных после редактирования
    }

    public void DeleteClient(ClientModel client)
    {
        Clients.Remove(client);
        SaveData();
    }

    private void SaveData()
    {
        var data = new
        {
            Clients = Clients
        };
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(DataFilePath, json);
    }

    private DataModel LoadData()
    {
        if (File.Exists(DataFilePath))
        {
            var json = File.ReadAllText(DataFilePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new DataModel { Clients = new List<ClientModel>() };
            }

            try
            {
                return JsonSerializer.Deserialize<DataModel>(json);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Ошибка десериализации: {ex.Message}");
                return new DataModel { Clients = new List<ClientModel>() };
            }
        }
        return new DataModel { Clients = new List<ClientModel>() };
    }
}

public class DataModel
{
    public List<ClientModel> Clients { get; set; }
    public List<DealModel> Deals { get; set; }
    public List<ContactModel> Contacts { get; set; }
}

public class ContactModel
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}

public class DealModel
{
    public string DealDetails { get; set; }
    public DateTime DealDate { get; set; }
    public ContactModel Contact { get; set; }
}