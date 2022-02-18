using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanHang18.BusinessLayer.Entity;
using BanHang18.BusinessLayer.Workflow;

namespace BanHang18.PresentationLayer
{
    public partial class AccountManagement : Form
    {
        private DataSet ds;
        private DataViewManager dsView;
        private bool isActive;

        public AccountManagement(bool isActive)
        {
            InitializeComponent();
            this.isActive = isActive;
            loadDataToComboBox(); //---Nạp dữ liệu cho ComboBox
            loadDataToGridView(this.isActive, 0); //---Nạp dữ liêu cho GridView
            formatColumnInDGV();
            
        }


        /// <summary>
        /// Dùng để nạp dữ liệu cho ComboBox NhomTk
        /// </summary>
        private void loadDataToComboBox()
        {
            this.cboNhomTk.DataSource = new BusNhomTaiKhoan().GetDataSet().Tables[0];
            this.cboNhomTk.DisplayMember = "tenNhom";
            this.cboNhomTk.ValueMember = "maNhom";
            this.cboNhomTk.SelectedIndex = -1;

        }

        /// <summary>
        /// Nạp dữ liệu vào GridView
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="maNhom"></param>
        private void loadDataToGridView(bool isActive, int maNhom)
        {
            this.ds = new BusTaiKhoanTV().GetDataSet(isActive, maNhom);
            //---Set default view Manager
            this.dsView = ds.DefaultViewManager;
            this.dgvNhomTk.DataSource = this.dsView;
            this.dgvNhomTk.DataMember = "taiKhoanTV";
           
        }

        /// <summary>
        /// Format columns
        /// </summary>
        public void formatColumnInDGV()
        {
            //---Format columns
            this.dgvNhomTk.Columns["hoDem"].Width = 150;
            this.dgvNhomTk.Columns["tenTV"].Width = 120;
            this.dgvNhomTk.Columns["taiKhoan"].Width = 120;
            this.dgvNhomTk.Columns["ngaySinh"].Width = 100;
            this.dgvNhomTk.Columns["gioiTinh"].Width = 80;
            this.dgvNhomTk.Columns["soDT"].Width = 120;
            this.dgvNhomTk.Columns["diaChi"].Width = 350;

            //--Định dạng lại tên các cột trong DataGridView
            this.dgvNhomTk.Columns["hoDem"].HeaderText = "Họ đệm";
            this.dgvNhomTk.Columns["tenTV"].HeaderText = "Tên TV";
            this.dgvNhomTk.Columns["taiKhoan"].HeaderText = "Tài khoản";
            this.dgvNhomTk.Columns["ngaySinh"].HeaderText = "Ngày sinh";
            this.dgvNhomTk.Columns["gioiTinh"].HeaderText = "Giới tính";
            this.dgvNhomTk.Columns["soDT"].HeaderText = "Số ĐT";
            this.dgvNhomTk.Columns["diaChi"].HeaderText = "Địa chỉ";
            //---Create button
            DataGridViewImageColumn nut = new DataGridViewImageColumn();
            nut.Name = "Modify";
            nut.Image = Properties.Resources.users_edit;
            this.dgvNhomTk.Columns.Add(nut);
        }

        /// <summary>
        /// Thoát form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Lọc dữ liệu theo mã nhóm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cboNhomTk.SelectedIndex >= 0)
            {
                int maNhom = int.Parse(this.cboNhomTk.SelectedValue.ToString());
                this.loadDataToGridView(this.isActive, maNhom);
            }
            else
            {
                MessageBox.Show("Hãy chọn nhóm tài khoản để lọc");
                this.cboNhomTk.Focus();
            }
        }

        /// <summary>
        /// Sự kiện khi nhấn nút Modify trong DataGridViev
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNhomTk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvNhomTk.Columns["Modify"].Index)
            {
                string taiKhoan = this.dgvNhomTk.Rows[e.RowIndex].Cells["taiKhoan"].Value.ToString();
                Accounts a = new Accounts(taiKhoan);
                a.MdiParent = this.MdiParent;
                a.Show();
            }
            
        }

        /// <summary>
        /// Làm mới danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDataToGridView(this.isActive, 0);
        }
    }
}
