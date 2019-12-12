USE [master]
GO

IF DB_ID('VehicleMaster') IS NOT NULL
  set noexec off               -- prevent creation when already exists

/****** Object:  Database [VehicleManufacture]    Script Date: 18.10.2019 18:33:09 ******/
CREATE DATABASE [VehicleMaster];
GO

USE [VehicleMaster]
GO

/****** Object:  Table [dbo].[Vehicle]    Script Date: 12/12/2019 8:32:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vehicle](
	[EngineNo] [nvarchar](450) NOT NULL,
	[ChesisNo] [nvarchar](max) NOT NULL,
	[ModelName] [nvarchar](max) NOT NULL,
	[Variant] [nvarchar](max) NOT NULL,
	[Manufacturer] [nvarchar](max) NOT NULL,
	[YearOfManufacture] [int] NOT NULL,
	[MonthOfManufacture] [int] NOT NULL,
	[BatchNo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[EngineNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[IntegrationEventLog]    Script Date: 12/12/2019 8:32:05 AM ******/

CREATE TABLE [dbo].[IntegrationEventLog](
	[EventId] [uniqueidentifier] NOT NULL,
	[Content] [varchar](max) NULL,
	[State] [int] NULL,
	[TimesSent] [int] NULL,
	[CreationTime] [date] NULL,
	[EventTypeName] [varchar](max) NULL,
	[TransactionId] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


