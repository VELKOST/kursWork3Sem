using System;
using System.Collections.Generic;
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
        }
    }

