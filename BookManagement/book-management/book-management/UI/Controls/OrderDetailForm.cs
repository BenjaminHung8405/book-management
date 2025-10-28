// book-management\UI\OrderDetailForm.cs
using System.Windows.Forms;
using book_management.Models;

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
            this.Text = "Chi ti?t h�a ??n";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            // T?o DataGridView ?? hi?n th? chi ti?t
            var dgvDetail = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true
            };

            // Th�m c�c c?t
            dgvDetail.Columns.Add("TenSach", "T�n s�ch");
            dgvDetail.Columns.Add("DonGia", "??n gi�");
            dgvDetail.Columns.Add("SoLuong", "S? l??ng");
            dgvDetail.Columns.Add("GiamGia", "Gi?m gi�");
            dgvDetail.Columns.Add("ThanhTien", "Th�nh ti?n");

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
                        item.GiamGia.ToString("N0") + " ?",
                        item.ThanhTien.ToString("N0") + " ?"
                    );
                }
            }
        }
    }
}