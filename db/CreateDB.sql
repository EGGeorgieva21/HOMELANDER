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
	[IssuedDate] date,
	[ExpirationDate] date,
	[UserId] int FOREIGN KEY REFERENCES Users(Id) NOT NULL
);

CREATE TABLE [Skills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50) UNIQUE NOT NULL
);

CREATE TABLE [UserSkills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[UserId] int FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	[SkillId] int FOREIGN KEY REFERENCES Skills(Id) NOT NULL
);

CREATE TABLE [WorkExperiences] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Place] nvarchar(50) NOT NULL,
	[FromDate] date,
	[ToDate] date,
	[UserId] int FOREIGN KEY REFERENCES Users(Id) NOT NULL
);

CREATE TABLE [Education] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Place] nvarchar(50) NOT NULL,
	[FromDate] date,
	[ToDate] date,
	[UserId] int FOREIGN KEY REFERENCES Users(Id) NOT NULL
);

CREATE TABLE [EducationSkills] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[EducationId] int FOREIGN KEY REFERENCES Education(Id) NOT NULL,
	[SkillId] int FOREIGN KEY REFERENCES Skills(Id) NOT NULL
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
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[UserId] int FOREIGN KEY REFERENCES Users(Id)
);

CREATE TABLE [Resumes] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Summary] nvarchar(255),
	[UserId] int FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	[TemplateId] int FOREIGN KEY REFERENCES Templates(Id) NOT NULL
);

INSERT INTO [Skills]
VALUES
    ('Programming'),
    ('Database Management'),
    ('Web Development'),
    ('Data Analysis'),
    ('Project Management'),
    ('Machine Learning'),
    ('Graphic Design'),
    ('Network Administration'),
    ('Digital Marketing'),
    ('Content Writing'),
    ('UI/UX Design'),
    ('Mobile App Development'),
    ('Cloud Computing'),
    ('Business Intelligence'),
    ('Salesforce'),
    ('Video Editing'),
    ('Quality Assurance'),
    ('Cybersecurity'),
    ('Agile Methodology'),
    ('IT Support'),
    ('Public Speaking'),
    ('Social Media Management'),
    ('Copywriting'),
    ('Product Management'),
    ('Data Science');

INSERT INTO [Languages]
VALUES
    ('English'),
    ('Bulgarian'),
    ('Spanish'),
    ('French'),
    ('Chinese'),
    ('German'),
    ('Russian'),
    ('Japanese'),
    ('Arabic'),
    ('Portuguese'),
    ('Italian'),
    ('Dutch'),
    ('Korean'),
    ('Turkish'),
    ('Swedish'),
    ('Greek'),
    ('Hebrew'),
    ('Thai'),
    ('Vietnamese'),
    ('Hindi'),
    ('Indonesian'),
    ('Finnish'),
    ('Danish'),
    ('Norwegian'),
    ('Polish');