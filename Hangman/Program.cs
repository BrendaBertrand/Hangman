namespace Hangman;

class Program
{
    static readonly List<string> WORDS_LIST = new List<string>() { "subway", "swivel", "syndrome", "thriftless" };
    private static readonly Random rng = new Random();
    private static readonly string MAGIC_WORD = WORDS_LIST[rng.Next(0, WORDS_LIST.Count)].ToUpper();
    private const int MAX_ERRORS = 5;

    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to your Hangman Game!");
        //Next line should be removed in the final version
        Console.WriteLine($"The chosen word is : {MAGIC_WORD}");
       
        Console.WriteLine("\nHere is your word : ");
        List<char> displayedWord = new List<char>();
        for (int i = 0; i < MAGIC_WORD.Length; i++)
        {
            displayedWord.Add('_');
        }

        List<char> wrongLetters = new List<char>();
        do
        {
            displayedWord.ForEach(letter => Console.Write($"{letter} "));
            if (wrongLetters.Count > 0)
            {
                Console.Write("\nWrong letters : ");
                wrongLetters.ForEach(letter => Console.Write($"{letter} "));
            }

            if (!displayedWord.Contains('_'))
            {
                Console.WriteLine("\n\nCongratulations! You won!\n");
                break;
            }

            if (wrongLetters.Count >= MAX_ERRORS)
            {
                Console.WriteLine("\n\nGAME OVER");
                Console.Write($"\nThe word was : {MAGIC_WORD}\n");
                break;
            }


            Console.Write("\n\nNext letter : ");
            char userTry = Char.ToUpper(Console.ReadKey().KeyChar);


            if (wrongLetters.Contains(userTry) || displayedWord.Contains(userTry))
            {
                Console.Clear();
                Console.WriteLine("You already submitted this character\n");
                continue;
            }

            if (MAGIC_WORD.Contains(userTry))
            {
                for (int i = 0; i < MAGIC_WORD.Length; i++)
                {
                    if (MAGIC_WORD[i] == userTry)
                    {
                        displayedWord[i] = userTry;
                    }
                }
            }
            else
            {
                wrongLetters.Add(userTry);
            }


            Console.Clear();
        } while (true);
    }
}