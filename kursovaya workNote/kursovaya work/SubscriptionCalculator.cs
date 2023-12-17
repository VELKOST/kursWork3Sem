using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya_work
{
    internal class SubscriptionCalculator
    {
        // Цены на услуги и абонементы
        private double baseCostMonthly = 2000; // стоимость месячного абонемента
        private double baseCostAnnual = 20000; // стоимость годового абонемента
        private double baseCostSingle = 500; // стоимость разового посещения
        private double personalTrainingCost = 500; // стоимость персональной тренировки
        private double massageCost = 300; // стоимость массажа
        private double saunaCost = 400; // стоимость сауны

        // Список для хранения клиентов и стоимости их абонементов
        private List<Tuple<Client, double>> clientCosts = new List<Tuple<Client, double>>();

        public void CalculateAndStoreCost(List<Client> clients)
        {
            // Очищаем текущий список стоимостей
            clientCosts.Clear();

            foreach (var client in clients)
            {
                double totalCost = 0;

                // Учитываем стоимость абонемента
                switch (client.SubscriptionType)
                {
                    case "Месячный":
                        totalCost += baseCostMonthly;
                        break;
                    case "Годовой":
                        totalCost += baseCostAnnual;
                        break;
                    case "Разовый":
                        totalCost += baseCostSingle;
                        break;
                }

                // Учитываем стоимость дополнительных услуг
                totalCost += client.PersonalTrainings * personalTrainingCost;
                totalCost += client.Massages * massageCost;
                totalCost += client.Saunas * saunaCost;

                // Добавляем клиента и стоимость его абонемента в список
                clientCosts.Add(new Tuple<Client, double>(client, totalCost));
            }
        }

        public void DisplayCosts()
        {
            Console.WriteLine("\nСтоимость абонементов:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var clientCost in clientCosts)
            {
                Console.WriteLine($"Клиент: {clientCost.Item1.Name}, Стоимость абонемента: {clientCost.Item2}");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        }
    }
}
