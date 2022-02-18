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
    class BusTrangThai
    {
        public DataSet GetDataSet()
        {
            string query = "Select * from trangThai";
            return new daoSqlServer().GetDataSet(query, "trangThai");
        }
    }
}
