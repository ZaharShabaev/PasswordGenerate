namespace PasswordGenerator.Extensions;

public class PasswordGeneratoros
{

    private IList<char> _chars = new List<char>()
    {
        'q', 'w', 'e', 'r', 't', 's', 'y'
    };

    private IList<int> _ints = new List<int>()
    {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9
    };
    
    private IList<string> _symbol = new List<string>()
    {
        "-", "+", "/", "&", "$", "@" 
    };
    
    public string GeneratePassword(DfPass difficult, int lenght)
    {
        switch (difficult)
        {
            case DfPass.Easy:
                return GenerateEasy(lenght);
            case DfPass.Medium:
                return GenerateMiddle(lenght);
            case DfPass.Hard:
                return GenerateHard(lenght);
                default:
                throw new ArgumentOutOfRangeException(nameof(difficult), difficult, null);
        }

        return string.Empty;
    }

    private string GenerateEasy(int lenght)
    {
        string pwd = string.Empty;
        
        for (int i = 0; i < lenght; i++)
        {
            pwd += _ints[new Random().Next(0, _ints.Count)];
        }

        return pwd;
    }

    private string GenerateMiddle(int lenght)
    {
        string pwd = string.Empty;
        
        for (int i = 0; i < lenght; i++)
        {
            pwd += _ints[new Random().Next(0, _ints.Count)];
            pwd += _chars[new Random().Next(0, _chars.Count)];
        }

        pwd = Shuffle(pwd);
        
        return pwd.Substring(lenght);
    }

    
    private string GenerateHard(int lenght)
    {
        string pwd = string.Empty;
        
        for (int i = 0; i < lenght; i++)
        {
            pwd += _ints[new Random().Next(0, _ints.Count)];
            pwd += _chars[new Random().Next(0, _chars.Count)];
            pwd += _symbol[new Random().Next(0, _symbol.Count)];
        }

        pwd = Shuffle(pwd);
        
        return pwd.Substring(lenght);
    }
    
    public string Shuffle(string str)
    {
        char[] array = str.ToCharArray();
        Random rng = new Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (array[k], array[n]) = (array[n], array[k]);
        }

        return new string(array);
    }
}