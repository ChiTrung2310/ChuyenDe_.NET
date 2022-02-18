using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanHang18.BusinessLayer.Workflow;
using BanHang18.BusinessLayer.Entity;

namespace BanHang18.PresentationLayer
{
    public partial class NhomTaiKhoan : Form
    {
        private DataSet ds;
        private DataViewManager dsView;
        private bool ok = false;

        public NhomTaiKhoan()
        {
            InitializeComponent();
            dataBinding();
        }

        private void dataBinding()
        {
            updateDataGridView();
            //--Thêm nút Delete
            DataGridViewButtonColumn nutXoa = new DataGridViewButtonColumn();
            nutXoa.Name = "Delete";
            nutXoa.Text = "Xóa";
            nutXoa.UseColumnTextForButtonValue = true;
            //--Gắn nút xóa vào DataGridView
            this.dsNhomTk.Columns.Add(nutXoa);
            this.dsNhomTk.CellClick += DsNhomTk_CellClick;

            //---Binding to TextBox
            this.txtTenNhom.DataBindings.Clear();
            this.txtTenNhom.DataBindings.Add("Text", dsView, "nhomTk.tenNhom");

            this.txtGhiChu.DataBindings.Clear();
            this.txtGhiChu.DataBindings.Add("Text", dsView, "nhomTk.ghiChu");

        }

        private void updateDataGridView()
        {
            BusNhomTaiKhoan x = new BusNhomTaiKhoan();
            //--Wait a minutes
            ds = x.GetDataSet();
            //---Set default view to dsView
            dsView = ds.DefaultViewManager;
            //---Binding to DataGridView
            this.dsNhomTk.DataSource = dsView;
            this.dsNhomTk.DataMember = "nhomTk";

            //---Định dạng cột cho DS quận huyện (độ rộng)
            this.dsNhomTk.Columns[0].Width = 50;
            this.dsNhomTk.Columns[1].Width = 150;
            this.dsNhomTk.Columns[2].Width = 280;
            this.dsNhomTk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //---Binding to TextBox
            this.txtTenNhom.DataBindings.Clear();
            this.txtTenNhom.DataBindings.Add("Text", dsView, "nhomTk.tenNhom");

            this.txtGhiChu.DataBindings.Clear();
            this.txtGhiChu.DataBindings.Add("Text", dsView, "nhomTk.ghiChu");
        }

        private void DsNhomTk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dsNhomTk.Columns["Delete"].Index)
            {
                int maCX = int.Parse(this.dsNhomTk.Rows[e.RowIndex].Cells[1].Value.ToString());
                BusNhomTaiKhoan x = new BusNhomTaiKhoan();
                x.info = packageNTk();
                x.info.MaNhom = maCX;
                if (x.deleteNhomTk() > 0)
                {
                    MessageBox.Show("Đã xóa thành công 1 nhóm tài khoản !!!");
                    updateDataGridView();
                }

            }

        }

        private GroupTaiKhoan packageNTk()
        {
            GroupTaiKhoan x = new GroupTaiKhoan();
            x.TenNhom = this.txtTenNhom.Text.Trim();
            x.GhiChu = this.txtGhiChu.Text.Trim();
            return x;
        }

        /// <summary>
        /// Nhấn new để bắt đầu thêm nhóm tài khoản mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            ok = true;
            this.txtTenNhom.Text = "";
            this.txtGhiChu.Text = "";
            this.txtTenNhom.Focus();
        }

        /// <summary>
        /// Kiểm tra xem đủ điều kiện để nút save enable
        /// </summary>
        /// <returns></returns>
        private bool enableSaveButton()
        {
            return (this.txtTenNhom.Text.Length > 0);
        }

        /// <summary>
        /// Nhấn vào để hoàn thành thêm nhóm tài khoản mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                //---B1: Đóng gói dữ liệu
                BusNhomTaiKhoan x = new BusNhomTaiKhoan();
                x.info = packageNTk();

                //---B2: Gọi hàm lưu dữ liệu 
                int kq = x.addNhomTk();
                if (kq == 1)
                {
                    MessageBox.Show("Đã thêm thành công 1 nhóm tài khoản !!!");
                    updateDataGridView();
                    ok = false;
                }
            }
            else
            {
                BusNhomTaiKhoan x = new BusNhomTaiKhoan();
                x.info = packageNTk();
                int Ma = int.Parse(dsNhomTk.CurrentRow.Cells["maNhom"].Value.ToString());
                x.info.MaNhom = Ma;
                //---B2: Gọi hàm update dữ liệu 
                int kq = x.updateNhomTk();
                if (kq == 1)
                {
                    MessageBox.Show("Đã update thành công 1 nhóm tài khoản !!!");
                    updateDataGridView();

                }
            }

        }

        /// <summary>
        /// Print dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy kết nối máy in!!!");
        }

        /// <summary>
        /// Nhấn để thoát form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Bẫy sự kiện cho ô nhập liệu tên nhóm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTenNhom_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = enableSaveButton();
        }

        private void NhomTaiKhoan_Load(object sender, EventArgs e)
        {
            this.dsNhomTk.Columns[0].Width = 50;
            this.dsNhomTk.Columns[1].Width = 150;
            this.dsNhomTk.Columns[2].Width = 280;
            this.dsNhomTk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //--Đổi lại tên các cột trong DataGridView 
            this.dsNhomTk.Columns[1].HeaderText = "Mã nhóm ";
            this.dsNhomTk.Columns[2].HeaderText = "Tên nhóm";
            this.dsNhomTk.Columns[3].HeaderText = "Ghi chú";
        }
    }
}
