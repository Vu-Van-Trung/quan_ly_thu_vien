using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang // ĐÃ SỬA: Phải khớp với namespace bên Designer
{
    public partial class QuanLyDonHang : Form
    {
        // Cấu hình chuỗi kết nối (Lưu ý: Bạn nhớ sửa lại Server Name cho đúng máy bạn)
        string connectionString = @"Data Source=.;Initial Catalog=QuanLyBanHangDB;Integrated Security=True";

        // DataTable lưu tạm danh sách chi tiết
        DataTable dtChiTiet;

        public QuanLyDonHang()
        {
            InitializeComponent();
            KhoiTaoLuoiDuLieu();
        }

        private void KhoiTaoLuoiDuLieu()
        {
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("TenSanPham", typeof(string));
            dtChiTiet.Columns.Add("SoLuong", typeof(int));
            dtChiTiet.Columns.Add("DonGia", typeof(decimal));
            dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTiet.DataSource = dtChiTiet;

            // Định dạng tiền tệ
            if (dgvChiTiet.Columns["DonGia"] != null)
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";

            if (dgvChiTiet.Columns["ThanhTien"] != null)
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        // --- NÚT THÊM ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!");
                return;
            }

            string tenSP = txtTenSP.Text;
            int soLuong = (int)numSoLuong.Value;
            decimal donGia = numDonGia.Value;
            decimal thanhTien = soLuong * donGia;

            dtChiTiet.Rows.Add(tenSP, soLuong, donGia, thanhTien);
            CapNhatTongTien();

            // Reset vùng nhập
            txtTenSP.Clear();
            numSoLuong.Value = 1;
            txtTenSP.Focus();
        }

        // --- NÚT XÓA (Mới bổ sung) ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count > 0)
            {
                // Xóa dòng đang chọn khỏi DataTable
                foreach (DataGridViewRow row in dgvChiTiet.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dtChiTiet.Rows.RemoveAt(row.Index);
                    }
                }
                CapNhatTongTien();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }
        }

        // --- NÚT HỦY (Mới bổ sung) ---
        private void btnHuy_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        // --- NÚT TÌM KIẾM (Mới bổ sung logic cơ bản) ---
        private void btnTim_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng tìm kiếm đơn hàng đang phát triển!");
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (DataRow row in dtChiTiet.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }
            lblTongTien.Text = tongTien.ToString("N0");
        }

        // --- NÚT LƯU (TRANSACTION) ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDon.Text) || dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập Mã đơn và thêm ít nhất 1 sản phẩm!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Lưu Master
                    string sqlDonHang = "INSERT INTO DONHANG (MaDon, TenKhachHang, NgayDat, TongTien) VALUES (@Ma, @Ten, @Ngay, @Tong)";
                    SqlCommand cmdMaster = new SqlCommand(sqlDonHang, conn, transaction);
                    cmdMaster.Parameters.AddWithValue("@Ma", txtMaDon.Text);
                    cmdMaster.Parameters.AddWithValue("@Ten", txtTenKhach.Text);
                    cmdMaster.Parameters.AddWithValue("@Ngay", dtpNgayDat.Value);

                    // Xử lý chuỗi tiền tệ (bỏ dấu phẩy/chấm động nếu có để parse về decimal)
                    decimal tongTienFinal = 0;
                    decimal.TryParse(lblTongTien.Text.Replace(",", "").Replace(".", ""), out tongTienFinal);
                    cmdMaster.Parameters.AddWithValue("@Tong", tongTienFinal);

                    cmdMaster.ExecuteNonQuery();

                    // 2. Lưu Detail
                    string sqlChiTiet = "INSERT INTO CHITIETDONHANG (MaDon, TenSanPham, SoLuong, DonGia, ThanhTien) VALUES (@MaDon, @TenSP, @SL, @Gia, @ThanhTien)";
                    foreach (DataRow row in dtChiTiet.Rows)
                    {
                        SqlCommand cmdDetail = new SqlCommand(sqlChiTiet, conn, transaction);
                        cmdDetail.Parameters.AddWithValue("@MaDon", txtMaDon.Text);
                        cmdDetail.Parameters.AddWithValue("@TenSP", row["TenSanPham"]);
                        cmdDetail.Parameters.AddWithValue("@SL", row["SoLuong"]);
                        cmdDetail.Parameters.AddWithValue("@Gia", row["DonGia"]);
                        cmdDetail.Parameters.AddWithValue("@ThanhTien", row["ThanhTien"]);
                        cmdDetail.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Lưu đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiForm();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LamMoiForm()
        {
            txtMaDon.Clear();
            txtTenKhach.Clear();
            txtTenSP.Clear();
            numSoLuong.Value = 1;
            numDonGia.Value = 0;
            dtChiTiet.Rows.Clear();
            lblTongTien.Text = "0";
            txtMaDon.Focus();
        }

        private void QuanLyDonHang_Load(object sender, EventArgs e)
        {

        }
    }
}