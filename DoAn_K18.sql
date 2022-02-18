
-- Tạo database BanHangOnline
create database BanHang18
go
use BanHang18
go
create table nhomTk(
	maNhom int identity primary key,
	tenNhom nvarchar(35) not null default N'Giao hàng',
	ghiChu ntext default ''
);
go

create table loaiSP(
	maLoai int not null primary key identity(1,1),
	loaiSP nvarchar(88) not null default N'Dụng cụ nhà bếp', 
	ghiChu ntext default ''
);
go

create table quanHuyen(
	maQH int not null primary key identity,
	tenQH nvarchar(88) not null ,
	tinhThanh nvarchar(65) not null, 
	ghiChu ntext default ''
);
go
-- 1: Tạo Table [Accounts] chứa tài khoản thành viên được phép sử dụng các trang quản trị ----
create table taiKhoanTV
(
	taiKhoan varchar(20) primary key not null,
	matKhau varchar(20) not null,
	maNhom int not null references nhomTk(maNhom),
	hoDem nvarchar(50) null,
	tenTV nvarchar(30) not null,
	ngaysinh datetime ,
	gioiTinh bit default 1,
	soDT nvarchar(20),
	email nvarchar(50),
	diaChi nvarchar(250),
	maQH int not null references quanHuyen(maQH),
	trangThai bit default 0,
	ghiChu ntext
)
go

-- 2: Tạo Table [Customers] chứa Thông tin khách hàng  ---------------------------------------
create table khachHang
(
	maKH varchar(10) primary key not null,
	tenKH nvarchar(50) not null,
	soDT varchar(20) ,
	email varchar(50),
	diaChi nvarchar(250),
	maQH int not null references quanHuyen(maQH),
	ngaySinh datetime ,
	gioiTinh bit default 1,
	ghiChu ntext
)
go

-- 3: Tạo Table [Articles] chứa thông tin về các bài viết phục vụ cho quảng bá sản phẩm, ------
--    xu hướng mua sắm hiện nay của người tiêu dùng , ...             ------------------------- 
create table baiViet
(
	maBV varchar(10) primary key not null,
	tenBV nvarchar(250) not null,
	hinhDD varchar(max),
	ndTomTat nvarchar(2000),
	ngayDang datetime ,
	maLoai int not null references loaiSP(maLoai),
	noiDung nvarchar(4000),
	taiKhoan varchar(20) not null ,
	daDuyet bit default 0,
	foreign key (taiKhoan) references taiKhoanTV(taiKhoan) 
)
go

-- 4: Tạo Table [Products] chứa thông tin của sản phẩm mà shop kinh doanh online --------------
create table sanPham
(
	maSP varchar(10) primary key not null,
	tenSP nvarchar(500) not NULL,
	hinhDD varchar(max) DEFAULT '',
	ndTomTat nvarchar(2000) DEFAULT '',
	nhaSanXuat nvarchar(89) default '',
	ngayDang DATETIME DEFAULT CURRENT_TIMESTAMP,
	maLoai int not null references loaiSP(maLoai),
	noiDung nvarchar(4000) DEFAULT '',
	taiKhoan varchar(20) not null foreign key references taiKhoanTV(taiKhoan),
	daDuyet bit default 0,
	giaBan INTEGER DEFAULT 0,
	giamGia INTEGER DEFAULT 0 CHECK (giamGia>=0 AND giamGia<=100)
)
go

-- 5: Tạo Table [Orders] chứa danh sách đơn hàng mà khách đã đặt mua thông qua web ------------
create table donHang
(
	soDH varchar(10) primary key not null ,
	maKH varchar(10) not null foreign key references khachHang(maKH),
	taiKhoan varchar(20) not null foreign key references taiKhoanTV(taiKhoan),
	ngayDat datetime,
	daKichHoat bit default 1,
	ngayGH datetime,
	diaChiGH nvarchar(250),
	ghiChu ntext
)
go	

