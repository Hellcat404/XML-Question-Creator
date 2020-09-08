﻿using System;
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
    }
}
