Create database QLKhachHang;
use QLKhachHang;

drop database QLKhachHang;

Create table TaiKhoan(
	Ten_TK nvarchar(255) PRIMARY KEY,
	MatKhau_TK nvarchar(255) not null,
	Email_KH nvarchar(255),
	HoTen_KH nvarchar(255) not null,
	NgaySinh_KH SMALLDATETIME not null,
	GioiTinh_KH nvarchar(5) not null,
	ThuNhap_KH money
)

insert into TaiKhoan values('vancute1','123','van123@gmail.com',N'Đàm Thiện Nhàn Vân','08-23-2019',N'Nữ',1000000);
select * from  TaiKhoan;