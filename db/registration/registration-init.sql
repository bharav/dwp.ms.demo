USE [master]
GO

IF DB_ID('RegistrationMaster') IS NOT NULL
  set noexec off               -- prevent creation when already exists

/****** Object:  Database [VehicleManufacture]    Script Date: 18.10.2019 18:33:09 ******/
CREATE DATABASE [RegistrationMaster];
GO

USE [RegistrationMaster]
GO

/****** Object:  Table [dbo].[Registration]    Script Date: 12/12/2019 8:31:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Registration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ChesisNo] [nvarchar](max) NOT NULL,
	[EngineNo] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[RegNo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[VehicleYetToRegister](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EngineNo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_VehicleYetToRegister] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

