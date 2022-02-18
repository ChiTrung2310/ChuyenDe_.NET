using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanHang18.BusinessLayer.Entity;
using BanHang18.DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BanHang18.BusinessLayer.Workflow
{
    class BusKhachHang
    {
        public KhachHang info { set; get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BusKhachHang()
        {
            this.info = new KhachHang();
        }

        /// <summary>
        /// Trả về câu DML dùng cho mục đích insert dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string insertSql()
        {
            return string.Format("Insert Into khachHang (maKH, tenKH, soDT, email, diaChi, maQH, ngaySinh, gioiTinh, ghiChu) " +
                                              "Values ('{0}', N'{1}', '{2}', '{3}', N'{4}', {5},'{6}', {7}, N'{8}' )",
                                              this.info.MaKh, this.info.TenKh,this.info.SoDT,this.info.Email,this.info.DiaChi, 
                                              this.info.MaQH, this.info.NgaySinh, (this.info.GioiTinh ? 1 : 0), this.info.GhiChu);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Update dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string updateSql()
        {
            return string.Format("Update khachHang set soDT = '{0}', email = '{1}', diaChi = N'{2}', maQH = {3}, ghiChu = N'{4}' Where maKH = '{5}' ",
                this.info.SoDT, this.info.Email, this.info.DiaChi, this.info.MaQH, this.info.GhiChu, this.info.MaKh);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Delete dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string deleteSql()
        {
            return string.Format("Delete khachHang Where maKH = '{0}' ", this.info.MaKh);
        }

        /// <summary>
        /// Thêm thông tin khách hàng vào database
        /// </summary>
        /// <returns></returns>
        public int addKhachHang()
        {
            int kq = 0;
            string query = this.insertSql();
            kq = new daoSqlServer().executeNonQuery(query);
            return kq;
        }

        /// <summary>
        /// Update thông tin khách hàng vào database
        /// </summary>
        /// <returns></returns>
        public int updateKhachHang()
        {
            return new daoSqlServer().executeNonQuery(updateSql());
        }

        /// <summary>
        /// Delete thông tin khách hàng trong database
        /// </summary>
        /// <returns></returns>
        public int deleteKhachHang()
        {
            return new daoSqlServer().executeNonQuery(deleteSql());
        }

        /// <summary>
        /// Đọc về dữ liệu từ table khachHang và trả về DataSet Object
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            //iif(gioiTinh = 1, 'Nam', N'Nữ') as gioiTinh
            string query = "Select * from khachHang";
            return new daoSqlServer().GetDataSet(query, "khachHang");
        }

        /// <summary>
        /// Đọc thông tin khách hàng từ database
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public KhachHang getInfo(string maKH)
        {
            KhachHang kq = new KhachHang();
            SqlDataReader reader = new daoSqlServer().getDataReader("Select tenKH, ngaySinh, gioiTinh, soDT, email, diaChi, maQH, ghiChu from khachHang where maKH='" + maKH + "'");
            while (reader.Read())
            {
                kq.TenKh = reader.GetString(0);
                kq.NgaySinh = reader.GetDateTime(1);
                kq.GioiTinh = reader.GetBoolean(2);
                kq.SoDT = reader.GetString(3);
                kq.Email = reader.GetString(4);
                kq.DiaChi = reader.GetString(5);
                kq.MaQH = reader.GetInt32(6);
                kq.GhiChu = reader.GetString(7);
            }
            return kq;
        }

    }
}

