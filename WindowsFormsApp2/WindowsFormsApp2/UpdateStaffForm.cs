using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UpdateStaffForm : Form
    {
        private LogicLayer Business;
        private int StaffId;
        public UpdateStaffForm(int id)
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.StaffId = id;
            this.Load += UpdateStaffForm_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnClose.Click += btnClose_Click;
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string gender = "";
            var name = this.txtName.Text;
            if (rbMale.Checked)
            {
                gender = this.rbMale.Text;
            }
            else
            {
                gender = this.rbFemale.Text;
            }
            var dateofbirth = this.dtpBirthday.Value;
            var phonenumber = this.txtPhone.Text;
            var address = this.txtAddress.Text;
            var room = (int)this.cboRoom.SelectedValue;
            this.Business.UpdateStaff(this.StaffId, name, gender, dateofbirth, phonenumber, address, room);
            MessageBox.Show("Update successfully");
            this.Close();
        }

        private void UpdateStaffForm_Load(object sender, EventArgs e)
        {
            this.cboRoom.DataSource = this.Business.GetRoom();
            this.cboRoom.DisplayMember = "RoomName";
            this.cboRoom.ValueMember = "RoomId";
            var staff = this.Business.Get1NhanVien(this.StaffId);
           // string birthday = String.Format(staff.dateofbirth.ToString());
            this.txtName.Text = staff.Fullname;
            this.txtPhone.Text = staff.Phonenumber;
            this.txtAddress.Text = staff.Address;
            this.dtpBirthday.Text = String.Format(staff.Birthday.ToString());
            this.cboRoom.SelectedValue = staff.Room_Id;
            if (rbMale.Text == "Male")
            {
                rbMale.Checked = true;
            }
            if(rbFemale.Text == staff.Gender)
            {
                rbFemale.Checked = true;
            }
        }
    }
}
