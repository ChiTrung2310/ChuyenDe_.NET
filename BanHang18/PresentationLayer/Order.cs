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
    public partial class Order : Form
    {
        private DataSet ds;
        private DataViewManager dsView;
        private bool isActive;

        public Order(bool isActive)
        {
            InitializeComponent();
            this.isActive = isActive;
            loadDataToComboBox(); //---Nạp dữ liệu cho ComboBox
            loadDataToGridView(this.isActive, 0); //---Nạp dữ liêu cho GridView
            formatColumnInDGV();
        }


        /// <summary>
        /// Dùng để nạp dữ liệu cho ComboBox Trang Thái
        /// </summary>
        private void loadDataToComboBox()
        {
            this.cboTrangThai.DataSource = new BusTrangThai().GetDataSet().Tables[0];
            this.cboTrangThai.DisplayMember = "tenTT";
            this.cboTrangThai.ValueMember = "maTT";
            this.cboTrangThai.SelectedIndex = -1;

        }

        /// <summary>
        /// Nạp dữ liệu vào GridView
        /// </summary>
        /// <param name="isActive">Đơn hàng đã được kích hoạt hay chưa</param>
        /// <param name="TrangThai">Trạng thái của đơn hàng</param>
        private void loadDataToGridView(bool isActive, int TrangThai)
        {
            this.ds = new BusDonHang().GetDataSet(isActive, TrangThai);
            //---Set default view Manager
            this.dsView = ds.DefaultViewManager;
            this.dsDonHang.DataSource = this.dsView;
            this.dsDonHang.DataMember = "donHang";

        }

        /// <summary>
        /// Format columns
        /// </summary>
        public void formatColumnInDGV()
        {
            //---Format columns
            this.dsDonHang.Columns["soDH"].Width = 100;
            this.dsDonHang.Columns["tenKH"].Width = 150;
            this.dsDonHang.Columns["ngayDat"].Width = 170;
            this.dsDonHang.Columns["taiKhoan"].Width = 150;
            this.dsDonHang.Columns["diaChiGH"].Width = 250;
            this.dsDonHang.Columns["SoSP"].Width = 80;

            this.dsDonHang.Columns["soDH"].HeaderText = "Số ĐH";
            this.dsDonHang.Columns["tenKH"].HeaderText = "Tên KH";
            this.dsDonHang.Columns["ngayDat"].HeaderText = "Ngày đặt";
            this.dsDonHang.Columns["taiKhoan"].HeaderText = "Tài khoản";
            this.dsDonHang.Columns["diaChiGH"].HeaderText = "Địa chỉ GH";
            this.dsDonHang.Columns["SoSP"].HeaderText = "Số SP";

            this.dsDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //---Create button
            DataGridViewImageColumn nut = new DataGridViewImageColumn();
            nut.Name = "Modify";
            nut.Image = Properties.Resources.document;
            this.dsDonHang.Columns.Add(nut);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cboTrangThai.SelectedIndex >= 0)
            {
                int TrangThai = int.Parse(this.cboTrangThai.SelectedValue.ToString());
                this.loadDataToGridView(this.isActive, TrangThai);
            }
            else
            {
                MessageBox.Show("Hãy chọn trạng thái đơn hàng để lọc");
                this.cboTrangThai.Focus();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDataToGridView(this.isActive, 0);
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
        /// Khi ấn vào nút chỉnh sửa đơn hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dsDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dsDonHang.Columns["Modify"].Index)
            {
                string sodh = this.dsDonHang.Rows[e.RowIndex].Cells["soDH"].Value.ToString();
                EditOrder ed = new EditOrder(sodh);
                ed.MdiParent = this.MdiParent;
                ed.Show();
            }
        }
    }
}
