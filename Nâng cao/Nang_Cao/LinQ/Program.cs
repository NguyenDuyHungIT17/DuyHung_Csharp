using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        List<int> numbers = new List<int> { 1, 2, 6, 8, 3, 10, 4, 5 };
        Console.WriteLine("Mảng ban đầu: ");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i] + " ");
        }

        var evenNumbers = numbers.Where(n => n % 2 == 0);

        var grouped = evenNumbers
            .GroupBy(n => n > 5 ? "Lớn hơn 5" : "Nhỏ hơn hoặc bằng 5")
            .OrderBy(g => g.Key); 

        foreach (var group in grouped)
        {
            Console.WriteLine($"\nNhóm: {group.Key}");
            foreach (var number in group.OrderBy(n => n)) 
            {
                Console.Write($"  {number}");
            }
        }
    }
}