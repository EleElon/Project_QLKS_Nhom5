CREATE DATABASE QLKS
GO

-- DROP DATABASE QLKS

USE QLKS
GO

CREATE TABLE Users (
	UserName NVARCHAR(10) PRIMARY KEY NOT NULL,
	PassWordd NVARCHAR(10) NOT NULL
);
GO

CREATE TABLE NhanVien (
    MaNhanVien NVARCHAR(10) PRIMARY KEY NOT NULL,
	MaPhong NVARCHAR(10),	
    TenNhanVien NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    Luong FLOAT NOT NULL
);
GO

CREATE TABLE KhachHang (
    MaKhachHang NVARCHAR(10) PRIMARY KEY NOT NULL,
	MaDichVu NVARCHAR(10),
    TenKhachHang NVARCHAR(100) NOT NULL,
	CCCD nvarchar(12),
	Email NVARCHAR(100) NOT NULL,
	SDT NVARCHAR(20) NOT NULL,
	DiaChi NVARCHAR(255) NOT NULL,
);
GO

CREATE TABLE Phong (
    MaPhong NVARCHAR(10) PRIMARY KEY NOT NULL,
    MaLoaiPhong NVARCHAR(10) NOT NULL,
    SoPhong NVARCHAR(10) NOT NULL,
    TinhTrang NVARCHAR(20)
);
GO

CREATE TABLE LoaiPhong (
    MaLoaiPhong NVARCHAR(10) PRIMARY KEY NOT NULL,
    TenLoaiPhong NVARCHAR(50) NOT NULL,
    Gia FLOAT NOT NULL
);
GO

CREATE TABLE DatPhong (
    MaDatPhong NVARCHAR(10) PRIMARY KEY,
    MaKhachHang NVARCHAR(10),

);
GO

CREATE TABLE ChiTietDatPhong (
    MaChiTietDatPhong NVARCHAR(10) PRIMARY KEY,
	MaDatPhong NVARCHAR(10),
    MaKhachHang NVARCHAR(10),
	MaPhong NVARCHAR(10),
	MaLoaiPhong NVARCHAR(10),
	TinhTrang NVARCHAR(50),
	GiaMoiDem FLOAT,
	SoLuongPhong INT,
	TongGia FLOAT,
	PhuongThucThanhToan NVARCHAR(100),
    NgayNhanPhong DATE,
    NgayTraPhong DATE
);
GO

CREATE TABLE DichVu (
    MaDichVu NVARCHAR(10) PRIMARY KEY NOT NULL,
    MaLoaiDichVu NVARCHAR(10) NOT NULL,
    TenDichVu NVARCHAR(100) NOT NULL,
    Gia FLOAT NOT NULL
);
GO

CREATE TABLE LoaiDichVu (
    MaLoaiDichVu NVARCHAR(10) PRIMARY KEY NOT NULL,
    TenLoaiDichVu NVARCHAR(50) NOT NULL,
	MaLoaiPhong NVARCHAR(10) NOT NULL
);
GO



CREATE TABLE DanhSachSuDungDichVu (
    MaSuDungDichVu NVARCHAR(10) PRIMARY KEY NOT NULL,
    MaDichVu NVARCHAR(10),
	MaDatPhong NVARCHAR(10),
	SoLuong INT
);
go

CREATE TABLE CoSoVatChat (
	 MaPhong NVARCHAR(10) NOT NULL,
    MaCoSoVatChat NVARCHAR(10) PRIMARY KEY NOT NULL,
    TenCoSoVatChat NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(200) NOT NULL
);
GO



CREATE TABLE DoanhThu (
    MaDoanhThu NVARCHAR(10) PRIMARY KEY NOT NULL,
    Ngay DATE NOT NULL,
    SoTien FLOAT NOT NULL
);
GO

CREATE TABLE TraPhong (
    MaTraPhong NVARCHAR(10) PRIMARY KEY NOT NULL,
    MaDatPhong NVARCHAR(10) NOT NULL,
    NgayTra DATE NOT NULL,
    TienDatCoc FLOAT NOT NULL
);
GO

CREATE TABLE Luong (
    MaLuong NVARCHAR(10) PRIMARY KEY NOT NULL,
    MaNhanVien NVARCHAR(10) NOT NULL,
    Thang INT NOT NULL,
    SoTien FLOAT NOT NULL
);
GO


CREATE TABLE ChiTietHoaDon (
    MaHoaDon NVARCHAR(10) PRIMARY KEY NOT NULL,
    MaDatPhong NVARCHAR(10) NOT NULL,
	 MaSuDungDichVu NVARCHAR(10),
	 PhuThu float,
	 TienPhong float,
	 TienDichVu float,
	 GiamGiaKH float,
	 HinhThucThanhToan nvarchar(100),
	 SoNgay float,
	 ThanhTien float
);
GO


