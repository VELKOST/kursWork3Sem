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

        public void RemoveClient(Client client)
        {
            clients.Remove(client);
            Console.WriteLine($"Клиент {client.Name} удален.");
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
    }
}
