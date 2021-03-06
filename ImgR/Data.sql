USE [Newsletter]
GO
SET IDENTITY_INSERT [dbo].[tbl_ImageDevice] ON 

GO
INSERT [dbo].[tbl_ImageDevice] ([ID], [Name], [ShortName], [UserAgent], [Width], [Height], [Orientation], [IsDefault]) VALUES (1, N'iPhone 3G', N'iph-3g', N'My user Agent String .... Lol xoxo', 320, 480, 1, 0)
GO
INSERT [dbo].[tbl_ImageDevice] ([ID], [Name], [ShortName], [UserAgent], [Width], [Height], [Orientation], [IsDefault]) VALUES (2, N'iPad Mini', N'ipa-mi', N'', 768, 1024, 1, 0)
GO
INSERT [dbo].[tbl_ImageDevice] ([ID], [Name], [ShortName], [UserAgent], [Width], [Height], [Orientation], [IsDefault]) VALUES (3, N'Laptop', N'lp', N'', 1366, 768, 1, 0)
GO
INSERT [dbo].[tbl_ImageDevice] ([ID], [Name], [ShortName], [UserAgent], [Width], [Height], [Orientation], [IsDefault]) VALUES (4, N'Big Screen', N'bg-scr', N'', 1920, 1080, 1, 1)
GO
INSERT [dbo].[tbl_ImageDevice] ([ID], [Name], [ShortName], [UserAgent], [Width], [Height], [Orientation], [IsDefault]) VALUES (5, N'Small Laptop', N'sm-lp', N'', 1024, 768, 1, 0)
GO
INSERT [dbo].[tbl_ImageDevice] ([ID], [Name], [ShortName], [UserAgent], [Width], [Height], [Orientation], [IsDefault]) VALUES (1004, N'iPhone X', N'iph-x', N'', 774, 612, 1, 0)
GO
INSERT [dbo].[tbl_ImageDevice] ([ID], [Name], [ShortName], [UserAgent], [Width], [Height], [Orientation], [IsDefault]) VALUES (1005, N'Iphone x', N'sam-ga-no-n7', N'', 400, 640, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_ImageDevice] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Image] ON 

GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (1, 0, 0, N'xejgvomlzfs-11', N'jpg', N'~/images/xejgvomlzfs-11.jpg', N'Jungle King', N'animals', N'', CAST(0x0000A68600E47299 AS DateTime), 0, 0, 1, 2880, 1800, 1, 4, NULL)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (2, 0, 0, N'xejgvomlzfs-iph-3g-11', N'jpg', N'~/images/xejgvomlzfs-iph-3g-11.jpg', N'Jungle King', N'animals', N'', CAST(0x0000A68600E472B6 AS DateTime), 0, 1, 2, 480, 300, 0, 4, 1)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (3, 0, 0, N'xejgvomlzfs-ipa-mi-13', N'jpg', N'~/images/xejgvomlzfs-ipa-mi-13.jpg', N'Jungle King', N'animals', N'', CAST(0x0000A68600E472D5 AS DateTime), 0, 1, 3, 1152, 720, 0, 4, 2)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (4, 0, 0, N'xejgvomlzfs-lp-15', N'jpg', N'~/images/xejgvomlzfs-lp-15.jpg', N'Jungle King', N'animals', N'', CAST(0x0000A68600E47303 AS DateTime), 0, 1, 4, 2048, 1280, 0, 4, 3)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (5, 0, 0, N'xejgvomlzfs-sm-lp-17', N'jpg', N'~/images/xejgvomlzfs-sm-lp-17.jpg', N'Jungle King', N'animals', N'', CAST(0x0000A68600E4732B AS DateTime), 0, 1, 5, 1536, 960, 0, 4, 5)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (6, 0, 0, N'xejgvomlzfs', N'jpg', N'~/images/xejgvomlzfs.jpg', N'Jungle King (Edited)', N'animals', N'', CAST(0x0000A68600E48B89 AS DateTime), 1, 0, 0, 2880, 1800, 1, 4, NULL)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (7, 0, 0, N'xejgvomlzfs-iph-3g', N'jpg', N'~/images/xejgvomlzfs-iph-3g.jpg', N'Jungle King (Edited)', N'animals', N'', CAST(0x0000A68600E48BF2 AS DateTime), 1, 6, 0, 480, 300, 0, 4, 1)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (8, 0, 0, N'xejgvomlzfs-ipa-mi', N'jpg', N'~/images/xejgvomlzfs-ipa-mi.jpg', N'Jungle King (Edited)', N'animals', N'', CAST(0x0000A68600E48C12 AS DateTime), 1, 6, 0, 1152, 720, 0, 4, 2)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (9, 0, 0, N'xejgvomlzfs-lp', N'jpg', N'~/images/xejgvomlzfs-lp.jpg', N'Jungle King (Edited)', N'animals', N'', CAST(0x0000A68600E48C44 AS DateTime), 1, 6, 0, 2048, 1280, 0, 4, 3)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10, 0, 0, N'xejgvomlzfs-sm-lp', N'jpg', N'~/images/xejgvomlzfs-sm-lp.jpg', N'Jungle King (Edited)', N'animals', N'', CAST(0x0000A68600E48C6A AS DateTime), 1, 6, 0, 1536, 960, 0, 4, 5)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (11, 0, 0, N'kuqrjhienvo', N'jpg', N'~/images/kuqrjhienvo.jpg', N'Wind Falls Ghost Tree', N'trees', N'', CAST(0x0000A6860105B309 AS DateTime), 1, 0, 0, 3840, 2160, 1, 4, NULL)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (12, 0, 0, N'kuqrjhienvo-iph-3g', N'jpg', N'~/images/kuqrjhienvo-iph-3g.jpg', N'Wind Falls Ghost Tree', N'trees', N'', CAST(0x0000A6860105B33D AS DateTime), 1, 11, 0, 640, 360, 0, 4, 1)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (13, 0, 0, N'kuqrjhienvo-ipa-mi', N'jpg', N'~/images/kuqrjhienvo-ipa-mi.jpg', N'Wind Falls Ghost Tree', N'trees', N'', CAST(0x0000A6860105B375 AS DateTime), 1, 11, 0, 1536, 864, 0, 4, 2)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (14, 0, 0, N'kuqrjhienvo-lp', N'jpg', N'~/images/kuqrjhienvo-lp.jpg', N'Wind Falls Ghost Tree', N'trees', N'', CAST(0x0000A6860105B3C6 AS DateTime), 1, 11, 0, 2730, 1536, 0, 4, 3)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (15, 0, 0, N'kuqrjhienvo-sm-lp', N'jpg', N'~/images/kuqrjhienvo-sm-lp.jpg', N'Wind Falls Ghost Tree', N'trees', N'', CAST(0x0000A6860105B41F AS DateTime), 1, 11, 0, 2048, 1152, 0, 4, 5)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (16, 0, 0, N'rhafuitqzkb', N'jpg', N'~/images/rhafuitqzkb.jpg', N'Acid trip', N'liquids', N'', CAST(0x0000A686010E16DC AS DateTime), 1, 0, 0, 1920, 1080, 1, 4, NULL)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (17, 0, 0, N'rhafuitqzkb-iph-3g', N'jpg', N'~/images/rhafuitqzkb-iph-3g.jpg', N'Acid trip', N'liquids', N'', CAST(0x0000A686010E16FC AS DateTime), 1, 16, 0, 320, 180, 0, 4, 1)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (18, 0, 0, N'rhafuitqzkb-ipa-mi', N'jpg', N'~/images/rhafuitqzkb-ipa-mi.jpg', N'Acid trip', N'liquids', N'', CAST(0x0000A686010E1708 AS DateTime), 1, 16, 0, 768, 432, 0, 4, 2)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (19, 0, 0, N'rhafuitqzkb-lp', N'jpg', N'~/images/rhafuitqzkb-lp.jpg', N'Acid trip', N'liquids', N'', CAST(0x0000A686010E171D AS DateTime), 1, 16, 0, 1365, 768, 0, 4, 3)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (20, 0, 0, N'rhafuitqzkb-sm-lp', N'jpg', N'~/images/rhafuitqzkb-sm-lp.jpg', N'Acid trip', N'liquids', N'', CAST(0x0000A686010E172D AS DateTime), 1, 16, 0, 1024, 576, 0, 4, 5)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (21, 0, 0, N'iqwabmjcrey', N'jpg', N'~/images/iqwabmjcrey.jpg', N'Colors and more colors', N'liquids', N'', CAST(0x0000A686010E2F00 AS DateTime), 1, 0, 0, 1920, 1080, 1, 4, NULL)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (22, 0, 0, N'iqwabmjcrey-iph-3g', N'jpg', N'~/images/iqwabmjcrey-iph-3g.jpg', N'Colors and more colors', N'liquids', N'', CAST(0x0000A686010E2F3F AS DateTime), 1, 21, 0, 320, 180, 0, 4, 1)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (23, 0, 0, N'iqwabmjcrey-ipa-mi', N'jpg', N'~/images/iqwabmjcrey-ipa-mi.jpg', N'Colors and more colors', N'liquids', N'', CAST(0x0000A686010E2F4B AS DateTime), 1, 21, 0, 768, 432, 0, 4, 2)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (24, 0, 0, N'iqwabmjcrey-lp', N'jpg', N'~/images/iqwabmjcrey-lp.jpg', N'Colors and more colors', N'liquids', N'', CAST(0x0000A686010E2F5C AS DateTime), 1, 21, 0, 1365, 768, 0, 4, 3)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (25, 0, 0, N'iqwabmjcrey-sm-lp', N'jpg', N'~/images/iqwabmjcrey-sm-lp.jpg', N'Colors and more colors', N'liquids', N'', CAST(0x0000A686010E2F6C AS DateTime), 1, 21, 0, 1024, 576, 0, 4, 5)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (26, 0, 0, N'cxjvlymdrew', N'jpg', N'~/images/cxjvlymdrew.jpg', N'Dogs', N'animals', N'', CAST(0x0000A686010E5479 AS DateTime), 1, 0, 0, 1600, 1200, 1, 4, NULL)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (27, 0, 0, N'cxjvlymdrew-iph-3g', N'jpg', N'~/images/cxjvlymdrew-iph-3g.jpg', N'Dogs', N'animals', N'', CAST(0x0000A686010E54A1 AS DateTime), 1, 26, 0, 266, 200, 0, 4, 1)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (28, 0, 0, N'cxjvlymdrew-ipa-mi', N'jpg', N'~/images/cxjvlymdrew-ipa-mi.jpg', N'Dogs', N'animals', N'', CAST(0x0000A686010E54B8 AS DateTime), 1, 26, 0, 640, 480, 0, 4, 2)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (29, 0, 0, N'cxjvlymdrew-lp', N'jpg', N'~/images/cxjvlymdrew-lp.jpg', N'Dogs', N'animals', N'', CAST(0x0000A686010E54D6 AS DateTime), 1, 26, 0, 1137, 853, 0, 4, 3)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (30, 0, 0, N'cxjvlymdrew-sm-lp', N'jpg', N'~/images/cxjvlymdrew-sm-lp.jpg', N'Dogs', N'animals', N'', CAST(0x0000A686010E54F0 AS DateTime), 1, 26, 0, 853, 640, 0, 4, 5)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (31, 0, 0, N'wfqnuzahxoj', N'jpg', N'~/images/wfqnuzahxoj.jpg', N'Ares Mask', N'greek', N'', CAST(0x0000A686010E97EE AS DateTime), 1, 0, 0, 1920, 1080, 1, 4, NULL)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (32, 0, 0, N'wfqnuzahxoj-iph-3g', N'jpg', N'~/images/wfqnuzahxoj-iph-3g.jpg', N'Ares Mask', N'greek', N'', CAST(0x0000A686010E9805 AS DateTime), 1, 31, 0, 320, 180, 0, 4, 1)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (33, 0, 0, N'wfqnuzahxoj-ipa-mi', N'jpg', N'~/images/wfqnuzahxoj-ipa-mi.jpg', N'Ares Mask', N'greek', N'', CAST(0x0000A686010E9811 AS DateTime), 1, 31, 0, 768, 432, 0, 4, 2)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (34, 0, 0, N'wfqnuzahxoj-lp', N'jpg', N'~/images/wfqnuzahxoj-lp.jpg', N'Ares Mask', N'greek', N'', CAST(0x0000A686010E9826 AS DateTime), 1, 31, 0, 1365, 768, 0, 4, 3)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (35, 0, 0, N'wfqnuzahxoj-sm-lp', N'jpg', N'~/images/wfqnuzahxoj-sm-lp.jpg', N'Ares Mask', N'greek', N'', CAST(0x0000A686010E9835 AS DateTime), 1, 31, 0, 1024, 576, 0, 4, 5)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10002, 0, 0, N'cduekftzpbm', N'jpg', N'~/images/cduekftzpbm.jpg', N'Cool Car', N'cars', N'', CAST(0x0000A68700A6B3AC AS DateTime), 1, 0, 0, 1920, 1200, 1, 4, NULL)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10003, 0, 0, N'cduekftzpbm-iph-3g', N'jpg', N'~/images/cduekftzpbm-iph-3g.jpg', N'Cool Car', N'cars', N'', CAST(0x0000A68700A6B3BC AS DateTime), 1, 10002, 0, 320, 200, 0, 4, 1)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10004, 0, 0, N'cduekftzpbm-ipa-mi', N'jpg', N'~/images/cduekftzpbm-ipa-mi.jpg', N'Cool Car', N'cars', N'', CAST(0x0000A68700A6B3CB AS DateTime), 1, 10002, 0, 768, 480, 0, 4, 2)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10005, 0, 0, N'cduekftzpbm-lp', N'jpg', N'~/images/cduekftzpbm-lp.jpg', N'Cool Car', N'cars', N'', CAST(0x0000A68700A6B3E1 AS DateTime), 1, 10002, 0, 1365, 853, 0, 4, 3)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10006, 0, 0, N'cduekftzpbm-sm-lp', N'jpg', N'~/images/cduekftzpbm-sm-lp.jpg', N'Cool Car', N'cars', N'', CAST(0x0000A68700A6B3FB AS DateTime), 1, 10002, 0, 1024, 640, 0, 4, 5)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10007, 0, 0, N'fbqvjzihmpu', N'jpg', N'~/images/fbqvjzihmpu.jpg', N'Disco Cat', N'animals', N'', CAST(0x0000A6880101DB76 AS DateTime), 1, 0, 0, 2880, 1800, 1, 4, NULL)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10008, 0, 0, N'fbqvjzihmpu-iph-3g', N'jpg', N'~/images/fbqvjzihmpu-iph-3g.jpg', N'Disco Cat', N'animals', N'', CAST(0x0000A6880101DBA4 AS DateTime), 1, 10007, 0, 480, 300, 0, 4, 1)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10009, 0, 0, N'fbqvjzihmpu-ipa-mi', N'jpg', N'~/images/fbqvjzihmpu-ipa-mi.jpg', N'Disco Cat', N'animals', N'', CAST(0x0000A6880101DBCC AS DateTime), 1, 10007, 0, 1152, 720, 0, 4, 2)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10010, 0, 0, N'fbqvjzihmpu-lp', N'jpg', N'~/images/fbqvjzihmpu-lp.jpg', N'Disco Cat', N'animals', N'', CAST(0x0000A6880101DBFD AS DateTime), 1, 10007, 0, 2048, 1280, 0, 4, 3)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10011, 0, 0, N'fbqvjzihmpu-sm-lp', N'jpg', N'~/images/fbqvjzihmpu-sm-lp.jpg', N'Disco Cat', N'animals', N'', CAST(0x0000A6880101DC21 AS DateTime), 1, 10007, 0, 1536, 960, 0, 4, 5)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10012, 0, 0, N'fbqvjzihmpu-iph-x', N'jpg', N'~/images/fbqvjzihmpu-iph-x.jpg', N'Disco Cat', N'animals', N'', CAST(0x0000A6880101DC3E AS DateTime), 1, 10007, 0, 1160, 725, 0, 4, 1004)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10013, 0, 0, N'gworbnmydzf', N'jpg', N'~/images/gworbnmydzf.jpg', N'Headphones', N'music', N'Hello', CAST(0x0000A68A00FB2F73 AS DateTime), 1, 0, 0, 2880, 1800, 1, 4, NULL)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10014, 0, 0, N'gworbnmydzf-iph-3g', N'jpg', N'~/images/gworbnmydzf-iph-3g.jpg', N'Headphones', N'music', N'Hello', CAST(0x0000A68A00FB2FA9 AS DateTime), 1, 10013, 0, 480, 300, 0, 4, 1)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10015, 0, 0, N'gworbnmydzf-ipa-mi', N'jpg', N'~/images/gworbnmydzf-ipa-mi.jpg', N'Headphones', N'music', N'Hello', CAST(0x0000A68A00FB2FD2 AS DateTime), 1, 10013, 0, 1152, 720, 0, 4, 2)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10016, 0, 0, N'gworbnmydzf-lp', N'jpg', N'~/images/gworbnmydzf-lp.jpg', N'Headphones', N'music', N'Hello', CAST(0x0000A68A00FB3008 AS DateTime), 1, 10013, 0, 2048, 1280, 0, 4, 3)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10017, 0, 0, N'gworbnmydzf-sm-lp', N'jpg', N'~/images/gworbnmydzf-sm-lp.jpg', N'Headphones', N'music', N'Hello', CAST(0x0000A68A00FB302E AS DateTime), 1, 10013, 0, 1536, 960, 0, 4, 5)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10018, 0, 0, N'gworbnmydzf-iph-x', N'jpg', N'~/images/gworbnmydzf-iph-x.jpg', N'Headphones', N'music', N'Hello', CAST(0x0000A68A00FB3051 AS DateTime), 1, 10013, 0, 1160, 725, 0, 4, 1004)
GO
INSERT [dbo].[tbl_Image] ([ID], [OwnerID], [OwnerType], [Name], [Extension], [URL], [Title], [Category], [Description], [CreationTime], [Active], [ResizeOf], [BackupOf], [Width], [Height], [ResizeForDevices], [TargetDevice], [ResizeDevice]) VALUES (10019, 0, 0, N'gworbnmydzf-sam-ga-no-n7', N'jpg', N'~/images/gworbnmydzf-sam-ga-no-n7.jpg', N'Headphones', N'music', N'Hello', CAST(0x0000A68A00FB3075 AS DateTime), 1, 10013, 0, 599, 374, 0, 4, 1005)
GO
SET IDENTITY_INSERT [dbo].[tbl_Image] OFF
GO
