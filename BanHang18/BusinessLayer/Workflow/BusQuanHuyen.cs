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
    class BusQuanHuyen
    {
        public QuanHuyen info { set; get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BusQuanHuyen()
        {
            this.info = new QuanHuyen();
        }

        /// <summary>
        /// Trả về câu DML dùng cho mục đích insert dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string insertSql()
        {
            return string.Format("Insert Into quanHuyen (tenQH, tinhThanh, ghiChu) Values (N'{0}', N'{1}' , N'{2}');", this.info.TenQH, this.info.TinhThanh, this.info.GhiChu);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Update dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string updateSql()
        {
            return string.Format("Update quanHuyen set tenQH = N'{0}', tinhThanh = N'{1}', ghiChu = N'{2}' Where maQH = {3} ", this.info.TenQH, this.info.TinhThanh, this.info.GhiChu, this.info.MaQH);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Delete dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string deleteSql()
        {
            return string.Format("Delete quanHuyen Where maQH = {0}", this.info.MaQH);
        }

        /// <summary>
        /// Thêm thông tin quận huyện vào database
        /// </summary>
        /// <returns></returns>
        public int addQuanHuyen()
        {
            int kq = 0;
            string query = this.insertSql();
            kq = new daoSqlServer().executeNonQuery(query);
            return kq;
        }

        /// <summary>
        /// Update thông tin quận huyện vào database
        /// </summary>
        /// <returns></returns>
        public int updateQuanHuyen()
        {
            return new daoSqlServer().executeNonQuery(updateSql());
        }

        /// <summary>
        /// Delete thông tin quận huyện trong database
        /// </summary>
        /// <returns></returns>
        public int deleteQuanHuyen()
        {
            return new daoSqlServer().executeNonQuery(deleteSql());
        }

        /// <summary>
        /// Đọc về dữ liệu từ table quanHuyen và trả về DataSet Object
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            string query = "Select * from quanHuyen";
            return new daoSqlServer().GetDataSet(query, "quanHuyen");
        }
    }
}
