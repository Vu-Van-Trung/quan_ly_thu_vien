namespace DoAnDemoUI
{
    partial class QlTheThuVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenSV = new System.Windows.Forms.TextBox();
            this.txtSoThe = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.gbXuLy = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panelDieuKhien = new System.Windows.Forms.Panel();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.btnCuoi = new System.Windows.Forms.Button();
            this.btnSau = new System.Windows.Forms.Button();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.btnDau = new System.Windows.Forms.Button();
            this.gbThongTin.SuspendLayout();
            this.gbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.gbXuLy.SuspendLayout();
            this.panelDieuKhien.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(300, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(359, 31);
            this.lblTitle.Text = "DANH MỤC THẺ THƯ VIỆN";

            // gbThongTin
            this.gbThongTin.Controls.Add(this.cbGioiTinh);
            this.gbThongTin.Controls.Add(this.dtpNgayKetThuc);
            this.gbThongTin.Controls.Add(this.dtpNgayBatDau);
            this.gbThongTin.Controls.Add(this.dtpNgaySinh);
            this.gbThongTin.Controls.Add(this.txtGhiChu);
            this.gbThongTin.Controls.Add(this.txtDienThoai);
            this.gbThongTin.Controls.Add(this.txtDiaChi);
            this.gbThongTin.Controls.Add(this.txtTenSV);
            this.gbThongTin.Controls.Add(this.txtSoThe);
            this.gbThongTin.Controls.Add(this.label9);
            this.gbThongTin.Controls.Add(this.label8);
            this.gbThongTin.Controls.Add(this.label7);
            this.gbThongTin.Controls.Add(this.label6);
            this.gbThongTin.Controls.Add(this.label5);
            this.gbThongTin.Controls.Add(this.label4);
            this.gbThongTin.Controls.Add(this.label3);
            this.gbThongTin.Controls.Add(this.label2);
            this.gbThongTin.Controls.Add(this.label1);
            this.gbThongTin.Location = new System.Drawing.Point(12, 53);
            this.gbThongTin.Size = new System.Drawing.Size(960, 160);
            this.gbThongTin.Text = "Thông Tin Sinh Viên";

            // Các Control nhập liệu
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            this.cbGioiTinh.Location = new System.Drawing.Point(293, 29);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(100, 21);

            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(520, 114);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(120, 20);

            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(520, 72);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(120, 20);

            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(520, 29);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(120, 20);

            this.txtGhiChu.Location = new System.Drawing.Point(730, 72);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Size = new System.Drawing.Size(213, 62);
            this.txtGhiChu.Name = "txtGhiChu";

            this.txtDienThoai.Location = new System.Drawing.Point(85, 114);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(148, 20);

            this.txtDiaChi.Location = new System.Drawing.Point(730, 29);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(213, 20);

            this.txtTenSV.Location = new System.Drawing.Point(85, 72);
            this.txtTenSV.Name = "txtTenSV";
            this.txtTenSV.Size = new System.Drawing.Size(200, 20);

            this.txtSoThe.Location = new System.Drawing.Point(85, 29);
            this.txtSoThe.Name = "txtSoThe";
            this.txtSoThe.ReadOnly = true;
            this.txtSoThe.Size = new System.Drawing.Size(100, 20);

            // Labels
            this.label1.Text = "Mã thẻ:"; this.label1.Location = new System.Drawing.Point(20, 32);
            this.label2.Text = "Tên SV:"; this.label2.Location = new System.Drawing.Point(20, 75);
            this.label3.Text = "Giới tính:"; this.label3.Location = new System.Drawing.Point(230, 32);
            this.label4.Text = "Điện thoại:"; this.label4.Location = new System.Drawing.Point(20, 117);
            this.label5.Text = "Ngày sinh:"; this.label5.Location = new System.Drawing.Point(430, 32);
            this.label6.Text = "Ngày tạo:"; this.label6.Location = new System.Drawing.Point(430, 75);
            this.label7.Text = "Ngày hết hạn:"; this.label7.Location = new System.Drawing.Point(430, 117);
            this.label8.Text = "Địa chỉ:"; this.label8.Location = new System.Drawing.Point(670, 32);
            this.label9.Text = "Ghi chú:"; this.label9.Location = new System.Drawing.Point(670, 75);

            // gbDanhSach & DataGridView
            this.gbDanhSach.Controls.Add(this.dgvDanhSach);
            this.gbDanhSach.Location = new System.Drawing.Point(12, 219);
            this.gbDanhSach.Size = new System.Drawing.Size(731, 258);
            this.gbDanhSach.Text = "Bảng Thông Tin Thẻ Thư Viện";

            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.Name = "dgvDanhSach";

            // gbXuLy & Buttons
            this.gbXuLy.Controls.Add(this.btnThoat);
            this.gbXuLy.Controls.Add(this.btnXoa);
            this.gbXuLy.Controls.Add(this.btnSua);
            this.gbXuLy.Controls.Add(this.btnLuu);
            this.gbXuLy.Controls.Add(this.btnIn);
            this.gbXuLy.Controls.Add(this.btnThem);
            this.gbXuLy.Controls.Add(this.btnTimKiem);
            this.gbXuLy.Controls.Add(this.txtTimKiem);
            this.gbXuLy.Location = new System.Drawing.Point(749, 219);
            this.gbXuLy.Size = new System.Drawing.Size(223, 299);
            this.gbXuLy.Text = "Xử Lý";

            this.btnThem.Text = "Thêm"; this.btnThem.Location = new System.Drawing.Point(14, 30); this.btnThem.Size = new System.Drawing.Size(90, 40);
            this.btnIn.Text = "In"; this.btnIn.Location = new System.Drawing.Point(120, 30); this.btnIn.Size = new System.Drawing.Size(90, 40);
            this.btnLuu.Text = "Lưu"; this.btnLuu.Location = new System.Drawing.Point(14, 90); this.btnLuu.Size = new System.Drawing.Size(90, 40);
            this.btnSua.Text = "Sửa"; this.btnSua.Location = new System.Drawing.Point(120, 90); this.btnSua.Size = new System.Drawing.Size(90, 40);
            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new System.Drawing.Point(14, 150); this.btnXoa.Size = new System.Drawing.Size(90, 40);
            this.btnThoat.Text = "Thoát"; this.btnThoat.Location = new System.Drawing.Point(120, 150); this.btnThoat.Size = new System.Drawing.Size(90, 40);

            this.txtTimKiem.Location = new System.Drawing.Point(14, 257); this.txtTimKiem.Size = new System.Drawing.Size(115, 20); this.txtTimKiem.Name = "txtTimKiem";
            this.btnTimKiem.Text = "Tìm Kiếm"; this.btnTimKiem.Location = new System.Drawing.Point(135, 252); this.btnTimKiem.Name = "btnTimKiem";

            // Panel Dieu Khien
            this.panelDieuKhien.Controls.Add(this.lblTongSo);
            this.panelDieuKhien.Controls.Add(this.btnCuoi);
            this.panelDieuKhien.Controls.Add(this.btnSau);
            this.panelDieuKhien.Controls.Add(this.btnTruoc);
            this.panelDieuKhien.Controls.Add(this.btnDau);
            this.panelDieuKhien.Location = new System.Drawing.Point(12, 483);
            this.panelDieuKhien.Size = new System.Drawing.Size(731, 35);

            this.lblTongSo.AutoSize = true; this.lblTongSo.ForeColor = System.Drawing.Color.Red;
            this.lblTongSo.Location = new System.Drawing.Point(10, 10); this.lblTongSo.Name = "lblTongSo"; this.lblTongSo.Text = "Tổng: ";

            this.btnDau.Text = "|<<"; this.btnDau.Location = new System.Drawing.Point(293, 6); this.btnDau.Name = "btnDau";
            this.btnTruoc.Text = "<<"; this.btnTruoc.Location = new System.Drawing.Point(403, 6); this.btnTruoc.Name = "btnTruoc";
            this.btnSau.Text = ">>"; this.btnSau.Location = new System.Drawing.Point(513, 6); this.btnSau.Name = "btnSau";
            this.btnCuoi.Text = ">>|"; this.btnCuoi.Location = new System.Drawing.Point(623, 6); this.btnCuoi.Name = "btnCuoi";

            // Main Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 531);
            this.Controls.Add(this.panelDieuKhien);
            this.Controls.Add(this.gbXuLy);
            this.Controls.Add(this.gbDanhSach);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.lblTitle);
            this.Name = "TheThuVien"; // Quan trọng: Khớp tên Class
            this.Text = "Quản Lý Thẻ Thư Viện";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TheThuVien_Load);

            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.gbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.gbXuLy.ResumeLayout(false);
            this.gbXuLy.PerformLayout();
            this.panelDieuKhien.ResumeLayout(false);
            this.panelDieuKhien.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            // GẮN SỰ KIỆN (Quan trọng để nút bấm hoạt động)
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            this.btnDau.Click += new System.EventHandler(this.btnDau_Click);
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            this.btnSau.Click += new System.EventHandler(this.btnSau_Click);
            this.btnCuoi.Click += new System.EventHandler(this.btnCuoi_Click);
            this.dgvDanhSach.SelectionChanged += new System.EventHandler(this.dgvDanhSach_SelectionChanged);
        }

        #endregion

        // Khai báo các Control
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6, label7, label8, label9;
        private System.Windows.Forms.TextBox txtSoThe, txtTenSV, txtDienThoai, txtGhiChu, txtDiaChi;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh, dtpNgayKetThuc, dtpNgayBatDau;
        private System.Windows.Forms.GroupBox gbDanhSach;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.GroupBox gbXuLy;
        private System.Windows.Forms.Button btnThem, btnIn, btnThoat, btnXoa, btnSua, btnLuu;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel panelDieuKhien;
        private System.Windows.Forms.Button btnCuoi, btnSau, btnTruoc, btnDau;
        private System.Windows.Forms.Label lblTongSo;
    }
}