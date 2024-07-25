namespace QL_ChoThue_BD
{
    partial class DangNhap
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
            this.label_TenDangNhap_DN = new System.Windows.Forms.Label();
            this.textBox_TenDangNhap_DN = new System.Windows.Forms.TextBox();
            this.label_MatKhau_DN = new System.Windows.Forms.Label();
            this.textBox_MatKhau_DN = new System.Windows.Forms.TextBox();
            this.checkBox_HienThiMatKhau_DN = new System.Windows.Forms.CheckBox();
            this.linkLabel_DangKi_DN = new System.Windows.Forms.LinkLabel();
            this.button_DangNhap_DN = new System.Windows.Forms.Button();
            this.button_Thoat_DN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_TenDangNhap_DN
            // 
            this.label_TenDangNhap_DN.AutoSize = true;
            this.label_TenDangNhap_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TenDangNhap_DN.Location = new System.Drawing.Point(45, 123);
            this.label_TenDangNhap_DN.Name = "label_TenDangNhap_DN";
            this.label_TenDangNhap_DN.Size = new System.Drawing.Size(115, 16);
            this.label_TenDangNhap_DN.TabIndex = 0;
            this.label_TenDangNhap_DN.Text = "Tên đăng nhập:";
            // 
            // textBox_TenDangNhap_DN
            // 
            this.textBox_TenDangNhap_DN.Location = new System.Drawing.Point(190, 116);
            this.textBox_TenDangNhap_DN.Name = "textBox_TenDangNhap_DN";
            this.textBox_TenDangNhap_DN.Size = new System.Drawing.Size(272, 24);
            this.textBox_TenDangNhap_DN.TabIndex = 1;
            // 
            // label_MatKhau_DN
            // 
            this.label_MatKhau_DN.AutoSize = true;
            this.label_MatKhau_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MatKhau_DN.Location = new System.Drawing.Point(45, 184);
            this.label_MatKhau_DN.Name = "label_MatKhau_DN";
            this.label_MatKhau_DN.Size = new System.Drawing.Size(73, 16);
            this.label_MatKhau_DN.TabIndex = 2;
            this.label_MatKhau_DN.Text = "Mật khẩu:";
            // 
            // textBox_MatKhau_DN
            // 
            this.textBox_MatKhau_DN.Location = new System.Drawing.Point(190, 179);
            this.textBox_MatKhau_DN.Name = "textBox_MatKhau_DN";
            this.textBox_MatKhau_DN.PasswordChar = '*';
            this.textBox_MatKhau_DN.Size = new System.Drawing.Size(272, 24);
            this.textBox_MatKhau_DN.TabIndex = 3;
            // 
            // checkBox_HienThiMatKhau_DN
            // 
            this.checkBox_HienThiMatKhau_DN.AutoSize = true;
            this.checkBox_HienThiMatKhau_DN.Location = new System.Drawing.Point(190, 229);
            this.checkBox_HienThiMatKhau_DN.Name = "checkBox_HienThiMatKhau_DN";
            this.checkBox_HienThiMatKhau_DN.Size = new System.Drawing.Size(144, 22);
            this.checkBox_HienThiMatKhau_DN.TabIndex = 4;
            this.checkBox_HienThiMatKhau_DN.Text = "Hiển thị mật khẩu";
            this.checkBox_HienThiMatKhau_DN.UseVisualStyleBackColor = true;
            this.checkBox_HienThiMatKhau_DN.CheckedChanged += new System.EventHandler(this.checkBox_HienThiMatKhau_DN_CheckedChanged);
            // 
            // linkLabel_DangKi_DN
            // 
            this.linkLabel_DangKi_DN.AutoSize = true;
            this.linkLabel_DangKi_DN.Location = new System.Drawing.Point(400, 230);
            this.linkLabel_DangKi_DN.Name = "linkLabel_DangKi_DN";
            this.linkLabel_DangKi_DN.Size = new System.Drawing.Size(62, 18);
            this.linkLabel_DangKi_DN.TabIndex = 5;
            this.linkLabel_DangKi_DN.TabStop = true;
            this.linkLabel_DangKi_DN.Text = "Đăng kí ";
            this.linkLabel_DangKi_DN.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_DangKi_DN_LinkClicked);
            // 
            // button_DangNhap_DN
            // 
            this.button_DangNhap_DN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_DangNhap_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DangNhap_DN.Location = new System.Drawing.Point(48, 295);
            this.button_DangNhap_DN.Name = "button_DangNhap_DN";
            this.button_DangNhap_DN.Size = new System.Drawing.Size(124, 40);
            this.button_DangNhap_DN.TabIndex = 6;
            this.button_DangNhap_DN.Text = "Đăng nhập";
            this.button_DangNhap_DN.UseVisualStyleBackColor = false;
            this.button_DangNhap_DN.Click += new System.EventHandler(this.button_DangNhap_DN_Click);
            // 
            // button_Thoat_DN
            // 
            this.button_Thoat_DN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_Thoat_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Thoat_DN.Location = new System.Drawing.Point(338, 295);
            this.button_Thoat_DN.Name = "button_Thoat_DN";
            this.button_Thoat_DN.Size = new System.Drawing.Size(124, 40);
            this.button_Thoat_DN.TabIndex = 7;
            this.button_Thoat_DN.Text = "Thoát";
            this.button_Thoat_DN.UseVisualStyleBackColor = false;
            this.button_Thoat_DN.Click += new System.EventHandler(this.button_Thoat_DN_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 418);
            this.Controls.Add(this.button_Thoat_DN);
            this.Controls.Add(this.button_DangNhap_DN);
            this.Controls.Add(this.linkLabel_DangKi_DN);
            this.Controls.Add(this.checkBox_HienThiMatKhau_DN);
            this.Controls.Add(this.textBox_MatKhau_DN);
            this.Controls.Add(this.label_MatKhau_DN);
            this.Controls.Add(this.textBox_TenDangNhap_DN);
            this.Controls.Add(this.label_TenDangNhap_DN);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DangNhap";
            this.Text = "Đăng Nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TenDangNhap_DN;
        private System.Windows.Forms.TextBox textBox_TenDangNhap_DN;
        private System.Windows.Forms.Label label_MatKhau_DN;
        private System.Windows.Forms.TextBox textBox_MatKhau_DN;
        private System.Windows.Forms.CheckBox checkBox_HienThiMatKhau_DN;
        private System.Windows.Forms.LinkLabel linkLabel_DangKi_DN;
        private System.Windows.Forms.Button button_DangNhap_DN;
        private System.Windows.Forms.Button button_Thoat_DN;
    }
}

