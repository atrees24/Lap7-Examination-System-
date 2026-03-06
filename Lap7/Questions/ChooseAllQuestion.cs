using System;
using System.Collections.Generic;
using System.Text;
using Lap7.Answers;

public class ChooseAllQuestion : Question
{
    private List<Answer> CorrectAnswers;

    public ChooseAllQuestion(string header, string body, int marks,
        AnswerList answers, List<Answer> correctAnswers)
        : base(header, body, marks, answers, correctAnswers[0])
    {
        CorrectAnswers = correctAnswers;
    }


    public override void Display()
    {
        Console.WriteLine(ToString());
        for (int i = 0; i < Answers.Count; i++)
            Console.WriteLine(Answers[i]);

        Console.WriteLine("Select all correct answers...");
    }

    public override bool CheckAnswer(List<Answer> studentAnswers)
    {
        if (studentAnswers == null)
            return false;

        if (studentAnswers.Count != CorrectAnswers.Count)
            return false;

        for (int i = 0; i < CorrectAnswers.Count; i++)
        {
            bool found = false;

            for (int j = 0; j < studentAnswers.Count; j++)
            {
                if (CorrectAnswers[i].Equals(studentAnswers[j]))
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                return false;
        }

        return true;
    }
}