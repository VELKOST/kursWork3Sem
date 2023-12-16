using System;
using System.Collections.Generic;
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
    }
}
