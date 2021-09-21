using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngRusDictionary
{
    enum TranslationDirection
    {
        RusEng,
        EngRus
    }
    class TranslableWord
    {
        string _word;
        TranslableWord _translation;

        public TranslableWord(string word, string translation, string description = null)
        {
            _word = word;
            _translation = new TranslableWord(translation, this);
        }
        private TranslableWord(string word, TranslableWord translation)
        {
            _word = word;
            _translation = translation;
        }

        public string Word { get => _word; }
        internal TranslableWord Translation { get => _translation; }
    }
}
