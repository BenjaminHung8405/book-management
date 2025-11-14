using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace book_management.UI.Controls
{
    public partial class ucOrderItem : UserControl
    {
        private dynamic _item;

        // Fired when quantity or line total changes
        public event EventHandler QuantityChanged;
        // Fired when user requests removal of this item
        public event EventHandler Removed;

        public ucOrderItem()
        {
            InitializeComponent();

            // Wire events
            btnIncrease.Click += BtnIncrease_Click;
            btnDecrease.Click += BtnDecrease_Click;
            btnRemoveItem.Click += BtnRemoveItem_Click;
            txtQuantity.TextChanged += TxtQuantity_TextChanged;

            // Ensure numeric-only input for quantity
            txtQuantity.KeyPress += (s, e) =>
            {
                // allow control keys and digits
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };
        }

        public void SetData(dynamic item)
        {
            _item = item;
            // Ensure fields exist
            if (_item == null) return;

            lblBookTitle.Text = _item.TenSach ?? string.Empty;
            lblBookPrice.Text = "Đơn giá: " + (Convert.ToDecimal(_item.DonGia)).ToString("N0") + "₫";
            txtQuantity.Text = (_item.SoLuong ?? 1).ToString();
            lblLineTotal.Text = (Convert.ToDecimal(_item.ThanhTien)).ToString("N0") + "₫";

            // Try to load cover image asynchronously (non-blocking)
            try
            {
                string url = _item.AnhBiaUrl as string;
                if (!string.IsNullOrEmpty(url))
                {
                    var _ = book_management.Helpers.ImageLoader.LoadIntoPictureBoxAsync(url, picBookCover, null);
                }
            }
            catch
            {
                // ignore image load failures
            }
        }

        private void UpdateFromQuantity(int qty)
        {
            if (_item == null) return;
            if (qty < 1) qty = 1;
            _item.SoLuong = qty;
            _item.ThanhTien = Convert.ToDecimal(_item.DonGia) * _item.SoLuong;

            txtQuantity.Text = _item.SoLuong.ToString();
            lblLineTotal.Text = Convert.ToDecimal(_item.ThanhTien).ToString("N0") + "₫";

            QuantityChanged?.Invoke(this, EventArgs.Empty);
        }

        private void BtnIncrease_Click(object sender, EventArgs e)
        {
            int q = 1;
            int.TryParse(txtQuantity.Text, out q);
            q++;
            UpdateFromQuantity(q);
        }

        private void BtnDecrease_Click(object sender, EventArgs e)
        {
            int q = 1;
            int.TryParse(txtQuantity.Text, out q);
            q = Math.Max(1, q - 1);
            UpdateFromQuantity(q);
        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            int q;
            if (int.TryParse(txtQuantity.Text, out q) && q > 0)
            {
                UpdateFromQuantity(q);
            }
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            Removed?.Invoke(this, EventArgs.Empty);
        }

        // Expose current line total for parent to compute totals
        public decimal GetLineTotal()
        {
            if (_item == null) return 0m;
            return Convert.ToDecimal(_item.ThanhTien);
        }

        // Expose item id if needed
        public int GetSachId()
        {
            if (_item == null) return 0;
            return Convert.ToInt32(_item.SachId);
        }

        // Public helpers for parent to modify quantity
        public void AddQuantity(int delta)
        {
            int q = 1;
            int.TryParse(txtQuantity.Text, out q);
            q += delta;
            UpdateFromQuantity(q);
        }

        public void SetQuantity(int qty)
        {
            UpdateFromQuantity(qty);
        }
    }
}
