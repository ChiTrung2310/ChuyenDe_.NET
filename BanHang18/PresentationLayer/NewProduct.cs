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
using System.IO;
using BanHang18.Lib;

namespace BanHang18.PresentationLayer
{
    public partial class NewProduct : Form
    {
        private SanPham info;
        private bool ok = true;

        public NewProduct()
        {         
            InitializeComponent();
            this.txtTaiKhoan.Text = Lib.secureObject.ttDangNhap.TaiKhoan;
            this.info = new SanPham(new Bitmap(this.pbHinhDD.Width, this.pbHinhDD.Height));
            bindingData();
            
        }

        public NewProduct(string maSP)
        {
            InitializeComponent();
            this.info = new BusSanPham().getInfo(maSP);
            bindingData();
            ok = false;
        }

        //---binding data
        private void bindingData()
        {
            //ok = false;
            //btnSave.Enabled = true;
            //---Binding data
            this.txtMaSP.DataBindings.Add("Text", this.info, "MaSP");
            this.txtTenSP.DataBindings.Add("Text", this.info, "TenSP");
            this.cboLoaiSP.DataBindings.Add("SelectedValue", this.info, "MaLoai");
            this.txtNhaSX.DataBindings.Add("Text", this.info, "NhaSanXuat");
            this.txtUnit.DataBindings.Add("Text", this.info, "DonViTinh");
            this.dtNgayDang.DataBindings.Add("Value", this.info, "NgayDang");

            this.txtTaiKhoan.DataBindings.Add("Text", this.info, "TaiKhoan");
            this.cbDaDuyet.DataBindings.Add("Checked", this.info, "DaDuyet");
            //this.txtTaiKhoan.Text = "amdin"; //--Chỉnh sửa lại là tài khoản khác
            //this.info.TaiKhoan = "amdin";

            //---Đã chỉnh lại tài khoản tương ứng
            this.txtTaiKhoan.Text = Lib.secureObject.ttDangNhap.TaiKhoan;
            this.cbDaDuyet.Checked = false;

            this.txtTomTat.DataBindings.Add("Text", this.info, "TomTat");
            this.txtNoiDung.DataBindings.Add("Text", this.info, "NoiDung");
            this.txtGiaBan.DataBindings.Add("Text", this.info, "GiaBan");
            this.txtGiamGia.DataBindings.Add("Text", this.info, "GiamGia");

            //---Load data to ComboBox loại SP
            this.cboLoaiSP.DataSource = new BusLoaiSanPham().GetDataSet().Tables[0];
            this.cboLoaiSP.DisplayMember = "loaiSP";
            this.cboLoaiSP.ValueMember = "maLoai";
            this.cboLoaiSP.SelectedIndex = -1;
        }

        /// <summary>
        /// Binding image on UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbHinhDD_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file | *.png; *.jpg; *.jpeg; *.bmp; *.gif";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                this.info.HinhDD = Image.FromFile(ofd.FileName);
                this.pbHinhDD.Image = this.info.HinhDD;
            }
        }

        /// <summary>
        /// Nhấn để hoàn tất thêm sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                if (enableSaveButton() == true)
                {
                    if (new BusSanPham(this.info).addSanPham() == 1)
                    {
                        MessageBox.Show("Đã thêm 1 sản phẩm !!!");
                        ok = false;
                        btnNew.PerformClick();
                    }
                }
                else
                {
                    this.DieuKien();
                }
            }
            else
            {
                if (new BusSanPham(this.info).updateSanPham() == 1)
                {
                    MessageBox.Show("Đã update 1 sản phẩm !!!");
                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// Kiểm tra các điều kiện logic trước khi nhập vào database
        /// </summary>
        /// <returns></returns>
        private bool enableSaveButton()
        {
            return (this.txtMaSP.Text.Trim().Length > 0 && this.txtTenSP.Text.Trim().Length > 0 &&
                    cboLoaiSP.SelectedIndex >= 0 && this.txtTaiKhoan.Text.Trim().Length > 0);
        }

        /// <summary>
        /// Kiểm tra lỗi nhập liệu của người dùng trên UI
        /// </summary>
        private void DieuKien()
        {
            if (this.txtMaSP.Text.Trim().Equals(""))
            {
                this.baoLoi.Show("Chưa nhập mã sản phẩm !!!", this.txtMaSP, 0, -68, 4000);
                this.txtMaSP.Focus();
            }

            else if (this.txtTenSP.Text.Trim().Equals(""))
            {
                this.baoLoi.Show("Chưa nhập tên sản phẩm !!!", this.txtTenSP, 0, -68, 4000);
                this.txtTenSP.Focus();
            }

            else if (this.cboLoaiSP.SelectedIndex == -1)
            {
                this.baoLoi.Show("Chưa chọn loại sản phẩm !!!", this.cboLoaiSP, 0, -68, 4000);
                this.cboLoaiSP.Focus();
            }

            else if (this.txtTaiKhoan.Text.Trim().Equals(""))
            {
                this.baoLoi.Show("Chưa chọn loại sản phẩm !!!", this.cboLoaiSP, 0, -68, 4000);
                this.cboLoaiSP.Focus();
            }
        }

        /// <summary>
        /// Nhấn khi thêm mới sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            ok = true;
            this.txtTaiKhoan.Text = Lib.secureObject.ttDangNhap.TaiKhoan;
            //this.btnSave.Enabled = true;
            this.txtMaSP.Text = "";
            this.txtTenSP.Text = "";
            this.txtNhaSX.Text = "";
            this.txtUnit.Text = "";
            this.txtTomTat.Text = "";
            this.cboLoaiSP.SelectedIndex = -1;
            this.txtNoiDung.Text = "";
            this.txtGiaBan.Text = "";
            this.txtGiamGia.Text = "";
            this.pbHinhDD.Image = new Bitmap(this.pbHinhDD.Width, this.pbHinhDD.Height);
            this.txtMaSP.Focus();
            
        }

        /// <summary>
        /// Thoát khỏi form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
