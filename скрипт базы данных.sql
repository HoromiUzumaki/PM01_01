USE [master]
GO
/****** Object:  Database [HappyTooth]    Script Date: 27.03.2025 16:55:52 ******/
CREATE DATABASE [HappyTooth]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HappyTooth', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HappyTooth.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HappyTooth_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HappyTooth_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HappyTooth] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HappyTooth].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HappyTooth] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HappyTooth] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HappyTooth] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HappyTooth] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HappyTooth] SET ARITHABORT OFF 
GO
ALTER DATABASE [HappyTooth] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HappyTooth] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HappyTooth] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HappyTooth] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HappyTooth] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HappyTooth] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HappyTooth] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HappyTooth] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HappyTooth] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HappyTooth] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HappyTooth] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HappyTooth] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HappyTooth] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HappyTooth] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HappyTooth] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HappyTooth] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HappyTooth] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HappyTooth] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HappyTooth] SET  MULTI_USER 
GO
ALTER DATABASE [HappyTooth] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HappyTooth] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HappyTooth] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HappyTooth] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HappyTooth] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HappyTooth] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HappyTooth] SET QUERY_STORE = OFF
GO
USE [HappyTooth]
GO
/****** Object:  Table [dbo].[appointments]    Script Date: 27.03.2025 16:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[appointments](
	[appointment_id] [int] IDENTITY(1,1) NOT NULL,
	[patient_id] [int] NOT NULL,
	[doctor_id] [int] NOT NULL,
	[appointment_time] [datetime2](7) NOT NULL,
	[status] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[appointment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doctor_schedule]    Script Date: 27.03.2025 16:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctor_schedule](
	[schedule_id] [int] IDENTITY(1,1) NOT NULL,
	[doctor_id] [int] NOT NULL,
	[day_of_week] [nvarchar](10) NOT NULL,
	[start_time] [time](7) NOT NULL,
	[end_time] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[schedule_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doctors]    Script Date: 27.03.2025 16:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctors](
	[doctor_id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[specialization] [nvarchar](50) NOT NULL,
	[user_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[doctor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patients]    Script Date: 27.03.2025 16:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patients](
	[patient_id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[phone] [nvarchar](20) NOT NULL,
	[email] [nvarchar](50) NULL,
	[birth_date] [date] NULL,
	[user_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[patient_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[services]    Script Date: 27.03.2025 16:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[services](
	[service_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 27.03.2025 16:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password_hash] [nvarchar](255) NOT NULL,
	[role] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[visit_services]    Script Date: 27.03.2025 16:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[visit_services](
	[visit_id] [int] NOT NULL,
	[service_id] [int] NOT NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[visit_id] ASC,
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[visits]    Script Date: 27.03.2025 16:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[visits](
	[visit_id] [int] IDENTITY(1,1) NOT NULL,
	[appointment_id] [int] NOT NULL,
	[diagnosis] [nvarchar](max) NULL,
	[treatment] [nvarchar](max) NULL,
	[total_price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[visit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[appointments] ON 

INSERT [dbo].[appointments] ([appointment_id], [patient_id], [doctor_id], [appointment_time], [status]) VALUES (1, 1, 1, CAST(N'2023-12-15T10:00:00.0000000' AS DateTime2), N'запланирован')
INSERT [dbo].[appointments] ([appointment_id], [patient_id], [doctor_id], [appointment_time], [status]) VALUES (2, 2, 3, CAST(N'2023-12-16T11:30:00.0000000' AS DateTime2), N'запланирован')
INSERT [dbo].[appointments] ([appointment_id], [patient_id], [doctor_id], [appointment_time], [status]) VALUES (3, 3, 2, CAST(N'2023-12-14T15:45:00.0000000' AS DateTime2), N'завершен')
INSERT [dbo].[appointments] ([appointment_id], [patient_id], [doctor_id], [appointment_time], [status]) VALUES (4, 4, 5, CAST(N'2023-12-17T09:15:00.0000000' AS DateTime2), N'запланирован')
INSERT [dbo].[appointments] ([appointment_id], [patient_id], [doctor_id], [appointment_time], [status]) VALUES (5, 5, 4, CAST(N'2023-12-13T14:00:00.0000000' AS DateTime2), N'отменен')
INSERT [dbo].[appointments] ([appointment_id], [patient_id], [doctor_id], [appointment_time], [status]) VALUES (6, 6, 7, CAST(N'2023-12-18T16:30:00.0000000' AS DateTime2), N'запланирован')
INSERT [dbo].[appointments] ([appointment_id], [patient_id], [doctor_id], [appointment_time], [status]) VALUES (7, 7, 6, CAST(N'2023-12-12T12:45:00.0000000' AS DateTime2), N'завершен')
INSERT [dbo].[appointments] ([appointment_id], [patient_id], [doctor_id], [appointment_time], [status]) VALUES (8, 8, 9, CAST(N'2023-12-19T08:30:00.0000000' AS DateTime2), N'запланирован')
INSERT [dbo].[appointments] ([appointment_id], [patient_id], [doctor_id], [appointment_time], [status]) VALUES (9, 9, 8, CAST(N'2023-12-11T17:15:00.0000000' AS DateTime2), N'завершен')
INSERT [dbo].[appointments] ([appointment_id], [patient_id], [doctor_id], [appointment_time], [status]) VALUES (10, 10, 10, CAST(N'2023-12-20T13:00:00.0000000' AS DateTime2), N'запланирован')
SET IDENTITY_INSERT [dbo].[appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[doctor_schedule] ON 

INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (1, 1, N'пн', CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (2, 1, N'вт', CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (3, 1, N'ср', CAST(N'10:00:00' AS Time), CAST(N'19:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (4, 2, N'пн', CAST(N'10:00:00' AS Time), CAST(N'19:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (5, 2, N'ср', CAST(N'08:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (6, 2, N'пт', CAST(N'08:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (7, 3, N'вт', CAST(N'11:00:00' AS Time), CAST(N'20:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (8, 3, N'чт', CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (9, 3, N'сб', CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (10, 4, N'пн', CAST(N'08:30:00' AS Time), CAST(N'17:30:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (11, 4, N'вт', CAST(N'08:30:00' AS Time), CAST(N'17:30:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (12, 4, N'чт', CAST(N'08:30:00' AS Time), CAST(N'17:30:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (13, 5, N'пн', CAST(N'09:00:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (14, 5, N'ср', CAST(N'09:00:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (15, 5, N'пт', CAST(N'09:00:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (16, 6, N'вт', CAST(N'10:00:00' AS Time), CAST(N'19:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (17, 6, N'чт', CAST(N'10:00:00' AS Time), CAST(N'19:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (18, 6, N'сб', CAST(N'10:00:00' AS Time), CAST(N'14:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (19, 7, N'пн', CAST(N'08:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (20, 7, N'ср', CAST(N'08:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (21, 7, N'пт', CAST(N'08:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (22, 8, N'вт', CAST(N'12:00:00' AS Time), CAST(N'20:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (23, 8, N'чт', CAST(N'12:00:00' AS Time), CAST(N'20:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (24, 8, N'сб', CAST(N'10:00:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (25, 9, N'пн', CAST(N'09:30:00' AS Time), CAST(N'18:30:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (26, 9, N'вт', CAST(N'09:30:00' AS Time), CAST(N'18:30:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (27, 9, N'чт', CAST(N'09:30:00' AS Time), CAST(N'18:30:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (28, 10, N'пн', CAST(N'07:00:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (29, 10, N'ср', CAST(N'07:00:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[doctor_schedule] ([schedule_id], [doctor_id], [day_of_week], [start_time], [end_time]) VALUES (30, 10, N'пт', CAST(N'07:00:00' AS Time), CAST(N'16:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[doctor_schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[doctors] ON 

INSERT [dbo].[doctors] ([doctor_id], [full_name], [specialization], [user_id]) VALUES (1, N'Козлова Елена Дмитриевна', N'Терапевт', 7)
INSERT [dbo].[doctors] ([doctor_id], [full_name], [specialization], [user_id]) VALUES (2, N'Петров Сергей Иванович', N'Хирург', NULL)
INSERT [dbo].[doctors] ([doctor_id], [full_name], [specialization], [user_id]) VALUES (3, N'Соколова Анна Михайловна', N'Ортодонт', NULL)
INSERT [dbo].[doctors] ([doctor_id], [full_name], [specialization], [user_id]) VALUES (4, N'Лебедев Денис Владимирович', N'Имплантолог', NULL)
INSERT [dbo].[doctors] ([doctor_id], [full_name], [specialization], [user_id]) VALUES (5, N'Громова Наталья Петровна', N'Пародонтолог', NULL)
INSERT [dbo].[doctors] ([doctor_id], [full_name], [specialization], [user_id]) VALUES (6, N'Орлов Андрей Сергеевич', N'Эндодонтист', NULL)
INSERT [dbo].[doctors] ([doctor_id], [full_name], [specialization], [user_id]) VALUES (7, N'Зайцева Ирина Викторовна', N'Детский стоматолог', NULL)
INSERT [dbo].[doctors] ([doctor_id], [full_name], [specialization], [user_id]) VALUES (8, N'Воробьев Павел Николаевич', N'Ортопед', NULL)
INSERT [dbo].[doctors] ([doctor_id], [full_name], [specialization], [user_id]) VALUES (9, N'Соловьева Марина Алексеевна', N'Гигиенист', NULL)
INSERT [dbo].[doctors] ([doctor_id], [full_name], [specialization], [user_id]) VALUES (10, N'Баранов Игорь Олегович', N'Челюстно-лицевой хирург', NULL)
SET IDENTITY_INSERT [dbo].[doctors] OFF
GO
SET IDENTITY_INSERT [dbo].[patients] ON 

INSERT [dbo].[patients] ([patient_id], [full_name], [phone], [email], [birth_date], [user_id]) VALUES (1, N'Иванов Петр Сидорович', N'+79161234567', N'ivanov@mail.ru', CAST(N'1985-03-15' AS Date), 5)
INSERT [dbo].[patients] ([patient_id], [full_name], [phone], [email], [birth_date], [user_id]) VALUES (2, N'Смирнова Анна Владимировна', N'+79035678901', N'smirnova@gmail.com', CAST(N'1990-07-22' AS Date), 6)
INSERT [dbo].[patients] ([patient_id], [full_name], [phone], [email], [birth_date], [user_id]) VALUES (3, N'Кузнецов Дмитрий Игоревич', N'+79219876543', N'kuznetsov@yandex.ru', CAST(N'1978-11-30' AS Date), NULL)
INSERT [dbo].[patients] ([patient_id], [full_name], [phone], [email], [birth_date], [user_id]) VALUES (4, N'Петрова Ольга Сергеевна', N'+79105551234', N'petrova@mail.com', CAST(N'1982-05-17' AS Date), NULL)
INSERT [dbo].[patients] ([patient_id], [full_name], [phone], [email], [birth_date], [user_id]) VALUES (5, N'Сидоров Алексей Викторович', N'+79031112233', N'sidorov@inbox.ru', CAST(N'1995-09-21' AS Date), NULL)
INSERT [dbo].[patients] ([patient_id], [full_name], [phone], [email], [birth_date], [user_id]) VALUES (6, N'Федорова Мария Дмитриевна', N'+79253334455', N'fedorova@gmail.com', CAST(N'1988-12-10' AS Date), NULL)
INSERT [dbo].[patients] ([patient_id], [full_name], [phone], [email], [birth_date], [user_id]) VALUES (7, N'Николаев Андрей Павлович', N'+79167778899', N'nikolaev@mail.ru', CAST(N'1973-04-25' AS Date), NULL)
INSERT [dbo].[patients] ([patient_id], [full_name], [phone], [email], [birth_date], [user_id]) VALUES (8, N'Волкова Екатерина Олеговна', N'+79049990011', N'volkova@yandex.ru', CAST(N'1992-08-14' AS Date), NULL)
INSERT [dbo].[patients] ([patient_id], [full_name], [phone], [email], [birth_date], [user_id]) VALUES (9, N'Белов Артем Александрович', N'+79262223344', N'belov@inbox.ru', CAST(N'1980-01-05' AS Date), NULL)
INSERT [dbo].[patients] ([patient_id], [full_name], [phone], [email], [birth_date], [user_id]) VALUES (10, N'Козлова Татьяна Ивановна', N'+79134445566', N'kozlova@gmail.com', CAST(N'1975-06-28' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[patients] OFF
GO
SET IDENTITY_INSERT [dbo].[services] ON 

INSERT [dbo].[services] ([service_id], [name], [price]) VALUES (1, N'Консультация', CAST(1500.00 AS Decimal(10, 2)))
INSERT [dbo].[services] ([service_id], [name], [price]) VALUES (2, N'Лечение кариеса', CAST(5000.00 AS Decimal(10, 2)))
INSERT [dbo].[services] ([service_id], [name], [price]) VALUES (3, N'Удаление зуба', CAST(7000.00 AS Decimal(10, 2)))
INSERT [dbo].[services] ([service_id], [name], [price]) VALUES (4, N'Профессиональная чистка', CAST(3500.00 AS Decimal(10, 2)))
INSERT [dbo].[services] ([service_id], [name], [price]) VALUES (5, N'Рентгенография', CAST(1200.00 AS Decimal(10, 2)))
INSERT [dbo].[services] ([service_id], [name], [price]) VALUES (6, N'Установка пломбы', CAST(4500.00 AS Decimal(10, 2)))
INSERT [dbo].[services] ([service_id], [name], [price]) VALUES (7, N'Имплантация зуба', CAST(25000.00 AS Decimal(10, 2)))
INSERT [dbo].[services] ([service_id], [name], [price]) VALUES (8, N'Исправление прикуса', CAST(30000.00 AS Decimal(10, 2)))
INSERT [dbo].[services] ([service_id], [name], [price]) VALUES (9, N'Лечение периодонтита', CAST(8000.00 AS Decimal(10, 2)))
INSERT [dbo].[services] ([service_id], [name], [price]) VALUES (10, N'Виниры', CAST(20000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[services] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([user_id], [username], [password_hash], [role]) VALUES (4, N'admin', N'admin123', N'admin')
INSERT [dbo].[users] ([user_id], [username], [password_hash], [role]) VALUES (5, N'ivanov', N'ivanov123', N'patient')
INSERT [dbo].[users] ([user_id], [username], [password_hash], [role]) VALUES (6, N'smirnova', N'smirnova123', N'patient')
INSERT [dbo].[users] ([user_id], [username], [password_hash], [role]) VALUES (7, N'kozlova', N'kozlova123', N'doctor')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (1, 2, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (1, 6, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (2, 9, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (3, 1, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (4, 4, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (5, 5, 2)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (5, 9, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (6, 1, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (7, 4, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (8, 3, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (9, 1, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (9, 2, 1)
INSERT [dbo].[visit_services] ([visit_id], [service_id], [quantity]) VALUES (10, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[visits] ON 

INSERT [dbo].[visits] ([visit_id], [appointment_id], [diagnosis], [treatment], [total_price]) VALUES (1, 3, N'Кариес', N'Пломбирование зуба', CAST(4500.00 AS Decimal(10, 2)))
INSERT [dbo].[visits] ([visit_id], [appointment_id], [diagnosis], [treatment], [total_price]) VALUES (2, 7, N'Пульпит', N'Эндодонтическое лечение', CAST(8000.00 AS Decimal(10, 2)))
INSERT [dbo].[visits] ([visit_id], [appointment_id], [diagnosis], [treatment], [total_price]) VALUES (3, 9, N'Отсутствие зуба', N'Консультация по имплантации', CAST(1500.00 AS Decimal(10, 2)))
INSERT [dbo].[visits] ([visit_id], [appointment_id], [diagnosis], [treatment], [total_price]) VALUES (4, 3, N'Гингивит', N'Профессиональная чистка', CAST(3500.00 AS Decimal(10, 2)))
INSERT [dbo].[visits] ([visit_id], [appointment_id], [diagnosis], [treatment], [total_price]) VALUES (5, 7, N'Периодонтит', N'Лечение каналов', CAST(10000.00 AS Decimal(10, 2)))
INSERT [dbo].[visits] ([visit_id], [appointment_id], [diagnosis], [treatment], [total_price]) VALUES (6, 9, N'Неправильный прикус', N'Консультация ортодонта', CAST(1500.00 AS Decimal(10, 2)))
INSERT [dbo].[visits] ([visit_id], [appointment_id], [diagnosis], [treatment], [total_price]) VALUES (7, 3, N'Зубной камень', N'Чистка AirFlow', CAST(4000.00 AS Decimal(10, 2)))
INSERT [dbo].[visits] ([visit_id], [appointment_id], [diagnosis], [treatment], [total_price]) VALUES (8, 7, N'Перелом зуба', N'Удаление', CAST(7000.00 AS Decimal(10, 2)))
INSERT [dbo].[visits] ([visit_id], [appointment_id], [diagnosis], [treatment], [total_price]) VALUES (9, 9, N'Кариес', N'Лечение с анестезией', CAST(5500.00 AS Decimal(10, 2)))
INSERT [dbo].[visits] ([visit_id], [appointment_id], [diagnosis], [treatment], [total_price]) VALUES (10, 3, N'Стоматит', N'Назначение лечения', CAST(2000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[visits] OFF
GO
/****** Object:  Index [idx_appointments_doctor]    Script Date: 27.03.2025 16:55:52 ******/
CREATE NONCLUSTERED INDEX [idx_appointments_doctor] ON [dbo].[appointments]
(
	[doctor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_appointments_patient]    Script Date: 27.03.2025 16:55:52 ******/
CREATE NONCLUSTERED INDEX [idx_appointments_patient] ON [dbo].[appointments]
(
	[patient_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_appointments_time]    Script Date: 27.03.2025 16:55:52 ******/
CREATE NONCLUSTERED INDEX [idx_appointments_time] ON [dbo].[appointments]
(
	[appointment_time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_doctor_day]    Script Date: 27.03.2025 16:55:52 ******/
ALTER TABLE [dbo].[doctor_schedule] ADD  CONSTRAINT [UQ_doctor_day] UNIQUE NONCLUSTERED 
(
	[doctor_id] ASC,
	[day_of_week] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_doctor_schedule]    Script Date: 27.03.2025 16:55:52 ******/
CREATE NONCLUSTERED INDEX [idx_doctor_schedule] ON [dbo].[doctor_schedule]
(
	[doctor_id] ASC,
	[day_of_week] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__users__F3DBC57254EC3D0A]    Script Date: 27.03.2025 16:55:52 ******/
ALTER TABLE [dbo].[users] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_users_roles]    Script Date: 27.03.2025 16:55:52 ******/
CREATE NONCLUSTERED INDEX [idx_users_roles] ON [dbo].[users]
(
	[role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_users_username]    Script Date: 27.03.2025 16:55:52 ******/
CREATE NONCLUSTERED INDEX [idx_users_username] ON [dbo].[users]
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[visit_services] ADD  DEFAULT ((1)) FOR [quantity]
GO
ALTER TABLE [dbo].[appointments]  WITH CHECK ADD FOREIGN KEY([doctor_id])
REFERENCES [dbo].[doctors] ([doctor_id])
GO
ALTER TABLE [dbo].[appointments]  WITH CHECK ADD FOREIGN KEY([patient_id])
REFERENCES [dbo].[patients] ([patient_id])
GO
ALTER TABLE [dbo].[doctor_schedule]  WITH CHECK ADD FOREIGN KEY([doctor_id])
REFERENCES [dbo].[doctors] ([doctor_id])
GO
ALTER TABLE [dbo].[doctors]  WITH CHECK ADD  CONSTRAINT [FK_doctors_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[doctors] CHECK CONSTRAINT [FK_doctors_users]
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD  CONSTRAINT [FK_patients_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[patients] CHECK CONSTRAINT [FK_patients_users]
GO
ALTER TABLE [dbo].[visit_services]  WITH CHECK ADD FOREIGN KEY([service_id])
REFERENCES [dbo].[services] ([service_id])
GO
ALTER TABLE [dbo].[visit_services]  WITH CHECK ADD FOREIGN KEY([visit_id])
REFERENCES [dbo].[visits] ([visit_id])
GO
ALTER TABLE [dbo].[visits]  WITH CHECK ADD FOREIGN KEY([appointment_id])
REFERENCES [dbo].[appointments] ([appointment_id])
GO
ALTER TABLE [dbo].[appointments]  WITH CHECK ADD CHECK  (([status]='завершен' OR [status]='отменен' OR [status]='запланирован'))
GO
ALTER TABLE [dbo].[doctor_schedule]  WITH CHECK ADD CHECK  (([day_of_week]='вс' OR [day_of_week]='сб' OR [day_of_week]='пт' OR [day_of_week]='чт' OR [day_of_week]='ср' OR [day_of_week]='вт' OR [day_of_week]='пн'))
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD CHECK  (([role]='admin' OR [role]='doctor' OR [role]='patient'))
GO
USE [master]
GO
ALTER DATABASE [HappyTooth] SET  READ_WRITE 
GO
