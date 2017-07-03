SET IDENTITY_INSERT [dbo].[Sections] ON
INSERT INTO [dbo].[Sections] ([Id], [Content], [Description], [Name], [ParentId], [SectionTypeId]) VALUES (22, N'', NULL, N'Programming', NULL, 1)

INSERT INTO [dbo].[Sections] ([Id], [Content], [Description], [Name], [ParentId], [SectionTypeId]) VALUES (23, N'', NULL, N'C#', 3, 1)
INSERT INTO [dbo].[Sections] ([Id], [Content], [Description], [Name], [ParentId], [SectionTypeId]) VALUES (24, NULL, NULL, N'Make Your First WPF Application', 10, 2)
INSERT INTO [dbo].[Sections] ([Id], [Content], [Description], [Name], [ParentId], [SectionTypeId]) VALUES (25, NULL, NULL, N'C# For Beginners', 10, 2)
SET IDENTITY_INSERT [dbo].[Sections] OFF
