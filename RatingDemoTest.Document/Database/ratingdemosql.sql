USE [master]
GO
/****** Object:  Database [RatingDemoTest]    Script Date: 05-06-2020 4:14:10 AM ******/
CREATE DATABASE [RatingDemoTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RatingDemoTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\RatingDemoTest.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RatingDemoTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\RatingDemoTest_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RatingDemoTest] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RatingDemoTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RatingDemoTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RatingDemoTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RatingDemoTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RatingDemoTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RatingDemoTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [RatingDemoTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RatingDemoTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RatingDemoTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RatingDemoTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RatingDemoTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RatingDemoTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RatingDemoTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RatingDemoTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RatingDemoTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RatingDemoTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RatingDemoTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RatingDemoTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RatingDemoTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RatingDemoTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RatingDemoTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RatingDemoTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RatingDemoTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RatingDemoTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RatingDemoTest] SET  MULTI_USER 
GO
ALTER DATABASE [RatingDemoTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RatingDemoTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RatingDemoTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RatingDemoTest] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [RatingDemoTest] SET DELAYED_DURABILITY = DISABLED 
GO
USE [RatingDemoTest]
GO
/****** Object:  Table [dbo].[AnswerOptions]    Script Date: 05-06-2020 4:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnswerOptions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[QuestionID] [int] NULL,
	[Point] [int] NULL,
	[Icon] [nvarchar](50) NULL,
 CONSTRAINT [PK_AnswerOptions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Answers]    Script Date: 05-06-2020 4:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[Point] [float] NOT NULL CONSTRAINT [DF_Answers_Point]  DEFAULT ((0)),
	[QuestionID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Questions]    Script Date: 05-06-2020 4:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[ServiceID] [int] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Services]    Script Date: 05-06-2020 4:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Icon] [nvarchar](50) NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 05-06-2020 4:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PassWord] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AnswerOptions] ON 

INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (1, N'Rất không sạch sẽ', 1, 1, N'crying.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (2, N'Không sạch sẽ', 1, 2, N'sad.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (3, N'Chấp nhận được', 1, 3, N'happy.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (4, N'Sạch sẽ', 1, 4, N'smile.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (5, N'Rất sạch sẽ', 1, 5, N'in-love.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (6, N'Rất không chuyên nghiệp', 2, 1, N'crying.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (7, N'Không chuyên nghiệp', 2, 2, N'sad.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (8, N'Chuyên nghiệp', 2, 3, N'happy.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (9, N'Rất chuyên nghiệp', 2, 4, N'smile.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (10, N'Soái ca', 2, 5, N'in-love.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (11, N'Rất kém', 3, 1, N'crying.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (12, N'Kém', 3, 2, N'sad.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (13, N'Trung bình', 3, 3, N'happy.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (14, N'Khá', 3, 4, N'smile.png')
INSERT [dbo].[AnswerOptions] ([ID], [Title], [QuestionID], [Point], [Icon]) VALUES (15, N'Tốt', 3, 5, N'in-love.png')
SET IDENTITY_INSERT [dbo].[AnswerOptions] OFF
SET IDENTITY_INSERT [dbo].[Answers] ON 

INSERT [dbo].[Answers] ([ID], [Comment], [Point], [QuestionID], [UserID]) VALUES (3, N'Hay', 4, 1, 1)
INSERT [dbo].[Answers] ([ID], [Comment], [Point], [QuestionID], [UserID]) VALUES (4, N'test', 3, 2, 1)
INSERT [dbo].[Answers] ([ID], [Comment], [Point], [QuestionID], [UserID]) VALUES (5, N'Hà lòng', 3, 3, 1)
SET IDENTITY_INSERT [dbo].[Answers] OFF
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([ID], [Title], [ServiceID]) VALUES (1, N'Bạn thấy lớp học văn phòng có <b>Sạch sẽ</b> không?', 1)
INSERT [dbo].[Questions] ([ID], [Title], [ServiceID]) VALUES (2, N'Bạn có hài lòng với dịch vụ <b>Bảo vệ</b> cũa ALT IELTS Gia sư không?', 2)
INSERT [dbo].[Questions] ([ID], [Title], [ServiceID]) VALUES (3, N'Bạn có hài lòng với dịch vụ <b>Chăm sóc học viên</b> cũa ALT IELTS Gia sư không?', 3)
SET IDENTITY_INSERT [dbo].[Questions] OFF
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([ID], [Title], [Code], [Icon]) VALUES (1, N'Vệ sinh', N'VS', N'bucket.png')
INSERT [dbo].[Services] ([ID], [Title], [Code], [Icon]) VALUES (2, N'Bảo vệ', N'BV', N'policeman.png')
INSERT [dbo].[Services] ([ID], [Title], [Code], [Icon]) VALUES (3, N'Chăm sóc học viên', N'CSHV', N'social-care.png')
SET IDENTITY_INSERT [dbo].[Services] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [PassWord]) VALUES (1, N'P@ssw0rd')
INSERT [dbo].[Users] ([ID], [PassWord]) VALUES (2, N'passcode')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[AnswerOptions]  WITH CHECK ADD  CONSTRAINT [FK_AnswerOptions_Questions] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Questions] ([ID])
GO
ALTER TABLE [dbo].[AnswerOptions] CHECK CONSTRAINT [FK_AnswerOptions_Questions]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Questions] ([ID])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Users]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Services] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ID])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Services]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Điểm' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Answers', @level2type=N'COLUMN',@level2name=N'Point'
GO
USE [master]
GO
ALTER DATABASE [RatingDemoTest] SET  READ_WRITE 
GO
