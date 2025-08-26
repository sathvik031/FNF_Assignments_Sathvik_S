using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSqlTest.BusinessLogic;

namespace WebSqlTest.Pages
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string word = Request.QueryString["word"];
                if (!string.IsNullOrEmpty(word))
                {
                    lblErrorMessage.Text = $"'{word}' is not present in the application. Please try another word.";
                }
                else
                {
                    lblErrorMessage.Text = "Word not found. Please try another word.";
                }

                // Show available words
                LoadAvailableWords();
            }
        }

        private void LoadAvailableWords()
        {
            try
            {
                var wordService = new WordService();
                var allWords = wordService.GetAllWords();

                var wordsList = string.Join(", ", allWords.Keys.OrderBy(k => k));
                lblAvailableWords.Text = wordsList;
            }
            catch (Exception)
            {
                lblAvailableWords.Text = "Unable to load available words.";
            }
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}