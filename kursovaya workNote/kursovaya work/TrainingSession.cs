using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya_work
{
    internal class TrainingSession
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
    }
}
