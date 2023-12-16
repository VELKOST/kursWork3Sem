using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya_work
{
    internal class Trainer
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
    }
}
