using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Question_Creator.Models
{
    public class Question
    {
        private string text = null;
        private Image image = null;
        private List<Answer> answers = null;

        public Question(string t, Image i, List<Answer> a)
        {
            text = t;
            image = i;
            answers = a;
        }

        public string getText() { return text; }
        public Image getImage() { return image; }
        public List<Answer> getAnswers() { return answers; }
    }
}
