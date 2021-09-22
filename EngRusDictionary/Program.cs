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
            LanguageDictionary dictionary = new LanguageDictionary();
            dictionary.AddTranslation("Россия", "Russia");
            dictionary.AddTranslation("Америка", "America");
            dictionary.AddTranslation("США", "America");
            dictionary.AddTranslation("USA", "Америка");
            dictionary.AddTranslation("Китай", "China");
            
            foreach (var translation in dictionary.GetTranslations("Россия"))
            {
                Console.WriteLine($"Россия - {translation}");
            }
            Console.WriteLine();

            foreach (var translation in dictionary.GetTranslations("America"))
            {
                Console.WriteLine($"America - {translation}");
            }
            Console.WriteLine();

            foreach (var translation in dictionary.GetTranslations("Америка"))
            {
                Console.WriteLine($"Америка - {translation}");
            }
            Console.WriteLine();

            Console.ReadKey(); 
        }
    }
}
