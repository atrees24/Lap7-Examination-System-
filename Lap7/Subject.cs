using System;
using System.Collections.Generic;
using System.Text;

namespace Lap7
{
    public class Subject
    {
        public string Name { get; private set; }
        public List<Student> EnrolledStudents { get; private set; }


        public Subject(string name ) 
        {
            Name = name;
            EnrolledStudents = new List<Student>();
        }

        public void Enroll(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (EnrolledStudents.Contains(student))
                throw new InvalidOperationException("Student already enrolled.");


            EnrolledStudents.Add( student );
        }

        public void NotifyStudents(object sender, ExamEventArgs e)
        {
            foreach (var student in EnrolledStudents)
            {
                student.OnExamStarted(sender, e);
            }
        }

        public override string ToString()
        {
            return $"Subject: {Name}, Students Count: {EnrolledStudents.Count}";
        }
    }
}
