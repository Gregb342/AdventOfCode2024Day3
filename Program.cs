using System.Text.RegularExpressions;

namespace AdventOfCode2024Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "input.txt");

            int result = 0;

            // parcourir le fichier avec un streamreader
            using (StreamReader sr = new StreamReader(path))
            {
                // repérer uniquement les éléments qui ont ce format là "mul(xxx1,xxx2)"
                string regexPattern = @"mul\(\d{1,3},\d{1,3}\)";

                Regex regex = new Regex(regexPattern);

                MatchCollection match = regex.Matches(sr.ReadToEnd());
                string[] numbers;

                foreach (Match m in match)
                {
                    // pour chaque élément repéré, calcul xxx1 * xxx2
                    string value = m.ToString().Remove(m.Length - 1).Remove(0, 4);
                    numbers = value.Split(',').ToArray();

                    int multiply = Int32.Parse(numbers[0]) * Int32.Parse(numbers[1]);
                    // ajouter le résultat à une variable finale
                    result += multiply;
                }
            }

            // retourner la variable finale.
            Console.WriteLine(result.ToString());
        }
    }
}
