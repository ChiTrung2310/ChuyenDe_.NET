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
    public partial class EditOrder : Form
    {
        public EditOrder()
        {
            InitializeComponent();
            loadDataToComboBox();
        }

        public EditOrder(string sodh)
        {
            InitializeComponent();
            //---Load data
            loadDataToComboBox();
            DonHang a = new BusDonHang().getInfo(sodh);
            fillUI(a);
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

        private void fillUI(DonHang x)
        {
            this.txtSoDH.Text = x.SoDH;
            this.txtMaKH.Text = x.MaKH;
            this.txtTaiKhoan.Text = x.TaiKhoan;
            this.dtNgayDat.Value = x.NgayDat;
            this.dtNgayGH.Value = x.NgayGH;
            this.txtDiaChiGH.Text = x.DiaChiGH;
            this.txtGhiChu.Text = x.GhiChu;
            this.cboTrangThai.SelectedValue = x.TrangThai;

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
        /// Nhấn để update đơn hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            BusDonHang x = new BusDonHang();
            x.info = packageDH();
            string soDh = this.txtSoDH.Text.Trim(); 
            x.info.SoDH = soDh;

            //---B2: Gọi hàm update dữ liệu 
            int kq = x.updateDonHang();
            if (kq == 1)
            {
                MessageBox.Show("Đã update thành công 1 đơn hàng !!!");
                this.Dispose();

            }
        }

        /// <summary>
        /// Đóng gói giao diện UI
        /// </summary>
        /// <returns></returns>
        private DonHang packageDH()
        {
            DonHang x = new DonHang();
            //---Thông tin bài viết
            x.SoDH = this.txtSoDH.Text.Trim();
            x.MaKH = this.txtMaKH.Text.Trim();
            x.TaiKhoan = this.txtTaiKhoan.Text.Trim();
            x.NgayDat = this.dtNgayDat.Value;
            x.NgayGH = this.dtNgayGH.Value;
            x.DiaChiGH = this.txtDiaChiGH.Text.Trim();
            x.GhiChu = this.txtGhiChu.Text.Trim();
            x.TrangThai = int.Parse(this.cboTrangThai.SelectedValue.ToString());

            return x;
        }
    }
}
