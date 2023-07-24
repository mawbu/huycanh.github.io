CREATE TABLE LoaiSP (
    MaLoai char(2) PRIMARY KEY,
    TenLoai nvarchar(30) NOT NULL
);

CREATE TABLE SanPham (
    MaSP char(6) PRIMARY KEY,
    TenSP nvarchar(30) NOT NULL,
    NgayNhap DateTime,
    MaLoai char(2) REFERENCES LoaiSP(MaLoai)
);

ALTER TABLE SanPham
ADD FOREIGN KEY (MaLoai) REFERENCES LoaiSP(MaLoai)

INSERT INTO LoaiSP (MaLoai, TenLoai) VALUES
    ('01', N'Điện thoại'),
    ('02', N'Laptop');

	INSERT INTO SanPham (MaSP, TenSP, NgayNhap, MaLoai) VALUES
    ('SP001', N'Samsung Galaxy S10', '2023-07-20', '01'),
    ('SP002', N'iPhone 12', '2023-07-21', '01'),
    ('SP003', N'Dell XPS 13', '2023-07-22', '02');
