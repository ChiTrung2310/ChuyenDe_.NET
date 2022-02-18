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
    public partial class Customer : Form
    {
        private DataSet ds;
        private DataViewManager dsView;
        private bool ok = false;

        public Customer()
        {
            InitializeComponent();
            dataBinding();

        }

        private void loadDataToComboBox()
        {
            //---1/-Load data cho cboMaQH
            DataSet ds = new BusQuanHuyen().GetDataSet();
            this.cboMaQH.DataSource = ds.Tables[0];
            this.cboMaQH.DisplayMember = "tenQH";
            this.cboMaQH.ValueMember = "maQH";
        }

        /// <summary>
        /// Update lại dữ liệu cho DataGridView Custommer
        /// </summary>
        private void updateDataGridView()
        {
            BusKhachHang x = new BusKhachHang();
            ds = x.GetDataSet();
            //--Set Default view to dsView
            dsView = ds.DefaultViewManager;
            //--Binding to GridView
            this.dsCustomer.DataSource = dsView;
            this.dsCustomer.DataMember = "khachHang";

            //---Binding to UI
            this.txtMaKH.DataBindings.Clear();
            this.txtMaKH.DataBindings.Add("Text", dsView, "khachHang.maKH");

            this.txtTenKH.DataBindings.Clear();
            this.txtTenKH.DataBindings.Add("Text", dsView, "khachHang.tenKH");

            this.dtNgaySinh.DataBindings.Clear();
            this.dtNgaySinh.DataBindings.Add("Value", dsView, "khachHang.ngaySinh");

            this.rdNam.DataBindings.Clear();
            this.rdNam.DataBindings.Add("Checked", dsView, "khachHang.gioiTinh");

            this.txtDiaChi.DataBindings.Clear();
            this.txtDiaChi.DataBindings.Add("Text", dsView, "khachHang.diaChi");

            this.cboMaQH.DataBindings.Clear();
            this.cboMaQH.DataBindings.Add("SelectedValue", dsView, "khachHang.maQH");

            this.txtSoDT.DataBindings.Clear();
            this.txtSoDT.DataBindings.Add("Text", dsView, "khachHang.soDT");

            this.txtEmail.DataBindings.Clear();
            this.txtEmail.DataBindings.Add("Text", dsView, "khachHang.email");

            this.txtGhiChu.DataBindings.Clear();
            this.txtGhiChu.DataBindings.Add("Text", dsView, "khachHang.ghiChu");

            //---Định dạng cột cho DS khách hàng (độ rộng)
            this.dsCustomer.Columns[0].Width = 120;
            this.dsCustomer.Columns[1].Width = 150;
            this.dsCustomer.Columns[2].Width = 170;
            this.dsCustomer.Columns[3].Width = 260;
            this.dsCustomer.Columns[4].Width = 260;
            this.dsCustomer.Columns[6].Width = 150;
            this.dsCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //--Các cột không cần thiết thì ẩn đi
            this.dsCustomer.Columns["maKH"].Visible = false;
            this.dsCustomer.Columns["maQH"].Visible = false;
            this.dsCustomer.Columns["ghiChu"].Visible = false;

            //---Đổi lại tên header của columns
            this.dsCustomer.Columns["tenKH"].HeaderText = "Họ tên";
            this.dsCustomer.Columns["ngaySinh"].HeaderText = "Ngày sinh";
            this.dsCustomer.Columns["gioiTinh"].HeaderText = "Giới tính";
            this.dsCustomer.Columns["soDT"].HeaderText = "Số ĐT";
            this.dsCustomer.Columns["diaChi"].HeaderText = "Địa chỉ";
        }
        
        /// <summary>
        /// Binding data
        /// </summary>
        private void dataBinding()
        {
            loadDataToComboBox();
            updateDataGridView();
            //--Thêm nút Delete
            DataGridViewButtonColumn nutXoa = new DataGridViewButtonColumn();
            nutXoa.Name = "Delete";
            nutXoa.Text = "Xóa";
            nutXoa.UseColumnTextForButtonValue = true;

            //--Gắn nút xóa vào DataGridView
            this.dsCustomer.Columns.Add(nutXoa);
            this.dsCustomer.CellClick += DsCustomer_CellClick;

        }

        /// <summary>
        /// Đóng gói dữ liệu từ giao diện
        /// </summary>
        /// <returns></returns>
        private KhachHang packageKH()
        {
            KhachHang x = new KhachHang();
            //----------
            x.MaKh = this.txtMaKH.Text.Trim();
            x.TenKh = this.txtTenKH.Text.Trim();
            x.GioiTinh = this.rdNam.Checked;
            x.NgaySinh = this.dtNgaySinh.Value;
            x.SoDT = this.txtSoDT.Text.Trim();
            x.Email = this.txtEmail.Text.Trim();
            x.DiaChi = this.txtDiaChi.Text.Trim();
            x.MaQH = int.Parse(this.cboMaQH.SelectedValue.ToString());          
            x.GhiChu = this.txtGhiChu.Text.Trim();
            return x;

        }

        /// <summary>
        /// Khi nhấn nút xóa khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DsCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dsCustomer.Columns["Delete"].Index)
            {
                string maKH = this.txtMaKH.Text;
                BusKhachHang x = new BusKhachHang();
                x.info = packageKH();
                x.info.MaKh = maKH;
                if (x.deleteKhachHang() > 0)
                {
                    MessageBox.Show("Đã xóa thành công 1 khách hàng !!!");
                    updateDataGridView();

                }

            }

        }

        /// <summary>
        /// Nhấn để bắt đầu thêm mới khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.ok = true;
            this.txtTenKH.Text = "";
            this.txtMaKH.Text = "";
            this.txtSoDT.Text = "";
            this.txtGhiChu.Text = "";
            this.txtEmail.Text = "";
            this.txtDiaChi.Text = "";
            this.cboMaQH.SelectedIndex = -1;
            this.rdNam.Checked = true;
            this.dtNgaySinh.Value = DateTime.Now;
            this.txtTenKH.Focus();
        }

        /// <summary>
        /// Nhấn hoàn tất việc thêm khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                if (enableSaveButton() == true)
                {
                    BusKhachHang x = new BusKhachHang();
                    x.info = packageKH();

                    //---B2: Gọi hàm lưu dữ liệu 
                    int kq = x.addKhachHang();
                    if (kq == 1)
                    {
                        MessageBox.Show("Đã thêm thành công 1 khách hàng mới !!!");
                        updateDataGridView();
                        ok = false;
                    }
                }
                else
                {
                    this.DieuKien();
                }
            }
            else
            {
                BusKhachHang x = new BusKhachHang();
                x.info = packageKH();
                string Ma = dsCustomer.CurrentRow.Cells["maKH"].Value.ToString();  
                x.info.MaKh = Ma;
                //---B2: Gọi hàm update dữ liệu 
                int kq = x.updateKhachHang();
                if (kq == 1)
                {
                    MessageBox.Show("Đã update thông tin 1 khách hàng!!!");
                    updateDataGridView();
                }
            }
        }

        /// <summary>
        /// Kiểm tra các điều kiện logic trước khi nhập vào database
        /// </summary>
        /// <returns></returns>
        private bool enableSaveButton()
        {
            return (this.txtMaKH.Text.Trim().Length > 0 && cboMaQH.SelectedIndex >= 0 
                && this.txtTenKH.Text.Trim().Length > 0);
        }

        /// <summary>
        /// Kiểm tra lỗi nhập liệu của người dùng trên UI
        /// </summary>
        private void DieuKien()
        {
            if (this.txtMaKH.Text.Trim().Equals(""))
            {
                this.baoLoi.Show("Chưa nhập mã khách hàng !!!", this.txtMaKH, 0, -68, 4000);
                this.txtMaKH.Focus();
            }

            else if (this.txtTenKH.Text.Trim().Equals(""))
            {
                this.baoLoi.Show("Chưa nhập tên khách hàng !!!", this.txtTenKH, 0, -68, 4000);
                this.txtTenKH.Focus();
            }

            else if (this.cboMaQH.SelectedIndex == -1)
            {
                this.baoLoi.Show("Chưa chọn quận huyện !!!", this.cboMaQH, 0, -68, 4000);
                this.cboMaQH.Focus();
            }
        }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btnSelect_Click(object sender, EventArgs e)
        {
            if(txtMaKH.Text.Trim().Length > 0)
            {
                Purchase.maKH = this.txtMaKH.Text.Trim();
                this.Dispose();
            }
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {
            rdNu.Checked = !rdNam.Checked;
        }
    }
}
