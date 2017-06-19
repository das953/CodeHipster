--add 1 category -> 1 TestType(?) -> 2Theme with -> 1 lesson (1 video, 1 text) & quiz
SET IDENTITY_INSERT [dbo].[Sections] ON
INSERT INTO [dbo].[Sections] ([Id], [Content], [Description], [Name], [ParentId], [SectionTypeId]) VALUES 
(22, N'', NULL, N'Test_Category', NULL, 1),

(23, N'', NULL, N'Test_TestType', 22, 2),

(24, N'', NULL, N'Test_Theme', 23, 3),

(25, N'', N'Test_FunnyLesson', N'Test_Lesson', 24, 4),
(26, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/DHjLhaB3bGs?list=RDwJvB8iCyfFk" frameborder="0" allowfullscreen></iframe>', N'Test_Video_Pokaz', N'Test_VideoLesson', 25, 5),
(27, N'<div style="text-align: center">Hello<br>World!</div>', N'Test_Text', N'Test_TextLesson', 25, 6),

(28, N'', N'Test_TestItBabe!', N'Test_Quiz', 24, 7),


(29, N'', NULL, N'Test_Theme1', 23, 3),

(30, N'', N'Test_FunnyLesson1', N'Test_Lesson1', 29, 4),
(31, N'<iframe width="560" height="315" src="https://www.youtube.com/embed/iQNHXFnTQg8?list=RDwJvB8iCyfFk" frameborder="0" allowfullscreen></iframe>', N'Test_Video_Pokaz1', N'Test_VideoLesson1', 30, 5),
(32, N'<div style="text-align: center">Bye<br>World!</div>', N'Test_Text1', N'Test_TextLesson1', 30, 6),

(33, N'', N'Test_TestItBabe1!', N'Test_Quiz1', 29, 7)

SET IDENTITY_INSERT [dbo].[Sections] OFF


--Insert 3 test question for 2 test quiz
SET IDENTITY_INSERT [dbo].[Questions] ON
INSERT INTO [dbo].[Questions] ([Id], [QuestionGrade], [QuestionText], [SectionId]) VALUES 
(1, 1, 'Test question 1', 28),
(2, 1, 'Test question 2', 28),
(3, 1, 'Test question 3', 28),

(4, 1, 'Test question 4', 33),
(5, 1, 'Test question 5', 33),
(6, 1, 'Test question 6', 33)

SET IDENTITY_INSERT [dbo].[Questions] OFF

--Insert test answert to each test question
SET IDENTITY_INSERT [dbo].[Answers] ON
INSERT INTO [dbo].[Answers] ([Id], [AnswerText], [IsCorrect], [QuestionId]) VALUES
(1, 'False answer', 0, 1),
(2, 'True answer', 1, 1),
(3, 'False answer', 0, 1),

(4, 'True answer', 1, 2),
(5, 'False answer', 0, 2),
(6, 'False answer', 0, 2),

(7, 'False answer', 0, 3),
(8, 'False answer', 0, 3),
(9, 'True answer', 1, 3),

(10, 'False answer', 0, 4),
(11, 'True answer', 1, 4),

(12, 'True answer', 1, 5),
(13, 'False answer', 0, 5),

(14, 'False answer', 0, 6),
(15, 'True answer', 1, 6)

SET IDENTITY_INSERT [dbo].[Answers] OFF