using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class StaffView
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public System.DateTime dateofbirth { get; set; }
        public string phonenumber { get; set; }
        public string address { get; set; }
        public Nullable<int> room { get; set; }
        public string PHONGBAN { get; set; }
        public StaffView(NHANVIEN staff)
        {
            this.Id = staff.Id;
            this.name = staff.name;
            this.gender = staff.gender;
            this.dateofbirth = staff.dateofbirth;
            this.phonenumber = staff.phonenumber;
            this.address = staff.address;
            this.room = staff.PHONGBAN.Id;
            this.PHONGBAN = staff.PHONGBAN.room;
        }
    }
      
}
