using book_management.UI.Modal;
using book_management.Data;
using book_management.Models;
using book_management.Helpers;
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
    public partial class CustomersControl : UserControl
    {
        private List<KhachHang> allCustomers;
        private List<KhachHang> filteredCustomers;
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 1;
        private string currentSearchKeyword = "";
        private System.Windows.Forms.Timer searchTimer;

        public CustomersControl()
        {
            InitializeComponent();
            InitializeEvents();
            LoadCustomers();
        }

        /// <summary>
        /// Khởi tạo các sự kiện
        /// </summary>
        private void InitializeEvents()
        {
            // Sự kiện tìm kiếm
            txtSearchUser.TextChanged += TxtSearchUser_TextChanged;
            txtSearchUser.KeyDown += TxtSearchUser_KeyDown;

            // Sự kiện DataGridView
            dgvUsers.CellClick += DgvUsers_CellClick;
            dgvUsers.CellFormatting += DgvUsers_CellFormatting;

            // Placeholder cho textbox tìm kiếm
            SetSearchPlaceholder();
        }

        /// <summary>
        /// Thiết lập placeholder cho textbox tìm kiếm
        /// </summary>
        private void SetSearchPlaceholder()
        {
            txtSearchUser.Text = "Tìm kiếm theo tên, số điện thoại hoặc địa chỉ...";
            txtSearchUser.ForeColor = Color.Gray;

            txtSearchUser.GotFocus += (s, e) =>
            {
                if (txtSearchUser.Text == "Tìm kiếm theo tên, số điện thoại hoặc địa chỉ...")
                {
                    txtSearchUser.Text = "";
                    txtSearchUser.ForeColor = Color.Black;
                }
            };

            txtSearchUser.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearchUser.Text))
                {
                    txtSearchUser.Text = "Tìm kiếm theo tên, số điện thoại hoặc địa chỉ...";
                    txtSearchUser.ForeColor = Color.Gray;
                }
            };
        }

        /// <summary>
        /// Load danh sách khách hàng từ database
        /// </summary>
        private void LoadCustomers()
        {
            try
            {
                // Cleanup khách vãng lai cũ
                CustomerRepository.CleanupExpiredTemporaryCustomers();

                // Load tất cả khách hàng
                allCustomers = CustomerRepository.GetAllCustomers();
                filteredCustomers = allCustomers.ToList();

                RefreshDataGridView();
                UpdatePageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khách hàng: {ex.Message}",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tìm kiếm khách hàng
        /// </summary>
        private void SearchCustomers()
        {
            try
            {
                currentSearchKeyword = txtSearchUser.Text.Trim();

                if (string.IsNullOrEmpty(currentSearchKeyword) ||
                  currentSearchKeyword == "Tìm kiếm theo tên, số điện thoại hoặc địa chỉ...")
                {
                    // Hiển thị tất cả khách hàng
                    filteredCustomers = allCustomers.ToList();
                }
                else
                {
                    // Tìm kiếm trên local data trước
                    filteredCustomers = allCustomers.Where(c =>
                       c.TenKhach.Contains(currentSearchKeyword, StringComparison.OrdinalIgnoreCase) ||
                        c.SoDienThoai.Contains(currentSearchKeyword) ||
                    c.DiaChi.Contains(currentSearchKeyword, StringComparison.OrdinalIgnoreCase)
                           ).ToList();

                    // Nếu không tìm thấy, tìm kiếm từ database
                    if (filteredCustomers.Count == 0)
                    {
                        filteredCustomers = CustomerRepository.SearchCustomers(currentSearchKeyword);
                    }
                }

                currentPage = 1; // Reset về trang đầu
                RefreshDataGridView();
                UpdatePageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm khách hàng: {ex.Message}",
                         "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật DataGridView với dữ liệu hiện tại
        /// </summary>
        private void RefreshDataGridView()
        {
            try
            {
                dgvUsers.Rows.Clear();

                // Tính toán phân trang
                totalPages = (int)Math.Ceiling((double)filteredCustomers.Count / pageSize);
                if (totalPages == 0) totalPages = 1;

                // Lấy dữ liệu cho trang hiện tại
                var pageData = filteredCustomers
                   .Skip((currentPage - 1) * pageSize)
              .Take(pageSize)
              .ToList();

                // Thêm dữ liệu vào DataGridView
                foreach (var customer in pageData)
                {
                    dgvUsers.Rows.Add(
                    customer.TenKhach,
               "", 
                customer.SoDienThoai,
                customer.DiaChi,
                customer.NgayTao.ToString("dd/MM/yyyy")
               );

                    // Lưu KhId vào Tag của row để sử dụng later
                    dgvUsers.Rows[dgvUsers.Rows.Count - 1].Tag = customer.KhId;
                }

                // Cập nhật pagination buttons
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật danh sách: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật thông tin trang
        /// </summary>
        private void UpdatePageInfo()
        {
            int fromRecord = filteredCustomers.Count == 0 ? 0 : (currentPage - 1) * pageSize + 1;
            int toRecord = Math.Min(currentPage * pageSize, filteredCustomers.Count);

            lblPageInfo.Text = $"Hiển thị {fromRecord}-{toRecord} của {filteredCustomers.Count} khách hàng";
        }

        /// <summary>
        /// Cập nhật các nút phân trang
        /// </summary>
        private void UpdatePaginationButtons()
        {
            flowPaginationButtons.Controls.Clear();

            if (totalPages <= 1) return;

            // Nút Previous
            if (currentPage > 1)
            {
                var btnPrev = CreatePaginationButton("‹", currentPage - 1);
                flowPaginationButtons.Controls.Add(btnPrev);
            }

            // Các nút số trang
            int startPage = Math.Max(1, currentPage - 2);
            int endPage = Math.Min(totalPages, currentPage + 2);

            if (startPage > 1)
            {
                flowPaginationButtons.Controls.Add(CreatePaginationButton("1", 1));
                if (startPage > 2)
                {
                    var lblDots = new Label { Text = "...", AutoSize = true, Margin = new Padding(5) };
                    flowPaginationButtons.Controls.Add(lblDots);
                }
            }

            for (int i = startPage; i <= endPage; i++)
            {
                var btn = CreatePaginationButton(i.ToString(), i);
                if (i == currentPage)
                {
                    btn.BackColor = Color.FromArgb(74, 144, 226);
                    btn.ForeColor = Color.White;
                }
                flowPaginationButtons.Controls.Add(btn);
            }

            if (endPage < totalPages)
            {
                if (endPage < totalPages - 1)
                {
                    var lblDots = new Label { Text = "...", AutoSize = true, Margin = new Padding(5) };
                    flowPaginationButtons.Controls.Add(lblDots);
                }
                flowPaginationButtons.Controls.Add(CreatePaginationButton(totalPages.ToString(), totalPages));
            }

            // Nút Next
            if (currentPage < totalPages)
            {
                var btnNext = CreatePaginationButton("›", currentPage + 1);
                flowPaginationButtons.Controls.Add(btnNext);
            }
        }

        /// <summary>
        /// Tạo button phân trang
        /// </summary>
        private Button CreatePaginationButton(string text, int pageNumber)
        {
            var btn = new Button
            {
                Text = text,
                Size = new Size(35, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(74, 144, 226),
                Tag = pageNumber,
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderColor = Color.FromArgb(74, 144, 226);
            btn.FlatAppearance.BorderSize = 1;

            btn.Click += (s, e) =>
            {
                currentPage = (int)btn.Tag;
                RefreshDataGridView();
                UpdatePageInfo();
            };

            return btn;
        }

        /// <summary>
        /// Sự kiện thêm khách hàng mới
        /// </summary>
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addForm = new frmAddCustomer())
                {
                    if (addForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh danh sách sau khi thêm thành công
                        LoadCustomers();
                        MessageBox.Show("Thêm khách hàng thành công!", "Thông báo",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form thêm khách hàng: {ex.Message}",
              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện tìm kiếm khi nhập text
        /// </summary>
        private void TxtSearchUser_TextChanged(object sender, EventArgs e)
        {
            // Delay search để tránh tìm kiếm quá nhiều lần
            searchTimer?.Stop();
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 200; // 200ms delay
            searchTimer.Tick += (s, args) =>
                   {
                       searchTimer.Stop();
                       SearchCustomers();
                   };
            searchTimer.Start();
        }

        /// <summary>
        /// Sự kiện nhấn Enter để tìm kiếm
        /// </summary>
        private void TxtSearchUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                searchTimer?.Stop();
                SearchCustomers();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Sự kiện click vào DataGridView
        /// </summary>
        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var khId = (int)dgvUsers.Rows[e.RowIndex].Tag;
            string columnName = dgvUsers.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "colEdit":
                    EditCustomer(khId);
                    break;
                case "colDelete":
                    DeleteCustomer(khId);
                    break;
            }
        }

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        private void EditCustomer(int khId)
        {
            try
            {
                var customer = CustomerRepository.GetCustomerById(khId);
                if (customer == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo form edit (có thể tái sử dụng frmAddCustomer)
                using (var editForm = new frmAddCustomer())
                {
                    editForm.Text = "Sửa thông tin khách hàng";
                    // editForm.SetCustomerInfo(customer); // Cần implement method này

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadCustomers();
                        MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa thông tin khách hàng: {ex.Message}",
             "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        private void DeleteCustomer(int khId)
        {
            try
            {
                var customer = CustomerRepository.GetCustomerById(khId);
                if (customer == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show(
                 $"Bạn có chắc chắn muốn xóa khách hàng '{customer.TenKhach}'?\n" +
                          "Lưu ý: Chỉ có thể xóa khách hàng chưa có hóa đơn nào.",
                 "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = CustomerRepository.DeleteCustomer(khId);
                    if (success)
                    {
                        LoadCustomers();
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa khách hàng: {ex.Message}",
          "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Format hiển thị cho DataGridView
        /// </summary>
        private void DgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                // Format cho cột ngày tạo
                if (dgvUsers.Columns[e.ColumnIndex].Name == "colNgayTao" && e.Value != null)
                {
                    if (DateTime.TryParse(e.Value.ToString(), out DateTime date))
                    {
                        e.Value = date.ToString("dd/MM/yyyy");
                        e.FormattingApplied = true;
                    }
                }

                // Highlight khách vãng lai
                if (e.RowIndex >= 0)
                {
                    var tenKhach = dgvUsers.Rows[e.RowIndex].Cells["colHoTen"].Value?.ToString();
                    if (tenKhach == "Khách vãng lai" || string.IsNullOrEmpty(tenKhach))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 248, 220); // Light yellow
                        e.CellStyle.ForeColor = Color.FromArgb(133, 77, 14); // Dark yellow
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi formatting: {ex.Message}");
            }
        }

        /// <summary>
        /// Refresh danh sách (có thể gọi từ form khác)
        /// </summary>
        public void RefreshCustomerList()
        {
            LoadCustomers();
        }
    }
}
