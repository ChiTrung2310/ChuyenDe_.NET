using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang18.BusinessLayer.Entity
{
    class GroupTaiKhoan
    {
        /// <summary>
        /// Mã nhóm
        /// </summary>
        public int MaNhom { get; set; }

        /// <summary>
        /// Tên gọi của nhóm
        /// </summary>
        public string TenNhom { get; set; }

        /// <summary>
        /// Các thông tin liên quan
        /// </summary>
        public string GhiChu { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GroupTaiKhoan()
        {
            this.TenNhom = "";
            this.GhiChu = "";
        }
    }
}
