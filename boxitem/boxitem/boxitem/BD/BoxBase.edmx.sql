
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/24/2018 11:25:55
-- Generated from EDMX file: F:\kopia_d\studia_sem6\pum_projekt_poprawki\boxitem\boxitem\boxitem\BoxBase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BoxesDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsersBoxes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Boxes] DROP CONSTRAINT [FK_UsersBoxes];
GO
IF OBJECT_ID(N'[dbo].[FK_BoxesItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Items] DROP CONSTRAINT [FK_BoxesItems];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Boxes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Boxes];
GO
IF OBJECT_ID(N'[dbo].[Items]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Items];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Boxes'
CREATE TABLE [dbo].[Boxes] (
    [Name] nvarchar(50)  NOT NULL,
    [Number] int  NULL,
    [Description] varchar(max)  NULL,
    [BoxID] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Picture] varbinary(max)  NULL,
    [Users_UserId] int  NOT NULL,
    [Users_Login] nchar(10)  NOT NULL,
    [Users_Name] nchar(10)  NOT NULL,
    [Users_Surname] nchar(10)  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [Name] nvarchar(50)  NOT NULL,
    [Number] int  NULL,
    [Description] varchar(max)  NULL,
    [ItemId] int  NOT NULL,
    [BoxId] int  NOT NULL,
    [Picture] varbinary(max)  NULL,
    [Boxes_Name] nvarchar(50)  NOT NULL,
    [Boxes_BoxID] int  NOT NULL,
    [Boxes_UserId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int  NOT NULL,
    [Login] nchar(10)  NOT NULL,
    [Password] nchar(20)  NOT NULL,
    [Name] nchar(10)  NOT NULL,
    [Surname] nchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Name], [BoxID], [UserId] in table 'Boxes'
ALTER TABLE [dbo].[Boxes]
ADD CONSTRAINT [PK_Boxes]
    PRIMARY KEY CLUSTERED ([Name], [BoxID], [UserId] ASC);
GO

-- Creating primary key on [Name], [ItemId], [BoxId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([Name], [ItemId], [BoxId] ASC);
GO

-- Creating primary key on [UserId], [Login], [Name], [Surname] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId], [Login], [Name], [Surname] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Users_UserId], [Users_Login], [Users_Name], [Users_Surname] in table 'Boxes'
ALTER TABLE [dbo].[Boxes]
ADD CONSTRAINT [FK_UsersBoxes]
    FOREIGN KEY ([Users_UserId], [Users_Login], [Users_Name], [Users_Surname])
    REFERENCES [dbo].[Users]
        ([UserId], [Login], [Name], [Surname])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersBoxes'
CREATE INDEX [IX_FK_UsersBoxes]
ON [dbo].[Boxes]
    ([Users_UserId], [Users_Login], [Users_Name], [Users_Surname]);
GO

-- Creating foreign key on [Boxes_Name], [Boxes_BoxID], [Boxes_UserId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_BoxesItems]
    FOREIGN KEY ([Boxes_Name], [Boxes_BoxID], [Boxes_UserId])
    REFERENCES [dbo].[Boxes]
        ([Name], [BoxID], [UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BoxesItems'
CREATE INDEX [IX_FK_BoxesItems]
ON [dbo].[Items]
    ([Boxes_Name], [Boxes_BoxID], [Boxes_UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------