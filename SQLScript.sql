USE [ECommerce]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25/11/2023 12:40:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 25/11/2023 12:40:29 pm ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 25/11/2023 12:40:29 pm ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 25/11/2023 12:40:29 pm ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 25/11/2023 12:40:29 pm ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 25/11/2023 12:40:29 pm ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 25/11/2023 12:40:29 pm ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 25/11/2023 12:40:29 pm ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faqs]    Script Date: 25/11/2023 12:40:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faqs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](50) NULL,
	[Answer] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Faqs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 25/11/2023 12:40:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Price] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 25/11/2023 12:40:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [nvarchar](max) NULL,
	[Image] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[MetaInfo] [nvarchar](50) NULL,
	[MetaTitle] [nvarchar](50) NULL,
	[UrlReferer] [nvarchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 25/11/2023 12:40:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[MetaInfo] [nvarchar](50) NULL,
	[UrlReferer] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[MetaTitle] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 25/11/2023 12:40:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[Reviewid] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Reviews] [nvarchar](max) NULL,
	[Rating] [nvarchar](max) NULL,
	[ProductId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Reviewid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221207203148_initial-create', N'5.0.17')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221207222219_initial-create2', N'5.0.17')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221207222307_initial-create22', N'5.0.17')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230616123304_initial-create1', N'5.0.17')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230617091044_abdguvdy', N'5.0.17')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4f55b9cc-e752-4e3f-b52a-8406e5079cdc', N'Anonymous', N'ANONYMOUS', N'7416ea2c-136e-4d61-beeb-1db69e3887db')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0b24f223-e539-4507-a983-f8166d26d216', N'4f55b9cc-e752-4e3f-b52a-8406e5079cdc')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0b24f223-e539-4507-a983-f8166d26d216', N'admin@ecommerce.com', N'ADMIN@ECommerce.COM', N'admin@ecommerce.com', N'ADMIN@ECommerce.COM', 0, N'AQAAAAEAACcQAAAAEKSho88UKdEip0yWT1GB5Rst+gG9QIacGtlruzDv+KiZ5St5BDao37X47JkAprQgXQ==', N'BVJBENW4LHEQKHNXZV3TQSWXFODSVT3Q', N'aac80053-071e-4d8f-a475-366810846e38', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Faqs] ON 
