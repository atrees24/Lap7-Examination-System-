using System;
using System.Collections.Generic;
using System.Text;
using Lap7.Answers;

public abstract class Question
{
    public string Header { get; set; }
    public string Body { get; set; }
    public int Marks { get; set; }
    public AnswerList Answers { get; set; }
    public Answer CorrectAnswer { get; set; }

    protected Question(string header, string body, int marks, AnswerList answers, Answer correctAnswer)
    {
        if (string.IsNullOrWhiteSpace(header))
            throw new ArgumentException("Header cannot be null or empty");

        if (string.IsNullOrWhiteSpace(body))
            throw new ArgumentException("Body cannot be null or empty");

        if (marks <= 0)
            throw new ArgumentException("Marks must be greater than 0");

        if (answers == null)
            throw new ArgumentNullException(nameof(answers));

        if (correctAnswer == null)
            throw new ArgumentNullException(nameof(correctAnswer));

        Header = header;
        Body = body;
        Marks = marks;
        Answers = answers;
        CorrectAnswer = correctAnswer;
    }

    public abstract void Display();


    public abstract bool CheckAnswer(List<Answer> studentAnswers);

    public override string ToString()
    {
        return $"[{Header}] {Body} ({Marks} Marks)";
    }

    public override bool Equals(object obj)
    {
        if (obj is Question other)
        {
            return Header == other.Header &&
                   Body == other.Body &&
                   Marks == other.Marks &&
                   CorrectAnswer.Equals(other.CorrectAnswer);//used equals 3shan dh obj msh qema basyta tt3ml kda ==
                                                             // lasm a3ml kda override l equals 3nd answer 3shan tshta8l
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Header, Body, Marks, CorrectAnswer);
    }

}