using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DoAnDemoUI.Data;  // Namespace chứa Context
using DoAnDemoUI.Model; // Namespace chứa Entity

namespace DoAnDemoUI
{
    public partial class QLMuonSach : Form
    {
        // 1. Khai báo biến toàn cục
        ThuVienContext db;
        BindingSource bindingSource;

        public QLMuonSach()
        {
            InitializeComponent();

            // Khởi tạo BindingSource
            bindingSource = new BindingSource();
        }

        // 2. ĐÂY LÀ HÀM BẠN ĐANG THIẾU (Nguyên nhân gây lỗi)
        private void QLMuonSach_Load(object sender, EventArgs e)
        {
            db = new ThuVienContext(); // Khởi tạo DB Context
            LoadData();                // Gọi hàm tải dữ liệu

            // Gắn bindingSource vào DataGridView
            dgvSachMuon.DataSource = bindingSource;

            // Gắn sự kiện thay đổi dòng chọn để cập nhật số thứ tự
            dgvSachMuon.SelectionChanged += (s, ev) => UpdateIndex();
        }

        // 3. Hàm tải dữ liệu
        private void LoadData()
        {
            try
            {
                // Load dữ liệu từ bảng Chi Tiết Phiếu Mượn (CTPhieuMuon)
                // Select ẩn danh để lấy các trường cần thiết hiển thị lên lưới
                var data = db.CTPhieuMuons.Select(ct => new
                {
                    ct.Id,
                    MaPhieu = ct.MaPhieuMuon,
                    TenSach = ct.Sach.TenSach, // Lấy tên sách từ bảng Sach
                    ct.TrangThai,
                    ct.NgayTraDK
                }).ToList();

                bindingSource.DataSource = data;

                // Load ComboBox Mã Sách
                cbMaSach.DataSource = db.Sachs.ToList();
                cbMaSach.DisplayMember = "TenSach"; // Hiển thị tên
                cbMaSach.ValueMember = "MaSach";    // Giá trị là mã

                // Load ComboBox Mã Phiếu Mượn
                cbMaPM.DataSource = db.PhieuMuons.ToList();
                cbMaPM.DisplayMember = "MaPhieuMuon";
                cbMaPM.ValueMember = "MaPhieuMuon";

                // Binding dữ liệu vào các ô TextBox (Optional)
                BindControls();

                UpdateIndex();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void BindControls()
        {
            // Xóa binding cũ
            txtTinhTrang.DataBindings.Clear();
            dtpNgayTra.DataBindings.Clear();

            // Binding đơn giản (Lưu ý: Binding vào object ẩn danh ở trên có thể hạn chế chức năng sửa, 
            // tốt nhất là binding vào List<CTPhieuMuon> gốc nếu muốn sửa trực tiếp)
            txtTinhTrang.DataBindings.Add("Text", bindingSource, "TrangThai", true, DataSourceUpdateMode.Never);
            dtpNgayTra.DataBindings.Add("Value", bindingSource, "NgayTraDK", true, DataSourceUpdateMode.Never);
        }

        private void UpdateIndex()
        {
            if (bindingSource != null)
                txtIndex.Text = $"{bindingSource.Position + 1} / {bindingSource.Count}";
        }

        // --- CÁC NÚT ĐIỀU HƯỚNG ---
        // Bạn cần vào Designer, click đúp vào các nút này để nó tự sinh ra sự kiện nối với các hàm dưới đây
        // Hoặc copy tên hàm này vào phần Events trong Properties của nút bấm.

        private void btnDau_Click(object sender, EventArgs e) { bindingSource.MoveFirst(); UpdateIndex(); }
        private void btnTruoc_Click(object sender, EventArgs e) { bindingSource.MovePrevious(); UpdateIndex(); }
        private void btnSau_Click(object sender, EventArgs e) { bindingSource.MoveNext(); UpdateIndex(); }
        private void btnCuoi_Click(object sender, EventArgs e) { bindingSource.MoveLast(); UpdateIndex(); }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- CÁC NÚT CHỨC NĂNG (DEMO) ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Code thêm mới...
            MessageBox.Show("Chức năng thêm đang phát triển");
        }

        // Cần đảm bảo bạn đã Double Click vào nút Thêm, Sửa, Xóa bên Designer 
        // để tạo hàm xử lý sự kiện tương ứng, nếu không sẽ không bấm được.
    }
}