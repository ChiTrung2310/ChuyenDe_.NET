using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanHang18.BusinessLayer.Entity;

namespace BanHang18.Lib.UserControls
{
    public partial class ProductCard : UserControl
    {
        public string MaSP { 
            set { this.btnEdit.AccessibleDescription = value;
                this.btnDelete.AccessibleDescription = value;
            }
        }

        public string TenSP
        {
            set
            {
                this.lblName.Text = value;
            } 
        }

        public Image HinhDD
        {
            set
            {
                this.pbImage.Image = value;
            }
        }

        public int GiaBan
        {
            set
            {
                this.lblGia.Text = value.ToString("#,### VNĐ"); //--Định dạng tiền Việt Nam hiển thị trên productCard
            }
        }

        public int GiamGia
        {
            set
            {
                this.lblGiamGia.Text = value.ToString()+"%"; //--Định dạng thêm dấu % vào cột giảm giá
            }
        }

        /// <summary>
        /// Gắn sự kiện để xử lý cho nút edit trong Card Product
        /// </summary>
        public event EventHandler editButton_Click
        {
            add { this.btnEdit.Click += value; }
            remove { this.btnEdit.Click -= value; }
        }

        /// <summary>
        /// Gắn sự kiện để xử lý cho nút delete trong Card Product
        /// </summary>
        public event EventHandler deleteButton_Click
        {
            add { this.btnDelete.Click += value; }
            remove { this.btnDelete.Click -= value; }
        }


        public ProductCard()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
