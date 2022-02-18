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
using BanHang18.Lib;

namespace BanHang18
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Thoát hoàn toàn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //---Lấy thông tin người dùng nhập từ giao diện
            string tk = this.txtTaiKhoan.Text.Trim();
            string mk = this.txtPass.Text.Trim();
            if(tk.Length>0 && mk.Length > 0)
            {
                //--Băm mật khẩu vừa nhập
                mk = new Encryption().SHA256_Hashing(mk);
                TaiKhoanTV TK = new BusTaiKhoanTV().getInfo(tk);
                //--So sánh mật khẩu và tài khoản
                if (TK.TaiKhoan.Equals(tk) && TK.MatKhau.Equals(mk))
                {
                    secureObject.ttDangNhap = TK;
                    this.Dispose();
                }
                else
                {
                    this.baoLoi.Show("Thông tin đăng nhập không hợp lệ!!!", this.txtTaiKhoan, 0, -68, 4000);
                    this.txtTaiKhoan.Text = "";
                    this.txtPass.Text = "";
                    this.txtTaiKhoan.Focus();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbtienTrinh.Value < pbtienTrinh.Maximum)
                pbtienTrinh.Value += 10;
        }

        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtPass.Text.Trim().Length > 0)
                    btnLogin_Click(this.btnLogin, e);
                else
                    this.txtPass.Focus();

            }
            else if (e.KeyCode == Keys.Escape)
                btnExit_Click(this.btnExit, e);
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtTaiKhoan.Text.Trim().Length > 0)
                    btnLogin_Click(this.btnLogin, e);
                else
                    this.txtTaiKhoan.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
                btnExit_Click(this.btnExit, e);
        }
    }
}
