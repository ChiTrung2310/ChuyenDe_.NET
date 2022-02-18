using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BanHang18.BusinessLayer.Entity
{
    class BaiViet
    {
        /// <summary>
        /// Mã bài viết
        /// </summary>
        public string MaBV { get; set; }

        /// <summary>
        /// Tên bài viết
        /// </summary>
        public string TenBV { get; set; }

        /// <summary>
        /// Hình đại diện bài viết
        /// </summary>
        public Image HinhDD { get; set; }

        /// <summary>
        /// Tóm tắt của bài viết
        /// </summary>
        public string TomTat { get; set; }

        /// <summary>
        /// Ngày đăng bài viết
        /// </summary>
        public DateTime NgayDang { get; set; }

        /// <summary>
        /// Mã loại sản phẩm
        /// </summary>
        public int MaLoai { get; set; }

        /// <summary>
        /// Nội dung bài viết
        /// </summary>
        public string NoiDung { get; set; }

        /// <summary>
        /// Tài khoản
        /// </summary>
        public string TaiKhoan { get; set; }

        /// <summary>
        /// Đã duyệt 
        /// </summary>
        public string DaDuyet { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaiViet()
        {
            this.MaBV = "";
            this.TenBV = "";
            this.HinhDD = new Bitmap(300, 300); ;
            this.TomTat = "";
            this.NoiDung = "";
            this.TaiKhoan = "";
        }

        public BaiViet(Bitmap x)
        {
            this.MaBV = "";
            this.TenBV = "";
            this.HinhDD = x;
            this.TomTat = "";
            this.NoiDung = "";
            this.TaiKhoan = "";
        }
    }
}
