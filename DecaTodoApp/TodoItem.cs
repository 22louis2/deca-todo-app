using System;
using System.Collections.Generic;
using System.Text;

namespace DecaTodoApp
{
    public class TodoItem
    {
        public string Text { get; }
        public int Number { get; }

        public TodoItem(int number, string text)
        {
            Number = number;
            Text = text;
        }

        public override string ToString()
        {
            return "#" + Number + " " + Text;
        }
    }
}
