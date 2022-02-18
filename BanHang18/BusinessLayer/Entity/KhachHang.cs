using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang18.BusinessLayer.Entity
{
    class KhachHang
    {
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string MaKh { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string TenKh { get; set; }

        /// <summary>
        /// Số điện thoại khách hàng
        /// </summary>
        public string SoDT { get; set; }

        /// <summary>
        /// Email khách hàng
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string DiaChi { get; set; }

        /// <summary>
        /// Mã quận huyện
        /// </summary>
        public int MaQH { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime NgaySinh { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Boolean GioiTinh { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string GhiChu { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public KhachHang()
        {
            this.MaKh = "";
            this.TenKh = "";
            this.SoDT = "";
            this.Email = "";
            this.DiaChi = "";
            this.GhiChu = "";
        }
    }
}
