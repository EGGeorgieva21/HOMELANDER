CREATE DATABASE ResumeBuilder
GO

USE ResumeBuilder

CREATE TABLE [Users] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Username] varchar(50) NOT NULL,
	[Password] varchar(64) NOT NULL,
	[Email] varchar(50) NOT NULL,
	[FullName] nvarchar(50),
	[Phone] varchar(50),
	[Location] nvarchar(50)
); 

CREATE TABLE [Languages](
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Language] varchar(50) NOT NULL
);

CREATE TABLE [UserLanguages](
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[UserId] int FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	[LanguageId] int FOREIGN KEY REFERENCES Languages(Id) NOT NULL,
	[AdvanceLevel] varchar(50)
);

CREATE TABLE [Skills](
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Skill] varchar(50)
);

CREATE TABLE [WorkExperiences](
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Place] nvarchar(50) NOT NULL,
	[FromDate] date NOT NULL,
	[ToDate] date
);

CREATE TABLE [Education](
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Place] nvarchar(50) NOT NULL,
	[FromDate] date NOT NULL,
	[ToDate] date
);

CREATE TABLE [EducationSkills](
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[EducationId] int FOREIGN KEY REFERENCES Education(Id) NOT NULL,
	[SkillId] int FOREIGN KEY REFERENCES Skills(Id) NOT NULL
);

CREATE TABLE [Certificates](
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50),
	[IssuedDate] date NOT NULL,
	[ExpirationDate] date
);

CREATE TABLE [Templates](
	[Id] int PRIMARY KEY IDENTITY(1,1)
);

CREATE TABLE [Resumes] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[UserId] int FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	[TemplateId] int FOREIGN KEY REFERENCES Templates(Id) NOT NULL
);