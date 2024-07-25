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
    public partial class Main_User : Form
    {
        //KetNoiCSDL ketNoiCSDL = new KetNoiCSDL();

        public Main_User()
        {
            InitializeComponent();
        }

        private void Main_User_Load(object sender, EventArgs e)
        {
            LoadBangDiaData();
            LoadPhieuThueData();
        }

        private void LoadData()
        {
            // Clear all text fields
            textBox_TenBangDia_TabSP.Clear();
            comboBox_TheLoai_TabSP.Text = "";
            comboBox_TinhTrang_TabSP.Text = "";
            textBox_NhaCungCap_tabSP.Clear();
            dateTimePicker_NgayThue_TabSP.Value = DateTime.Now;
            dateTimePicker_NgayTra_TabSP.Value = DateTime.Now;
            textBox_TienThanhToan_TabSP.Clear();
            textBox_TenNguoiThue_TabSP.Clear();

            textBox_TenBangDiaTR_TabDS.Clear();
            comboBox_TheLoaiTR_TabDS.Text = "";
            comboBox_TinhTrangTR_TabDS.Text = "";
            textBox_NhaCungCapTR_tabDS.Clear();
            dateTimePicker_NgayThueTR_TabDS.Value = DateTime.Now;
            dateTimePicker_NgayTraTR_TabDS.Value = DateTime.Now;
            dateTimePicker_NgayTraThucTR_TabDS.Value = DateTime.Now;
            textBox_NgayTreTR_TabDS.Clear();
            textBox_TenNguoiTraTR_TabDS.Clear();
            textBox_TienPhatTR_TabDS.Clear();

            comboBox_TheLoaiTK_TabSP.Text = "";
            textBox_TenTK_TabSP.Clear();
        }

        private void LoadBangDiaData()
        {
            KetNoiCSDL ketNoiCSDL = new KetNoiCSDL();

            string query = "SELECT MaBangDia AS N'Mã băng đĩa', TenBangDia AS N'Tên băng đĩa', TenNhaCungCap AS N'Tên nhà cung cấp', TheLoai AS N'Thể loại', TinhTrang AS N'Tình trạng', DonGia AS N'Đơn giá' " +
                "FROM BangDia INNER JOIN NhaCungCap ON BangDia.MaNhaCungCap = NhaCungCap.MaNhaCungCap";
            DataTable dataTable = ketNoiCSDL.Execute(query);
            dataGridView_SP.DataSource = dataTable;
        }

        private void LoadPhieuThueData()
        {
            KetNoiCSDL ketNoiCSDL = new KetNoiCSDL();

            string query = @"
            SELECT 
                PhieuThue.SoPhieuThue AS N'Mã phiếu thuê',
                BangDia.TenBangDia AS N'Tên băng đĩa',
                BangDia.TheLoai AS N'Thể loại',
                BangDia.TinhTrang N'Tình trạng',
                NhaCungCap.TenNhaCungCap N'Tên nhà cung cấp',
                KhachHang.HoTen AS N'Tên khách hàng',
                PhieuThue.NgayThue N'Ngày thuê',
                PhieuThue.NgayTra N'Ngày trả',
                BangDia.DonGia AS N'Đơn giá'
            FROM 
                PhieuThue
            JOIN 
                BangDia ON PhieuThue.MaBangDia = BangDia.MaBangDia
            JOIN 
                NhaCungCap ON BangDia.MaNhaCungCap = NhaCungCap.MaNhaCungCap
            JOIN 
                KhachHang ON PhieuThue.MaKhachHang = KhachHang.MaKhachHang;
            ";
            DataTable dataTable = ketNoiCSDL.Execute(query);
            dataGridView_PT.DataSource = dataTable;
        }

        private void button_Thue_TabSP_Click(object sender, EventArgs e)
        {
            KetNoiCSDL ketNoiCSDL = new KetNoiCSDL();

            string tenNguoiThue = textBox_TenNguoiThue_TabSP.Text;
            string tenBangDia = textBox_TenBangDia_TabSP.Text;
            string theLoai = comboBox_TheLoai_TabSP.Text;
            string tinhTrang = comboBox_TinhTrang_TabSP.Text;
            string nhaCungCap = textBox_NhaCungCap_tabSP.Text;
            decimal donGia = decimal.Parse(textBox_TienThanhToan_TabSP.Text);
            DateTime ngayThue = dateTimePicker_NgayThue_TabSP.Value;
            DateTime ngayTra = dateTimePicker_NgayTra_TabSP.Value;

            ketNoiCSDL.OpenConnection();

            using (SqlConnection connection = ketNoiCSDL.GetSqlConnection())
            {
                // Kiểm tra xem tên người thuê có trong CSDL không
                string queryKiemTra = "SELECT COUNT(*) FROM KhachHang WHERE HoTen = @tenNguoiThue";
                SqlCommand cmdKiemTra = connection.CreateCommand();
                cmdKiemTra.CommandText = queryKiemTra;
                cmdKiemTra.Parameters.AddWithValue("@tenNguoiThue", tenNguoiThue);

                int count = (int)cmdKiemTra.ExecuteScalar();

                if (count > 0)
                {
                    // Thêm thông tin vào bảng PhieuThue và lấy SoPhieuThue mới nhất
                    string queryThemPhieuThue = "INSERT INTO PhieuThue (MaKhachHang, MaBangDia, NgayThue, NgayTra, TongTienThanhToan) " +
                                                "OUTPUT INSERTED.SoPhieuThue " +
                                                "VALUES ((SELECT MaKhachHang FROM KhachHang WHERE HoTen = @tenNguoiThue), " +
                                                "(SELECT MaBangDia FROM BangDia WHERE TenBangDia = @tenBangDia), " +
                                                "@ngayThue, @ngayTra, @donGia)";

                    SqlCommand cmdThemPhieuThue = new SqlCommand(queryThemPhieuThue, connection);
                    cmdThemPhieuThue.Parameters.AddWithValue("@tenNguoiThue", tenNguoiThue);
                    cmdThemPhieuThue.Parameters.AddWithValue("@tenBangDia", tenBangDia);
                    cmdThemPhieuThue.Parameters.AddWithValue("@ngayThue", ngayThue);
                    cmdThemPhieuThue.Parameters.AddWithValue("@ngayTra", ngayTra);
                    cmdThemPhieuThue.Parameters.AddWithValue("@donGia", donGia);

                    int soPhieuThue = (int)cmdThemPhieuThue.ExecuteScalar();

                    // Thêm thông tin vào bảng LichSuThue
                    string queryThemLichSuThue = "INSERT INTO LichSuThue (SoPhieuThue, MaKhachHang, MaBangDia) " +
                                                 "VALUES (@soPhieuThue, " +
                                                 "(SELECT MaKhachHang FROM KhachHang WHERE HoTen = @tenNguoiThue), " +
                                                 "(SELECT MaBangDia FROM BangDia WHERE TenBangDia = @tenBangDia))";

                    SqlCommand cmdThemLichSuThue = new SqlCommand(queryThemLichSuThue, connection);
                    cmdThemLichSuThue.Parameters.AddWithValue("@soPhieuThue", soPhieuThue);
                    cmdThemLichSuThue.Parameters.AddWithValue("@tenNguoiThue", tenNguoiThue);
                    cmdThemLichSuThue.Parameters.AddWithValue("@tenBangDia", tenBangDia);

                    cmdThemLichSuThue.ExecuteNonQuery();

                    MessageBox.Show("Thuê thành công!");

                    LoadPhieuThueData();

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Tên người dùng không hợp lệ!");
                }
            }
        }
    


        private void dataGridView_SP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_SP.Rows[e.RowIndex];
                textBox_TenBangDia_TabSP.Text = row.Cells["Tên băng đĩa"].Value.ToString();
                comboBox_TheLoai_TabSP.Text = row.Cells["Thể loại"].Value.ToString();
                comboBox_TinhTrang_TabSP.Text = row.Cells["Tình trạng"].Value.ToString();
                textBox_NhaCungCap_tabSP.Text = row.Cells["Tên nhà cung cấp"].Value.ToString();
                textBox_TienThanhToan_TabSP.Text = row.Cells["Đơn giá"].Value.ToString();

                // Thêm code cập nhật ngày thuê và ngày trả ở đây
                dateTimePicker_NgayThue_TabSP.Value = DateTime.Now; // Ngày thuê là ngày hiện tại
                dateTimePicker_NgayTra_TabSP.Value = dateTimePicker_NgayThue_TabSP.Value.AddDays(3); // Ngày trả là 3 ngày sau ngày thuê

                dateTimePicker_NgayThue_TabSP.Enabled = false;
                dateTimePicker_NgayTra_TabSP.Enabled = false;
            }
        }

        private void button_TimKiem_TabSP_Click(object sender, EventArgs e)
        {
            KetNoiCSDL ketNoiCSDL = new KetNoiCSDL();

            string theLoai = comboBox_TheLoaiTK_TabSP.Text;
            string tenBangDia = textBox_TenTK_TabSP.Text;

            string query = "SELECT MaBangDia AS N'Mã băng đĩa', TenBangDia AS N'Tên băng đĩa', TenNhaCungCap AS N'Tên nhà cung cấp', TheLoai AS N'Thể loại', TinhTrang AS N'Tình trạng', DonGia AS N'Đơn giá' " +
                "FROM BangDia INNER JOIN NhaCungCap ON BangDia.MaNhaCungCap = NhaCungCap.MaNhaCungCap";

            if (!string.IsNullOrEmpty(theLoai))
            {
                query += " WHERE TheLoai = @theLoai";
            }
            else if (!string.IsNullOrEmpty(tenBangDia))
            {
                query += " WHERE TenBangDia LIKE @tenBangDia";
            }

            SqlCommand cmd = new SqlCommand(query, ketNoiCSDL.GetSqlConnection());

            if (!string.IsNullOrEmpty(theLoai))
            {
                cmd.Parameters.AddWithValue("@theLoai", theLoai);
            }
            else if (!string.IsNullOrEmpty(tenBangDia))
            {
                cmd.Parameters.AddWithValue("@tenBangDia", "%" + tenBangDia + "%");
            }

            DataTable dataTable = new DataTable();
            ketNoiCSDL.OpenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            ketNoiCSDL.CloseConnection();

            dataGridView_SP.DataSource = dataTable;
            LoadData();
        }

        private void button_LamMoi_TabSP_Click(object sender, EventArgs e)
        {
            LoadBangDiaData();
        }

        private void button_Tra_TabDS_Click(object sender, EventArgs e)
        {
            KetNoiCSDL ketNoiCSDL = new KetNoiCSDL();

            string tenNguoiThue = textBox_TenNguoiTraTR_TabDS.Text;
            string tenBangDia = textBox_TenBangDiaTR_TabDS.Text;
            DateTime ngayThue = dateTimePicker_NgayThueTR_TabDS.Value;
            DateTime ngayTraDuKien = dateTimePicker_NgayTraTR_TabDS.Value;
            DateTime ngayTraThucTe = dateTimePicker_NgayTraThucTR_TabDS.Value;
            decimal tienPhatQuaHan = decimal.Parse(textBox_TienPhatTR_TabDS.Text);
            ketNoiCSDL.OpenConnection();

            using (SqlConnection connection = ketNoiCSDL.GetSqlConnection())
            {
                // Kiểm tra xem tên người thuê có trong CSDL không
                string queryKiemTra = "SELECT COUNT(*) FROM KhachHang WHERE HoTen = @tenNguoiThue";
                SqlCommand cmdKiemTra = new SqlCommand(queryKiemTra, connection);
                cmdKiemTra.Parameters.AddWithValue("@tenNguoiThue", tenNguoiThue);

                int count = (int)cmdKiemTra.ExecuteScalar();

                if (count > 0)
                {
                    // Thêm thông tin vào bảng PhieuTra và lấy SoPhieuTra mới nhất
                    string queryThemPhieuTra = @"
                INSERT INTO PhieuTra (MaKhachHang, MaBangDia, NgayThue, NgayTraDuKien, NgayTraThuTe, TienPhatQuaHan)
                OUTPUT INSERTED.SoPhieuTra
                VALUES (
                    (SELECT MaKhachHang FROM KhachHang WHERE HoTen = @tenNguoiThue),
                    (SELECT MaBangDia FROM BangDia WHERE TenBangDia = @tenBangDia),
                    @ngayThue, 
                    @ngayTraDuKien, 
                    @ngayTraThucTe,
                    @tienPhatQuaHan)";

                    SqlCommand cmdThemPhieuTra = new SqlCommand(queryThemPhieuTra, connection);
                    cmdThemPhieuTra.Parameters.AddWithValue("@tenNguoiThue", tenNguoiThue);
                    cmdThemPhieuTra.Parameters.AddWithValue("@tenBangDia", tenBangDia);
                    cmdThemPhieuTra.Parameters.AddWithValue("@ngayThue", ngayThue);
                    cmdThemPhieuTra.Parameters.AddWithValue("@ngayTraDuKien", ngayTraDuKien);
                    cmdThemPhieuTra.Parameters.AddWithValue("@ngayTraThucTe", ngayTraThucTe);
                    cmdThemPhieuTra.Parameters.AddWithValue("@tienPhatQuaHan", tienPhatQuaHan);

                    int soPhieuTra = (int)cmdThemPhieuTra.ExecuteScalar();

                    // Thêm thông tin vào bảng LichSuTra
                    string queryThemLichSuTra = @"
                INSERT INTO LichSuTra (SoPhieuTra, MaKhachHang, MaBangDia)
                VALUES (
                    @soPhieuTra,
                    (SELECT MaKhachHang FROM KhachHang WHERE HoTen = @tenNguoiThue),
                    (SELECT MaBangDia FROM BangDia WHERE TenBangDia = @tenBangDia))";

                    SqlCommand cmdThemLichSuTra = new SqlCommand(queryThemLichSuTra, connection);
                    cmdThemLichSuTra.Parameters.AddWithValue("@soPhieuTra", soPhieuTra);
                    cmdThemLichSuTra.Parameters.AddWithValue("@tenNguoiThue", tenNguoiThue);
                    cmdThemLichSuTra.Parameters.AddWithValue("@tenBangDia", tenBangDia);

                    cmdThemLichSuTra.ExecuteNonQuery();

                    string soPhieuThue = dataGridView_PT.CurrentRow.Cells["Mã phiếu thuê"].Value.ToString();

                    // Xóa các bản ghi liên quan trong bảng LichSuThue trước khi xóa PhieuThue
                    string queryDeleteLichSuThue = "DELETE FROM LichSuThue WHERE SoPhieuThue = @soPhieuThue";
                    SqlCommand cmdDeleteLichSuThue = new SqlCommand(queryDeleteLichSuThue, connection);
                    cmdDeleteLichSuThue.Parameters.AddWithValue("@soPhieuThue", soPhieuThue);
                    cmdDeleteLichSuThue.ExecuteNonQuery();

                    // Xóa bản ghi trong bảng PhieuThue
                    string queryDeletePhieuThue = "DELETE FROM PhieuThue WHERE SoPhieuThue = @soPhieuThue";
                    SqlCommand cmdDeletePhieuThue = new SqlCommand(queryDeletePhieuThue, connection);
                    cmdDeletePhieuThue.Parameters.AddWithValue("@soPhieuThue", soPhieuThue);
                    cmdDeletePhieuThue.ExecuteNonQuery();

                    MessageBox.Show("Trả băng đĩa thành công và băng đĩa đã được xóa khỏi hệ thống!");

                    LoadPhieuThueData();
                }
                else
                {
                    MessageBox.Show("Tên người dùng không hợp lệ!");
                }
            }
        }

        private void dataGridView_PT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_PT.Rows[e.RowIndex];
                textBox_TenBangDiaTR_TabDS.Text = row.Cells["Tên băng đĩa"].Value.ToString();
                comboBox_TheLoaiTR_TabDS.Text = row.Cells["Thể loại"].Value.ToString();
                comboBox_TinhTrangTR_TabDS.Text = row.Cells["Tình trạng"].Value.ToString();
                textBox_NhaCungCapTR_tabDS.Text = row.Cells["Tên nhà cung cấp"].Value.ToString();
                textBox_TenNguoiTraTR_TabDS.Text = row.Cells["Tên khách hàng"].Value.ToString();
                dateTimePicker_NgayThue_TabSP.Value = Convert.ToDateTime(row.Cells["Ngày thuê"].Value);
                dateTimePicker_NgayTra_TabSP.Value = Convert.ToDateTime(row.Cells["Ngày trả"].Value);
                dateTimePicker_NgayTraThucTR_TabDS.Value = DateTime.Now; // Ngày trả thực tế là ngày hiện tại

                // Disable editing for rental and expected return dates
                dateTimePicker_NgayThueTR_TabDS.Enabled = false;
                dateTimePicker_NgayTraTR_TabDS.Enabled = false;

                // Calculate late days and penalty
                int lateDays = (dateTimePicker_NgayTraThucTR_TabDS.Value - dateTimePicker_NgayTra_TabSP.Value).Days;
                lateDays = lateDays > 0 ? lateDays : 0;
                textBox_NgayTreTR_TabDS.Text = lateDays.ToString();

                // Calculate fine and format it as an integer
                decimal fine = lateDays * 10000;
                textBox_TienPhatTR_TabDS.Text = fine.ToString();
            }
        }

        private void button_LSTTR_TabDS_Click(object sender, EventArgs e)
        {
            Form_LichSu form_LichSu = new Form_LichSu();
            form_LichSu.ShowDialog();
        }

        private void button_DangXuat_TabDS_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
