using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class SalaryView
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Salary { get; set; }
        
        

        public SalaryView(SalaryPosition salary)
        {
            this.Id = salary.Id;
            this.RoomId = salary.RoomId;
            this.Salary = string.Format(salary.Salary.ToString());
           
            
        }
    }
}
