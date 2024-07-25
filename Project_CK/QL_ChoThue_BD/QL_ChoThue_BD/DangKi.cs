using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ChoThue_BD
{
    public partial class DangKi : Form
    {
        KetNoiCSDL ketNoiCSDL = new KetNoiCSDL();

        public DangKi()
        {
            InitializeComponent();
        }

        private void textBox_TenDangNhap_DK_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_MatKhau_DK_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_XacNhanMatKhau_DK_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            textBox_TenDangNhap_DK.Text = "";
            textBox_MatKhau_DK.Text = "";
            comboBox_LoaiTaiKhoan_DK.Text = "";
            textBox_XacNhanMatKhau_DK.Text = "";
            textBox_MaNV_DK.Text = "";
        }

        private void button_DangKi_DK_Click(object sender, EventArgs e)
        {
            string tenDangNhap = textBox_TenDangNhap_DK.Text;
            string matKhau = textBox_MatKhau_DK.Text;
            string xacNhanMatKhau = textBox_XacNhanMatKhau_DK.Text;
            string loaiTaiKhoan = comboBox_LoaiTaiKhoan_DK.SelectedItem.ToString();
            string maNV = textBox_MaNV_DK.Text;

            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            if (loaiTaiKhoan == "Nhân Viên")
            {
                // Kiểm tra mã nhân viên
                string queryKiemTraMaNV = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @MaNV";
                try
                {
                    SqlConnection sqlConnection = ketNoiCSDL.GetSqlConnection();
                    SqlCommand command = new SqlCommand(queryKiemTraMaNV, sqlConnection);
                    command.Parameters.AddWithValue("@MaNV", maNV);
                    sqlConnection.Open();
                    int count = (int)command.ExecuteScalar();
                    sqlConnection.Close();

                    if (count == 0)
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra mã nhân viên: " + ex.Message);
                    return;
                }
            }

            try
            {
                SqlConnection sqlConnection = ketNoiCSDL.GetSqlConnection();
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand command = sqlConnection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    string queryTaiKhoan = "INSERT INTO TaiKhoan (TenTK, MatKhau, Role) VALUES (@TenTK, @MatKhau, @Role)";
                    command.CommandText = queryTaiKhoan;
                    command.Parameters.AddWithValue("@TenTK", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);
                    command.Parameters.AddWithValue("@Role", loaiTaiKhoan);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Đăng ký thành công");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi đăng ký tài khoản: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }

            LoadData();
        }

        private void DangKi_Load(object sender, EventArgs e)
        {
            comboBox_LoaiTaiKhoan_DK.Items.Add("Nhân Viên");
            comboBox_LoaiTaiKhoan_DK.Items.Add("Khách Hàng");
            comboBox_LoaiTaiKhoan_DK.SelectedIndexChanged += ComboBox_LoaiTaiKhoan_DK_SelectedIndexChanged;
            textBox_MaNV_DK.Visible = false;
        }

        private void ComboBox_LoaiTaiKhoan_DK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_LoaiTaiKhoan_DK.SelectedItem.ToString() == "Nhân Viên")
            {
                textBox_MaNV_DK.Visible = true;
            }
            else
            {
                textBox_MaNV_DK.Visible = false;
            }
        }

        private void checkBox_HienThiMatKhau_DK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_HienThiMatKhau_DK.Checked)
            {
                textBox_MatKhau_DK.PasswordChar = '\0';
                textBox_XacNhanMatKhau_DK.PasswordChar = '\0';
            }
            else
            {
                textBox_MatKhau_DK.PasswordChar = '*';
                textBox_XacNhanMatKhau_DK.PasswordChar = '*';
            }
        }

        private void button_Thoat_DK_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            this.Close();
        }
    }
}
