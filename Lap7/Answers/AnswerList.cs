using System;
using System.Collections.Generic;

namespace Lap7.Answers
{
    public class AnswerList
    {
        private List<Answer> _answers;

        public int Count
        {
            get { return _answers.Count; }
        }

        public AnswerList(int capacity = 4)
        {
            _answers = new List<Answer>(capacity);
        }

        public void Add(Answer answer)
        {
            if (answer == null)
                throw new ArgumentNullException(nameof(answer));

            _answers.Add(answer);
        }

        public Answer GetById(int id)
        {
            for (int i = 0; i < _answers.Count; i++)
            {
                if (_answers[i].Id == id)
                    return _answers[i];
            }
            return null;
        }

        public Answer this[int index]
        {
            get
            {
                if (index < 0 || index >= _answers.Count)
                    throw new IndexOutOfRangeException();

                return _answers[index];
            }
            set
            {
                if (index < 0 || index >= _answers.Count)
                    throw new IndexOutOfRangeException();

                _answers[index] = value;
            }
        }
    }
}