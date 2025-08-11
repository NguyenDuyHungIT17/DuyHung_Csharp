using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Nhập họ tên: ");
        string hoTen = Console.ReadLine();

        char[] chars = hoTen.ToCharArray();

        int start = 0;
        while (start < chars.Length && chars[start] == ' ')
            start++;

        int end = chars.Length - 1;
        while (end >= 0 && chars[end] == ' ')
            end--;

        int spaceIndex = -1;
        for (int i = start; i <= end; i++)
        {
            if (chars[i] == ' ')
            {
                spaceIndex = i;
                break;
            }
        }

        string ho = "";
        for (int i = start; i < spaceIndex; i++)
        {
            ho += chars[i];
        }

        string ten = "";
        int lastSpace = -1;
        for (int i = end; i >= start; i--)
        {
            if (chars[i] == ' ')
            {
                lastSpace = i;
                break;
            }
        }
        for (int i = lastSpace + 1; i <= end; i++)
        {
            ten += chars[i];
        }

        int doDaiTen = 0;
        for (int i = 0; i < ten.Length; i++)
        {
            doDaiTen++;
        }

        Console.WriteLine($"Họ: {ho}");
        Console.WriteLine($"Tên: {ten}");
        Console.WriteLine($"Độ dài tên: {doDaiTen}");
    }
}
