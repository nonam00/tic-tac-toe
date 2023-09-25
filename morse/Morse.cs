using System.Net.Security;

namespace morse;

public class Morse
{
    private static readonly Dictionary<string, string> morseAlphabet = new Dictionary<string, string>()
    {
        { "A", ".-" },
        { "B", "-..." },
        { "C", "-.-." },
        { "D", "-.." },
        { "E", "." },
        { "F", "..-." },
        { "G", "--." },
        { "H", "...." },
        { "I", ".." },
        { "J", ".---" },
        { "K", "-.-" },
        { "L", ".-.." },
        { "M", "--" },
        { "N", "-." },
        { "O", "---" },
        { "P", ".--." },
        { "Q", "--.-" },
        { "R", ".-." },
        { "S", "..." },
        { "T", "-" },
        { "U", "..-" },
        { "V", "...-" },
        { "W", ".--" },
        { "X", "-..-" },
        { "Y", "-.--" },
        { "Z", "--.." },

        { "1", ".----"},
        { "2", "..---" },
        { "3", "...--" },
        { "4", "....-" },
        { "5", "....."},
        { "6", "-...."},
        { "7", "--..."},
        { "8", "---.."},
        { "9", "----."},
        { "0", "-----"},

        { " ", "/"}
    };
    public static string Encryption(string? input)
    {
        input = input.ToUpper();
        string encrypted = String.Empty;
        for(int i=0; i<input.Length; i++)
        {
            if (!morseAlphabet.ContainsKey(input[i].ToString()))
                throw new ArgumentException("Неверный формат ввода, строка содержит символы, неподдерживающиеся азбукой морзе");
            encrypted += morseAlphabet[input[i].ToString()] + " ";
        }    
        return encrypted;
    }

    public static string Decription(string? input)
    {
        string[] simbols = input.Split(' ');
        string decripted = String.Empty;
        for(int i=0; i<simbols.Length; i++)
        {
            if (!morseAlphabet.ContainsValue(simbols[i]))
                throw new ArgumentException("Неверный формат ввода, строка содержит символы, неподдерживающиеся азбукой морзе");
            decripted += morseAlphabet.FirstOrDefault(x => x.Value == simbols[i]).Key;
        }
        return decripted;
    }

}
