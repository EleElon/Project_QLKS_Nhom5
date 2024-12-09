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
    MaNhanVien NVARCHAR(100) PRIMARY KEY NOT NULL,
	MaPhong NVARCHAR(100),	
    TenNhanVien NVARCHAR(100) NOT NULL,
	gioiTinh NVARCHAR(10) NOT NULL,
	ngaySinh DATE NOT NULL, 
	SDT NVARCHAR(20) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    diaChi NVARCHAR(200) NOT NULL
);
GO

CREATE TABLE KhachHang (
    MaKhachHang NVARCHAR(100) PRIMARY KEY NOT NULL,
	MaDichVu NVARCHAR(100),
    TenKhachHang NVARCHAR(100) NOT NULL,
	CCCD nvarchar(12),
	Email NVARCHAR(100) NOT NULL,
	SDT NVARCHAR(20) NOT NULL,
	DiaChi NVARCHAR(255) NOT NULL,
);
GO

CREATE TABLE Phong (
    MaPhong NVARCHAR(100) PRIMARY KEY NOT NULL,
    MaLoaiPhong NVARCHAR(100) NOT NULL,
    SoPhong NVARCHAR(10) NOT NULL,
    TinhTrang NVARCHAR(20)
);
GO

CREATE TABLE LoaiPhong (
    MaLoaiPhong NVARCHAR(100) PRIMARY KEY NOT NULL,
    TenLoaiPhong NVARCHAR(50) NOT NULL,
    Gia FLOAT NOT NULL
);
GO

CREATE TABLE DatPhong (
    MaDatPhong NVARCHAR(100) PRIMARY KEY,
    MaKhachHang NVARCHAR(100),

);
GO

CREATE TABLE ChiTietDatPhong (
    MaChiTietDatPhong NVARCHAR(100) PRIMARY KEY,
	MaDatPhong NVARCHAR(100),
    MaKhachHang NVARCHAR(100),
	MaPhong NVARCHAR(100),
	MaLoaiPhong NVARCHAR(100),
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
    MaDichVu NVARCHAR(100) PRIMARY KEY NOT NULL,
    MaLoaiDichVu NVARCHAR(100) NOT NULL,
    TenDichVu NVARCHAR(100) NOT NULL,
    Gia FLOAT NOT NULL
);
GO

CREATE TABLE LoaiDichVu (
    MaLoaiDichVu NVARCHAR(100) PRIMARY KEY NOT NULL,
    TenLoaiDichVu NVARCHAR(50) NOT NULL,
	MaLoaiPhong NVARCHAR(100) NOT NULL
);
GO



CREATE TABLE DanhSachSuDungDichVu (
    MaSuDungDichVu NVARCHAR(100) PRIMARY KEY NOT NULL,
    MaDichVu NVARCHAR(100),
	MaDatPhong NVARCHAR(100),
	SoLuong INT,
	Gia float
);
go

CREATE TABLE CoSoVatChat (
	 MaPhong NVARCHAR(100) NOT NULL,
    MaCoSoVatChat NVARCHAR(100) PRIMARY KEY NOT NULL,
    TenCoSoVatChat NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(200) NOT NULL
);
GO

