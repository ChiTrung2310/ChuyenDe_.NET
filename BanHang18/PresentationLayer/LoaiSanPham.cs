using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanHang18.BusinessLayer.Workflow;
using BanHang18.BusinessLayer.Entity;

namespace BanHang18.PresentationLayer
{
    public partial class LoaiSanPham : Form
    {
        private DataSet ds;
        private DataViewManager dsView;
        private bool ok = false;

        public LoaiSanPham()
        {
            InitializeComponent();
            dataBinding();
        }



        private void dataBinding()
        {
            updateDataGridView();
            //--Thêm nút Delete
            DataGridViewButtonColumn nutXoa = new DataGridViewButtonColumn();
            nutXoa.Name = "Delete";
            nutXoa.Text = "Xóa";
            nutXoa.UseColumnTextForButtonValue = true;
            //--Gắn nút xóa vào DataGridView
            this.dsLoaiSp.Columns.Add(nutXoa);
            this.dsLoaiSp.CellClick += DsLoaiSP_CellClick;

            //---Binding to TextBox
            this.txtLoaiSp.DataBindings.Clear();
            this.txtLoaiSp.DataBindings.Add("Text", dsView, "loaiSP.loaiSP");

            this.txtGhiChu.DataBindings.Clear();
            this.txtGhiChu.DataBindings.Add("Text", dsView, "loaiSP.ghiChu");

        }

        private void updateDataGridView()
        {
            BusLoaiSanPham x = new BusLoaiSanPham();
            //--Wait a minutes
            ds = x.GetDataSet();
            //---Set default view to dsView
            dsView = ds.DefaultViewManager;
            //---Binding to DataGridView
            this.dsLoaiSp.DataSource = dsView;
            this.dsLoaiSp.DataMember = "loaiSP";

            //---Định dạng cột cho DS quận huyện (độ rộng)
            this.dsLoaiSp.Columns[0].Width = 50;
            this.dsLoaiSp.Columns[1].Width = 150;
            this.dsLoaiSp.Columns[2].Width = 280;
            this.dsLoaiSp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //---Binding to TextBox
            this.txtLoaiSp.DataBindings.Clear();
            this.txtLoaiSp.DataBindings.Add("Text", dsView, "loaiSP.loaiSP");

            this.txtGhiChu.DataBindings.Clear();
            this.txtGhiChu.DataBindings.Add("Text", dsView, "loaiSP.ghiChu");
        }

        private void DsLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dsLoaiSp.Columns["Delete"].Index)
            {
                int maCX = int.Parse(this.dsLoaiSp.Rows[e.RowIndex].Cells[1].Value.ToString());
                BusLoaiSanPham x = new BusLoaiSanPham();
                x.info = packageLSP();
                x.info.MaLoai = maCX;
                if (x.deleteLoaiSP() > 0)
                {
                    MessageBox.Show("Đã xóa thành công 1 loại tài khoản !!!");
                    updateDataGridView();
                }

            }

        }

        private LoaiSp packageLSP()
        {
            LoaiSp x = new LoaiSp();
            x.LoaiSP = this.txtLoaiSp.Text.Trim();
            x.GhiChu = this.txtGhiChu.Text.Trim();
            return x;
        }


        /// <summary>
        /// Khi load form lên 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoaiSanPham_Load(object sender, EventArgs e)
        {
            this.dsLoaiSp.Columns[0].Width = 50;
            this.dsLoaiSp.Columns[1].Width = 150;
            this.dsLoaiSp.Columns[2].Width = 280;
            this.dsLoaiSp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //---Set lại tên của các cột trong DataGridView
            this.dsLoaiSp.Columns[1].HeaderText = "Mã loại";
            this.dsLoaiSp.Columns[2].HeaderText = "Loại sản phẩm";
            this.dsLoaiSp.Columns[3].HeaderText = "Ghi chú";
        }

        /// <summary>
        /// Nhấn vào để bắt đầu thêm loại sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.ok = true;
            this.txtLoaiSp.Text = "";
            this.txtGhiChu.Text = "";
            txtLoaiSp.Focus();
        }

        /// <summary>
        /// Nhấn vào để hoàn tất quá trình thêm loại sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                //---B1: Đóng gói dữ liệu
                BusLoaiSanPham x = new BusLoaiSanPham();
                x.info = packageLSP();

                //---B2: Gọi hàm lưu dữ liệu 
                int kq = x.addLoaiSP();
                if (kq == 1)
                {
                    MessageBox.Show("Đã thêm thành công 1 loại sản phẩm !!!");
                    this.ok = false;
                    updateDataGridView();

                }
            }
            else
            {
           
                BusLoaiSanPham x = new BusLoaiSanPham();
                x.info = packageLSP();
                int MaLoai = int.Parse(dsLoaiSp.CurrentRow.Cells["maLoai"].Value.ToString());
                x.info.MaLoai = MaLoai;
                //---B2: Gọi hàm update dữ liệu 
                int kq = x.updateLoaiSP();
                if (kq == 1)
                {
                    MessageBox.Show("Đã update thành công 1 loại sản phẩm !!!");
                    updateDataGridView();

                }
            }
        }

        /// <summary>
        /// In dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy kết nối máy in!!!");
        }

        /// <summary>
        /// Đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Kiểm tra điều kiện bật nút save
        /// </summary>
        /// <returns></returns>
        private bool enableSaveButton()
        {
            return (this.txtLoaiSp.Text.Length > 0);
        }

        /// <summary>
        /// Kiểm tra dữ liệu ô nhập loại sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoaiSp_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = enableSaveButton();
        }
    }
}
