USE [master]
GO
/****** Object:  Database [MerchandisingManagement]    Script Date: 8/9/2021 00:44:24 ******/
CREATE DATABASE [MerchandisingManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MerchandisingManagement', FILENAME = N'C:\Users\Home PC\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\MerchandisingManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MerchandisingManagement_log', FILENAME = N'C:\Users\Home PC\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\MerchandisingManagement.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MerchandisingManagement] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MerchandisingManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MerchandisingManagement] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [MerchandisingManagement] SET ANSI_NULLS ON 
GO
ALTER DATABASE [MerchandisingManagement] SET ANSI_PADDING ON 
GO
ALTER DATABASE [MerchandisingManagement] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [MerchandisingManagement] SET ARITHABORT ON 
GO
ALTER DATABASE [MerchandisingManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MerchandisingManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [MerchandisingManagement] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [MerchandisingManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [MerchandisingManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MerchandisingManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MerchandisingManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [MerchandisingManagement] SET  MULTI_USER 
GO
ALTER DATABASE [MerchandisingManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MerchandisingManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MerchandisingManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MerchandisingManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MerchandisingManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MerchandisingManagement] SET QUERY_STORE = OFF
GO
USE [MerchandisingManagement]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MerchandisingManagement]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/9/2021 00:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [nvarchar](50) NOT NULL,
	[CatergoryName] [nvarchar](50) NULL,
	[MinimumStockQuantity] [int] NULL,
	[EntryDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 8/9/2021 00:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Title] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CategoryName] [nvarchar](50) NULL,
	[StockQuantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SearchProduct]    Script Date: 8/9/2021 00:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchProduct] @SearchKeyword nvarchar(30) AS BEGIN 
SET NOCOUNT ON;
SELECT 
  pe.Title, 
  pe.CategoryName, 
  pe.Description, 
  pe.StockQuantity, 
  ce.MinimumStockQuantity 
FROM 
  Products pe 
  INNER JOIN Categories ce on pe.CategoryName = ce.CatergoryName 
  AND pe.StockQuantity > ce.MinimumStockQuantity 
WHERE 
  pe.CategoryName LIKE CONCAT('%', @SearchKeyword, '%') 
  OR pe.Description LIKE CONCAT('%', @SearchKeyword, '%') 
  OR pe.Title LIKE CONCAT('%', @SearchKeyword, '%'); END

GO
USE [master]
GO
ALTER DATABASE [MerchandisingManagement] SET  READ_WRITE 
GO
