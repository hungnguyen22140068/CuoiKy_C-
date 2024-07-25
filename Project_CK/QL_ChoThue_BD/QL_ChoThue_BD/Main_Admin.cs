using System;
using System.Collections;
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
    public partial class Main_Admin : Form
    {
        KetNoiCSDL KetNoiCSDL = new KetNoiCSDL();

        public Main_Admin()
        {
            InitializeComponent();
        }

        private void Main_Admin_Load(object sender, EventArgs e)
        {
            LoadBangDiaData();

            LoadNhanVienData();

            LoadKhachHangData();

            LoadThongKeData();

            LoadNhaCungCapData();
        }

        private void Loaddata()
        {
            textBox_MaKhachHang_TabQLKH.Text = "";
            textBox_TenKhachHang_TabQLKH.Text = "";
            comboBox_GioiTinh_TabQLKH.Text = "";
            textBox_SDT_TabQLKH.Text = "";
            textBox_DiaChi_TabQLKH.Text = "";
            dateTimePicker_NgaySinh_TabQLKH.Text = "";

            textBox_MaBangDia.Text = "";
            textBox_TenBangDia.Text = "";
            textBox_MaNhaCungCap.Text = "";
            comboBox_TenNhaCungCap.Text = "";
            comboBox_TheLoai.Text = "";
            comboBox_TinhTrang.Text = "";
            textBox_DoanGia.Text = "";

            textBox_MaNhanVien_TabQLNV.Text = "";
            textBox_TenNhanVien_TabQLNV.Text = "";
            textBox_SDT_TabQLNV.Text = "";
            textBox_DiaChi_TabQLNV.Text = "";
            comboBox_GioiTinh_TabQLNV.Text = "";
            comboBox_ChucVu_TabQLNV.Text = "";
            dateTimePicker_NgaySinh_TabQLNV.Text = "";
        }

        // tab quản lý sản phẩm
        private void LoadBangDiaData()
        {
            string query = "SELECT MaBangDia AS N'Mã băng đĩa', TenBangDia AS N'Tên băng đĩa', TenNhaCungCap AS N'Tên nhà cung cấp', TheLoai AS N'Thể loại', TinhTrang AS N'Tình trạng', DonGia AS N'Đơn giá' " +
                "FROM BangDia INNER JOIN NhaCungCap ON BangDia.MaNhaCungCap = NhaCungCap.MaNhaCungCap";
            DataTable dataTable = KetNoiCSDL.Execute(query);
            dataGridView_QLSP.DataSource = dataTable;
        }

        private void LoadNhaCungCapData()
        {
            string query = "SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap";
            DataTable dataTable = KetNoiCSDL.Execute(query);
            comboBox_TenNhaCungCap.DataSource = dataTable;
            comboBox_TenNhaCungCap.DisplayMember = "TenNhaCungCap";
            comboBox_TenNhaCungCap.ValueMember = "MaNhaCungCap";
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            string maBangDia = textBox_MaBangDia.Text;
            string tenBangDia = textBox_TenBangDia.Text;
            string maNhaCungCap = textBox_MaNhaCungCap.Text;
            string theLoai = comboBox_TheLoai.Text;
            string tinhTrang = comboBox_TinhTrang.Text;
            decimal donGia = Convert.ToDecimal(textBox_DoanGia.Text);

            string query = $"INSERT INTO BangDia (MaBangDia, TenBangDia, MaNhaCungCap, TheLoai, TinhTrang, DonGia) VALUES ('{maBangDia}', N'{tenBangDia}', '{maNhaCungCap}', N'{theLoai}', N'{tinhTrang}', {donGia})";
            KetNoiCSDL.ExecuteNonQuery(query);
            LoadBangDiaData();
            Loaddata();
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            string maBangDia = dataGridView_QLSP.CurrentRow.Cells["Mã băng đĩa"].Value.ToString();

            string query = "DELETE FROM BangDia WHERE MaBangDia = '" + maBangDia + "'";
            KetNoiCSDL.ExecuteNonQuery(query);
            LoadBangDiaData();
            Loaddata();
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            string maBangDia = textBox_MaBangDia.Text;
            string tenBangDia = textBox_TenBangDia.Text;
            string maNhaCungCap = textBox_MaNhaCungCap.Text;
            string theLoai = comboBox_TheLoai.Text;
            string tinhTrang = comboBox_TinhTrang.Text;
            decimal donGia;

            if (!decimal.TryParse(textBox_DoanGia.Text, out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ. Vui lòng nhập lại.");
                return;
            }

            string query = $"UPDATE BangDia SET TenBangDia = N'{tenBangDia}', MaNhaCungCap = '{maNhaCungCap}', TheLoai = N'{theLoai}', TinhTrang = N'{tinhTrang}', DonGia = {donGia} WHERE MaBangDia = '{maBangDia}'";
            KetNoiCSDL.ExecuteNonQuery(query);
            LoadBangDiaData();
            Loaddata();
        }

        private void comboBox_TenNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_TenNhaCungCap.SelectedItem != null)
            {
                DataRowView selectedItem = comboBox_TenNhaCungCap.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    textBox_MaNhaCungCap.Text = selectedItem["MaNhaCungCap"].ToString();
                }
            }
        }

        private void dataGridView_QLSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_QLSP.Rows[e.RowIndex];
                textBox_MaBangDia.Text = row.Cells["Mã băng đĩa"].Value.ToString();
                textBox_TenBangDia.Text = row.Cells["Tên băng đĩa"].Value.ToString();
                comboBox_TenNhaCungCap.Text = row.Cells["Tên nhà cung cấp"].Value.ToString();
                foreach (DataRowView item in comboBox_TenNhaCungCap.Items)
                {
                    if (item["TenNhaCungCap"].ToString() == row.Cells["Tên nhà cung cấp"].Value.ToString())
                    {
                        comboBox_TenNhaCungCap.SelectedItem = item;
                        textBox_MaNhaCungCap.Text = item["MaNhaCungCap"].ToString();
                        break;
                    }
                }

                comboBox_TheLoai.Text = row.Cells["Thể loại"].Value.ToString();
                comboBox_TinhTrang.Text = row.Cells["Tình trạng"].Value.ToString();
                textBox_DoanGia.Text = row.Cells["Đơn giá"].Value.ToString();
            }
        }


        // tab quản lý nhân viên
        private void LoadNhanVienData()
        {
            string query = "SELECT MaNhanVien AS N'Mã nhân viên', TenNhanVien AS N'Tên nhân viên', SDT AS N'Số điện thoại', DiaChi AS N'Địa chỉ', GioiTinh AS N'Giới tính', ChucVu AS N'Chức vụ', NgayThangNamSinh AS N'Ngày sinh' " +
                "FROM NhanVien";
            DataTable dataTable = KetNoiCSDL.Execute(query);
            dataGridView_QLNV.DataSource = dataTable;
        }

        private void button_Them_TabQLNV_Click(object sender, EventArgs e)
        {
            string maNhanVien = textBox_MaNhanVien_TabQLNV.Text;
            string tenNhanVien = textBox_TenNhanVien_TabQLNV.Text;
            string SDT = textBox_SDT_TabQLNV.Text;
            string diaChi = textBox_DiaChi_TabQLNV.Text;
            string gioiTinh = comboBox_GioiTinh_TabQLNV.Text;
            string chucVu = comboBox_ChucVu_TabQLNV.Text;
            string ngaySinh = dateTimePicker_NgaySinh_TabQLNV.Value.ToString("yyyy-MM-dd");

            string query = $"INSERT INTO NhanVien (MaNhanVien, TenNhanVien, SDT, DiaChi, GioiTinh, ChucVu, NgayThangNamSinh) VALUES ('{maNhanVien}', N'{tenNhanVien}', '{SDT}', N'{diaChi}', N'{gioiTinh}', N'{chucVu}', '{ngaySinh}')";
            KetNoiCSDL.ExecuteNonQuery(query);
            LoadNhanVienData();
            Loaddata();
        }

        private void button_Xoa_TabQLNV_Click(object sender, EventArgs e)
        {
            string maNhanVien = dataGridView_QLNV.CurrentRow.Cells["Mã nhân viên"].Value.ToString();

            string query = "DELETE FROM NhanVien WHERE MaNhanVien = '" + maNhanVien + "'";
            KetNoiCSDL.ExecuteNonQuery(query);
            LoadNhanVienData();
            Loaddata();
        }

        private void button_Sua_TabQLNV_Click(object sender, EventArgs e)
        {
            string maNhanVien = textBox_MaNhanVien_TabQLNV.Text;
            string tenNhanVien = textBox_TenNhanVien_TabQLNV.Text;
            string SDT = textBox_SDT_TabQLNV.Text;
            string diaChi = textBox_DiaChi_TabQLNV.Text;
            string gioiTinh = comboBox_GioiTinh_TabQLNV.Text;
            string chucVu = comboBox_ChucVu_TabQLNV.Text;
            string ngaySinh = dateTimePicker_NgaySinh_TabQLNV.Value.ToString("yyyy-MM-dd");

            string query = $"UPDATE NhanVien SET TenNhanVien = N'{tenNhanVien}', SDT = '{SDT}', DiaChi = N'{diaChi}', GioiTinh = N'{gioiTinh}', ChucVu = N'{chucVu}', NgayThangNamSinh = '{ngaySinh}' WHERE MaNhanVien = '{maNhanVien}'";
            KetNoiCSDL.ExecuteNonQuery(query);
            LoadNhanVienData();
            Loaddata();
        }

        private void dataGridView_QLNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_QLNV.Rows[e.RowIndex];
                textBox_MaNhanVien_TabQLNV.Text = row.Cells["Mã nhân viên"].Value.ToString();
                textBox_TenNhanVien_TabQLNV.Text = row.Cells["Tên nhân viên"].Value.ToString();
                textBox_SDT_TabQLNV.Text = row.Cells["Số điện thoại"].Value.ToString();
                textBox_DiaChi_TabQLNV.Text = row.Cells["Địa chỉ"].Value.ToString();
                comboBox_GioiTinh_TabQLNV.Text = row.Cells["Giới tính"].Value.ToString();
                comboBox_ChucVu_TabQLNV.Text = row.Cells["Chức vụ"].Value.ToString();
                dateTimePicker_NgaySinh_TabQLNV.Text = row.Cells["Ngày sinh"].Value.ToString();
            }
        }


        // tab quản lý khách hàng
        private void LoadKhachHangData()
        {
            string query = "SELECT MaKhachHang AS N'Mã khách hàng', HoTen AS N'Tên khách hàng', GioiTinh AS N'Giới tính', SDT AS N'Số điện thoại', DiaChi AS N'Địa chỉ', NgayThangNamSinh AS N'Ngày sinh' " +
                "FROM KhachHang";
            DataTable dataTable = KetNoiCSDL.Execute(query);
            dataGridView_QLKH.DataSource = dataTable;
        }

        private void button_Them_TabQLKH_Click(object sender, EventArgs e)
        {
            string maKhachHang = textBox_MaKhachHang_TabQLKH.Text;
            string hoTen = textBox_TenKhachHang_TabQLKH.Text;
            string gioiTinh = comboBox_GioiTinh_TabQLKH.Text;
            string SDT = textBox_SDT_TabQLKH.Text;
            string diaChi = textBox_DiaChi_TabQLKH.Text;
            string ngaySinh = dateTimePicker_NgaySinh_TabQLKH.Value.ToString("yyyy-MM-dd");

            string query = $"INSERT INTO KhachHang (MaKhachHang, HoTen, GioiTinh, SDT, DiaChi, NgayThangNamSinh) VALUES ('{maKhachHang}', N'{hoTen}', N'{gioiTinh}', '{SDT}', N'{diaChi}', '{ngaySinh}')";
            KetNoiCSDL.Execute(query);
            LoadKhachHangData();
            Loaddata();
        }

        private void button_Xoa_TabQLKH_Click(object sender, EventArgs e)
        {
            string maKhachHang = dataGridView_QLKH.CurrentRow.Cells["Mã khách hàng"].Value.ToString();

            string query = "DELETE FROM KhachHang WHERE MaKhachHang = '" + maKhachHang + "'";
            KetNoiCSDL.ExecuteNonQuery(query);
            LoadKhachHangData();
            Loaddata();
        }

        private void button_Sua_TabQLKH_Click(object sender, EventArgs e)
        {
            string maKhachHang = textBox_MaKhachHang_TabQLKH.Text;
            string hoTen = textBox_TenKhachHang_TabQLKH.Text;
            string gioiTinh = comboBox_GioiTinh_TabQLKH.Text;
            string SDT = textBox_SDT_TabQLKH.Text;
            string diaChi = textBox_DiaChi_TabQLKH.Text;
            string ngaySinh = dateTimePicker_NgaySinh_TabQLKH.Value.ToString("yyyy-MM-dd");

            string query = $"UPDATE KhachHang SET HoTen = N'{hoTen}', GioiTinh = N'{gioiTinh}', SDT = N'{SDT}', DiaChi = N'{diaChi}', NgayThangNamSinh = '{ngaySinh}' WHERE MaKhachHang = '{maKhachHang}'";
            KetNoiCSDL.ExecuteNonQuery(query);
            LoadKhachHangData();
            Loaddata();
        }

        private void dataGridView_QLKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_QLKH.Rows[e.RowIndex];
                textBox_MaKhachHang_TabQLKH.Text = row.Cells["Mã khách hàng"].Value.ToString();
                textBox_TenKhachHang_TabQLKH.Text = row.Cells["Tên khách hàng"].Value.ToString();
                comboBox_GioiTinh_TabQLKH.Text = row.Cells["Giới tính"].Value.ToString();
                textBox_SDT_TabQLKH.Text = row.Cells["Số điện thoại"].Value.ToString();
                textBox_DiaChi_TabQLKH.Text = row.Cells["Địa chỉ"].Value.ToString();
                dateTimePicker_NgaySinh_TabQLKH.Text = row.Cells["Ngày sinh"].Value.ToString();
            }
        }

        // Tab quản lý thống kê
        private void LoadThongKeData()
        {
            string query = @"
                SELECT 
                    bd.TenBangDia, 
                    ISNULL(pt.SoLanThue, 0) AS SoLanThue,
                    ISNULL(SUM(pt.TongTienThanhToan), 0) AS TongGiaTien
                FROM 
                    BangDia bd
                LEFT JOIN 
                    (SELECT MaBangDia, COUNT(*) AS SoLanThue, SUM(TongTienThanhToan) AS TongTienThanhToan
                    FROM PhieuThue
                    GROUP BY MaBangDia) pt
                    ON bd.MaBangDia = pt.MaBangDia
                GROUP BY 
                    bd.TenBangDia, TongTienThanhToan, SoLanThue
                ORDER BY 
                    SoLanThue, TenBangDia, TongTienThanhToan;";

            DataTable dataTable = KetNoiCSDL.Execute(query);
            dataGridView_QLTK.DataSource = dataTable;
        }

        private void button_ThongKe_TabQLTK_Click(object sender, EventArgs e)
        {
            string query = "";
            if(radioButton_NhieuNhat_TabQLTK.Checked)
            {
                query = @"
                    SELECT TOP 1
                        bd.TenBangDia,
                        COUNT(pt.SoPhieuThue) AS SoLanThue,
                        SUM(pt.TongTienThanhToan) AS TongGiaTien
                    FROM 
                        BangDia bd
                        INNER JOIN 
                        PhieuThue pt ON bd.MaBangDia = pt.MaBangDia
                    GROUP BY 
                        bd.TenBangDia, bd.DonGia
                    ORDER BY 
                        SoLanThue DESC";
            }
            else if (radioButton_ItNhat_TabQLTK.Checked)
            {
                query = @"
                    SELECT 
                        bd.TenBangDia, 
                        ISNULL(SUM(pt.TongTienThanhToan), 0) AS TongGiaTien, 
                        ISNULL(pt.SoLanThue, 0) AS SoLanThue
                    FROM 
                        BangDia bd
                    LEFT JOIN 
                        (SELECT MaBangDia, COUNT(*) AS SoLanThue, SUM(TongTienThanhToan) AS TongTienThanhToan
                        FROM PhieuThue
                        GROUP BY MaBangDia) pt
                        ON bd.MaBangDia = pt.MaBangDia
                    GROUP BY 
                        bd.TenBangDia, pt.TongTienThanhToan, pt.SoLanThue
                    HAVING 
                        ISNULL(pt.SoLanThue, 0) = 0
                    ORDER BY 
                        SoLanThue ASC";
            }
            DataTable dataTable = KetNoiCSDL.Execute(query);
            dataGridView_QLTK.DataSource = dataTable;
        }
        private void button_LamMoi_TabQLTK_Click(object sender, EventArgs e)
        {
            LoadThongKeData();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView_QLSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label_MaNhaCungCap_Click(object sender, EventArgs e)
        {

        }


        private void label_GioiTinh_TabQLKH_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_GioiTinh_TabQLKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void dataGridView_QLKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