-- 6: Tạo Table [OrderDetails] chứa thông tin chi tiết của các đơn hàng ---
--    mà khách đã đặt mua với các mặt hàng cùng số lượng đã chọn ---------- 
create table ctDonHang	
(
	soDH varchar(10) not null foreign key references donHang(soDH),
	maSP varchar(10) not null foreign key references sanPham(maSP),
	soLuong int,
	giaBan bigint,
	giamGia BIGINT,
	PRIMARY KEY (soDH, maSP)
)
go

-- 7: Tạo Table chứa thông tin trạng thái của đơn hàng
create table trangThai
(
	maTT int primary key not null,
	tenTT nvarchar(50)
)
go	


/*========================== Nhập dữ liệu mẫu ==============================*/

--- Insert data to nhomTK, loaiSP, quanHuyen
insert into nhomTk (tenNhom) values (N'Quản lý');
insert into nhomTk (tenNhom) values (N'Giao hàng');
insert into nhomTk (tenNhom) values (N'Marketing');

insert into loaiSP (loaiSP) values (N'Dụng cụ nhà bếp');
insert into loaiSP (loaiSP) values (N'Điện gia dụng');
insert into loaiSP (loaiSP) values (N'Trang trí nội thất');
insert into loaiSP (loaiSP) values (N'Dụng cụ thể thao');
insert into loaiSP (loaiSP) values (N'Thiết bị thông minh');
insert into loaiSP (loaiSP) values (N'Quần - Áo, Thời trang');

insert into quanHuyen (tenQH, tinhThanh) values (N'Q1', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q2', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q3', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q4', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q5', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q6', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q7', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q8', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q9', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q10', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q11', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Q12', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Bình Thạnh', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Bình Tân', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Bình chánh', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Tân Phú', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Cần Giờ', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Nhà Bè', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Củ Chi', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Phú Nhuận', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Tân Bình', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Hóc Môn', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Thủ Đức', N'TP Hồ Chí Minh');
insert into quanHuyen (tenQH, tinhThanh) values (N'Gò Vấp', N'TP Hồ Chí Minh');


-- YC 1: Nhập thông tin tài khoản, tối thiểu 5 thành viên sẽ dùng để làm việc với các trang: Administrative pages
insert into taiKhoanTV
values('minh','minhquang',1,'Nguyễn Minh','Quang',06/12/1996,1,0935694223,'minhminh@gmail.com','472 CMT8, P.11,Q3, TP.HCM',3,1,'')
insert into taiKhoanTV
values('amdin','toilaquanly',1,N'Nguyễn Quang',N'Hưng',06/12/1996,1,0935694223,'minhminh@gmail.com','472 CMT8, P.11,Q3, TP.HCM',3,1,'')
GO

-- YC3: Nhập thông tin bài viết, Tối thiểu 10 bài viết thuộc loại: giới thiệu sản phẩm, khuyến mãi, quảng cáo, ... 
--      liên quan đến sản phẩm mà bạn dự định kinh doanh trong đồ án sẽ thực hiện

-- YC3: Nhập thông tin sản phẩm, Tối thiểu 30 sản phẩm liên quan đến mục tiêu mà bạn sẽ thực hiện trong đồ án
INSERT INTO dbo.sanPham 
        (maSP, tenSP, hinhDD, ndTomTat, maLoai, noiDung, taiKhoan, giaBan, giamGia)
VALUES  ( '01' , -- maSP - varchar(10)
          N'Túi xách nam - da bò' , 
          '/images/product06.jpg', 
          N'Giới thiệu túi xách nam bằng vật liệu da bò' , 
          6 , -- loaiHang - nvarchar(30)
          N'Nội dung Giới thiệu túi xách nam bằng vật liệu da bò' ,
          'minh' , -- taiKhoan - varchar(20)
          1650000 , -- giaBan - int
          20  -- %
        ) 
INSERT INTO dbo.sanPham 
        (maSP, tenSP, hinhDD, ndTomTat, maLoai, noiDung, taiKhoan, giaBan, giamGia)
