USE [footballManager]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 20/07/2021 3:55:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[PlayerID] [int] NULL,
	[LocationX] [int] NULL,
	[LocationY] [int] NULL,
	[TeamID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 20/07/2021 3:55:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerName] [nvarchar](100) NULL,
	[Region] [nvarchar](100) NULL,
	[DateOfBirth] [datetime] NULL,
	[TeamID] [int] NULL,
	[Position] [varchar](50) NULL,
	[Physical] [float] NULL,
	[Attacking] [float] NULL,
	[Defending] [float] NULL,
	[Speed] [float] NULL,
	[Image] [varchar](max) NULL,
	[isMain] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 20/07/2021 3:55:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](50) NOT NULL,
	[TimeStart] [nvarchar](50) NOT NULL,
	[TimeEnd] [nvarchar](50) NOT NULL,
	[Date] [datetime] NULL,
	[TeamID] [int] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 20/07/2021 3:55:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](100) NULL,
	[Region] [nvarchar](100) NULL,
	[Logo] [varchar](max) NULL,
	[Money] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transfer]    Script Date: 20/07/2021 3:55:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfer](
	[TransferID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerID] [int] NULL,
	[PlayerName] [nvarchar](100) NULL,
	[TeamName] [nvarchar](100) NULL,
	[Price] [float] NULL,
	[Date] [date] NULL,
	[TeamID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20/07/2021 3:55:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[PrivateQuestion] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[TeamID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (1, 570, 406, 1)
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (5, 484, 224, 1)
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (12, 224, 25, 1)
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (11, 130, 153, 1)
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (3, 300, 149, 1)
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (9, 316, 317, 1)
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (8, 640, 234, 1)
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (2, 570, 55, 1)
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (7, 180, 415, 1)
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (4, 21, 222, 1)
INSERT [dbo].[Location] ([PlayerID], [LocationX], [LocationY], [TeamID]) VALUES (6, 141, 265, 1)
GO
SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (1, N'Messi', N'Argentine', CAST(N'1987-06-24T00:00:00.000' AS DateTime), 1, N'fw', 6, 10, 5, 10, N'm10.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (2, N'Ronaldo', N'Portuguese', CAST(N'1985-02-05T00:00:00.000' AS DateTime), 1, N'fw', 10, 6, 8, 6, N'13b8897e-1e09-4280-933b-ce0616ab4177.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (3, N'Paul Labile Pogba', N'French', CAST(N'1993-03-15T00:00:00.000' AS DateTime), 1, N'mf', 9, 8, 8, 9, N'3ga.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (4, N'Gareth Frank Bale', N'Welsh', CAST(N'1989-07-07T00:00:00.000' AS DateTime), 1, N'mf', 8, 8, 7, 10, N'fa3a34c3-5f02-4719-b856-fa112ac7befc.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (5, N'Bruno Fernandes', N'Portuguese', CAST(N'1994-09-08T00:00:00.000' AS DateTime), 1, N'fw', 7, 8, 7, 8, N'br.png', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (6, N'Giorgio Chiellini', N'Argentine', CAST(N'1984-08-15T00:00:00.000' AS DateTime), 1, N'df', 9, 5, 9, 6, N'ch.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (7, N'Philippe Coutinho Correia', N'Brazilian ', CAST(N'1992-12-06T00:00:00.000' AS DateTime), 1, N'mf', 9, 9, 5, 8, N'4296fb9d-6fb5-488e-8c91-be90db8ab232.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (8, N'Edinson Cavani', N'Uruguayan', CAST(N'1987-02-14T00:00:00.000' AS DateTime), 1, N'fw', 8, 8, 5, 8, N'cv.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (9, N'Paulo Dybala', N'Argentine', CAST(N'1993-11-15T00:00:00.000' AS DateTime), 1, N'fw', 7, 9, 5, 9, N'Dyjpg.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (10, N'Ryan Giggs', N'Wales', CAST(N'1973-11-29T00:00:00.000' AS DateTime), 1, N'fw', 9, 7, 7, 8, N'g.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (11, N'Gerard Piqué', N'Spanish', CAST(N'1987-02-02T00:00:00.000' AS DateTime), 1, N'df', 8, 6, 8, 8, N'pq.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (12, N'Marcus Rashford', N'England', CAST(N'1997-10-31T00:00:00.000' AS DateTime), 1, N'fw', 8, 8, 7, 10, N'rf.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (13, N'de Jong', N'Netherlands', CAST(N'1997-05-12T00:00:00.000' AS DateTime), 1, N'mf', 9, 9, 7, 8, N'sa.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (14, N'Karim Benzema', N'French', CAST(N'1987-12-19T00:00:00.000' AS DateTime), 1, N'fw', 9, 9, 7, 10, N'bz.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (15, N'Eden Hazard', N'Belgium', CAST(N'1991-07-01T00:00:00.000' AS DateTime), 1, N'fw', 9, 9, 7, 9, N'79faf0c1-81df-4ca5-92c2-403038ac4560.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (16, N'Toni Kroos', N'Germany', CAST(N'1990-01-04T00:00:00.000' AS DateTime), 1, N'mf', 9, 9, 8, 8, N'cr.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (17, N'Marcelo', N'Brazil', CAST(N'1988-05-12T00:00:00.000' AS DateTime), 1, N'df', 9, 8, 9, 8, N'lo.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (18, N'Jadon Sancho', N'England', CAST(N'2000-03-25T00:00:00.000' AS DateTime), 1, N'fw', 8, 9, 7, 10, N'cho.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (19, N'David de Gea', N'Spanish', CAST(N'1990-11-07T00:00:00.000' AS DateTime), 1, N'gk', 9, 5, 9, 5, N'tnk.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (20, N'Kai Havertz', N'Germany', CAST(N'1999-06-11T00:00:00.000' AS DateTime), 1, N'mf', 8, 9, 7, 9, N'hv.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (21, N'N''Golo Kanté', N'French', CAST(N'1991-03-29T00:00:00.000' AS DateTime), 1, N'mf', 7, 8, 8, 8, N'kan.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (22, N'Manuel Neuer', N'Germany', CAST(N'1986-03-27T00:00:00.000' AS DateTime), 2, N'gk', 9, 7, 7, 8, N'neu.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (23, N'Robert Lewandowski', N'Poland', CAST(N'1988-08-21T00:00:00.000' AS DateTime), 2, N'fw', 9, 9, 6, 9, N'ld.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (24, N'Kevin De Bruyne', N'Belgium', CAST(N'1991-06-28T00:00:00.000' AS DateTime), 2, N'mf', 9, 9, 8, 9, N'kv.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (26, N'Antoine Griezmann', N'France', CAST(N'1991-03-21T00:00:00.000' AS DateTime), 2, N'fw', 8, 8, 8, 8, N'gr.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (27, N'Ansu Fati', N'Guinea-Bissau', CAST(N'2002-10-31T00:00:00.000' AS DateTime), 2, N'fw ', 8, 8, 8, 8, N'bu.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (28, N'Dembélé', N'France', CAST(N'1997-05-15T00:00:00.000' AS DateTime), 2, N'fw', 9, 8, 8, 9, N'de.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (29, N'Pedri', N'Spain', CAST(N'2002-11-25T00:00:00.000' AS DateTime), 2, N'mf', 9, 5, 8, 8, N'g.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (30, N'Ilaix Moriba', N'Guinea', CAST(N'2003-01-19T00:00:00.000' AS DateTime), 2, N'mf', 8, 8, 8, 8, N'z.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (31, N'Sergio Busquets', N'Spain', CAST(N'1988-07-16T00:00:00.000' AS DateTime), 2, N'mf', 9, 8, 7, 8, N'qq.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (32, N'Riqui Puig', N'Spain', CAST(N'1999-08-13T00:00:00.000' AS DateTime), 2, N'mf', 8, 8, 8, 8, N'pu.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (33, N'Martin Braithwaite', N'Denmark', CAST(N'1991-06-05T00:00:00.000' AS DateTime), 2, N'fw', 9, 8, 5, 8, N'bw.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (34, N'Jordi Alba', N'Spain', CAST(N'1989-03-21T00:00:00.000' AS DateTime), 2, N'df', 9, 8, 8, 8, N'ab.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (35, N'Samuel Umtiti', N'Cameroon', CAST(N'1993-11-14T00:00:00.000' AS DateTime), 2, N'df', 9, 8, 8, 8, N'ut.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (36, N'ter Stegen', N'Germany', CAST(N'1992-04-30T00:00:00.000' AS DateTime), 2, N'gk', 9, 5, 5, 8, N'te.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (37, N'Neto', N'Brazil', CAST(N'1989-07-19T00:00:00.000' AS DateTime), 2, N'gk', 9, 5, 5, 8, N'ne.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (38, N'Varane', N'France', CAST(N'1993-04-25T00:00:00.000' AS DateTime), 2, N'df', 9, 8, 8, 8, N'va.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (39, N'David Alaba', N'Austria', CAST(N'1992-06-24T00:00:00.000' AS DateTime), 2, N'df', 9, 8, 6, 7, N'dl.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (40, N'Isco', N'Spain', CAST(N'1992-04-21T00:00:00.000' AS DateTime), 2, N'mf', 9, 8, 8, 8, N'is.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (41, N'Luka Modrić', N'Croatia', CAST(N'1985-09-09T00:00:00.000' AS DateTime), 2, N'mf', 7, 9, 8, 8, N'MR.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (42, N'Vinícius Júnior', N'Brazil', CAST(N'2000-07-12T00:00:00.000' AS DateTime), 2, N'fw', 8, 8, 8, 8, N'vi.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (43, N'Thibaut Courtois', N'Belgium', CAST(N'1992-05-11T00:00:00.000' AS DateTime), 2, N'gk', 10, 5, 5, 8, N'cot.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (44, N'Marco Asensio', N'Spain', CAST(N'1996-01-21T00:00:00.000' AS DateTime), 2, N'fw', 8, 8, 8, 8, N'as.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (45, N'Nacho', N'Spain', CAST(N'1990-01-18T00:00:00.000' AS DateTime), 2, N'df', 8, 6, 8, 8, N'na.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (46, N'Casemiro', N'Brazil', CAST(N'1992-02-23T00:00:00.000' AS DateTime), 0, N'df', 8, 8, 8, 8, N'cs.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (47, N'Federico Valverde', N'Uruguay', CAST(N'1998-07-22T00:00:00.000' AS DateTime), 3, N'mf', 8, 8, 8, 8, N'val.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (48, N'Dani Carvajal', N'Spain', CAST(N'1992-01-11T00:00:00.000' AS DateTime), 3, N'df', 8, 8, 8, 8, N'rb.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (49, N'Harry Maguire', N'England', CAST(N'1993-03-05T00:00:00.000' AS DateTime), 3, N'df', 10, 8, 8, 8, N'mg.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (50, N'Anthony Martial', N'France', CAST(N'1995-12-05T00:00:00.000' AS DateTime), 3, N'fw', 9, 8, 8, 8, N'mt.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (51, N'Mason Greenwood', N'England', CAST(N'2001-10-01T00:00:00.000' AS DateTime), 3, N'fw', 8, 8, 8, 8, N'grw.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (52, N'Jesse Lingard', N'England', CAST(N'1992-12-15T00:00:00.000' AS DateTime), 3, N'mf', 10, 10, 10, 10, N'lg.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (53, N'Donny van de Beek', N'Netherlands', CAST(N'1997-04-18T00:00:00.000' AS DateTime), 3, N'mf', 8, 8, 8, 8, N'vb.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (54, N'Tom Heaton', N'England', CAST(N'1986-04-15T00:00:00.000' AS DateTime), 3, N'gk', 9, 5, 5, 5, N'to.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (55, N'Juan Mata', N'Spain', CAST(N'1988-04-28T00:00:00.000' AS DateTime), 3, N'mf', 8, 8, 8, 8, N'ma.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (56, N'Luke Shaw', N'England', CAST(N'1995-07-12T00:00:00.000' AS DateTime), 3, N'df', 9, 8, 8, 8, N'sh.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (57, N'Fred', N'Brazil', CAST(N'1993-03-05T00:00:00.000' AS DateTime), 3, N'mf', 8, 8, 8, 8, N'fz.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (58, N'Dean Henderson', N'England', CAST(N'1997-03-12T00:00:00.000' AS DateTime), 3, N'gk', 9, 5, 5, 5, N'den.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (59, N'Daniel James', N'England', CAST(N'1997-11-10T00:00:00.000' AS DateTime), 3, N'fw', 9, 8, 8, 8, N'ja.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (60, N'Federico Chiesa', N'Italya', CAST(N'1997-10-25T00:00:00.000' AS DateTime), 3, N'gw', 8, 8, 8, 8, N'che.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (61, N'Álvaro Morata', N'Spain', CAST(N'1992-10-23T00:00:00.000' AS DateTime), 3, N'fw', 9, 0, 0, 9, N'mo.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (62, N'de Ligt', N'Netherlands', CAST(N'1999-08-12T00:00:00.000' AS DateTime), 3, N'df', 9, 5, 9, 9, N'san.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (63, N'Leonardo Bonucci', N'Italy', CAST(N'1987-05-01T00:00:00.000' AS DateTime), 3, N'df', 9, 7, 9, 9, N'bo.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (64, N'Juan Cuadrado', N'Colombia', CAST(N'1988-05-26T00:00:00.000' AS DateTime), 3, N'fw', 9, 8, 8, 8, N'cu.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (65, N'Adrien Rabiot', N'France', CAST(N'1995-04-03T00:00:00.000' AS DateTime), 3, N'mf', 8, 8, 8, 8, N'rab.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (66, N'Aaron Ramsey', N'Wales', CAST(N'1990-12-26T00:00:00.000' AS DateTime), 3, N'mf', 8, 8, 8, 8, N'rs.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (72, N'asdasd', N'Cameroon', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (74, N'xcv', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (76, N'cgxg', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (78, N'asdasd', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (81, N'asdasd', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (83, N'sdfsdf', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (84, N'fdgdfg', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (85, N'dfgdfg', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (71, N'dat', N'England', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 5, 1, 4, 3, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (75, N'asdasd', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (80, N'ewrwer', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (73, N'qwe', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (77, N'fhgj', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (79, N'asdasd', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (82, N'asdada', N'Argentine', CAST(N'2021-08-07T00:57:16.000' AS DateTime), 14, N'df', 1, 1, 1, 1, N'ca23129c-e364-463f-8d78-bb371220119e.jpg', 1)
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([ScheduleID], [Content], [TimeStart], [TimeEnd], [Date], [TeamID]) VALUES (2, N'Lich tap luyen', N'8:2', N'3:0', CAST(N'2021-12-07T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Schedule] ([ScheduleID], [Content], [TimeStart], [TimeEnd], [Date], [TeamID]) VALUES (4, N'Eo Chang Hy', N'3:3', N'9:3', CAST(N'2021-08-07T21:14:43.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON 

INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (1, N'Barcelona', N'Spain', N'baxa.png', 8760000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (2, N'Real Madrid', N'Spain', N'ra.png', 1254000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (3, N'Manchester United', N'England', N'mu.jpg', 3300000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (4, N'Chelsea', N'England', N'cs.png', 3200000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (5, N'Bayern Munich', N'Germany', N'ba.png', 3070000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (6, N'Manchester City', N'England', N'mc.png', 2910000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (7, N'Paris Saint-Germain', N'France', N'pa.png', 1820000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (8, N'Juve', N'Italya', N'jv.png', 2000000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (14, N'Eo Chang Hy', N'Azerbaijan', N'49c69171-92d7-4ace-b437-755ce26ff3fa.jpg', 20000)
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
SET IDENTITY_INSERT [dbo].[Transfer] ON 

INSERT [dbo].[Transfer] ([TransferID], [PlayerID], [PlayerName], [TeamName], [Price], [Date], [TeamID]) VALUES (13, 46, N'Casemiro', N'Real Madrid', 5000000, CAST(N'2021-07-20' AS Date), 2)
SET IDENTITY_INSERT [dbo].[Transfer] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (1, N'admin', N'admin', N'21312312', N'sa@gmail.com', N'Question 1', N'sa', 1)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (2, N'user2', N'123', N'123123', N'sb@gmail.com', N'Question 2', N'sb', 2)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (3, N'Ole', N'123', N'7377218282', N'sc@gmai.com', N'Question 3', N'sc', 3)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (4, N'Thomas Tuchel', N'123', N'434343', N'sd@gmail.com', N'Question 4', N'sd', 4)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (5, N'Hansi Flick', N'123', N'45454545', N'se@gmail.com', N'Question 1', N'se', 5)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (6, N'Pep', N'123', N'3333733737', N'sf@gmial.com', N'Question 2', N'sf', 6)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (7, N'Mauricio Pochettino', N'123', N'55555', N'mau@gmail.com', N'Question 3', N'ss', 7)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (8, N'Allegri', N'123', N'777777', N'all@gmial.com', N'Question 4', N'sls', 8)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (14, N'admin2', N'admin', N'123456', N'dat@gmail.com', N'', N'dat', 14)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
