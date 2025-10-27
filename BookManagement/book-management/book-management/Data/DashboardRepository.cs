using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq; // Thêm namespace ?? s? d?ng LINQ

namespace book_management.Data
{
    public class DashboardRepository
    {
        /// <summary>
        /// L?y danh sách hóa ??n g?n ?ây
        /// </summary>
   /// <param name="top">S? l??ng hóa ??n l?y v? (m?c ??nh 10)</param>
        /// <returns>Danh sách hóa ??n</returns>
  public static List<dynamic> GetRecentOrders(int top = 10)
    {
        var orders = new List<dynamic>();
  try
      {
   using (var connection = DatabaseConnection.GetConnection())
        {
        connection.Open();
         
      string query = $@"
        SELECT TOP {top}
            hd.hoadon_id,
        CASE 
    WHEN hd.kh_id IS NOT NULL THEN kh.ten_khach
  WHEN hd.ten_khach_vang_lai IS NOT NULL THEN hd.ten_khach_vang_lai
       ELSE N'Khách vãng lai'
             END as ten_khach,
      hd.ngay_lap,
     hd.tong_tien,
          hd.trang_thai
        FROM HoaDon hd
  LEFT JOIN KhachHang kh ON hd.kh_id = kh.kh_id
 ORDER BY hd.ngay_lap DESC";
        
     using (var command = new SqlCommand(query, connection))
          {
        using (var reader = command.ExecuteReader())
        {
   while (reader.Read())
    {
     dynamic order = new System.Dynamic.ExpandoObject();
     order.HoaDonId = reader["hoadon_id"];
  order.TenKhach = reader["ten_khach"]?.ToString() ?? "Khách vãng lai";
 order.NgayLap = reader["ngay_lap"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_lap"]) : DateTime.MinValue;
      order.TongTien = reader["tong_tien"] != DBNull.Value ? Convert.ToDecimal(reader["tong_tien"]) : 0m;
         order.TrangThai = reader["trang_thai"]?.ToString() ?? "ChuaThanhToan";
        
       orders.Add(order);
   }
       }
          }
 }
          }
 catch (Exception ex)
      {
     throw new Exception($"L?i khi l?y danh sách hóa ??n: {ex.Message}", ex);
     }
  
 return orders;
      }

        /// <summary>
      /// L?y doanh thu theo ngày trong kho?ng th?i gian
  /// </summary>
/// <param name="fromDate">T? ngày</param>
    /// <param name="toDate">??n ngày</param>
  /// <returns>Doanh thu theo ngày</returns>
        public static List<dynamic> GetRevenueByDate(DateTime fromDate, DateTime toDate)
  {
    var revenueData = new List<dynamic>();
            try
          {
         using (var connection = DatabaseConnection.GetConnection())
  {
   connection.Open();
 
   string query = @"
         SELECT 
   CAST(hd.ngay_lap AS DATE) as ngay,
 SUM(hd.tong_tien) as doanh_thu,
COUNT(hd.hoadon_id) as so_don_hang
      FROM HoaDon hd
    WHERE hd.trang_thai = N'DaThanhToan'
        AND CAST(hd.ngay_lap AS DATE) BETWEEN @FromDate AND @ToDate
   GROUP BY CAST(hd.ngay_lap AS DATE)
      ORDER BY CAST(hd.ngay_lap AS DATE)";
     
       using (var command = new SqlCommand(query, connection))
         {
        command.Parameters.AddWithValue("@FromDate", fromDate.Date);
             command.Parameters.AddWithValue("@ToDate", toDate.Date);
     
        using (var reader = command.ExecuteReader())
       {
           while (reader.Read())
     {
     dynamic revenue = new System.Dynamic.ExpandoObject();
   revenue.Ngay = reader["ngay"] != DBNull.Value ? Convert.ToDateTime(reader["ngay"]) : DateTime.MinValue;
     revenue.DoanhThu = reader["doanh_thu"] != DBNull.Value ? Convert.ToDecimal(reader["doanh_thu"]) : 0m;
    revenue.SoDonHang = reader["so_don_hang"] != DBNull.Value ? Convert.ToInt32(reader["so_don_hang"]) : 0;
       
     revenueData.Add(revenue);
     }
         }
}
}
            }
          catch (Exception ex)
     {
 throw new Exception($"L?i khi l?y doanh thu theo ngày: {ex.Message}", ex);
     }
     
      return revenueData;
        }

     /// <summary>
      /// L?y th?ng kê t?ng quan
     /// </summary>
        /// <returns>Th?ng kê dashboard</returns>
        public static dynamic GetDashboardStats()
    {
 try
    {
             using (var connection = DatabaseConnection.GetConnection())
  {
       connection.Open();
        
  string query = @"
   SELECT 
         -- T?ng doanh thu hôm nay
       (SELECT ISNULL(SUM(tong_tien), 0) 
  FROM HoaDon 
     WHERE trang_thai = N'DaThanhToan' 
        AND CAST(ngay_lap AS DATE) = CAST(GETDATE() AS DATE)) as doanh_thu_hom_nay,
           
           -- T?ng doanh thu tháng này
          (SELECT ISNULL(SUM(tong_tien), 0) 
     FROM HoaDon 
         WHERE trang_thai = N'DaThanhToan' 
    AND MONTH(ngay_lap) = MONTH(GETDATE()) 
    AND YEAR(ngay_lap) = YEAR(GETDATE())) as doanh_thu_thang_nay,

    -- S? ??n hàng hôm nay
         (SELECT COUNT(*) 
       FROM HoaDon 
 WHERE CAST(ngay_lap AS DATE) = CAST(GETDATE() AS DATE)) as don_hang_hom_nay,
      
        -- S? ??n hàng tháng này
    (SELECT COUNT(*) 
     FROM HoaDon 
        WHERE MONTH(ngay_lap) = MONTH(GETDATE()) 
   AND YEAR(ngay_lap) = YEAR(GETDATE())) as don_hang_thang_nay,
    
  -- T?ng s? sách trong kho
        (SELECT ISNULL(SUM(so_luong), 0) 
   FROM Sach 
           WHERE trang_thai = 1) as tong_so_sach,
 
       -- S? sách s?p h?t (< 10)
              (SELECT COUNT(*) 
         FROM Sach 
   WHERE trang_thai = 1 AND so_luong < 10) as sach_sap_het,
    
          -- S? khách hàng
 (SELECT COUNT(*) FROM KhachHang) as so_khach_hang,
       
     -- S? nhân viên
  (SELECT COUNT(*) FROM NguoiDung WHERE vai_tro IN (N'Admin', N'NhanVien')) as so_nhan_vien";
     
       using (var command = new SqlCommand(query, connection))
         {
  using (var reader = command.ExecuteReader())
     {
        if (reader.Read())
 {
     dynamic stats = new System.Dynamic.ExpandoObject();
         stats.DoanhThuHomNay = reader["doanh_thu_hom_nay"] != DBNull.Value ? Convert.ToDecimal(reader["doanh_thu_hom_nay"]) : 0m;
 stats.DoanhThuThangNay = reader["doanh_thu_thang_nay"] != DBNull.Value ? Convert.ToDecimal(reader["doanh_thu_thang_nay"]) : 0m;
   stats.DonHangHomNay = reader["don_hang_hom_nay"] != DBNull.Value ? Convert.ToInt32(reader["don_hang_hom_nay"]) : 0;
        stats.DonHangThangNay = reader["don_hang_thang_nay"] != DBNull.Value ? Convert.ToInt32(reader["don_hang_thang_nay"]) : 0;
  stats.TongSoSach = reader["tong_so_sach"] != DBNull.Value ? Convert.ToInt32(reader["tong_so_sach"]) : 0;
     stats.SachSapHet = reader["sach_sap_het"] != DBNull.Value ? Convert.ToInt32(reader["sach_sap_het"]) : 0;
       stats.SoKhachHang = reader["so_khach_hang"] != DBNull.Value ? Convert.ToInt32(reader["so_khach_hang"]) : 0;
  stats.SoNhanVien = reader["so_nhan_vien"] != DBNull.Value ? Convert.ToInt32(reader["so_nhan_vien"]) : 0;
     
    return stats;
    }
 }
          }
       }
            }
 catch (Exception ex)
            {
   throw new Exception($"L?i khi l?y th?ng kê dashboard: {ex.Message}", ex);
  }
        
          return null;
   }

        /// <summary>
        /// L?y top sách bán ch?y
        /// </summary>
    /// <param name="top">S? l??ng sách l?y v?</param>
        /// <returns>Top sách bán ch?y</returns>
      public static List<dynamic> GetTopSellingBooks(int top = 5)
        {
    var topBooks = new List<dynamic>();
 try
     {
     using (var connection = DatabaseConnection.GetConnection())
           {
     connection.Open();
    
  string query = $@"
       SELECT TOP {top}
   s.sach_id,
      s.ten_sach,
             SUM(cthd.so_luong) as tong_ban,
           SUM(cthd.thanh_tien) as doanh_thu,
      STUFF((
         SELECT ', ' + tg.ten_tacgia
      FROM Sach_TacGia st
  INNER JOIN TacGia tg ON st.tacgia_id = tg.tacgia_id
 WHERE st.sach_id = s.sach_id
     FOR XML PATH('')), 1, 2, '') AS tac_gia
         FROM Sach s
     INNER JOIN ChiTietHoaDon cthd ON s.sach_id = cthd.sach_id
      INNER JOIN HoaDon hd ON cthd.hoadon_id = hd.hoadon_id
   WHERE hd.trang_thai = N'DaThanhToan'
    GROUP BY s.sach_id, s.ten_sach
  ORDER BY SUM(cthd.so_luong) DESC";
  
         using (var command = new SqlCommand(query, connection))
   {
using (var reader = command.ExecuteReader())
       {
       while (reader.Read())
         {
               dynamic book = new System.Dynamic.ExpandoObject();
   book.SachId = reader["sach_id"];
           book.TenSach = reader["ten_sach"]?.ToString() ?? "";
         book.TongBan = reader["tong_ban"] != DBNull.Value ? Convert.ToInt32(reader["tong_ban"]) : 0;
 book.DoanhThu = reader["doanh_thu"] != DBNull.Value ? Convert.ToDecimal(reader["doanh_thu"]) : 0m;
    book.TacGia = reader["tac_gia"]?.ToString() ?? "";
  
   topBooks.Add(book);
         }
       }
             }
   }
}
         catch (Exception ex)
      {
        throw new Exception($"L?i khi l?y top sách bán ch?y: {ex.Message}", ex);
       }
          
   return topBooks;
        }

        /// <summary>
        /// L?y doanh thu 7 ngày g?n nh?t
        /// </summary>
     /// <returns>Doanh thu 7 ngày</returns>
 public static List<dynamic> GetLast7DaysRevenue()
    {
 var fromDate = DateTime.Today.AddDays(-6); // 7 ngày bao g?m hôm nay
            var toDate = DateTime.Today;
   
            var revenueData = GetRevenueByDate(fromDate, toDate);
  
            // ??m b?o có ?? 7 ngày, ?i?n 0 cho nh?ng ngày không có d? li?u
     var result = new List<dynamic>();
      for (int i = 0; i < 7; i++)
     {
      var currentDate = fromDate.AddDays(i);
   
      // Tìm d? li?u cho ngày hi?n t?i
    dynamic existingData = null;
      foreach (dynamic r in revenueData)
      {
    if (((DateTime)r.Ngay).Date == currentDate.Date)
        {
          existingData = r;
        break;
      }
      }
      
      if (existingData != null)
       {
            result.Add(existingData);
    }
          else
     {
          dynamic emptyData = new System.Dynamic.ExpandoObject();
    emptyData.Ngay = currentDate;
             emptyData.DoanhThu = 0m;
   emptyData.SoDonHang = 0;
   result.Add(emptyData);
           }
  }
            
return result;
        }
    }
}