using book_management.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_management.UI.Modal
{
    public partial class frmAddEditBook : System.Windows.Forms.Form
    {
        private dynamic _bookToEdit;

        public frmAddEditBook(dynamic bookToEdit = null)
        {
            InitializeComponent();
            _bookToEdit = bookToEdit;

            // Set NumericUpDown constraints BEFORE setting values
            numGia.Maximum = 10000000;
            numGia.DecimalPlaces = 2;
            numSL.Maximum = 100000;
            numNamXB.Minimum = 1900;
            numNamXB.Maximum = 2100;
            numSoTrang.Maximum = 10000;

            // Set properties for Cancel button
            btnCancelModal.DialogResult = DialogResult.Cancel;

            // REMOVE: btnSaveBook.DialogResult = DialogResult.OK;
            // REMOVE: btnSaveBook.Click += btnSaveBook_Click;
            // These lines were causing auto-close on button click

            // Load combo boxes
            LoadComboBoxes();

            // Set title
            label1.Text = _bookToEdit != null ? "Sửa thông tin sách" : "Thêm sách mới";

            if (_bookToEdit != null)
            {
                LoadBookData();
            }
        }

        private void LoadComboBoxes()
        {
            // Authors
            var authors = BookRepository.GetAllAuthors();
            cbTacGia.DataSource = authors.Select(a => new { Text = a.TenTacGia, Value = a.TacGiaId }).ToList();
            cbTacGia.DisplayMember = "Text";
            cbTacGia.ValueMember = "Value";

            // Categories
            var categories = BookRepository.GetAllCategories();
            cbTheLoai.DataSource = categories.Select(c => new { Text = c.TenTheLoai, Value = c.TheLoaiId }).ToList();
            cbTheLoai.DisplayMember = "Text";
            cbTheLoai.ValueMember = "Value";

            // Status
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Còn hàng");
            cbTrangThai.Items.Add("Hết hàng");
        }

        private void LoadBookData()
        {
            txtTenSach.Text = _bookToEdit.TenSach;
            
            // Set Author by finding the first author name
            string[] authorNames = _bookToEdit.TacGia.Split(new[] { ", " }, StringSplitOptions.None);
            if (authorNames.Length > 0 && cbTacGia.DataSource != null)
            {
                string authorToFind = authorNames[0].Trim();
                // Iterate through the DataSource items without casting
                foreach (var item in (System.Collections.IEnumerable)cbTacGia.DataSource)
                {
                    if (item.GetType().GetProperty("Text")?.GetValue(item)?.ToString() == authorToFind)
                    {
                        cbTacGia.SelectedValue = item.GetType().GetProperty("Value")?.GetValue(item);
                        break;
                    }
                }
            }

            numGia.Value = _bookToEdit.Gia;
            
            // Set Category by finding the first category name
            string[] categoryNames = _bookToEdit.TheLoai.Split(new[] { ", " }, StringSplitOptions.None);
            if (categoryNames.Length > 0 && cbTheLoai.DataSource != null)
            {
                string categoryToFind = categoryNames[0].Trim();
                // Iterate through the DataSource items without casting
                foreach (var item in (System.Collections.IEnumerable)cbTheLoai.DataSource)
                {
                    if (item.GetType().GetProperty("Text")?.GetValue(item)?.ToString() == categoryToFind)
                    {
                        cbTheLoai.SelectedValue = item.GetType().GetProperty("Value")?.GetValue(item);
                        break;
                    }
                }
            }

            numSL.Value = _bookToEdit.SoLuong;
            txtNXB.Text = _bookToEdit.NhaXuatBan;
            numNamXB.Value = _bookToEdit.NamXuatBan > 0 ? _bookToEdit.NamXuatBan : 0;
            numSoTrang.Value = _bookToEdit.SoTrang > 0 ? _bookToEdit.SoTrang : 0;
            txtMoTa.Text = _bookToEdit.MoTa;
            txtNgonNgu.Text = _bookToEdit.NgonNgu;
            cbTrangThai.SelectedItem = _bookToEdit.TrangThai ? "Còn hàng" : "Hết hàng";
            txtURL.Text = _bookToEdit.AnhBiaUrl;
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbTacGia.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tác giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbTheLoai.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numGia.Value <= 0)
            {
                MessageBox.Show("Giá sách phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numSL.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string tenSach = txtTenSach.Text.Trim();
                var publishers = BookRepository.GetAllPublishers();
                var publisher = publishers.FirstOrDefault(p => p.TenNxb == txtNXB.Text.Trim());
                if (publisher == null)
                {
                    MessageBox.Show("Nhà xuất bản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int nxbId = publisher.NxbId;
                decimal gia = numGia.Value;
                int soLuong = (int)numSL.Value;
                string anhBiaUrl = txtURL.Text.Trim();
                List<int> tacGiaIds = cbTacGia.SelectedValue != null ? new List<int> { (int)cbTacGia.SelectedValue } : new List<int>();
                List<int> theLoaiIds = cbTheLoai.SelectedValue != null ? new List<int> { (int)cbTheLoai.SelectedValue } : new List<int>();
                int? namXuatBan = numNamXB.Value > 0 ? (int?)numNamXB.Value : null;
                int? soTrang = numSoTrang.Value > 0 ? (int?)numSoTrang.Value : null;
                string moTa = txtMoTa.Text.Trim();
                string ngonNgu = txtNgonNgu.Text.Trim();

                if (_bookToEdit != null)
                {
                    // Update
                    BookRepository.UpdateBook(_bookToEdit.SachId, tenSach, nxbId, gia, soLuong, anhBiaUrl, tacGiaIds, theLoaiIds, namXuatBan, soTrang, moTa, ngonNgu);
                    MessageBox.Show("Cập nhật sách thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Add
                    BookRepository.AddBook(tenSach, nxbId, gia, soLuong, anhBiaUrl, tacGiaIds, theLoaiIds, namXuatBan, soTrang, moTa, ngonNgu);
                    MessageBox.Show("Thêm sách thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Form stays open when error occurs - NO close here!
            }
        }

        private void btnCancelModal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
