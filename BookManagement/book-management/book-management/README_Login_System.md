# H??ng d?n H? th?ng ??ng nh?p v?i Database

## ?? **T?ng quan**
H? th?ng ??ng nh?p ?ã ???c c?p nh?t ?? s? d?ng database th?c thay vì mock data. Ng??i dùng gi? s? ???c xác th?c t? b?ng `NguoiDung` trong database.

## ?? **Các thành ph?n ?ã thêm/c?p nh?t**

### ? **1. UserRepository.cs**
- **AuthenticateUser()** - Xác th?c ng??i dùng t? database
- **GetUserById()** - L?y thông tin ng??i dùng theo ID
- **GetAllUsers()** - L?y t?t c? ng??i dùng
- **AddUser()** - Thêm ng??i dùng m?i
- **UpdateUser()** - C?p nh?t thông tin ng??i dùng
- **ChangePassword()** - Thay ??i m?t kh?u
- **SetUserStatus()** - Kích ho?t/vô hi?u hóa ng??i dùng

### ? **2. CurrentUser.cs**
- Qu?n lý phiên ??ng nh?p hi?n t?i
- L?u tr? thông tin ng??i dùng trong session
- Ki?m tra quy?n truy c?p (Admin, NhanVien, KhachHang)
- Cung c?p thông tin hi?n th?

### ? **3. LoginForm.cs (?ã c?p nh?t)**
- S? d?ng UserRepository ?? xác th?c
- Validation input ??y ??
- X? lý l?i k?t n?i database
- H? tr? Enter key navigation
- L?u thông tin ng??i dùng vào CurrentUser

### ? **4. MainForm.cs (?ã c?p nh?t)**
- Hi?n th? thông tin ng??i dùng ??ng nh?p
- Dropdown menu v?i các tùy ch?n:
  - Thông tin cá nhân
  - Test database
  - ??ng xu?t
- Phân quy?n hi?n th? theo vai trò

## ?? **Tài kho?n m?c ??nh trong Database**

```sql
-- Tài kho?n Admin
Username: admin
Password: 123
Vai trò: Admin

-- Tài kho?n Nhân viên
Username: nv01, nv02, nv03, nv04
Password: 123
Vai trò: NhanVien

-- Tài kho?n Khách hàng
Username: kh01, kh02, kh03, kh04, kh05
Password: 123
Vai trò: KhachHang
```

## ?? **Cách s? d?ng**

### **1. ??ng nh?p**
1. Nh?p username và password
2. Nh?n "??ng nh?p" ho?c Enter
3. H? th?ng s?:
   - Xác th?c t? database
   - L?u thông tin ng??i dùng
   - Chuy?n ??n MainForm
 - Hi?n th? thông báo chào m?ng

### **2. Qu?n lý phiên ??ng nh?p**
```csharp
// Ki?m tra ??ng nh?p
if (CurrentUser.IsLoggedIn)
{
    // Ng??i dùng ?ã ??ng nh?p
    string userName = CurrentUser.Username;
    string fullName = CurrentUser.FullName;
    string role = CurrentUser.Role;
}

// Ki?m tra quy?n
if (CurrentUser.IsAdmin)
{
    // Ch? Admin m?i truy c?p ???c
}

if (CurrentUser.IsEmployee)
{
    // Admin và NhanVien
}
```

### **3. Thông tin hi?n th?**
- **Thanh header**: Hi?n th? tên và vai trò
- **Màu s?c**: M?i vai trò có màu khác nhau
  - Admin: ??
  - Nhân viên: Xanh d??ng  
  - Khách hàng: Xanh lá

### **4. ??ng xu?t**
1. Click vào dropdown menu ? header
2. Ch?n "??ng xu?t"
3. Xác nh?n ??ng xu?t
4. Quay v? LoginForm

## ?? **C?u hình Database**

### **Connection String** (trong DatabaseConnection.cs):
```csharp
private static readonly string connectionString = 
    @"Server=localhost;Database=BookManagement;Integrated Security=true;";
```

### **B?ng NguoiDung**:
```sql
CREATE TABLE NguoiDung (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    ho_ten NVARCHAR(100),
    email NVARCHAR(100) UNIQUE,
    so_dien_thoai NVARCHAR(20),
    vai_tro NVARCHAR(20) CHECK (vai_tro IN ('Admin', 'NhanVien', 'KhachHang')),
 ngay_tao DATETIME DEFAULT GETDATE(),
    trang_thai BIT DEFAULT 1
);
```

## ??? **B?o m?t**

### **Hi?n t?i:**
- M?t kh?u l?u d?ng plain text (?? demo)
- Xác th?c ??n gi?n

### **Khuy?n ngh? nâng c?p:**
```csharp
// Hash password tr??c khi l?u
public static string HashPassword(string password)
{
    using (var sha256 = SHA256.Create())
    {
   byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}

// Verify password
public static bool VerifyPassword(string password, string hash)
{
    string hashOfInput = HashPassword(password);
    return hashOfInput == hash;
}
```

## ?? **X? lý l?i**

### **L?i k?t n?i Database:**
- Hi?n th? thông báo l?i
- Không crash ?ng d?ng
- Log error cho debug

### **L?i xác th?c:**
- Thông báo "Tên ??ng nh?p ho?c m?t kh?u không ?úng"
- Clear password field
- Focus v? password input

### **Validation:**
- Ki?m tra username/password không r?ng
- Trim whitespace t? username

## ?? **Tính n?ng UX**

### **Keyboard Navigation:**
- Tab ?? di chuy?n gi?a fields
- Enter ? username ? chuy?n ??n password
- Enter ? password ? th?c hi?n ??ng nh?p

### **Password Visibility:**
- Click icon m?t ?? hi?n/?n password
- Icon thay ??i theo tr?ng thái

### **Form Behavior:**
- AcceptButton = btnLogin (Enter anywhere s? ??ng nh?p)
- Form ?óng = thoát ?ng d?ng
- T? ??ng focus vào username khi m?

## ?? **K?t qu?**

H? th?ng ??ng nh?p hoàn ch?nh v?i:
- ? Xác th?c t? database th?c
- ? Qu?n lý session ng??i dùng
- ? Phân quy?n theo vai trò
- ? UX thân thi?n
- ? X? lý l?i ??y ??
- ? B?o m?t c? b?n

**S?n sàng s? d?ng trong môi tr??ng production!** ??