GO
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (1, N'How do I place an order for medicines?', N'To place an order, you can browse the online catalog, search for the desired medicines, select the desired quantity, and add them to your cart. Once you have added all the items, proceed to the checkout page, provide the required details, and confirm your order.', 0, 1, CAST(N'2023-06-17T14:16:17.2784072' AS DateTime2), CAST(N'2023-06-17T14:16:17.2786425' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216')
GO
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (4, N'What payment methods are accepted?', N'We accept various payment methods, including credit/debit cards, net banking, and digital wallets. You can choose the payment method that is most convenient for you during the checkout process.', 0, 1, CAST(N'2023-06-17T14:17:07.0307424' AS DateTime2), CAST(N'2023-06-17T14:17:07.0307453' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216')
GO
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (5, N'Is it safe to make online payments?', N'Yes, we ensure the security of your payment information. Our website uses secure encryption technology to protect your data. Additionally, we only work with trusted payment gateway providers that follow industry standards for secure online transactions.', 0, 1, CAST(N'2023-06-17T14:17:40.3887730' AS DateTime2), CAST(N'2023-06-17T14:17:40.3887775' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216')
GO
SET IDENTITY_INSERT [dbo].[Faqs] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (1, N'test', 200, 3, N'Pending', 0, 1, CAST(N'2023-06-16T17:50:44.2873679' AS DateTime2), CAST(N'2023-06-16T17:50:44.2857462' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (2, N'test', 200, 30, N'Pending', 0, 1, CAST(N'2023-06-16T19:55:24.3832264' AS DateTime2), CAST(N'2023-06-16T19:55:24.3831508' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (3, N'test1', 35, 30, N'Pending', 0, 1, CAST(N'2023-06-16T19:55:24.4268599' AS DateTime2), CAST(N'2023-06-16T19:55:24.4268567' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (4, N'test', 200, 30, N'Pending', 0, 1, CAST(N'2023-06-16T21:58:27.6080480' AS DateTime2), CAST(N'2023-06-16T21:58:27.6071708' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (5, N'test', 200, 30, N'Pending', 0, 1, CAST(N'2023-06-16T22:06:25.4480285' AS DateTime2), CAST(N'2023-06-16T22:06:25.4480143' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (6, N'test', 200, 30, N'Pending', 0, 1, CAST(N'2023-06-16T22:08:49.3564138' AS DateTime2), CAST(N'2023-06-16T22:08:49.3564037' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (7, N'test', 200, 30, N'Pending', 0, 1, CAST(N'2023-06-16T22:13:52.3045150' AS DateTime2), CAST(N'2023-06-16T22:13:52.3045091' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (8, N'test', 200, 30, N'Pending', 0, 1, CAST(N'2023-06-16T22:22:41.6705759' AS DateTime2), CAST(N'2023-06-16T22:22:41.6705709' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (9, N'test', 200, 32, N'Pending', 0, 1, CAST(N'2023-06-17T14:11:52.7501073' AS DateTime2), CAST(N'2023-06-17T14:11:52.7496086' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (10, N'test', 200, 62, N'Pending', 0, 1, CAST(N'2023-06-17T14:12:24.4893296' AS DateTime2), CAST(N'2023-06-17T14:12:24.4893209' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (11, N'test1', 35, 30, N'Pending', 0, 1, CAST(N'2023-06-17T14:12:24.5111266' AS DateTime2), CAST(N'2023-06-17T14:12:24.5111243' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (12, N'test', 200, 31, N'Pending', 0, 1, CAST(N'2023-11-24T16:17:06.4784432' AS DateTime2), CAST(N'2023-11-24T16:17:06.4780800' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (13, N'test', 200, 6, N'Pending', 0, 1, CAST(N'2023-11-24T16:22:29.9009555' AS DateTime2), CAST(N'2023-11-24T16:22:29.9009486' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (14, N'test1', 35, 32, N'Pending', 0, 1, CAST(N'2023-11-24T16:22:29.9315021' AS DateTime2), CAST(N'2023-11-24T16:22:29.9315000' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (15, N'test', 200, 20, N'Pending', 0, 1, CAST(N'2023-11-24T16:23:25.7606862' AS DateTime2), CAST(N'2023-11-24T16:23:25.7606836' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (16, N'test1', 35, 38, N'Pending', 0, 1, CAST(N'2023-11-24T16:23:25.7761940' AS DateTime2), CAST(N'2023-11-24T16:23:25.7761911' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (17, N'test1', 35, 7, N'Pending', 0, 1, CAST(N'2023-11-24T23:59:46.9142141' AS DateTime2), CAST(N'2023-11-24T23:59:46.9138290' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (18, N'sf', 23, 1, N'Pending', 0, 1, CAST(N'2023-11-25T10:59:13.7792447' AS DateTime2), CAST(N'2023-11-25T10:59:13.7789017' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (19, N'test', 200, 1, N'Pending', 0, 1, CAST(N'2023-11-25T11:24:55.4881473' AS DateTime2), CAST(N'2023-11-25T11:24:55.4881388' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (20, N'test', 200, 1, N'Pending', 0, 1, CAST(N'2023-11-25T11:26:51.4450008' AS DateTime2), CAST(N'2023-11-25T11:26:51.4449990' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (21, N'test', 200, 1, N'Pending', 0, 1, CAST(N'2023-11-25T11:27:36.5093870' AS DateTime2), CAST(N'2023-11-25T11:27:36.5093848' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (22, N'umar', 213, 1, N'Pending', 0, 1, CAST(N'2023-11-25T11:43:39.7559157' AS DateTime2), CAST(N'2023-11-25T11:43:39.7558310' AS DateTime2), N'', N'')
GO
INSERT [dbo].[Orders] ([Id], [ProductName], [Price], [Quantity], [Status], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (23, N'umar', 213, 31, N'Pending', 0, 1, CAST(N'2023-11-25T11:43:52.7297383' AS DateTime2), CAST(N'2023-11-25T11:43:52.7297363' AS DateTime2), N'', N'')
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [Description], [ProductTypeId], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [MetaInfo], [MetaTitle], [UrlReferer]) VALUES (1, N'test', N'200', N'ec73ddc5-7656-45c5-87ab-9e518524286d_25-Nov-2023_00-06-53_pngwing.com.png', N'<h1>Title</h1><ol><li>this is test</li><li>this is test</li><li>this is test</li></ol>', 1, 0, 1, CAST(N'2023-06-16T17:42:08.2195130' AS DateTime2), CAST(N'2023-11-25T12:12:12.9975999' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216', N'test', N'test', N'test')
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [Description], [ProductTypeId], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [MetaInfo], [MetaTitle], [UrlReferer]) VALUES (2, N'test1', N'35', N'fc53bdbc-ff6a-45e4-88bb-d2572d0adb19_25-Nov-2023_00-04-22_pent.PNG', N'<p>test1</p>', 2, 0, 1, CAST(N'2023-06-16T19:54:58.0729954' AS DateTime2), CAST(N'2023-11-25T00:04:22.7907307' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216', N'test1', N'test1', N'test1')
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [Description], [ProductTypeId], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [MetaInfo], [MetaTitle], [UrlReferer]) VALUES (3, N'umar', N'213', N'088edc76-ec67-4ba1-bb0b-2681bb8667f4_24-Nov-2023_18-09-49_short.PNG', N'<ol><li>umar</li></ol>', 3, 0, 1, CAST(N'2023-11-24T18:09:04.7674478' AS DateTime2), CAST(N'2023-11-24T18:09:49.9082207' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216', N'umar', N'umar', N'umar')
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [Description], [ProductTypeId], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [MetaInfo], [MetaTitle], [UrlReferer]) VALUES (4, N'sf', N'23', N'21123eb8-abc5-4142-ad98-1bbf522e3cb8_25-Nov-2023_00-07-24_pngwing.com (1).png', N'<p>qwe</p>', 1, 0, 1, CAST(N'2023-11-25T00:07:24.8498737' AS DateTime2), CAST(N'2023-11-25T00:07:24.8501287' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216', N'qwe', N'w', N'qwe')
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [Description], [ProductTypeId], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [MetaInfo], [MetaTitle], [UrlReferer]) VALUES (5, N'Short', N'300', N'7373a17c-b0e3-467b-a551-ac6ca361be2d_25-Nov-2023_12-14-01_pent.PNG', N'<p>asd</p>', 5, 0, 1, CAST(N'2023-11-25T12:14:01.8805038' AS DateTime2), CAST(N'2023-11-25T12:14:01.8878575' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216', N'sad', N'asd', N'sad')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] ON 
GO
INSERT [dbo].[ProductTypes] ([Id], [Name], [MetaInfo], [UrlReferer], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [MetaTitle]) VALUES (1, N'test234', N'testing', N'test4332', 0, 1, CAST(N'2023-06-16T17:41:10.1470708' AS DateTime2), CAST(N'2023-06-16T17:41:10.1473883' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216', N'testing')
GO
INSERT [dbo].[ProductTypes] ([Id], [Name], [MetaInfo], [UrlReferer], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [MetaTitle]) VALUES (2, N'test1', N'abc', N'test1', 0, 1, CAST(N'2023-06-16T19:53:58.7162277' AS DateTime2), CAST(N'2023-06-16T19:53:58.7164449' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216', N'abc')
GO
INSERT [dbo].[ProductTypes] ([Id], [Name], [MetaInfo], [UrlReferer], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [MetaTitle]) VALUES (3, N'test11', N'abc', N'testing11', 0, 1, CAST(N'2023-11-24T16:20:35.9677635' AS DateTime2), CAST(N'2023-11-24T16:20:35.9679689' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216', N'abc')
GO
INSERT [dbo].[ProductTypes] ([Id], [Name], [MetaInfo], [UrlReferer], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [MetaTitle]) VALUES (4, N'try', N'qw', N'q', 0, 1, CAST(N'2023-11-25T10:12:41.7712689' AS DateTime2), CAST(N'2023-11-25T10:12:41.7714208' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216', N'qw')
GO
INSERT [dbo].[ProductTypes] ([Id], [Name], [MetaInfo], [UrlReferer], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [MetaTitle]) VALUES (5, N'Mens', N'dmajs', N'asjdnj', 0, 1, CAST(N'2023-11-25T12:13:37.2831738' AS DateTime2), CAST(N'2023-11-25T12:13:37.2833366' AS DateTime2), N'0b24f223-e539-4507-a983-f8166d26d216', N'0b24f223-e539-4507-a983-f8166d26d216', N'dmajs')
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Review] ON 
GO
INSERT [dbo].[Review] ([Reviewid], [FirstName], [LastName], [Email], [Reviews], [Rating], [ProductId], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (1, N'Umar', N'Amir', N'umaramir662@gmail.com', N'this product changed my life.. Thanks for making this awsome anti depression meds', N'Amazing', 1, 0, 1, CAST(N'2023-06-17T14:43:46.0530791' AS DateTime2), CAST(N'2023-06-17T14:43:46.0534339' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Review] ([Reviewid], [FirstName], [LastName], [Email], [Reviews], [Rating], [ProductId], [IsDeleted], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (2, N'Muhammad Taha', N'Ubaid', N'Umar@gmail.com', N'Very Good Poduct', N'not provided', 1, 0, 1, CAST(N'2023-11-25T11:12:09.0561340' AS DateTime2), CAST(N'2023-11-25T11:12:09.0562494' AS DateTime2), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Review] OFF
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [Image]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[ProductTypes] ADD  DEFAULT (N'') FOR [Name]
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
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTypes_ProductTypeId]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Products_ProductId]
GO
/****** Object:  StoredProcedure [dbo].[sp_fetchProductTypes]    Script Date: 25/11/2023 12:40:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_fetchProductTypes]
as
select Id,Name,UrlReferer from producttypes where IsActive='true' and IsDeleted='false'
GO
