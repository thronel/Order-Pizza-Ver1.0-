using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Object
{
    class ChamCongObj
    {
        string lydo, date, name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Lydo
        {
            get { return lydo; }
            set { lydo = value; }
        }

        int manv;

        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        public ChamCongObj() { }
        public ChamCongObj(string lydo, string date, int manv, string name)
        {
            this.lydo = lydo;
            this.date = date;
            this.manv = manv;
            this.name = name;
        }
    }
}
