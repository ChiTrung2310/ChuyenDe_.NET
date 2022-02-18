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
    class BusNhomTaiKhoan
    {
        public GroupTaiKhoan info { set; get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BusNhomTaiKhoan()
        {
            this.info = new GroupTaiKhoan();
        }

        /// <summary>
        /// Trả về câu DML dùng cho mục đích insert dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string insertSql()
        {
            return string.Format("Insert Into nhomTk (tenNhom, ghiChu) Values (N'{0}', N'{1}');", this.info.TenNhom, this.info.GhiChu);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Update dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string updateSql()
        {
            return string.Format("Update nhomTk set tenNhom = N'{0}', ghiChu = N'{1}' Where maNhom = {2}", this.info.TenNhom, this.info.GhiChu, this.info.MaNhom);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Delete dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string deleteSql()
        {
            return string.Format("Delete nhomTk Where maNhom = {0}", this.info.MaNhom);
        }

        /// <summary>
        /// Thêm thông tin nhóm tài khoản vào database
        /// </summary>
        /// <returns></returns>
        public int addNhomTk()
        {
            int kq = 0;
            string query = this.insertSql();
            kq = new daoSqlServer().executeNonQuery(query);
            return kq;
        }

        /// <summary>
        /// Update thông tin nhóm tài khoản vào database
        /// </summary>
        /// <returns></returns>
        public int updateNhomTk()
        {
            return new daoSqlServer().executeNonQuery(updateSql());
        }

        /// <summary>
        /// Delete thông tin nhóm tài khoản trong database
        /// </summary>
        /// <returns></returns>
        public int deleteNhomTk()
        {
            return new daoSqlServer().executeNonQuery(deleteSql());
        }

        /// <summary>
        /// Đọc về dữ liệu từ table nhomTk và trả về DataSet Object
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            string query = "Select * from nhomTk";
            return new daoSqlServer().GetDataSet(query, "nhomTk");
        }
    
    }
}
