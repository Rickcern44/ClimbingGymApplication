--Make sure im using the master to create 
USE master 
GO 
--If the database already exists then drop if before creating a new one
Drop database IF exists ClimbingGym
GO
--Create the DB
CREATE Database ClimbingGym
GO
--Switch the use statement to the new DB
USE ClimbingGym
GO

--This enables DB diagram usage
ALTER AUTHORIZATION ON DATABASE::[ClimbingGym] TO [sa]
GO

--Create all the table

-- [Climbing Gym]

CREATE TABLE [Gym]
(
 [Gym Id]             int IDENTITY (1, 1) NOT NULL ,
 [Name]               nvarchar(50) NOT NULL ,
 [Address1]           nvarchar(100) NOT NULL ,
 [Adress2]            nvarchar(50) NULL ,
 [Phone Number]       nvarchar(50) NOT NULL ,
 [Max Capacity]       int NOT NULL ,
 [Attendance Counter] int NOT NULL ,
 [Email]              nvarchar(50) NOT NULL ,
 [Day Price]          money NOT NULL ,


 CONSTRAINT [PK_Climbing Gym] PRIMARY KEY CLUSTERED ([Gym Id] ASC)
);
GO

-- ************************************** [Gym Type]
-- ************************************** [Person]
CREATE TABLE [Person]
(
 [UserId]       int IDENTITY (1, 1) NOT NULL ,
 [Gym Id]       int NOT NULL ,
 [Name]         nvarchar(50) NOT NULL ,
 [Address1]     nvarchar(50) NOT NULL ,
 [Address2]     nvarchar(50) NOT NULL ,
 [Phone Number] nvarchar(50) NULL ,
 [Email]        nvarchar(50) NULL ,
 [Member]       bit NOT NULL ,


 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([UserId] ASC),
 CONSTRAINT [FK_23] FOREIGN KEY ([Gym Id])  REFERENCES [Gym]([Gym Id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_23] ON [Person] 
 (
  [Gym Id] ASC
 )

GO

CREATE TABLE [Gym Type]
(
 [Gym Id]           int NOT NULL ,
 [Bouldering]       bit NOT NULL ,
 [Top Roping]       bit NOT NULL ,
 [Sport Climbing]   bit NOT NULL ,
 [Workout Area]     bit NOT NULL ,
 [Food]             bit NOT NULL ,
 [Interactive Wall] nvarchar(50) NULL ,


 CONSTRAINT [FK_41] FOREIGN KEY ([Gym Id])  REFERENCES [Gym]([Gym Id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_41] ON [Gym Type] 
 (
  [Gym Id] ASC
 )

GO

-- ************************************** [Membership]

CREATE TABLE [Membership]
(
 [Member Number] int NOT NULL ,
 [Gym Id]        int NOT NULL ,
 [Password]      nvarchar(50) NOT NULL ,
 [UserId]        int NOT NULL ,


 CONSTRAINT [PK_Membership] PRIMARY KEY CLUSTERED ([Member Number] ASC),
 CONSTRAINT [FK_53] FOREIGN KEY ([Gym Id])  REFERENCES [Gym]([Gym Id]),
 CONSTRAINT [FK_64] FOREIGN KEY ([UserId])  REFERENCES [Person]([UserId])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_53] ON [Membership] 
 (
  [Gym Id] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_64] ON [Membership] 
 (
  [UserId] ASC
 )

GO


-- ************************************** [User Login]

CREATE TABLE [User Login]
(
 [Username] uniqueidentifier NOT NULL ,
 [UserId]   int NOT NULL ,
 [Password] nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_User Login] PRIMARY KEY CLUSTERED ([Username] ASC),
 CONSTRAINT [FK_57] FOREIGN KEY ([UserId])  REFERENCES [Person]([UserId])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_57] ON [User Login] 
 (
  [UserId] ASC
 )

GO

--TEST DATA

--Gyms
Insert  Gym (Name, Address1, Adress2, [Phone Number], [Max Capacity], [Attendance Counter], Email, [Day Price])
	values ('Climb Cleveland', '2190 Professor Avenue Cleveland OH 44113', null,'2169064186', 30, 0, 'ClimbCleveland@gmail.com', 13.00)
Insert Gym (Name, Address1, Adress2, [Phone Number], [Max Capacity], [Attendance Counter], Email, [Day Price])
	values('Shaker Rocks', '3377 Warrensville Center Shaker Heights Rd OH 44122', null,'2168480460',75, 0, 'ShakerRocks@gmail.com', 26.00)

--Gym Types
INSERT [Gym Type] ([Gym Id], Bouldering, [Top Roping], [Sport Climbing], [Workout Area], Food, [Interactive Wall])
	values (1, 1, 0, 0, 1, 0, 'None')
INSERT [Gym Type] ([Gym Id], Bouldering, [Top Roping], [Sport Climbing], [Workout Area], Food, [Interactive Wall])
	values (2, 1, 1, 1, 1, 1, 'None')

--People
Insert Person ([Gym Id], Name, Address1, Address2, [Phone Number], Email, Member)
	Values (1, 'Shelley Cerny', '1548 Alameda Ave Lakewood OH 44107', 'Apartment 1', '4404402160', 'cerny.ricky@gmail.com', 0)
Insert Person ([Gym Id], Name, Address1, Address2, [Phone Number], Email, Member)
	Values (2, 'Ricky Cerny', '1548 Alameda Ave Lakewood OH 44107', 'Apartment 1', '1234567891', 'cerny.ricky@gmail.com', 0)


select * from Gym G
	join [Gym Type] as GT on g.[Gym Id] = GT.[Gym Id]

Select * from Person






























