using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Question_Creator.Models
{
    public class Answer
    {
        private string text = null;
        private bool correct = false;

        public Answer(string t, bool c)
        {
            text = t;
            correct = c;
        }

        public string getText() { return text; }
        public bool isCorrect() { return correct; }
    }
}
