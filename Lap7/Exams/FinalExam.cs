using System;
using System.Collections.Generic;
using System.Text;
using Lap7.Answers;

namespace Lap7.Exams
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, Question[] questions, Subject subject)
        {
            Time = time;
            Questions = questions ?? Array.Empty<Question>();
            NumberOfQuestions = Questions.Length;
            Subject = subject;
            Mode = ExamMode.Queued;
            QuestionAnswerDictionary = new Dictionary<Question, Answer>();
        }

        public override void ShowExam()
        {
            Start();

            foreach (var question in Questions)
            {
                Console.WriteLine("--------------------------------");
                question.Display();
                int id;
                while (!int.TryParse(Console.ReadLine(), out id) ||
                       question.Answers.GetById(id) == null)
                {
                    Console.Write("Invalid answer. Try again: ");
                }

                Answer studentAnswer = question.Answers.GetById(id);

                QuestionAnswerDictionary[question] = studentAnswer;
            }

            Finish();
        }

        public override void Finish()
        {
            base.Finish();

            Console.WriteLine("\n===== Student Answers =====");

            foreach (var pair in QuestionAnswerDictionary)
            {
                Console.WriteLine($"Question: {pair.Key.Body}");
                Console.WriteLine($"Your Answer: {pair.Value}");
                Console.WriteLine();
            }
        }
    }
}