ALTER TABLE Phong
ADD CONSTRAINT FK_Phong_LoaiPhong
FOREIGN KEY (MaLoaiPhong) REFERENCES LoaiPhong(MaLoaiPhong);
GO


ALTER TABLE LoaiDichVu
ADD CONSTRAINT FK_LoaiDichVu_LoaiPhong
FOREIGN KEY (MaLoaiPhong) REFERENCES LoaiPhong(MaLoaiPhong);
GO


ALTER TABLE DatPhong
ADD CONSTRAINT FK_DatPhong_KhachHang
FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang);
GO



ALTER TABLE ChiTietDatPhong
ADD CONSTRAINT FK_ChiTietDatPhong_DatPhong
FOREIGN KEY (MaDatPhong) REFERENCES DatPhong(MaDatPhong);
GO


ALTER TABLE ChiTietDatPhong
ADD CONSTRAINT FK_ChiTietDatPhong_KhachHang
FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang);
GO


ALTER TABLE ChiTietDatPhong
ADD CONSTRAINT FK_ChiTietDatPhong_LoaiPhong
FOREIGN KEY (MaLoaiPhong) REFERENCES LoaiPhong(MaLoaiPhong);
GO


ALTER TABLE ChiTietDatPhong
ADD CONSTRAINT FK_ChiTietDatPhong_Phong
FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong);
GO


ALTER TABLE DichVu
ADD CONSTRAINT FK_DichVu_LoaiDichVu
FOREIGN KEY (MaLoaiDichVu) REFERENCES LoaiDichVu(MaLoaiDichVu);
GO





ALTER TABLE TraPhong
ADD CONSTRAINT FK_TraPhong_DatPhong
FOREIGN KEY (MaDatPhong) REFERENCES DatPhong(MaDatPhong);
GO


ALTER TABLE Luong
ADD CONSTRAINT FK_Luong_NhanVien
FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien);
GO

ALTER TABLE CoSoVatChat
ADD CONSTRAINT FK_CoSoVatChat_Phong
FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong);
GO


ALTER TABLE NhanVien
ADD CONSTRAINT FK_NhanVien_Phong
FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong);
GO

ALTER TABLE DanhSachSuDungDichVu
ADD CONSTRAINT FK_DanhSachSuDungDichVu_DichVu 
FOREIGN KEY (MaDichVu) REFERENCES DichVu(MaDichVu);
go
   
ALTER TABLE DanhSachSuDungDichVu
ADD CONSTRAINT FK_DanhSachSuDungDichVu_DatPhong 
FOREIGN KEY (MaDatPhong) REFERENCES DatPhong(MaDatPhong)
go


ALTER TABLE ChiTietHoaDon
ADD CONSTRAINT FK_ChiTietHoaDon_DanhSachSuDungDichVu 
FOREIGN KEY (MaSuDungDichVu) REFERENCES DanhSachSuDungDichVu(MaSuDungDichVu)
GO


INSERT INTO Users (UserName, PassWordd)
VALUES
('a', '123'),
('admin', '123123');
GO


INSERT INTO LoaiPhong (MaLoaiPhong, TenLoaiPhong, Gia)
VALUES
('LP001', 'Phong Don', 500000),
('LP002', 'Phong Doi', 800000),
('LP003', 'Phong VIP', 1500000),
('LP004', 'Phong Gia Dinh', 1200000),
('LP005', 'Phong Suite', 2500000),
('LP006', 'Phong Deluxe', 1800000),
('LP007', 'Phong Standard', 700000),
('LP008', 'Phong Executive', 2200000),
('LP009', 'Phong Premier', 2700000),
('LP010', 'Phong Royal Suite', 3500000);
GO


INSERT INTO Phong (MaPhong, MaLoaiPhong, SoPhong,TinhTrang)
VALUES 
('P001', 'LP001', 101,'Trong'),
('P002', 'LP002', 102,'Dang Su Dung'),
('P003', 'LP001', 103,'Trong'),
('P004', 'LP003', 104,'Trong'),
('P005', 'LP002', 105,'Trong'),
('P006', 'LP003', 106, 'Dang Su Dung'),
('P007', 'LP004', 107, 'Trong'),
('P008', 'LP005', 108, 'Dang Su Dung'),
('P009', 'LP004', 109, 'Trong'),
('P010', 'LP001', 110, 'Trong');

GO


