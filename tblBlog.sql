USE [DotNetTrainingBatch4]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 28/4/2024 6:15:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'Test Titile', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'Test Titile', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'Test Titile', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'Test Titile', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (5, N'Test Titile', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'Test Titile', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (7, N'Test Titile', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (8, N'Test Titile', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (9, N'Test Titile', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (10, N'Test Titile', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (11, N'title', N'author', N'content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1002, N'title', N'author', N'content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1003, N'title', N'author', N'content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1004, N'title', N'author', N'content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2002, N'title', N'author', N'content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2003, N'title', N'author', N'content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2004, N'title', N'author', N'content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2005, N'title', N'author', N'content')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
