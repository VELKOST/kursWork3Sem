using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya_work
{
    internal class TrainerManager
    {
        private List<Trainer> trainers = new List<Trainer>();

        public void AddTrainer(Trainer trainer)
        {
            trainers.Add(trainer);
            Console.WriteLine($"Тренер {trainer.Name} добавлен.");
            SaveTrainersToFile();
        }

        public void RemoveTrainer(string name)
        {
            var trainer = trainers.FirstOrDefault(t => t.Name == name);
            if (trainer != null)
            {
                trainers.Remove(trainer);
                Console.WriteLine($"Тренер {trainer.Name} удален.");
                SaveTrainersToFile();
            }
            else
            {
                Console.WriteLine("Ошибка: тренер с таким именем не найден.");
            }
        }

        public void DisplayTrainers()
        {
            LoadTrainersFromFile();
            Console.WriteLine("\nСписок тренеров:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var trainer in trainers)
            {
                Console.WriteLine($"Имя: {trainer.Name}, Контактная информация: {trainer.ContactInfo}, Специализация: {trainer.Specialization}");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        }

        public Trainer GetTrainer(int index)
        {
            if (index >= 0 && index < trainers.Count)
            {
                return trainers[index];
            }
            else
            {
                Console.WriteLine("Ошибка: индекс вне диапазона.");
                return null;
            }
        }

        private void SaveTrainersToFile()
        {
            using (StreamWriter writer = new StreamWriter("trainers.txt"))
            {
                foreach (var trainer in trainers)
                {
                    writer.WriteLine($"{trainer.Name},{trainer.ContactInfo},{trainer.Specialization}");
                }
            }
        }

        private void LoadTrainersFromFile()
        {
            trainers.Clear();
            using (StreamReader reader = new StreamReader("trainers.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    string contactInfo = parts[1];
                    string specialization = parts[2];

                    Trainer trainer = new Trainer(name, contactInfo, specialization);
                    trainers.Add(trainer);
                }
            }
        }
    }
}
