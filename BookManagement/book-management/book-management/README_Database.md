# H??ng d?n s? d?ng k?t n?i SQL Server v?i Windows Authentication

## Các file ?ã t?o:

### 1. DatabaseConnection.cs
- Qu?n lý k?t n?i ??n SQL Server
- S? d?ng Windows Authentication (Integrated Security=true)
- Cung c?p các ph??ng th?c:
  - `GetConnection()`: T?o k?t n?i m?i
  - `TestConnection()`: Ki?m tra k?t n?i
  - `GetConnectionString()`: L?y connection string

### 2. BookRepository.cs
- Ch?a các ph??ng th?c thao tác v?i b?ng Sach
- Các ph??ng th?c chính:
  - `GetAllBooks()`: L?y t?t c? sách
  - `GetBookById(int id)`: L?y sách theo ID
  - `AddBook()`: Thêm sách m?i
  - `UpdateBook()`: C?p nh?t sách
  - `DeleteBook()`: Xóa sách

### 3. MockDatabase.cs (?ã c?p nh?t)
- Thêm kh? n?ng chuy?n ??i gi?a mock data và real database
- Property `UseMockData` ?? b?t/t?t mock mode
- T? ??ng fallback v? mock data n?u không k?t n?i ???c database

### 4. DatabaseTestForm.cs
- Form ?? test k?t n?i database
- Các ch?c n?ng:
  - Test Connection: Ki?m tra k?t n?i
  - Toggle Mode: Chuy?n ??i gi?a mock/real data  
- Load Books: T?i và hi?n th? danh sách sách

### 5. CreateDatabase.sql
- Script SQL ?? t?o database và table
- T?o stored procedures
- Thêm d? li?u m?u

## Cách s? d?ng:

### B??c 1: T?o Database
1. M? SQL Server Management Studio
2. Connect v?i Windows Authentication
3. Ch?y script `CreateDatabase.sql`

### B??c 2: C?u hình Connection String
Trong `DatabaseConnection.cs`, c?p nh?t connection string n?u c?n:
```csharp
private static readonly string connectionString = 
    @"Server=localhost;Database=BookManagement;Integrated Security=true;";
```

Thay `localhost` b?ng tên server c?a b?n n?u khác.

### B??c 3: Test k?t n?i
1. Ch?y ?ng d?ng
2. S? d?ng `DatabaseTestForm` ?? ki?m tra k?t n?i
3. Ho?c g?i `Database.TestDatabaseConnection()` trong code

### B??c 4: S? d?ng trong ?ng d?ng
```csharp
// T? ??ng ch?n gi?a mock data và real database
var books = Database.GetAllBooks();

// Ho?c s? d?ng tr?c ti?p repository
var books = BookRepository.GetAllBooks();

// Thêm sách m?i
int newId = BookRepository.AddBook("Tên sách", "Tác gi?", 100000, "url_anh");
```

## L?u ý:
- S? d?ng System.Data.SqlClient (có s?n trong .NET Framework 4.8)
- Không c?n cài thêm package Microsoft.Data.SqlClient
- T? ??ng fallback v? mock data n?u không k?t n?i ???c database
- T?t c? connection ???c dispose t? ??ng v?i using statement

## Troubleshooting:
1. **Không k?t n?i ???c SQL Server:**
   - Ki?m tra SQL Server ?ã ch?y ch?a
   - Ki?m tra Windows Authentication ?ã enable ch?a
   - Ki?m tra tên server trong connection string

2. **Database không t?n t?i:**
   - Ch?y script CreateDatabase.sql
   - Ho?c thay ??i tên database trong connection string

3. **L?i quy?n truy c?p:**
   - ??m b?o user Windows hi?n t?i có quy?n truy c?p SQL Server
   - Thêm user vào SQL Server n?u c?n