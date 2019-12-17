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
    public partial class IndexStaffForm : Form
    {
        private LogicLayer Business;
        public IndexStaffForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += IndexStaffForm_Load;
            this.btnCreate.Click += BtnCreate_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.grdStaff.DoubleClick += GrdStaff_DoubleClick;
            this.btnFind.Click += BtnFind_Click;
            this.btnShow.Click += BtnShow_Click;
            this.txtFind.Leave += TxtFind_Leave;
            this.txtFind.Enter += TxtFind_Enter;          
            this.btnSort.Click += btnSort_Click;
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            var db = new StaffManagementEntities();
            grdSalary.DataSource = db.SalaryPositions.OrderBy(r => r.Salary).ToList();
        }

        private void TxtFind_Leave(object sender, EventArgs e)
        {
            if(txtFind.Text == "")
            {
                txtFind.Text = "Please enter id";
                txtFind.ForeColor = Color.Gray;
            }
        }

        private void TxtFind_Enter(object sender, EventArgs e)
        {
            if(txtFind.Text == "Please enter id")
            {
                txtFind.Text = "";
                txtFind.ForeColor = Color.Gray;

            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            var roomForm = new RoomForm();
            roomForm.ShowDialog();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            grdStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in grdStaff.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(txtFind.Text.ToLower()))
                    {
                        row.Selected = true;
                        grdStaff.CurrentCell = row.Cells[1];
                        return;
                    }
                }
                throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("This id does not exist");
                grdStaff.ClearSelection();
            }         
        }

        private void GrdStaff_DoubleClick(object sender, EventArgs e)
        {
            if (grdStaff.SelectedRows.Count == 1)
            {
                var staff = (StaffView)grdStaff.SelectedRows[0].DataBoundItem;
                var updateForm = new UpdateStaffForm(staff.Id);
                updateForm.ShowDialog();
                this.loadAllStaff();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (grdStaff.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var staff = (StaffView)grdStaff.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteStaff(staff.Id);
                    MessageBox.Show("Delete successfully!");
                    this.loadAllStaff();
                }
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateStaffForm();
            createForm.ShowDialog();
            this.loadAllStaff();
        }

        private void IndexStaffForm_Load(object sender, EventArgs e)
        {
            this.loadAllStaff();
            this.loadSalary();
        }
        private void loadAllStaff()
        {
            
            // this.dataGridView1.DataSource = this.Business.GetNhanVien();
            var staff = this.Business.GetNhanVien();
           // var room = this.Business.GetRoom();
            StaffView[] staffviews = new StaffView[staff.Length];
            for(int i = 0; i < staffviews.Length; i++)
            {
                staffviews[i] = new StaffView(staff[i]);
            }
            this.grdStaff.DataSource = staffviews;
            this.txtCount.Text = String.Format(staffviews.Length.ToString());           
        }
        private void loadSalary()
        {
           // grdSalary.DataSource = this.Business.GetSalary();
            var salary = this.Business.GetSalary();
            SalaryView[] salaryviews = new SalaryView[salary.Length];
            for(int i = 0; i < salaryviews.Length; i++)
            {
                salaryviews[i] = new SalaryView(salary[i]);
            }
            this.grdSalary.DataSource = salaryviews;
        }
      
       
    }
}
