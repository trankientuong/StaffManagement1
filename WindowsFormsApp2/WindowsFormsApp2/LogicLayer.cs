using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class LogicLayer
    {
        public StaffRestaurant[] GetNhanVien()
        {
            var db = new StaffManagementEntities();
            return db.StaffRestaurants.ToArray();
        }
        public void CreateStaff(string name, string gender, DateTime dateofbirth, string phonenumber, string address, int room)
        {
            var db = new StaffManagementEntities();
            var newStaff = new StaffRestaurant();
            newStaff.Fullname = name;
            newStaff.Gender = gender;
            newStaff.Birthday = dateofbirth;
            newStaff.Phonenumber = phonenumber;
            newStaff.Address = address;
            newStaff.Room_Id = room;
            db.StaffRestaurants.Add(newStaff);
            db.SaveChanges();
        }
        public RoomRestaurant[] GetRoom()
        {
            var db = new StaffManagementEntities();
            return db.RoomRestaurants.ToArray();
            
        }
        public void UpdateStaff(int id, string name, string gender, DateTime dateofbirth, string phonenumber, string address, int room)
        {
            var db = new StaffManagementEntities();
            var oldStaff = db.StaffRestaurants.Find(id);
            oldStaff.Fullname = name;
            oldStaff.Gender = gender;
            oldStaff.Birthday = dateofbirth;
            oldStaff.Phonenumber = phonenumber;
            oldStaff.Address = address;
            oldStaff.Room_Id = room;
            db.Entry(oldStaff).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteStaff(int id)
        {
            var db = new StaffManagementEntities();
            var staff = db.StaffRestaurants.Find(id);
            db.StaffRestaurants.Remove(staff);
            db.SaveChanges();
        }
        public StaffRestaurant Get1NhanVien(int id)
        {
            var db = new StaffManagementEntities();
            var staff = db.StaffRestaurants.Find(id);
            return staff;
        }
        public SalaryPosition[] GetSalary()
        {
            var db = new StaffManagementEntities();
            
            return db.SalaryPositions.ToArray();
        }
    }
}
