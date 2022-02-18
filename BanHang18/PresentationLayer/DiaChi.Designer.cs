namespace BanHang18.PresentationLayer
{
    partial class DiaChi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCloseDC = new System.Windows.Forms.Button();
            this.btnPrintDC = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaveDC = new System.Windows.Forms.Button();
            this.btnNewDC = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtTinhThanh = new System.Windows.Forms.TextBox();
            this.txtTenQH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dsQuanHuyen = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsQuanHuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 440);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCloseDC);
            this.panel4.Controls.Add(this.btnPrintDC);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(714, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(355, 440);
            this.panel4.TabIndex = 1;
            // 
            // btnCloseDC
            // 
            this.btnCloseDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCloseDC.Image = global::BanHang18.Properties.Resources.exit;
            this.btnCloseDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseDC.Location = new System.Drawing.Point(206, 360);
            this.btnCloseDC.Name = "btnCloseDC";
            this.btnCloseDC.Size = new System.Drawing.Size(137, 56);
            this.btnCloseDC.TabIndex = 9;
            this.btnCloseDC.Text = "Close";
            this.btnCloseDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloseDC.UseVisualStyleBackColor = true;
            this.btnCloseDC.Click += new System.EventHandler(this.btnCloseDC_Click);
            // 
            // btnPrintDC
            // 
            this.btnPrintDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPrintDC.Image = global::BanHang18.Properties.Resources.printer;
            this.btnPrintDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintDC.Location = new System.Drawing.Point(20, 360);
            this.btnPrintDC.Name = "btnPrintDC";
            this.btnPrintDC.Size = new System.Drawing.Size(137, 56);
            this.btnPrintDC.TabIndex = 8;
            this.btnPrintDC.Text = "Print";
            this.btnPrintDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintDC.UseVisualStyleBackColor = true;
            this.btnPrintDC.Click += new System.EventHandler(this.btnPrintDC_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BanHang18.Properties.Resources.locations;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 312);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSaveDC);
            this.panel3.Controls.Add(this.btnNewDC);
            this.panel3.Controls.Add(this.txtGhiChu);
            this.panel3.Controls.Add(this.txtTinhThanh);
            this.panel3.Controls.Add(this.txtTenQH);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(714, 440);
            this.panel3.TabIndex = 0;
            // 
            // btnSaveDC
            // 
            this.btnSaveDC.Enabled = false;
            this.btnSaveDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSaveDC.Image = global::BanHang18.Properties.Resources.save;
            this.btnSaveDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveDC.Location = new System.Drawing.Point(515, 360);
            this.btnSaveDC.Name = "btnSaveDC";
            this.btnSaveDC.Size = new System.Drawing.Size(137, 56);
            this.btnSaveDC.TabIndex = 7;
            this.btnSaveDC.Text = "Save";
            this.btnSaveDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveDC.UseVisualStyleBackColor = true;
            this.btnSaveDC.Click += new System.EventHandler(this.btnSaveDC_Click);
            // 
            // btnNewDC
            // 
            this.btnNewDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNewDC.Image = global::BanHang18.Properties.Resources.map_add;
            this.btnNewDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewDC.Location = new System.Drawing.Point(289, 360);
            this.btnNewDC.Name = "btnNewDC";
            this.btnNewDC.Size = new System.Drawing.Size(137, 56);
            this.btnNewDC.TabIndex = 6;
            this.btnNewDC.Text = "New";
            this.btnNewDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewDC.UseVisualStyleBackColor = true;
            this.btnNewDC.Click += new System.EventHandler(this.btnNewDC_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtGhiChu.Location = new System.Drawing.Point(289, 165);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(386, 150);
            this.txtGhiChu.TabIndex = 5;
            // 
            // txtTinhThanh
            // 
            this.txtTinhThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTinhThanh.Location = new System.Drawing.Point(289, 93);
            this.txtTinhThanh.Name = "txtTinhThanh";
            this.txtTinhThanh.Size = new System.Drawing.Size(386, 34);
            this.txtTinhThanh.TabIndex = 4;
            this.txtTinhThanh.TextChanged += new System.EventHandler(this.txtTenQH_TextChanged);
            // 
            // txtTenQH
            // 
            this.txtTenQH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenQH.Location = new System.Drawing.Point(289, 27);
            this.txtTenQH.Name = "txtTenQH";
            this.txtTenQH.Size = new System.Drawing.Size(386, 34);
            this.txtTenQH.TabIndex = 3;
            this.txtTenQH.TextChanged += new System.EventHandler(this.txtTenQH_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(107, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ghi Chú";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(71, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tỉnh Thành";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Quận Huyện";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dsQuanHuyen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 440);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1069, 272);
            this.panel2.TabIndex = 1;
            // 
            // dsQuanHuyen
            // 
            this.dsQuanHuyen.AllowUserToAddRows = false;
            this.dsQuanHuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsQuanHuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsQuanHuyen.Location = new System.Drawing.Point(0, 0);
            this.dsQuanHuyen.Name = "dsQuanHuyen";
            this.dsQuanHuyen.RowTemplate.Height = 24;
            this.dsQuanHuyen.Size = new System.Drawing.Size(1069, 272);
            this.dsQuanHuyen.TabIndex = 0;
            // 
            // DiaChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1069, 712);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiaChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiaChi";
            this.Load += new System.EventHandler(this.DiaChi_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsQuanHuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dsQuanHuyen;
        private System.Windows.Forms.Button btnCloseDC;
        private System.Windows.Forms.Button btnPrintDC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSaveDC;
        private System.Windows.Forms.Button btnNewDC;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtTinhThanh;
        private System.Windows.Forms.TextBox txtTenQH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}