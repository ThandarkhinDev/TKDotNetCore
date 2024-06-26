USE [master]
GO
/****** Object:  Database [TKDotNetCore]    Script Date: 6/27/2024 10:04:58 AM ******/
CREATE DATABASE [TKDotNetCore] ON  PRIMARY 
( NAME = N'TKDotNetCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TKDotNetCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TKDotNetCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TKDotNetCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TKDotNetCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TKDotNetCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TKDotNetCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TKDotNetCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TKDotNetCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TKDotNetCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [TKDotNetCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TKDotNetCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TKDotNetCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TKDotNetCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TKDotNetCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TKDotNetCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TKDotNetCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TKDotNetCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TKDotNetCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TKDotNetCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TKDotNetCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TKDotNetCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TKDotNetCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TKDotNetCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TKDotNetCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TKDotNetCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TKDotNetCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TKDotNetCore] SET RECOVERY FULL 
GO
ALTER DATABASE [TKDotNetCore] SET  MULTI_USER 
GO
ALTER DATABASE [TKDotNetCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TKDotNetCore] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TKDotNetCore', N'ON'
GO
USE [TKDotNetCore]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 6/27/2024 10:04:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'Title1', N'Author1', N'Content1')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'Title2', N'Author2', N'Content2')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'Title2', N'Author2', N'Content2')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'Title2', N'Author2', N'Content2')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'Title6a', N'Author6a', N'Content6a')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (7, N'Title6b', N'Author6b', N'Content6b')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (8, N'Title7', N'Author7', N'Content7')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (9, N'Title8', N'Author8', N'Content8')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
GO
USE [master]
GO
ALTER DATABASE [TKDotNetCore] SET  READ_WRITE 
GO
