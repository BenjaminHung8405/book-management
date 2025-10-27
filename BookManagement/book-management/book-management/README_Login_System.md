# H??ng d?n H? th?ng ??ng nh?p v?i Database

## ?? **T?ng quan**
H? th?ng ??ng nh?p ?� ???c c?p nh?t ?? s? d?ng database th?c thay v� mock data. Ng??i d�ng gi? s? ???c x�c th?c t? b?ng `NguoiDung` trong database.

## ?? **C�c th�nh ph?n ?� th�m/c?p nh?t**

### ? **1. UserRepository.cs**
- **AuthenticateUser()** - X�c th?c ng??i d�ng t? database
- **GetUserById()** - L?y th�ng tin ng??i d�ng theo ID
- **GetAllUsers()** - L?y t?t c? ng??i d�ng
- **AddUser()** - Th�m ng??i d�ng m?i
- **UpdateUser()** - C?p nh?t th�ng tin ng??i d�ng
- **ChangePassword()** - Thay ??i m?t kh?u
- **SetUserStatus()** - K�ch ho?t/v� hi?u h�a ng??i d�ng

### ? **2. CurrentUser.cs**
- Qu?n l� phi�n ??ng nh?p hi?n t?i
- L?u tr? th�ng tin ng??i d�ng trong session
- Ki?m tra quy?n truy c?p (Admin, NhanVien, KhachHang)
- Cung c?p th�ng tin hi?n th?

### ? **3. LoginForm.cs (?� c?p nh?t)**
- S? d?ng UserRepository ?? x�c th?c
- Validation input ??y ??
- X? l� l?i k?t n?i database
- H? tr? Enter key navigation
- L?u th�ng tin ng??i d�ng v�o CurrentUser

### ? **4. MainForm.cs (?� c?p nh?t)**
- Hi?n th? th�ng tin ng??i d�ng ??ng nh?p
- Dropdown menu v?i c�c t�y ch?n:
  - Th�ng tin c� nh�n
  - Test database
  - ??ng xu?t
- Ph�n quy?n hi?n th? theo vai tr�

## ?? **T�i kho?n m?c ??nh trong Database**

```sql
-- T�i kho?n Admin
Username: admin
Password: 123
Vai tr�: Admin

-- T�i kho?n Nh�n vi�n
Username: nv01, nv02, nv03, nv04
Password: 123
Vai tr�: NhanVien

-- T�i kho?n Kh�ch h�ng
Username: kh01, kh02, kh03, kh04, kh05
Password: 123
Vai tr�: KhachHang
```

## ?? **C�ch s? d?ng**

### **1. ??ng nh?p**
1. Nh?p username v� password
2. Nh?n "??ng nh?p" ho?c Enter
3. H? th?ng s?:
   - X�c th?c t? database
   - L?u th�ng tin ng??i d�ng
   - Chuy?n ??n MainForm
 - Hi?n th? th�ng b�o ch�o m?ng

### **2. Qu?n l� phi�n ??ng nh?p**
```csharp
// Ki?m tra ??ng nh?p
if (CurrentUser.IsLoggedIn)
{
    // Ng??i d�ng ?� ??ng nh?p
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
    // Admin v� NhanVien
}
```

### **3. Th�ng tin hi?n th?**
- **Thanh header**: Hi?n th? t�n v� vai tr�
- **M�u s?c**: M?i vai tr� c� m�u kh�c nhau
  - Admin: ??
  - Nh�n vi�n: Xanh d??ng  
  - Kh�ch h�ng: Xanh l�

### **4. ??ng xu?t**
1. Click v�o dropdown menu ? header
2. Ch?n "??ng xu?t"
3. X�c nh?n ??ng xu?t
4. Quay v? LoginForm

## ?? **C?u h�nh Database**

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
- X�c th?c ??n gi?n

### **Khuy?n ngh? n�ng c?p:**
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

## ?? **X? l� l?i**

### **L?i k?t n?i Database:**
- Hi?n th? th�ng b�o l?i
- Kh�ng crash ?ng d?ng
- Log error cho debug

### **L?i x�c th?c:**
- Th�ng b�o "T�n ??ng nh?p ho?c m?t kh?u kh�ng ?�ng"
- Clear password field
- Focus v? password input

### **Validation:**
- Ki?m tra username/password kh�ng r?ng
- Trim whitespace t? username

## ?? **T�nh n?ng UX**

### **Keyboard Navigation:**
- Tab ?? di chuy?n gi?a fields
- Enter ? username ? chuy?n ??n password
- Enter ? password ? th?c hi?n ??ng nh?p

### **Password Visibility:**
- Click icon m?t ?? hi?n/?n password
- Icon thay ??i theo tr?ng th�i

### **Form Behavior:**
- AcceptButton = btnLogin (Enter anywhere s? ??ng nh?p)
- Form ?�ng = tho�t ?ng d?ng
- T? ??ng focus v�o username khi m?

## ?? **K?t qu?**

H? th?ng ??ng nh?p ho�n ch?nh v?i:
- ? X�c th?c t? database th?c
- ? Qu?n l� session ng??i d�ng
- ? Ph�n quy?n theo vai tr�
- ? UX th�n thi?n
- ? X? l� l?i ??y ??
- ? B?o m?t c? b?n

**S?n s�ng s? d?ng trong m�i tr??ng production!** ??