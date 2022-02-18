using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanHang18.BusinessLayer.Entity;
using BanHang18.DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using BanHang18.Lib;
using System.Collections;

namespace BanHang18.BusinessLayer.Workflow
{
    class BusBaiViet
    {
        public BaiViet info { set; get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BusBaiViet()
        {
            this.info = new BaiViet();
        }

        /// <summary>
        /// Tái khởi gán
        /// </summary>
        /// <param name="x"></param>
        public BusBaiViet(BaiViet x)
        {
            this.info = x;
        }

        /// <summary>
        /// Trả về câu DML dùng cho mục đích insert dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string insertSql()
        {
            return string.Format("Insert Into baiViet (maBV, tenBV, hinhDD, ndTomTat, ngayDang, maLoai, noiDung, taiKhoan, daDuyet) " +
                "Values ('{0}', N'{1}','{2}', N'{3}', '{4}', {5}, N'{6}', N'{7}', {8} );",
                this.info.MaBV, this.info.TenBV, Tools.ImageToString(this.info.HinhDD), this.info.TomTat,
                DateTime.Now, this.info.MaLoai, this.info.NoiDung, this.info.TaiKhoan, "0" );
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Update dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string updateSql()
        {
            return string.Format("Update baiViet set tenBV = N'{0}', ndTomTat = N'{1}', noiDung = N'{2}', hinhDD = '{3}', daDuyet={4} " +
                                 "Where maBV = {5}", this.info.TenBV, this.info.TomTat, this.info.NoiDung, Tools.ImageToString(this.info.HinhDD),
                                                    "0", this.info.MaBV);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Delete dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string deleteSql()
        {
            return string.Format("Delete baiViet Where maBV = {0}", this.info.MaBV);
        }

        /// <summary>
        /// Thêm thông tin bài viết vào database
        /// </summary>
        /// <returns></returns>
        public int addBaiViet()
        {
            int kq = 0;
            string query = this.insertSql();
            kq = new daoSqlServer().executeNonQuery(query);
            return kq;
        }

        /// <summary>
        /// Update thông tin bài viết vào database
        /// </summary>
        /// <returns></returns>
        public int updateBaiViet()
        {
            return new daoSqlServer().executeNonQuery(updateSql());
        }

        /// <summary>
        /// Delete thông tin bài viết trong database
        /// </summary>
        /// <returns></returns>
        public int deleteBaiViet()
        {
            return new daoSqlServer().executeNonQuery(deleteSql());
        }

        /// <summary>
        /// Đọc thông tin của bài viết từ Database
        /// </summary>
        /// <param name="maSP">Thông tin bài viết muốn đọc</param>
        /// <returns></returns>
        public BaiViet getInfo(string maBaiViet)
        {
            BaiViet kq = new BaiViet();
            SqlDataReader reader = new daoSqlServer().getDataReader("Select maBV, tenBV, hinhDD, ngayDang, taiKhoan, ndTomTat, noiDung, maLoai " +
                                                                     "From baiViet Where maBV='" + maBaiViet + "'");
            while (reader.Read())
            {
                kq.MaBV = reader.GetString(0);
                kq.TenBV = reader.GetString(1);
                kq.HinhDD = Tools.stringToImage(reader.GetString(2));
                kq.NgayDang = reader.GetDateTime(3);
                kq.TaiKhoan = reader.GetString(4);
                kq.TomTat = reader.GetString(5);
                kq.NoiDung = reader.GetString(6);
                kq.MaLoai = reader.GetInt32(7);
            }
            return kq;

        }


        /// <summary>
        /// Đọc danh sách bài viết dựa vào mã loại sản phẩm hay đã duyệt
        /// </summary>
        /// <param name="isActive">True: đã kích hoạt - False: chưa kích hoạt</param>
        /// <param name="maLoai">Mã Loại sản phẩm dùng cho Filter [0: Không lọc]</param>
        /// <returns></returns>
        public DataSet GetDataSet(bool isActive, int maLoai)
        {
            string query = "Select maBV, tenBV, taiKhoan, hinhDD, ndTomTat, NgayDang, noiDung " +
                           "From baiViet/* t inner join loaiSP q on (t.maLoai = q.maLoai)*/ " +
                           "Where daDuyet = " + (isActive ? "1" : "0") + (maLoai > 0 ? " And /*t.*/maLoai = " + maLoai.ToString() : "") + " Order by maBV";
            return new daoSqlServer().GetDataSet(query, "baiViet");
        }
    }
}
