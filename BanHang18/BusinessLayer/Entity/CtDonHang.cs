using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang18.BusinessLayer.Entity
{
    class CtDonHang
    {
        /// <summary>
        /// Số đơn hàng
        /// </summary>
        public string SoDH { get; set; }

        /// <summary>
        /// Mã Sản phẩm trong danh sách
        /// </summary>
        public string MaSP { get; set; }

        /// <summary>
        /// Số lượng đặt mua
        /// </summary>
        public int SoLuong { get; set; }

        /// <summary>
        /// Giá bán của sản phẩm ở thời điểm tương ứng
        /// </summary>
        public int GiaBan { get; set; }

        /// <summary>
        /// Tỉ lệ giảm giá của sản phẩm 
        /// </summary>
        public int GiamGia { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CtDonHang()
        {
            this.SoDH = "";
            this.MaSP = "";
        }
    }
}
