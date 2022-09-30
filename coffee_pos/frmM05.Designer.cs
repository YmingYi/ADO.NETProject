
namespace coffee_pos
{
    partial class frmM05
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
            this.label5 = new System.Windows.Forms.Label();
            this.bthSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.dglShow = new System.Windows.Forms.DataGridView();
            this.btnCheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dglShow)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(52, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 35);
            this.label5.TabIndex = 9;
            this.label5.Text = "結帳";
            // 
            // bthSend
            // 
            this.bthSend.BackColor = System.Drawing.Color.MintCream;
            this.bthSend.Location = new System.Drawing.Point(149, 455);
            this.bthSend.Name = "bthSend";
            this.bthSend.Size = new System.Drawing.Size(154, 42);
            this.bthSend.TabIndex = 24;
            this.bthSend.Text = "結帳";
            this.bthSend.UseVisualStyleBackColor = false;
            this.bthSend.Click += new System.EventHandler(this.bthSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MintCream;
            this.btnClose.Location = new System.Drawing.Point(342, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 42);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "回上一頁";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTotalPrice.Location = new System.Drawing.Point(461, 365);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(157, 42);
            this.lblTotalPrice.TabIndex = 28;
            this.lblTotalPrice.Text = "$0";
            // 
            // dglShow
            // 
            this.dglShow.BackgroundColor = System.Drawing.Color.MintCream;
            this.dglShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglShow.Location = new System.Drawing.Point(56, 89);
            this.dglShow.Name = "dglShow";
            this.dglShow.RowHeadersWidth = 51;
            this.dglShow.RowTemplate.Height = 27;
            this.dglShow.Size = new System.Drawing.Size(562, 264);
            this.dglShow.TabIndex = 27;
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.MintCream;
            this.btnCheck.Location = new System.Drawing.Point(60, 363);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(146, 43);
            this.btnCheck.TabIndex = 29;
            this.btnCheck.Text = "確認訂單";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // frmM05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(667, 535);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.dglShow);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.bthSend);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmM05";
            this.Text = "結帳單";
            this.Load += new System.EventHandler(this.frmM05_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dglShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bthSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.DataGridView dglShow;
        private System.Windows.Forms.Button btnCheck;
    }
}