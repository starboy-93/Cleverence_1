using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Channels;

class StringCompression
{
    public static string CompressString(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        StringBuilder compressed = new StringBuilder();
        char currentChar = input[0];
        int count = 1;

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == currentChar)
            {
                count++;
            }
            else
            {
                compressed.Append(currentChar);
                if (count > 1)
                    compressed.Append(count);
                currentChar = input[i];
                count = 1;
            }
        }

        compressed.Append(currentChar);
        if (count > 1)
            compressed.Append(count);

        return compressed.ToString();
    }

    public static string DecompressString(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        StringBuilder decompressed = new StringBuilder();

        for (int i = 0; i < input.Length;)
        {
            char c = input[i];
            i++;

            string countString = "";
            while (i < input.Length && char.IsDigit(input[i]))
            {
                countString += input[i];
                i++;
            }

            int count = countString.Length > 0 ? int.Parse(countString) : 1;

            for (int j = 0; j < count; j++)
            {
                decompressed.Append(c);
            }
        }

        return decompressed.ToString();
    }

    static bool ContainsNumber(string input)
    {
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }


    static void Main()
    {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();
            string compressedString = "";
            string decompressedString = "";

            var result = ContainsNumber(input) ? decompressedString = DecompressString(input) : compressedString = CompressString(input);
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Вы ничего не ввели");
            else if (result == input)
                Console.WriteLine($"Ваша строка не содержит цифр или повторяющихся символов и осталась неизменной: {input}");
            else
                Console.WriteLine($"Строка после преобразования: {result}");
    }
}