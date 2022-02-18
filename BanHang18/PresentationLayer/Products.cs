using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using BanHang18.BusinessLayer.Entity;
using BanHang18.BusinessLayer.Workflow;
using BanHang18.Lib.UserControls;

namespace BanHang18.PresentationLayer
{
    public partial class Products : Form
    {

        private bool isApproved;//

        public Products(bool isApproved)//
        {
            
            InitializeComponent();
            this.isApproved = isApproved;//
            createCard(this.isApproved); //
        }

        public void createCard(bool isApproved)//
        {
            ArrayList list = new BusSanPham().getListOfProduct(isApproved);//--Xét theo đã duyệt hay chưa
            foreach(SanPham i in list)
            {
                ProductCard x = new ProductCard();
                x.MaSP = i.MaSP;
                x.TenSP = i.TenSP;
                x.HinhDD = i.HinhDD;
                x.GiaBan = i.GiaBan;
                x.GiamGia = i.GiamGia;

                x.editButton_Click += X_editButton_Click;
                x.deleteButton_Click += X_deleteButton_Click;

                //-----
                this.prdRegion.Controls.Add(x);

            }

        }

        private void X_editButton_Click(object sender, EventArgs e)
        {
            Button nut = (Button)sender;
            string maSP = nut.AccessibleDescription;
            NewProduct p = new NewProduct(maSP);
            p.MdiParent = this.MdiParent;
            p.Show();
            //this.Dispose();
        }

        private void X_deleteButton_Click(object sender, EventArgs e)
        {
            Button nut = (Button)sender;
            string maSP = nut.AccessibleDescription;
            BusSanPham x = new BusSanPham();
            x.info.MaSP = maSP;
            if (x.deleteSanPham() > 0)
            {
                MessageBox.Show("Đã xóa thành công 1 sản phẩm !!!");
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {

        }
    }
}