VALUES  ( '02' , -- maSP - varchar(10)
          N'Túi xách thời trang trẻ trung - vải bố' , 
          '/images/product01.jpg', 
          N'Giới thiệu túi xách nam bằng vật liệu da bò' , 
          6 , -- loaiHang - nvarchar(30)
          N'Nội dung Giới thiệu túi xách nam bằng vật liệu da bò' ,
          'minh' , -- taiKhoan - varchar(20)
          450000 , -- giaBan - int
          15  -- %
        ) 
INSERT INTO dbo.sanPham 
        (maSP, tenSP, hinhDD, ndTomTat, maLoai, noiDung, taiKhoan, giaBan, giamGia)
VALUES  ( '03' , -- maSP - varchar(10)
          N'Túi xách nữ - da trăn' , 
          '/images/product07.jpg', 
          N'Giới thiệu túi xách nữ bằng vật liệu da trăn' , 
          6 , -- loaiHang - nvarchar(30)
          N'Nội dung Giới thiệu túi xách nam bằng vật liệu da trăn' ,
          'minh' , -- taiKhoan - varchar(20)
          2300000 , -- giaBan - int
          20  -- %
        ) 
INSERT INTO dbo.sanPham 
        (maSP, tenSP, hinhDD, ndTomTat, maLoai, noiDung, taiKhoan, giaBan, giamGia)
VALUES  ( '04' , -- maSP - varchar(10)
          N'Đồng hồ nam - cơ thụy sỹ' , 
          '/images/product02.jpg', 
          N'Giới thiệu đồng hồ nam, mặt tròn của thụy sỹ' , 
          6 , -- loaiHang - nvarchar(30)
          N'Nội dung Giới thiệu đồng hồ nam, mặt tròn của thụy sỹ' ,
          'minh' , -- taiKhoan - varchar(20)
          4500000 , -- giaBan - int
          35  -- %
        ) 
INSERT INTO dbo.sanPham 
        (maSP, tenSP, hinhDD, ndTomTat, maLoai, noiDung, taiKhoan, giaBan, giamGia)
VALUES  ( '05' , -- maSP - varchar(10)
          N'Giày nam trẻ trung' , 
          '/images/product04.jpg', 
          N'Giới thiệu giày nam, chất liệu vải' , 
          6 , -- loaiHang - nvarchar(30)
          N'Nội dung Giới thiệu giày nam, chất liệu vải' ,
          'minh' , -- taiKhoan - varchar(20)
          3500000 , -- giaBan - int
          23  -- %
        ) 
INSERT INTO dbo.sanPham 
        (maSP, tenSP, hinhDD, ndTomTat, maLoai, noiDung, taiKhoan, giaBan, giamGia)
VALUES  ( '06' , -- maSP - varchar(10)
          N'Giày nữ thời trang' , 
          '/images/product05.jpg', 
          N'Giới thiệu Giày nữ thời trang' , 
          6 , -- loaiHang - nvarchar(30)
          N'Nội dung Giới thiệu Giày nữ thời trang' ,
          'minh' , -- taiKhoan - varchar(20)
          31500000 , -- giaBan - int
          42  -- %
        ) 
INSERT INTO dbo.sanPham 
        (maSP, tenSP, hinhDD, ndTomTat, maLoai, noiDung, taiKhoan, giaBan, giamGia)
VALUES  ( '07' , -- maSP - varchar(10)
          N'Dây nịt nam - trung niên' , 
          '/images/product08.jpg', 
          N'Giới thiệu Dây nịt nam - trung niên' , 
          6 , -- loaiHang - nvarchar(30)
          N'Nội dung Giới thiệu Dây nịt nam - trung niên' ,
          'minh' , -- taiKhoan - varchar(20)
          300000 , -- giaBan - int
          12  -- %
        ) 
INSERT INTO dbo.sanPham 
        (maSP, tenSP, hinhDD, ndTomTat, maLoai, noiDung, taiKhoan, giaBan, giamGia)
