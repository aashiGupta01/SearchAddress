Create Database AddressLocation 

USE [AddressLocation]
GO

/****** Object:  Table [dbo].[locations]    Script Date: 18-08-2020 00:06:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[locations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[zip] [bigint] NULL,
 CONSTRAINT [PK_locations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


INSERT INTO [dbo].[locations]
           ([Address]
           ,[State]
           ,[City]
           ,[zip])
     VALUES
           ('Old Delhi Market'
           ,'New Delhi'
           ,'Delhi'
           , 110089), 
		   ('South Beach','Florida','Miami',110083),
		   ('Fort Lauderable',	'Florida',	'Miam',	110086),
		   ('Fort Worth',	'Texas',	'Dallas',	110090),
		   ('North Fort',	'Florida',	'Miami Beach',	110099)

GO
