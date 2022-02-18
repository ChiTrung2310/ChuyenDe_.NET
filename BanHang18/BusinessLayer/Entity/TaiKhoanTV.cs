using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang18.BusinessLayer.Entity
{
    class TaiKhoanTV
    {
        /// <summary>
        /// Tài khoản
        /// </summary>
        public string TaiKhoan { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string MatKhau { get; set; }

        /// <summary>
        /// Mã nhóm
        /// </summary>
        public int MaNhom { get; set; }

        /// <summary>
        /// Họ đệm
        /// </summary>
        public string HoDem { get; set; }

        /// <summary>
        /// Tên thành viên
        /// </summary>
        public string TenTV { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime NgaySinh { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Boolean GioiTinh { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string SoDT { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string DiaChi { get; set; }

        /// <summary>
        /// Mã quận huyện
        /// </summary>
        public int MaQH { get; set; }

        /// <summary>
        /// Trạng thái của tài khoản
        /// </summary>
        public Boolean TrangThai { get; set; }

        /// <summary>
        /// Các thông tin liên quan
        /// </summary>
        public string GhiChu { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaiKhoanTV()
        {
            this.TaiKhoan = "";
            this.MatKhau = "";
            this.HoDem = "";
            this.NgaySinh = new DateTime(1900, 1, 1);
            this.SoDT = "";
            this.Email = "";
            this.DiaChi = "";
            this.GhiChu = "";
        }
    }
}
