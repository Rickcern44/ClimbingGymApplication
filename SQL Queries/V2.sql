--Make sure we are not using some other DB 
use master
go 

--Get back to where we were drop db if it exists
drop database if exists ClimbingGym

--Create the new art gallery DB
create database ClimbingGym
go



use ClimbingGym
GO

Alter Authorization on database :: [ArtGallery] to [sa]
-- ************************************** [Gym]--
CREATE TABLE Gym
(
 GymId       int IDENTITY (1, 1) NOT NULL ,
 Name        nvarchar(50) NOT NULL ,
 Address     nvarchar(100) NOT NULL ,
 PhoneNumber nvarchar(50) NOT NULL ,
 Email       nvarchar(50) NOT NULL ,
 MaxCapacity int NOT NULL ,


 CONSTRAINT [PK_Gym] PRIMARY KEY CLUSTERED ([GymId] ASC)
);
GO

-- ************************************** [Login]

CREATE TABLE [Login]
(
 [LoginId]   int IDENTITY (1, 1) NOT NULL ,
 [UserName]  nvarchar(50) NOT NULL ,
 [Password]  nvarchar(50) NOT NULL ,
 [Salt]      nvarchar(50) NOT NULL ,
 [Role]      NVARCHAR(50) NOT NULL,


 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([LoginId] ASC)
);
GO

-- ************************************** [Person]

CREATE TABLE Person
(
 Id          int IDENTITY (1, 1) NOT NULL ,
 FirstName   nvarchar(50) NOT NULL ,
 LastName    nvarchar(50) NOT NULL ,
 Address     nvarchar(50) NOT NULL ,
 PhoneNumber nvarchar(50) NOT NULL ,
 Email       nvarchar(50) NOT NULL ,
 LoginId     int NOT NULL ,


 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_85] FOREIGN KEY ([LoginId])  REFERENCES [Login]([LoginId])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_85] ON [Person] 
 (
  LoginId ASC
 )

GO

-- ************************************** [Memberships]

CREATE TABLE [Memberships]
(
 MemberId    int IDENTITY (1, 1) NOT NULL ,
 GymId       int NOT NULL ,
 MemberSince datetime NOT NULL ,
 PersonId    int NOT NULL ,


 CONSTRAINT [PK_Memberships] PRIMARY KEY CLUSTERED ([MemberId] ASC),
 CONSTRAINT [FK_105] FOREIGN KEY (PersonId)  REFERENCES [Person](Id),
 CONSTRAINT [FK_91] FOREIGN KEY (GymId)  REFERENCES [Gym](GymId)
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_105] ON [Memberships] 
 (
  PersonId ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_91] ON [Memberships] 
 (
  GymId ASC
 )

GO
-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [GymType]

CREATE TABLE [GymType]
(
 [GymId]            int NOT NULL ,
 [Bouldering]       bit NOT NULL ,
 [TopRoping]        bit NOT NULL ,
 [SportClimbing]    bit NOT NULL ,
 [WorkoutArea]      bit NOT NULL ,
 [FoodArea]         bit NOT NULL ,
 [InteractiveBoard] nvarchar(50) NULL ,


 CONSTRAINT [FK_19] FOREIGN KEY ([GymId])  REFERENCES [Gym]([GymId])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_19] ON [GymType] 
 (
  [GymId] ASC
 )

GO

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [Pricing]

CREATE TABLE [Pricing]
(
 [GymId]   int NOT NULL ,
 [DayPass] money NOT NULL ,
 [Monthly] money NULL ,
 [Yearly]  money NULL ,


 CONSTRAINT [FK_12] FOREIGN KEY ([GymId])  REFERENCES [Gym]([GymId])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_12] ON [Pricing] 
 (
  [GymId] ASC
 )

GO


--TEST DATA

--Gyms
INSERT Gym (Name, Address, PhoneNumber, Email, MaxCapacity)
    VALUES ('Shaker Rocks', '3377 Warrensville Center Shaker Heights Rd OH 44122', '2168480460', 'ShakerRocks@gmail.com' , 75)
INSERT Gym (Name, Address, PhoneNumber, Email, MaxCapacity)
    VALUES ('Climb Clevaland', '2190 Professor Avenue Cleveland OH 44113', '2169064186', 'ClimbCleveland@gmail.com' , 45)
Insert Gym (Name, Address, PhoneNumber, Email, MaxCapacity)
    VALUES ('Nosotros Lakewood', '14321 Detroit Avenue Lakewood OH 44107', '2165121841', 'NosotrosClim@gmail.com' , 30)

--Gym Types
INSERT GymType (GymId, Bouldering, TopRoping, SportClimbing, WorkoutArea, FoodArea, InteractiveBoard)
    VALUES (1, 1, 1, 1, 1, 1, 'None')
INSERT GymType (GymId, Bouldering, TopRoping, SportClimbing, WorkoutArea, FoodArea, InteractiveBoard)
    VALUES (2, 1, 0, 0, 1, 0, 'None')
INSERT GymType (GymId, Bouldering, TopRoping, SportClimbing, WorkoutArea, FoodArea, InteractiveBoard)
    VALUES (3, 1, 0, 0, 1, 0, 'None')

--Pricing
INSERT Pricing (GymId, DayPass, Monthly, Yearly)
    VALUES(1, 26.00, 90.00, 800.00)
INSERT Pricing (GymId, DayPass, Monthly, Yearly)
    VALUES(2, 13.00, 45.00, 550.00)
INSERT Pricing (GymId, DayPass, Monthly, Yearly)
    VALUES(3, 14.00, null, 430.34)

--Why wont role work?

select * from Gym g
    join GymType gt on g.GymId = gt.GymId
    join Pricing p on p.GymId = g.GymId











































