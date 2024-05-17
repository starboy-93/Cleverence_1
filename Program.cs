using System;
using System.Text;

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


    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();
        string compressedString = "";
        string decompressedString = "";
        Console.WriteLine("Выберите пункт:\n 1. Сжать строку \n 2. Развернуть строку");
        int choice = int.Parse(Console.ReadLine());
        Console.WriteLine("Оригинальная строка " + input);
        switch (choice)
            { 
            case 1:
                compressedString = CompressString(input);
                Console.WriteLine("Сжатая строка: " + compressedString);
                break;
            case 2:
                decompressedString = DecompressString(input);
                Console.WriteLine("Расвернутая строка: " + decompressedString);
                break;
            default:
                Console.WriteLine("Вашего выбора нет в списке");
                break;

            }
    }
}