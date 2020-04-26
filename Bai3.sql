Create database QLKhachHang;
use QLKhachHang;

drop database QLKhachHang;

Create table TaiKhoan(
	Ten_TK nvarchar(255) PRIMARY KEY not null,
	MatKhau_TK nvarchar(255) not null,
	--re_MatKhau_TK nvarchar(255) not null check(dbo.check_mk(Ten_TK) = 1),
	Email_KH nvarchar(255) check(dbo.check_Email(Email_KH) = 1),
	HoTen_KH nvarchar(255) not null,
	NgaySinh_KH SMALLDATETIME not null check(NgaySinh_KH <= GETDATE()),
	GioiTinh_KH nvarchar(5) not null,
	ThuNhap_KH money check(ThuNhap_KH >= 1000000 AND ThuNhap_KH <= 50000000),
)

/*
go
create function dbo.check_mk(@Ten_TK nvarchar(255))
returns bit
as
begin
	declare @mk nvarchar(255);
	declare @re_mk nvarchar(255);
	declare @state int = 0;
	
	select @mk = MatKhau_TK from TaiKhoan where Ten_TK = @Ten_TK;
	select @re_mk = re_MatKhau_TK from TaiKhoan where Ten_TK = @Ten_TK;
	if (@mk = @re_mk)
		set @state = 1
	return @state
end;
*/
go

CREATE FUNCTION dbo.check_Email(@EMAIL varchar(255))

RETURNS bit as
BEGIN     
	  DECLARE @bitRetVal Bit = 1
	  IF (@EMAIL <> '' AND @EMAIL NOT LIKE '_%@__%.__%')
		 SET @bitRetVal = 0  -- Invalid
	  RETURN @bitRetVal
END 
go


insert into TaiKhoan values('vancute1','','van123@gmail.com',N'Đàm Thiện Nhàn Vân','08-23-2019',N'Nữ',1000000);
select * from  TaiKhoan;