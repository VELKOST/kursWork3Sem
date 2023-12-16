using System;
using System.Collections.Generic;
using kursovaya_work;

// Класс Client
/*public class Client
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
*/

// Класс Trainer
/*public class Trainer
{
    // Свойства тренера
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public string Specialization { get; set; }

    // Конструктор
    public Trainer(string name, string contactInfo, string specialization)
    {
        Name = name;
        ContactInfo = contactInfo;
        Specialization = specialization;
    }
}*/

// Класс TrainingSession
/*public class TrainingSession
{
    // Свойства тренировочной сессии
    public DateTime DateAndTime { get; set; }
    public Trainer Trainer { get; set; }
    public string TrainingType { get; set; }

    // Конструктор
    public TrainingSession(DateTime dateAndTime, Trainer trainer, string trainingType)
    {
        DateAndTime = dateAndTime;
        Trainer = trainer;
        TrainingType = trainingType;
    }
}*/

// Класс для управления списком клиентов
/*public class ClientManager
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
}*/

// Класс для управления списком тренеров
/*public class TrainerManager
{
    private List<Trainer> trainers = new List<Trainer>();

    public void AddTrainer(Trainer trainer)
    {
        trainers.Add(trainer);
        Console.WriteLine($"Тренер {trainer.Name} добавлен.");
    }

    public void RemoveTrainer(Trainer trainer)
    {
        trainers.Remove(trainer);
        Console.WriteLine($"Тренер {trainer.Name} удален.");
    }

    public void DisplayTrainers()
    {
        Console.WriteLine("\nСписок тренеров:");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        foreach (var trainer in trainers)
        {
            Console.WriteLine($"Имя: {trainer.Name}, Контактная информация: {trainer.ContactInfo}, Специализация: {trainer.Specialization}");
        }
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
    }
}*/

// Класс для управления расписанием тренировок
/*public class ScheduleManager
{
    private List<TrainingSession> schedule = new List<TrainingSession>();

    public void AddTrainingSession(TrainingSession session)
    {
        schedule.Add(session);
        Console.WriteLine($"Тренировка {session.TrainingType} добавлена в расписание.");
    }

    public void RemoveTrainingSession(TrainingSession session)
    {
        schedule.Remove(session);
        Console.WriteLine($"Тренировка {session.TrainingType} удалена из расписания.");
    }

    public void DisplaySchedule()
    {
        Console.WriteLine("\nРасписание тренировок:");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        foreach (var session in schedule)
        {
            Console.WriteLine($"Дата и время: {session.DateAndTime}, Тренер: {session.Trainer.Name}, Тип тренировки: {session.TrainingType}");
        }
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
    }
}*/

// Класс для расчета стоимости абонемента
/*public class SubscriptionCalculator
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

    public void CalculateAndStoreCost(Client client)
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
}*/



class Program
{
    static void Main()
    {

            // Создаем менеджеров
            ClientManager clientManager = new ClientManager();
            TrainerManager trainerManager = new TrainerManager();
            ScheduleManager scheduleManager = new ScheduleManager();
            SubscriptionCalculator subscriptionCalculator = new SubscriptionCalculator();

            // Добавляем клиентов
            Client client1 = new Client("Иван", "ivan@mail.com", "Месячный", 2, 1, 0);
            Client client2 = new Client("Мария", "maria@mail.com", "Годовой", 0, 0, 3);
            clientManager.AddClient(client1);
            clientManager.AddClient(client2);

            // Добавляем тренеров
            Trainer trainer1 = new Trainer("Алексей", "alexey@mail.com", "Йога");
            Trainer trainer2 = new Trainer("Елена", "elena@mail.com", "Пилатес");
            trainerManager.AddTrainer(trainer1);
            trainerManager.AddTrainer(trainer2);

            // Добавляем тренировочные сессии
            TrainingSession session1 = new TrainingSession(DateTime.Now, trainer1, "Йога");
            TrainingSession session2 = new TrainingSession(DateTime.Now, trainer2, "Пилатес");
            scheduleManager.AddTrainingSession(session1);
            scheduleManager.AddTrainingSession(session2);

            // Выводим списки тренеров, клиентов и тренировок
            trainerManager.DisplayTrainers();
            clientManager.DisplayClients();
            scheduleManager.DisplaySchedule();

            // Рассчитываем и сохраняем стоимость абонемента для каждого клиента
            subscriptionCalculator.CalculateAndStoreCost(client1);
            subscriptionCalculator.CalculateAndStoreCost(client2);

            // Расчитываем и выводим стоимость абонемента
            subscriptionCalculator.DisplayCosts();

    }
}

/*описание классов и методов, используемых в приложении для управления фитнес-клубом:

Client: Этот класс представляет клиента фитнес-клуба. Он содержит свойства Name (имя), ContactInfo (контактная информация),
SubscriptionType (тип абонемента), PersonalTrainings (количество персональных тренировок), Massages (количество массажей) и Saunas (количество посещений сауны).

Trainer: Этот класс представляет тренера в фитнес-клубе. Он содержит свойства Name (имя), ContactInfo (контактная информация) и Specialization (специализация).

TrainingSession: Этот класс представляет тренировочную сессию. Он содержит свойства DateAndTime (дата и время), Trainer (тренер) и TrainingType (тип тренировки).

ClientManager: Этот класс управляет списком клиентов. Он содержит методы AddClient (добавить клиента), RemoveClient (удалить клиента) и DisplayClients (показать клиентов).

TrainerManager: Этот класс управляет списком тренеров. Он содержит методы AddTrainer (добавить тренера), RemoveTrainer (удалить тренера) и DisplayTrainers (показать тренеров).

ScheduleManager: Этот класс управляет расписанием тренировок. Он содержит методы AddTrainingSession (добавить тренировочную сессию),
RemoveTrainingSession (удалить тренировочную сессию) и DisplaySchedule (показать расписание).

SubscriptionCalculator: Этот класс расчитывает стоимость абонемента. Он содержит метод CalculateAndStoreCost, который принимает клиента и рассчитывает стоимость его абонемента,
а затем сохраняет эту информацию. Метод DisplayCosts выводит стоимость абонемента для каждого клиента.
*/
