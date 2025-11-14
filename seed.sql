-- Seed script for Book Management Database
-- This script inserts sample data for testing the application
-- Run this script in SQL Server Management Studio or via sqlcmd
-- Note: Adjust database name and paths as needed

USE book_management; -- Replace with your database name

-- Insert sample publishers
INSERT INTO NhaXuatBan (ten_nxb, dia_chi, dien_thoai) VALUES
('NXB Kim Đồng', 'Hà Nội', '0123456789'),
('NXB Trẻ', 'TP.HCM', '0987654321'),
('NXB Giáo Dục', 'Hà Nội', '0111111111');

-- Insert sample categories
INSERT INTO TheLoai (ten_the_loai) VALUES
('Văn Học'),
('Khoa Học'),
('Lịch Sử'),
('Thiếu Nhi'),
('Kinh Tế');

-- Insert sample books
INSERT INTO Sach (ten_sach, tac_gia, gia_ban, so_luong_ton, the_loai_id, nxb_id, mo_ta) VALUES
('Harry Potter và Hòn Đá Phù Thủy', 'J.K. Rowling', 150000, 50, 4, 1, 'Cuốn sách đầu tiên trong series Harry Potter'),
('Sapiens: Lược Sử Loài Người', 'Yuval Noah Harari', 200000, 30, 3, 2, 'Lịch sử nhân loại từ thời tiền sử đến hiện đại'),
('Đắc Nhân Tâm', 'Dale Carnegie', 120000, 40, 5, 3, 'Sách về nghệ thuật giao tiếp và ứng xử'),
('Tôi Thấy Hoa Vàng Trên Cỏ Xanh', 'Nguyễn Nhật Ánh', 80000, 60, 1, 1, 'Tiểu thuyết tuổi thơ'),
('Vũ Trụ Trong Vỏ Hạt Dẻ', 'Stephen Hawking', 180000, 20, 2, 2, 'Giải thích vũ trụ một cách dễ hiểu');

-- Insert sample users (passwords are hashed, use 'password123' for all)
INSERT INTO NguoiDung (ho_ten, ten_dang_nhap, mat_khau, vai_tro) VALUES
('Nguyễn Văn A', 'admin', 'password123', 'Admin'), -- Note: In real app, hash passwords
('Trần Thị B', 'staff1', 'password123', 'Staff'),
('Lê Văn C', 'staff2', 'password123', 'Staff');

-- Insert sample customers
INSERT INTO KhachHang (ten_khach, dia_chi, dien_thoai, email) VALUES
('Nguyễn Minh Anh', 'Hà Nội', '0912345678', 'minhanh@gmail.com'),
('Trần Thu Hương', 'TP.HCM', '0987654321', 'thuhuong@yahoo.com'),
('Lê Quang Vinh', 'Đà Nẵng', '0905123456', 'quangvinh@outlook.com');

-- Insert sample vouchers
INSERT INTO KhuyenMai (ten_km, mo_ta, phan_tram_giam, ngay_bat_dau, ngay_ket_thuc, trang_thai) VALUES
('Khuyến mãi mùa hè', 'Giảm 10% cho tất cả sách', 10, '2024-06-01', '2024-08-31', 'Active'),
('Khuyến mãi ngày lễ', 'Giảm 20% cho sách thiếu nhi', 20, '2024-09-01', '2024-09-30', 'Active'),
('Khuyến mãi sinh viên', 'Giảm 15% với thẻ sinh viên', 15, '2024-01-01', '2024-12-31', 'Active');

-- Insert sample invoices (assuming some books and customers exist)
-- First, insert invoice details that reference the books above
INSERT INTO HoaDon (ngay_lap, tong_tien, trang_thai, ten_khach_vang_lai, user_id) VALUES
('2024-10-01 10:00:00', 150000, 'DaThanhToan', 'Khách vãng lai 1', 2),
('2024-10-02 14:30:00', 320000, 'DaThanhToan', NULL, 2), -- Linked to customer
('2024-10-03 09:15:00', 80000, 'ChuaThanhToan', 'Khách vãng lai 2', 3),
('2024-10-04 16:45:00', 200000, 'DaThanhToan', NULL, 2), -- Linked to customer
('2024-10-05 11:20:00', 280000, 'DaHuy', NULL, 3); -- Linked to customer

-- Update invoices with customer IDs where applicable
UPDATE HoaDon SET kh_id = 1 WHERE hoadon_id = 2;
UPDATE HoaDon SET kh_id = 2 WHERE hoadon_id = 4;
UPDATE HoaDon SET kh_id = 3 WHERE hoadon_id = 5;

-- Insert invoice details (ChiTietHoaDon)
INSERT INTO ChiTietHoaDon (hoadon_id, sach_id, so_luong, gia_ban, thanh_tien) VALUES
(1, 1, 1, 150000, 150000), -- Harry Potter
(2, 2, 1, 200000, 200000), -- Sapiens
(2, 3, 1, 120000, 120000), -- Đắc Nhân Tâm
(3, 4, 1, 80000, 80000),   -- Tôi Thấy Hoa Vàng
(4, 5, 1, 180000, 180000), -- Vũ Trụ Trong Vỏ Hạt Dẻ
(5, 1, 1, 150000, 150000), -- Harry Potter
(5, 4, 1, 80000, 80000);   -- Tôi Thấy Hoa Vàng

-- Insert sample warehouse entries
INSERT INTO Kho (ten_kho, dia_chi) VALUES
('Kho Hà Nội', 'Hà Nội'),
('Kho TP.HCM', 'TP.HCM');

-- Insert warehouse details
INSERT INTO ChiTietKho (kho_id, sach_id, so_luong) VALUES
(1, 1, 25),
(1, 2, 15),
(1, 3, 20),
(1, 4, 30),
(1, 5, 10),
(2, 1, 25),
(2, 2, 15),
(2, 3, 20),
(2, 4, 30),
(2, 5, 10);

-- Note: To run this script:
-- 1. Open SQL Server Management Studio
-- 2. Connect to your database server
-- 3. Open this file
-- 4. Execute the script
--
-- Alternatively, from command line:
-- sqlcmd -S server_name -d database_name -i seed.sql
--
-- Make sure the database schema is created first by running any migration scripts.