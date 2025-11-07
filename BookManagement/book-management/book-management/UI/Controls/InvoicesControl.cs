using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using book_management.Data;
using book_management.DataAccess;
using book_management.Models;
using book_management.UI.Theme;
using FontAwesome.Sharp;

namespace book_management.UI.Controls
{
    // Đảm bảo có 'partial'
    public partial class InvoicesControl : UserControl
    {
        public event EventHandler AddInvoiceClicked;

        private string placeholderText = "Tìm theo mã HD, tên khách...";

        // Các biến logic
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 1;

        public InvoicesControl()
        {
            InitializeComponent(); // Gọi hàm từ file .Designer.cs
            AssignEvents();

            // SỬA LỖI: Chuyển LoadInvoices() vào sự kiện _Load
        }

        // SỬA LỖI: Thêm sự kiện Load
        private void InvoicesControl_Load(object sender, EventArgs e)
        {
            // Chỉ tải dữ liệu khi Form được Load (lúc chạy F5)
            LoadInvoices();
        }

        /// <summary>
        /// Gán các sự kiện cho control
        /// </summary>
        private void AssignEvents()
        {
            txtSearch.GotFocus += TxtSearch_GotFocus;
            txtSearch.LostFocus += TxtSearch_LostFocus;
            TxtSearch_LostFocus(txtSearch, null); // Set placeholder

            btnSearch.Click += BtnSearch_Click;
            btnAddInvoice.Click += BtnAddInvoice_Click;
            btnRefresh.Click += BtnRefresh_Click;

            dgvInvoices.CellClick += DgvInvoices_CellClick;
            dgvInvoices.CellFormatting += DgvInvoices_CellFormatting;
        }

        /// <summary>
        /// Xử lý khi người dùng nhấp vào TextBox
        /// </summary>
        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == placeholderText)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Xử lý khi người dùng nhấp ra ngoài TextBox
        /// </summary>
        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = placeholderText;
                tb.ForeColor = Color.Gray;
            }
        }

        private void LoadInvoices()
        {
            try
            {
                var invoices = HoaDonRepository.GetAllInvoices();
                dgvInvoices.Rows.Clear();
                decimal totalAmount = 0;

                foreach (var invoice in invoices)
                {
                    dgvInvoices.Rows.Add(
                       invoice.HoaDonId,
                       invoice.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                       invoice.TenNguoiMua,
                       invoice.TongTien.ToString("N0") + " đ",
                       invoice.TrangThai,
                       invoice.NguoiLap
                      );
                    totalAmount += invoice.TongTien;
                }
                UpdateSummary(invoices.Count, totalAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}",
                       "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSummary(int totalInvoices, decimal totalAmount)
        {
            lblTotalInvoices.Text = $"Tổng số hóa đơn: {totalInvoices}";
            lblTotalAmount.Text = $"Tổng doanh thu: {totalAmount:N0} đ";
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
            TxtSearch_LostFocus(txtSearch, null);
            cmbStatusFilter.SelectedIndex = 0;
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;
            LoadInvoices();
        }

        private void SearchInvoices()
        {
            try
            {
                var searchTerm = txtSearch.Text.Trim();
                if (searchTerm == placeholderText) searchTerm = "";

                var statusDisplay = cmbStatusFilter.SelectedItem?.ToString();
                var fromDate = dtpFromDate.Value.Date;
                var toDate = dtpToDate.Value.Date.AddDays(1);

                string statusDb = statusDisplay;
                if (statusDisplay == "Đã thanh toán")
                    statusDb = "DaThanhToan";
                else if (statusDisplay == "Chưa thanh toán")
                    statusDb = "ChuaThanhToan";
                else if (statusDisplay == "Đã hủy")
                    statusDb = "DaHuy";

                var invoices = HoaDonRepository.SearchInvoices(searchTerm, statusDb, fromDate, toDate);

                dgvInvoices.Rows.Clear();
                decimal totalAmount = 0;

                foreach (var invoice in invoices)
                {
                    dgvInvoices.Rows.Add(
                       invoice.HoaDonId,
                       invoice.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                       invoice.TenNguoiMua,
                       invoice.TongTien.ToString("N0") + " đ",
                       invoice.TrangThai,
                       invoice.NguoiLap
                       );
                    totalAmount += invoice.TongTien;
                }
                UpdateSummary(invoices.Count, totalAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}",
                                 "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var hoaDonId = Convert.ToInt32(dgvInvoices.Rows[e.RowIndex].Cells["HoaDonId"].Value);

            switch (dgvInvoices.Columns[e.ColumnIndex].Name)
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

        private void DgvInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInvoices.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                var status = e.Value.ToString();
                switch (status)
                {
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
                MessageBox.Show("Chức năng sửa hóa đơn đang phát triển.");
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
                    LoadInvoices(); // Tải lại dữ liệu
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}