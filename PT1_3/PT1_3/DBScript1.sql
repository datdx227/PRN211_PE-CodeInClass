USE master
GO
if exists (select * from sysdatabases where name='PT11')
		drop database PT11
GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE PT11
  ON PRIMARY (NAME = N''PT11'', FILENAME = N''' + @device_directory + N'PT11.mdf'')
  LOG ON (NAME = N''PT11_log'',  FILENAME = N''' + @device_directory + N'PT11.ldf'')')
GO

exec sp_dboption 'PT11','trunc. log on chkpt.','true'
exec sp_dboption 'PT11','select into/bulkcopy','true'
GO
USE [PT11]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssetTypes](
	[AssetTypeID] [int] IDENTITY(1,1) NOT NULL,
	[AssetTypeCode] [varchar](10) NOT NULL,
	[AssetTypeName] [nvarchar](100) NOT NULL,
	[AssetTypeGroupID] [tinyint] NOT NULL,
	[IsDetail] [bit] NOT NULL,
 CONSTRAINT [PK_AssetTypes] PRIMARY KEY CLUSTERED 
(
	[AssetTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_AssetTypeCode] UNIQUE NONCLUSTERED 
(
	[AssetTypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AssetTypes] ON
INSERT [dbo].[AssetTypes] ([AssetTypeID], [AssetTypeCode], [AssetTypeName], [AssetTypeGroupID], [IsDetail]) VALUES (1, N'501', N'Personal Computers', 5, 1)
INSERT [dbo].[AssetTypes] ([AssetTypeID], [AssetTypeCode], [AssetTypeName], [AssetTypeGroupID], [IsDetail]) VALUES (2, N'502', N'Laptops', 5, 1)
INSERT [dbo].[AssetTypes] ([AssetTypeID], [AssetTypeCode], [AssetTypeName], [AssetTypeGroupID], [IsDetail]) VALUES (3, N'503', N'PC Servers', 5, 1)
INSERT [dbo].[AssetTypes] ([AssetTypeID], [AssetTypeCode], [AssetTypeName], [AssetTypeGroupID], [IsDetail]) VALUES (4, N'504', N'Servers', 5, 1)
INSERT [dbo].[AssetTypes] ([AssetTypeID], [AssetTypeCode], [AssetTypeName], [AssetTypeGroupID], [IsDetail]) VALUES (5, N'505', N'Other Computers', 5, 1)
SET IDENTITY_INSERT [dbo].[AssetTypes] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetTypeGroups](
	[AssetTypeGroupID] [tinyint] NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AssetTypeGroups] PRIMARY KEY CLUSTERED 
(
	[AssetTypeGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AssetTypeGroups] ([AssetTypeGroupID], [GroupName]) VALUES (1, N'Lands')
INSERT [dbo].[AssetTypeGroups] ([AssetTypeGroupID], [GroupName]) VALUES (2, N'Houses')
INSERT [dbo].[AssetTypeGroups] ([AssetTypeGroupID], [GroupName]) VALUES (3, N'Architects')
INSERT [dbo].[AssetTypeGroups] ([AssetTypeGroupID], [GroupName]) VALUES (4, N'Vehicles')
INSERT [dbo].[AssetTypeGroups] ([AssetTypeGroupID], [GroupName]) VALUES (5, N'Computers')
INSERT [dbo].[AssetTypeGroups] ([AssetTypeGroupID], [GroupName]) VALUES (6, N'Others')
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MaterialTypes](
	[MaterialTypeID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialTypeCode] [varchar](10) NOT NULL,
	[MaterialTypeName] [nvarchar](100) NOT NULL,
	[MaterialGroupID] [tinyint] NOT NULL,
	[IsDetail] [bit] NOT NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[MaterialTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_MaterialCode] UNIQUE NONCLUSTERED 
(
	[MaterialTypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MaterialTypes] ON
INSERT [dbo].[MaterialTypes] ([MaterialTypeID], [MaterialTypeCode], [MaterialTypeName], [MaterialGroupID], [IsDetail]) VALUES (1, N'401', N'Integrated Cards', 4, 1)
INSERT [dbo].[MaterialTypes] ([MaterialTypeID], [MaterialTypeCode], [MaterialTypeName], [MaterialGroupID], [IsDetail]) VALUES (2, N'402', N'Transitors', 4, 1)
INSERT [dbo].[MaterialTypes] ([MaterialTypeID], [MaterialTypeCode], [MaterialTypeName], [MaterialGroupID], [IsDetail]) VALUES (3, N'403', N'Capacities', 4, 1)
INSERT [dbo].[MaterialTypes] ([MaterialTypeID], [MaterialTypeCode], [MaterialTypeName], [MaterialGroupID], [IsDetail]) VALUES (4, N'404', N'Electronic wires', 4, 1)
INSERT [dbo].[MaterialTypes] ([MaterialTypeID], [MaterialTypeCode], [MaterialTypeName], [MaterialGroupID], [IsDetail]) VALUES (5, N'405', N'Other', 4, 1)
SET IDENTITY_INSERT [dbo].[MaterialTypes] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialGroups](
	[MaterialGroupID] [tinyint] NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MaterialGroups] PRIMARY KEY CLUSTERED 
(
	[MaterialGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MaterialGroups] ([MaterialGroupID], [GroupName]) VALUES (1, N'Primary Materials')
INSERT [dbo].[MaterialGroups] ([MaterialGroupID], [GroupName]) VALUES (2, N'Secondary Materials')
INSERT [dbo].[MaterialGroups] ([MaterialGroupID], [GroupName]) VALUES (3, N'Tools')
INSERT [dbo].[MaterialGroups] ([MaterialGroupID], [GroupName]) VALUES (4, N'Spare Parts')
INSERT [dbo].[MaterialGroups] ([MaterialGroupID], [GroupName]) VALUES (5, N'Faulty Materials')
INSERT [dbo].[MaterialGroups] ([MaterialGroupID], [GroupName]) VALUES (6, N'Other Materials')