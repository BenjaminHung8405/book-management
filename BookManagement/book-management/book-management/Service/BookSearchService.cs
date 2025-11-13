using System;
using System.Collections.Generic;
using System.Linq;
using book_management.Data;
using book_management.Helpers;

namespace book_management.Services
{
    public static class BookSearchService
    {
        /// <summary>
        /// Tìm kiếm sách với từ khóa 
        /// </summary>
        public static List<dynamic> SearchBooks(List<dynamic> allBooks, string searchKeyword)
        {
            if (string.IsNullOrEmpty(searchKeyword))
                return allBooks.ToList();

            // Tìm kiếm trên local data trước
            var localResults = allBooks.Where(book =>
            {
                try
                {
                    string tenSach = book.TenSach?.ToString() ?? "";
                    string tacGia = book.TacGia?.ToString() ?? "";
                    string theLoai = book.TheLoai?.ToString() ?? "";
                    
                    return tenSach.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase)||
                           tacGia.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase)||
                           theLoai.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Search error for book: {ex.Message}");
                    return false;
                }
            }).ToList();

            // Nếu không tìm thấy, tìm kiếm từ database
            if (localResults.Count == 0)
            {
                try
                {
                    return BookRepository.SearchBooks(searchKeyword);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Database search error: {ex.Message}");
                    return new List<dynamic>();
                }
            }

            return localResults;
        }

        /// <summary>
        /// Lọc sách theo thể loại và trạng thái
        /// </summary>
        public static List<dynamic> FilterBooks(List<dynamic> allBooks, string categoryFilter = "", string statusFilter = "")
        {
            return allBooks.Where(book =>
            {
                bool matchCategory = true;
                bool matchStatus = true;

                try
                {
                    // Filter theo thể loại 
                    if (!string.IsNullOrEmpty(categoryFilter))
                    {
                        string theLoai = book.TheLoai?.ToString() ?? "";
                        matchCategory = theLoai.IndexOf(categoryFilter, StringComparison.OrdinalIgnoreCase) >= 0;
                    }

                    // Filter theo trạng thái - NULL SAFE
                    if (!string.IsNullOrEmpty(statusFilter))
                    {
                        int soLuong = 0;
                        try
                        {
                            if (book.SoLuong != null)
                                soLuong = Convert.ToInt32(book.SoLuong);
                        }
                        catch
                        {
                            soLuong = 0;
                        }

                        switch (statusFilter)
                        {
                            case "Còn hàng":
                                matchStatus = soLuong > 10;
                                break;
                            case "Hết hàng":
                                matchStatus = soLuong <= 0;
                                break;
                            case "Sắp hết":
                                matchStatus = soLuong > 0 && soLuong <= 10;
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Filter error for book: {ex.Message}");
                    return false;
                }

                return matchCategory && matchStatus;
            }).ToList();
        }

        /// <summary>
        /// Tìm kiếm và lọc kết hợp
        /// </summary>
        public static List<dynamic> SearchAndFilter(List<dynamic> allBooks, string searchKeyword = "",
            string categoryFilter = "", string statusFilter = "")
        {
            try
            {
                var results = allBooks?.ToList() ?? new List<dynamic>();


                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    results = SearchBooks(results, searchKeyword);
                }

                if (!string.IsNullOrEmpty(categoryFilter) || !string.IsNullOrEmpty(statusFilter))
                {
                    results = FilterBooks(results, categoryFilter, statusFilter);
                }

                return results;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SearchAndFilter error: {ex.Message}");
                return new List<dynamic>();
            }
        }
    }
}