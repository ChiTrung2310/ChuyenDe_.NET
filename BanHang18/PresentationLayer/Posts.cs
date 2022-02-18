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
    public partial class Posts : Form
    {
        private DataSet ds;
        private DataViewManager dsView;
        private bool isActive;

        public Posts(bool isActive)
        {
            InitializeComponent();
            this.isActive = isActive;
            loadDataToComboBox(); //---Nạp dữ liệu cho ComboBox
            loadDataToGridView(this.isActive, 0); //---Nạp dữ liệu cho GridView
            formatColumnInDGV();

        }

        /// <summary>
        /// Dùng để nạp dữ liệu cho ComboBox Loại sản phẩm
        /// </summary>
        private void loadDataToComboBox()
        {
            this.cboLoaiSP.DataSource = new BusLoaiSanPham().GetDataSet().Tables[0];
            this.cboLoaiSP.DisplayMember = "loaiSP";
            this.cboLoaiSP.ValueMember = "maLoai";
            this.cboLoaiSP.SelectedIndex = -1;

        }

        /// <summary>
        /// Nạp dữ liệu vào GridView
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="maNhom"></param>
        private void loadDataToGridView(bool isActive, int maLoai)
        {
            this.ds = new BusBaiViet().GetDataSet(isActive, maLoai);
            //---Set default view Manager
            this.dsView = ds.DefaultViewManager;
            this.dsBaiViet.DataSource = this.dsView;
            this.dsBaiViet.DataMember = "baiViet";

        }

        /// <summary>
        /// Format columns
        /// </summary>
        public void formatColumnInDGV()
        {
            //---Format columns
            this.dsBaiViet.Columns["maBV"].Width = 70;
            this.dsBaiViet.Columns["tenBV"].Width = 150;
            this.dsBaiViet.Columns["ndTomTat"].Width = 210;
            this.dsBaiViet.Columns["ngayDang"].Width = 100;
            this.dsBaiViet.Columns["noiDung"].Width = 340;
            this.dsBaiViet.Columns["taiKhoan"].Width = 150;
            this.dsBaiViet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dsBaiViet.Columns["hinhDD"].Visible = false;

            //---Đặt lại tên các cột trong DataGridView
            this.dsBaiViet.Columns["maBV"].HeaderText = "Mã BV";
            this.dsBaiViet.Columns["tenBV"].HeaderText = "Tên BV";
            this.dsBaiViet.Columns["ndTomTat"].HeaderText = "Tóm tắt";
            this.dsBaiViet.Columns["ngayDang"].HeaderText = "Ngày đăng";
            this.dsBaiViet.Columns["noiDung"].HeaderText = "Nội dung";
            this.dsBaiViet.Columns["taiKhoan"].HeaderText = "Tài khoản";

            //---Create button
            DataGridViewImageColumn nut = new DataGridViewImageColumn();
            nut.Name = "Modify";
            nut.Image = Properties.Resources.newspaper_go; //---Hình cho nút chỉnh sửa
            this.dsBaiViet.Columns.Add(nut);
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cboLoaiSP.SelectedIndex >= 0)
            {
                int maLoai = int.Parse(this.cboLoaiSP.SelectedValue.ToString());
                this.loadDataToGridView(this.isActive, maLoai);
            }
            else
            {
                MessageBox.Show("Hãy chọn loại sản phẩm để lọc");
                this.cboLoaiSP.Focus();
            }
        }

        /// <summary>
        /// Load lại dữ liệu trong DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDataToGridView(this.isActive, 0);
        }

        /// <summary>
        /// thoát form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dsBaiViet_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dsBaiViet.Columns["Modify"].Index)
            {
                string ma = this.dsBaiViet.Rows[e.RowIndex].Cells["maBV"].Value.ToString();
                NewPosts NP = new NewPosts(ma);
                NP.MdiParent = this.MdiParent;
                NP.Show();
            }
        }
    }
}
