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
using BanHang18.Lib;
using System.IO;

namespace BanHang18.PresentationLayer
{
    public partial class NewPosts : Form
    {
        private BaiViet info;
        private bool ok = true;
        public NewPosts()
        {
            InitializeComponent();
            loadDataToComboBox();
            this.info = new BaiViet(new Bitmap(this.pbHinhDD.Width, this.pbHinhDD.Height));
        }

        public NewPosts(string maBaiViet)
        {
            InitializeComponent();
            loadDataToComboBox();
            //---Load data
            BaiViet a = new BusBaiViet().getInfo(maBaiViet);
            fillUI(a);
        }

        //---Load dữ liệu cho cboLoaiSP
        private void loadDataToComboBox()
        {
            //---1/-Load data cho cboMaQH
            DataSet ds = new BusLoaiSanPham().GetDataSet();
            this.cboMaLoai.DataSource = ds.Tables[0];
            this.cboMaLoai.DisplayMember = "loaiSP";
            this.cboMaLoai.ValueMember = "maLoai";
            this.cboMaLoai.SelectedIndex = -1;
        }

        /// <summary>
        /// Đổ dữ liệu từ from bài viết
        /// </summary>
        /// <param name="x"></param>
        private void fillUI(BaiViet x)
        {
            this.ok = false;
            this.txtMaBV.Text = x.MaBV;
            this.txtTenBV.Text = x.TenBV;
            this.dtNgayDang.Value = x.NgayDang;
            this.txtTomTat.Text = x.TomTat;
            this.txtNoiDung.Text = x.NoiDung;
            this.cboMaLoai.SelectedValue = x.MaLoai.ToString();
            this.txtTaiKhoan.Text = x.TaiKhoan;

        }

        /// <summary>
        /// Nhấn để thêm mới bài viết
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txtMaBV.Text = "";
            this.txtTenBV.Text = "";
            this.txtTaiKhoan.Text = Lib.secureObject.ttDangNhap.TaiKhoan;
            this.txtNoiDung.Text = "";
            this.txtTomTat.Text = "";
            this.dtNgayDang.Value = DateTime.Now;
            this.pbHinhDD.Image = new Bitmap(this.pbHinhDD.Width, this.pbHinhDD.Height);
            this.cboMaLoai.SelectedIndex = -1;
            this.txtMaBV.Focus();
        }

        /// <summary>
        /// Nhấn save để hoàn tất thêm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                //---B1: Đóng gói dữ liệu
                BusBaiViet x = new BusBaiViet();
                x.info = packageBV();

                //---B2: Gọi hàm lưu dữ liệu 
                int kq = x.addBaiViet();
                if (kq == 1)
                {
                    MessageBox.Show("Đã thêm thành công 1 bài viết !!!");
                    ok = false;
                    this.btnNew.PerformClick();
                }
            }
            else
            {
                BusBaiViet x = new BusBaiViet();
                x.info = packageBV();
                string Ma = this.txtMaBV.Text.Trim(); 
                x.info.MaBV = Ma;

                //---B2: Gọi hàm update dữ liệu 
                int kq = x.updateBaiViet();
                if (kq == 1)
                {
                    MessageBox.Show("Đã update thành công 1 bài viết !!!");
                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// Đóng gói giao diện UI
        /// </summary>
        /// <returns></returns>
        private BaiViet packageBV()
        {
            BaiViet x = new BaiViet();
            //---Thông tin bài viết
            x.MaBV = this.txtMaBV.Text.Trim();
            x.TenBV = this.txtTenBV.Text.Trim();
            x.NgayDang = this.dtNgayDang.Value;
            x.TomTat = this.txtTomTat.Text.Trim();
            x.TaiKhoan = this.txtTaiKhoan.Text.Trim();
            x.MaLoai = int.Parse(this.cboMaLoai.SelectedValue.ToString());
            x.NoiDung = this.txtNoiDung.Text.Trim();

            return x;
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
        /// Nhấn vào để chọn hình cho Sản phẩm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbHinhDD_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file | *.png; *.jpg; *.jpeg; *.bmp; *.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.info.HinhDD = Image.FromFile(ofd.FileName);
                this.pbHinhDD.Image = this.info.HinhDD;
            }
        }
    }
}
