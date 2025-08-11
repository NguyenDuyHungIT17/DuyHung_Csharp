using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_ManagerStudent
{
    public class Teacher : Nguoi, Interface
    {
        public string MonDay { get; set; }

        public Teacher(string name, string monDay) : base(name)
        {
            MonDay = monDay;
        }

        public override void InThongTin()
        {
            Console.WriteLine($"Giáo viên: {Name}, Môn dạy: {MonDay}");
        }

        public void HoatDong()
        {
            Console.WriteLine($"{Name} đang giảng bài môn {MonDay}.");
        }
    }
}
