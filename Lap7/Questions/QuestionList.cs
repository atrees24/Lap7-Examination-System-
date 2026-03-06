using System;
using System.Collections.Generic;
using System.IO;

public class QuestionList : List<Question>
{
    private string _filePath;

    public QuestionList(string filePath)
    {
        _filePath = filePath;
    }

    public new void Add(Question question)
    {
        if (question == null)
            throw new ArgumentNullException(nameof(question));

       
        base.Add(question);


     
        using (StreamWriter writer = new StreamWriter(_filePath, true))
        {

            if (string.IsNullOrWhiteSpace(_filePath))
                throw new ArgumentException("File path invalid");
            writer.WriteLine(question.ToString());
        }
    }
}