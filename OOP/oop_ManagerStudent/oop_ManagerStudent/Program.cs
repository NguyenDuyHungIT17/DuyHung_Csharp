using oop_ManagerStudent;
using System;

public class program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        List<Nguoi> dsNguoi = new List<Nguoi>();
        dsNguoi.Add(new Student("Nguyễn Văn Hưng", "10A9"));
        dsNguoi.Add(new Student("Trần Thị Sen", "10A1"));
        dsNguoi.Add(new Student("Phạm Văn Da", "11B2"));

        dsNguoi.Add(new Teacher("Nguyễn Duy Hưng", "Toán"));
        dsNguoi.Add(new Teacher("Lê Bá Hoàng", "Văn"));

        Console.WriteLine("=== Thông tin danh sách ===");
        foreach (Nguoi nguoi in dsNguoi)
        {
            nguoi.InThongTin();
        }

        Console.WriteLine("\n=== Hoạt động của từng người ===");
        foreach (Nguoi n in dsNguoi)
        {
            if (n is Interface hd)
            {
                hd.HoatDong();
            }
        }
    }
}