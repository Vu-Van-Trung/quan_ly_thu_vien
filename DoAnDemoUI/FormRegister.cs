using DoAnDemoUI.Data; // Chắc chắn đã thêm tham chiếu đến Context
using DoAnDemoUI.Model; // Chắc chắn đã thêm tham chiếu đến Model User
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure; // Cần cho việc bắt lỗi DbUpdateException
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnDemoUI
{
    public partial class FormRegister : Form
    {
        // Loại bỏ connectionString hardcode, Form sẽ dùng ThuVienContext
        // private readonly string connectionString = "Data Source=LAPTOP-50B3600E;Initial Catalog=QLThuVien;Integrated Security=True;"; 

        public FormRegister()
        {
            InitializeComponent();
            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        // =========================================================================
        // PHƯƠNG THỨC XỬ LÝ SỰ KIỆN ĐĂNG KÝ
        // =========================================================================

        private async void create_Click(object sender, EventArgs e)
        {
            string newUsername = txtNewUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Tắt nút để tránh double-click trong khi xử lý
            create.Enabled = false;

            if (!ValidateInput(newUsername, newPassword, confirmPassword))
            {
                create.Enabled = true; // Bật lại nếu validation thất bại
                return;
            }

            // Hash the password before storing it
            string hashedPassword = HashPassword(newPassword);

            // Sử dụng Entity Framework để thêm User mới
            try
            {
                using (var context = new ThuVienContext())
                {
                    // 1. Kiểm tra tài khoản đã tồn tại chưa (Quan trọng!)
                    bool userExists = await context.Users.AnyAsync(u => u.Username == newUsername);

                    if (userExists)
                    {
                        MessageBox.Show("Tài khoản này đã tồn tại. Vui lòng chọn tên đăng nhập khác.", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNewUsername.Focus();
                        return;
                    }

                    // 2. Tạo đối tượng User mới
                    var newUser = new User
                    {
                        Username = newUsername,
                        Password = hashedPassword, // Lưu mật khẩu đã hash
                        Role = "User", // Mặc định là vai trò "User"
                        CreatedAt = DateTime.Now
                    };

                    // 3. Thêm vào DbSet và lưu vào Database
                    context.Users.Add(newUser);

                    // Sử dụng SaveChangesAsync để chạy bất đồng bộ
                    await context.SaveChangesAsync();

                    MessageBox.Show("Đăng ký tài khoản thành công! Bạn có thể đăng nhập ngay bây giờ.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (DbUpdateException dbEx)
            {
                // Xử lý lỗi từ Entity Framework (ví dụ: lỗi giới hạn ký tự, lỗi Null)
                MessageBox.Show("Lỗi cập nhật CSDL: " + dbEx.Message, "Lỗi Entity Framework", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác (ví dụ: lỗi kết nối)
                MessageBox.Show("Đã xảy ra lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                create.Enabled = true; // Luôn bật lại nút khi kết thúc
            }
        }

        // =========================================================================
        // PHƯƠNG THỨC HỖ TRỢ (HASH VÀ VALIDATION)
        // =========================================================================

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu nhập
        /// </summary>
        private bool ValidateInput(string username, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Tên tài khoản và Mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return false;
            }

            // Bạn có thể kích hoạt lại phần kiểm tra độ phức tạp mật khẩu ở đây
            /*
            const string passwordPattern = @"^(?=.{8,64}$)(?=.*[A-Za-z])(?=.*\d)(?=.*[^A-Za-z0-9]).+$";
            if (!Regex.IsMatch(password, passwordPattern))
            {
                 MessageBox.Show("Mật khẩu phải từ 8 đến 64 ký tự, chứa ít nhất một chữ cái, một chữ số và một ký tự đặc biệt.", "Lỗi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtNewPassword.Focus();
                 return false;
            }
            */

            return true;
        }

        // SHA-256 hashing helper (tương tự như trong Form Login)
        private static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // =========================================================================
        // PHƯƠNG THỨC GIAO DIỆN KHÁC
        // =========================================================================

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng Form đăng ký để trở về Form Login
        }

        // Giữ lại các phương thức sự kiện rỗng khác nếu cần thiết cho Designer
        private void label1_Click(object sender, EventArgs e) { }
        private void txtNewUsername_TextChanged(object sender, EventArgs e) { }
        private void txtNewPassword_TextChanged(object sender, EventArgs e) { }
        private void txtConfirmPassword_TextChanged(object sender, EventArgs e) { }
    }
}