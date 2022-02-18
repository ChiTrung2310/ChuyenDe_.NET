using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang18.BusinessLayer.Entity
{
    class QuanHuyen
    {
        /// <summary>
        /// Mã quận huyện
        /// </summary>
        public int MaQH { get; set; }

        /// <summary>
        /// Tên gọi của quận huyện
        /// </summary>
        public string TenQH { get; set; }

        /// <summary>
        /// Tên thành phố / Tỉnh thành tương ứng
        /// </summary>
        public string TinhThanh { get; set; }

        /// <summary>
        /// Các thông tin khác liên quan
        /// </summary>
        public string GhiChu { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public QuanHuyen()
        {
            this.TenQH = "";
            this.TinhThanh = "";
            this.GhiChu = "";
        }


    }
}
