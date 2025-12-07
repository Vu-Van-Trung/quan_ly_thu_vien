using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace DoAnDemoUI
{
    public partial class QuanLiSach : Form
    {
        private BindingList<Book> _books;
        private bool _isEditing;
        private Book _editingBook;

        public QuanLiSach()
        {
            InitializeComponent();
            InitializeLogic();
        }

        private void InitializeLogic()
        {
            // sample data (include Gia and SoLuong)
            _books = new BindingList<Book>
            {
                new Book { MaSach = "S001", TenSach = "Lập trình C#", MaTacGia = "TG01", MaTheLoai = "TL01", MaNXB = "NXB01", NamSX = 2020, Gia = 150000m, SoLuong = 10 },
                new Book { MaSach = "S002", TenSach = "Thiết kế CSDL", MaTacGia = "TG02", MaTheLoai = "TL02", MaNXB = "NXB02", NamSX = 2018, Gia = 120000m, SoLuong = 5 }
            };

            bindingSourceBooks.DataSource = _books;

            // wire events
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnSearch.Click += BtnSearch_Click;
            dgvBooks.SelectionChanged += DgvBooks_SelectionChanged;
            dgvBooks.DoubleClick += DgvBooks_DoubleClick;

            SetEditingState(false);
        }

        private void DgvBooks_DoubleClick(object sender, EventArgs e)
        {
            LoadSelectedToFields();
            SetEditingState(false);
        }

        private void DgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            // update fields when selection changes (non-edit mode)
            if (!_isEditing)
            {
                LoadSelectedToFields();
            }
        }

        private void LoadSelectedToFields()
        {
            if (dgvBooks.CurrentRow == null) return;
            var book = dgvBooks.CurrentRow.DataBoundItem as Book;
            if (book == null) return;

            txtMaSach.Text = book.MaSach;
            txtTenSach.Text = book.TenSach;
            txtMaTacGia.Text = book.MaTacGia;
            txtMaTheLoai.Text = book.MaTheLoai;
            txtMaNXB.Text = book.MaNXB;
            txtNamSX.Text = book.NamSX?.ToString() ?? string.Empty;

            // show new fields
            if (book.Gia.HasValue)
                txtGiaSach.Text = book.Gia.Value.ToString("0.##", CultureInfo.CurrentCulture);
            else
                txtGiaSach.Text = string.Empty;

            txtSoLuong.Text = book.SoLuong?.ToString() ?? string.Empty;

            _editingBook = book;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            _isEditing = false;
            _editingBook = null;
            SetEditingState(true);
            txtMaSach.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sách để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditing = true;
            _editingBook = dgvBooks.CurrentRow.DataBoundItem as Book;
            SetEditingState(true);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var book = dgvBooks.CurrentRow.DataBoundItem as Book;
            if (book == null) return;

            if (MessageBox.Show($"Xóa sách '{book.TenSach}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _books.Remove(book);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // basic validation
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("MASACH không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSach.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                MessageBox.Show("TENSACH không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSach.Focus();
                return;
            }

            int? nam = null;
            if (!string.IsNullOrWhiteSpace(txtNamSX.Text))
            {
                int tmp;
                if (int.TryParse(txtNamSX.Text, out tmp))
                {
                    nam = tmp;
                }
                else
                {
                    MessageBox.Show("Năm SX phải là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNamSX.Focus();
                    return;
                }
            }

            // parse new fields
            decimal? gia = null;
            if (!string.IsNullOrWhiteSpace(txtGiaSach.Text))
            {
                decimal tmpG;
                if (decimal.TryParse(txtGiaSach.Text.Trim(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out tmpG))
                {
                    gia = tmpG;
                }
                else
                {
                    MessageBox.Show("Giá phải là số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaSach.Focus();
                    return;
                }
            }

            int? soLuong = null;
            if (!string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                int tmpS;
                if (int.TryParse(txtSoLuong.Text.Trim(), out tmpS))
                {
                    soLuong = tmpS;
                }
                else
                {
                    MessageBox.Show("Số lượng phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Focus();
                    return;
                }
            }

            if (_isEditing && _editingBook != null)
            {
                // update existing
                _editingBook.MaSach = txtMaSach.Text.Trim();
                _editingBook.TenSach = txtTenSach.Text.Trim();
                _editingBook.MaTacGia = txtMaTacGia.Text.Trim();
                _editingBook.MaTheLoai = txtMaTheLoai.Text.Trim();
                _editingBook.MaNXB = txtMaNXB.Text.Trim();
                _editingBook.NamSX = nam;

                // new fields
                _editingBook.Gia = gia;
                _editingBook.SoLuong = soLuong;

                bindingSourceBooks.ResetBindings(false);
            }
            else
            {
                // ensure no duplicate id
                if (_books.Any(b => string.Equals(b.MaSach, txtMaSach.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("MASACH đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSach.Focus();
                    return;
                }

                var newBook = new Book
                {
                    MaSach = txtMaSach.Text.Trim(),
                    TenSach = txtTenSach.Text.Trim(),
                    MaTacGia = txtMaTacGia.Text.Trim(),
                    MaTheLoai = txtMaTheLoai.Text.Trim(),
                    MaNXB = txtMaNXB.Text.Trim(),
                    NamSX = nam,
                    // new fields
                    Gia = gia,
                    SoLuong = soLuong
                };

                _books.Add(newBook);
            }

            SetEditingState(false);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            SetEditingState(false);
            if (_editingBook != null)
            {
                // reload from current book
                LoadSelectedToFields();
            }
            else
            {
                ClearInputFields();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text?.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                bindingSourceBooks.DataSource = _books;
            }
            else
            {
                var filtered = _books.Where(b => (!string.IsNullOrWhiteSpace(b.TenSach) && b.TenSach.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                                              || (!string.IsNullOrWhiteSpace(b.MaSach) && b.MaSach.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
                                     .ToList();
                bindingSourceBooks.DataSource = new BindingList<Book>(filtered);
            }
            bindingSourceBooks.ResetBindings(false);
        }

        private void SetEditingState(bool editing)
        {
            _isEditing = editing;
            txtMaSach.Enabled = editing;
            txtTenSach.Enabled = editing;
            txtMaTacGia.Enabled = editing;
            txtMaTheLoai.Enabled = editing;
            txtMaNXB.Enabled = editing;
            txtNamSX.Enabled = editing;

            // enable new fields while editing
            txtGiaSach.Enabled = editing;
            txtSoLuong.Enabled = editing;

            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;

            btnAdd.Enabled = !editing;
            btnEdit.Enabled = !editing;
            btnDelete.Enabled = !editing;
            btnSearch.Enabled = !editing;
            txtSearch.Enabled = !editing;

            if (!editing)
            {
                // when not editing, ensure binding shows full list again
                bindingSourceBooks.DataSource = _books;
                bindingSourceBooks.ResetBindings(false);
            }
        }

        private void ClearInputFields()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtMaTacGia.Text = "";
            txtMaTheLoai.Text = "";
            txtMaNXB.Text = "";
            txtNamSX.Text = "";
            // clear new fields
            txtGiaSach.Text = "";
            txtSoLuong.Text = "";
            _editingBook = null;
        }

        // simple POCO model for binding
        private class Book
        {
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public string MaTacGia { get; set; }
            public string MaTheLoai { get; set; }
            public string MaNXB { get; set; }
            public int? NamSX { get; set; }

            // new properties
            public decimal? Gia { get; set; }
            public int? SoLuong { get; set; }
        }
    }
}
