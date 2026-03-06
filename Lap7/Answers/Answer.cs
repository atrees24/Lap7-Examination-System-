using System;
using System.Collections.Generic;
using System.Text;

namespace Lap7.Answers
{
    public class Answer:IComparable<Answer>
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Answer(int id , string text) 
        {
            if (id <= 0)
                throw new ArgumentException("Id must be positive");

            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text cannot be empty");

            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return $"{Id} - {Text}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text);
        }

        public override bool Equals(object? obj)
        {
            if(obj is Answer other)
            {
                return Id == other.Id 
                    && Text == other.Text;
            }
            return false;
        }

        public int CompareTo(Answer? other)
        {
            if (other == null) 
                return 1; 

            return Id.CompareTo(other.Id);
        }
    }
}
