using DoAnDemoUI.Data; // Import ThuVienContext
using System;
using System.Linq;
using System.Security.Cryptography; // Vẫn cần để Hash mật khẩu
using System.Text;
using System.Windows.Forms;

namespace DoAnDemoUI
{
    public partial class Login : Form
    {
        private bool exitConfirmed = false;

        public Login()
        {
            InitializeComponent();
            // Đảm bảo FormClosing được gán
            this.FormClosing += form1_FormClosing;
            // Thiết lập PasswordChar, đã có trong Designer nhưng nên đảm bảo
            // txtPassword.UseSystemPasswordChar = false; // Thiết lập này bị ghi đè bởi dòng sau
            txtPassword.PasswordChar = '*';
        }

        // --- HÀM HASH MẬT KHẨU (Giữ nguyên vì đây là logic bảo mật) ---
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

        // --- XỬ LÝ SỰ KIỆN ĐĂNG NHẬP SỬ DỤNG ENTITY FRAMEWORK ---
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string rawPassword = txtPassword.Text;

            // Xóa thông báo lỗi cũ (Nếu bạn sử dụng ErrorProvider)
            // errorProvider1.Clear(); 

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(rawPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Hash mật khẩu người dùng nhập
            string hashedPassword = HashPassword(rawPassword);

            // 2. Xác thực bằng Entity Framework
            try
            {
                // Sử dụng 'using' để đảm bảo context được dispose
                using (var context = new ThuVienContext())
                {
                    // Tìm người dùng theo Tên đăng nhập VÀ Mật khẩu đã Hash
                    // Mật khẩu trong DB (trường 'Password') phải là giá trị SHA-256 Hex Hash
                    var user = context.Users
                                    .FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);

                    if (user != null)
                    {
                        // Đăng nhập thành công
                        // MessageBox.Show($"Đăng nhập thành công! Chào mừng {user.} (Quyền: {user.Quyen}).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        QuanLiThuVien mainForm = new QuanLiThuVien();

                        // Ẩn Form đăng nhập hiện tại
                        this.Hide();

                        // Hiển thị Form quản lý chính
                        mainForm.Show();
                    }
                    else
                    {
                        // Đăng nhập thất bại
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtUsername.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi liên quan đến Entity Framework/kết nối DB
                MessageBox.Show($"Lỗi xử lý dữ liệu (EF): {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- CÁC HÀM XỬ LÝ KHÁC (Được giữ nguyên) ---

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                exitConfirmed = true; // Đặt cờ để FormClosing không hỏi lại
                Application.Exit();
                return;
            }

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

        // Xử lý sự kiện Đăng ký Tài khoản
        private void dktk_Click(object sender, EventArgs e)
        {
            // Cần đảm bảo FormRegister() tồn tại
            using (var registerForm = new FormRegister())
            {
                this.Hide();
                registerForm.ShowDialog();
                this.Show();
            }
            //MessageBox.Show("Đang mở Form Đăng Ký...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitConfirmed)
                return;

            var result = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        // Các hàm không quan trọng trong logic chính (Giữ lại hoặc xóa bớt tùy ý)
        private void Login_Load(object sender, EventArgs e) { /* ... */ }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void lblUsername_Click(object sender, EventArgs e) { }
        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void chkRemember_CheckedChanged(object sender, EventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
    }
}