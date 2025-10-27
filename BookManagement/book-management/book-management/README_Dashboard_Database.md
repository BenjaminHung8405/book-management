# H??ng d?n Dashboard v?i D? li?u Database

## ?? **T?ng quan**
DashboardControl ?� ???c c?p nh?t ?? s? d?ng d? li?u th?c t? database thay v� mock data. Dashboard hi?n hi?n th?:

- **Bi?u ?? doanh thu** 7 ng�y g?n nh?t
- **Danh s�ch h�a ??n** g?n ?�y
- **Th?ng k� t?ng quan** (hi?n th? trong console/debug)

## ?? **C�c th�nh ph?n ?� c?p nh?t**

### ? **1. DashboardRepository.cs**
Repository m?i ch?a c�c ph??ng th?c:

#### **GetRecentOrders(int top = 10)**
```sql
-- L?y h�a ??n g?n ?�y v?i th�ng tin kh�ch h�ng
SELECT TOP 10
    hd.hoadon_id,
    CASE 
        WHEN hd.kh_id IS NOT NULL THEN kh.ten_khach
        WHEN hd.ten_khach_vang_lai IS NOT NULL THEN hd.ten_khach_vang_lai
        ELSE N'Kh�ch v�ng lai'
    END as ten_khach,
    hd.ngay_lap,
    hd.tong_tien,
    hd.trang_thai
FROM HoaDon hd
LEFT JOIN KhachHang kh ON hd.kh_id = kh.kh_id
ORDER BY hd.ngay_lap DESC
```

#### **GetLast7DaysRevenue()**
```sql
-- Doanh thu 7 ng�y g?n nh?t
SELECT 
    CAST(hd.ngay_lap AS DATE) as ngay,
    SUM(hd.tong_tien) as doanh_thu,
COUNT(hd.hoadon_id) as so_don_hang
FROM HoaDon hd
WHERE hd.trang_thai = 'DaThanhToan'
    AND CAST(hd.ngay_lap AS DATE) BETWEEN @FromDate AND @ToDate
GROUP BY CAST(hd.ngay_lap AS DATE)
ORDER BY CAST(hd.ngay_lap AS DATE)
```

#### **GetDashboardStats()**
```sql
-- Th?ng k� t?ng quan
SELECT 
    -- Doanh thu h�m nay
    (SELECT ISNULL(SUM(tong_tien), 0) 
     FROM HoaDon 
     WHERE trang_thai = 'DaThanhToan' 
 AND CAST(ngay_lap AS DATE) = CAST(GETDATE() AS DATE)) as doanh_thu_hom_nay,
    
    -- Doanh thu th�ng n�y
    (SELECT ISNULL(SUM(tong_tien), 0) 
   FROM HoaDon 
     WHERE trang_thai = 'DaThanhToan' 
     AND MONTH(ngay_lap) = MONTH(GETDATE()) 
     AND YEAR(ngay_lap) = YEAR(GETDATE())) as doanh_thu_thang_nay,
    
    -- S? ??n h�ng, s�ch trong kho, kh�ch h�ng, nh�n vi�n...
```

#### **GetTopSellingBooks(int top = 5)**
```sql
-- Top s�ch b�n ch?y
SELECT TOP 5
    s.sach_id,
    s.ten_sach,
  SUM(cthd.so_luong) as tong_ban,
    SUM(cthd.thanh_tien) as doanh_thu,
    -- Concat t�n t�c gi?
FROM Sach s
INNER JOIN ChiTietHoaDon cthd ON s.sach_id = cthd.sach_id
INNER JOIN HoaDon hd ON cthd.hoadon_id = hd.hoadon_id
WHERE hd.trang_thai = 'DaThanhToan'
GROUP BY s.sach_id, s.ten_sach
ORDER BY SUM(cthd.so_luong) DESC
```

### ? **2. DashboardControl.cs (?� c?p nh?t)**

#### **LoadRevenueChart()**
- L?y d? li?u 7 ng�y g?n nh?t t? database
- T? ??ng ?i?n 0 cho ng�y kh�ng c� doanh thu
- Format hi?n th? ??p v?i currency format
- Hi?n th? gi� tr? tr�n ?i?m

