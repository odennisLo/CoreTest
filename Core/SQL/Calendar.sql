USE [MineDB]
GO

/****** Object:  Table [dbo].[Calendar]    Script Date: 2020/3/26 ¤W¤È 12:10:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Calendar](
	[SerID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[IP] [varchar](50) NOT NULL
) ON [PRIMARY]
GO


