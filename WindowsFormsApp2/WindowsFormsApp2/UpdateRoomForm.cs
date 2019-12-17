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
    public partial class UpdateRoomForm : Form
    {
        private LogicLayer Business;
        private int RoomId;
        public UpdateRoomForm(int id)
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += UpdateRoomForm_Load;
            this.RoomId = id;
            this.btnSave.Click += btnSave_Click;
            this.btnClose.Click += btnClose_Click;
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string roomname = this.txtRoomName.Text;
            string position = this.txtPosition.Text;
            this.Business.UpdateRoom(this.RoomId, roomname, position);
            MessageBox.Show("Update room successfully");
            this.Close();
        }

        void UpdateRoomForm_Load(object sender, EventArgs e)
        {
            var room = this.Business.get1Room(RoomId);
            this.txtRoomId.Text = String.Format(room.RoomId.ToString());
            this.txtRoomName.Text = room.RoomName;
            this.txtPosition.Text = room.Position;
        }
    }
}
