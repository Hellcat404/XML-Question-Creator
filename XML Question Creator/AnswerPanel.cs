using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML_Question_Creator
{
    public class AnswerPanel : Panel
    {
        Panel _apanel;
        public int answer = 0;

        public string _text = "";
        public bool _correct = false;

        Label answerlabel;

        public AnswerPanel(Panel parent, int answers) {
            answer = answers+1;
            _apanel = parent;
            parent.Size += new Size(0, 30);

            this.Size = new Size(324, 30);
            this.Location = new Point(0, (answers * 30) + 19);

            answerlabel = new Label();
            answerlabel.Text = String.Format("{0}:", (answers + 1).ToString());
            answerlabel.Font = new Font(parent.Font.Name, parent.Font.Size, FontStyle.Regular);
            answerlabel.Size = new Size(24, 13);
            answerlabel.Location = new Point(0, 2);
            this.Controls.Add(answerlabel);

            TextBox answertextbox = new TextBox();
            answertextbox.Font = new Font(parent.Font.Name, parent.Font.Size, FontStyle.Regular);
            answertextbox.Size = new Size(201, 22);
            answertextbox.Location = new Point(25, 0);
            answertextbox.TextChanged += new EventHandler(txtText_TextChanged);
            this.Controls.Add(answertextbox);

            CheckBox answercheckbox = new CheckBox();
            answercheckbox.Checked = false;
            answercheckbox.Text = "correct?";
            answercheckbox.Font = new Font(parent.Font.Name, parent.Font.Size, FontStyle.Regular);
            answercheckbox.Size = new Size(66, 17);
            answercheckbox.Location = new Point(232, 2);
            answercheckbox.CheckedChanged += new EventHandler(cbCorrect_CheckedChanged);
            this.Controls.Add(answercheckbox);

            Button deleteanswerbutton = new Button();
            deleteanswerbutton.Image = Properties.Resources.trash;
            deleteanswerbutton.Size = new Size(24, 24);
            deleteanswerbutton.Location = new Point(300, -1);
            deleteanswerbutton.Click += new EventHandler(deleteAnswer);
            this.Controls.Add(deleteanswerbutton);
        }

        private void cbCorrect_CheckedChanged(object sender, EventArgs e) {
            _correct = ((CheckBox)sender).Checked;
        }

        private void txtText_TextChanged(object sender, EventArgs e) {
            _text = ((TextBox)sender).Text;
        }

        private void deleteAnswer(object sender, EventArgs e) {
            _apanel.Size -= new Size(0,30);
            _apanel.Controls.Remove(this);
            ((QuestionTab)_apanel.Parent).answerpanels.Remove(this);
            ((QuestionTab)_apanel.Parent).UpdateAnswers();
            this.Dispose();
        }

        public void UpdateAnswer() {
            answerlabel.Text = String.Format("{0}:", (answer + 1).ToString());
            this.Location = new Point(0, (answer * 30) + 19);
        }
    }
}
