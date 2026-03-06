using System;
using System.Collections.Generic;
using System.Text;
using Lap7.Answers;

namespace Lap7.Exams
{
    public class PracticeExam : Exam
    {
        public PracticeExam(int time, Question[] questions, Subject subject)
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

                Console.Write("Enter Answer Id: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                    continue;

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
                Console.WriteLine($"Correct Answer: {pair.Key.CorrectAnswer}");
                Console.WriteLine();
            }

            int finalScore = CorrectExam();
            Console.WriteLine($"Final Grade = {finalScore}");
        }
    }
}
