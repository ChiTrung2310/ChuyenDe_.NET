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
    public partial class DiaChi : Form
    {
        private DataSet ds;
        private DataViewManager dsView;

        private bool ok = false; //--biến ok dùng để kiểm tra là insert hay update


        public DiaChi()
        {
            InitializeComponent();
            dataBinding();

        }

        /// <summary>
        /// Binding dữ liệu
        /// </summary>
        private void dataBinding()
        {
            updateDataGridView();
            //--Thêm nút Delete
            DataGridViewButtonColumn nutXoa = new DataGridViewButtonColumn();
            nutXoa.Name = "Delete";
            nutXoa.Text = "Xóa";
            nutXoa.UseColumnTextForButtonValue = true;
            //--Gắn nút xóa vào DataGridView
            this.dsQuanHuyen.Columns.Add(nutXoa);
            this.dsQuanHuyen.CellClick += DsQuanHuyen_CellClick;

            //---Binding to TextBox
            this.txtTenQH.DataBindings.Clear(); ///---Clear giúp cho binding được nhiều lần sau mỗi lần binding đầu tiên
            this.txtTenQH.DataBindings.Add("Text", dsView, "quanHuyen.tenQH");

            this.txtTinhThanh.DataBindings.Clear();
            this.txtTinhThanh.DataBindings.Add("Text", dsView, "quanHuyen.tinhThanh");

            this.txtGhiChu.DataBindings.Clear();
            this.txtGhiChu.DataBindings.Add("Text", dsView, "quanHuyen.ghiChu");

        }

        /// <summary>
        /// Update DataGridView
        /// </summary>
        private void updateDataGridView()
        {
            BusQuanHuyen x = new BusQuanHuyen();
            ds = x.GetDataSet();
            //---Set default view to dsView
            dsView = ds.DefaultViewManager;
            //---Binding to DataGridView
            this.dsQuanHuyen.DataSource = dsView;
            this.dsQuanHuyen.DataMember = "quanHuyen";

            //---Định dạng cột cho DS quận huyện (độ rộng)
            this.dsQuanHuyen.Columns[0].Width = 60;
            this.dsQuanHuyen.Columns[1].Width = 120;
            this.dsQuanHuyen.Columns[2].Width = 170;
            this.dsQuanHuyen.Columns[3].Width = 260;
            this.dsQuanHuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //---Binding to TextBox
            this.txtTenQH.DataBindings.Clear();
            this.txtTenQH.DataBindings.Add("Text", dsView, "quanHuyen.tenQH");

            this.txtTinhThanh.DataBindings.Clear();
            this.txtTinhThanh.DataBindings.Add("Text", dsView, "quanHuyen.tinhThanh");

            this.txtGhiChu.DataBindings.Clear();
            this.txtGhiChu.DataBindings.Add("Text", dsView, "quanHuyen.ghiChu");

        }

        private void DsQuanHuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == this.dsQuanHuyen.Columns["Delete"].Index)
            {
                int maCX = int.Parse(this.dsQuanHuyen.Rows[e.RowIndex].Cells[1].Value.ToString());
                BusQuanHuyen x = new BusQuanHuyen();
                x.info = packageQH();
                x.info.MaQH = maCX;
                if (x.deleteQuanHuyen() > 0)
                {
                    MessageBox.Show("Đã xóa thành công 1 quận huyện !!!");
                    updateDataGridView();

                }
                    
            }

        }

        private void btnCloseDC_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Sự kiện xảy ra khi người dùng nhập dữ liệu vào textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTenQH_TextChanged(object sender, EventArgs e)
        {
            this.btnSaveDC.Enabled = enableSaveButton();
        }

        /// <summary>
        /// True nếu các ô đã có dữ liệu và false nếu 
        /// </summary>
        /// <returns></returns>
        private bool enableSaveButton()
        {
            return (this.txtTenQH.Text.Length > 0 && this.txtTinhThanh.Text.Length > 0);
        }

        /// <summary>
        /// Đóng gói thông tin từ giao diện UI
        /// </summary>
        /// <returns></returns>
        private QuanHuyen packageQH()
        {
            QuanHuyen x = new QuanHuyen();
            x.TenQH = this.txtTenQH.Text.Trim();
            x.TinhThanh = this.txtTinhThanh.Text.Trim();
            x.GhiChu = this.txtGhiChu.Text.Trim();
            return x;
            
        }

        /// <summary>
        /// Sự kiện khi người dùng nhấn nút new
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewDC_Click(object sender, EventArgs e)
        {
            ok = true;
            this.txtTenQH.Text = "";
            this.txtTinhThanh.Text = "";
            this.txtGhiChu.Text = "";
            this.txtTenQH.Focus();
        }

        /// <summary>
        /// Sự kiện khi người dùng nhấn nút save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveDC_Click(object sender, EventArgs e)
        {
            if (ok == true)  // -- Nếu ok = true thì cho phép thêm mới và ok = false thì cho phép update
            {
                //---B1: Đóng gói dữ liệu
                BusQuanHuyen x = new BusQuanHuyen();
                x.info = packageQH();

                //---B2: Gọi hàm lưu dữ liệu 
                int kq = x.addQuanHuyen();
                if (kq == 1)
                {
                    MessageBox.Show("Đã thêm thành công 1 quận huyện !!!");
                    updateDataGridView();
                    ok = false;

                }
            }
            else
            {
                
                BusQuanHuyen x = new BusQuanHuyen();
                x.info = packageQH();         
                int Ma = int.Parse(dsQuanHuyen.CurrentRow.Cells["maQH"].Value.ToString());  //--Lấy maQH từ dataGrid để truyền vào update dữ liệu
                x.info.MaQH = Ma;
               
                //---B2: Gọi hàm update dữ liệu 
                int kq = x.updateQuanHuyen();
                if (kq == 1)
                {
                    MessageBox.Show("Đã update thành công 1 quận huyện !!!");
                    updateDataGridView();

                }
            }
        }


        /// <summary>
        /// Khi load form địa chỉ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiaChi_Load(object sender, EventArgs e)
        {

            this.dsQuanHuyen.Columns[0].Width = 60;
            this.dsQuanHuyen.Columns[1].Width = 120;
            this.dsQuanHuyen.Columns[2].Width = 170;
            this.dsQuanHuyen.Columns[3].Width = 260;
            this.dsQuanHuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dsQuanHuyen.Columns[1].HeaderText = "Mã QH";
            this.dsQuanHuyen.Columns[2].HeaderText = "Tên quận huyện";
            this.dsQuanHuyen.Columns[3].HeaderText = "Tỉnh thành";
            this.dsQuanHuyen.Columns[4].HeaderText = "Ghi chú";



        }

        private void btnPrintDC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy kết nối máy in!!!");
        }
    }
}
