using System;
using System.Collections.Generic;
using System.Text;
using Lap7.Exams;

namespace Lap7
{
    public class ExamEventArgs : EventArgs
    {
        public Subject Subject { get; }
        public Exam Exam { get; }

        public ExamEventArgs(Subject subject, Exam exam)
        {
            Subject = subject;
            Exam = exam;
        }
    }


    public delegate void ExamStartedHandler(object sender, ExamEventArgs e);
}
