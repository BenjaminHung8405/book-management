# H??ng d?n s? d?ng k?t n?i SQL Server v?i Windows Authentication

## C�c file ?� t?o:

### 1. DatabaseConnection.cs
- Qu?n l� k?t n?i ??n SQL Server
- S? d?ng Windows Authentication (Integrated Security=true)
- Cung c?p c�c ph??ng th?c:
  - `GetConnection()`: T?o k?t n?i m?i
  - `TestConnection()`: Ki?m tra k?t n?i
  - `GetConnectionString()`: L?y connection string

### 2. BookRepository.cs
- Ch?a c�c ph??ng th?c thao t�c v?i b?ng Sach
- C�c ph??ng th?c ch�nh:
  - `GetAllBooks()`: L?y t?t c? s�ch
  - `GetBookById(int id)`: L?y s�ch theo ID
  - `AddBook()`: Th�m s�ch m?i
  - `UpdateBook()`: C?p nh?t s�ch
  - `DeleteBook()`: X�a s�ch

### 3. MockDatabase.cs (?� c?p nh?t)
- Th�m kh? n?ng chuy?n ??i gi?a mock data v� real database
- Property `UseMockData` ?? b?t/t?t mock mode
- T? ??ng fallback v? mock data n?u kh�ng k?t n?i ???c database

### 4. DatabaseTestForm.cs
- Form ?? test k?t n?i database
- C�c ch?c n?ng:
  - Test Connection: Ki?m tra k?t n?i
  - Toggle Mode: Chuy?n ??i gi?a mock/real data  
- Load Books: T?i v� hi?n th? danh s�ch s�ch

### 5. CreateDatabase.sql
- Script SQL ?? t?o database v� table
- T?o stored procedures
- Th�m d? li?u m?u

## C�ch s? d?ng:

### B??c 1: T?o Database
1. M? SQL Server Management Studio
2. Connect v?i Windows Authentication
3. Ch?y script `CreateDatabase.sql`

### B??c 2: C?u h�nh Connection String
Trong `DatabaseConnection.cs`, c?p nh?t connection string n?u c?n:
```csharp
private static readonly string connectionString = 
    @"Server=localhost;Database=BookManagement;Integrated Security=true;";
```

Thay `localhost` b?ng t�n server c?a b?n n?u kh�c.

### B??c 3: Test k?t n?i
1. Ch?y ?ng d?ng
2. S? d?ng `DatabaseTestForm` ?? ki?m tra k?t n?i
3. Ho?c g?i `Database.TestDatabaseConnection()` trong code

### B??c 4: S? d?ng trong ?ng d?ng
```csharp
// T? ??ng ch?n gi?a mock data v� real database
var books = Database.GetAllBooks();

// Ho?c s? d?ng tr?c ti?p repository
var books = BookRepository.GetAllBooks();

// Th�m s�ch m?i
int newId = BookRepository.AddBook("T�n s�ch", "T�c gi?", 100000, "url_anh");
```

## L?u �:
- S? d?ng System.Data.SqlClient (c� s?n trong .NET Framework 4.8)
- Kh�ng c?n c�i th�m package Microsoft.Data.SqlClient
- T? ??ng fallback v? mock data n?u kh�ng k?t n?i ???c database
- T?t c? connection ???c dispose t? ??ng v?i using statement

## Troubleshooting:
1. **Kh�ng k?t n?i ???c SQL Server:**
   - Ki?m tra SQL Server ?� ch?y ch?a
   - Ki?m tra Windows Authentication ?� enable ch?a
   - Ki?m tra t�n server trong connection string

2. **Database kh�ng t?n t?i:**
   - Ch?y script CreateDatabase.sql
   - Ho?c thay ??i t�n database trong connection string

3. **L?i quy?n truy c?p:**
   - ??m b?o user Windows hi?n t?i c� quy?n truy c?p SQL Server
   - Th�m user v�o SQL Server n?u c?n