using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
    class Program
    {
        static void Main()
        {

            //string directoryName = Path.GetDirectoryName(typeof(Program).Assembly.Location);

            //Console.WriteLine(directoryName);
            // Solution I manually pushed the tsv file into bin -> Debug -> net6.0 directory which I saw that this file lives in that directory and not the Directory where the namespace is named after

            List<Language> languages = File.ReadAllLines("./languages.tsv")
              .Skip(1)
              .Select(line => Language.FromTsv(line))
              .ToList();

            // Q1
            foreach (var l in languages)
            {
                // Console.WriteLine(l.Prettify());
            }

            // Q2
            var eachLang = languages.Select(l => $"{l.Year}, {l.Name}, {l.ChiefDeveloper}");

            foreach (string l in eachLang)
            {
                //Console.WriteLine(l);
            }

            // Q3
            var cSharpFound = from x in languages
                              where x.Name.Contains("C#")
                              select x;

            foreach (var l in cSharpFound)
            {
                Console.WriteLine(l.Prettify());
            }
            Console.WriteLine();

            // Q4
            var langByMicrosoft = languages.Where(x => x.ChiefDeveloper.Contains("Microsoft"));

            Console.WriteLine("Numbs of languages invented by Microsoft: " + langByMicrosoft.Count().ToString());
            // removed the foreach use the PrettyPrintAll() instead
            // PrettyPrintAll(langByMicrosoft);
            Console.WriteLine();

            // Q5
            var fromLisp = languages.Where(x => x.Predecessors.Contains("Lisp"));
            Console.WriteLine("Numbs of langugaes inspired by Lisp: " + fromLisp.Count().ToString());

            // for Q10 we removed the foreach we will test the PrettyPrintAll() method instead.
            // PrettyPrintAll(fromLisp);
            // So any foreach in the code with the DataType Language we can use the method PrettyPrintAll()!!

            Console.WriteLine();

            // Q6
            var scriptLangs = languages.Where(x => x.Name.Contains("Script"));

            Console.WriteLine("Numbs of languages with the name \"Script\" in their name: " + scriptLangs.Count().ToString());
            // removed foreach use PrettyPrintAll() method instead
            // PrettyPrintAll(scriptLangs);
            Console.WriteLine();

            // Q7
            Console.WriteLine("All languages in this DB: " + languages.Count.ToString());
            // PrettyPrintAll(languages);

            // Q8 upto Where then Q9 for Select
            var between95And05 = languages
                        .Where(l => l.Year >= 1995 && l.Year <= 2005)
                        .Select(l => $"{l.Name} was invented in {l.Year}");

            Console.WriteLine("All languages that came out between 1995 and 2005: " + between95And05.Count().ToString());
            // Q11 test PrintAll() we can use it for all as it is IEnumerable<Object> 
            // PrintAll(between95And05);
            Console.WriteLine();

            // Q12 OrderBy Method and Min() method
            var order = languages.OrderBy(lang => lang.Name).ToList();
            PrettyPrintAll(order);
            int oldest = languages.Min(old => old.Year);
            Console.WriteLine();
            Console.WriteLine(oldest);

            

        }

        // Q10
        public static void PrettyPrintAll(IEnumerable<Language> langs)
        {
            foreach (Language lang in langs)
            {
                Console.WriteLine(lang.Prettify());
            }
        }

        // Q11
        public static void PrintAll(IEnumerable<Object> obj)
        {
            foreach (Object o in obj)
            {
                Console.WriteLine(o);
            }
        }
    }
}
