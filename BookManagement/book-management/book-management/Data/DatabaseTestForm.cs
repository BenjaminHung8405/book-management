using System;
using System.Windows.Forms;
using book_management.Data;

namespace book_management.Data
{
 public partial class DatabaseTestForm : Form
    {
        private Button btnTestConnection;
private Button btnToggleMode;
        private Label lblStatus;
        private Label lblMode;
        private Button btnLoadBooks;
        private ListBox lstBooks;

        public DatabaseTestForm()
        {
            InitializeComponent();
     }

        private void InitializeComponent()
    {
 this.btnTestConnection = new Button();
    this.btnToggleMode = new Button();
            this.lblStatus = new Label();
 this.lblMode = new Label();
     this.btnLoadBooks = new Button();
      this.lstBooks = new ListBox();
     this.SuspendLayout();

      // btnTestConnection
 this.btnTestConnection.Location = new System.Drawing.Point(12, 12);
            this.btnTestConnection.Name = "btnTestConnection";
  this.btnTestConnection.Size = new System.Drawing.Size(150, 30);
    this.btnTestConnection.Text = "Test Connection";
       this.btnTestConnection.UseVisualStyleBackColor = true;
      this.btnTestConnection.Click += new EventHandler(this.btnTestConnection_Click);

       // btnToggleMode
        this.btnToggleMode.Location = new System.Drawing.Point(180, 12);
   this.btnToggleMode.Name = "btnToggleMode";
     this.btnToggleMode.Size = new System.Drawing.Size(120, 30);
    this.btnToggleMode.Text = "Load Books";
       this.btnToggleMode.UseVisualStyleBackColor = true;
    this.btnToggleMode.Click += new EventHandler(this.btnToggleMode_Click);

        // lblStatus
            this.lblStatus.AutoSize = true;
   this.lblStatus.Location = new System.Drawing.Point(12, 55);
        this.lblStatus.Name = "lblStatus";
   this.lblStatus.Size = new System.Drawing.Size(85, 13);
    this.lblStatus.Text = "Status: Unknown";

// lblMode
 this.lblMode.AutoSize = true;
      this.lblMode.Location = new System.Drawing.Point(12, 75);
        this.lblMode.Name = "lblMode";
          this.lblMode.Size = new System.Drawing.Size(85, 13);
      this.lblMode.Text = "Database Connection";

  // btnLoadBooks
     this.btnLoadBooks.Location = new System.Drawing.Point(12, 100);
            this.btnLoadBooks.Name = "btnLoadBooks";
            this.btnLoadBooks.Size = new System.Drawing.Size(100, 30);
          this.btnLoadBooks.Text = "Load Books";
     this.btnLoadBooks.UseVisualStyleBackColor = true;
      this.btnLoadBooks.Click += new EventHandler(this.btnLoadBooks_Click);

       // lstBooks
        this.lstBooks.FormattingEnabled = true;
    this.lstBooks.Location = new System.Drawing.Point(12, 140);
     this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(560, 250);
    this.lstBooks.TabIndex = 5;

       // DatabaseTestForm
 this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
  this.ClientSize = new System.Drawing.Size(584, 411);
     this.Controls.Add(this.lstBooks);
       this.Controls.Add(this.btnLoadBooks);
  this.Controls.Add(this.lblMode);
   this.Controls.Add(this.lblStatus);
 this.Controls.Add(this.btnToggleMode);
     this.Controls.Add(this.btnTestConnection);
            this.Name = "DatabaseTestForm";
     this.Text = "Database Connection Test";
            this.Load += new EventHandler(this.DatabaseTestForm_Load);
            this.ResumeLayout(false);
  this.PerformLayout();
     }

 private void DatabaseTestForm_Load(object sender, EventArgs e)
      {
 TestConnectionStatus();
    }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
     TestConnectionStatus();
    }

private void TestConnectionStatus()
      {
            try
            {
    bool canConnect = DatabaseConnection.TestConnection();
       if (canConnect)
         {
            lblStatus.Text = "Status: Database Connected ?";
     lblStatus.ForeColor = System.Drawing.Color.Green;
        }
       else
    {
    lblStatus.Text = "Status: Database Not Available ?";
        lblStatus.ForeColor = System.Drawing.Color.Red;
      }
      }
 catch (Exception ex)
  {
 lblStatus.Text = "Status: Error - " + ex.Message;
     lblStatus.ForeColor = System.Drawing.Color.Red;
      }
      }

   private void btnToggleMode_Click(object sender, EventArgs e)
   {
    LoadBooksFromDatabase();
        }

        private void btnLoadBooks_Click(object sender, EventArgs e)
   {
 LoadBooksFromDatabase();
}

 private void LoadBooksFromDatabase()
  {
 try
  {
   lstBooks.Items.Clear();
   var books = BookRepository.GetAllBooks();
 
  foreach (dynamic book in books)
  {
        string bookInfo = $"ID: {book.SachId} - {book.TenSach} - {book.TacGia} - {book.Gia:C}";
   lstBooks.Items.Add(bookInfo);
     }

        MessageBox.Show($"?ã t?i {books.Count} cu?n sách t? database.", "Thông báo", 
       MessageBoxButtons.OK, MessageBoxIcon.Information);
       }
     catch (Exception ex)
    {
                MessageBox.Show($"L?i khi t?i sách: {ex.Message}", "L?i", 
           MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
}
    }
}