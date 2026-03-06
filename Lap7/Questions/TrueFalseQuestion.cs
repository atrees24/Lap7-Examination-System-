using System;
using System.Collections.Generic;
using System.Text;
using Lap7.Answers;

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion(string header, string body, int marks,AnswerList answers, Answer correctAnswer)
       : base(header, body, marks, answers, correctAnswer) 
     {
    }


    public override bool CheckAnswer(List<Answer> studentAnswers)
    {
        if (studentAnswers == null || studentAnswers.Count != 1)
            return false;

        return CorrectAnswer.Equals(studentAnswers[0]);
    }

    public override void Display()
    {
        Console.WriteLine(ToString());
        for (int i = 0; i < Answers.Count; i++)
            Console.WriteLine(Answers[i]);
    }
}