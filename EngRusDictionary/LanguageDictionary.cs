using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngRusDictionary
{
    class LanguageDictionary
    {
        TranslationDirection _translationDirection;
        // Решил сделать List вместо Dictionary, чтобы у одного слова могло быть несколько переводов
        List<TranslableWord> _dictionary = new List<TranslableWord>() 
        {
            {new TranslableWord("Russia", "Россия") },
            {new TranslableWord("Russia", "Не Россия") }
        };

        public LanguageDictionary(TranslationDirection translationDirection)
        {
            _translationDirection = translationDirection;
        }
        public LanguageDictionary(LanguageDictionary dictionary, TranslationDirection translationDirection)
        {
            _dictionary = Dictionary;
            _translationDirection = translationDirection;
        }

        internal List<TranslableWord> Dictionary { get => _dictionary; set => _dictionary = value; }

        public void AddTranslation(string word, string translation)
        {
            TranslableWord wordToAdd = null;
            word = word.ToLower();
            translation = translation.ToLower();

            if (FindWordLanguage(word) == 1)
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
        
        public void SwitchTranslationDirection()
        {
            if (_translationDirection == TranslationDirection.EngRus)
                _translationDirection = TranslationDirection.RusEng;
            else
                _translationDirection = TranslationDirection.EngRus;
        }

        public IEnumerable<string> GetTranslations(string wordToFind)
        {
            wordToFind = wordToFind.ToLower();
            if (FindWordLanguage(wordToFind) == 2 && _translationDirection == TranslationDirection.EngRus)
                SwitchTranslationDirection();


            List<string> translations = new List<string>();
            foreach (var word in _dictionary)
            {
                if (_translationDirection == TranslationDirection.EngRus)
                {
                    if (word.Word == wordToFind)
                        translations.Add(word.Translation.Word);
                }
                else
                {
                    if (word.Translation.Word == wordToFind)
                        translations.Add(word.Word);
                }
            }

            if(translations.Count == 0)
                throw new Exception("Перевод не найден");
            return translations;
        }
    }
}
