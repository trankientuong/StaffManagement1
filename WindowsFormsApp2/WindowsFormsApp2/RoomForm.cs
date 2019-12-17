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
    public partial class RoomForm : Form
    {
        private LogicLayer Business;
        public RoomForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += RoomForm_Load;
            this.btnAdd.Click += btnAdd_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnClose.Click += btnClose_Click;
            this.grdRoom.DoubleClick += grdRoom_DoubleClick;
        }

        void grdRoom_DoubleClick(object sender, EventArgs e)
        {
            if (grdRoom.SelectedRows.Count == 1)
            {
                var room = (RoomView)grdRoom.SelectedRows[0].DataBoundItem;
                var updateRoom = new UpdateRoomForm(room.RoomId);
                updateRoom.ShowDialog();
                this.loadAllRoom();
            }
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdRoom.SelectedRows.Count == 1)
            {


                if (MessageBox.Show("Do you want to delete this ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var room = (RoomView)grdRoom.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteRoom(room.RoomId);
                    MessageBox.Show("Delete successfully");
                    this.loadAllRoom();
                }
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            var CreateRoom = new AddRoomForm();
            CreateRoom.ShowDialog();
            this.loadAllRoom();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            this.loadAllRoom();
        }
        private void loadAllRoom()
        {
            this.grdRoom.DataSource = this.Business.GetRoom();
            var room = this.Business.GetRoom();
            var roomviews = new RoomView[room.Length];
            for(int i = 0; i < roomviews.Length; i++)
            {
                roomviews[i] = new RoomView(room[i]);
            }
            this.grdRoom.DataSource = roomviews;
        }
    }
}
