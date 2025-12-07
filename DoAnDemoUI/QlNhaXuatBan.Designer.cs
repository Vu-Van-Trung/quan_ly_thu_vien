using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;



namespace DoAnDemoUI
{
    partial class QlNhaXuatBan
    {
        private IContainer components = null;

        private Panel topPanel;
        private Label lblTitle;

        private GroupBox grpDetails;
        private Label lblMaNXB;
        private TextBox txtMaNXB;
        private Label lblTenNXB;
        private TextBox txtTenNXB;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblThongTinDD;
        private TextBox txtThongTinDD;

        private FlowLayoutPanel flowButtons;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSave;
        private Button btnClear;

        private DataGridView dgvNXB;
        private Button btnSearch;
        private TextBox txtSearch;

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

            this.topPanel = new Panel();
            this.lblTitle = new Label();

            this.grpDetails = new GroupBox();
            this.lblMaNXB = new Label();
            this.txtMaNXB = new TextBox();
            this.lblTenNXB = new Label();
            this.txtTenNXB = new TextBox();
            this.lblDiaChi = new Label();
            this.txtDiaChi = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblThongTinDD = new Label();
            this.txtThongTinDD = new TextBox();

            this.flowButtons = new FlowLayoutPanel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnSave = new Button();
            this.btnClear = new Button();

            this.txtSearch = new TextBox();
            this.btnSearch = new Button();

            this.dgvNXB = new DataGridView();

            ((ISupportInitialize)(this.dgvNXB)).BeginInit();
            this.SuspendLayout();

            // topPanel (blue title bar)
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Height = 48;
            this.topPanel.BackColor = Color.FromArgb(40, 120, 200);
            this.topPanel.Padding = new Padding(12);

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Quản lý Nhà Xuất Bản";
            this.topPanel.Controls.Add(this.lblTitle);

            // grpDetails (left groupbox with inputs)
            this.grpDetails.Location = new Point(12, 64);
            this.grpDetails.Size = new Size(360, 260);
            this.grpDetails.Text = "Thông tin nhà xuất bản";
            this.grpDetails.Font = new Font("Segoe UI", 9F);

            // detail controls layout inside groupbox
            var labelWidth = 120;
            var ctrlLeft = 14;
            var ctrlTop = 24;
            var spacingY = 34;
            var ctrlWidth = 220;

            // lblMaNXB
            this.lblMaNXB.Location = new Point(ctrlLeft, ctrlTop);
            this.lblMaNXB.Size = new Size(labelWidth, 20);
            this.lblMaNXB.Text = "MANHAXUATBAN";
            this.lblMaNXB.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // txtMaNXB
            this.txtMaNXB.Location = new Point(ctrlLeft + labelWidth, ctrlTop - 2);
            this.txtMaNXB.Size = new Size(ctrlWidth, 23);
            this.txtMaNXB.Name = "txtMaNXB";

            // lblTenNXB
            this.lblTenNXB.Location = new Point(ctrlLeft, ctrlTop + spacingY);
            this.lblTenNXB.Size = new Size(labelWidth, 20);
            this.lblTenNXB.Text = "TENNHAXUATBAN";

            // txtTenNXB
            this.txtTenNXB.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY - 2);
            this.txtTenNXB.Size = new Size(ctrlWidth, 23);
            this.txtTenNXB.Name = "txtTenNXB";

            // lblDiaChi
            this.lblDiaChi.Location = new Point(ctrlLeft, ctrlTop + spacingY * 2);
            this.lblDiaChi.Size = new Size(labelWidth, 20);
            this.lblDiaChi.Text = "DIACHI";

