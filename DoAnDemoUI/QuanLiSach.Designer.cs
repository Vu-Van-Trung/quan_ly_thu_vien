
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnDemoUI
{
    partial class QuanLiSach
    {
        private IContainer components = null;

        private Label lblTitle;
        private GroupBox grpDetails;
        private Label lblMaSach;
        private TextBox txtMaSach;
        private Label lblTenSach;
        private TextBox txtTenSach;
        private Label lblMaTacGia;
        private TextBox txtMaTacGia;
        private Label lblMaTheLoai;
        private TextBox txtMaTheLoai;
        private Label lblMaNXB;
        private TextBox txtMaNXB;
        private Label lblNamSX;
        private TextBox txtNamSX;

        // new controls
        private Label lblGiaSach;
        private TextBox txtGiaSach;
        private Label lblSoLuong;
        private TextBox txtSoLuong;

        private FlowLayoutPanel flowButtons;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSave;
        private Button btnCancel;

        private DataGridView dgvBooks;
        private BindingSource bindingSourceBooks;

        private TextBox txtSearch;
        private Button btnSearch;
        private Panel topPanel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();

            this.lblTitle = new Label();
            this.topPanel = new Panel();

            this.grpDetails = new GroupBox();
            this.lblMaSach = new Label();
            this.txtMaSach = new TextBox();
            this.lblTenSach = new Label();
            this.txtTenSach = new TextBox();
            this.lblMaTacGia = new Label();
            this.txtMaTacGia = new TextBox();
            this.lblMaTheLoai = new Label();
            this.txtMaTheLoai = new TextBox();
            this.lblMaNXB = new Label();
            this.txtMaNXB = new TextBox();
            this.lblNamSX = new Label();
            this.txtNamSX = new TextBox();

            // new controls initialization
            this.lblGiaSach = new Label();
            this.txtGiaSach = new TextBox();
            this.lblSoLuong = new Label();
            this.txtSoLuong = new TextBox();

            this.flowButtons = new FlowLayoutPanel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.txtSearch = new TextBox();
            this.btnSearch = new Button();

            this.dgvBooks = new DataGridView();
            this.bindingSourceBooks = new BindingSource(this.components);

            ((ISupportInitialize)(this.dgvBooks)).BeginInit();
            ((ISupportInitialize)(this.bindingSourceBooks)).BeginInit();
            this.SuspendLayout();

            // 
            // topPanel
            // 
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Height = 48;
            this.topPanel.BackColor = Color.FromArgb(40, 120, 200);
            this.topPanel.Padding = new Padding(12);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "SÁCH";
            this.topPanel.Controls.Add(this.lblTitle);

            // 
            // grpDetails
            // 
            this.grpDetails.Location = new Point(12, 64);
            // increase height to fit extra fields
            this.grpDetails.Size = new Size(360, 380);
            this.grpDetails.Text = "Thông tin sách";
            this.grpDetails.Font = new Font("Segoe UI", 9F);

            // detail controls layout
            var labelWidth = 90;
            var ctrlLeft = 14;
            var ctrlTop = 24;
            var spacingY = 34;
            var ctrlWidth = 240;

            // 
            // lblMaSach
            // 
            this.lblMaSach.Location = new Point(ctrlLeft, ctrlTop);
            this.lblMaSach.Size = new Size(labelWidth, 20);
            this.lblMaSach.Text = "MASACH";
            this.lblMaSach.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new Point(ctrlLeft + labelWidth, ctrlTop - 2);
            this.txtMaSach.Size = new Size(ctrlWidth, 23);
            this.txtMaSach.Name = "txtMaSach";

            // 
            // lblTenSach
            // 
            this.lblTenSach.Location = new Point(ctrlLeft, ctrlTop + spacingY);
            this.lblTenSach.Size = new Size(labelWidth, 20);
            this.lblTenSach.Text = "TENSACH";

            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY - 2);
            this.txtTenSach.Size = new Size(ctrlWidth, 23);
            this.txtTenSach.Name = "txtTenSach";

            // 
            // lblMaTacGia
            // 
            this.lblMaTacGia.Location = new Point(ctrlLeft, ctrlTop + spacingY * 2);
            this.lblMaTacGia.Size = new Size(labelWidth, 20);
            this.lblMaTacGia.Text = "MATACGIA";

            // 
            // txtMaTacGia
            // 
            this.txtMaTacGia.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY * 2 - 2);
            this.txtMaTacGia.Size = new Size(ctrlWidth, 23);
            this.txtMaTacGia.Name = "txtMaTacGia";

            // 
            // lblMaTheLoai
            // 
            this.lblMaTheLoai.Location = new Point(ctrlLeft, ctrlTop + spacingY * 3);
            this.lblMaTheLoai.Size = new Size(labelWidth, 20);
            this.lblMaTheLoai.Text = "MATHELOAI";

            // 
            // txtMaTheLoai
            // 
            this.txtMaTheLoai.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY * 3 - 2);
            this.txtMaTheLoai.Size = new Size(ctrlWidth, 23);
            this.txtMaTheLoai.Name = "txtMaTheLoai";

            // 
            // lblMaNXB
            // 
            this.lblMaNXB.Location = new Point(ctrlLeft, ctrlTop + spacingY * 4);
            this.lblMaNXB.Size = new Size(labelWidth, 20);
            this.lblMaNXB.Text = "MANHAXUATBAN";

            // 
            // txtMaNXB
            // 
            this.txtMaNXB.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY * 4 - 2);
            this.txtMaNXB.Size = new Size(ctrlWidth, 23);
            this.txtMaNXB.Name = "txtMaNXB";

            // 
            // lblNamSX
            // 
            this.lblNamSX.Location = new Point(ctrlLeft, ctrlTop + spacingY * 5);
            this.lblNamSX.Size = new Size(labelWidth, 20);
            this.lblNamSX.Text = "NAMSX";

            // 
            // txtNamSX
            // 
            this.txtNamSX.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY * 5 - 2);
            this.txtNamSX.Size = new Size(ctrlWidth, 23);
            this.txtNamSX.Name = "txtNamSX";

            // new: lblGiaSach
            this.lblGiaSach.Location = new Point(ctrlLeft, ctrlTop + spacingY * 6);
            this.lblGiaSach.Size = new Size(labelWidth, 20);
            this.lblGiaSach.Text = "GIASACH";

            this.txtGiaSach.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY * 6 - 2);
            this.txtGiaSach.Size = new Size(ctrlWidth, 23);
            this.txtGiaSach.Name = "txtGiaSach";

            // new: lblSoLuong
            this.lblSoLuong.Location = new Point(ctrlLeft, ctrlTop + spacingY * 7);
            this.lblSoLuong.Size = new Size(labelWidth, 20);
            this.lblSoLuong.Text = "SỐ LƯỢNG";

            this.txtSoLuong.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY * 7 - 2);
            this.txtSoLuong.Size = new Size(ctrlWidth, 23);
            this.txtSoLuong.Name = "txtSoLuong";

            // add detail controls
            this.grpDetails.Controls.Add(this.lblMaSach);
            this.grpDetails.Controls.Add(this.txtMaSach);
            this.grpDetails.Controls.Add(this.lblTenSach);
            this.grpDetails.Controls.Add(this.txtTenSach);
            this.grpDetails.Controls.Add(this.lblMaTacGia);
            this.grpDetails.Controls.Add(this.txtMaTacGia);
            this.grpDetails.Controls.Add(this.lblMaTheLoai);
            this.grpDetails.Controls.Add(this.txtMaTheLoai);
            this.grpDetails.Controls.Add(this.lblMaNXB);
            this.grpDetails.Controls.Add(this.txtMaNXB);
            this.grpDetails.Controls.Add(this.lblNamSX);
            this.grpDetails.Controls.Add(this.txtNamSX);

            // add new controls to groupbox
            this.grpDetails.Controls.Add(this.lblGiaSach);
            this.grpDetails.Controls.Add(this.txtGiaSach);
            this.grpDetails.Controls.Add(this.lblSoLuong);
            this.grpDetails.Controls.Add(this.txtSoLuong);

            // 
            // flowButtons
            // 
            this.flowButtons.Location = new Point(12, 472);
            this.flowButtons.Size = new Size(360, 40);
            this.flowButtons.FlowDirection = FlowDirection.LeftToRight;
            this.flowButtons.WrapContents = false;

            // 
            // btnAdd
            // 
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Size = new Size(70, 30);
            this.btnAdd.Name = "btnAdd";

            // 
            // btnEdit
            // 
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Size = new Size(70, 30);
            this.btnEdit.Name = "btnEdit";

            // 
            // btnDelete
            // 
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Size = new Size(70, 30);
            this.btnDelete.Name = "btnDelete";

            // 
            // btnSave
            // 
            this.btnSave.Text = "Lưu";
            this.btnSave.Size = new Size(70, 30);
            this.btnSave.Name = "btnSave";

            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Size = new Size(70, 30);
            this.btnCancel.Name = "btnCancel";

            this.flowButtons.Controls.Add(this.btnAdd);
            this.flowButtons.Controls.Add(this.btnEdit);
            this.flowButtons.Controls.Add(this.btnDelete);
            this.flowButtons.Controls.Add(this.btnSave);
            this.flowButtons.Controls.Add(this.btnCancel);

            // 
            // txtSearch and btnSearch
            // 
            this.txtSearch.Location = new Point(390, 64);
            this.txtSearch.Size = new Size(300, 23);
            this.txtSearch.Name = "txtSearch";

            this.btnSearch.Location = new Point(700, 62);
            this.btnSearch.Size = new Size(70, 26);
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Name = "btnSearch";

            // 
            // dgvBooks
            // 
            this.dgvBooks.Location = new Point(390, 96);
            this.dgvBooks.Size = new Size(380, 320);
            this.dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvBooks.AutoGenerateColumns = false;
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.DataSource = this.bindingSourceBooks;

            // columns
            var colMaSach = new DataGridViewTextBoxColumn { DataPropertyName = "MaSach", HeaderText = "MASACH", Width = 80 };
            var colTenSach = new DataGridViewTextBoxColumn { DataPropertyName = "TenSach", HeaderText = "TENSACH", Width = 150 };
            var colMaTacGia = new DataGridViewTextBoxColumn { DataPropertyName = "MaTacGia", HeaderText = "MATACGIA (FK)", Width = 80 };
            var colMaTheLoai = new DataGridViewTextBoxColumn { DataPropertyName = "MaTheLoai", HeaderText = "MATHELOAI (FK)", Width = 90 };
            var colMaNXB = new DataGridViewTextBoxColumn { DataPropertyName = "MaNXB", HeaderText = "MANHAXUATBAN (FK)", Width = 110 };
            var colNamSX = new DataGridViewTextBoxColumn { DataPropertyName = "NamSX", HeaderText = "NAMSX", Width = 60 };

            // new columns: GiaSach and SoLuong
            var colGia = new DataGridViewTextBoxColumn { DataPropertyName = "Gia", HeaderText = "GIÁ", Width = 90, DefaultCellStyle = { Format = "N2" } };
            var colSoLuong = new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "SỐ LƯỢNG", Width = 80 };

            this.dgvBooks.Columns.AddRange(new DataGridViewColumn[] {
                colMaSach, colTenSach, colMaTacGia, colMaTheLoai, colMaNXB, colNamSX, colGia, colSoLuong
            });

            // 
            // form (QuanLiSach)
            // 
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.flowButtons);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvBooks);

            this.Text = "Quản lý sách";
            this.Font = new Font("Segoe UI", 9F);
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimumSize = new Size(820, 490);
            this.Name = "QuanLiSach";

            ((ISupportInitialize)(this.dgvBooks)).EndInit();
            ((ISupportInitialize)(this.bindingSourceBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}