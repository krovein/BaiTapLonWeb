use master
go
drop database ddthaoluan
go
create database ddthaoluan
go
use ddthaoluan
go
--Tạo Bảng--

create table tblQuyen
(
	ID_iMaquyen int primary key identity(1,1) not null,
	sTenquyen Nvarchar(50) not null
)
go
select * from tblQuyen
go

 

create table tblTaikhoan
(
	ID_sTentaikhoan varchar(20) primary key not null,
	sMatkhau varchar(255) not null,
	sHoten Nvarchar(50) not null,
	sEmail varchar(50),
	dNgaysinh date,
	bGioitinh bit,
	sDiachi Nvarchar(255),
	sAvatar varchar(255) default 'images/noavatar.png',
	FK_iMaquyen int not null,
	dtLastlogin datetime null,
)
go
select * from tblTaikhoan
go
create table tblNhomchude
(
	ID_iManhomchude int identity(1,1) primary key not null,
	sTennhomchude Nvarchar(255) not null 
)
go
create table tblChude
(
	ID_sMachude varchar(20) primary key not null,
	sTenchude Nvarchar(50) not null,
	FK_iManhomchude int not null,
	
)
go

select * from tblChude
go
create table tblBaiviet
(
	ID_iMabaiviet int identity(1,1) primary key not null,
	sTieudebaiviet Nvarchar(255) not null,
	sNoidungbaiviet Nvarchar(500) not null,
	FK_sMachude varchar(20) not null,
	sLinktai varchar(255) null,
	dtThoigiandang datetime not null,
	FK_sTentaikhoan varchar(20) not null,
	iDuyet int default 0,
)
go
create table tblbaitraloi
(
	ID_iMabaitraloi int primary key identity(1,1),
	sNoidungbaitraloi Nvarchar(500),
	FK_iMabaiviet int,
	fk_sNguoiviet varchar(20),
	dtThoigiantraloi datetime,
)
go
alter table tblTaikhoan add constraint fkquyen FOREIGN KEY (FK_iMaquyen) REFERENCES tblquyen(ID_iMaquyen)
alter table tblchude add constraint fkmanhomchude FOREIGN KEY (FK_iManhomchude) REFERENCES tblnhomchude(ID_iManhomchude)
alter table tblbaiviet add constraint fkmachude FOREIGN KEY (FK_sMachude) REFERENCES tblchude(ID_sMachude) on delete cascade
alter table tblbaiviet add constraint fknguoidang FOREIGN KEY (FK_sTentaikhoan) REFERENCES tblTaikhoan(ID_sTentaikhoan) ON UPDATE CASCADE
alter table tblbaitraloi add constraint fknguoitraloi FOREIGN KEY (fk_sNguoiviet) REFERENCES tblTaikhoan(ID_sTentaikhoan) ON UPDATE CASCADE
alter table tblbaitraloi add constraint fkbaiviet FOREIGN KEY (FK_iMabaiviet) REFERENCES tblBaiviet(ID_iMabaiviet) on DELETE cascade
go
insert into tblQuyen(sTenquyen) values ('Admin'),('User')

insert into tblTaikhoan(ID_sTentaikhoan,sMatkhau,sHoten,sEmail,dNgaysinh,bGioitinh,sDiachi,FK_iMaquyen) 
values ('quantrihethong','123456',N'Bùi Thị Nhung','btnhung1995@gmail.com','05/18/1995',0,N'Hà Nội','1')

insert into tblTaikhoan(ID_sTentaikhoan,sMatkhau,sHoten,sEmail,dNgaysinh,bGioitinh,sDiachi,FK_iMaquyen) 
values ('admin','123456',N'Lương Quốc Toản','toan19041995@gmail.com','04/19/1995',1,N'Hà Nội','1')

insert into tblTaikhoan(ID_sTentaikhoan,sMatkhau,sHoten,sEmail,dNgaysinh,bGioitinh,sDiachi,FK_iMaquyen) 
values ('toan','123456',N'Lương Quốc Toản','toan19041995@gmail.com','04/19/1995',1,N'Hà Nội','2')

insert into tblTaikhoan(ID_sTentaikhoan,sMatkhau,sHoten,sEmail,dNgaysinh,bGioitinh,sDiachi,FK_iMaquyen) 
values ('nhung1','123456',N'Bùi Thị Nhung','btnhung1995@gmail.com','05/18/1995',0,N'Hà Nội','2')

insert into tblTaikhoan(ID_sTentaikhoan,sMatkhau,sHoten,sEmail,dNgaysinh,bGioitinh,sDiachi,FK_iMaquyen) 
values ('nhung2','123456',N'Bùi Thị Nhung','btnhung1995@gmail.com','07/18/1995',1,N'Hà Nội','2')

insert into tblNhomchude(sTennhomchude) values (N'Tin tức & sự kiện'),(N'Tài liệu lập trình'),(N'Hỏi đáp')

insert into tblchude(ID_sMachude,sTenchude,FK_iManhomchude) values ('thongbao', N'Thông báo',1),('noiquy',N'Nội quy',1),
('tailieuphp','php',2),('tailieujava','java',2),('tailieuandroid','android',2),('tailieucshap','cshap',2),('tailieuasp.net','asp.net',2),
('hoidapphp','php',3),('hoidapjava','java',3),('hoidapandroid','android',3),('hoidapcshap','cshap',3),('hoidapasp.net','asp.net',3)

select * from tblTaikhoan
go
--select top 10 ID_iMabaiviet,sTieudebaiviet,dtthoigiandang,ID_sTentaikhoan
--from tblBaiviet,tbltaikhoan
--where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan

/*Chú Thích: alter table tblbaitraloi add dungsai nvarchar(500) not null
alter table tblbaitraloi drop column dungsai
alter table tblbaitraloi drop constraint fknguoitraloi*/

/*//Sử dụng procdure*/
create proc updatethongtin
@taikhoan varchar(20),
@hoten Nvarchar(50),
@email varchar(50),
@ngaysinh date,
@gioitinh bit,
@diachi Nvarchar(255)
as
begin
	update tblTaikhoan set sHoten=@hoten,sEmail=@email,dNgaysinh=@ngaysinh,bGioitinh=@gioitinh,sDiachi=@diachi where ID_sTentaikhoan=@taikhoan
end
go
--exec updatethongtin @taikhoan = 'nhung1' ,@hoten = N'Bùi Thị Nhung', @email='btnhung1995@gmail.com', @ngaysinh = '18/02/2015', @gioitinh = 0, @diachi=N'Hải phòng'
create proc capnhatthoigian
@thoigian datetime,
@taikhoan varchar(20)
as
begin
	update tblTaikhoan set dtLastlogin = @thoigian where ID_sTentaikhoan=@taikhoan
end
go
--delete from tblTaikhoan where ID_sTentaikhoan = 'quantrihethong'
create proc themtaikhoan
@tentaikhoan varchar(20),
@matkhau varchar(255) ,
@hoten Nvarchar(50) ,
@email varchar(50),
@ngaysinh date,
@gioitinh bit,
@diachi Nvarchar(255),
@maquyen int
as
begin 
insert into tblTaikhoan(ID_sTentaikhoan,sMatkhau,sHoten,sEmail,dNgaysinh,bGioitinh,sDiachi,FK_iMaquyen) values
(@tentaikhoan,@matkhau,@hoten,@email,@ngaysinh,@gioitinh,@diachi,@maquyen)
end
go