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
    class BusSanPham
    {
        public SanPham info { set; get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BusSanPham()
        {
            this.info = new SanPham();
        }

        public BusSanPham(SanPham x)
        {
            this.info = x;
        }

        /// <summary>
        /// Trả về câu DML dùng cho mục đích insert dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string insertSql()
        {
            return string.Format("Insert Into sanPham (maSP, tenSP, hinhDD, ndTomTat, ngayDang, noiDung, taiKhoan, daDuyet, giaBan, giamGia, maLoai, nhaSanXuat, dvt) " +
                "Values ('{0}', N'{1}','{2}', N'{3}', '{4}', N'{5}', '{6}', {7}, {8}, {9}, {10}, N'{11}', N'{12}');",
                this.info.MaSP, this.info.TenSP, Tools.ImageToString(this.info.HinhDD), this.info.TomTat, 
                DateTime.Now, this.info.NoiDung, this.info.TaiKhoan, "0",
                this.info.GiaBan.ToString(), this.info.GiamGia.ToString(), this.info.MaLoai, this.info.NhaSanXuat, this.info.DonViTinh);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Update dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string updateSql()
        {
            return string.Format("Update sanPham set tenSP = N'{0}', ndTomTat = N'{1}', noiDung = N'{2}', hinhDD = '{3}', " +
                                                    " daDuyet={4}, giaBan={5}, giamGia={6}, maLoai={7}, nhaSanXuat=N'{8}', dvt=N'{9}' " +
                                  " Where maSP = {10}",
                                  this.info.TenSP, this.info.TomTat, this.info.NoiDung, Tools.ImageToString(this.info.HinhDD),
                                  "0", this.info.GiaBan.ToString(), this.info.GiamGia.ToString(), this.info.MaLoai.ToString(), 
                                  this.info.NhaSanXuat, this.info.DonViTinh, this.info.MaSP);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Delete dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string deleteSql()
        {
            return string.Format("Delete sanPham Where maSP = {0}", this.info.MaSP);
        }

        /// <summary>
        /// Thêm thông tin sản phẩm vào database
        /// </summary>
        /// <returns></returns>
        public int addSanPham()
        {
            int kq = 0;
            string query = this.insertSql();
            kq = new daoSqlServer().executeNonQuery(query);
            return kq;
        }

        /// <summary>
        /// Update thông tin sản phẩm vào database
        /// </summary>
        /// <returns></returns>
        public int updateSanPham()
        {
            return new daoSqlServer().executeNonQuery(updateSql());
        }

        /// <summary>
        /// Delete thông tin sản phẩm trong database
        /// </summary>
        /// <returns></returns>
        public int deleteSanPham()
        {
            return new daoSqlServer().executeNonQuery(deleteSql());
        }

        /// <summary>
        /// Đọc về dữ liệu từ table sanPham và trả về DataSet Object
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            string query = "Select * from sanPham";
            return new daoSqlServer().GetDataSet(query, "sanPham");
        }

        public DataSet GetDataSetItem()
        {
            string query = "Select maSP as ID, tenSP as N'Tên Sản Phẩm', nhaSanXuat as N'Nhà Sản Xuất', dvt as N'Đơn Vị', (FORMAT(giaBan, '#,### VNĐ')) as N'Giá Bán', giamGia as N'Giảm Giá(%)' from sanPham";
            return new daoSqlServer().GetDataSet(query, "sanPham");
        }

        /// <summary>
        /// Lấy danh sách sản phẩm phục vụ cho việc lọc dữ liệu
        /// </summary>
        /// <param name="likeName">Tên gần giống với tên sản phẩm</param>
        /// <returns></returns>
        public DataSet GetDataSet(string likeName)
        {
            string query = "Select maSP as ID, tenSP as N'Tên Sản Phẩm', nhaSanXuat as N'Nhà Sản Xuất', dvt as N'Đơn Vị', (FORMAT(giaBan, '#,### VNĐ')) as N'Giá Bán', (FORMAT(giaBan*giamGia/100, '#,### VNĐ')) as N'Được giảm' from sanPham " +
                            "where daDuyet = 1 " +
                            (likeName.Trim().Length>0 ? "And tenSP like N'" +likeName.Trim()+ "%'" : "") + "Order by tenSP";
            return new daoSqlServer().GetDataSet(query, "sanPham");
        }

        /// <summary>
        /// Đọc thông tin của sản phẩm từ Database
        /// </summary>
        /// <param name="maSP">Thông tin sản phẩm muốn đọc</param>
        /// <returns></returns>
        public SanPham getInfo(string maSP)
        {
            SanPham kq = new SanPham();
            SqlDataReader reader = new daoSqlServer().getDataReader("Select maSP, tenSP, maLoai, hinhDD, ndTomTat, ngayDang, noiDung, taiKhoan, daDuyet, giaBan, giamGia, nhaSanXuat, dvt " +
                                                                     "From sanPham Where maSP='" + maSP + "'");
            while (reader.Read())
            {
                kq.MaSP = reader.GetString(0);
                kq.TenSP = reader.GetString(1);
                kq.MaLoai = reader.GetInt32(2);
                kq.HinhDD = Tools.stringToImage(reader.GetString(3));
                kq.TomTat = reader.GetString(4);
                kq.NgayDang = reader.GetDateTime(5);
                kq.NoiDung = reader.GetString(6);
                kq.TaiKhoan = reader.GetString(7);
                kq.DaDuyet = reader.GetBoolean(8);
                kq.GiaBan = reader.GetInt32(9);
                kq.GiamGia = reader.GetInt32(10);
                kq.NhaSanXuat = reader.GetString(11);
                kq.DonViTinh = reader.GetString(12);
            }
            return kq;

        }


        /// <summary>
        /// Get list of the Product infomation
        /// </summary>
        /// <param name="isApproved">Đã duyệt Nếu 0 là chưa duyệt 1 là đã duyệt</param>
        /// <returns></returns>
        public ArrayList getListOfProduct(bool isApproved)
        {
            string query = "Select maSP, tenSP, maLoai, hinhDD, ndTomTat, ngayDang, noiDung, taiKhoan, daDuyet, giaBan, giamGia, nhaSanXuat, dvt " +
                                                                     "From sanPham Where DaDuyet='" + (isApproved?"1":"0") + "'";
            SqlDataReader reader = new daoSqlServer().getDataReader(query);
            ArrayList kq = new ArrayList();
            while (reader.Read())
            {
                SanPham x = new SanPham();
                //----Đọc dữ liệu
                x.MaSP = reader.GetString(0);
                x.TenSP = reader.GetString(1);
                x.MaLoai = reader.GetInt32(2);
                x.HinhDD = Tools.stringToImage(reader.GetString(3));
                x.TomTat = reader.GetString(4);
                x.NgayDang = reader.GetDateTime(5);
                x.NoiDung = reader.GetString(6);
                x.TaiKhoan = reader.GetString(7);
                x.DaDuyet = reader.GetBoolean(8);
                x.GiaBan = reader.GetInt32(9);
                x.GiamGia = reader.GetInt32(10);
                x.NhaSanXuat = reader.GetString(11);
                x.DonViTinh = reader.GetString(12);

                kq.Add(x);
            }

            return kq;
        }

    }
}
