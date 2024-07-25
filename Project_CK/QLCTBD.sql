CREATE DATABASE QLCTBD
GO
USE QLCTBD
GO

-- Tạo bảng
CREATE TABLE KhachHang
(
    MaKhachHang CHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL,
    SDT CHAR(10),
    DiaChi NVARCHAR(100) NOT NULL,
    NgayThangNamSinh DATE
)
GO

CREATE TABLE NhanVien
(
    MaNhanVien CHAR(10) PRIMARY KEY,
    TenNhanVien NVARCHAR(50) NOT NULL,
    SDT CHAR(10),
    DiaChi NVARCHAR(50) NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    NgayThangNamSinh DATE
)
GO

CREATE TABLE TaiKhoan
(
    TenTK VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(50),
    Role NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE NhaCungCap
(
    MaNhaCungCap CHAR(10) PRIMARY KEY,
    TenNhaCungCap NVARCHAR(50),
    DiaChi NVARCHAR(100),
    Email NVARCHAR(50)
)
GO

CREATE TABLE BangDia 
(
    MaBangDia CHAR(10) PRIMARY KEY,
    TenBangDia NVARCHAR(50) NOT NULL,
    MaNhaCungCap CHAR(10) NOT NULL,
    TheLoai NVARCHAR(50) NOT NULL,
    TinhTrang NVARCHAR(50) NOT NULL,
    DonGia DECIMAL NOT NULL,

    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
)
GO

CREATE TABLE PhieuThue
(
    SoPhieuThue INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang CHAR(10) NOT NULL,
    MaBangDia CHAR(10) NOT NULL,
    NgayThue DATE NOT NULL,
    NgayTra DATE NOT NULL,
    TongTienThanhToan DECIMAL NOT NULL,

    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaBangDia) REFERENCES BangDia(MaBangDia)
)
GO

CREATE TABLE PhieuTra
(
    SoPhieuTra INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang CHAR(10) NOT NULL,
    MaBangDia CHAR(10) NOT NULL,
    NgayThue DATE NOT NULL,
    NgayTraDuKien DATE NOT NULL,
	NgayTraThuTe DATE NOT NULL,
    TienPhatQuaHan DECIMAL NOT NULL,

    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaBangDia) REFERENCES BangDia(MaBangDia)
)
GO

CREATE TABLE LichSuThue
(
    SoPhieuThue INT NOT NULL,
    MaKhachHang CHAR(10) NOT NULL,
    MaBangDia CHAR(10) NOT NULL,

    FOREIGN KEY (SoPhieuThue) REFERENCES PhieuThue(SoPhieuThue),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaBangDia) REFERENCES BangDia(MaBangDia)
)
GO

CREATE TABLE LichSuTra
(
    SoPhieuTra INT NOT NULL,
    MaKhachHang CHAR(10) NOT NULL,
    MaBangDia CHAR(10) NOT NULL,

    FOREIGN KEY (SoPhieuTra) REFERENCES PhieuTra(SoPhieuTra),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaBangDia) REFERENCES BangDia(MaBangDia)
)
GO

CREATE TABLE ThongKe
(
    SoPhieuThue INT NOT NULL,
    MaKhachHang CHAR(10) NOT NULL,
    MaBangDia CHAR(10) NOT NULL,

    FOREIGN KEY (SoPhieuThue) REFERENCES PhieuThue(SoPhieuThue),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaBangDia) REFERENCES BangDia(MaBangDia)
)
GO

-- Thêm dữ liệu vào bảng TaiKhoan
INSERT INTO TaiKhoan (TenTK, MatKhau, Role) VALUES
('Admin', 'Admin', N'Admin'),
('KhachHang', 'MatKhauKhachHang', N'Khách Hàng');
GO

