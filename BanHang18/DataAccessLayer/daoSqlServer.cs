using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanHang18.DataAccessLayer
{
    class daoSqlServer
    {
        private string strConnect;

        /// <summary>
        /// Default constructor
        /// </summary>
        public daoSqlServer()
        {
            this.strConnect = Properties.Settings.Default.chuoiKetNoi;
        }

        /// <summary>
        /// Trả về cho nơi gọi 1 sqlConnection đã kết nối
        /// </summary>
        /// <returns></returns>
        public SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(this.strConnect);
            con.Open();
            return con;
        }

        /// <summary>
        /// Thực thi lệnh [Insert - Update - Delete]
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int executeNonQuery(string query)
        {
            int kq = 0;
            SqlCommand cmd = new SqlCommand(query,getConnection());
            kq = cmd.ExecuteNonQuery();
            return kq;
        }

        /// <summary>
        /// Đọc dữ liệu truy vấn từ database cho nơi gọi
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string query, string tableName)
        {
            //B1: Tạo DataSet
            DataSet ds = new DataSet();
            //B2: Tạo DataAdapter
            SqlDataAdapter adap = new SqlDataAdapter(query, getConnection());
            //B3: Fill DataSet
            adap.TableMappings.Add("Table", tableName);
            adap.Fill(ds);
            return ds;
        }

        /// <summary>
        /// Đọc dữ liệu từ database và trả về 1 SqlDataReader có chứa dữ liệu cho nơi gọi
        /// </summary>
        /// <param name="query">Câu truy vấn</param>
        /// <returns></returns>
        public SqlDataReader getDataReader(string query)
        {
            SqlCommand cmd = new SqlCommand(query, getConnection());
            return cmd.ExecuteReader();         
        }

        /// <summary>
        /// Transaction thêm ct đơn hàng    
        /// </summary>
        /// <param name="statements">Danh sách các lênh cần để chạy trên sql</param>
        /// <returns></returns>
        public bool ExecuteTransaction(List<string> statements)
        {
            bool kq = false;
            using (SqlConnection connection = getConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                //---B1: Create a Transaction 
                SqlTransaction transact = connection.BeginTransaction("CompleteOrder");
                cmd.Connection = connection;
                cmd.Transaction = transact;
                //---B2: Run all of the command in list
                try
                {
                    foreach(string s in statements)
                    {
                        cmd.CommandText = s;
                        cmd.ExecuteNonQuery();
                    }
                    //---B3: Commit if successfull
                    transact.Commit();
                    kq = true;
                }
                catch
                {
                    //---B3: Rollback if error
                    transact.Rollback();
                }
            }

            return kq;
        }

    }
}
