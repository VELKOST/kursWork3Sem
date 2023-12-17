using System;
using System.Collections.Generic;
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
            Console.WriteLine($"Клиент {client.Name} добавлен.");
        }

        public void RemoveClient(string name)
        {
            var client = clients.FirstOrDefault(c => c.Name == name);
            if (client != null)
            {
                clients.Remove(client);
                Console.WriteLine($"Клиент {client.Name} удален.");
            }
            else
            {
                Console.WriteLine("Ошибка: клиент с таким именем не найден.");
            }
        }

        public void DisplayClients()
        {
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
                Console.WriteLine("Ошибка: индекс вне диапазона.");
                return null;
            }
        }
    }
}
