using System;

internal class Program
{
    class Block
    {
        private string value;
        private bool status;

        private static int count;
        public Block()
        {
            value = count++.ToString();
            status = true;
        }

        static Block()
        {
            count = 1;
        }

        public void Set(string value)
        {
            this.value = value;
            status = false;
        }

        public string Value
        {
            get { return value; }
            set { Value = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }

    class Game
    {
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
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    blocks[i, j] = new Block();
        }
        protected void Print()
        {
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
             Convert.ToInt32(num) > 0 && Convert.ToInt32(num) <= 9 && blocks[ keys [num][0], keys[num][1]].Status;
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
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    if (blocks[i, j].Status == true)
                        return false;
                }
            }
            return true;
        }
    }

    class Solo : Game
    {
        public Solo() : base()
        {
            int count = 1;
            while(true)
            {
                Thread.Sleep(1500);
                Console.Clear();
                Print();

                string choice = Console.ReadLine();
                if (CheckStatus(choice))
                    SetBlock(choice, "X");
                else
                {
                    Console.WriteLine("\nError");
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
                while(true)
                {
                    string ran = random.Next(1,10).ToString();
                    if (CheckStatus(ran))
                    {
                        SetBlock(ran, "O");
                        break;
                    }
                }
                Print();
            
                if(GameOver())
                {
                    Console.WriteLine("You lose");
                    break;
                }
            }
        }
    }

    class Duo : Game
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
                if (CheckStatus(choice1))
                    SetBlock(choice1, "X");
                else
                {
                    Console.WriteLine("\nError");
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
                if (CheckStatus(choice2))
                    SetBlock(choice2, "O");
                else
                {
                    Console.WriteLine("\nError");
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


    private static void Main(string[] args)
    {

        Game game;
        try
        {
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "Solo":
                    game = new Solo();
                    break;
                case "Duo":
                    game = new Duo();
                    break;
                default:
                    throw new Exception("Error");
            }
        }
        catch(Exception ex) { Console.WriteLine(ex.Message); }
    }
}