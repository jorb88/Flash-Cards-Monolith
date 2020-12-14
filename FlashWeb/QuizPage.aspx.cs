using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlashLib;

namespace FlashWeb
{
	public partial class QuizPage : System.Web.UI.Page
	{
		private FlashCard quiz;
		private FlashEntities db;
		private Student user;
		protected void Page_Load(object sender, EventArgs e)
		{
			db = (FlashEntities)Session["db"];
			if (Session["user"] == null)
				Response.Redirect("~/Default.aspx");
			user = (Student)Session["user"];
			if (Session["quiz"] == null)
			{
				quiz = new FlashCard();
				Session["quiz"] = quiz;
			}
			else
			{
				quiz = (FlashCard)Session["quiz"];
			}
			if (!IsPostBack)
			{
				quiz.Op = "+";
				btnAnswer.Enabled = false;
				lblQuestion.Text = "----------";
				lblCorrect.Text = "";
				lblWelcome.Text = "Welcome " + user.FirstName + " " + user.LastName;
			}
		}
		protected void btnQuestion_Click(object sender, EventArgs e)
		{
			lblQuestion.Text = quiz.BuildEquation();
			txtAnswer.Text = "";
			user.Tries++;
			db.SaveChanges();
			btnQuestion.Enabled = false;
			btnAnswer.Enabled = true;
		}
		protected void btnAnswer_Click(object sender, EventArgs e)
		{
			if (txtAnswer.Text.Trim().Length == 0)
			{
				lblCorrect.Text = "Please enter an answer.";
				return;
			}
			double answer = double.Parse(txtAnswer.Text);
			if (quiz.CheckAnswer(answer) == true)
			{
				lblCorrect.Text = "Correct";
				user.Correct++;
				db.SaveChanges();
			}
			else lblCorrect.Text = "Incorrect";
			lblCorrect.Text = lblCorrect.Text + " - " + user.Correct + " correct out of " + user.Tries + " tries";
			btnQuestion.Enabled = true;
			btnAnswer.Enabled = false;
		}
		protected void rbAdd_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			quiz.Op = rb.Text;
		}
	}
}