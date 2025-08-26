using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSqlTest.Models
{
    public class WordModel
    {
        public int Id { get; set; }
        public string EnglishWord { get; set; }
        public string Translation { get; set; }
        public DateTime DateAdded { get; set; }
        public bool HasUserTranslation { get; set; }

        public WordModel()
        {
            DateAdded = DateTime.Now;
            HasUserTranslation = false;
        }

        public WordModel(string englishWord, string translation) : this()
        {
            EnglishWord = englishWord;
            Translation = translation;
        }

        public WordModel(string englishWord, string translation, bool hasUserTranslation) : this(englishWord, translation)
        {
            HasUserTranslation = hasUserTranslation;
        }
    }
}