#### **LoadRecentSales()**
- L?y 10 h�a ??n g?n nh?t
- Format m� h�a ??n: `HD-0001`
- Chuy?n ??i tr?ng th�i: `DaThanhToan` ? `?� thanh to�n`
- X? l� kh�ch v�ng lai v� kh�ch h�ng c� ID

#### **LoadDashboardStats()**
- L?y th?ng k� t?ng quan
- Hi?n th? trong Debug console
- S?n s�ng ?? bind v�o labels/cards

#### **Error Handling & Fallback**
- Try-catch bao quanh t?t c? database calls
- Fallback v? mock data n?u database l?i
- Hi?n th? message box th�ng b�o l?i

## ?? **T�nh n?ng m?i**

### **?? Bi?u ?? th�ng minh**
```csharp
// Chart t? ??ng load 7 ng�y g?n nh?t
var revenueData = DashboardRepository.GetLast7DaysRevenue();
foreach (dynamic revenue in revenueData)
{
    DateTime date = revenue.Ngay;
    decimal amount = revenue.DoanhThu;
    string dateLabel = date.ToString("dd/MM");
    seriesDoanhThu.Points.AddXY(dateLabel, (double)amount);
}
```

### **?? Refresh t? ??ng**
```csharp
// Method public ?? refresh dashboard
public void RefreshDashboard()
{
  LoadRevenueChart();
    LoadRecentSales();
    LoadDashboardStats();
}
```

### **?? Styling ??p**
- Chart v?i m�u s?c professional
- DataGridView v?i style Tailwind CSS
- Status badges v?i m�u theo tr?ng th�i
- Currency formatting t? ??ng

## ?? **C�ch s? d?ng trong th?c t?**

### **1. Th�m v�o MainForm**
```csharp
private void btnRefreshDashboard_Click(object sender, EventArgs e)
{
    if (panelContent.Controls[0] is DashboardControl dashboard)
    {
      dashboard.RefreshDashboard();
    }
}
```

### **2. Timer t? ??ng refresh**
```csharp
private Timer dashboardTimer;

private void SetupDashboardTimer()
{
 dashboardTimer = new Timer();
    dashboardTimer.Interval = 300000; // 5 ph�t
    dashboardTimer.Tick += (s, e) => RefreshDashboard();
    dashboardTimer.Start();
}
```

### **3. Th�m Labels ?? hi?n th? stats**
```csharp
// Trong LoadDashboardStats()
if (stats != null)
{
    lblDoanhThuHomNay.Text = stats.DoanhThuHomNay.ToString("C0");
    lblDoanhThuThang.Text = stats.DoanhThuThangNay.ToString("C0");
    lblDonHangHomNay.Text = stats.DonHangHomNay.ToString();
    lblTongSach.Text = stats.TongSoSach.ToString();
    lblSachSapHet.Text = stats.SachSapHet.ToString();
}
```

## ??? **Error Handling**

### **Database Connection Issues**
```csharp
try
{
    LoadRevenueChart();
  LoadRecentSales();
    LoadDashboardStats();
}
catch (Exception ex)
{
    MessageBox.Show($"L?i khi t?i d? li?u dashboard:\n{ex.Message}", 
     "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
    // Fallback to mock data
    LoadMockDataFallback();
}
```

### **Missing Data Handling**
```csharp
// T? ??ng ?i?n 0 cho ng�y kh�ng c� d? li?u
for (int i = 0; i < 7; i++)
{
    var currentDate = fromDate.AddDays(i);
    var existingData = revenueData.FirstOrDefault(r => 
   ((DateTime)r.Ngay).Date == currentDate.Date);
    
    if (existingData == null)
    {
        // T?o data v?i 0
        dynamic emptyData = new ExpandoObject();
        emptyData.Ngay = currentDate;
        emptyData.DoanhThu = 0m;
        result.Add(emptyData);
    }
}
```

## ?? **K?t qu?**

Dashboard hi?n c� th?:
- ? **Hi?n th? doanh thu th?c** t? database
- ? **Danh s�ch h�a ??n th?c** v?i format ??p
- ? **Th?ng k� t?ng quan** ??y ??
- ? **Error handling** robust
- ? **Fallback mechanism** khi database l?i
- ? **Performance optimized** v?i top queries
- ? **Responsive design** v?i styling professional

**Dashboard production-ready v?i real-time data! ????**