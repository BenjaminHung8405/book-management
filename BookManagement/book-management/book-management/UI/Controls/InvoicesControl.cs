using book_management.DataAccess;
using book_management.UI.Theme;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_management.UI.Controls
{
    public partial class InvoicesControl : UserControl
    {
        public event EventHandler AddInvoiceClicked;
        
        private string placeholderText = "Tìm theo mã HD, tên khách...";

        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 1;

        public InvoicesControl()
        {
            InitializeComponent();
            InitializeInvoiceControl();
            LoadInvoices();
        }

        private void InitializeInvoiceControl()
        {
            // Setup status filter
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.AddRange(new string[] { "Tất cả", "Đã thanh toán", "Chưa thanh toán", "Đã hủy" });
            cmbStatusFilter.SelectedIndex = 0;

            // Setup date filters
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;

            // Setup search placeholder
            txtSearchBook.GotFocus += TxtSearch_GotFocus;
            txtSearchBook.LostFocus += TxtSearch_LostFocus;
            TxtSearch_LostFocus(txtSearchBook, null);

            // Setup DataGridView columns for invoices
            SetupInvoiceColumns();

            // Attach event handlers
            dgvInvoices.CellClick += DgvInvoices_CellClick;
            dgvInvoices.CellFormatting += DgvInvoices_CellFormatting;
        }

        private void SetupInvoiceColumns()
        {
            dgvInvoices.Columns.Clear();
            
            // Add invoice columns
            dgvInvoices.Columns.Add("HoaDonId", "Mã HD");
            dgvInvoices.Columns.Add("NgayLap", "Ngày lập");
            dgvInvoices.Columns.Add("TenNguoiMua", "Khách hàng");
            dgvInvoices.Columns.Add("TongTien", "Tổng tiền");
            dgvInvoices.Columns.Add("TrangThai", "Trạng thái");
            dgvInvoices.Columns.Add("NguoiLap", "Người lập");

            // Add action buttons
            var colViewDetail = new DataGridViewButtonColumn
            {
                Name = "ViewDetail",
                HeaderText = "Chi tiết",
                Text = "Xem",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dgvInvoices.Columns.Add(colViewDetail);

            var colEdit = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Sửa",
                Text = "Sửa",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvInvoices.Columns.Add(colEdit);

            var colDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Xóa",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvInvoices.Columns.Add(colDelete);

            // Configure column sizing
            dgvInvoices.Columns["HoaDonId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["NgayLap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["TongTien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["NguoiLap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["ViewDetail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["TenNguoiMua"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Configure column alignment
            dgvInvoices.Columns["HoaDonId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["TenNguoiMua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["NgayLap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["NguoiLap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            lblPageInfo.Text = $"Tổng số hóa đơn: {totalInvoices} | Tổng doanh thu: {totalAmount:N0} đ";
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
            LoadInvoices();
        }

        private void SearchInvoices()
        {
            try
            {
                var searchTerm = txtSearchBook.Text == placeholderText ? "" : txtSearchBook.Text.Trim();
                var status = cmbStatusFilter.SelectedItem?.ToString();
                var fromDate = dtpFromDate.Value.Date;
                var toDate = dtpToDate.Value.Date.AddDays(1);

                var invoices = HoaDonRepository.SearchInvoices(searchTerm, status, fromDate, toDate);

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
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        break;
                    case "ChuaThanhToan":
                        e.Value = "Chưa thanh toán";
                        e.CellStyle.BackColor = Color.LightYellow;
                        e.CellStyle.ForeColor = Color.DarkOrange;
                        break;
                    case "DaHuy":
                        e.Value = "Đã hủy";
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.DarkRed;
                        break;
                }
            }
        }

        private void ViewInvoiceDetail(int hoaDonId)
        {
            try
            {
                var chiTietList = ChiTietHoaDonRepository.GetChiTietByHoaDonId(hoaDonId);
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
                // var editForm = new EditInvoiceForm(invoice);
                // editForm.ShowDialog();
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
    }
}
