
//Lambda trả về danh sách bình phương
// lọc số chan tu ket quả binh phương
// Sắp xếp kết quả tăng dần và in ra màn hình
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Nhập các số nguyên, cách nhau bởi dấu cách:");
        string input = Console.ReadLine();
        List<int> numbers = input.Split(' ')
                                 .Where(s => int.TryParse(s, out _))
                                 .Select(int.Parse)
                                 .ToList();

        var result = numbers
            .Select(x => x * x)     
            .Where(x => x % 2 == 0)    
            .OrderBy(x => x);           

        Console.WriteLine("Kết quả: " + string.Join(", ", result));
    }
}