INSERT INTO LoaiDichVu (MaLoaiDichVu, TenLoaiDichVu, MaLoaiPhong)
VALUES
('DV001', 'Dich vu an uong', 'LP001'),
('DV002', 'Dich vu giat ui', 'LP002'),
('DV003', 'Dich vu dua don', 'LP003'),
('DV004', 'Dich vu ve sinh', 'LP001'),
('DV005', 'Dich vu spa', 'LP003'),
('DV006', 'Dich vu karaoke', 'LP002'),
('DV007', 'Dich vu BBQ', 'LP004'),
('DV008', 'Dich vu massage', 'LP005'),
('DV009', 'Dich vu doc bao', 'LP002'),
('DV010', 'Dich vu tap gym', 'LP005');
GO


INSERT INTO DichVu (MaDichVu, MaLoaiDichVu, TenDichVu, Gia)
VALUES
('DV001', 'DV001', 'An sang buffet', 150000),
('DV002', 'DV001', 'An trua set menu', 250000),
('DV003', 'DV002', 'Giat ai quan ao', 50000),
('DV004', 'DV003', 'Dua don san bay', 350000),
('DV005', 'DV005', 'Massage toan than', 600000),
('DV006', 'DV001', 'An toi buffet', 200000),
('DV007', 'DV002', 'Ui quan ao cao cap', 70000),
('DV008', 'DV004', 'Ve sinh phong hang ngay', 300000),
('DV009', 'DV003', 'Thue xe dua don', 500000),
('DV010', 'DV005', 'Cham soc da mat', 450000);
GO


INSERT INTO KhachHang (MaKhachHang, MaDichVu, TenKhachHang, CCCD, Email, SDT, DiaChi)
VALUES
('KH001', 'DV001', 'Nguyen Van A', '012345678901', 'nguyenvana@example.com', '0912345678', '123 Nguyen Trai, Ha Noi'),
('KH002', 'DV003', 'Tran Thi B', '098765432109', 'tranthib@example.com', '0987654321', '456 Le Loi, Ho Chi Minh'),
('KH003', 'DV001', 'Le Van C', '011223344556', 'levanc@example.com', '0901122334', '789 Hoang Hoa Tham, Da Nang'),
('KH004', 'DV002', 'Pham Thi D', '033445566778', 'phamthid@example.com', '0911223344', '101 Hai Ba Trung, Ha Noi'),
('KH005', 'DV003', 'Bui Thi E', '044556677889', 'buithie@example.com', '0933445566', '202 Ba Trieu, Hue'),
('KH006', 'DV006', 'Nguyen Van F', '055667788990', 'nguyenvanf@example.com', '0922334455', '123 Bach Dang, Da Nang'),
('KH007', 'DV007', 'Pham Thi G', '066778899001', 'phamthig@example.com', '0933445566', '456 Vo Thi Sau, Vung Tau'),
('KH008', 'DV008', 'Le Thi H', '077889900112', 'lethih@example.com', '0944556677', '789 Tran Hung Dao, Can Tho'),
('KH009', 'DV009', 'Hoang Van I', '088990011223', 'hoangvani@example.com', '0955667788', '101 Le Thanh Ton, Nha Trang'),
('KH010', 'DV010', 'Tran Thi J', '099001122334', 'tranthij@example.com', '0966778899', '202 Hai Ba Trung, Hue');


GO


INSERT INTO NhanVien (MaNhanVien, MaPhong, TenNhanVien, ChucVu, Luong)
VALUES
('NV001', 'P001', 'Nguyen Van A', 'Giam Doc', 5000.00),
('NV002', 'P002', 'Tran Thi B', 'Truong Phong', 3500.00),
('NV003', 'P003', 'Le Van C', 'Nhan Vien', 2500.00),
('NV004', 'P004', 'Pham Thi D', 'Ke Toan', 3000.00),
('NV005', 'P005', 'Bui Van E', 'Bao Ve', 2000.00),
('NV006', 'P001', 'Nguyen Van F', 'Phuc Vu', 2200.00),
('NV007', 'P002', 'Tran Thi G', 'Tiep Tan', 1800.00),
('NV008', 'P003', 'Le Van H', 'Giam Sat', 3000.00),
('NV009', 'P004', 'Pham Thi I', 'Ke Toan', 2900.00),
('NV010', 'P005', 'Bui Van J', 'Bao Ve', 2100.00);
GO


INSERT INTO DatPhong (MaDatPhong, MaKhachHang)
VALUES 
('DP001', 'KH001'),
('DP002', 'KH006'),
('DP006', 'KH002'),
('DP007', 'KH003'),
('DP008', 'KH004'),
('DP005', 'KH005'),
('DP010', 'KH001'),
('DP011', 'KH002'),
('DP012', 'KH003'),
('DP013', 'KH004'),
('DP014', 'KH005'),
('DP015', 'KH006');
GO