-- Thêm dữ liệu vào bảng NhaCungCap
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, Email) VALUES 
('NCC01', N'Nhà cung cấp 1', N'88 Phạm Ngũ Lão, P4, Gò Vấp, TPHCM', N'nhacungcap1@gmail.com'),
('NCC02', N'Nhà cung cấp 2', N'89 Phạm Ngũ Lão, P5, Gò Vấp, TPHCM', N'nhacungcap2@gmail.com'),
('NCC03', N'Nhà cung cấp 3', N'90 Phạm Ngũ Lão, P6, Gò Vấp, TPHCM', N'nhacungcap3@gmail.com'),
('NCC04', N'Nhà cung cấp 4', N'91 Phạm Ngũ Lão, P7, Gò Vấp, TPHCM', N'nhacungcap4@gmail.com');
GO

-- Thêm dữ liệu vào bảng KhachHang
INSERT INTO KhachHang (MaKhachHang, HoTen, GioiTinh, SDT, DiaChi, NgayThangNamSinh) VALUES
('KH01', N'Nguyễn Thành Hưng', N'Nam', '0365732494', N'88 Phạm Ngũ Lão, P4, GV, TPHCM', '2004-05-17'),
('KH02', N'Võ Phi Hùng', N'Nam', '0365732494', N'88 Phạm Ngũ Lão, P4, GV, TPHCM', '2004-06-15'),
('KH03', N'Cao Hoài Dự', N'Nam', '0365732494', N'88 Phạm Ngũ Lão, P4, GV, TPHCM', '2004-02-19'),
('KH04', N'Hà Minh Duy Khương', N'Nam', '0365732494', N'88 Phạm Ngũ Lão, P4, GV, TPHCM', '2004-02-18'),
('KH05', N'Đoàn Thanh Duy', N'Nam', '0365732494', N'88 Phạm Ngũ Lão, P4, GV, TPHCM', '2004-04-17');
GO

-- Thêm dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, SDT, DiaChi, GioiTinh, ChucVu, NgayThangNamSinh) VALUES
('NV01', N'Nguyễn Thành Hưng', '0365732494', N'88 Phạm Ngũ Lão, P4, GV, TPHCM', N'Nam', N'Quản lý', '2004-05-17'),
('NV02', N'Võ Phi Hùng', '0365732494', N'88 Phạm Ngũ Lão, P4, GV, TPHCM', N'Nam', N'Nhân viên bán hàng', '2004-05-23'),
('NV03', N'Cao hoài Dự', '0365732494', N'88 Phạm Ngũ Lão, P4, GV, TPHCM', N'Nam', N'Nhân viên bán hàng', '2004-02-17'),
('NV04', N'Hà Minh Duy Khương', '0365732494', N'88 Phạm Ngũ Lão, P4, GV, TPHCM', N'Nam', N'Nhân viên bán hàng', '2004-02-19'),
('NV05', N'Đoàn Thanh Duy', '0365732494', N'88 Phạm Ngũ Lão, P4, GV, TPHCM', N'Nam', N'Nhân viên bán hàng', '2004-03-19');
GO

-- Thêm dữ liệu vào bảng BangDia
INSERT INTO BangDia (MaBangDia, TenBangDia, MaNhaCungCap, TheLoai, TinhTrang, DonGia) VALUES
('BD01', N'Hẻm Cụt', 'NCC01', N'Hài', N'Mới', '25000'),
('BD02', N'Lật Mặt', 'NCC02', N'Hài, Hành động', N'Mới', '25000'),
('BD03', N'Quỷ Cẩu', 'NCC03', N'Kinh dị', N'Mới', '25000'),
('BD04', N'Nhà Bà Nữ', 'NCC04', N'Hài, Tâm lý', N'Mới', '25000'),
('BD05', N'Nghề Siêu Dễ', 'NCC01', N'Hài', N'Mới', '25000');
GO

