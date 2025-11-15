using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using book_management.Data;
using book_management.DataAccess;
using book_management.Models;
using book_management.UI.Modal;
using TextBox = System.Windows.Forms.TextBox;
namespace book_management.UI.Controls
{
    public partial class WarehouseControl : System.Windows.Forms.UserControl
    {

        public event EventHandler AddInvoiceClicked;
        private string placeholderText = "Tìm theo mã HD, tên khách...";
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 1;
        public WarehouseControl()
        {
            InitializeComponent();
            InitializeData();

            // Register DataGridView events
            this.Load += WarehouseControl_Load;
            //this.dgvImports.CellContentClick += dgvImports_CellContentClick;
            // Register search events
            this.txtSearchWareHouse.GotFocus += TxtSearch_GotFocus;
            this.txtSearchWareHouse.KeyDown += TxtSearchWareHouse_KeyDown;
        }
        private void InitializeData()
        {

            // Make date pickers optional (user can uncheck to disable date filtering)
            dtpFromDate.ShowCheckBox = true;
            dtpFromDate.Checked = false;
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = "dd/MM/yyyy";
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);

            dtpToDate.ShowCheckBox = true;
            dtpToDate.Checked = false; 
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = "dd/MM/yyyy";
            dtpToDate.Value = DateTime.Now;

            // Apply initial placeholder
            TxtSearch_LostFocus(txtSearchWareHouse, null);

            // Style DataGridView
            StyleDataGridView();

            // Do not allow editing or deleting warehouse imports: hide those action columns
            try
            {
                if (dgvImports.Columns["colDelete"] != null) dgvImports.Columns["colDelete"].Visible = false;
                if (dgvImports.Columns["colEdit"] != null) dgvImports.Columns["colEdit"].Visible = false;
            }
            catch { }
        }

        private void StyleDataGridView()
        {
            // Header styling
            dgvImports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
            dgvImports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvImports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvImports.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cell styling
            dgvImports.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvImports.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            dgvImports.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvImports.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Column alignments
            colMaPN.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colNXB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colNguoiTao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colNgayNhap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colTongTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnAddImport_Click(object sender, EventArgs e)
        {
            using (var form = new frmAddImport())
            {
                form.ShowDialog();
            }
        }
        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = placeholderText;
                tb.ForeColor = Color.Gray;
            }
        }

        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == placeholderText)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void TxtSearchWareHouse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SearchWareHouse();
            }
        }

        private string GetSearchTerm()
        {
            string searchTerm = txtSearchWareHouse.Text.Trim();
            return searchTerm == placeholderText ? "" : searchTerm;
        }

        private void SearchWareHouse()
        {
            try
            {
                var searchTerm = GetSearchTerm();

                List<book_management.Models.PhieuNhap> results;

                // If both date pickers are checked, use repository date range search
                if (dtpFromDate.ShowCheckBox && dtpFromDate.Checked && dtpToDate.ShowCheckBox && dtpToDate.Checked)
                {
                    var start = dtpFromDate.Value.Date;
                    var end = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);
                    results = WareHouseRepository.SearchWareHousesByDateRange(start, end);
                }
                else
                {
                    results = WareHouseRepository.GetAllWareHouses();
                }

                // If there's a search term, do client-side filtering: by pn_id or TenNguoiNhap
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var lower = searchTerm.ToLowerInvariant();
                    if (int.TryParse(searchTerm, out int pnId))
                    {
                        results = results.FindAll(p => p.PnId == pnId);
                    }
                    else
                    {
                        results = results.FindAll(p => (p.TenNguoiNhap ?? string.Empty).ToLowerInvariant().Contains(lower));
                    }
                }

                PopulateDataGridView(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WarehouseControl_Load(object sender, EventArgs e)
        {
            try
            {
                LoadWareHouse();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải WareHouseControl: {ex.Message}", "Lỗi nghiêm trọng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadWareHouse()
        {
            try
            {
                var wareHouse = WareHouseRepository.GetAllWareHouses();
                PopulateDataGridView(wareHouse);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}",
                       "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateDataGridView(dynamic wareHouse)
        {
            dgvImports.Rows.Clear();
            decimal totalAmount = 0;

            foreach (var warehouse in wareHouse)
            {
                var rowIndex = dgvImports.Rows.Add(
                   warehouse.PnId,
                   warehouse.TenNXB,
                   warehouse.TenNguoiNhap,
                   warehouse.NgayNhap.ToString("dd/MM/yyyy HH:mm"),
                   warehouse.TongTien.ToString("N0") + " đ"
                );

                // set the row Tag on the DataGridView row (not on the model)
                dgvImports.Rows[rowIndex].Tag = warehouse.PnId;
                totalAmount += warehouse.TongTien;
            }

            // Optionally update pagination/summary label if present (keep existing behavior)
            try
            {
                lblPageInfo.Text = $"Hiển thị1-{Math.Min(dgvImports.Rows.Count, 10)} của {dgvImports.Rows.Count}";
            }
            catch { }
        }
        private void RefreshData()
        {
            txtSearchWareHouse.Text = string.Empty;
            TxtSearch_LostFocus(txtSearchWareHouse, null);
            // reset date filters
            if (dtpFromDate.ShowCheckBox) dtpFromDate.Checked = false;
            if (dtpToDate.ShowCheckBox) dtpToDate.Checked = false;
            // perform a fresh load (which will consider date checkbox states)
            SearchWareHouse();
        }
        public void RefreshWareHouse()
        {
            LoadWareHouse();
        }

        private void BtnSearchWareHouse_Click(object sender, EventArgs e)
        {
            SearchWareHouse();
        }
    }
}
