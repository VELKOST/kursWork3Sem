using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya_work
{
    internal class ClientManager
    {
        private List<Client> clients = new List<Client>();

        public void AddClient(Client client)
        {
            clients.Add(client);
            SaveClientsToFile();
        }

        public void RemoveClient(string name)
        {
            var client = clients.FirstOrDefault(c => c.Name == name);
            if (client != null)
            {
                clients.Remove(client);
                SaveClientsToFile();
            }
          
        }

        public void DisplayClients()
        {
            LoadClientsFromFile();
            Console.WriteLine("\nСписок клиентов:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var client in clients)
            {
                Console.WriteLine($"Имя: {client.Name}, Контактная информация: {client.ContactInfo}, Тип абонемента: {client.SubscriptionType}");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        }

        public List<Client> GetClients()
        {
            return clients;
        }

        public Client GetClient(int index)
        {
            if (index >= 0 && index < clients.Count)
            {
                return clients[index];
            }
            else
            {
                return null;
            }
        }

        private void SaveClientsToFile()
        {
            using (StreamWriter writer = new StreamWriter("clients.txt"))
            {
                foreach (var client in clients)
                {
                    writer.WriteLine($"{client.Name},{client.ContactInfo},{client.SubscriptionType},{client.PersonalTrainings},{client.Massages},{client.Saunas}");
                }
            }
        }

        private void LoadClientsFromFile()
        {
            clients.Clear();
            using (StreamReader reader = new StreamReader("clients.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    string contactInfo = parts[1];
                    string subscriptionType = parts[2];
                    int personalTrainings = int.Parse(parts[3]);
                    int massages = int.Parse(parts[4]);
                    int saunas = int.Parse(parts[5]);

                    Client client = new Client(name, contactInfo, subscriptionType, personalTrainings, massages, saunas);
                    clients.Add(client);
                }
            }
        }
    }
}
