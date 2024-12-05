using System.Text.RegularExpressions;

namespace AdventOfCode2024Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "input.txt");

            int result = 0;
            int result2 = 0;

            // parcourir le fichier avec un streamreader
            using (StreamReader sr = new StreamReader(path))
            {
                // repérer uniquement les éléments qui ont ce format là "mul(xxx1,xxx2)"
                string regexPattern = @"mul\(\d{1,3},\d{1,3}\)";
                string secondRegexPattern = @"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)";

                Regex regex = new Regex(regexPattern);
                Regex secondRegex = new Regex(secondRegexPattern);
               
                string content = sr.ReadToEnd();

                MatchCollection match = regex.Matches(content);
                MatchCollection match2 = secondRegex.Matches(content);
                string[] numbers;

                bool isDo = true;

                foreach (Match m in match2)
                {
                    if (m.Value == "do()")
                    {
                        isDo = true;
                    }

                    if (m.Value == "don't()")
                    {
                        isDo = false;
                        continue;
                    }

                    if (m.Value.Contains("mul") && isDo)
                    {
                        string value = m.ToString().Remove(m.Length - 1).Remove(0, 4);
                        numbers = value.Split(',').ToArray();
                        int multiply = Int32.Parse(numbers[0]) * Int32.Parse(numbers[1]);
                        result2 += multiply;
                    }
                }

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
            //retourner la variable finale.
            Console.WriteLine(result.ToString());

            Console.Write(result2.ToString());
        }
    }
}
