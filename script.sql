
USE [bookclass]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorys]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorys](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](10) NOT NULL,
	[icon] [nvarchar](30) NOT NULL,
	[createDate] [datetime] NOT NULL,
	[lastModifty] [datetime] NULL,
	[recordTS] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseDate]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseDate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[courseId] [int] NOT NULL,
	[date] [datetime] NOT NULL,
	[createDate] [datetime] NOT NULL,
	[lastModifty] [date] NULL,
	[recordTS] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](2000) NOT NULL,
	[categoryId] [int] NOT NULL,
	[imageId] [int] NOT NULL,
	[locationId] [int] NOT NULL,
	[createDate] [datetime] NOT NULL,
	[lastModifty] [datetime] NULL,
	[recordTS] [timestamp] NOT NULL,
	[price] [decimal](7, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseTime]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTime](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[courseDateId] [int] NOT NULL,
	[time] [time](7) NOT NULL,
	[createDate] [datetime] NOT NULL,
	[lastModifty] [datetime] NULL,
	[recordTS] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[path] [varchar](255) NOT NULL,
	[description] [varchar](1000) NOT NULL,
	[createDate] [datetime] NOT NULL,
	[lastModifty] [datetime] NULL,
	[recordTS] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](1000) NOT NULL,
	[lng] [decimal](9, 6) NOT NULL,
	[lat] [decimal](9, 6) NOT NULL,
	[createDate] [datetime] NOT NULL,
	[lastModifty] [datetime] NULL,
	[recordTS] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Providers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](2000) NULL,
	[createDate] [datetime] NOT NULL,
	[lastModifty] [datetime] NULL,
	[recordTS] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserComments]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserComments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [nvarchar](450) NOT NULL,
	[userRateing] [int] NULL,
	[comment] [nvarchar](2000) NOT NULL,
	[createDate] [datetime] NOT NULL,
	[lastModifty] [datetime] NULL,
	[recordTS] [timestamp] NOT NULL,
	[courseId] [int] NOT NULL,
	[UserRegisterId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRegister]    Script Date: 5/11/2019 13:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRegister](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[courseTimeId] [int] NOT NULL,
	[userId] [nvarchar](450) NOT NULL,
	[createDate] [datetime] NOT NULL,
	[lastModifty] [datetime] NULL,
	[recordTS] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'admin', N'admin', N'admin', N'cb61c309-7ea9-4f21-9fbc-36f7b0d0a6d9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dba5bec3-7685-4df9-a1ea-32f59db7e787', N'admin')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'079770d7-765b-45d8-b81c-be47a697193e', N'wonglun4@gmail.com', N'WONGLUN4@GMAIL.COM', N'wonglun4@gmail.com', N'WONGLUN4@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEEfPpE2a287RkO7r8oN0DreunCKVmnFE28CO4B5Xnv+yGYT71TcUO5HxPaGBP9eUhQ==', N'NIEVSKGB53KY2QIRT2PCYSPPXR2KUVTQ', N'87078ce8-a7c7-4545-bf82-dd2b1a564b06', N'123412324434343223', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', N'wonglun@gmail.com', N'WONGLUN@GMAIL.COM', N'wonglun@gmail.com', N'WONGLUN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEDgJJp1M3fo8yMfkareKGbnTMD5LY97qvyL6btT780sgWMh2I7XPvWb+FK/K6vgMRg==', N'6SDDXTHCOK6OIFHYW57WR3HM47KS34NU', N'cb61c309-7ea9-4f21-9fbc-36f7b0d0a6d9', N'123412324434343223', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b1b9a979-c4be-4bac-a438-4d8478882724', N'wonglun3@gmail.com', N'WONGLUN3@GMAIL.COM', N'wonglun3@gmail.com', N'WONGLUN3@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEEHPJDImUCvoLUMyQFWF7/sQpl4/gNaQNIs9yerhXP3r1tC++TEiO1CMFDf33KRirQ==', N'YNKIXUJZ3WKL2FVIY62YEEZNVUJDOJ2E', N'8f0f5162-4d34-473b-b94c-4d08e28179fe', N'123412324434343223', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'dba5bec3-7685-4df9-a1ea-32f59db7e787', N'admin@bookclass.com', N'ADMIN@BOOKCLASS.COM', N'admin@bookclass.com', N'ADMIN@BOOKCLASS.COM', 1, N'AQAAAAEAACcQAAAAEPfl9ohVmdaU0AdWJ1yNq5D+gZBl4aVFnjly3hyKH1NemkogIJZqIBVS7Dvev1XH4g==', N'JWZFSI37GYUTA3TX65DKEC3YYOSAYHGE', N'dce0a2f0-5b44-4e4a-8963-c2f9492dd940', N'12345678', 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Categorys] ON 

