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

namespace BanHang18.PresentationLayer
{
    public partial class Accounts : Form
    {
        private bool ok = true;

        public Accounts()
        {
            InitializeComponent();
            loadDataToComboBox();
        }

        public Accounts(string taiKhoan)
        {
            InitializeComponent();
            loadDataToComboBox();
            //---Load data
            TaiKhoanTV a = new BusTaiKhoanTV().getInfo(taiKhoan);
            fillUI(a);
        }

        /// <summary>
        /// Load dữ liệu giữa các form
        /// </summary>
        /// <param name="x"></param>
        private void fillUI(TaiKhoanTV x)
        {
            this.ok = false;
            this.txtHoDem.Text = x.HoDem;
            this.txtTen.Text = x.TenTV;
            this.rdNam.Checked = x.GioiTinh;
            this.dtNgaySinh.Value = x.NgaySinh;
            this.mtSoDT.Text = x.SoDT;
            this.txtEmail.Text = x.Email;
            this.txtGhiChu.Text = x.GhiChu;
            this.txtDiaChi.Text = x.DiaChi;
            this.cboMaNhom.SelectedValue = x.MaNhom.ToString();
            this.cboMaQH.SelectedValue = x.MaQH.ToString();
            this.txtTaiKhoan.Text = x.TaiKhoan;
            this.btnSave.Enabled = true;
            this.gpTaiKhoan.Enabled = false;
       
        }

        /// <summary>
        /// Load data in comboBox MaQH và MaNhom
        /// </summary>
        private void loadDataToComboBox()
        {
            //---1/-Load data cho cboMaQH
            DataSet ds = new BusQuanHuyen().GetDataSet();
            this.cboMaQH.DataSource = ds.Tables[0];
            this.cboMaQH.DisplayMember = "tenQH";
            this.cboMaQH.ValueMember = "maQH";
            this.cboMaQH.SelectedIndex = -1;

            //---2/-Load data cho cboMaNhom
            ds = new BusNhomTaiKhoan().GetDataSet();
            this.cboMaNhom.DataSource = ds.Tables[0];
            this.cboMaNhom.DisplayMember = "tenNhom";
            this.cboMaNhom.ValueMember = "maNhom";
            this.cboMaNhom.SelectedIndex = -1;
        }

        /// <summary>
        /// Nhấn để bắt đầu thêm tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            ok = true;
            this.txtTaiKhoan.Text = "";
            this.txtHoDem.Text = "";
            this.txtTen.Text = "";
            this.txtDiaChi.Text = "";
            this.txtEmail.Text = "";
            this.txtGhiChu.Text = "";
            this.txtMatKhau.Text = "";
            this.txtXacNhan.Text = "";
            this.dtNgaySinh.Value = DateTime.Today; //---Cho ngày là ngày hôm nay
            this.rdNam.Checked = true;
            this.mtSoDT.Text = "";
            this.cboMaQH.SelectedIndex = -1;
            this.cboMaNhom.SelectedIndex = -1;
            this.txtHoDem.Focus();
        }

        /// <summary>
        /// Đóng gói dữ liệu tài khoản thành viên
        /// </summary>
        /// <returns></returns>
        private TaiKhoanTV packageTK()
        {
            TaiKhoanTV x = new TaiKhoanTV();
            //---Thông tin cá nhân
            x.HoDem = this.txtHoDem.Text.Trim();
            x.TenTV = this.txtTen.Text.Trim();
            x.NgaySinh = this.dtNgaySinh.Value;
            x.GioiTinh = this.rdNam.Checked;

            //---Thông tin liên lạc
            x.DiaChi = this.txtDiaChi.Text.Trim();
            x.MaQH = int.Parse(this.cboMaQH.SelectedValue.ToString());
            x.SoDT = this.mtSoDT.Text.Trim();
            x.Email = this.txtEmail.Text.Trim();
            x.GhiChu = this.txtGhiChu.Text.Trim();

            //--Tài khoản
            x.TaiKhoan = this.txtTaiKhoan.Text.Trim();
            x.MatKhau = new Encryption().SHA256_Hashing(this.txtMatKhau.Text.Trim()); //--Mã hóa mật khẩu
            x.MaNhom = int.Parse(this.cboMaNhom.SelectedValue.ToString());
            return x;

        }

        /// <summary>
        /// Kiểm tra điều kiện để nút save được bật
        /// </summary>
        /// <returns></returns>
        private bool enableSaveButton()
        {
             return (this.txtTaiKhoan.Text.Trim().Length > 0 && this.txtMatKhau.Text.Trim().Length > 0
                 && this.txtTen.Text.Trim().Length > 0 && this.cboMaNhom.SelectedIndex >= 0 && this.txtDiaChi.Text.Trim().Length > 0
                 && this.cboMaQH.SelectedIndex >= 0 && this.mtSoDT.Text.Trim().Length > 0);

        }

