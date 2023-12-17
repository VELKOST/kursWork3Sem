using System;
using System.Collections.Generic;
using kursovaya_work;

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
        for (int i = 1; i <= 10; i++)
        {
            Client client = new Client($"Клиент{i}", $"client{i}@mail.com", "Месячный", 2, 1, 0);
            clientManager.AddClient(client);
        }

        // Добавляем тренеров
        for (int i = 1; i <= 10; i++)
        {
            Trainer trainer = new Trainer($"Тренер{i}", $"trainer{i}@mail.com", "Йога");
            trainerManager.AddTrainer(trainer);
        }

        // Добавляем тренировочные сессии
        for (int i = 1; i <= 5; i++)
        {
            TrainingSession session = new TrainingSession(DateTime.Now, trainerManager.GetTrainer(i - 1), "Йога");
            scheduleManager.AddTrainingSession(session);
        }

        // Рассчитываем и сохраняем стоимость абонемента для каждого клиента
        foreach (var client in clientManager.GetClients())
        {
            subscriptionCalculator.CalculateAndStoreCost(clientManager.GetClients());
        }

        string userType;
        while (true) {
            Console.Clear();
            Console.WriteLine("Кто пользователь? admin || trainer ||client");
        userType = Console.ReadLine();
            if (userType == "admin" || userType == "trainer" || userType == "client")
                break;
        }
        string login = "";
        string password = "";

        while (true)
        {
            Console.WriteLine("Введите логин:");
            login = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            password = Console.ReadLine();

            if ((userType == "admin" && login == "admin" && password == "admin") ||
                (userType == "trainer" && login == "trainer" && password == "trainer") ||
                (userType == "client" && login == "client" && password == "client"))
            {
                break;
            }
            else
            {
                Console.WriteLine("Неверный логин или пароль. Попробуйте еще раз или введите 'exit' для возврата к выбору пользователя.");
                string command = Console.ReadLine();
                if (command == "exit")
                {
                    return;
                }
            }
        }


        // Выводим списки в зависимости от типа пользователя
        switch (userType)
        {
            case "admin":
                while (true)
                {
                    Console.WriteLine("Введите команду (add/remove/display/exit):");
                    string command = Console.ReadLine();

                    switch (command)
                    {
                        case "add":
                            Console.WriteLine("Что вы хотите добавить? (client/trainer/session)");
                            string addItem = Console.ReadLine();

                            switch (addItem)
                            {
                                case "client":
                                    // Добавляем клиента
                                    Console.WriteLine("Введите имя клиента:");
                                    string clientName = Console.ReadLine();
                                    Console.WriteLine("Введите контактную информацию клиента:");
                                    string clientContactInfo = Console.ReadLine();
                                    Console.WriteLine("Введите тип абонемента клиента(Месячный/Годовой/Разовый):");
                                    string clientSubscriptionType = Console.ReadLine();
                                    Console.WriteLine("Введите количество персональных тренировок клиента:");
                                    int clientPersonalTrainings = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите количество массажей клиента:");
                                    int clientMassages = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите количество посещений сауны клиента:");
                                    int clientSaunas = int.Parse(Console.ReadLine());

                                    Client newClient = new Client(clientName, clientContactInfo, clientSubscriptionType, clientPersonalTrainings, clientMassages, clientSaunas);
                                    clientManager.AddClient(newClient);
                                    Console.Clear();
                                    break;
                                case "trainer":
                                    // Добавляем тренера
                                    Console.WriteLine("Введите имя тренера:");
                                    string trainerName = Console.ReadLine();
                                    Console.WriteLine("Введите контактную информацию тренера:");
                                    string trainerContactInfo = Console.ReadLine();
                                    Console.WriteLine("Введите специализацию тренера:");
                                    string trainerSpecialization = Console.ReadLine();

                                    Trainer newTrainer = new Trainer(trainerName, trainerContactInfo, trainerSpecialization);
                                    trainerManager.AddTrainer(newTrainer);
                                    Console.Clear();
                                    break;
                                case "session":
                                    // Добавляем тренировку
                                    Console.WriteLine("Введите дату и время тренировки (формат: гггг-мм-дд чч:мм):");
                                    DateTime sessionDateTime = DateTime.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите индекс тренера для тренировки:");
                                    int trainerIndex = int.Parse(Console.ReadLine());
                                    Trainer sessionTrainer = trainerManager.GetTrainer(trainerIndex);
                                    Console.WriteLine("Введите тип тренировки:");
                                    string sessionType = Console.ReadLine();

                                    TrainingSession newSession = new TrainingSession(sessionDateTime, sessionTrainer, sessionType);
                                    scheduleManager.AddTrainingSession(newSession);
                                    Console.Clear();
                                    break;
                            }
                            break;
                        case "remove":
                            Console.WriteLine("Что вы хотите удалить? (client/trainer/session)");
                            string removeItem = Console.ReadLine();

                            switch (removeItem)
                            {
                                case "client":
                                    // Удаляем клиента
                                    Console.WriteLine("Введите имя клиента, которого хотите удалить:");
                                    string clientName = Console.ReadLine();
                                    clientManager.RemoveClient(clientName);
                                    Console.Clear();
                                    break;
                                case "trainer":
                                    // Удаляем тренера
                                    Console.WriteLine("Введите имя тренера, которого хотите удалить:");
                                    string trainerName = Console.ReadLine();
                                    trainerManager.RemoveTrainer(trainerName);
                                    Console.Clear();
                                    break;
                                case "session":
                                    // Удаляем тренировку
                                    Console.WriteLine("Введите индекс тренировки, которую хотите удалить:");
                                    int sessionIndex = int.Parse(Console.ReadLine());
                                    TrainingSession sessionToRemove = scheduleManager.GetSession(sessionIndex);
                                    scheduleManager.RemoveTrainingSession(sessionToRemove);
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Неизвестная команда.");
                                    break;
                            }
                            break;
                        case "display":
                            // Отображаем информацию
                            trainerManager.DisplayTrainers();
                            clientManager.DisplayClients();
                            scheduleManager.DisplaySchedule();
                            subscriptionCalculator.CalculateAndStoreCost(clientManager.GetClients());
                            subscriptionCalculator.DisplayCosts();
                            break;
                        case "exit":
                            return;
                        default:
                            Console.WriteLine("Неизвестная команда.");
                            break;
                    }
                }

                break;
            case "client":
                trainerManager.DisplayTrainers();
                scheduleManager.DisplaySchedule();
                break;
            case "trainer":
                scheduleManager.DisplaySchedule();
                clientManager.DisplayClients();
                break;
            default:
                Console.WriteLine("Некорректный пользователь");
                break;
        }
    }
}
