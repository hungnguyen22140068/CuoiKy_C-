namespace QL_ChoThue_BD
{
    partial class Form_LichSu
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridView_LSTR = new System.Windows.Forms.DataGridView();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LSTR)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridView_LSTR);
            this.groupBox6.Location = new System.Drawing.Point(44, 11);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(782, 271);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "LỊCH SỬ TRẢ";
            // 
            // dataGridView_LSTR
            // 
            this.dataGridView_LSTR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LSTR.Location = new System.Drawing.Point(6, 21);
            this.dataGridView_LSTR.Name = "dataGridView_LSTR";
            this.dataGridView_LSTR.RowHeadersWidth = 51;
            this.dataGridView_LSTR.RowTemplate.Height = 24;
            this.dataGridView_LSTR.Size = new System.Drawing.Size(770, 243);
            this.dataGridView_LSTR.TabIndex = 1;
            // 
            // Form_LichSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 292);
            this.Controls.Add(this.groupBox6);
            this.Name = "Form_LichSu";
            this.Text = "Lịch sử thuê / trả";
            this.Load += new System.EventHandler(this.Form_LichSu_Load);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LSTR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridView_LSTR;
    }
}