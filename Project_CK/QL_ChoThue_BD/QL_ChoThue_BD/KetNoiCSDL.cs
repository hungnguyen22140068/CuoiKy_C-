using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace QL_ChoThue_BD
{
    public class KetNoiCSDL
    {
        /*
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;
        string str;

        public KetNoiCSDL()
        {
            try
            {
                this.str = ConfigurationManager.ConnectionStrings["ketnoi"].ConnectionString;
                if (string.IsNullOrEmpty(str))
                {
                    throw new InvalidOperationException("Chuỗi kết nối không được cấu hình trong App.config");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo kết nối: {ex.Message}");
            }
        }

        public void OpenConnection()
        {
            if (sqlConnection == null || sqlConnection.State == ConnectionState.Closed)
            {
                try
                {
                    sqlConnection = new SqlConnection(str);
                    sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở kết nối: {ex.Message}");
                }
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection != null || sqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đóng kết nối: {ex.Message}");
                }
            }
        }

        public DataTable Execute(string query)
        {
            DataTable dt = new DataTable();
            OpenConnection();

            try
            {
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi truy vấn: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public void ExecuteNonQuery(string query)
        {
            OpenConnection();

            try
            {
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi truy vấn không trả về dữ liệu: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }

        public string KiemTraDangNhap(string userName, string passWord)
        {
            string role = null;
            string query = "SELECT Role FROM TaiKhoan WHERE TenTK = @username AND MatKhau = @password";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@username", userName);
            cmd.Parameters.AddWithValue("@password", passWord);

            OpenConnection();
            try
            {

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    role = reader["Role"].ToString();
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show($"Lỗi khi kiểm tra đăng nhập: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return role;
        }

        public SqlConnection GetSqlConnection()
        {
            return sqlConnection;
        }
        */


        private SqlConnection sqlConnection;
        private string str;

        public KetNoiCSDL()
        {
            try
            {
                this.str = ConfigurationManager.ConnectionStrings["ketnoi"].ConnectionString;
                if (string.IsNullOrEmpty(str))
                {
                    throw new InvalidOperationException("Chuỗi kết nối không được cấu hình trong App.config");
                }
                sqlConnection = new SqlConnection(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo kết nối: {ex.Message}");
            }
        }

        public void OpenConnection()
        {
            if (sqlConnection == null || sqlConnection.State == ConnectionState.Closed)
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở kết nối: {ex.Message}");
                }
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đóng kết nối: {ex.Message}");
                }
            }
        }

        public DataTable Execute(string query)
        {
            DataTable dt = new DataTable();
            OpenConnection();

            try
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection))
                {
                    sqlDataAdapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi truy vấn: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public void ExecuteNonQuery(string query)
        {
            OpenConnection();

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi truy vấn không trả về dữ liệu: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }

        public string KiemTraDangNhap(string userName, string passWord)
        {
            string role = null;
            string query = "SELECT Role FROM TaiKhoan WHERE TenTK = @username AND MatKhau = @password";

            OpenConnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@password", passWord);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            role = reader["Role"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra đăng nhập: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }

            return role;
        }

        public SqlConnection GetSqlConnection()
        {
            return sqlConnection;
        }
    }
}

