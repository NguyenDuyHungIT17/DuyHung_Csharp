using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_ManagerStudent
{
    public abstract class Nguoi
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Nguoi() { }

        public Nguoi(string name) { this.Name = name; }

        public abstract void InThongTin();
    }
}