INSERT INTO ChiTietDatPhong (MaChiTietDatPhong, MaDatPhong, MaKhachHang, MaPhong, MaLoaiPhong, TinhTrang, GiaMoiDem, SoLuongPhong, TongGia, PhuongThucThanhToan, NgayNhanPhong, NgayTraPhong)
VALUES 
('CTDP001', 'DP001', 'KH001', 'P001', 'LP001', 'Da nhan phong', 500000, 1, 500000, 'Tien mat', '2024-09-15', '2024-09-18'),
('CTDP002', 'DP006', 'KH002', 'P006', 'LP002', 'Dang Bao Tri', 500000, 1, 500000, 'Tien mat', '2024-09-19', '2024-09-21'),
('CTDP003', 'DP007', 'KH003', 'P007', 'LP002', 'Chua nhan phong', 500000, 1, 500000, 'The tin dung', '2024-09-16', '2024-09-19'),
('CTDP004', 'DP008', 'KH004', 'P004', 'LP002', 'Chua nhan phong', 500000, 1, 500000, 'The tin dung', '2024-09-20', '2024-09-23'),
('CTDP005', 'DP005', 'KH005', 'P005', 'LP001', 'Da tra phong', 500000, 1, 500000, 'The tin dung', '2024-09-10', '2024-09-12');
GO


INSERT INTO DanhSachSuDungDichVu (MaSuDungDichVu, MaDichVu, MaDatPhong, SoLuong)
VALUES 
('SDDV001', 'DV001', 'DP001', 2),
('SDDV002', 'DV003', 'DP002', 1),
('SDDV003', 'DV005', 'DP007', 3),
('SDDV004', 'DV002', 'DP006', 1),
('SDDV005', 'DV004', 'DP006', 2),
('SDDV006', 'DV001', 'DP007', 5),
('SDDV007', 'DV002', 'DP008', 3),
('SDDV008', 'DV005', 'DP005', 2),
('SDDV009', 'DV001', 'DP008', 4),
('SDDV010', 'DV002', 'DP007', 1),
('SDDV011', 'DV003', 'DP008', 2),
('SDDV012', 'DV004', 'DP001', 3),
('SDDV013', 'DV005', 'DP002', 1),
('SDDV014', 'DV001', 'DP002', 2),
('SDDV015', 'DV003', 'DP006', 1);
GO



INSERT INTO CoSoVatChat (MaPhong, MaCoSoVatChat, TenCoSoVatChat, MoTa)
VALUES 
('P001', 'CSVC001', 'Tivi', 'Tivi Samsung 42 inch'),
('P002', 'CSVC002', 'Giuong', 'Giuong doi 1m8 x 2m'),
('P003', 'CSVC003', 'Dieu hoa', 'Dieu hoa Daikin 12000 BTU'),
('P004', 'CSVC004', 'Tuy chon phong tam', 'Phong tam co voi sen va bon tam'),
('P005', 'CSVC005', 'Ban lam viec', 'Ban lam viec go soi'),
('P001', 'CSVC006', 'Tu lanh', 'Tu lanh LG 300L'),
('P002', 'CSVC007', 'May giat', 'May giat Toshiba 8 kg'),
('P003', 'CSVC008', 'Lo vi song', 'Lo vi song Electrolux'),
('P004', 'CSVC009', 'Bong den', 'Bong den LED 12W'),
('P005', 'CSVC010', 'Internet', 'Internet FPT 100 Mbps');
GO


INSERT INTO Luong (MaLuong, MaNhanVien, Thang, SoTien)
VALUES 
('L001', 'NV001', 9, 5000),
('L002', 'NV002', 9, 3500),
('L003', 'NV003', 9, 2500),
('L004', 'NV004', 9, 3000),
('L005', 'NV005', 9, 2000);
GO


INSERT INTO TraPhong (MaTraPhong, MaDatPhong, NgayTra, TienDatCoc)
VALUES 
('TP001', 'DP001', '2024-09-18', 100000),
('TP002', 'DP002', '2024-09-25', 150000),
('TP003', 'DP002', '2024-09-12', 200000);
GO


INSERT INTO DoanhThu (MaDoanhThu, Ngay, SoTien)
VALUES 
('DT001', '2024-09-18', 500000),
('DT002', '2024-09-25', 1600000),
('DT003', '2024-09-12', 500000);
GO


SELECT * FROM Users
SELECT * FROM LoaiPhong
SELECT * FROM Phong
SELECT * FROM LoaiDichVu
SELECT * FROM DichVu
SELECT * FROM KhachHang
SELECT * FROM NhanVien
SELECT * FROM ChiTietDatPhong
SELECT * FROM CoSoVatChat
SELECT * FROM DanhSachSuDungDichVu
SELECT * FROM ChiTietHoaDon
SELECT * FROM Luong