CREATE TABLE HoaDon (
    MaHoaDon NVARCHAR(100) PRIMARY KEY NOT NULL,
    MaDatPhong NVARCHAR(100) NOT NULL,
    TongTien FLOAT NOT NULL,
    TinhTrangThanhToan NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE DoanhThu (
    MaDoanhThu NVARCHAR(100) PRIMARY KEY NOT NULL,
    Ngay DATE NOT NULL,
    SoTien FLOAT NOT NULL
);
GO

CREATE TABLE TraPhong (
    MaTraPhong NVARCHAR(100) PRIMARY KEY NOT NULL,
    MaDatPhong NVARCHAR(100) NOT NULL,
    NgayTra DATE NOT NULL,
    TienDatCoc FLOAT NOT NULL
);
GO

   
CREATE TABLE ChamCong (
    MaChamCong NVARCHAR(100) PRIMARY KEY NOT NULL,
	TenBangChamCong	NVARCHAR(100) NOT NULL,
    MaNhanVien NVARCHAR(100) NOT NULL,
    Thang NVARCHAR(10) NOT NULL,
    Nam INT NOT NULL,
    SoNgayLamViec INT,
	SoGioTangCa FLOAT,
    NgayChamCong DATE,
    GhiChu NVARCHAR(200),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

																								
CREATE TABLE Luong (
    MaLuong NVARCHAR(100) PRIMARY KEY NOT NULL,
	MaChamCong NVARCHAR(100) NOT NULL,
    MaNhanVien NVARCHAR(100) NOT NULL,
    Thang INT NOT NULL,
    Nam INT NOT NULL,
    SoNgayLamViec INT,
    SoGioTangCa FLOAT,
    LuongCoBan FLOAT,
    PhuCap FLOAT,
    Thuong FLOAT,
    KhauTru FLOAT,
    TongLuong FLOAT,
    NgayTinhLuong DATE,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
	FOREIGN KEY (MaChamCong) REFERENCES ChamCong(MaChamCong)
);
GO


CREATE TABLE ChiTietHoaDon (
    MaHoaDon NVARCHAR(100) PRIMARY KEY NOT NULL,
    MaDatPhong	NVARCHAR(100) NOT NULL,
	 MaSuDungDichVu NVARCHAR(100),
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


ALTER TABLE HoaDon
ADD CONSTRAINT FK_HoaDon_DatPhong
FOREIGN KEY (MaDatPhong) REFERENCES DatPhong(MaDatPhong);
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
('LDV001', 'Dich vu an uong', 'LP001'),
('LDV002', 'Dich vu giat ui', 'LP002'),
('LDV003', 'Dich vu dua don', 'LP003'),
('LDV004', 'Dich vu ve sinh', 'LP001'),
('LDV005', 'Dich vu spa', 'LP003'),
('LDV006', 'Dich vu karaoke', 'LP002'),
('LDV007', 'Dich vu BBQ', 'LP004'),
('LDV008', 'Dich vu massage', 'LP005'),
('LDV009', 'Dich vu doc bao', 'LP002'),
('LDV010', 'Dich vu tap gym', 'LP005');
GO



INSERT INTO DichVu (MaDichVu, MaLoaiDichVu, TenDichVu, Gia)
VALUES
('DV001', 'LDV001', 'An sang buffet', 150000),
('DV002', 'LDV002', 'An trua set menu', 250000),
('DV003', 'LDV003', 'Giat ai quan ao', 50000),
('DV004', 'LDV003', 'Dua don san bay', 350000),
('DV005', 'LDV005', 'Massage toan than', 600000),
('DV006', 'LDV004', 'An toi buffet', 200000),
('DV007', 'LDV002', 'Ui quan ao cao cap', 70000),
('DV008', 'LDV004', 'Ve sinh phong hang ngay', 300000),
('DV009', 'LDV005', 'Thue xe dua don', 500000),
('DV010', 'LDV006', 'Cham soc da mat', 450000);
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


INSERT INTO NhanVien (MaNhanVien, MaPhong, TenNhanVien, gioiTinh, ngaySinh, SDT, ChucVu, diaChi)
VALUES
('NV001', 'P001', N'Nguyen Van AB', N'Nam', '1996-04-01', '0123456789', N'Giam Doc', N'Ha Noi'),
('NV002', 'P002', 'Tran Thi BC', N'Nu', '1997-04-02', '0123456789', 'Truong Phong', N'Ho Chi Minh'),
('NV003', 'P003', 'Le Van CD', N'Nam', '1998-04-03', '0123456789', 'Nhan Vien', N'Hai Phong'),
('NV004', 'P004', 'Pham Thi Dung', N'Nu', '1998-04-03', '0123456789', 'Ke Toan', N'Hai Phong'),
('NV005', 'P005', 'Bui Van Em', N'Nam','1998-04-03', '0123456789', 'Bao Ve', N'Da Nang'),
('NV006', 'P001', 'Nguyen Van Fyy', N'Nam', '1999-04-04', '0123456789', 'Phuc Vu', N'Da Nang'),
('NV007', 'P002', 'Tran Thi Giang', N'Nu', '2000-04-05', '0123456789', 'Tiep Tan', N'Can Tho'),
('NV008', 'P003', 'Le Van Hoa', N'Nu', '2000-04-05', '0123456789', 'Giam Sat', N'Nam Dinh'),
('NV009', 'P004', 'Pham Thi hien', N'Nu', '2000-04-05', '0123456789', 'Ke Toan', N'Quang Ngai'),
('NV010', 'P005', 'Bui Van nhi', N'Nu', '2000-04-05', '0123456789','Bao Ve', N'Ca Mau');
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


INSERT INTO DanhSachSuDungDichVu (MaSuDungDichVu, MaDichVu, MaDatPhong, SoLuong,Gia)
VALUES 
('SDDV001', 'DV001', 'DP001', 2,2400000),
('SDDV002', 'DV003', 'DP002', 1,1200000),
('SDDV003', 'DV005', 'DP007', 3,3600000),
('SDDV004', 'DV002', 'DP006', 1,1200000),
('SDDV005', 'DV004', 'DP006', 2,3000000),
('SDDV006', 'DV001', 'DP007', 5,3000000),
('SDDV007', 'DV002', 'DP008', 3,3000000),
('SDDV008', 'DV005', 'DP005', 2,3000000),
('SDDV009', 'DV001', 'DP008', 4,3000000),
('SDDV010', 'DV002', 'DP007', 1,3000000),
('SDDV011', 'DV003', 'DP008', 2,3000000),
('SDDV012', 'DV004', 'DP001', 3,3000000),
('SDDV013', 'DV005', 'DP002', 1,3000000),
('SDDV014', 'DV001', 'DP002', 2,3000000),
('SDDV015', 'DV003', 'DP006', 1,3000000);
GO

select * from ChiTietHoaDon
INSERT INTO ChiTietHoaDon(MaHoaDon,MaDatPhong,MaSuDungDichVu,PhuThu,TienPhong,TienDichVu,GiamGiaKH,HinhThucThanhToan,SoNgay,ThanhTien)
VALUES 
('HD02','P001','SDDV002',1000,500000,1200000,0,'Tien Mat',3,3099888),
('HD03', 'P002', 'SDDV003', 2000, 800000, 3600000, 50000, 'Tien Mat', 2, 5192000),
('HD04', 'P003', 'SDDV004', 1500, 500000, 1200000, 100000, 'Tin Dung Ngan Hang', 4, 2215000),
('HD05', 'P004', 'SDDV005', 1000, 1500000, 3000000, 0, 'Tien Mat', 3, 7501000),
('HD06', 'P005', 'SDDV006', 3000, 800000, 300000, 20000, 'Tin Dung Ngan Hang', 5, 4303000),
('HD07', 'P006', 'SDDV007', 2500, 1500000, 300000, 5000, 'Tien Mat', 1, 1802500),
('HD08', 'P007', 'SDDV008', 4000, 1200000, 300000, 100000, 'Tien Mat', 6, 7594000),
('HD09', 'P008', 'SDDV009', 500, 2500000, 300000, 20000, 'Tin Dung Ngan Hang', 2, 5299500),
('HD10', 'P009', 'SDDV010', 2000, 1200000, 300000, 50000, 'Tien Mat', 7, 8907000);




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


INSERT INTO ChamCong (MaChamCong, TenBangChamCong, MaNhanVien, Thang, Nam, SoNgayLamViec, SoGioTangCa, NgayChamCong, GhiChu)
VALUES 
('CC001', N'AB Thang 9', 'NV001', N'9', 2024, 28, 1, '2024-09-30', 'Lam du cong, khong co tang ca'),
('CC002', N'Thi BC Thang 9','NV002', N'9', 2024, 26, 2, '2024-09-30', 'Nghi phep 2 ngay'),
('CC003', N'Van CD Thang 9','NV003', N'9', 2024, 27, 1, '2024-09-30', 'Tang ca 2 gio moi ngay trong 5 ngay'),
('CC004', N'Thi Dung Thang 9','NV004', N'9', 2024, 29, 0, '2024-09-30', 'Nghi om nhieu, khong co tang ca'),
('CC005', N'Van Em Thang 9','NV005', N'9', 2024, 30, 0, '2024-09-30', 'Lam them ca cuoi tuan, hieu suat cao'),
('CC006', N'AB Thang 10','NV001', N'10', 2024, 26, 0, '2024-10-31', 'Lam viec cham chi, nghi 1 ngay le'),
('CC007', N'Thi BC Thang 10','NV002', N'10', 2024, 28, 2, '2024-10-31', 'Co tang ca 1 ngay, nghi phep 2 ngay'),
('CC008', N'Van CD Thang 10','NV003', N'10', 2024, 24, 1, '2024-10-31', 'Tang ca lien tuc trong tuan cuoi thang'),
('CC009', N'Thi Dung Thang 10','NV004', N'10', 2024, 28, 0, '2024-10-31', 'Hoan thanh du cong viec, khong nghi'),
('CC010', N'Van Em Thang 10','NV005', N'10', 2024, 31, 0, '2024-10-31', 'Hieu suat cao, khong nghi phep');
GO


INSERT INTO Luong (MaLuong, MaChamCong, MaNhanVien, Thang, Nam, SoNgayLamViec, SoGioTangCa, LuongCoBan, PhuCap, Thuong, KhauTru, TongLuong, NgayTinhLuong)
VALUES 
('L001', 'CC001', 'NV001', 9, 2024, 31, 1, 7000000, 0, 200000, 0, 7950000, '2024-09-18'),
('L002', 'CC002', 'NV002', 9, 2024, 29, 2, 7000000, 0, 0, 200000, 7920000, '2024-09-18'),
('L003', 'CC003', 'NV003', 9, 2024, 29, 2, 7000000, 0, 0, 200000, 7920000, '2024-09-18'),
('L004', 'CC004', 'NV004', 9, 2024, 30, 1, 7000000, 0, 0, 0, 7850000, '2024-09-18'),
('L005', 'CC005', 'NV005', 9, 2024, 28, 1, 7000000, 0, 0, 400000, 7760000, '2024-09-18'),
('L006', 'CC006', 'NV006', 9, 2024, 25, 0, 8000000, 500000, 300000, 100000, 8700000, '2024-09-20'),
('L007', 'CC007', 'NV007', 9, 2024, 27, 3, 7500000, 300000, 100000, 200000, 7950000, '2024-09-21'),
('L008', 'CC008', 'NV008', 9, 2024, 30, 4, 8000000, 0, 500000, 100000, 8600000, '2024-09-22'),
('L009', 'CC009', 'NV009', 9, 2024, 29, 2, 7000000, 200000, 0, 0, 7400000, '2024-09-23'),
('L010', 'CC010', 'NV010', 9, 2024, 28, 0, 6500000, 100000, 200000, 150000, 6750000, '2024-09-24'),
('L011', 'CC007', 'NV001', 10, 2024, 31, 1, 7500000, 0, 300000, 500000, 7300000, '2024-10-18'),
('L012', 'CC001', 'NV002', 10, 2024, 30, 2, 8000000, 400000, 100000, 300000, 8200000, '2024-10-19'),
('L013', 'CC003', 'NV003', 10, 2024, 29, 1, 7000000, 0, 200000, 100000, 7100000, '2024-10-20'),
('L014', 'CC002', 'NV004', 10, 2024, 30, 3, 8000000, 500000, 300000, 200000, 8700000, '2024-10-21'),
('L015', 'CC006', 'NV005', 10, 2024, 28, 0, 7500000, 200000, 100000, 0, 7800000, '2024-10-22');
GO


INSERT INTO TraPhong (MaTraPhong, MaDatPhong, NgayTra, TienDatCoc)
VALUES 
('TP001', 'DP001', '2024-09-18', 100000),
('TP002', 'DP002', '2024-09-25', 150000),
('TP003', 'DP002', '2024-09-12', 200000);
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
SELECT * FROM ChamCong

Select kh.TenKhachHang, ctdp.NgayNhanPhong, ctdp.NgayTraPhong, ctdp.GiaMoiDem, ctdp.SoLuongPhong, ctdp.TongGia, ctdp.PhuongThucThanhToan, lp.TenLoaiPhong from KhachHang as kh
join ChiTietDatPhong as ctdp on kh.MaKhachHang = ctdp.MaKhachHang
join LoaiPhong as lp on ctdp.MaLoaiPhong = lp.MaLoaiPhong
--join LoaiDichVu as ldv on lp.MaLoaiPhong = ldv.MaLoaiPhong
--join DichVu as dv on ldv.MaLoaiDichVu = dv.MaLoaiDichVu
where ctdp.NgayNhanPhong BETWEEN '2024-09-19' AND '2024-11-12'

select kh.MaKhachHang,kh.TenKhachHang,kh.Email,kh.DiaChi,kh.CCCD,kh.SDT,ctdp.GiaMoiDem,ctdp.SoLuongPhong,ctdp.TongGia,ctdp.NgayNhanPhong,ctdp.NgayTraPhong from ChiTietDatPhong as ctdp
join KhachHang as kh on ctdp.MaKhachHang = kh.MaKhachHang
join Phong as p on ctdp.MaPhong = p.MaPhong
where ctdp.NgayTraPhong  between '2024-09-19' AND '2024-11-12'
go

Create Procedure [dbo].[HienThiThongKeKhachHang]
@TuNgay date,
@DenNgay date
as
begin
select kh.MaKhachHang,kh.TenKhachHang,kh.Email,kh.DiaChi,kh.CCCD,kh.SDT,ctdp.GiaMoiDem,ctdp.SoLuongPhong,ctdp.TongGia,ctdp.NgayNhanPhong,ctdp.NgayTraPhong from ChiTietDatPhong as ctdp
join KhachHang as kh on ctdp.MaKhachHang = kh.MaKhachHang
join Phong as p on ctdp.MaPhong = p.MaPhong
where ctdp.NgayTraPhong  between @TuNgay  AND @DenNgay
end
Go
