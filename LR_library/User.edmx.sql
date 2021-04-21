
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/21/2021 22:21:07
-- Generated from EDMX file: D:\КАИ\2 курс\ОАиП\лабы\2 семестр\5\LR_library\LR_library\User.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [D:\КАИ\2 КУРС\ОАИП\ЛАБЫ\2 СЕМЕСТР\5\DATABASE\LR_DB.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserCode_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserCodeSet] DROP CONSTRAINT [FK_UserCode_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[UserCodeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserCodeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Login] nvarchar(255)  NOT NULL,
    [Email] nvarchar(255)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserCodeSet'
CREATE TABLE [dbo].[UserCodeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(10)  NOT NULL,
    [Timestamp] datetime  NOT NULL,
    [User_Id] int  NOT NULL,
    [User_Email] nvarchar(255)  NOT NULL,
    [User_Login] nvarchar(255)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id], [Email], [Login] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id], [Email], [Login] ASC);
GO

-- Creating primary key on [Id] in table 'UserCodeSet'
ALTER TABLE [dbo].[UserCodeSet]
ADD CONSTRAINT [PK_UserCodeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id], [User_Email], [User_Login] in table 'UserCodeSet'
ALTER TABLE [dbo].[UserCodeSet]
ADD CONSTRAINT [FK_UserCode_User]
    FOREIGN KEY ([User_Id], [User_Email], [User_Login])
    REFERENCES [dbo].[UserSet]
        ([Id], [Email], [Login])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCode_User'
CREATE INDEX [IX_FK_UserCode_User]
ON [dbo].[UserCodeSet]
    ([User_Id], [User_Email], [User_Login]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------