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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DoAnDemoUI
{
    public partial class Login : Form
    {
        private bool exitConfirmed = false;
        public Login()
        {
            InitializeComponent();
            this.FormClosing += form1_FormClosing;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.PasswordChar = '*';
        
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Chuỗi kết nối đến SQL Server
            // Cần thay đổi theo thông tin SQL Server của bạn
            string connectionString = "Data Source=LAPTOP-50B3600E;Initial Catalog=QLThuVien;Integrated Security=True;";
            //string connectionString = "Data Source=Ten_serverName;Initial Catalog=QLThuVien;Integrated Security=True;";
            // Hoặc dùng: "Server=TEN_SERVER;Database=QLThuVien;User Id=user;Password=pass;"

            string username = txtUsername.Text;
            string Password = txtPassword.Text; // Plain text input from the user

            // Hash the entered password using SHA-256 before sending to database.
            // IMPORTANT: Ensure the Users table stores the SHA-256 hex hash of passwords.
            string hashedPassword = HashPassword(Password);

            // 2. Câu truy vấn SQL sử dụng Parameterized Query
            // TRÁNH SQL INJECTION. LƯU ý: Password trong CSDL phải là hash SHA-256.
            string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // 3. Thêm tham số để tránh SQL Injection
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);

                    try
                    {
                        connection.Open();
                        // ExecuteScalar trả về giá trị ô đầu tiên của dòng đầu tiên (ở đây là COUNT)
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count == 1)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Mở Form quản lý thư viện và ẩn Form đăng nhập
                            // Ví dụ: FormMain mainForm = new FormMain();
                            // mainForm.Show();
                            // this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Clear();
                            txtUsername.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối hoặc truy vấn cơ sở dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public static string HashPassword(string password)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
                return;
            }

            // Nếu không thoát, xóa giá trị nhập và đặt focus về ô tài khoản
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị để đặt lại mật khẩu.", "Quên mật khẩu",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    // Đổi màu nền vùng chứa các form con thành màu trắng xám nhẹ
                    ctl.BackColor = Color.FromArgb(240, 242, 245);
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If exit was already confirmed (e.g., via ConfirmExit), allow closing without prompting.
            if (exitConfirmed)
                return;

            var result = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            // if yes, allow close to proceed
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void dktk_Click(object sender, EventArgs e)
        {
            using (var registerForm = new FormRegister())
            {
                this.Hide();
                registerForm.ShowDialog();
                this.Show();
            }
        }
    }
}
