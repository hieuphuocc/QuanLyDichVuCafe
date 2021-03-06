USE [master]
GO
/****** Object:  Database [QuanLyQuanCafe]    Script Date: 28/12/2021 9:14:20 SA ******/
CREATE DATABASE [QuanLyQuanCafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyQuanCafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyQuanCafe.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyQuanCafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyQuanCafe_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyQuanCafe] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyQuanCafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyQuanCafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyQuanCafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyQuanCafe', N'ON'
GO
USE [QuanLyQuanCafe]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[username] [nvarchar](100) NOT NULL,
	[name] [nvarchar](100) NOT NULL CONSTRAINT [DF__Account__name__145C0A3F]  DEFAULT (N''),
	[password] [nvarchar](100) NOT NULL CONSTRAINT [DF__Account__passwor__15502E78]  DEFAULT ((0)),
	[account_role] [int] NOT NULL CONSTRAINT [DF__Account__account__164452B1]  DEFAULT ((0)),
 CONSTRAINT [PK__Account__F3DBC573BC089037] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_checkin] [date] NOT NULL DEFAULT (getdate()),
	[date_checkout] [date] NULL,
	[table_id] [int] NOT NULL,
	[status] [int] NOT NULL DEFAULT ((0)),
	[discount] [int] NULL,
	[totalPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bill_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[count] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Tên'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Tên'),
	[category_id] [int] NOT NULL,
	[price] [float] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TableProduct]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableProduct](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Tên'),
	[status] [nvarchar](100) NOT NULL DEFAULT (N'Trống'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Account] ([username], [name], [password], [account_role]) VALUES (N'hieu', N'Trần Văn Phước Hiếu', N'123', 1)
INSERT [dbo].[Account] ([username], [name], [password], [account_role]) VALUES (N'husc', N'Xây dựng ứng dụng với .NET Framework', N'123', 1)
INSERT [dbo].[Account] ([username], [name], [password], [account_role]) VALUES (N'taikhoan', N'Tài khoản', N'0', 0)
INSERT [dbo].[Account] ([username], [name], [password], [account_role]) VALUES (N'test', N'Tài khoản Test', N'123', 0)
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [date_checkin], [date_checkout], [table_id], [status], [discount], [totalPrice]) VALUES (27, CAST(N'2021-12-26' AS Date), CAST(N'2021-12-26' AS Date), 15, 1, 0, 10000)
INSERT [dbo].[Bill] ([id], [date_checkin], [date_checkout], [table_id], [status], [discount], [totalPrice]) VALUES (28, CAST(N'2021-12-27' AS Date), CAST(N'2021-12-27' AS Date), 1, 1, 0, 1000)
INSERT [dbo].[Bill] ([id], [date_checkin], [date_checkout], [table_id], [status], [discount], [totalPrice]) VALUES (29, CAST(N'2021-12-27' AS Date), CAST(N'2021-12-27' AS Date), 2, 1, 0, 60000)
INSERT [dbo].[Bill] ([id], [date_checkin], [date_checkout], [table_id], [status], [discount], [totalPrice]) VALUES (30, CAST(N'2021-12-27' AS Date), CAST(N'2021-12-27' AS Date), 8, 1, 20, 92000)
INSERT [dbo].[Bill] ([id], [date_checkin], [date_checkout], [table_id], [status], [discount], [totalPrice]) VALUES (31, CAST(N'2021-12-27' AS Date), CAST(N'2021-12-27' AS Date), 1, 1, 30, 7000)
INSERT [dbo].[Bill] ([id], [date_checkin], [date_checkout], [table_id], [status], [discount], [totalPrice]) VALUES (32, CAST(N'2021-12-27' AS Date), CAST(N'2021-12-27' AS Date), 10, 1, 0, 24000)
INSERT [dbo].[Bill] ([id], [date_checkin], [date_checkout], [table_id], [status], [discount], [totalPrice]) VALUES (42, CAST(N'2021-12-28' AS Date), CAST(N'2021-12-28' AS Date), 4, 1, 10, 95400)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (31, 27, 1, 1)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (32, 28, 11, 1)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (33, 29, 11, 2)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (34, 32, 9, 1)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (35, 32, 1, 1)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (36, 31, 1, 1)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (37, 29, 1, 1)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (38, 30, 14, 2)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (39, 30, 12, 1)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (40, 30, 11, 1)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (41, 42, 19, 1)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (42, 42, 17, 2)
INSERT [dbo].[BillInfo] ([id], [bill_id], [product_id], [count]) VALUES (43, 42, 23, 3)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (1, N'Nước có gas')
INSERT [dbo].[Category] ([id], [name]) VALUES (2, N'Cà phê')
INSERT [dbo].[Category] ([id], [name]) VALUES (3, N'Trà sữa')
INSERT [dbo].[Category] ([id], [name]) VALUES (4, N'Nước trái cây')
INSERT [dbo].[Category] ([id], [name]) VALUES (6, N'Sữa chua')
INSERT [dbo].[Category] ([id], [name]) VALUES (7, N'Đồ uống nóng')
INSERT [dbo].[Category] ([id], [name]) VALUES (8, N'Đồ uống lạnh')
INSERT [dbo].[Category] ([id], [name]) VALUES (9, N'Trà')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (1, N'Sting dâu', 1, 10000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (2, N'Sting vàng', 1, 10000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (3, N'Trà sữa trân châu', 3, 30000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (4, N'Trà sữa matcha', 3, 35000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (6, N'Bò húc', 1, 15000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (7, N'Cà phê sữa đá', 2, 12000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (8, N'Cà phê đen', 2, 10000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (9, N'Coca - Cola', 1, 14000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (11, N'Nước cam', 4, 25000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (12, N'Nước ép dưa hấu', 4, 30000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (14, N'Nước chanh dây', 4, 30000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (15, N'Pepsi', 1, 9000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (16, N'7Up', 1, 10000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (17, N'Sữa chua dâu', 6, 25000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (18, N'Number One', 1, 15000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (19, N'Trà gừng', 9, 20000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (20, N'Trà đào', 9, 15000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (21, N'Trà tắc', 3, 10000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (22, N'Bạc xỉu', 2, 12000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (23, N'Caocao sữa nóng', 7, 12000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (24, N'Cà phê rang xay', 2, 20000)
INSERT [dbo].[Product] ([id], [name], [category_id], [price]) VALUES (25, N'Trà sữa bạc hà', 3, 35000)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[TableProduct] ON 

INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (1, N'Bàn 1', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (2, N'Bàn 2', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (3, N'Bàn 3', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (4, N'Bàn 4', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (5, N'Bàn 5', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (6, N'Bàn 6', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (7, N'Bàn 7', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (8, N'Bàn 8', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (9, N'Bàn 9', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (10, N'Bàn 10', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (11, N'Bàn 11', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (12, N'Bàn 12', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (13, N'Bàn 13', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (14, N'Bàn 14', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (15, N'Bàn 15', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (16, N'Bàn 16', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (17, N'Bàn 17', N'Trống')
INSERT [dbo].[TableProduct] ([id], [name], [status]) VALUES (19, N'Bàn 18', N'Trống')
SET IDENTITY_INSERT [dbo].[TableProduct] OFF
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([table_id])
REFERENCES [dbo].[TableProduct] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([bill_id])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
/****** Object:  StoredProcedure [dbo].[AddBill]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddBill]
@table_id INT
AS
BEGIN
	INSERT Bill(date_checkin,date_checkout,table_id,status,discount)
	VALUES
		(GETDATE(),
		NULL,
		@table_id,
		0,
		0)
END

GO
/****** Object:  StoredProcedure [dbo].[AddBillInfo]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddBillInfo]
@idBill INT, @idProduct INT, @count INT
AS
BEGIN
	DECLARE @isExistsBillInfo INT
	DECLARE @ProductCount INT = 1

	SELECT @isExistsBillInfo = id, @ProductCount = bi.count 
	FROM BillInfo as bi
	WHERE bill_id = @idBill AND product_id = @idProduct

	IF(@isExistsBillInfo > 0)
	BEGIN
		DECLARE @newcount INT = @ProductCount + @count
		IF (@newcount > 0)
			UPDATE BillInfo SET count = @ProductCount + @count WHERE bill_id = @idBill AND product_id = @idProduct
		ELSE
			DELETE BillInfo WHERE bill_id = @idBill AND product_id = @idProduct
	END
	ELSE
		BEGIN
			INSERT BillInfo(bill_id,product_id,count)
			VALUES(@idBill,@idProduct,@count)
		END
END

GO
/****** Object:  StoredProcedure [dbo].[checkLogin]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[checkLogin]
@username nvarchar(100), @password nvarchar(100)
AS
BEGIN
	SELECT * FROM Account WHERE username = @username AND password = @password
END

GO
/****** Object:  StoredProcedure [dbo].[GetAccountByUsername]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetAccountByUsername]
@username nvarchar(100)
AS
BEGIN
	SELECT * FROM Account WHERE username = @username
END

GO
/****** Object:  StoredProcedure [dbo].[GetListBillByDate]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetListBillByDate]
@date_checkin DATE, @date_checkout DATE
AS
	BEGIN
		SELECT tp.name AS [Tên bàn], b.date_checkin AS [Ngày vào],b.date_checkout AS [Ngày ra], b.discount AS [Giảm giá] , b.totalPrice AS [Tổng tiền]
		FROM Bill AS b JOIN TableProduct AS tp ON tp.id = b.table_id
		WHERE b.date_checkin >= @date_checkin AND b.date_checkout <= @date_checkout AND b.status = 1
	END

GO
/****** Object:  StoredProcedure [dbo].[GetTableList]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetTableList]
AS
	SELECT * FROM TableProduct

GO
/****** Object:  StoredProcedure [dbo].[SwitchTable]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SwitchTable]
@idTable1 INT, @idTable2 int
AS
	BEGIN
		DECLARE @idFirstBill int
		DECLARE @idSecondBill int
		DECLARE @isFirstTableEmpty INT = 1
		DECLARE @isSecondTableEmpty INT = 1

		SELECT @idSecondBill = id FROM Bill WHERE table_id = @idTable2 AND status = 0
		SELECT @idFirstBill = id FROM Bill WHERE table_id = @idTable1 AND status = 0

		IF(@idFirstBill IS NULL)
			BEGIN
					INSERT Bill(date_checkin,date_checkout,table_id,status)
					VALUES(GETDATE(),NULL,@idTable1,0)
					SELECT @idFirstBill = MAX(id) FROM Bill WHERE table_id = @idTable1 AND status = 0

			END
		SELECT @isFirstTableEmpty = COUNT(*) FROM BillInfo WHERE bill_id = @idFirstBill

		IF(@idSecondBill IS NULL)
			BEGIN
					INSERT Bill(date_checkin,date_checkout,table_id,status)
					VALUES(GETDATE(),NULL,@idTable2,0)
					SELECT @idFirstBill = MAX(id) FROM Bill WHERE table_id = @idTable2 AND status = 0
			END
		SELECT @isSecondTableEmpty = COUNT(*) FROM BillInfo WHERE bill_id = @idSecondBill

		SELECT id INTO IDBillInfoTable FROM BillInfo WHERE bill_id = @idSecondBill
		UPDATE BillInfo SET bill_id = @idSecondBill WHERE bill_id = @idFirstBill
		UPDATE BillInfo SET bill_id = @idFirstBill WHERE id IN( SELECT * FROM IDBillInfoTable)

		DROP TABLE IDBillInfoTable

		IF(@isFirstTableEmpty = 0)
			UPDATE TableProduct SET status = N'Trống' WHERE id = @idTable2

		IF(@isSecondTableEmpty = 0)
			UPDATE TableProduct SET status = N'Trống' WHERE id = @idTable1
	END

GO
/****** Object:  StoredProcedure [dbo].[UpdateAccount]    Script Date: 28/12/2021 9:14:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateAccount]
@username NVARCHAR(100), @name NVARCHAR(100), @password NVARCHAR(100), @newpassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0

	SELECT @isRightPass = COUNT(*) FROM Account WHERE username = @username AND password = @password
	IF (@isRightPass = 1)
	BEGIN
		IF(@newpassword = null OR @newpassword = '')
			UPDATE Account SET name = @name WHERE username = @username
		ELSE
			UPDATE Account SET name = @name, password = @newpassword WHERE username = @username
	END
END

GO
USE [master]
GO
ALTER DATABASE [QuanLyQuanCafe] SET  READ_WRITE 
GO
