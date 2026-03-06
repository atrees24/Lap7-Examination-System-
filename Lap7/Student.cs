using System;
using System.Collections.Generic;
using System.Text;

namespace Lap7
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name invalid");
            Id = id; Name = name; 
        }


        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"Student {Name} notified:");
            Console.WriteLine($"Exam started for subject: {e.Subject.Name}");
            Console.WriteLine("--------------------------");
        }
    }
}
