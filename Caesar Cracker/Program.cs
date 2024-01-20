using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        string[] wordlist;
        const string ALPHABET = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";
        Console.Title = "Caesar cracker";
        try
        {
            wordlist = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "wordlist.txt"));
            while (true)
            {
                Console.WriteLine("Warum auch immer gibt das Programm neben dem entschlüsselten string");
                Console.WriteLine("einen haufen Müll aus ich weiss nicht warum und ich will es auch nicht wissen");
                Console.Write("Enter encrypted string: ");
                string input = Console.ReadLine().ToLower().Replace(".", "").Replace(",", "").Replace("!", "").Replace("?", "").Replace("-", "");
                bool found = false;
                while(!found)
                {
                    int solutionid = 0;
                    for(int i = 1; i < 26; i++)
                    {
                        string converted = "";
                        int id = 0;
                        for (int j = 0; j < input.Length; j++)
                        {
                            for(int k = 0; k < 26; k++)
                            {
                                if (input[j] == ALPHABET[k])
                                {
                                    id = k;
                                    break;
                                }
                            }
                            converted += ALPHABET[id + i];
                        }
                        for(int k = 0;k < wordlist.Length; k++)
                        {
                            if (converted.Contains(wordlist[k]))
                            {
                                solutionid = id;
                                found = true;
                                if (found) Console.WriteLine(converted);
                                break;
                            }
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("wordlist.txt not found!");
            Console.ResetColor();
            Console.ReadKey();
        }
        
    }
}