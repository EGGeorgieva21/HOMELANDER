CREATE DATABASE ResumeBuilder
GO

USE ResumeBuilder

CREATE TABLE [Users] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Username] varchar(50) UNIQUE NOT NULL,
	[Password] varchar(64) NOT NULL,
	[Salt] varchar(50) NOT NULL,
	[Email] varchar(50) NOT NULL,
	[FullName] nvarchar(50),
	[Phone] varchar(50),
	[Location] nvarchar(50)
);

CREATE TABLE [Certificates] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL,
	[IssuedDate] date NOT NULL,
	[ExpirationDate] date,
	[UserId] int FOREIGN KEY REFERENCES Users(Id)
);

CREATE TABLE [Skills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) UNIQUE NOT NULL
);

CREATE TABLE [UserSkills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[UserId] int FOREIGN KEY REFERENCES Users(Id),
	[SkillId] int FOREIGN KEY REFERENCES Skills(Id)
);

CREATE TABLE [WorkExperiences] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Place] nvarchar(50) NOT NULL,
	[FromDate] date,
	[ToDate] date,
	[UserId] int FOREIGN KEY REFERENCES Users(Id)
);

CREATE TABLE [Education] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Place] nvarchar(50) NOT NULL,
	[FromDate] date,
	[ToDate] date,
	[UserId] int FOREIGN KEY REFERENCES Users(Id)
);

CREATE TABLE [EducationSkills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[EducationId] int FOREIGN KEY REFERENCES Education(Id),
	[SkillId] int FOREIGN KEY REFERENCES Skills(Id)
);

CREATE TABLE [Languages] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) UNIQUE NOT NULL
);

CREATE TABLE [UserLanguages] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[UserId] int FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	[LanguageId] int FOREIGN KEY REFERENCES Languages(Id) NOT NULL,
	[AdvanceLevel] varchar(50)
);

CREATE TABLE [Templates] (
	[Id] int PRIMARY KEY IDENTITY(1,1)
);

CREATE TABLE [Resume] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[UserId] int FOREIGN KEY REFERENCES Users(Id),
	[TemplateId] int FOREIGN KEY REFERENCES Templates(Id)
);