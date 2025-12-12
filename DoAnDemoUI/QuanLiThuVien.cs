using DoAnDemoUI; 
using QuanLyBanHang;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DoAnDemoUI
{

    public partial class QuanLiThuVien : Form
    {
        private readonly List<MenuAction> _menuActions = new List<MenuAction>();

        public QuanLiThuVien()
        {
            InitializeComponent();

            // <--- 2. THÊM DÒNG NÀY: Đặt form này làm Form Cha (Container)
            this.IsMdiContainer = true;

            // configure listbox
            lstMenu.DisplayMember = nameof(MenuAction.DisplayName);
            lstMenu.ValueMember = nameof(MenuAction.Key);

            lstMenu.DoubleClick += lstMenu_DoubleClick;
            lstMenu.KeyDown += lstMenu_KeyDown;

            SetupDefaultMenuActions();
            RefreshMenuList();
        }

        private void SetupDefaultMenuActions()
        {
            _menuActions.Clear();

            // Các menu 
            AddMenuAction("QuanLySach", "Quản lý sách", () => OpenOrActivateChild(typeof(QuanLiSach)));
            AddMenuAction("QlNhaXuatBan", "Nhà xuất bản", () => OpenOrActivateChild(typeof(QlNhaXuatBan)));
            AddMenuAction("QuanLyDonHang", "Quản lý đơn hàng", () => OpenOrActivateChild(typeof(QuanLyDonHang)));
            AddMenuAction("QuanLyMuonSach", "Quản lý Mượn Sách", () => OpenOrActivateChild(typeof(QLMuonSach)));
            AddMenuAction("TheThuVien", "Quản lý Thẻ Thư Viện", () => OpenOrActivateChild(typeof(QlTheThuVien)));
           // AddMenuAction("QuanLyNhanVien", "Quản lý Nhân Viên", () => OpenOrActivateChild(typeof(QuanLyNhanVien)));

        }


        public void AddMenuAction(string key, string displayName, Action action)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (_menuActions.Any(a => string.Equals(a.Key, key, StringComparison.OrdinalIgnoreCase))) return;

            _menuActions.Add(new MenuAction { Key = key, DisplayName = displayName ?? key, Action = action });
            RefreshMenuList();
        }

        public bool RemoveMenuAction(string key)
        {
            var item = _menuActions.FirstOrDefault(a => string.Equals(a.Key, key, StringComparison.OrdinalIgnoreCase));
            if (item == null) return false;
            _menuActions.Remove(item);
            RefreshMenuList();
            return true;
        }

        private void RefreshMenuList()
        {
            var selectedKey = (lstMenu.SelectedItem as MenuAction)?.Key;
            lstMenu.DataSource = null;
            lstMenu.DataSource = _menuActions.ToList(); 
            lstMenu.DisplayMember = nameof(MenuAction.DisplayName);
            lstMenu.ValueMember = nameof(MenuAction.Key);

            if (!string.IsNullOrEmpty(selectedKey))
            {
                var toSelect = _menuActions.FirstOrDefault(a => string.Equals(a.Key, selectedKey, StringComparison.OrdinalIgnoreCase));
                if (toSelect != null) lstMenu.SelectedItem = toSelect;
            }
        }

        private void ExecuteSelectedAction()
        {
            var sel = lstMenu.SelectedItem as MenuAction;
            if (sel == null) return;

            try
            {
                sel.Action?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi '{sel.DisplayName}': {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstMenu_DoubleClick(object sender, EventArgs e)
        {
            ExecuteSelectedAction();
        }

        private void lstMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteSelectedAction();
                e.Handled = true;
            }
        }

        private void OpenOrActivateChild(Type childType)
        {
            // 1. Kiểm tra xem form 
            foreach (var child in this.MdiChildren)
            {
                if (child.GetType() == childType)
                {
                    child.BringToFront();
                    if (child.WindowState == FormWindowState.Minimized)
                        child.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            // 2. Khởi tạo Form 
            Form frm = null;

            if (childType == typeof(QuanLiSach))
                frm = new QuanLiSach();
            else if (childType == typeof(QlNhaXuatBan))
                frm = new QlNhaXuatBan();
            else if (childType == typeof(QuanLyDonHang))
                frm = new QuanLyDonHang();
            else if (childType == typeof(QLMuonSach))
                frm = new QLMuonSach();
            else if (childType == typeof(QuanLyNhanVien))
                frm = new QuanLyNhanVien();

            // <--- THÊM ĐOẠN IF
            else if (childType == typeof(QlTheThuVien))
            {
                frm = new QlTheThuVien();
            }

            // 3. Hiển thị Form (QUAN TRỌNG NHẤT)
            if (frm != null)
            {
                // <--- BẮT BUỘC PHẢI CÓ DÒNG NÀY ĐỂ LÀM FORM CON
                frm.MdiParent = this;

                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

  
        private void mniDangXuat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng xuất thành công!", "Đăng xuất", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void mniThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // small container for menu actions
        private class MenuAction
        {
            public string Key { get; set; }
            public string DisplayName { get; set; }
            public Action Action { get; set; }

            public override string ToString() => DisplayName;
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e) { }

        private void QuanLiThuVien_Load(object sender, EventArgs e) { }

        private void QuanLiThuVien_Load_1(object sender, EventArgs e)
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

        private void mnuHeThong_Click(object sender, EventArgs e)
        {

        }
    }
}