using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSqlTest.Models;

namespace WebSqlTest.DataAccess
{
    public class WordRepository
    {
        private static readonly object _lockObject = new object();

        public WordModel SearchWord(string englishWord)
        {
            try
            {
                lock (_lockObject)
                {
                    var wordsDictionary = GetWordsDictionary();

                    if (wordsDictionary.ContainsKey(englishWord))
                    {
                        return wordsDictionary[englishWord];
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Search operation failed: " + ex.Message);
            }
        }

        public bool AddTranslationToWord(string englishWord, string translation)
        {
            try
            {
                lock (_lockObject)
                {
                    var wordsDictionary = GetWordsDictionary();
                    var myWords = GetMyWords();

                    if (wordsDictionary.ContainsKey(englishWord))
                    {
                        var existingWord = wordsDictionary[englishWord];
                        existingWord.Translation = translation;
                        existingWord.HasUserTranslation = true;
                        existingWord.DateAdded = DateTime.Now;

                        var existingInMyWords = myWords.FirstOrDefault(w =>
                            string.Equals(w.EnglishWord, englishWord, StringComparison.OrdinalIgnoreCase));

                        if (existingInMyWords == null)
                        {
                            var newWord = new WordModel(englishWord, translation, true)
                            {
                                Id = myWords.Count + 1
                            };
                            myWords.Add(newWord);
                        }
                        else
                        {
                            existingInMyWords.Translation = translation;
                            existingInMyWords.DateAdded = DateTime.Now;
                        }

                        HttpContext.Current.Application["WordsDictionary"] = wordsDictionary;
                        HttpContext.Current.Application["MyWords"] = myWords;

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Add translation operation failed: " + ex.Message);
            }
        }

        public List<WordModel> GetMyWords()
        {
            try
            {
                lock (_lockObject)
                {
                    var myWords = HttpContext.Current.Application["MyWords"] as List<WordModel>;
                    return myWords ?? new List<WordModel>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Get my words operation failed: " + ex.Message);
            }
        }

        public Dictionary<string, WordModel> GetAllWords()
        {
            try
            {
                lock (_lockObject)
                {
                    return GetWordsDictionary();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Get all words operation failed: " + ex.Message);
            }
        }

        private Dictionary<string, WordModel> GetWordsDictionary()
        {
            var wordsDictionary = HttpContext.Current.Application["WordsDictionary"] as Dictionary<string, WordModel>;

            if (wordsDictionary == null)
            {
                // Initialize if not present
                wordsDictionary = new Dictionary<string, WordModel>(StringComparer.OrdinalIgnoreCase)
                {
                    { "cricket", new WordModel("cricket", "fun event") },
                    { "movies", new WordModel("movies", "Mind freshnening") },
                    { "Fun", new WordModel("Fun", "traveling") }
                };
                HttpContext.Current.Application["WordsDictionary"] = wordsDictionary;
            }

            return wordsDictionary;
        }

        // Method to get word count for statistics
        public int GetWordCount()
        {
            lock (_lockObject)
            {
                var wordsDictionary = GetWordsDictionary();
                return wordsDictionary.Count;
            }
        }

        // Method to check if a word exists
        public bool WordExists(string englishWord)
        {
            lock (_lockObject)
            {
                var wordsDictionary = GetWordsDictionary();
                return wordsDictionary.ContainsKey(englishWord);
            }
        }
    }
}