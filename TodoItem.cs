using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp
{
    internal class TodoItem
    {
        public string Title { get;private set; }
        public bool IsDone { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public TodoItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("A feladat címe nem lehet üres!", nameof(title));
            }
            Title = title;
            CreatedAt = DateTime.Now;
        }
        public void MarkAsDone()
        {
            IsDone = true;
        }

        public override string ToString()
        {
            return $"[{(IsDone? "X": " ")}] {Title}";
        }
    }
}
