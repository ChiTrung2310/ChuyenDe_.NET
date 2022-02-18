using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BanHang18.PresentationLayer;

namespace BanHang18
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            Login login = new Login(); //---Gọi form login khi chạy chương trình
            login.ShowDialog();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DiaChi d = new DiaChi();
            d.MdiParent = this;
            d.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhomTaiKhoan nTk = new NhomTaiKhoan();
            nTk.MdiParent = this;
            nTk.Show();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoaiSanPham LSP = new LoaiSanPham();
            LSP.MdiParent = this;
            LSP.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Accounts TK = new Accounts();
            TK.MdiParent = this;
            TK.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AccountManagement Acc = new AccountManagement(false);
            Acc.MdiParent = this;
            Acc.Show();

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AccountManagement Acc = new AccountManagement(true);
            Acc.MdiParent = this;
            Acc.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewProduct NP = new NewProduct();
            NP.MdiParent = this;
            NP.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Products PD = new Products(false);
            PD.MdiParent = this;
            PD.Show();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Products PD = new Products(true);
            PD.MdiParent = this;
            PD.Show();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddItem AT = new AddItem();
            AT.MdiParent = this;
            AT.Show();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customer CT = new Customer();
            CT.MdiParent = this;
            CT.Show();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Purchase Pc = new Purchase();
            Pc.MdiParent = this;
            Pc.Show();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoaiSanPham LSP = new LoaiSanPham();
            LSP.MdiParent = this;
            LSP.Show();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewPosts PS = new NewPosts();
            PS.MdiParent = this;
            PS.Show();
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Posts P = new Posts(true);
            P.MdiParent = this;
            P.Show();
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Posts P = new Posts(false);
            P.MdiParent = this;
            P.Show();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Order O = new Order(true);
            O.MdiParent = this;
            O.Show();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Order O = new Order(false);
            O.MdiParent = this;
            O.Show();
        }
    }
}
