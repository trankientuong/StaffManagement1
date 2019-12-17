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
    public partial class CreateStaffForm : Form
    {
        private LogicLayer Business;
        public CreateStaffForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.btnSave.Click += BtnSave_Click;
            this.Load += CreateStaffForm_Load;
            this.btnClose.Click += btnClose_Click;
        }
        void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateStaffForm_Load(object sender, EventArgs e)
        {
            this.cboRoom.DataSource = this.Business.GetRoom();
            this.cboRoom.DisplayMember = "RoomName";
            this.cboRoom.ValueMember = "RoomId";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (checkData())
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
                this.Business.CreateStaff(name, gender, dateofbirth, phonenumber, address, room);
                MessageBox.Show("Create successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please entered all information");
            }
        }

        public bool checkData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please entered a name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please entered a phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please entered a phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
