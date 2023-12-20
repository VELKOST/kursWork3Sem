using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya_work
{
    internal class ScheduleManager
    {
        private List<TrainingSession> schedule = new List<TrainingSession>();

        public void AddTrainingSession(TrainingSession session)
        {
            schedule.Add(session);
            Console.WriteLine($"Тренировка {session.TrainingType} добавлена в расписание.");
            SaveScheduleToFile();
        }

        public void RemoveTrainingSession(TrainingSession session)
        {
            schedule.Remove(session);
            Console.WriteLine($"Тренировка {session.TrainingType} удалена из расписания.");
            SaveScheduleToFile();
        }

        public void DisplaySchedule()
        {
            LoadScheduleFromFile();
            Console.WriteLine("\nРасписание тренировок:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var session in schedule)
            {
                Console.WriteLine($"Дата и время: {session.DateAndTime}, Тренер: {session.Trainer.Name}, Тип тренировки: {session.TrainingType}");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        }

        public TrainingSession GetSession(int index)
        {
            if (index >= 0 && index < schedule.Count)
            {
                return schedule[index];
            }
            else
            {
                Console.WriteLine("Ошибка: индекс вне диапазона.");
                return null;
            }
        }

        private void SaveScheduleToFile()
        {
            using (StreamWriter writer = new StreamWriter("schedule.txt"))
            {
                foreach (var session in schedule)
                {
                    writer.WriteLine($"{session.DateAndTime},{session.Trainer.Name},{session.TrainingType}");
                }
            }
        }

        private void LoadScheduleFromFile()
        {
            schedule.Clear();
            using (StreamReader reader = new StreamReader("schedule.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    DateTime dateAndTime = DateTime.Parse(parts[0]);
                    string trainerName = parts[1];
                    string trainingType = parts[2];

                    Trainer trainer = new Trainer(trainerName, "", "");
                    TrainingSession session = new TrainingSession(dateAndTime, trainer, trainingType);
                    schedule.Add(session);
                }
            }
        }
    }
}
