using System.Text;

namespace ComeForBrainsSadConsoleUi.Service;

public static class TextWraper
{
    public static string[] Wrap(this string str, int width)
    {
        List<string> result = new();
        string[] lines = str.Split("\n");
        foreach (var line in lines)
        {
            string[] words = line.Split(" ");
            if (words.Length == 0)
                continue;

            StringBuilder builder = new(words[0]);
            for (int i = 1; i < words.Length; i++)
            {
                while(builder.Length > width)
                {
                    result.Add(builder.ToString()[..width]);
                    builder = new(builder.ToString()[width..]);
                }

                string word = words[i];
                if (builder.Length + word.Length + 1 > width)
                {
                    result.Add(builder.ToString());
                    builder = new(word);
                }
                else                
                    builder.Append(' ').Append(word);
            }
            result.Add(builder.ToString());
        }
        return result.ToArray();
    }
}