INSERT [dbo].[Categorys] ([id], [name], [icon], [createDate], [lastModifty]) VALUES (3, N'Cooking', N'fa-cutlery', CAST(N'2019-10-28T15:44:15.770' AS DateTime), CAST(N'2019-10-28T15:44:15.770' AS DateTime))
INSERT [dbo].[Categorys] ([id], [name], [icon], [createDate], [lastModifty]) VALUES (5, N'Outdoor', N'fa-soccer-ball-o', CAST(N'2019-10-28T15:47:38.837' AS DateTime), CAST(N'2019-10-28T15:47:38.837' AS DateTime))
INSERT [dbo].[Categorys] ([id], [name], [icon], [createDate], [lastModifty]) VALUES (6, N'Family', N'fa-home', CAST(N'2019-10-28T15:48:24.707' AS DateTime), CAST(N'2019-10-28T15:48:24.707' AS DateTime))
INSERT [dbo].[Categorys] ([id], [name], [icon], [createDate], [lastModifty]) VALUES (7, N'Crafting', N'fa-wrench', CAST(N'2019-10-28T15:49:45.087' AS DateTime), CAST(N'2019-10-28T15:49:45.087' AS DateTime))
INSERT [dbo].[Categorys] ([id], [name], [icon], [createDate], [lastModifty]) VALUES (8, N'Special', N'fa-star', CAST(N'2019-10-28T15:52:09.940' AS DateTime), CAST(N'2019-10-28T15:52:09.940' AS DateTime))
SET IDENTITY_INSERT [dbo].[Categorys] OFF
SET IDENTITY_INSERT [dbo].[CourseDate] ON 

