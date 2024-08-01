--日歷基本檔
USE Calendar
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[Calendar]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[Calendar]
GO

-- 
-- =============================================
-- Author:         bevis
-- Create date:    20240801
-- Description:    日歷基本檔
-- Modified By     Modification Date    Modification Description
-- bevis           20240801             Ini 
-- =============================================
CREATE TABLE [dbo].[Calendar](
	[groupId] [INT] IDENTITY(1,1) NOT NULL,     --流水號	
	[title] [NVARCHAR](20)  NOT NULL,			--標題
	[start] [datetime] NULL,					--開始時間	 
	[end] [datetime] NULL,						--結束時間	
	[color] [NVARCHAR](10) NULL,				--背景顏色
	[textColor] [NVARCHAR](10) NULL,			--文字顏色
	[CreateUser] [NVARCHAR](10) NULL,			--創建人員
	[CreateDate] [datetime] NOT NULL,			--創建時間
	[LogUser] [NVARCHAR](10 ) NULL,				--修改人員
	[LogDate] [datetime] NOT NULL,				--修改時間
	[LogSN] [ROWVERSION] NOT NULL,				--異動版本
	CONSTRAINT [PK_Calendar] PRIMARY KEY CLUSTERED 
	(		 
		[groupId] ASC
	) ON [PRIMARY]
) ON [PRIMARY]

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日歷基本檔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'groupId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'標題' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'開始時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'start'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'結束時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'end'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'背景顏色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'color'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文字顏色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'textColor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產生人員' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產生日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'異動人員' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'LogUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'異動時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'LogDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'異動版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar', @level2type=N'COLUMN',@level2name=N'LogSN'
GO