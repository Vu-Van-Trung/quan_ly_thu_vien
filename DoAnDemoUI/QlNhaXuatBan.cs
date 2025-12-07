using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace DoAnDemoUI
{
    public partial class QlNhaXuatBan : Form
    {
        private BindingList<Publisher> _publishers;
        private Publisher _editingPublisher; // tracks current record being edited

        public QlNhaXuatBan()
        {
            InitializeComponent();
            WireEvents();
            InitializeLogic();
        }

        private void WireEvents()
        {
            this.Load += NhaXuatBan_Load;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;     // wire new Save button
            btnClear.Click += BtnClear_Click;
            btnSearch.Click += BtnSearch_Click;
            dgvNXB.CellClick += DgvNXB_CellClick;
            // update STT when rows change (for example when user sorts)
            dgvNXB.DataBindingComplete += (s, e) => UpdateSTT();
        }

        private void NhaXuatBan_Load(object sender, EventArgs e)
        {
            // UI initialized
        }

        private void InitializeLogic()
        {
            // sample in-memory data for UI/testing (no ADO.NET)
            _publishers = new BindingList<Publisher>
            {
                new Publisher { MaNXB = "NXB01", TenNXB = "Nhà xuất bản A", DiaChi = "123 Đường A", Email = "contact@nxba.vn", ThongTin = "Nguyễn Văn A" },
                new Publisher { MaNXB = "NXB02", TenNXB = "Nhà xuất bản B", DiaChi = "456 Đường B", Email = "info@nxbB.vn", ThongTin = "Trần Thị B" }
            };

            dgvNXB.DataSource = _publishers;
            UpdateSTT();
            SetButtonsState(defaultEnabled: true);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var id = txtMaNXB.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("MANHAXUATBAN không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNXB.Focus();
                return;
            }

            if (_publishers.Any(p => string.Equals(p.MaNXB, id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã nhà xuất bản đã tồn tại (in-memory).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNXB.Focus();
                return;
            }

            var pub = new Publisher
            {
                MaNXB = id,
                TenNXB = txtTenNXB.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                ThongTin = txtThongTinDD.Text.Trim()
            };

            _publishers.Add(pub);
            ClearInputs();

            // refresh STT
            UpdateSTT();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNXB.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhà xuất bản để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _editingPublisher = dgvNXB.CurrentRow.DataBoundItem as Publisher;
            if (_editingPublisher == null) return;

            // prepare UI for editing: lock primary key, enable Save
            txtMaNXB.Enabled = false;
            txtTenNXB.Focus();
            btnSave.Enabled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_editingPublisher == null)
            {
                MessageBox.Show("Không có bản ghi đang sửa để lưu. Vui lòng chọn một bản ghi và nhấn Sửa trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // apply changes from UI into the editing publisher
            _editingPublisher.TenNXB = txtTenNXB.Text.Trim();
            _editingPublisher.DiaChi = txtDiaChi.Text.Trim();
            _editingPublisher.Email = txtEmail.Text.Trim();
            _editingPublisher.ThongTin = txtThongTinDD.Text.Trim();

            // refresh grid and clear editing state
            dgvNXB.Refresh();
            _editingPublisher = null;
            txtMaNXB.Enabled = true;
            btnSave.Enabled = false;
            ClearInputs();
            UpdateSTT();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNXB.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhà xuất bản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var pub = dgvNXB.CurrentRow.DataBoundItem as Publisher;
            if (pub == null) return;

            if (MessageBox.Show($"Xóa nhà xuất bản '{pub.TenNXB}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _publishers.Remove(pub);
                ClearInputs();

                // refresh STT
                UpdateSTT();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            // cancel any ongoing edit
            _editingPublisher = null;
            btnSave.Enabled = false;
            txtMaNXB.Enabled = true;
            ClearInputs();
        }

        private void DgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvNXB.Rows[e.RowIndex];
            var pub = row.DataBoundItem as Publisher;
            if (pub == null) return;

            txtMaNXB.Text = pub.MaNXB;
            txtTenNXB.Text = pub.TenNXB;
            txtDiaChi.Text = pub.DiaChi;
            txtEmail.Text = pub.Email;
            txtThongTinDD.Text = pub.ThongTin;
            txtMaNXB.Enabled = true; // default: primary key editable until Edit pressed
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var key = txtSearch.Text?.Trim();
            if (string.IsNullOrWhiteSpace(key))
            {
                dgvNXB.DataSource = _publishers;
                UpdateSTT();
                return;
            }

            var filtered = _publishers.Where(p => (!string.IsNullOrWhiteSpace(p.TenNXB) && p.TenNXB.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0)
                                              || (!string.IsNullOrWhiteSpace(p.MaNXB) && p.MaNXB.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0))
                                      .ToList();

            dgvNXB.DataSource = new BindingList<Publisher>(filtered);
            UpdateSTT();
        }

        private void ClearInputs()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtThongTinDD.Text = "";
            txtMaNXB.Enabled = true;
            dgvNXB.ClearSelection();
        }

        private void SetButtonsState(bool defaultEnabled)
        {
            btnAdd.Enabled = defaultEnabled;
            btnEdit.Enabled = defaultEnabled;
            btnDelete.Enabled = defaultEnabled;
            btnClear.Enabled = defaultEnabled;
            btnSearch.Enabled = defaultEnabled;
            // Save disabled by default; only enabled while editing
            btnSave.Enabled = false;
        }

        // populate STT column values (1..n)
        private void UpdateSTT()
        {
            if (dgvNXB.Columns["colSTT"] == null) return;

            for (int i = 0; i < dgvNXB.Rows.Count; i++)
            {
                var row = dgvNXB.Rows[i];
                // when last row is the new-row placeholder, skip it
                if (row.IsNewRow) continue;

                row.Cells["colSTT"].Value = (i + 1).ToString();
            }
        }

        // Simple in-memory model for UI testing
        private class Publisher
        {
            public string MaNXB { get; set; }
            public string TenNXB { get; set; }
            public string DiaChi { get; set; }
            public string Email { get; set; }
            public string ThongTin { get; set; }
        }
    }
}