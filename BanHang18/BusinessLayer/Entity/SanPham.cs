using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BanHang18.BusinessLayer.Entity
{
    class SanPham
    {
        /// <summary>
        /// Mã số của sản phẩm
        /// </summary>
        public string MaSP { get; set; }

        /// <summary>
        /// Tên gọi của sản phẩm
        /// </summary>
        public string TenSP { get; set; }

        /// <summary>
        /// Hình đại diện của sản phẩm
        /// </summary>
        public Image HinhDD { get; set; }

        /// <summary>
        /// Tóm tắt về sản phẩm
        /// </summary>
        public string TomTat { get; set; }

        /// <summary>
        /// Nhà sản xuất sản phẩm
        /// </summary>
        public string NhaSanXuat { get; set; }

        /// <summary>
        /// Ngày đăng sản phẩm
        /// </summary>
        public DateTime NgayDang { get; set; }

        /// <summary>
        /// Mã loại sản phẩm
        /// </summary>
        public int MaLoai { get; set; }

        /// <summary>
        /// Nội dung sản phẩm
        /// </summary>
        public string NoiDung { get; set; }

        /// <summary>
        /// Tài khoản
        /// </summary>
        public string TaiKhoan { get; set; }

        /// <summary>
        /// Đã duyệt hay chưa
        /// </summary>
        public Boolean DaDuyet { get; set; }

        /// <summary>
        /// Giá bán của sản phẩm
        /// </summary>
        public int GiaBan { get; set; }

        /// <summary>
        /// Giảm giá cho sản phẩm
        /// </summary>
        public int GiamGia { get; set; }

        /// <summary>
        /// Đon vị tính của sản phẩm
        /// </summary>
        public string DonViTinh { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SanPham()
        {
            this.MaSP = "";
            this.TenSP = "";
            this.NoiDung = "";
            this.TomTat = "";
            this.TaiKhoan = "";
            this.NhaSanXuat = "";
            this.DonViTinh = "";
            this.NgayDang = new DateTime(1900, 1, 1);
            this.HinhDD = new Bitmap(300, 300);
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="x"></param>
        public SanPham(Bitmap x)
        {
            this.MaSP = "";
            this.TenSP = "";
            this.NoiDung = "";
            this.TomTat = "";
            this.TaiKhoan = "";
            this.NhaSanXuat = "";
            this.DonViTinh = "";
            this.NgayDang = new DateTime(1900, 1, 1);
            this.HinhDD = x;
        }
    }
}
