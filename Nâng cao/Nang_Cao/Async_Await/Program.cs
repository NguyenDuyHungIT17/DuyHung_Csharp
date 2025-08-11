using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; 

        Console.WriteLine("=== DỮ LIỆU SINH VIÊN FINT ===");

        await KetNoiMayChu();
        var data = await LayDuLieuSinhVien();
        await XuLyDuLieu(data);

        Console.WriteLine("\n===DONE!===");
    }

    static async Task KetNoiMayChu()
    {
        Console.WriteLine("---------- Đang kết nối đến máy chủ...------------");
        await Task.Delay(2000);
        Console.WriteLine("---------- Kết nối thành công! ----------");
    }

    static async Task<List<(string MSSV, string HoTen, double DiemTB)>> LayDuLieuSinhVien()
    {
        string connectionString =
            "Server=localhost;Database=FINT_STUDENT;User Id=sa;Password=Duyhung@18022004sqlserver;TrustServerCertificate=True;";

        var dsStudent = new List<(string, string, double)>();

        Console.WriteLine("-----------  Đang tải ----------- ");

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            await conn.OpenAsync();

            string sql = "SELECT MSSV, HoTen, DiemTB FROM students";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    string mssv = reader.GetString(0);
                    string hoTen = reader.GetString(1);
                    double diemTB = reader.GetDouble(2);

                    dsStudent.Add((mssv, hoTen, diemTB));
                }
            }
        }

        Console.WriteLine("----------- Tải dữ liệu xong! ---------");
        return dsStudent;
    }

    static async Task XuLyDuLieu(List<(string MSSV, string HoTen, double DiemTB)> data)
    {
        Console.WriteLine("-----------  Đang xử lý dữ liệu... ----------- ");
        await Task.Delay(1500);

        Console.WriteLine("\n -----------  Danh sách sinh viên: ----------- ");
        foreach (var sv in data)
        {
            Console.WriteLine($"- {sv.MSSV} | {sv.HoTen} | Điểm TB: {sv.DiemTB}");
        }
    }
}
