using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

public class ClientService
{
    public ObservableCollection<ClientModel> Clients { get; private set; }

    public ClientService()
    {
        Clients = new ObservableCollection<ClientModel>();
        LoadClients();
    }

    public async Task<List<ClientModel>> LoadClientsAsync()
    {
        return await Task.Run(() => LoadClients());
    }

    public void AddClient(ClientModel client)
    {
        Clients.Add(client);
        SaveClients();
    }

    public void EditClient(ClientModel client)
    {
        SaveClients();
    }

    public void DeleteClient(ClientModel client)
    {
        Clients.Remove(client);
        SaveClients();
    }

    private void SaveClients()
    {
        using (StreamWriter writer = new StreamWriter("clients.txt"))
        {
            foreach (var client in Clients)
            {
                writer.WriteLine($"{client.FullName};{client.Contact};{client.InteractionHistory};{client.ClientType}");
            }
        }
    }

    private List<ClientModel> LoadClients()
    {
        var clientList = new List<ClientModel>();
        if (File.Exists("clients.txt"))
        {
            using (StreamReader reader = new StreamReader("clients.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 4)
                    {
                        clientList.Add(new ClientModel
                        {
                            FullName = parts[0],
                            Contact = parts[1],
                            InteractionHistory = parts[2],
                            ClientType = parts[3]
                        });
                    }
                }
            }
        }
        return clientList;
    }
}