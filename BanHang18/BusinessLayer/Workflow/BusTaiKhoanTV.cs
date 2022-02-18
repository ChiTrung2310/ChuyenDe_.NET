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
    class BusTaiKhoanTV
    {
        public TaiKhoanTV info { set; get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BusTaiKhoanTV()
        {
            this.info = new TaiKhoanTV();
        }

        /// <summary>
        /// Trả về câu DML dùng cho mục đích insert dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string insertSql()
        {
            return string.Format("Insert Into taiKhoanTV (taiKhoan, matKhau, maNhom, hoDem, tenTV, ngaySinh, gioiTinh, soDT, email, diaChi, maQH, trangThai, ghiChu)" +
                                              " Values ('{0}', '{1}' , {2}, N'{3}', N'{4}', '{5}', {6}, '{7}', '{8}', N'{9}', {10}, {11}, N'{12}') ",
                                              this.info.TaiKhoan, this.info.MatKhau, this.info.MaNhom, this.info.HoDem, this.info.TenTV,
                                              this.info.NgaySinh, (this.info.GioiTinh ? 1 : 0), this.info.SoDT, this.info.Email, this.info.DiaChi,
                                              this.info.MaQH, (this.info.TrangThai ? 1 : 0), this.info.GhiChu);
                                              
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Update dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string updateSql()
        {
            return string.Format("Update taiKhoanTV set hoDem = N'{0}', tenTV = N'{1}',  maNhom = {2}, ngaySinh = '{3}', gioiTinh = {4}," +
                                                        "soDT = '{5}', email = '{6}', diaChi = N'{7}', maQH = {8}, ghiChu = N'{9}' " +
                                  "Where taiKhoan ='{10}' ",  this.info.HoDem, this.info.TenTV, this.info.MaNhom, this.info.NgaySinh,
                                                              (this.info.GioiTinh ? 1 : 0), this.info.SoDT, this.info.Email, this.info.DiaChi, this.info.MaQH, this.info.GhiChu, this.info.TaiKhoan);
        }

        /// <summary>
        /// Trả về câu lệnh dùng cho mục đích Delete dữ liệu vào Sql Server
        /// </summary>
        /// <returns></returns>
        private string deleteSql()
        {
            return string.Format("Delete taiKhoanTV Where taiKhoan = {0}", this.info.TaiKhoan);
        }

        /// <summary>
        /// Thêm thông tin tài khoản thành viên vào database
        /// </summary>
        /// <returns></returns>
        public int addTaiKhoanTV()
        {
            int kq = 0;
            string query = this.insertSql();
            kq = new daoSqlServer().executeNonQuery(query);
            return kq;
        }

        /// <summary>
        /// Update thông tin tài khoản thành viên vào database
        /// </summary>
        /// <returns></returns>
        public int updateTaiKhoanTV()
        {
            return new daoSqlServer().executeNonQuery(updateSql());
        }

        /// <summary>
        /// Delete thông tin tài khoản thành viên trong database
        /// </summary>
        /// <returns></returns>
        public int deleteTaiKhoanTV()
        {
            return new daoSqlServer().executeNonQuery(deleteSql());
        }

        /// <summary>
        /// Đọc thông tin tài khoản
        /// </summary>
        /// <param name="taiKhoan">Thông tin của tài khoản muốn đọc</param>
        /// <returns></returns>
        public TaiKhoanTV getInfo(string taiKhoan)
        {
            TaiKhoanTV kq = new TaiKhoanTV();
            SqlDataReader reader = new daoSqlServer().getDataReader("Select taiKhoan, hoDem, tenTV, ngaySinh, gioiTinh, soDT, email, ghiChu, diaChi, maNhom, maQH, matKhau " +
                                                                    "From taiKhoanTV Where taiKhoan='" + taiKhoan + "'");
            while (reader.Read())
            {
                kq.TaiKhoan = reader.GetString(0);
                kq.HoDem = reader.GetString(1);
                kq.TenTV = reader.GetString(2);
                kq.NgaySinh = reader.GetDateTime(3);
                kq.GioiTinh = reader.GetBoolean(4);
                kq.SoDT = reader.GetString(5);
                kq.Email = reader.GetString(6);
                kq.GhiChu = reader.GetString(7);
                kq.DiaChi = reader.GetString(8);
                kq.MaNhom = reader.GetInt32(9);
                kq.MaQH = reader.GetInt32(10);
                kq.MatKhau = reader.GetString(11);

            }
            return kq;
        }

        /// <summary>
        /// Đọc danh sách tài khoản dựa vào mã nhóm tài khoản hay trạng thái
        /// </summary>
        /// <param name="isActive">True: đã kích hoạt - False: chưa kích hoạt</param>
        /// <param name="maNhom">Mã nhóm tài khoản dùng cho Filter [0: Không lọc]</param>
        /// <returns></returns>
        public DataSet GetDataSet(bool isActive, int maNhom)
        {
            string query = "Select hoDem, tenTV, taiKhoan, FORMAT(ngaySinh,'dd/MM/yyyy') as NgaySinh, iif(gioiTinh=1, 'Nam', N'Nữ') as gioiTinh, soDT, " +
                                   "diaChi + ', ' +q.tenQH + ', '+q.tinhThanh as diaChi " +
                           "From taiKhoanTV t inner join quanHuyen q on (t.maQH = q.maQH) " +
                           "Where trangThai = " + (isActive ? "1" : "0") + (maNhom > 0 ? " And t.maNhom = " + maNhom.ToString() : "") + " Order by tenTV";
            return new daoSqlServer().GetDataSet(query, "taiKhoanTV");
        }

    }
}
