namespace _09._07;
public class Game
{
    protected string simbol1;
    protected string simbol2;

    protected Dictionary<string, List<int>> keys = new Dictionary<string, List<int>>()
    {
        {"1", new List<int>{0,0} },
        {"2", new List<int>{0,1} },
        {"3", new List<int>{0,2} },
        {"4", new List<int>{1,0} },
        {"5", new List<int>{1,1} },
        {"6", new List<int>{1,2} },
        {"7", new List<int>{2,0} },
        {"8", new List<int>{2,1} },
        {"9", new List<int>{2,2} }
    };

    protected Block[,] blocks = new Block[3, 3];

    public Game()
    {
        Random rnd = new Random();
        int coin = rnd.Next(0,2);
        if (coin == 1)
        {
            simbol1 = "X";
            simbol2 = "O";
        }
        else
        {
            simbol1 = "O";
            simbol2 = "X";
        }
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                blocks[i, j] = new Block();
    }
    protected void Print()
    {
        Console.WriteLine($"Ваш символ - {simbol1}\n\n");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($" {blocks[i, j].Value} |");
            }
            Console.WriteLine("\n------------");
        }
    }
    protected bool CheckStatus(string num) =>
         Convert.ToInt32(num) > 0 && Convert.ToInt32(num) <= 9 && blocks[keys[num][0], keys[num][1]].Status;
    protected void SetBlock(string num, string simbol)
    {
        blocks[keys[num][0], keys[num][1]].Set(simbol);
    }
    protected bool GameOver() =>

            (blocks[0, 0].Value == blocks[0, 1].Value && blocks[0, 1].Value == blocks[0, 2].Value) ||
            (blocks[1, 0].Value == blocks[1, 1].Value && blocks[1, 1].Value == blocks[1, 2].Value) ||
            (blocks[2, 0].Value == blocks[2, 1].Value && blocks[2, 1].Value == blocks[2, 2].Value) ||

            (blocks[0, 0].Value == blocks[1, 0].Value && blocks[1, 0].Value == blocks[2, 0].Value) ||
            (blocks[0, 1].Value == blocks[1, 1].Value && blocks[1, 1].Value == blocks[2, 1].Value) ||
            (blocks[0, 2].Value == blocks[1, 2].Value && blocks[1, 2].Value == blocks[2, 2].Value) ||

            (blocks[0, 0].Value == blocks[1, 1].Value && blocks[1, 1].Value == blocks[2, 2].Value) ||
            (blocks[0, 2].Value == blocks[1, 1].Value && blocks[1, 1].Value == blocks[2, 0].Value);

    protected bool Draw()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (blocks[i, j].Status == true)
                    return false;
            }
        }
        return true;
    }
    protected bool CheckArgument(string input) => input.Length != 1 || input[0] < '1' || input[0] > '9'; 
}
