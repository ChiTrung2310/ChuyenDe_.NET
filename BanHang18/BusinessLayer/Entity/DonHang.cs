using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang18.BusinessLayer.Entity
{
    class DonHang
    {
        /// <summary>
        /// Số đơn hàng
        /// </summary>
        public string SoDH { get; set; }

        /// <summary>
        /// Mã khách hàng đặt mua sản phẩm
        /// </summary>
        public string MaKH { get; set; }

        /// <summary>
        /// Tài khoản của nhân viên bán hàng
        /// </summary>
        public string TaiKhoan { get; set; }

        /// <summary>
        /// Ngày đặt hàng
        /// </summary>
        public DateTime NgayDat { get; set; }

        /// <summary>
        /// Ngày giao hàng
        /// </summary>
        public DateTime NgayGH { get; set; }

        /// <summary>
        /// Địa chỉ giao hàng
        /// </summary>
        public string DiaChiGH { get; set; }

        /// <summary>
        /// Trạng thái của đơn hàng [1: bị hủy, 0: Mới đặt mua, chưa kích hoạt 1:Đã kích hoạt 2: Đang xử lý 3: Đang giao cho khách 4: Đã thanh toán]
        /// </summary>
        public int TrangThai { get; set; }

        /// <summary>
        /// Thông tin ghi chú liên quan đến đơn hàng
        /// </summary>
        public string GhiChu { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DonHang()
        {
            this.SoDH = "";
            this.MaKH = "";
            this.TaiKhoan = "";
            this.GhiChu = "";
            this.DiaChiGH = "";
            this.NgayDat = new DateTime(1900, 1, 1);
            this.NgayGH= new DateTime(1900, 1, 1);
        }
    }
}
