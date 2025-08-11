using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        XuLyHoTen();
        TinhTuoi();
        ChiaSo();
        Console.WriteLine("\n=== Chương trình kết thúc ===");
    }

    static void XuLyHoTen()
    {
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

        int lastSpace = -1;
        for (int i = end; i >= start; i--)
        {
            if (chars[i] == ' ')
            {
                lastSpace = i;
                break;
            }
        }

        string ten = "";
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


    static void TinhTuoi()
    {
        Console.Write("\nNhập ngày sinh (dd/MM/yyyy): ");
        string ngaySinhStr = Console.ReadLine();
        char[] nsChars = ngaySinhStr.ToCharArray();

        int ngay = (nsChars[0] - '0') * 10 + (nsChars[1] - '0');
        int thang = (nsChars[3] - '0') * 10 + (nsChars[4] - '0');
        int nam = (nsChars[6] - '0') * 1000 + (nsChars[7] - '0') * 100 + (nsChars[8] - '0') * 10 + (nsChars[9] - '0');

        DateTime now = DateTime.Now;
        int tuoi = now.Year - nam;
        if (now.Month < thang || (now.Month == thang && now.Day < ngay))
        {
            tuoi--;
        }

        Console.WriteLine($"Tuổi: {tuoi}");
    }


    static void ChiaSo()
    {
        try
        {
            Console.Write("\nNhập số bị chia: ");
            int so1 = ChuyenChuoiThanhSoNguyen(Console.ReadLine());

            Console.Write("Nhập số chia: ");
            int so2 = ChuyenChuoiThanhSoNguyen(Console.ReadLine());

            if (so2 == 0)
            {
                throw new DivideByZeroException("Không thể chia cho 0!");
            }

            double ketQua = (double)so1 / so2;
            Console.WriteLine($"Kết quả: {ketQua}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Lỗi: Bạn phải nhập số nguyên hợp lệ!");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi không xác định: {ex.Message}");
        }
    }


    static int ChuyenChuoiThanhSoNguyen(string str)
    {
        if (string.IsNullOrEmpty(str))
            throw new FormatException();

        int ketQua = 0;
        bool am = false;
        int i = 0;

        if (str[0] == '-')
        {
            am = true;
            i = 1;
        }

        for (; i < str.Length; i++)
        {
            if (str[i] < '0' || str[i] > '9')
                throw new FormatException();

            ketQua = ketQua * 10 + (str[i] - '0');
        }

        return am ? -ketQua : ketQua;
    }
}
