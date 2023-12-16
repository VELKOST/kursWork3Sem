using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya_work
{
    internal class Client
    {
        // Свойства клиента
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string SubscriptionType { get; set; }
        public int PersonalTrainings { get; set; }
        public int Massages { get; set; }
        public int Saunas { get; set; }

        // Конструктор
        public Client(string name, string contactInfo, string subscriptionType, int personalTrainings, int massages, int saunas)
        {
            Name = name;
            ContactInfo = contactInfo;
            SubscriptionType = subscriptionType;
            PersonalTrainings = personalTrainings;
            Massages = massages;
            Saunas = saunas;
        }
    }
}
