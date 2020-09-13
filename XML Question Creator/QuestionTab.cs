using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using XML_Question_Creator.Models;

namespace XML_Question_Creator
{
    public class QuestionTab : TabPage
    {
        private frmQCreator _QCreator;

        public int question = 0;
        public string _text = "";
        public Image _image = null;
        private List<Answer> answers;

        private TextBox qimagetextbox;
        private PictureBox qimagepicturebox;

        private Panel _apanel;
        public List<AnswerPanel> answerpanels;

        public QuestionTab(frmQCreator frm, int q) {
            _QCreator = frm;
            question = q;
            this.Text = String.Format("Question {0}", question);
            answerpanels = new List<AnswerPanel>();

            Label qtextlbl = new Label();
            qtextlbl.Name = "lblQText";
            qtextlbl.Text = "Question Text";
            qtextlbl.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
            qtextlbl.Size = new Size(78, 13);
            qtextlbl.Location = new Point(8, 13);
            this.Controls.Add(qtextlbl);

            TextBox qtextbox = new TextBox();
            qtextbox.Name = "txtQText";
            qtextbox.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Regular);
            qtextbox.Multiline = true;
            qtextbox.Size = new Size(271, 72);
            qtextbox.Location = new Point(8, 29);
            qtextbox.TextChanged += new EventHandler(txtQText_TextChanged);
            this.Controls.Add(qtextbox);

            Label qimagelbl = new Label();
            qimagelbl.Name = "lblQImage";
            qimagelbl.Text = "Question Image (Path)";
            qimagelbl.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
            qimagelbl.Size = new Size(124, 13);
            qimagelbl.Location = new Point(8, 114);
            this.Controls.Add(qimagelbl);

            qimagetextbox = new TextBox();
            qimagetextbox.Name = "txtQImage";
            qimagetextbox.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Regular);
            qimagetextbox.Size = new Size(187, 22);
            qimagetextbox.Location = new Point(11, 130);
            this.Controls.Add(qimagetextbox);

            Button browsebutton = new Button();
            browsebutton.Name = "btnBrowse";
            browsebutton.Text = "Browse...";
            browsebutton.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Regular);
            browsebutton.Size = new Size(75, 24);
            browsebutton.Location = new Point(204, 129);
            browsebutton.Click += new EventHandler(btnBrowse_Click);
            this.Controls.Add(browsebutton);

            qimagepicturebox = new PictureBox();
            qimagepicturebox.Name = "pbQImage";
            qimagepicturebox.Size = new Size(90, 90);
            qimagepicturebox.Location = new Point(11, 156);
            qimagepicturebox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(qimagepicturebox);

            Button removebutton = new Button();
            removebutton.Name = "btnQRemove";
            removebutton.Text = "Remove Question";
            removebutton.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Regular);
            removebutton.Size = new Size(121, 23);
            removebutton.Location = new Point(11, 268);
            removebutton.Click += new EventHandler(btnQRemove_Click);
            this.Controls.Add(removebutton);

            Panel answerspanel = new Panel();
            answerspanel.Name = "panAnswers";
            answerspanel.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Regular);
            answerspanel.Size = new Size(345, 69);
            answerspanel.Location = new Point(324, 13);
            this.Controls.Add(answerspanel);
            _apanel = answerspanel;

            Label answerslabel = new Label();
            answerslabel.Name = "lblAnswers";
            answerslabel.Text = "Answers";
            answerslabel.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
            answerslabel.Size = new Size(51, 13);
            answerslabel.Location = new Point(131, 0);
            answerspanel.Controls.Add(answerslabel);

            Button addanswerbutton = new Button();
            addanswerbutton.Name = "btnAddAnswer";
            addanswerbutton.Text = "Add Answer";
            addanswerbutton.Anchor = AnchorStyles.Bottom;
            addanswerbutton.Size = new Size(292, 23);
            addanswerbutton.Location = new Point(6, 13);
            addanswerbutton.Click += new EventHandler(btnAddAnswer_Click);
            answerspanel.Controls.Add(addanswerbutton);
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "png files (*.png)|*.png|bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            string fpath = "";
            if(fd.ShowDialog() == DialogResult.OK) {
                fpath = fd.FileName;
                Image img = Image.FromFile(fpath);
                float scale = 200f/img.Width;
                Bitmap newimg = new Bitmap(img, new Size((int)(img.Width * scale), (int)(img.Height * scale)));
                _image = newimg;
                qimagetextbox.Text = fpath;
                qimagepicturebox.Image = _image;
            }
            else {
                _image = null;
                qimagetextbox.Text = fpath;
                qimagepicturebox.Image = null;
            }
        }

        public List<Answer> getAnswers() {
            answers = new List<Answer>();
            for (int i = 0; i < answerpanels.Count; i++) {
                answers.Add(new Answer(answerpanels[i]._text,answerpanels[i]._correct));
            }
            return answers;
        }

        private void txtQText_TextChanged(object sender, EventArgs e) {
            _text = ((TextBox)sender).Text;
        }

        private void btnQRemove_Click(object sender, EventArgs e) {
            this.Parent.Controls.Remove(this);
            _QCreator.RemoveQuestion(question-1);
            this.Dispose();
        }

        public void UpdateQuestion() { 
            this.Text = String.Format("Question {0}", question);
        }

        public void UpdateAnswers() {
            for (int i = 0; i < answerpanels.Count; i++) {
                answerpanels[i].answer = i;
                answerpanels[i].UpdateAnswer();
            }
        }

        private void btnAddAnswer_Click(object sender, EventArgs e)
        {
            AnswerPanel ap = new AnswerPanel(_apanel, answerpanels.Count);
            _apanel.Controls.Add(ap);
            answerpanels.Add(ap);
        }
    }
}