            // txtDiaChi
            this.txtDiaChi.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY * 2 - 2);
            this.txtDiaChi.Size = new Size(ctrlWidth, 23);
            this.txtDiaChi.Name = "txtDiaChi";

            // lblEmail
            this.lblEmail.Location = new Point(ctrlLeft, ctrlTop + spacingY * 3);
            this.lblEmail.Size = new Size(labelWidth, 20);
            this.lblEmail.Text = "EMAIL";

            // txtEmail
            this.txtEmail.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY * 3 - 2);
            this.txtEmail.Size = new Size(ctrlWidth, 23);
            this.txtEmail.Name = "txtEmail";

            // lblThongTinDD
            this.lblThongTinDD.Location = new Point(ctrlLeft, ctrlTop + spacingY * 4);
            this.lblThongTinDD.Size = new Size(labelWidth, 20);
            this.lblThongTinDD.Text = "THONGTINDAIDIEN";

            // txtThongTinDD
            this.txtThongTinDD.Location = new Point(ctrlLeft + labelWidth, ctrlTop + spacingY * 4 - 2);
            this.txtThongTinDD.Size = new Size(ctrlWidth, 23);
            this.txtThongTinDD.Name = "txtThongTinDD";

            // add detail controls to groupbox
            this.grpDetails.Controls.Add(this.lblMaNXB);
            this.grpDetails.Controls.Add(this.txtMaNXB);
            this.grpDetails.Controls.Add(this.lblTenNXB);
            this.grpDetails.Controls.Add(this.txtTenNXB);
            this.grpDetails.Controls.Add(this.lblDiaChi);
            this.grpDetails.Controls.Add(this.txtDiaChi);
            this.grpDetails.Controls.Add(this.lblEmail);
            this.grpDetails.Controls.Add(this.txtEmail);
            this.grpDetails.Controls.Add(this.lblThongTinDD);
            this.grpDetails.Controls.Add(this.txtThongTinDD);

            // flowButtons (below groupbox)
            this.flowButtons.Location = new Point(12, 332);
            this.flowButtons.Size = new Size(360, 40);
            this.flowButtons.FlowDirection = FlowDirection.LeftToRight;
            this.flowButtons.WrapContents = false;

            // btnAdd
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Size = new Size(70, 30);
            this.btnAdd.Name = "btnAdd";

            // btnEdit
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Size = new Size(70, 30);
            this.btnEdit.Name = "btnEdit";

            // btnDelete
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Size = new Size(70, 30);
            this.btnDelete.Name = "btnDelete";

            // btnSave (new)
            this.btnSave.Text = "Lưu";
            this.btnSave.Size = new Size(70, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Enabled = false; // disabled by default; enabled when editing

            // btnClear (used as Cancel/Làm mới)
            this.btnClear.Text = "Làm mới";
            this.btnClear.Size = new Size(70, 30);
            this.btnClear.Name = "btnClear";

            // add buttons to flow panel (order)
            this.flowButtons.Controls.Add(this.btnAdd);
            this.flowButtons.Controls.Add(this.btnEdit);
            this.flowButtons.Controls.Add(this.btnDelete);
            this.flowButtons.Controls.Add(this.btnSave);
            this.flowButtons.Controls.Add(this.btnClear);

            // Search controls (positioned like QuanLiSach)
            this.txtSearch.Location = new Point(390, 64);
            this.txtSearch.Size = new Size(300, 23);
            this.txtSearch.Name = "txtSearch";

            this.btnSearch.Location = new Point(700, 62);
            this.btnSearch.Size = new Size(70, 26);
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Name = "btnSearch";

            // dgvNXB (right area under search)
            this.dgvNXB.Location = new Point(390, 96);
            this.dgvNXB.Size = new Size(420, 330);
            this.dgvNXB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvNXB.ReadOnly = true;
            this.dgvNXB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvNXB.MultiSelect = false;
            this.dgvNXB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ensure columns do not get auto-generated from DataSource
            this.dgvNXB.AutoGenerateColumns = false;

            // Columns order required: STT, MaNXB, TenNXB, ThongTin, DiaChi, Email
            var cSTT = new DataGridViewTextBoxColumn
            {
                Name = "colSTT",
                HeaderText = "STT",
                Width = 25,
                ReadOnly = true
            };

            var cMaNXB = new DataGridViewTextBoxColumn
            {
                Name = "colMaNXB",
                DataPropertyName = "MaNXB",
                HeaderText = "MaNXB",
                Width = 80
            };

            var cTenNXB = new DataGridViewTextBoxColumn
            {
                Name = "colTenNXB",
                DataPropertyName = "TenNXB",
                HeaderText = "TenNXB",
                Width = 160
            };

            var cThongTin = new DataGridViewTextBoxColumn
            {
                Name = "colThongTin",
                DataPropertyName = "ThongTin",
                HeaderText = "ThongTin",
                Width = 160
            };

            var cDiaChi = new DataGridViewTextBoxColumn
            {
                Name = "colDiaChi",
                DataPropertyName = "DiaChi",
                HeaderText = "DIACHI",
                Width = 160
            };

            var cEmail = new DataGridViewTextBoxColumn
            {
                Name = "colEmail",
                DataPropertyName = "Email",
                HeaderText = "EMAIL",
                Width = 160
            };

            this.dgvNXB.Columns.AddRange(new DataGridViewColumn[] { cSTT, cMaNXB, cTenNXB, cThongTin, cDiaChi, cEmail });

            // Form
            this.ClientSize = new Size(850, 460);
            // add controls in logical order: top panel, left group, left buttons, then search/grid
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.flowButtons);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvNXB);

            this.Text = "Quản lý Nhà Xuất Bản";
            this.Font = new Font("Segoe UI", 9F);
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimumSize = new Size(870, 500);
            this.Name = "NhaXuatBan";

            ((ISupportInitialize)(this.dgvNXB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}