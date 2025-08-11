using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_ManagerStudent
{
    public class Student : Nguoi, Interface
    {
        public string Lop { get; set; }

        public Student() { }

        public Student(string lop, string name) : base(name)
        {
            Lop = lop;
        }

        public override void InThongTin()
        {
            Console.WriteLine($"Ho ten: {Name}, Lop: {Lop}");
        }

        public void HoatDong()
        {
            Console.WriteLine($"{Name} đang học bài ở lớp {Lop}.");
        }
    }
}
