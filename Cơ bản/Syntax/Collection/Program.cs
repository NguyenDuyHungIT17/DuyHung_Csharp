//Quản lý danh sách tên (List<string>), nhập đến khi "end".
//Tìm kiếm tên trong List<string> và in vị trí.
//Từ điển  (Dictionary<string, string>) cho phép tra nghĩa.
//Đếm số lần xuất hiện của mỗi số trong mảng bằng Dictionary<int, int>.
//Lọc số > 10 trong List<int>.

using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
public class Collection()
{
    static void Main()
    {

        List<string> names = nhapDanhSachTen();
        Console.Write("Danh sach ten: ");
        inListString(names);

        timKiemTen(names);

        tuDien();

        int[] numbers = { 1, 2, 5, 2, 3, 5, 1, 5, 10, 2 };
        Console.WriteLine("Array: " + string.Join(", ", numbers));

        demSoLanXuatHien(numbers);

        List<int> listNumbers = new List<int> { 5, 12, 7, 20, 15, 3 };
        locSoLonHon10(listNumbers);
    }

   
    static List<string> nhapDanhSachTen()
    {
        List<string> names = new List<string>();
        while (true)
        {
            Console.Write("Nhap ten (end -> dung): ");
            string input = Console.ReadLine();
            if (input != null && input.ToLower() == "end")
                break;
            if (!string.IsNullOrWhiteSpace(input))
                names.Add(input);
        }
        return names;
    }

    static void inListString(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i]);
            if (i < list.Count - 1)
                Console.Write(", ");
        }
        Console.WriteLine();
    }

    static void timKiemTen(List<string> names)
    {
        Console.Write("Nhap ten can tim: ");
        string tenCanTim = Console.ReadLine();
      
        int viTri = -1;
        for (int i = 0; i < names.Count; i++)
        {
            if (names[i] == tenCanTim)
            {
                viTri = i;
                break;
            }
        }

        if (viTri != -1)
            Console.WriteLine($"Ten '{tenCanTim}' o {viTri}");
        else
            Console.WriteLine($"Khong tim thay '{tenCanTim}'");
    }

    static void tuDien()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            { "hello", "xin chào" },
            { "cat", "con mèo" },
            { "dog", "con chó" }
        };

        Console.Write("Tu can tra: ");
        string word = Console.ReadLine();

        bool found = false;
        foreach (var pair in dictionary)
        {
            if (pair.Key == word)
            {
                Console.WriteLine($"Nghia '{word}' la: {pair.Value}");
                found = true;
                break;
            }
        }

        if (!found)
            Console.WriteLine("Khong tim thay");
    }

    static void demSoLanXuatHien(int[] arr)
    {
        Dictionary<int, int> countMap = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            bool existed = false;
            foreach (var key in countMap.Keys)
            {
                if (key == arr[i])
                {
                    countMap[key]++;
                    existed = true;
                    break;
                }
            }
            if (!existed)
            {
                countMap[arr[i]] = 1;
            }
        }

        Console.WriteLine("So lan xuat hien:");
        foreach (var pair in countMap)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value} lan");
        }
    }

    static void locSoLonHon10(List<int> numbers)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > 10)
                result.Add(numbers[i]);
        }

        Console.Write("So > 10: ");
        for (int i = 0; i < result.Count; i++)
        {
            Console.Write(result[i]);
            if (i < result.Count - 1)
                Console.Write(", ");
        }
        Console.WriteLine();
    }
}