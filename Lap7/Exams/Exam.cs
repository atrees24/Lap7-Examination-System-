using System;
using System.Collections.Generic;
using System.Text;
using Lap7.Answers;

namespace Lap7.Exams
{
    public enum ExamMode
    {
        Starting,
        Queued,
        Finished
    }
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        public Dictionary<Question, Answer> QuestionAnswerDictionary { get; set; }
        public Subject Subject { get; set; }
        public ExamMode Mode { get; set; }

        public abstract void ShowExam();
        public virtual void Start()
        {
            Mode = ExamMode.Starting;
            OnExamStarted();
            Console.WriteLine("Exam started...");
        }

        public virtual void Finish()
        {
            Mode = ExamMode.Finished;
            Console.WriteLine("Exam finished.");
        }

        public int CorrectExam()
        {
            int score = 0;

            if (Questions == null || QuestionAnswerDictionary == null)
                return score;

            foreach (var question in Questions)
            {
          
                if (QuestionAnswerDictionary.ContainsKey(question))
                {
                    Answer studentAnswer = QuestionAnswerDictionary[question];

           
                    if (question.CheckAnswer(new List<Answer> { studentAnswer }))
                    {
                        score += question.Marks; 
                    }
                }
            }


            return score; 
        }


        public override string ToString()
        {
            return $"Subject: {Subject}, Time: {Time}, Questions: {NumberOfQuestions}, Mode: {Mode}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Exam other)
            {
                return Time == other.Time &&
                       NumberOfQuestions == other.NumberOfQuestions &&
                       Subject.Equals(other.Subject);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Time, NumberOfQuestions, Subject);
        }

        public int CompareTo(Exam? other)
        {
           if (other == null)
                return 1;

            int timeCompare = Time.CompareTo(other.Time);

            if (timeCompare != 0)
                return timeCompare;

            return NumberOfQuestions.CompareTo(other.NumberOfQuestions);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public event ExamStartedHandler ExamStarted;
        protected virtual void OnExamStarted()
        {
            ExamStarted?.Invoke(this, new ExamEventArgs(Subject, this));
        }
    }
}
