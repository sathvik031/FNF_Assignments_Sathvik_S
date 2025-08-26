using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSqlTest.BusinessLogic;

namespace WebSqlTest.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        private WordService _wordService;

        protected void Page_Load(object sender, EventArgs e)
        {
            _wordService = new WordService();

            if (!IsPostBack)
            {
                LoadMyWords();
                LoadApplicationStats();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchWord = txtEnglishWord.Text.Trim();

                if (string.IsNullOrEmpty(searchWord))
                {
                    ShowMessage("Please enter a word to search.", "error");
                    return;
                }

                var foundWord = _wordService.SearchWord(searchWord);

                if (foundWord != null)
                {
                    // Word found - show add translation section
                    lblFoundWord.Text = foundWord.EnglishWord;
                    txtTranslation.Text = foundWord.Translation; // Pre-fill with existing translation if any
                    pnlAddWord.Visible = true;
                    HideMessage();
                }
                else
                {
                    // Word not found - redirect to error page
                    Response.Redirect($"Error.aspx?word={Server.UrlEncode(searchWord)}");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("An error occurred while searching: " + ex.Message, "error");
            }
        }

        protected void btnAddToMyWords_Click(object sender, EventArgs e)
        {
            try
            {
                string englishWord = lblFoundWord.Text;
                string translation = txtTranslation.Text.Trim();

                if (string.IsNullOrEmpty(translation))
                {
                    ShowMessage("Please enter a translation.", "error");
                    return;
                }

                bool success = _wordService.AddTranslationToWord(englishWord, translation);

                if (success)
                {
                    ShowMessage("Word translation updated successfully!", "success");
                    LoadMyWords();
                    LoadApplicationStats();
                    pnlAddWord.Visible = false;
                    txtEnglishWord.Text = "";
                }
                else
                {
                    ShowMessage("Failed to update word translation. Please try again.", "error");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("An error occurred: " + ex.Message, "error");
            }
        }

        private void LoadMyWords()
        {
            try
            {
                var words = _wordService.GetMyWords();
                gvMyWords.DataSource = words;
                gvMyWords.DataBind();
            }
            catch (Exception ex)
            {
                ShowMessage("Failed to load words: " + ex.Message, "error");
            }
        }

        private void LoadApplicationStats()
        {
            try
            {
                string stats = _wordService.GetApplicationStats();
                lblStats.Text = stats;
            }
            catch (Exception ex)
            {
                lblStats.Text = "Unable to load .";
            }
        }

        private void ShowMessage(string message, string type)
        {
            lblMessage.Text = message;
            lblMessage.CssClass = $"message {type}";
            pnlMessage.Visible = true;
        }

        private void HideMessage()
        {
            pnlMessage.Visible = false;
        }
    }
}