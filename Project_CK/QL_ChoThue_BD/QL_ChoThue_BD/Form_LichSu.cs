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
    public partial class Form_LichSu : Form
    {
        KetNoiCSDL ketNoiCSDL = new KetNoiCSDL();

        public Form_LichSu()
        {
            InitializeComponent();
        }

        private void Form_LichSu_Load(object sender, EventArgs e) { 
            LoadLichSuTraData();
        }

        private void LoadLichSuTraData()
        {
            string query = @"
                SELECT 
                    BangDia.TenBangDia AS N'Tên băng đĩa',
                    KhachHang.HoTen AS N'Tên khách hàng',
                    PhieuTra.NgayTraDuKien AS N'Ngày trả dự kiến',
                    PhieuTra.NgayTraThuTe AS N'Ngày trả thực tế',
                    PhieuTra.TienPhatQuaHan AS N'Tiền phạt'
                FROM 
                    LichSuTra
                JOIN 
                    BangDia ON LichSuTra.MaBangDia = BangDia.MaBangDia
                JOIN 
                    KhachHang ON LichSuTra.MaKhachHang = KhachHang.MaKhachHang
                JOIN 
                    PhieuTra ON LichSuTra.SoPhieuTra = PhieuTra.SoPhieuTra;
            ";
            DataTable dataTable = ketNoiCSDL.Execute(query);
            dataGridView_LSTR.DataSource = dataTable;
        }
    }
}
