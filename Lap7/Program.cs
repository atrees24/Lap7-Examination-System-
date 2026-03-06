using Lap7.Answers;
using Lap7.Exams;

namespace Lap7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject s1 = new Subject("c#");

            Student st1 = new Student(1, "Ahmed");
            Student st2 = new Student(2, "Mohamed");
            Student st3 = new Student(1, "Nour");

            s1.Enroll(st1);
            s1.Enroll(st2);
            s1.Enroll(st3);

            AnswerList q1Answers = new AnswerList();
            q1Answers.Add(new Answer(1, "C#"));
            q1Answers.Add(new Answer(2, "Python"));
            q1Answers.Add(new Answer(3, "HTML"));

            ChooseOneQuestion q1 = new ChooseOneQuestion(
              "Q1",
              "Which is a programming language?",
              10,
              q1Answers,
              q1Answers.GetById(1) 
          );

          
            AnswerList q2Answers = new AnswerList();
            q2Answers.Add(new Answer(1, "True"));
            q2Answers.Add(new Answer(2, "False"));

            TrueFalseQuestion q2 = new TrueFalseQuestion(
                "Q2",
                "OOP is a programming paradigm.",
                5,
                q2Answers,
                q2Answers.GetById(1) 
            );


            Question[] questions = new Question[] { q1, q2 };

         
            PracticeExam practice = new PracticeExam(30, questions, s1);

      
            FinalExam final = new FinalExam(45, questions, s1);

            Console.WriteLine("Select Exam Type:");
            Console.WriteLine("1 - Practice Exam");
            Console.WriteLine("2 - Final Exam");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                practice.ShowExam();
            }
            else if (choice == "2")
            {
                final.ShowExam();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
