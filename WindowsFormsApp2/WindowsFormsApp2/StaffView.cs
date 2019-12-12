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
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public Nullable<int> Room_Id { get; set; }

        public string RoomRestaurant { get; set; }
        public StaffView(StaffRestaurant staff)
        {
            this.Id = staff.Id;
            this.Fullname = staff.Fullname;
            this.Gender = staff.Gender;
            this.Birthday = staff.Birthday;
            this.Phonenumber = staff.Phonenumber;
            this.Address = staff.Address;
            this.Room_Id = staff.RoomRestaurant.RoomId;
            this.RoomRestaurant = staff.RoomRestaurant.RoomName;
        }
    }
      
}
