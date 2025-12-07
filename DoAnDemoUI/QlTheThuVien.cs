using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAnDemoUI // Đã sửa theo tên Project của bạn
{
    public partial class QlTheThuVien : Form // Đã sửa tên Class theo file của bạn
    {
        // 1. CHUỖI KẾT NỐI (Lưu ý: Sửa lại tên Server máy bạn nếu cần)
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLThuVIen;Integrated Security=True";

        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        BindingSource bindingSource;
        SqlCommandBuilder cmdBuilder;

        public QlTheThuVien()
        {
            InitializeComponent();
        }

        private void TheThuVien_Load(object sender, EventArgs e)
        {
            LoadData();
            // Gán sự kiện cho DateTimePicker khi thay đổi giá trị
            dtpNgayBatDau.ValueChanged += DtpNgayBatDau_ValueChanged;
        }

        private void LoadData()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                string sql = "SELECT * FROM THETHUVIEN";
                da = new SqlDataAdapter(sql, conn);
                cmdBuilder = new SqlCommandBuilder(da); // Tự sinh lệnh Insert/Update/Delete

                dt = new DataTable();
                da.Fill(dt);

                bindingSource = new BindingSource();
                bindingSource.DataSource = dt;
                dgvDanhSach.DataSource = bindingSource;

                // Binding dữ liệu
                BindControl(txtSoThe, "Text", "SOTHE");
                BindControl(txtTenSV, "Text", "TENSV");
                BindControl(cbGioiTinh, "Text", "GIOITINH");
                BindControl(txtDiaChi, "Text", "DIACHI");
                BindControl(txtDienThoai, "Text", "DIENTHOAI");
                BindControl(txtGhiChu, "Text", "GHICHU");
                BindControl(dtpNgaySinh, "Value", "NGAYSINH");
                BindControl(dtpNgayBatDau, "Value", "NGAYBATDAU");
                BindControl(dtpNgayKetThuc, "Value", "NGAYKETTHUC");

                UpdateStatusLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void BindControl(Control control, string propertyName, string dataMember)
        {
            control.DataBindings.Clear();
            control.DataBindings.Add(propertyName, bindingSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void UpdateStatusLabel()
        {
            if (bindingSource != null)
                lblTongSo.Text = $"Tổng số: {bindingSource.Count} | Vị trí: {bindingSource.Position + 1}";
        }

        // --- SỰ KIỆN LOGIC NGÀY THÁNG ---
        private void DtpNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            // Tự động cộng 6 tháng vào ngày kết thúc
            dtpNgayKetThuc.Value = dtpNgayBatDau.Value.AddMonths(6);
        }

        // --- CÁC SỰ KIỆN BUTTON ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            bindingSource.AddNew();
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now.AddMonths(6);
            cbGioiTinh.SelectedIndex = 0;
            txtTenSV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy sửa trực tiếp trên ô nhập và nhấn LƯU.", "Hướng dẫn");
            txtTenSV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bindingSource.RemoveCurrent();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource.EndEdit();
                da.Update(dt);
                MessageBox.Show("Đã lưu thành công!");
                dt.Clear(); // Reload để lấy ID mới
                da.Fill(dt);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang in thẻ cho: " + txtTenSV.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
                bindingSource.RemoveFilter();
            else
                bindingSource.Filter = $"TENSV LIKE '%{tuKhoa}%' OR DIENTHOAI LIKE '%{tuKhoa}%'";
            UpdateStatusLabel();
        }

        // --- ĐIỀU HƯỚNG ---
        private void btnDau_Click(object sender, EventArgs e) { bindingSource.MoveFirst(); UpdateStatusLabel(); }
        private void btnTruoc_Click(object sender, EventArgs e) { bindingSource.MovePrevious(); UpdateStatusLabel(); }
        private void btnSau_Click(object sender, EventArgs e) { bindingSource.MoveNext(); UpdateStatusLabel(); }
        private void btnCuoi_Click(object sender, EventArgs e) { bindingSource.MoveLast(); UpdateStatusLabel(); }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e) { UpdateStatusLabel(); }
    }
}