using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using book_management.Data;
using book_management.DataAccess;
using book_management.Models;

namespace book_management.UI.Controls
{
    public partial class InvoicesControl : UserControl
    {
        #region Fields and Properties
        public event EventHandler AddInvoiceClicked;

        private string placeholderText = "Tìm theo mã HD, tên khách...";
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 1;
        #endregion

        #region Constructor
        public InvoicesControl()
        {
            InitializeComponent();
            InitializeData();
        }
        #endregion

        #region Initialization
        private void InitializeData()
        {
            // Set default values
            cmbStatusFilter.SelectedIndex = 0;

            // Make date pickers optional: user can uncheck to disable date filtering
            dtpFromDate.ShowCheckBox = true;
            dtpFromDate.Checked = false; // default: do not filter by date
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = "dd/MM/yyyy";
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);

            dtpToDate.ShowCheckBox = true;
            dtpToDate.Checked = false; // default: do not filter by date
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = "dd/MM/yyyy";
            dtpToDate.Value = DateTime.Now;

            // Apply initial placeholder
            TxtSearch_LostFocus(txtSearch, null);

            // Style DataGridView
            StyleDataGridView();

            // Hook up status filter change to refresh search results
            cmbStatusFilter.SelectedIndexChanged += CmbStatusFilter_SelectedIndexChanged;
        }

