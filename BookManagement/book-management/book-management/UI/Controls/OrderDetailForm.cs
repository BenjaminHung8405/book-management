// book-management\UI\OrderDetailForm.cs
using System.Windows.Forms;
using book_management.Models;
using System.Collections.Generic;
using System.Drawing;
namespace book_management.UI
{
    public partial class OrderDetailForm : Form
    {
        private List<ChiTietHoaDon> _chiTietHD;

        public OrderDetailForm(List<ChiTietHoaDon> chiTietHD)
        {
            InitializeComponent();
            _chiTietHD = chiTietHD;
            LoadOrderDetails();
        }

        private void InitializeComponent()
        {
            this.Text = "Chi tiết hóa đơn";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            
            var dgvDetail = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true
            };

         
            dgvDetail.Columns.Add("TenSach", "Tên sách");
            dgvDetail.Columns.Add("DonGia", "Đơn giá");
            dgvDetail.Columns.Add("SoLuong", "Số lượng");
            dgvDetail.Columns.Add("GiamGia", "Giảm giá");
            dgvDetail.Columns.Add("ThanhTien", "Thành tiền");

            this.Controls.Add(dgvDetail);
        }

        private void LoadOrderDetails()
        {
            var dgv = this.Controls[0] as DataGridView;
            if (dgv != null)
            {
                dgv.Rows.Clear();
                foreach (var item in _chiTietHD)
                {
                    dgv.Rows.Add(
                        item.TenSach,
                        item.DonGia.ToString("N0") + " ?",
                        item.SoLuong,
                        item.TienGiam.ToString("N0") + " ?",
                        item.ThanhTien.ToString("N0") + " ?"
                    );
                }
            }
        }
    }
}