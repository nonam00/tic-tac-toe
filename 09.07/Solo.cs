namespace _09._07;

public class Solo : Game
{
    public Solo() : base()
    {
        int count = 1;
        while (true)
        {
            Thread.Sleep(1500);
            Console.Clear();
            Print();

            string? choice = Console.ReadLine();

            if (CheckArgument(choice))
                continue;

            if (CheckStatus(choice))
                SetBlock(choice, simbol1);
            else
            {
                Console.WriteLine("\nКлетка занята");
                continue;
            }

            Console.Clear();
            Print();

            if (GameOver())
            {
                Console.WriteLine("You won");
                break;
            }

            if (count++ == 5)
            {
                Console.WriteLine("Draw");
                break;
            }

            Thread.Sleep(500);
            Console.Clear();

            Random random = new Random();
            while (true)
            {
                string ran = random.Next(1, 10).ToString();
                if (CheckStatus(ran))
                {
                    SetBlock(ran, simbol2);
                    break;
                }
            }
            Print();

            if (GameOver())
            {
                Console.WriteLine("You lose");
                break;
            }
        }
    }
}