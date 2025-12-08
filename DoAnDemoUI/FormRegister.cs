using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnDemoUI
{
    public partial class FormRegister : Form
    {
        private readonly string connectionString = "Data Source=LAPTOP-50B3600E;Initial Catalog=QLThuVien;Integrated Security=True;";

        public FormRegister()
        {
            InitializeComponent();
            txtNewPassword.UseSystemPasswordChar = false;
            txtNewPassword.PasswordChar = '*';


            txtConfirmPassword.UseSystemPasswordChar = false;
            txtConfirmPassword.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNewUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void create_Click(object sender, EventArgs e)
        {
            string newUsername = txtNewUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Input validation
            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Tên tài khoản và Mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password policy:
            // - length between 8 and 64
            // - must contain at least one letter, one digit and one special character
            /*const string passwordPattern = @"^(?=.{8,64}$)(?=.*[A-Za-z])(?=.*\d)(?=.*[^A-Za-z0-9]).+$";
            if (!Regex.IsMatch(newPassword, passwordPattern))
            {
                MessageBox.Show("Mật khẩu phải từ 8 đến 64 ký tự, chứa ít nhất một chữ cái, một chữ số và một ký tự đặc biệt.", "Lỗi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }*/

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            const string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", newUsername);

                // Hash the password using SHA-256 before storing it in the database.
                // Ensure the Users.Password column stores the SHA-256 hex string.
                string hashedPassword = HashPassword(newPassword);
                command.Parameters.AddWithValue("@Password", hashedPassword);
                command.Parameters.AddWithValue("@Role", "User");

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Đăng ký tài khoản thành công! Bạn có thể đăng nhập ngay bây giờ.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (SqlException ex)
                {
                    // 2627 / 2601 => unique constraint violation (username exists)
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        MessageBox.Show("Tài khoản này đã tồn tại. Vui lòng chọn tên đăng nhập khác.", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNewUsername.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static string HashSHA256(string text)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
        // SHA-256 hashing helper (returns lowercase hex string)
        private static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password ?? string.Empty));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