        private void StyleDataGridView()
        {
            // Header styling
            dgvInvoices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
            dgvInvoices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInvoices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvInvoices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cell styling
            dgvInvoices.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvInvoices.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            dgvInvoices.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvInvoices.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Column alignments
            HoaDonId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NgayLap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TenNguoiMua.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            TongTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            TrangThai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NguoiLap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion

        #region Event Handlers
        private void InvoicesControl_Load(object sender, EventArgs e)
        {
            try
            {
                LoadInvoices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải InvoicesControl: {ex.Message}", "Lỗi nghiêm trọng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = placeholderText;
                tb.ForeColor = Color.Gray;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchInvoices();
        }

        private void BtnAddInvoice_Click(object sender, EventArgs e)
        {
            AddInvoiceClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            TxtSearch_LostFocus(txtSearch, null); // Set lại placeholder
            cmbStatusFilter.SelectedIndex = 0; // Đặt về "Tất cả"
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpFromDate.Checked = false; // Không lọc theo ngày
            dtpToDate.Value = DateTime.Now;
            dtpToDate.Checked = false; // Không lọc theo ngày

            // Gọi hàm Load để đảm bảo query đúng được chạy
            LoadInvoices();
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When status filter changes, re-run search to update results
            try
            {
                SearchInvoices();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in status filter change: {ex.Message}");
            }
        }

        private void DgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                if (e.RowIndex >= dgvInvoices.Rows.Count) return;

                if (dgvInvoices.Rows[e.RowIndex].Tag == null) return;

                if (!int.TryParse(dgvInvoices.Rows[e.RowIndex].Tag.ToString(), out int hoaDonId)) return;

                string columnName = dgvInvoices.Columns[e.ColumnIndex].Name;

                switch (columnName)
                {
                    case "ViewDetail":
                        ViewInvoiceDetail(hoaDonId);
                        break;
                    case "Edit":
                        EditInvoice(hoaDonId);
                        break;
                    case "Delete":
                        DeleteInvoice(hoaDonId);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý click: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                if (e.ColumnIndex >= dgvInvoices.Columns.Count) return;

                if (dgvInvoices.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
                {
                    var status = e.Value.ToString();
                    switch (status)
                    {
                        case "TatCa":
                            e.Value = "Tất cả";
                            e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                            e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                            break;
                        case "DaThanhToan":
                            e.Value = "Đã thanh toán";
                            e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                            e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                            break;
                        case "ChuaThanhToan":
                            e.Value = "Chưa thanh toán";
                            e.CellStyle.BackColor = Color.FromArgb(254, 249, 195);
                            e.CellStyle.ForeColor = Color.FromArgb(133, 77, 14);
                            break;
                        case "DaHuy":
                            e.Value = "Đã hủy";
                            e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                            e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                            break;
                    }
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    e.FormattingApplied = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in CellFormatting: {ex.Message}");
            }
        }

        private void DgvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            TryUpdatePayButtonState();
        }
        #endregion

        #region Data Operations
        private void LoadInvoices()
        {
            try
            {
                var invoices = HoaDonRepository.GetAllInvoices();
                PopulateDataGridView(invoices);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}",
                       "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchInvoices()
        {
            try
            {
                string searchTerm = GetSearchTerm();
                string statusDb = GetStatusFilter(); // null => all

                // Use server-side filtering with optional dates
                DateTime? fromDate = dtpFromDate.Checked ? dtpFromDate.Value.Date : (DateTime?)null;
                DateTime? toDate = dtpToDate.Checked ? dtpToDate.Value.Date.AddDays(1).AddTicks(-1) : (DateTime?)null;

                var invoices = HoaDonRepository.SearchInvoices(searchTerm, statusDb, fromDate, toDate) ?? new List<HoaDon>();

                PopulateDataGridView(invoices);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}",
                                 "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateDataGridView(dynamic invoices)
        {
            dgvInvoices.Rows.Clear();
            decimal totalAmount = 0;
            var count = 0;
            foreach (var invoice in invoices)
            {
                var rowIndex = dgvInvoices.Rows.Add(
                   invoice.HoaDonId,
                   invoice.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                   invoice.TenNguoiMua,
                   invoice.TongTien.ToString("N0") + " đ",
                   invoice.TrangThai,
                   invoice.NguoiLap
                );
                count++;
                dgvInvoices.Rows[rowIndex].Tag = invoice.HoaDonId;
                totalAmount += invoice.TongTien;
            }
            UpdateSummary(count, totalAmount);

        }

        private void RefreshData()
        {
            txtSearch.Text = string.Empty;
            TxtSearch_LostFocus(txtSearch, null);
            cmbStatusFilter.SelectedIndex = 0;
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;
            LoadInvoices();
        }
        #endregion

        #region Helper Methods
        private string GetSearchTerm()
        {
            string searchTerm = txtSearch.Text.Trim();
            return searchTerm == placeholderText ? "" : searchTerm;
        }

        private string GetStatusFilter()
        {
            var statusDisplay = cmbStatusFilter.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(statusDisplay) || statusDisplay.Equals("Tất cả", StringComparison.OrdinalIgnoreCase) || statusDisplay.Equals("TatCa", StringComparison.OrdinalIgnoreCase))
                return null;

            switch (statusDisplay)
            {
                case "Đã thanh toán":
                    return "DaThanhToan";
                case "Chưa thanh toán":
                    return "ChuaThanhToan";
                case "Đã hủy":
                    return "DaHuy";
                default:
                    return null;
            }
        }

        private string RemoveAccents(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            string normalized = input.Normalize(System.Text.NormalizationForm.FormD);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            foreach (char c in normalized)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }
        // ham tinh tong hoa don va doanh thu
        private void UpdateSummary(int totalInvoices, decimal totalAmount)
        {
            lblTotalInvoices.Text = $"Tổng số hóa đơn: {totalInvoices}";
            lblTotalAmount.Text = $"Tổng doanh thu: {totalAmount:N0} đ";
        }
        #endregion

        #region Action Methods
        private void ViewInvoiceDetail(int hoaDonId)
        {
            try
            {
                var chiTietList = ChiTietHoaDonRepository.GetChiTietHoaDon(hoaDonId);
                var detailForm = new InvoiceDetailForm(hoaDonId, chiTietList);
                detailForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết hóa đơn: {ex.Message}",
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditInvoice(int hoaDonId)
        {
            try
            {
                var invoice = HoaDonRepository.GetInvoiceById(hoaDonId);
                if (invoice == null)
                {
                    MessageBox.Show("Hóa đơn không tồn tại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var editForm = new EditInvoiceControl(hoaDonId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadInvoices();
                        MessageBox.Show("Hóa đơn đã được cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa hóa đơn: {ex.Message}",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteInvoice(int hoaDonId)
        {
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn {hoaDonId}?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    HoaDonRepository.DeleteInvoice(hoaDonId);
                    MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvoices();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Payment Methods
        private void TryUpdatePayButtonState()
        {
            if (dgvInvoices.SelectedRows.Count == 1)
            {
                var selectedRow = dgvInvoices.SelectedRows[0];
                var status = selectedRow.Cells["TrangThai"].Value?.ToString();
                btnPay.Enabled = status == "ChuaThanhToan";
            }
            else
            {
                btnPay.Enabled = false;
            }
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count != 1) return;

            var selectedRow = dgvInvoices.SelectedRows[0];
            var hoaDonId = (int)selectedRow.Cells["HoaDonId"].Value;
            var status = selectedRow.Cells["TrangThai"].Value?.ToString();

            if (status != "ChuaThanhToan")
            {
                MessageBox.Show("Chỉ có thể thanh toán hóa đơn chưa thanh toán!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn đánh dấu hóa đơn này là đã thanh toán?",
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    HoaDonRepository.UpdateInvoiceStatus(hoaDonId, 1); // 1 = Đã thanh toán
                    MessageBox.Show("Thanh toán thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvoices();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Public Methods
        public void RefreshInvoices()
        {
            LoadInvoices();
        }
        #endregion
    }
}