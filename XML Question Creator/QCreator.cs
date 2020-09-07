using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML_Question_Creator.Models;

namespace XML_Question_Creator
{
    public partial class frmQCreator : Form {

        private List<Question> questions;

        public frmQCreator() {
            InitializeComponent();
            Initialize();
        }

        private void Initialize() { 
            questions = new List<Question>();
            tctlQuestions.TabPages.Clear();
            tctlQuestions.TabPages.Add("Add Question");
        }

        private void AddQuestion() {
            questions.Add(new Question(String.Format("Question {0}", questions.Count), null, null));
            CreateQuestionTab(String.Format("Question {0}",questions.Count));
        }

        private void CreateQuestionTab(string name) {
            tctlQuestions.TabPages.Insert(tctlQuestions.TabCount - 1, name);
            TabPage tab = tctlQuestions.TabPages[tctlQuestions.TabCount - 2];

            Label qtextlbl = new Label();
            qtextlbl.Name = "lblQText";
            qtextlbl.Text = "Question Text";
            qtextlbl.Font = new Font(tab.Font.Name,tab.Font.Size,FontStyle.Bold);
            qtextlbl.Size = new Size(78,13);
            qtextlbl.Location = new Point(8,13);
            tab.Controls.Add(qtextlbl);

            TextBox qtextbox = new TextBox();
            qtextbox.Name = "txtQText";
            qtextbox.Font = new Font(tab.Font.Name, tab.Font.Size, FontStyle.Regular);
            qtextbox.Multiline = true;
            qtextbox.Size = new Size(271,72);
            qtextbox.Location = new Point(8,29);
            tab.Controls.Add(qtextbox);

            Label qimagelbl = new Label();
            qimagelbl.Name = "lblQImage";
            qimagelbl.Text = "Question Image (Path)";
            qimagelbl.Font = new Font(tab.Font.Name, tab.Font.Size, FontStyle.Bold);
            qimagelbl.Size = new Size(124,13);
            qimagelbl.Location = new Point(8,114);
            tab.Controls.Add(qimagelbl);

            TextBox qimagetextbox = new TextBox();
            qimagetextbox.Name = "txtQImage";
            qimagetextbox.Font = new Font(tab.Font.Name, tab.Font.Size, FontStyle.Regular);
            qimagetextbox.Size = new Size(187,22);
            qimagetextbox.Location = new Point(11,130);
            tab.Controls.Add(qimagetextbox);

            Button browsebutton = new Button();
            browsebutton.Name = "btnBrowse";
            browsebutton.Text = "Browse...";
            browsebutton.Font = new Font(tab.Font.Name, tab.Font.Size, FontStyle.Regular);
            browsebutton.Size = new Size(75,24);
            browsebutton.Location = new Point(204,129);
            browsebutton.Click += new EventHandler(btnBrowse_Click);
            tab.Controls.Add(browsebutton);

            PictureBox qimagepicturebox = new PictureBox();
            qimagepicturebox.Name = "pbQImage";
            qimagepicturebox.Size = new Size(90,90);
            qimagepicturebox.Location = new Point(11,156);
            tab.Controls.Add(qimagepicturebox);

            Button removebutton = new Button();
            removebutton.Name = "btnQRemove";
            removebutton.Text = "Remove Question";
            removebutton.Font = new Font(tab.Font.Name, tab.Font.Size, FontStyle.Regular);
            removebutton.Size = new Size(121,23);
            removebutton.Location = new Point(11,268);
            removebutton.Click += new EventHandler(btnQRemove_Click);
            tab.Controls.Add(removebutton);

            Panel answerspanel = new Panel();
            answerspanel.Name = "panAnswers";
            answerspanel.Font = new Font(tab.Font.Name, tab.Font.Size, FontStyle.Regular);
            answerspanel.Size = new Size(305,69);
            answerspanel.Location = new Point(324,13);
            tab.Controls.Add(answerspanel);

            Label answerslabel = new Label();
            answerslabel.Name = "lblAnswers";
            answerslabel.Text = "Answers";
            answerslabel.Font = new Font(tab.Font.Name, tab.Font.Size, FontStyle.Bold);
            answerslabel.Size = new Size(51,13);
            answerslabel.Location = new Point(131,0);
            answerspanel.Controls.Add(answerslabel);

            Label answerlabel = new Label();
            answerlabel.Text = "1:";
            answerlabel.Font = new Font(tab.Font.Name, tab.Font.Size, FontStyle.Regular);
            answerlabel.Size = new Size(16,13);
            answerlabel.Location = new Point(3,19);
            answerspanel.Controls.Add(answerlabel);

            TextBox answertextbox = new TextBox();
            answertextbox.Font = new Font(tab.Font.Name, tab.Font.Size, FontStyle.Regular);
            answertextbox.Size = new Size(201,22);
            answertextbox.Location = new Point(25,16);
            answerspanel.Controls.Add(answertextbox);

            CheckBox answercheckbox = new CheckBox();
            answercheckbox.Text = "correct?";
            answercheckbox.Font = new Font(tab.Font.Name, tab.Font.Size, FontStyle.Regular);
            answercheckbox.Size = new Size(66,17);
            answercheckbox.Location = new Point(232,19);
            answerspanel.Controls.Add(answercheckbox);

            Button addanswerbutton = new Button();
            addanswerbutton.Name = "btnAddAnswer";
            addanswerbutton.Text = "Add Answer";
            addanswerbutton.Anchor = AnchorStyles.Bottom;
            addanswerbutton.Size = new Size(292,23);
            addanswerbutton.Location = new Point(6,43);
            addanswerbutton.Click += new EventHandler(btnAddAnswer_Click);
            answerspanel.Controls.Add(addanswerbutton);

            tctlQuestions.SelectedIndex = tctlQuestions.TabCount - 2;
        }

        private void btnAddAnswer_Click(object sender, EventArgs e) {
            Panel parent = (Panel)((Button)sender).Parent;
            Label answerlabel = new Label();
            answerlabel.Text = "1:";
            answerlabel.Font = new Font(parent.Font.Name, parent.Font.Size, FontStyle.Regular);
            answerlabel.Size = new Size(16, 13);
            answerlabel.Location = new Point(3, 19);
            parent.Controls.Add(answerlabel);

            TextBox answertextbox = new TextBox();
            answertextbox.Font = new Font(parent.Font.Name, parent.Font.Size, FontStyle.Regular);
            answertextbox.Size = new Size(201, 22);
            answertextbox.Location = new Point(25, 16);
            parent.Controls.Add(answertextbox);

            CheckBox answercheckbox = new CheckBox();
            answercheckbox.Text = "correct?";
            answercheckbox.Font = new Font(parent.Font.Name, parent.Font.Size, FontStyle.Regular);
            answercheckbox.Size = new Size(66, 17);
            answercheckbox.Location = new Point(232, 19);
            parent.Controls.Add(answercheckbox);
        }

        private void btnBrowse_Click(object sender, EventArgs e) {

        }

        private void btnQRemove_Click(object sender, EventArgs e) {

        }

        private void RemoveQuestion(int i) {
            questions.RemoveAt(i);
            NumberTabs();
        }

        private void NumberTabs() {
            for (int i = 0; i < questions.Count; i++) {
                tctlQuestions.TabPages[i].Text = String.Format("Question {0}", i+1);
            }
        }

        private void tsExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void tsNew_Click(object sender, EventArgs e) {
            Initialize();
        }

        private void tctlQuestions_Click(object sender, EventArgs e) {
            if ((((TabControl)sender).SelectedIndex) == (((TabControl)sender).TabCount - 1))
                AddQuestion();
        }
    }
}
