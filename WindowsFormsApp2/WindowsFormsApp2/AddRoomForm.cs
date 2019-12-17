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
    public partial class AddRoomForm : Form
    {
        private LogicLayer Business;
        public AddRoomForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.btnSave.Click += btnSave_Click;
            this.btnClose.Click += btnClose_Click;
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtRoomId.Text);
            string roomname = this.txtRoomName.Text;
            string position = this.txtPosition.Text;
            this.Business.CreateRoom(id, roomname, position);
            MessageBox.Show("Add room successfully");
            this.Close();
        }
    }
}
