namespace _09._07;
public class Block
{
    public string Value { get; set; }
    public bool Status { get; set; }

    private static int count;
    public Block()
    {
        Value = count++.ToString();
        Status = true;
    }

    static Block() => count = 1;

    public void Set(string value)
    {
        Value = value;
        Status = false;
    }
}