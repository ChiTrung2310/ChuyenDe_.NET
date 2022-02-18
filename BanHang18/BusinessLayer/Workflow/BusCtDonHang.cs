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
    class BusCtDonHang
    {
        public CtDonHang info { set; get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BusCtDonHang()
        {
            this.info = new CtDonHang();
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="x"></param>
        public BusCtDonHang(CtDonHang x)
        {
            this.info = x;
        }
        /// <summary>
        /// Trả về câu DML dùng cho mục đích insert dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        public string insertSql() //--public để đơn hàng có thể truy xuất
        {
            return string.Format("Insert Into ctDonHang (soDH, maSP, soLuong, giaBan, giamGia) " +
                                " Values ('{0}', '{1}' , {2} , {3}, {4} );", 
                                this.info.SoDH, this.info.MaSP, this.info.SoLuong, this.info.GiaBan, this.info.GiamGia);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Update dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string updateSql()
        {
            return string.Format("Update ctDonHang set maSP = '{0}', soLuong = {1}, giaBan = {2}, giamGia = {3} Where soDH = '{4}' And maSP='{0}' ",
                this.info.MaSP, this.info.SoLuong, this.info.GiaBan, this.info.GiamGia, this.info.SoDH);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Delete dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string deleteSql()
        {
            return string.Format("Delete ctDonHang Where soDH = '{0}' And maSP = '{1}' ", this.info.SoDH, this.info.MaSP);
        }

        /// <summary>
        /// Thêm thông tin chi tiết đơn hàng vào database
        /// </summary>
        /// <returns></returns>
        public int addCtDonHang()
        {           
            return new daoSqlServer().executeNonQuery(insertSql());           
        }

        /// <summary>
        /// Update thông tin chi tiết đơn hàng vào database
        /// </summary>
        /// <returns></returns>
        public int updateCtDonHang()
        {
            return new daoSqlServer().executeNonQuery(updateSql());
        }

        /// <summary>
        /// Delete thông tin chi tiết đơn hàng trong database
        /// </summary>
        /// <returns></returns>
        public int deleteCtDonHang()
        {
            return new daoSqlServer().executeNonQuery(deleteSql());
        }

        /// <summary>
        /// Đọc về dữ liệu từ table chi tiết đơn hàng và trả về DataSet Object
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet(string soDH)
        {
            string query = "Select soDH, maSP, soLuong, giaBan, giamGia from ctDonHang " +
                            "where soDH = 1 " +
                            (soDH.Trim().Length > 0 ? "And tenSP like N'" + soDH.Trim() + "%'" : "") ;
            return new daoSqlServer().GetDataSet(query, "ctDonHang");
        }
    }
}
