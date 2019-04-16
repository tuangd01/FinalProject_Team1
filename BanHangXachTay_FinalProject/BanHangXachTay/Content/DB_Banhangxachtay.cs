/*
 
Create database DBBANHANGXACHTAY

GO

USE DBBANHANGXACHTAY

CREATE TABLE tableTTKH (
	idKH int identity(1,1),
	maKH varchar(7) primary key,
	tenKH nvarchar(50),
	gioitinh nvarchar(10),
	sodienthoaiKH varchar(10),
	diachi nvarchar(max),
	ghichu nvarchar(max)
)

CREATE TABLE tableTTSP (
	idSP int identity(1,1),
	maSP varchar(7) primary key,
	tenSP nvarchar(50),
	dongia int,
	soluong int,
	ngaynhap date,
	ghichu nvarchar(max)

)

CREATE TABLE tableTTHD (
	idHD int identity(1,1) primary key,
	maKH varchar(7),
	tenKH nvarchar(50),
	sodienthoaiKH varchar(10),
	ngaydathang date,
	ngaynhanhang date,
	diachinhanhang nvarchar(max),
	maSP varchar(7),
	tenSP nvarchar(50),
	dongia int,
	soluong int,
	thanhtien int,
	ghichu nvarchar(max),
	
)
 
 */