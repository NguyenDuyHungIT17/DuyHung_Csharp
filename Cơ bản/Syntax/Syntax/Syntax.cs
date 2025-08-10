//HelloCSharp: In ra tên.
//ChuyenDoiKieuDuLieu: Chuyển chuỗi "123" sang kiểu số nguyên (int) và kiểu số thực (double).
//KiemTraChanLe: Kiểm tra xem một số là số chẵn hay số lẻ.
//TimSoLonNhat: Nhập vào ba số, tìm và in ra số lớn nhất trong ba số đó.
//BangCuuChuong: Nhập một số n, in ra bảng cửu chương của số đó từ 1 đến 10.
// viết chương trình hiển thị các hàm trên với các option
using System;

class Syntax
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Ten");
            Console.WriteLine("2. Chuyen doi kieu du lieu");
            Console.WriteLine("3. Chan Le");
            Console.WriteLine("4. So Lon nhat");
            Console.WriteLine("5. Bang cuu chuong");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon option: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Vui lòng nhập số hợp lệ!");
                continue;
            }

            switch (choice)
            {
                case 1: HelloCSharp(); break;
                case 2: ChuyenDoiKieuDuLieu(); break;
                case 3: KiemTraChanLe(); break;
                case 4: TimSoLonNhat(); break;
                case 5: BangCuuChuong(); break;
                case 0: return;
                default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
            }
        }
    }

    static void HelloCSharp()
    {
        Console.WriteLine("Nguyen Duy Hung");
    }

    static void ChuyenDoiKieuDuLieu()
    {
        string str = "123";
        int numInt = int.Parse(str);
        double numDouble = double.Parse(str);
        Console.WriteLine($"String: {str}");
        Console.WriteLine($"Int: {numInt}");
        Console.WriteLine($"Double: {numDouble}");
    }

    static void KiemTraChanLe()
    {
        Console.Write("Input number: ");
        if (!int.TryParse(Console.ReadLine(), out int x))
        {
            Console.WriteLine("Giá trị nhập không hợp lệ!");
            return;
        }

        if (x % 2 == 0)
            Console.WriteLine("Even");
        else
            Console.WriteLine("Odd");
    }

    static void TimSoLonNhat()
    {
        int a = NhapSo("Number a: ");
        int b = NhapSo("Number b: ");
        int c = NhapSo("Number c: ");

        int max = a;
        if (b > max) max = b;
        if (c > max) max = c;
        Console.WriteLine($"Largest number: {max}");
    }

    static void BangCuuChuong()
    {
        int n = NhapSo("Input number: ");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{n} x {i} = {n * i}");
        }
    }


    static int NhapSo(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value))
                return value;

            Console.WriteLine("Vui lòng nhập số nguyên hợp lệ!");
        }
    }
}
