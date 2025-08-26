using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WebSqlTest.Models;

namespace WebSqlTest
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var initialWords = new Dictionary<string, WordModel>(StringComparer.OrdinalIgnoreCase)
        {
            { "movie", new WordModel("movie", "Action") },
            { "Happy", new WordModel("Happy", "Traveling") },
            { "Fun", new WordModel("Fun", "Playing cricket") }
        };

            Application["WordsDictionary"] = initialWords;

            Application["MyWords"] = new List<WordModel>();
        }
    }
}