VALUES  ( '08' , -- maSP - varchar(10)
          N'Bóp da nam - cá sấu' , 
          '/images/product03.jpg', 
          N'Giới thiệu Bóp da nam - cá sấu' , 
          6 , -- loaiHang - nvarchar(30)
          N'Nội dung Giới thiệu Bóp da nam - cá sấu' ,
          'minh' , -- taiKhoan - varchar(20)
          1300000 , -- giaBan - int
          27  -- %
        ) 


go

---Thêm thông tin cho table trạng thái
insert into trangThai (maTT, tenTT) values (1, N'Đơn hàng bị hủy');
insert into trangThai (maTT, tenTT) values (2,N'Đang xử lý');
insert into trangThai (maTT, tenTT) values (3,N'Đang giao');
insert into trangThai (maTT, tenTT) values (4,N'Đã thu tiền');


--- 1/ - Simple case :: NewCustomer Stored Procedure

--alter proc NewCustomer(@maKH varchar(10),
--						@tenKH nvarchar(50), 
--						@gioiTinh bit, 
--						@ngaySinh datetime, 
--						@soDT varchar(2),
--						@email varchar(50),
--						@diaChi nvarchar(250),
--						@maQH int,
--						@ghiChu ntext)
						 
--AS
--	Insert into khachHang (maKH, tenKH, gioiTinh, ngaySinh, soDT, email, diaChi, maQH, ghiChu)
--				values    (@makh, @tenKH, @gioiTinh, @ngaySinh, @soDT, @email, @diaChi, @maQH, @ghiChu)


--execute NewCustomer 'KH001555', N'Phan Chí Trung', 1, '2000/01/23', '0332289599', 'pahnchitrung2310@gmail.com', N'Vườn Lài', 3, N'Không có gì';


--- 2/ - Simple case :: ChangePassword Stored Procedure
--create proc Change_Password(@taiKhoan varchar(20), @matKhau varchar(20))
--With Encryption
--As
--	Update taiKhoanTV set matKhau = @matKhau where taiKhoan = @taiKhoan

--go

go

create proc In_Don_Hang (@soDH as varchar(10))
With Encryption
As
Begin 
	--Khai báo các biến cần thiết
	Declare @tenKH nvarchar(50), @ngayGiao datetime, @diaChi nvarchar(50);
	Declare @tongTien bigint, @thueVAT int, @SoTienPhaiTra bigint;
	--Khai báo con trỏ sẽ sử dụng để chứa danh sách các dòng là chi tiết đơn hàng cần in
	Declare chiTietDH Cursor For Select s.tenSP, c.soLuong, c.giaBan From ctDonHang c inner join sanPham s on (s.maSP = c.maSP)  Where soDH = @soDH;
	--Khởi gán giá trị cho các biến trước khi sử dụng 
	set @tongTien = 0;
	set @thueVAT = 0;
	set @SoTienPhaiTra = 0;
	--Lấy thông tin tên khách hàng, địa chỉ, ngày giao và các biến cần thiết 
	Select @tenKH = k.tenKH, @ngayGiao=d.ngayGH, @diaChi = d.diaChiGH 
	from khachHang k inner join donHang d on (d.maKH = k.maKH)
	Where d.soDH = @soDH;
	--In thông tin chính của đơn hàng
	print N'Đơn hàng số: '+@soDH+ N' -- Ngày giao: '+ format(@ngayGiao, 'hh:mm dd/MM/yyyy')
	print N'Khách hàng: ' +@tenKH
	print N'Địa chỉ giao hàng: '+@diaChi
	print N'------------------------------------------------------------------------------'
	print N'|  STT  |  Sản phẩm                   | Số lượng |   Giá bán   |   Trị giá   |' 
	print N'|-------|-----------------------------|----------|-------------|-------------|' 
	print N'|                                                                            |'
	--Làm việc với con trỏ 

	Declare @tenSP nvarchar(50), @soLuong int, @giaBan int, @stt int
	set @stt = 1
	Open chiTietDH
	Fetch next from chiTietDH into @tenSP, @soLuong, @giaBan
	while @@FETCH_STATUS = 0 
	begin 
		print '| ' + format(@stt, '0')+'     |'+@tenSP + '         |' +format(@soLuong, '0')+ '         |' +format(@giaBan, '0')+ '      |'+ format((@soLuong*@giaBan), '0')+ '      |';
		set @stt = @stt + 1;
		set @tongTien = @tongTien + (@soLuong*@giaBan);
		--Đọc dữ liêu từ dòng tiếp theo có trong cursor
		Fetch next from chiTietDH into @tenSP, @soLuong, @giaBan 
	end
	 --Đọc hết dữ liệu trong Cursor
	 set @thueVAT = (10*@tongTien)/100;
	 set @SoTienPhaiTra = (@tongTien + @thueVAT);
	 print N'|-------|-----------------------------|----------|-------------|-------------|' 
	 print N'|   Tổng tiền                                                   '+ format(@tongTien, '#,### VNĐ') +'|'
	 print N'|   Thuế VAT (10%)                                                '+ format(@thueVAT, '#,### VNĐ') +'|'
	 print N'|   Số tiền phải trả                                            '+ format(@SoTienPhaiTra, '#,### VNĐ') +'|'
	 print N'|-----------------------------------------------------------------------------' 

	 --Đóng và thu hồi bộ nhớ đã cấp cho con trỏ
	 Close chiTietDH
	 Deallocate chiTietDH