-- Thêm dữ liệu vào bảng PhieuThue
INSERT INTO PhieuThue (MaKhachHang, MaBangDia, NgayThue, NgayTra, TongTienThanhToan) VALUES
('KH01', 'BD01', '2024-07-25', '2024-07-28', '25000'),
('KH02', 'BD02', '2024-07-20', '2024-07-23', '25000'),
('KH03', 'BD03', '2024-07-21', '2024-07-24', '25000'),
('KH04', 'BD04', '2024-07-22', '2024-07-25', '25000'),
('KH05', 'BD05', '2024-07-23', '2024-07-26', '25000');
GO

-- Thêm dữ liệu vào bảng PhieuTra
INSERT INTO PhieuTra (MaKhachHang, MaBangDia, NgayThue, NgayTraDuKien, NgayTraThuTe, TienPhatQuaHan) VALUES
('KH01', 'BD01', '2024-07-25', '2024-07-28', '2024-07-27', '0'),
('KH02', 'BD02', '2024-07-20', '2024-07-23', '2024-07-24', '10000'),
('KH03', 'BD03', '2024-07-21', '2024-07-24', '2024-07-26', '20000'),
('KH04', 'BD04', '2024-07-22', '2024-07-25', '2024-07-25', '0'),
('KH05', 'BD05', '2024-07-23', '2024-07-26', '2024-07-26', '0');
GO

-- Thêm dữ liệu vào bảng LichSuThue
INSERT INTO LichSuThue (SoPhieuThue, MaKhachHang, MaBangDia) VALUES
('1', 'KH01', 'BD01'),
('2', 'KH02', 'BD02'),
('3', 'KH03', 'BD03'),
('4', 'KH04', 'BD04'),
('5', 'KH05', 'BD05');
GO

-- Thêm dữ liệu vào bảng lịch sử trả
INSERT INTO LichSuTra (SoPhieuTra, MaKhachHang, MaBangDia) VALUES
('1', 'KH01', 'BD01'),
('2', 'KH02', 'BD02'),
('3', 'KH03', 'BD03'),
('4', 'KH04', 'BD04'),
('5', 'KH05', 'BD05');
GO

-- Tạo vai trò
CREATE ROLE QuanLy
--CREATE ROLE NhanVien
CREATE ROLE KhachHang
GO

-- Phân quyền cho các vai trò
-- Vai trò Quản lý
GRANT SELECT, INSERT, UPDATE, DELETE ON KhachHang TO QuanLy
GRANT SELECT, INSERT, UPDATE, DELETE ON BangDia TO QuanLy
GRANT SELECT, INSERT, UPDATE, DELETE ON NhanVien TO QuanLy
GRANT SELECT, INSERT, UPDATE, DELETE ON PhieuThue TO QuanLy
GO

/*
-- Vai trò Nhân viên
GRANT SELECT, INSERT, UPDATE ON KhachHang TO NhanVien
GRANT SELECT, INSERT, UPDATE ON BangDia TO NhanVien
GRANT SELECT, INSERT, UPDATE ON PhieuThue TO NhanVien
GRANT SELECT, INSERT ON BaoCao TO NhanVien
GO
*/

-- Vai trò Khách hàng
GRANT SELECT ON BangDia TO KhachHang
GRANT SELECT ON PhieuThue TO KhachHang
GO

-- Tạo tài khoản người dùng và thêm vào vai trò tương ứng
CREATE LOGIN QuanLyLogin WITH PASSWORD = 'MatKhauQuanLy'
--CREATE LOGIN NhanVienLogin WITH PASSWORD = 'MatKhauNhanVien'
CREATE LOGIN KhachHangLogin WITH PASSWORD = 'MatKhauKhachHang'
GO

CREATE USER QuanLyUser FOR LOGIN QuanLyLogin
--CREATE USER NhanVienUser FOR LOGIN NhanVienLogin
CREATE USER KhachHangUser FOR LOGIN KhachHangLogin
GO

EXEC sp_addrolemember 'QuanLy', 'QuanLyUser'
--EXEC sp_addrolemember 'NhanVien', 'NhanVienUser'
EXEC sp_addrolemember 'KhachHang', 'KhachHangUser'
GO
