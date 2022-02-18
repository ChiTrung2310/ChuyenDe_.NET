using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang18.BusinessLayer.Entity
{
    class LoaiSp
    {
        /// <summary>
        /// Mã loại sản phẩm
        /// </summary>
        public int MaLoai { get; set; }

        /// <summary>
        /// Tên loại sản phẩm
        /// </summary>
        public string LoaiSP { get; set; }

        /// <summary>
        /// Các thông tin liên quan
        /// </summary>
        public string GhiChu { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoaiSp()
        {
            this.LoaiSP = "";
            this.GhiChu = "";
        }
    }
}