End
go


--Customer by paging
create proc customerByPaing (@pageNumber int=1) --Khi chạy là trang 1
as
begin
	declare @start int , @end int, @n int 
	set @n = 25 --1 trang có 25 dòng
	set @start = (@pageNumber-1)*@n +1
	set @end = @start +@n

	--Run query and return from Start to end value
	SELECT * FROM 
			(Select ROW_NUMBER() over (order by tenKH) as Stt, k.tenKH, iif(gioiTinh=1,'Nam', N'Nữ') as gioiTinh,
			ngaySinh, soDT, email, diaChi + ', ' +q.tenQH+', ' + q.tinhThanh as diaChi, k.ghiChu
			From khachHang k inner join quanHuyen q on (k.maQH = q.maQH)) n
	WHERE Stt >= @start and Stt < @end
end 
go


---Báo cáo doanh thu các ngày trong tuần
create proc reportByWeekDay(@n int)
with encryption 
as
begin 
	set @n = @n * 1 --Tính lại n thành số âm
	select DATENAME(weekday, d.ngayGH) as 'By Weekday',
			format(sum(c.soLuong * c.giaBan - c.soLuong * c.giaBan * c.giamGia/100), '#,### VNĐ') as 'Total of money'
			from donHang d inner join ctDonHang c on (d.soDH = c.soDH)
			where ngayGH between DATEADD(day, @n, GETDATE()) and GETDATE()
			group by DATENAME(weekday, d.ngayGH)
end



--Lệnh sửa cấu trúc table sanPham
Alter table sanPham alter column hinhDD varchar(max);


--Lệnh sửa cấu trúc table baiViet
Alter table baiViet alter column hinhDD varchar(max);
exec reportByWeekDay 30

--Nhớ sửa lại cấu trú của table taiKhoanTV để field matKhau có độ dài đủ lớn để chứa được kết quả sau khi Hash chuỗi mật khẩu gốc:
Alter table taiKhoanTV Alter column matKhau varchar(100);

SELECT c.maSP, s.tenSP, c.soLuong, c.giaBan, c.giamGia
From ctDonHang c inner join sanPham s on (c.maSP = s.maSP)
where c.soDH = 'DH05'



select t.tenKH, soDT, d.soDH , d.taiKhoan, d.ngayDat, d.ngayGH, diaChiGH, c.maSP, c.soLuong, c.giaBan, c.giamGia, (select count(*) from ctDonHang where soDH = d.soDH) as N'Số SP' from khachHang t inner join donHang d on (t.maKH = d.maKH) inner join ctDonHang c on (d.soDH = c.soDH)