using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngRusDictionary
{
    class LanguageDictionary
    {
        TranslationDirection _translationDirection = TranslationDirection.EngRus;
        // Решил сделать List вместо Dictionary, чтобы у одного слова могло быть несколько переводов
        List<TranslableWord> _dictionary = new List<TranslableWord>();

        public LanguageDictionary()
        {
        }
        public LanguageDictionary(LanguageDictionary dictionary)
        {
            _dictionary = dictionary.Dictionary.ToList<TranslableWord>();
        }

        internal IReadOnlyList<TranslableWord> Dictionary { get => _dictionary.AsReadOnly(); }

        public void AddTranslation(string word, string translation)
        {
            TranslableWord wordToAdd = null;

            if (FindWordLanguage(word.ToLower()) == 1)
                wordToAdd = new TranslableWord(word, translation);
            else
                wordToAdd = new TranslableWord(translation, word);

            if (_dictionary.Contains(wordToAdd))
                throw new Exception("Слово уже есть в словаре");



            _dictionary.Add(wordToAdd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>1 - eng, 2 - rus</returns>
        private int FindWordLanguage(string word)
        {
            foreach (var item in word)
            {
                if (item >= 'a' && item <= 'z')
                    return 1;
            }
            return 2;
        }
       

        public IEnumerable<string> GetTranslations(string wordToFind)
        {
            if (FindWordLanguage(wordToFind) == 2)
                _translationDirection =  TranslationDirection.RusEng;


            List<string> translations = new List<string>();
            foreach (var word in _dictionary)
            {
                if (_translationDirection == TranslationDirection.EngRus)
                {
                    if (word.Word.ToLower() == wordToFind.ToLower())
                        translations.Add(word.Translation.Word);
                }
                else
                {
                    if (word.Translation.Word.ToLower() == wordToFind.ToLower())
                        translations.Add(word.Word);
                }
            }
            _translationDirection = TranslationDirection.EngRus;
            if (translations.Count == 0)
                throw new Exception("Перевод не найден");
            return translations;
        }
    }
}
