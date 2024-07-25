using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ChoThue_BD
{
    public partial class DangNhap : Form
    {
        KetNoiCSDL KetNoiCSDL = new KetNoiCSDL();   

        public DangNhap()
        {
            InitializeComponent();
        }

        private void button_DangNhap_DN_Click(object sender, EventArgs e)
        {
            string userName = textBox_TenDangNhap_DN.Text.Trim();
            string passWord = textBox_MatKhau_DN.Text.Trim();

            string role = KetNoiCSDL.KiemTraDangNhap(userName, passWord);
            if (role != null)
            {
                MessageBox.Show("Đăng nhập thành công! Vai trò của bạn là: " + role);

                if (role == "Admin")
                {
                    Main_Admin main_Admin = new Main_Admin();
                    main_Admin.FormClosed += Main_Admin_FormClosed;
                    main_Admin.Show();
                    this.Hide();
                }
                else if (role == "Khách Hàng")
                {
                    Main_User main_User = new Main_User();
                    main_User.FormClosed += Main_User_FormClosed;
                    main_User.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng.");
            }
        }

        private void Main_Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show(); // Hiển thị lại form Đăng nhập khi form Main_Admin đóng
        }

        private void Main_User_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show(); // Hiển thị lại form Đăng nhập khi form Main_User đóng
        }

        private void checkBox_HienThiMatKhau_DN_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_HienThiMatKhau_DN.Checked)
            {
                textBox_MatKhau_DN.PasswordChar = '\0'; 
            }
            else
            {
                textBox_MatKhau_DN.PasswordChar = '*'; 
            }
        }

        private void button_Thoat_DN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát khỏi ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }

        private void linkLabel_DangKi_DN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKi dangKi = new DangKi();
            dangKi.FormClosed += DangKi_FormClosed;
            dangKi.Show();
            this.Hide();
        }

        private void DangKi_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
