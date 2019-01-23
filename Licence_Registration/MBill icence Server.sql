USE [M_Billing]
GO

/****** Object:  Table [dbo].[Licence_Customer]    Script Date: 13-01-2019 06:00:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Licence_Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](40) NULL,
	[MobileNo] [char](10) NULL,
	[CustomerAddress] [nvarchar](50) NULL,
	[MoneyPaid] [money] NULL,
	[YearlyPlan] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[HddInfo] [nvarchar](50) NULL,
	[L_Key] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

SET ANSI_PADDING OFF
GO



