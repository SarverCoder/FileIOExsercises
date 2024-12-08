using System.Text;
using System.Text.RegularExpressions;

namespace FileIOExsercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "lorem.txt";
            int fileSizeMb = 100;
            string findWord = "lorem";
            int count = 0;

            if(new FileInfo(path).Length == 0 )
            {
                using (var streamWirter = new StreamWriter(path, false, Encoding.UTF8))
                {
                    Random random = new Random();

                    while(new FileInfo(path).Length < fileSizeMb * 1024 * 1024)
                    {
                        string randomText = GenerateRandomText(random, 100);
                        streamWirter.WriteLine(randomText);
                    }

                }

                Console.WriteLine("Fayl random so'zla bn to'ldirildi ");
            }


            try
            {
                using (var streamReader = new StreamReader(path))
                {
                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        count += Regex.Matches(line, $@"\b{Regex.Escape(findWord)}\b", RegexOptions.IgnoreCase).Count;

                    }
                }
                Console.WriteLine($"So'z '{findWord}' {count}  marta uchradi. va qatnashdi");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }



            

        }
            static string GenerateRandomText(Random random, int count)
            {
                string[] words = { "lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit" };
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < count; i++)
                {
                    sb.Append(words[random.Next(words.Length)]).Append(" ");

                }

                return sb.ToString();
            }
    }
}
