using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSqlTest.DataAccess;
using WebSqlTest.Models;

namespace WebSqlTest.BusinessLogic
{
    public class WordService
    {
        private readonly WordRepository _wordRepository;

        public WordService()
        {
            _wordRepository = new WordRepository();
        }

        public WordModel SearchWord(string englishWord)
        {
            if (string.IsNullOrWhiteSpace(englishWord))
                throw new ArgumentException("English word cannot be empty.");

            return _wordRepository.SearchWord(englishWord.Trim());
        }

        public bool AddTranslationToWord(string englishWord, string translation)
        {
            if (string.IsNullOrWhiteSpace(englishWord))
                throw new ArgumentException("English word cannot be empty.");

            if (string.IsNullOrWhiteSpace(translation))
                throw new ArgumentException("Translation cannot be empty.");

            return _wordRepository.AddTranslationToWord(englishWord.Trim(), translation.Trim());
        }

        public List<WordModel> GetMyWords()
        {
            var myWords = _wordRepository.GetMyWords();
            return myWords.OrderByDescending(w => w.DateAdded).ToList();
        }

        public Dictionary<string, WordModel> GetAllWords()
        {
            return _wordRepository.GetAllWords();
        }

        public int GetTotalWordCount()
        {
            return _wordRepository.GetWordCount();
        }

        public bool WordExists(string englishWord)
        {
            if (string.IsNullOrWhiteSpace(englishWord))
                return false;

            return _wordRepository.WordExists(englishWord.Trim());
        }

        public string GetApplicationStats()
        {
            var totalWords = GetTotalWordCount();
            var myWordsCount = GetMyWords().Count;
            return $"Total words available: {totalWords}, Changed words: {myWordsCount}";
        }
    }
}
