using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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
            if(questions == null)
                questions = new List<Question>();
            questions.Clear();
            tctlQuestions.TabPages.Clear();
            tctlQuestions.TabPages.Add("Add Question");
        }

        private void AddQuestion() {
            questions.Add(new Question(String.Format("Question {0}", questions.Count), null, null));
            CreateQuestionTab(questions.Count);
        }

        private void CreateQuestionTab(int question) {
            tctlQuestions.TabPages.Insert(tctlQuestions.TabCount - 1, new QuestionTab(this, question));
            tctlQuestions.SelectedIndex = tctlQuestions.TabCount - 2;
        }

        public void RemoveQuestion(int i) {
            questions.RemoveAt(i);
            NumberTabs();
        }

        private void NumberTabs() {
            for (int i = 0; i < questions.Count; i++) {
                ((QuestionTab)tctlQuestions.TabPages[i]).question = i+1;
                ((QuestionTab)tctlQuestions.TabPages[i]).UpdateQuestion();
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

        private void tsExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = false;
            fd.Description = "Select the Android Studio project folder.";
            if(fd.ShowDialog() == DialogResult.OK) {
                string apath = fd.SelectedPath;
                string dpath = apath + @"\app\src\main\res\drawable\";
                string xpath = apath + @"\app\src\main\res\xml\";

                for (int i = 0; i < questions.Count; i++) {
                    questions[i].setText(((QuestionTab)tctlQuestions.TabPages[i])._text);
                    questions[i].setImage(((QuestionTab)tctlQuestions.TabPages[i])._image);
                    questions[i].setAnswers(((QuestionTab)tctlQuestions.TabPages[i]).getAnswers());
                }
                for (int i = 0; i < questions.Count; i++) {
                    questions[i].getImage().Save(String.Format("{0}q{1}.png",dpath , i),System.Drawing.Imaging.ImageFormat.Png);
                }
                createQuestionsXML().Save(String.Format("{0}questionxml.xml",xpath));
            }
        }

        private XDocument createQuestionsXML() {
            XDocument qxml = new XDocument();
            XElement root = new XElement("questions");
            qxml.Add(root);
            for (int i = 0; i < questions.Count; i++) {
                XElement q = new XElement("question");
                root.Add(q);
                q.Add(new XAttribute("text", questions[i].getText()));
                q.Add(new XAttribute("image", String.Format("q{0}",i)));
                List<Answer> qans = questions[i].getAnswers();
                for (int j = 0; j < qans.Count; j++) {
                    XElement a = new XElement("answer");
                    q.Add(a);
                    a.Add(new XAttribute("text", qans[j].getText()));
                    a.Add(new XAttribute("correct", qans[j].isCorrect()));
                }
            }
            return qxml;
        }
    }
}
