SET IDENTITY_INSERT [dbo].[SectionTypes] ON
INSERT INTO [dbo].[SectionTypes] ([Id], [Name], [ParentId]) VALUES (1, N'Category', NULL)
INSERT INTO [dbo].[SectionTypes] ([Id], [Name], [ParentId]) VALUES (2, N'Course', 1)
INSERT INTO [dbo].[SectionTypes] ([Id], [Name], [ParentId]) VALUES (3, N'Theme', 2)
INSERT INTO [dbo].[SectionTypes] ([Id], [Name], [ParentId]) VALUES (4, N'Lesson', 3)
INSERT INTO [dbo].[SectionTypes] ([Id], [Name], [ParentId]) VALUES (5, N'Video Lesson', 4)
INSERT INTO [dbo].[SectionTypes] ([Id], [Name], [ParentId]) VALUES (6, N'Text Lesson', 4)
INSERT INTO [dbo].[SectionTypes] ([Id], [Name], [ParentId]) VALUES (7, N'Quiz', 3)
SET IDENTITY_INSERT [dbo].[SectionTypes] OFF