        /// <summary>
        /// Hoàn tất thêm tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                if (enableSaveButton() == true)
                {
                    if (txtMatKhau.Text.Trim().Equals(this.txtXacNhan.Text.Trim()))
                    {
                        BusTaiKhoanTV b = new BusTaiKhoanTV();
                        //---B1
                        b.info = packageTK();
                        //---B2 : Gọi hàm lưu dữ liệu
                        int kq = b.addTaiKhoanTV();
                        //---Thông báo kết quả
                        if (kq == 1)
                        {
                            MessageBox.Show(string.Format("Đã thêm thành công tài khoản {0} !!!", b.info.TaiKhoan));
                            ok = false;
                            this.btnNew.PerformClick();

                        }
                        else
                            MessageBox.Show("Lỗi !!!");
                    }
                    else
                    {
                        this.baoLoi.Show("Mật khẩu không khớp hãy nhập lại !!!", this.txtMatKhau, 0, -68, 4000);
                        this.txtMatKhau.Text = "";
                        this.txtXacNhan.Text = "";
                        this.txtMatKhau.Focus();
                    }
                }
                else
                    {
                        this.DieuKien();   //---Kiểm tra các lỗi ở UI của người dùng                     
                    }
                   
            }
            else
            {
                    BusTaiKhoanTV b = new BusTaiKhoanTV();
                    //---B1
                    b.info = packageTK();
        
                    string TK = this.txtTaiKhoan.Text;
                    b.info.TaiKhoan = TK;
                    //---B2: Gọi hàm update dữ liệu
                    int kq = b.updateTaiKhoanTV();
                    //---Thông báo kết quả
                    if (kq == 1)
                    {
                        MessageBox.Show(string.Format("Đã update thành công tài khoản {0} !!!", b.info.TaiKhoan));
                    }
                    this.Dispose();
            }
        }

        /// <summary>
        /// Kiểm tra các lỗi nhập liệu ở giao diện giao tiếp người dùng UI
        /// </summary>
        private void DieuKien()
        {
            if (this.txtTen.Text.Trim().Equals(""))
            {
                this.baoLoi.Show("Chưa nhập tên !!!", this.txtTen, 0, -68, 4000);
                this.txtTen.Focus();
            }
            else if (this.txtDiaChi.Text.Trim().Equals(""))
            {
                this.baoLoi.Show("Chưa nhập địa chỉ !!!", this.txtDiaChi, 0, -68, 4000);
                this.txtDiaChi.Focus();
            }
            else if (this.mtSoDT.Text.Trim().Equals(""))
            {
                this.baoLoi.Show("Chưa nhập số điện thoại !!!", this.mtSoDT, 0, -68, 4000);
                this.mtSoDT.Focus();
            }
            else if (this.cboMaQH.SelectedIndex == -1)
            {
                this.baoLoi.Show("Chưa chọn quận huyện !!!", this.cboMaQH, 0, -68, 4000);
                this.cboMaQH.Focus();
            }
            else if (this.cboMaNhom.SelectedIndex == -1)
            {
                this.baoLoi.Show("Chưa chọn nhóm !!!", this.cboMaNhom, 0, -68, 4000);
                this.cboMaNhom.Focus();
            }
            else if (this.txtTaiKhoan.Text.Trim().Equals(""))
            {
                this.baoLoi.Show("Chưa nhập tài khoản !!!", this.txtTaiKhoan, 0, -68, 4000);
                this.txtTaiKhoan.Focus();
            }

            else if (this.txtMatKhau.Text.Trim().Equals(""))
            {
                this.baoLoi.Show("Chưa nhập mật khẩu !!!", this.txtMatKhau, 0, -68, 4000);
                this.txtMatKhau.Focus();
            }

        }

        /// <summary>
        /// In dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy kết nối máy in!!!");
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

        /// <summary>
        /// Dùng theo cách cũ. Cách mới không dùng!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            //this.btnSave.Enabled = enableSaveButton();
        }

        private void cboMaQH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.btnSave.Enabled = enableSaveButton();
        }

        private void cboMaNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.btnSave.Enabled = enableSaveButton();
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            //this.btnSave.Enabled = enableSaveButton();
        }

        private void mtSoDT_TextChanged(object sender, EventArgs e)
        {
            //this.btnSave.Enabled = enableSaveButton();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            //this.btnSave.Enabled = enableSaveButton();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            //this.btnSave.Enabled = enableSaveButton();
        }
    }
}
