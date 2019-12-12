using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class RoomView
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string Position { get; set; }
    
        public int StaffRestaurant { get; set; }
        public RoomView(RoomRestaurant room)
        {           
            this.RoomId = room.RoomId;
            this.RoomName = room.RoomName;
            this.Position = room.Position;
            this.StaffRestaurant = room.StaffRestaurants.Count;
        }
    }
}
