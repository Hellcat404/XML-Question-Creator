using System.Collections.Generic;
using System.Drawing;

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

        public void setText(string t) { text = t; }
        public void setImage(Image i) { image = i; }
        public void setAnswers(List<Answer> a) { answers = a; }

        public string getText() { return text; }
        public Image getImage() { return image; }
        public List<Answer> getAnswers() { return answers; }
    }
}
