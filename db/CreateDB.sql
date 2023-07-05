CREATE DATABASE CVBuilder
GO

USE CVBuilder

CREATE TABLE [Users] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[Username] varchar(50),
	[Password] varchar(50),
	[Email] varchar(50)
);

CREATE TABLE [CV] (
	[Id] int PRIMARY KEY IDENTITY(1,1),
	[UserId] int FOREIGN KEY REFERENCES Users(Id)
);