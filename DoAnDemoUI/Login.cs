using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnDemoUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Vui lòng nhập tên đăng nhập.NV1");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Vui lòng nhập mật khẩu.123");
                txtPassword.Focus();
                return;
            }

            // Demo authentication:
            // - admin / 1234
            // - NV1 / 123  (requested account)
            var user = txtUsername.Text.Trim();
            var pass = txtPassword.Text;

            if ((user == "admin" && pass == "1234") || (user == "NV1" && pass == "123"))
            {
                // Open QuanLiThuVien as a child (owned) form and hide the login form.
                var mainForm = new QuanLiThuVien
                {
                    Owner = this
                };

                // When the child form closes, show the login form again
                mainForm.FormClosed += (s, args) =>
                {
                    // Clear sensitive fields
                    txtPassword.Text = string.Empty;
                    // Show login again
                    this.Show();
                };

                // Hide login and show child (non-modal) so Program.Main keeps running with the login instance as the main message pump
                this.Hide();
                mainForm.Show();

                return;
            }

            errorProvider1.SetError(txtUsername, "Tên đăng nhập hoặc mật khẩu không đúng.");
            errorProvider1.SetError(txtPassword, "Tên đăng nhập hoặc mật khẩu không đúng.");
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
