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
    public partial class Purchase : Form
    {
        public static string maKH = "";
        public static string maSP = "";
        public Purchase()
        {
            InitializeComponent();
            this.refreshUI();
        }

        /// <summary>
        /// Nút tạo đơn hàng mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            this.refreshUI();
        }

        /// <summary>
        /// Làm mới lại dữ liệu trên UI
        /// </summary>
        private void refreshUI()
        {
            this.txtMaDH.Text = "";
            this.txtNguoiBan.Text = Lib.secureObject.ttDangNhap.HoDem + " " + Lib.secureObject.ttDangNhap.TenTV;
            this.txtNgayDH.Text = string.Format("{0: hh:mm dd/MM/yyy}", DateTime.Now);
            this.checkBox1.Checked = false;
            this.txtNgayGH.Text = this.txtNgayDH.Text;
            this.txtKhachHang.Text = "";
            this.txtDiaChi.Text = "";
            this.txtMaKH.Text = "";
            this.txtHoTen.Text = "";
            this.txtSoDT.Text = "";
            this.txtNgaySinh.Value = DateTime.Now;
            this.txtEmail.Text = "";
            this.txtdiaChiKH.Text = "";
            this.rdGioiTinh.Checked = true;
            this.dsOrder.Rows.Clear();
            this.txtMaDH.Focus();

        }

        /// <summary>
        /// Nhấn để thêm món hàng vào DataGridView Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewItem_Click(object sender, EventArgs e)
        {
            new AddItem().ShowDialog(this);
            if (maSP.Length > 0)
            {
                //---Tạo ra một dòng trong chi tiết đặt hàng
                //---B1: Đọc thông tin sản phẩm dựa vào getInfo method
                SanPham x = new BusSanPham().getInfo(maSP);
                if(!this.searchItem(maSP))
                this.addNewRow(x);
            }
        }

        /// <summary>
        /// Hàm tăng số lượng thay vì tăng thêm 1 dòng
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        private bool searchItem(string maSP)
        {
            bool kq = false;
            foreach(DataGridViewRow i in this.dsOrder.Rows)
                if (i.Cells["mSP"].Value.ToString().Equals(maSP))
                {
                    //--B1: Get current 
                    int q = int.Parse(i.Cells["soLuong"].Value.ToString());
                    i.Cells["soLuong"].Value = ++q;
                    //--B2: Get giaBan - giamGia - Tính Tong tien lại
                    int p = int.Parse(i.Cells["giaBan"].Value.ToString());
                    int d = int.Parse(i.Cells["giamGia"].Value.ToString());
                    int v = q * p - d; //--Số tiền phải trả sau khi đã trừ tiền giảm giá
                    i.Cells["triGia"].Value = v;
                    //---B3: Set kq = true 
                    kq = true;
                    break;
                }
            return kq;
        }

        /// <summary>
        /// Tạo dòng thông tin sản phẩm đã chọn vào DataGridView
        /// </summary>
        /// <param name="x"></param>
        private void addNewRow(SanPham x)
        {
            //---B2: Dựa vào mã sản phẩm đã đọc tạo ra một dòng trong chi tiết đặt hàng
            DataGridViewRow dong = new DataGridViewRow();
            //---Tạo ô 1
            DataGridViewCell o1 = new DataGridViewTextBoxCell();
            o1.Value = x.MaSP;
            dong.Cells.Add(o1);

            //---Tạo ô 2
            DataGridViewCell o2 = new DataGridViewTextBoxCell();
            o2.Value = x.TenSP;
            dong.Cells.Add(o2);

            //---Tạo ô 3
            DataGridViewCell o3 = new DataGridViewTextBoxCell();
            o3.Value = x.DonViTinh;
            dong.Cells.Add(o3);

            //---Tạo ô 4
            DataGridViewCell o4 = new DataGridViewTextBoxCell();
            o4.Value = 1;
            dong.Cells.Add(o4);

            //---Tạo ô 5
            DataGridViewCell o5 = new DataGridViewTextBoxCell();
            o5.Value =  x.GiaBan;
            dong.Cells.Add(o5);

            //---Tạo ô 6
            DataGridViewCell o6 = new DataGridViewTextBoxCell();
            o6.Value = (x.GiaBan * x.GiamGia) / 100;
            dong.Cells.Add(o6);

            //---Tạo ô 7
            DataGridViewCell o7 = new DataGridViewTextBoxCell();
            o7.Value = (x.GiaBan - (x.GiaBan * x.GiamGia) / 100);
            dong.Cells.Add(o7);

            this.dsOrder.Rows.Add(dong);
        }

        /// <summary>
        /// Tạo đơn hàng && Ct Đơn hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPaymnet_Click(object sender, EventArgs e)
        {
            //--B1: Package UI donHang object
            DonHang d = new DonHang();
            d.SoDH = this.txtMaDH.Text.Trim();
            d.MaKH = this.txtMaKH.Text.Trim();
            d.TaiKhoan = Lib.secureObject.ttDangNhap.TaiKhoan;
            d.NgayDat = DateTime.Now;
            d.NgayGH = DateTime.Now;
            d.TrangThai = 4;
            d.DiaChiGH = this.txtDiaChi.Text.Trim();
            //--B2: Package DataGridView to List<CtDonHang>
            List<CtDonHang> items = new List<CtDonHang>();
            foreach(DataGridViewRow r in this.dsOrder.Rows)
            {
                CtDonHang c = new CtDonHang();
                c.SoDH = d.SoDH;
                c.MaSP = r.Cells["mSP"].Value.ToString();
                c.SoLuong = int.Parse(r.Cells["soLuong"].Value.ToString());
                c.GiaBan = int.Parse(r.Cells["giaBan"].Value.ToString());
                c.GiamGia = int.Parse(r.Cells["giamGia"].Value.ToString());
                items.Add(c);
            }
            //--B3: Run transaction 
            bool result = new BusDonHang().createCompleteOrder(d, items);
            //--B4: Message for the result 
            if (result)
            {
                MessageBox.Show("Tạo đơn hàng thành công");
                this.refreshUI();
            }

            else
                MessageBox.Show("Lỗi!!! Không thể tạo đơn hàng");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy kết nối máy in trước !!!");
        }

        /// <summary>
        /// Thoát form Purchase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Sự kiện khi chọn khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChonKH_Click(object sender, EventArgs e)
        {
            new Customer().ShowDialog(this);
            if (maKH.Length > 0)
            {
                this.txtMaKH.Text = maKH;
                KhachHang k = new BusKhachHang().getInfo(maKH);
                this.txtHoTen.Text = k.TenKh;
                this.txtKhachHang.Text = k.TenKh;
                this.txtSoDT.Text = k.SoDT;
                this.txtEmail.Text = k.Email;
                this.txtNgaySinh.Value = k.NgaySinh; 
                this.rdGioiTinh.Checked = k.GioiTinh;
                this.txtDiaChi.Text = k.DiaChi;
                this.txtdiaChiKH.Text = k.DiaChi;
                //---Reset after fill data
                maKH = "";
            }
        }

        private void rdGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            rdNu.Checked = !rdGioiTinh.Checked;
        }

        /// <summary>
        /// Sự kiện khi nhấn nút xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dsOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dsOrder.Columns["Command"].Index)
                this.dsOrder.Rows.Remove(this.dsOrder.Rows[e.RowIndex]);
        }

        private void calculateOrder()
        {
            long amount = 0, reduce = 0;
            foreach(DataGridViewRow i in this.dsOrder.Rows)
            {
                //--B1: Lấy số lượng, giá bán và giảm giá từ DataGridView
                int q = int.Parse(i.Cells["soLuong"].Value.ToString());
                int p = int.Parse(i.Cells["giaBan"].Value.ToString());
                int d = int.Parse(i.Cells["giamGia"].Value.ToString());

                //--B2: Tính tổng giá tiền và giảm giá
                amount += q * p;  //--Tổng tiền
                reduce +=  d*q;  //---Tổng tiền được giảm giá
                
            }
            //--Đổ dữ liệu lên giao diện
            this.txtTongSL.Text = string.Format("{0:#,### VNĐ}", amount);
            this.txtDuocGiam.Text = string.Format("{0:#,### VNĐ}", reduce);
            this.txtSoTien.Text = string.Format("{0:#,### VNĐ}", amount - reduce);

        }

        private void dsOrder_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.calculateOrder();
        }

        private void dsOrder_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.calculateOrder();
        }

        private void dsOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.calculateOrder();
        }
    }
}
