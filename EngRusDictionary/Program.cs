using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngRusDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Я не стал делать пользовательский интерфейс, а то я так никогда не закрою все домашки
            LanguageDictionary dictionary = new LanguageDictionary(TranslationDirection.EngRus);
            dictionary.AddTranslation("Apple company", "огрызок");
            dictionary.AddTranslation("apple", "яблоко");
            dictionary.AddTranslation("слово", "word");
            dictionary.AddTranslation("огрызок", "apple core");
            
            foreach (var translation in dictionary.GetTranslations("APPLE"))
            {
                Console.WriteLine($"apple - {translation}");
            }
            
            //dictionary.SwitchTranslationDirection();
            foreach (var translation in dictionary.GetTranslations("Огрызок"))
            {
                Console.WriteLine($"огрызок - {translation}");
            }
            Console.ReadKey(); 
        }
    }
}
