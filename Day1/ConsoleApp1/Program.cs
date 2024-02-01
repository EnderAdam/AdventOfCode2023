using System.IO;
using System.Text.RegularExpressions;

namespace test
{
    internal class Day1
    {
        private static void MainPart1(string[] args)
        {
            try
            {
                int result = 0;


                String line;
                StreamReader sr = new("C:\\Users\\thasa\\source\\repos\\Advent\\Day1\\ConsoleApp1\\input.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    var lineArray = line.Where(Char.IsDigit).ToArray();
                    if (lineArray.Length > 0)
                    {
                        //get last and first elements
                        var first = lineArray[0];
                        var last = lineArray[lineArray.Length - 1];
                        var appendedResult = new String(first + "" + last);
                        Console.WriteLine(appendedResult);
                        result = result + Int32.Parse(appendedResult);
                    }
                    line = sr.ReadLine();
                }

                sr.Close();
                Console.WriteLine(result);

            }
            catch
            {
                Console.WriteLine("error");
            }
        }
        private static void Main(string[] args)
        {
            try
            {
                long result = 0;


                var answer = File.ReadAllLines("C:\\Users\\thasa\\source\\repos\\Advent\\Day1\\ConsoleApp1\\input.txt");
                List<String> nums = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

                foreach (String line in answer)
                {
                    String line2 = line;
                    foreach (String elem in nums)
                    {
                        line2 = line2.Replace(elem, elem+nums.IndexOf(elem) + elem);
                    }
                    //Console.WriteLine(line2);

                    var lineArray = line2.Where(Char.IsDigit).ToArray();
                    if (lineArray.Length > 0)
                    {
                        //get last and first elements
                        var first = lineArray[0];
                        var last = lineArray[^1];
                        var appendedResult = new String(first + "" + last);
                        Console.WriteLine(appendedResult);
                        result = result + Int32.Parse(appendedResult);
                    }
                }

                Console.WriteLine(result);

            }
            catch
            {
                Console.WriteLine("error");
            }
        }
    }
}