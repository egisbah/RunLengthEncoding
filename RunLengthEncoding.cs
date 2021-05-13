using System;
using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        var encodedString = new StringBuilder();
        int letterCount = 1;
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        for (int i = 0; i < input.Length; i++)
        {
            if (i + 1 < input.Length && input[i] == input[i + 1])
            {
                letterCount++;
                continue;
            }
            if (letterCount > 1)
            {
                encodedString.Append(letterCount);
            }
            encodedString.Append(input[i]);
            letterCount = 1;
        };
        return encodedString.ToString();
    }

    public static string Decode(string input)
    {
        string charCount = "";
        var decodedMessage = new StringBuilder();
        foreach (var member in input)
        {
            if (char.IsDigit(member))
            {
                charCount += member;
            }
            else
            {
                if (charCount == string.Empty)
                {
                    decodedMessage.Append(member);
                }
                else
                {
                    int count = int.Parse(charCount);
                    string continousLetters = new string(member, count);
                    decodedMessage.Append(continousLetters);
                    charCount = "";
                }
            }
        }
        return decodedMessage.ToString();
    }
}
