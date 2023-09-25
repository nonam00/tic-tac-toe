namespace _09._07;

public class Duo : Game
{
    public Duo() : base()
    {
        int count = 1;
        while (true)
        {
            Thread.Sleep(1500);
            Console.Clear();
            Print();

            string choice1 = Console.ReadLine();

            if (CheckArgument(choice1))
                continue;

            if (CheckStatus(choice1))
                SetBlock(choice1, simbol1);
            else
            {
                Console.WriteLine("\nКлетка занята");
                continue;
            }

            Console.Clear();
            Print();

            if (GameOver())
            {
                Console.WriteLine("Player 1 won");
                break;
            }
            if (count++ == 5)
            {
                Console.WriteLine("Draw");
                break;
            }
            string choice2 = Console.ReadLine();

            if (CheckArgument(choice2))
                continue;

            if (CheckStatus(choice2))
                SetBlock(choice2, simbol2);
            else
            {
                Console.WriteLine("\nКлетка занята");
                continue;
            }

            Console.Clear();
            Print();

            if (GameOver())
            {
                Console.WriteLine("Player 2 won");
                break;
            }
        }
        count = 0;
    }
}