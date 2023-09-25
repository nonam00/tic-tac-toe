using _09._07;

Game game;
Console.WriteLine(
        "Выберете режим игры:\n" +
        "Solo - игра против бота\n" +
        "Duo - игра на двоих\n"
        );
try
{
    string? choice = Console.ReadLine();
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