INSERT [dbo].[CourseDate] ([id], [courseId], [date], [createDate], [lastModifty]) VALUES (1, 4, CAST(N'2019-10-30T00:00:00.000' AS DateTime), CAST(N'2019-10-29T00:17:54.373' AS DateTime), NULL)
INSERT [dbo].[CourseDate] ([id], [courseId], [date], [createDate], [lastModifty]) VALUES (2, 4, CAST(N'2019-11-01T00:00:00.000' AS DateTime), CAST(N'2019-10-29T00:18:08.577' AS DateTime), NULL)
INSERT [dbo].[CourseDate] ([id], [courseId], [date], [createDate], [lastModifty]) VALUES (3, 4, CAST(N'2019-11-14T00:00:00.000' AS DateTime), CAST(N'2019-11-05T04:07:23.070' AS DateTime), NULL)
INSERT [dbo].[CourseDate] ([id], [courseId], [date], [createDate], [lastModifty]) VALUES (8, 4, CAST(N'2019-11-26T00:00:00.000' AS DateTime), CAST(N'2019-11-05T12:37:58.250' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[CourseDate] OFF
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([id], [name], [description], [categoryId], [imageId], [locationId], [createDate], [lastModifty], [price]) VALUES (4, N'Cocktails Masterclass', N'Learn how to make a mean cocktail during this private mixology workshop. Take a break from sightseeing and sip the cocktails you make under the tutelage of a master mixologist. You''ll also chat about the history of spirits, the shake vs. stir techniques, and what makes a balanced cocktail. Then sit back and taste your creations with your host.', 3, 2, 1, CAST(N'2019-10-28T18:10:24.407' AS DateTime), NULL, CAST(200.00 AS Decimal(7, 2)))
INSERT [dbo].[Courses] ([id], [name], [description], [categoryId], [imageId], [locationId], [createDate], [lastModifty], [price]) VALUES (6, N'Dumplings & Pork Bun Class HK', N'Cooking has been one of my biggest interests since I was a kid as my Mom taught me how to make different types of Chinese dishes. Especially traditional dumplings in which it was our regular custom that gathers all the family together to prepare, wrap and cook.', 3, 5, 1, CAST(N'2019-10-28T18:11:36.920' AS DateTime), NULL, CAST(200.00 AS Decimal(7, 2)))
INSERT [dbo].[Courses] ([id], [name], [description], [categoryId], [imageId], [locationId], [createDate], [lastModifty], [price]) VALUES (7, N'Thai Cooking Class', N'Learn a thing or two about Thai cooking while traveling in China. Head to Peng Chau Island for a hands-on Thai cooking class with a group of just eight people or fewer. You’ll enjoy an intimate atmosphere and personalized attention from your guide as you make and eat some delicious Thai dishes.', 3, 6, 1, CAST(N'2019-10-28T18:12:46.000' AS DateTime), NULL, CAST(200.00 AS Decimal(7, 2)))
INSERT [dbo].[Courses] ([id], [name], [description], [categoryId], [imageId], [locationId], [createDate], [lastModifty], [price]) VALUES (9, N'Rock Climbing Adventure', N'If you are fun loving, enjoy adventure and love to travel off the beaten path, rock climbing in Hong Kong can satisfy all your wants. Join our courses to explore the other side of Hong Kong away from the urban scene. From beginners to advanced level climbers, you can find the tour that fits your interest.', 5, 7, 1, CAST(N'2019-10-28T18:24:46.927' AS DateTime), NULL, CAST(200.00 AS Decimal(7, 2)))
INSERT [dbo].[Courses] ([id], [name], [description], [categoryId], [imageId], [locationId], [createDate], [lastModifty], [price]) VALUES (10, N'Wild Hong Kong', N'We specialise in HIKING, CYCLING & KAYAKING TOURS to various parts of rural Hong Kong, exploring individual or multiple environments. Half and full day routes are available :) Our aim is to share this stunningly beautiful back yard with you and show you many of Hong Kong''s hidden gems. From remote hilltop vistas down to secluded waterfalls and golden beaches. Wild Hong Kong will take you on an adventure to remember!', 5, 7, 1, CAST(N'2019-10-28T18:28:39.000' AS DateTime), NULL, CAST(200.00 AS Decimal(7, 2)))
INSERT [dbo].[Courses] ([id], [name], [description], [categoryId], [imageId], [locationId], [createDate], [lastModifty], [price]) VALUES (11, N'Treasures of Lisboa Food Tours', N'Book a Food Tour in Lisbon to discover the authentic Portuguese cuisine with a local guide and enjoy 14 Tastings in 3hours. Discover a different side of Portuguese gastronomy: treat yourself to an exceptional gourmet experience off the beaten track, with Treasures of Lisboa Food Tours! Alternate between tastings of typical dishes and discovering the most beautiful hidden places of Lisbon on foot. Wine, charcuterie, sardines, pastries, and any other gastronomic pearls will ensure you take in authentic, picturesque Portugal.', 3, 9, 1, CAST(N'2019-10-28T18:32:04.103' AS DateTime), NULL, CAST(200.00 AS Decimal(7, 2)))
INSERT [dbo].[Courses] ([id], [name], [description], [categoryId], [imageId], [locationId], [createDate], [lastModifty], [price]) VALUES (13, N'Properties Investment Course', N'Properties Investment Course', 8, 9, 2, CAST(N'2019-11-04T23:51:00.000' AS DateTime), NULL, CAST(123.00 AS Decimal(7, 2)))
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[CourseTime] ON 

INSERT [dbo].[CourseTime] ([id], [courseDateId], [time], [createDate], [lastModifty]) VALUES (1, 1, CAST(N'13:11:00' AS Time), CAST(N'2019-10-29T00:18:46.847' AS DateTime), NULL)
INSERT [dbo].[CourseTime] ([id], [courseDateId], [time], [createDate], [lastModifty]) VALUES (2, 1, CAST(N'23:06:00' AS Time), CAST(N'2019-10-29T00:19:07.580' AS DateTime), NULL)
INSERT [dbo].[CourseTime] ([id], [courseDateId], [time], [createDate], [lastModifty]) VALUES (3, 2, CAST(N'05:30:00' AS Time), CAST(N'2019-10-29T00:19:17.150' AS DateTime), NULL)
INSERT [dbo].[CourseTime] ([id], [courseDateId], [time], [createDate], [lastModifty]) VALUES (4, 2, CAST(N'06:09:00' AS Time), CAST(N'2019-10-29T00:19:25.690' AS DateTime), NULL)
INSERT [dbo].[CourseTime] ([id], [courseDateId], [time], [createDate], [lastModifty]) VALUES (5, 1, CAST(N'05:06:00' AS Time), CAST(N'2019-10-29T00:19:31.530' AS DateTime), NULL)
INSERT [dbo].[CourseTime] ([id], [courseDateId], [time], [createDate], [lastModifty]) VALUES (6, 3, CAST(N'11:22:33' AS Time), CAST(N'2019-11-05T04:07:23.143' AS DateTime), NULL)
INSERT [dbo].[CourseTime] ([id], [courseDateId], [time], [createDate], [lastModifty]) VALUES (11, 3, CAST(N'22:22:22' AS Time), CAST(N'2019-11-05T04:31:29.407' AS DateTime), NULL)
INSERT [dbo].[CourseTime] ([id], [courseDateId], [time], [createDate], [lastModifty]) VALUES (15, 8, CAST(N'12:22:12' AS Time), CAST(N'2019-11-05T12:37:58.270' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[CourseTime] OFF
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([id], [path], [description], [createDate], [lastModifty]) VALUES (2, N'/images/Courses/1.jpg', N'course photo1', CAST(N'2019-10-28T18:08:47.400' AS DateTime), NULL)
INSERT [dbo].[Images] ([id], [path], [description], [createDate], [lastModifty]) VALUES (5, N'/images/Courses/2.jpg', N'1', CAST(N'2019-10-28T18:09:07.147' AS DateTime), NULL)
INSERT [dbo].[Images] ([id], [path], [description], [createDate], [lastModifty]) VALUES (6, N'/images/Courses/3.jpg', N'3', CAST(N'2019-10-28T18:09:18.567' AS DateTime), NULL)
INSERT [dbo].[Images] ([id], [path], [description], [createDate], [lastModifty]) VALUES (7, N'/images/Courses/4.jpg', N'4', CAST(N'2019-10-28T18:09:24.783' AS DateTime), NULL)
INSERT [dbo].[Images] ([id], [path], [description], [createDate], [lastModifty]) VALUES (8, N'/images/Courses/5.jpg', N'5', CAST(N'2019-10-28T18:09:29.837' AS DateTime), NULL)
INSERT [dbo].[Images] ([id], [path], [description], [createDate], [lastModifty]) VALUES (9, N'/images/Courses/6.jpg', N'6', CAST(N'2019-10-28T18:09:34.783' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Images] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([id], [address], [lng], [lat], [createDate], [lastModifty]) VALUES (1, N'55 juniper road sunnynook', CAST(-36.751133 AS Decimal(9, 6)), CAST(174.736900 AS Decimal(9, 6)), CAST(N'2019-10-28T18:07:24.577' AS DateTime), NULL)
INSERT [dbo].[Location] ([id], [address], [lng], [lat], [createDate], [lastModifty]) VALUES (2, N'Testing Location, Some Where', CAST(0.000000 AS Decimal(9, 6)), CAST(-36.775110 AS Decimal(9, 6)), CAST(N'2019-11-04T22:46:15.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Location] OFF
SET IDENTITY_INSERT [dbo].[UserComments] ON 

INSERT [dbo].[UserComments] ([id], [userId], [userRateing], [comment], [createDate], [lastModifty], [courseId], [UserRegisterId]) VALUES (1, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', 5, N'This is a test 1', CAST(N'2019-11-03T16:32:18.427' AS DateTime), NULL, 4, NULL)
INSERT [dbo].[UserComments] ([id], [userId], [userRateing], [comment], [createDate], [lastModifty], [courseId], [UserRegisterId]) VALUES (2, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', 5, N'This is a test 2', CAST(N'2019-11-03T16:32:23.857' AS DateTime), NULL, 4, NULL)
INSERT [dbo].[UserComments] ([id], [userId], [userRateing], [comment], [createDate], [lastModifty], [courseId], [UserRegisterId]) VALUES (3, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', 5, N'This is a test 3', CAST(N'2019-11-03T16:32:27.630' AS DateTime), NULL, 4, NULL)
INSERT [dbo].[UserComments] ([id], [userId], [userRateing], [comment], [createDate], [lastModifty], [courseId], [UserRegisterId]) VALUES (4, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', NULL, N'Testing124', CAST(N'2019-11-03T17:14:20.167' AS DateTime), NULL, 4, NULL)
INSERT [dbo].[UserComments] ([id], [userId], [userRateing], [comment], [createDate], [lastModifty], [courseId], [UserRegisterId]) VALUES (5, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', NULL, N'Test111', CAST(N'2019-11-03T17:33:31.700' AS DateTime), NULL, 4, NULL)
INSERT [dbo].[UserComments] ([id], [userId], [userRateing], [comment], [createDate], [lastModifty], [courseId], [UserRegisterId]) VALUES (6, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', NULL, N'Test11111', CAST(N'2019-11-03T17:33:40.853' AS DateTime), NULL, 4, NULL)
INSERT [dbo].[UserComments] ([id], [userId], [userRateing], [comment], [createDate], [lastModifty], [courseId], [UserRegisterId]) VALUES (7, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', NULL, N'Test11111Test11111Test11111 Test11111Test11111Test11111Test11111Test11111Test11111 Test11111Test11111   Test11111 Test11111 Test11111 Test11111   Test11111Test11111   Test11111Test11111Test11111Test11111  Test11111 Test11111', CAST(N'2019-11-03T17:34:15.410' AS DateTime), NULL, 4, NULL)
INSERT [dbo].[UserComments] ([id], [userId], [userRateing], [comment], [createDate], [lastModifty], [courseId], [UserRegisterId]) VALUES (8, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', NULL, N'Testing111', CAST(N'2019-11-03T17:46:44.610' AS DateTime), NULL, 6, NULL)
INSERT [dbo].[UserComments] ([id], [userId], [userRateing], [comment], [createDate], [lastModifty], [courseId], [UserRegisterId]) VALUES (9, N'dba5bec3-7685-4df9-a1ea-32f59db7e787', NULL, N'12', CAST(N'2019-11-05T12:38:33.590' AS DateTime), NULL, 4, NULL)
SET IDENTITY_INSERT [dbo].[UserComments] OFF
SET IDENTITY_INSERT [dbo].[UserRegister] ON 

INSERT [dbo].[UserRegister] ([id], [courseTimeId], [userId], [createDate], [lastModifty]) VALUES (2, 1, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', CAST(N'2019-10-29T16:11:49.390' AS DateTime), NULL)
INSERT [dbo].[UserRegister] ([id], [courseTimeId], [userId], [createDate], [lastModifty]) VALUES (3, 5, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', CAST(N'2019-10-29T22:11:35.047' AS DateTime), NULL)
INSERT [dbo].[UserRegister] ([id], [courseTimeId], [userId], [createDate], [lastModifty]) VALUES (4, 5, N'2b50e2d1-41fb-44b8-a953-e48fd252d9d0', CAST(N'2019-10-29T22:12:38.063' AS DateTime), NULL)
INSERT [dbo].[UserRegister] ([id], [courseTimeId], [userId], [createDate], [lastModifty]) VALUES (5, 4, N'dba5bec3-7685-4df9-a1ea-32f59db7e787', CAST(N'2019-11-05T04:47:33.393' AS DateTime), NULL)
INSERT [dbo].[UserRegister] ([id], [courseTimeId], [userId], [createDate], [lastModifty]) VALUES (6, 4, N'dba5bec3-7685-4df9-a1ea-32f59db7e787', CAST(N'2019-11-05T12:38:43.893' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[UserRegister] OFF
ALTER TABLE [dbo].[Categorys] ADD  DEFAULT (getdate()) FOR [createDate]
GO
ALTER TABLE [dbo].[CourseDate] ADD  DEFAULT (getdate()) FOR [createDate]
GO
ALTER TABLE [dbo].[Courses] ADD  DEFAULT (getdate()) FOR [createDate]
GO
ALTER TABLE [dbo].[CourseTime] ADD  DEFAULT (getdate()) FOR [createDate]
GO
ALTER TABLE [dbo].[Images] ADD  DEFAULT (getdate()) FOR [createDate]
GO
ALTER TABLE [dbo].[Location] ADD  DEFAULT (getdate()) FOR [createDate]
GO
ALTER TABLE [dbo].[Providers] ADD  DEFAULT (getdate()) FOR [createDate]
GO
ALTER TABLE [dbo].[UserComments] ADD  DEFAULT (getdate()) FOR [createDate]
GO
ALTER TABLE [dbo].[UserRegister] ADD  DEFAULT (getdate()) FOR [createDate]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CourseDate]  WITH CHECK ADD FOREIGN KEY([courseId])
REFERENCES [dbo].[Courses] ([id])
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categorys] ([id])
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD FOREIGN KEY([imageId])
REFERENCES [dbo].[Images] ([id])
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD FOREIGN KEY([locationId])
REFERENCES [dbo].[Location] ([id])
GO
ALTER TABLE [dbo].[CourseTime]  WITH CHECK ADD FOREIGN KEY([courseDateId])
REFERENCES [dbo].[CourseDate] ([id])
GO
ALTER TABLE [dbo].[UserComments]  WITH CHECK ADD FOREIGN KEY([courseId])
REFERENCES [dbo].[Courses] ([id])
GO
ALTER TABLE [dbo].[UserComments]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserRegister]  WITH CHECK ADD FOREIGN KEY([courseTimeId])
REFERENCES [dbo].[CourseTime] ([id])
GO
ALTER TABLE [dbo].[UserRegister]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO


select * from images

select * from Courses