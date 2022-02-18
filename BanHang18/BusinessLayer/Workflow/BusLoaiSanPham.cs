using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanHang18.BusinessLayer.Entity;
using BanHang18.DataAccessLayer;
using System.Data;

namespace BanHang18.BusinessLayer.Workflow
{
    class BusLoaiSanPham
    {
        public LoaiSp info { set; get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BusLoaiSanPham()
        {
            this.info = new LoaiSp();
        }

        /// <summary>
        /// Trả về câu DML dùng cho mục đích insert dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string insertSql()
        {
            return string.Format("Insert Into loaiSP (loaiSP, ghiChu) Values (N'{0}', N'{1}');", this.info.LoaiSP, this.info.GhiChu);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Update dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string updateSql()
        {
            return string.Format("Update loaiSP set loaiSP = N'{0}', ghiChu = N'{1}' Where maLoai = {2}", this.info.LoaiSP, this.info.GhiChu, this.info.MaLoai);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Delete dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string deleteSql()
        {
            return string.Format("Delete loaiSP Where maLoai = {0}", this.info.MaLoai);
        }

        /// <summary>
        /// Thêm thông tin loại sản phẩm vào database
        /// </summary>
        /// <returns></returns>
        public int addLoaiSP()
        {
            int kq = 0;
            string query = this.insertSql();
            kq = new daoSqlServer().executeNonQuery(query);
            return kq;
        }

        /// <summary>
        /// Update thông tin loại sản phẩm vào database
        /// </summary>
        /// <returns></returns>
        public int updateLoaiSP()
        {
            return new daoSqlServer().executeNonQuery(updateSql());
        }

        /// <summary>
        /// Delete thông tin loại sản phẩm trong database
        /// </summary>
        /// <returns></returns>
        public int deleteLoaiSP()
        {
            return new daoSqlServer().executeNonQuery(deleteSql());
        }

        /// <summary>
        /// Đọc về dữ liệu từ table loại sản phẩm và trả về DataSet Object
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            string query = "Select * from loaiSP";
            return new daoSqlServer().GetDataSet(query, "loaiSP");
        }
    }
}
