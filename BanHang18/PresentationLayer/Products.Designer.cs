namespace BanHang18.PresentationLayer
{
    partial class Products
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
            this.prdRegion = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // prdRegion
            // 
            this.prdRegion.AutoScroll = true;
            this.prdRegion.BackColor = System.Drawing.Color.Khaki;
            this.prdRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prdRegion.Location = new System.Drawing.Point(0, 0);
            this.prdRegion.Name = "prdRegion";
            this.prdRegion.Size = new System.Drawing.Size(893, 541);
            this.prdRegion.TabIndex = 0;
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 541);
            this.Controls.Add(this.prdRegion);
            this.Name = "Products";
            this.Text = "Products";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Products_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel prdRegion;
    }
}