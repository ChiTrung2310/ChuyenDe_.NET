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
    class BusDonHang
    {
        public DonHang info { set; get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BusDonHang()
        {
            this.info = new DonHang();
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="x"></param>
        public BusDonHang(DonHang x)
        {
            this.info = x;
        }

        /// <summary>
        /// Trả về câu DML dùng cho mục đích insert dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string insertSql()
        {
            return string.Format("Insert Into donHang (soDH, maKH, taiKhoan, ngayDat, ngayGH, diaChiGH, trangThai, ghiChu ) " +
                                 "Values ('{0}', '{1}','{2}', '{3}', '{4}', N'{5}', {6}, N'{7}');",
                                 this.info.SoDH, this.info.MaKH, this.info.TaiKhoan, this.info.NgayDat, this.info.NgayGH, this.info.DiaChiGH,
                                 this.info.TrangThai, this.info.GhiChu);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Update dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string updateSql()
        {

            return string.Format("Update donHang set maKH = '{0}', taiKhoan = '{1}', ngayDat = '{2}', " +
                                                    " ngayGH = '{3}', diachiGH = N'{4}', ghiChu = N'{5}', trangThai = {6} " +
                                  " Where soDH = '{7}' ",
                                  this.info.MaKH, this.info.TaiKhoan, this.info.NgayDat, this.info.NgayGH, this.info.DiaChiGH, 
                                  this.info.GhiChu, this.info.TrangThai, this.info.SoDH);

        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Delete dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string deleteSql()
        {
            return string.Format("Delete donHang Where soDH = '{0}' ", this.info.SoDH);
        }

        /// <summary>
        /// Thêm thông tin đơn hàng vào database
        /// </summary>
        /// <returns></returns>
        public int addDonHang()
        {
            int kq = 0;
            string query = this.insertSql();
            kq = new daoSqlServer().executeNonQuery(query);
            return kq;
        }

        /// <summary>
        /// Update thông tin đơn hàng vào database
        /// </summary>
        /// <returns></returns>
        public int updateDonHang()
        {
            return new daoSqlServer().executeNonQuery(updateSql());
        }

        /// <summary>
        /// Delete thông tin đơn hàng trong database
        /// </summary>
        /// <returns></returns>
        public int deleteDonHang()
        {
            return new daoSqlServer().executeNonQuery(deleteSql());
        }

        /// <summary>
        /// Hoàn thành việc thêm đơn hàng
        /// </summary>
        /// <param name="d">Don hang</param>
        /// <param name="items">List of ProDuct item</param>
        /// <returns></returns>
        public bool createCompleteOrder(DonHang d, List<CtDonHang> items)
        {
            bool kq = false;
            //--B1: Create list
            List<string> statements = new List<string>();
            //--B2: Convert DonHang
            statements.Add(new BusDonHang(d).insertSql());
            //--B3: Loop through the items
            foreach (CtDonHang i in items)
                statements.Add(new BusCtDonHang(i).insertSql());
            //--B4: Run transaction depend on daoSqlServer
            kq = new daoSqlServer().ExecuteTransaction(statements);
            return kq;
        }

        /// <summary>
        /// Get DataSet đổ dữ liệu
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            string query = "Select d.soDH, k.tenKH, d.ngayDat, d.taiKhoan, d.diaChiGH, (select count(*) from ctDonHang where soDH = d.soDH) as N'Số SP' from donHang d inner join khachHang k on (d.maKH=k.maKH) ";
            return new daoSqlServer().GetDataSet(query, "donHang");
        }

        /// <summary>
        /// Phục vụ việc lấy dữ liệu giữa nhiều form
        /// </summary>
        /// <param name="sodh"></param>
        /// <returns></returns>
        public DonHang getInfo(string sodh)
        {
            DonHang kq = new DonHang();
            SqlDataReader reader = new daoSqlServer().getDataReader("Select soDH, maKH, taiKhoan, ngayDat, ngayGH, diaChiGH, ghiChu, trangThai " +
                                                                     "From donHang Where soDH='" + sodh + "'");
            while (reader.Read())
            {
                kq.SoDH = reader.GetString(0);
                kq.MaKH = reader.GetString(1);
                kq.TaiKhoan = reader.GetString(2);
                kq.NgayDat = reader.GetDateTime(3);
                kq.NgayGH = reader.GetDateTime(4);
                kq.DiaChiGH = reader.GetString(5);
                kq.GhiChu = reader.GetString(6);
                kq.TrangThai = reader.GetInt32(7);
            }
            return kq;

        }

        /// <summary>
        /// Lấy danh sách đơn hàng phục vụ trả về nơi gọi
        /// </summary>
        /// <param name="TrangThai">Trạng thái của đơn hàng</param>
        /// <returns></returns>
        //public DataSet GetDataSet(bool isActive, int TrangThai)
        //{
        //    string query = "Select soDH, maKH, taiKhoan, ngayDat, daKichHoat, ngayGH, diaChiGH, ghiChu, trangThai from donHang " +
        //                    "where daKichHoat = " + (isActive ? "1" : "0") + (TrangThai > 0 ? " And trangThai = " + TrangThai.ToString() : "") ;
        //    return new daoSqlServer().GetDataSet(query, "donHang");
        //}

        public DataSet GetDataSet(bool isActive, int TrangThai)
        {
            string query = "Select d.soDH, k.tenKH, d.ngayDat, d.taiKhoan, d.diaChiGH, (select count(*) from ctDonHang where soDH = d.soDH) as N'SoSP' from donHang d inner join khachHang k on (d.maKH=k.maKH) " +
                            "where daKichHoat = " + (isActive ? "1" : "0") + (TrangThai > 0 ? " And trangThai = " + TrangThai.ToString() : "");
            return new daoSqlServer().GetDataSet(query, "donHang");
        }

        //public DataSet GetDataSet(bool isActive, int TrangThai)
        //{
        //    string query = "Select t.tenKH, soDT, d.soDH , d.taiKhoan, d.ngayDat, d.ngayGH, diaChiGH, c.maSP, c.soLuong, c.giaBan, c.giamGia from khachHang t inner join donHang d on (t.maKH = d.maKH) inner join ctDonHang c on (d.soDH = c.soDH) " +
        //                    "where daKichHoat = " + (isActive ? "1" : "0") + (TrangThai > 0 ? " And trangThai = " + TrangThai.ToString() : "");
        //    return new daoSqlServer().GetDataSet(query, "donHang");
        //}
    }
}
