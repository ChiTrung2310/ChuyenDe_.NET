using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanHang18.BusinessLayer.Entity;
using BanHang18.BusinessLayer.Workflow;

namespace BanHang18.PresentationLayer
{
    public partial class AddItem : Form
    {

        public AddItem()
        {
            InitializeComponent();          
            this.updateDataSource("");
            this.formatDGV();
        }

        /// <summary>
        /// Update dataSource to DataGridView
        /// </summary>
        /// <param name="filterValue"></param>
        private void updateDataSource(string filterValue)
        {
            this.dsItem.DataSource = new BusSanPham().GetDataSet(filterValue).Tables[0];
        }

        private void formatDGV()
        {
            //--Định dạng độ rộng các cột
            this.dsItem.Columns[0].Width = 80;
            this.dsItem.Columns[1].Width = 335;
            this.dsItem.Columns[2].Width = 128;
            this.dsItem.Columns[3].Width = 88;
            this.dsItem.Columns[4].Width = 150;
            this.dsItem.Columns[5].Width = 150;
            this.dsItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            updateDataSource(this.txtTimKiem.Text.Trim());
        }

        /// <summary>
        /// Thêm hàng vào chi tiết đặt hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //---Lấy ID sản phẩm để gán cho Chi tiết đặt hàng
            Purchase.maSP = this.dsItem.SelectedRows[0].Cells[0].Value.ToString();
            this.Dispose();
        }
    }
}
