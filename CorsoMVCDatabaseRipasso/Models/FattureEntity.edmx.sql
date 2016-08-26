
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/25/2016 09:52:48
-- Generated from EDMX file: c:\users\dnc\documents\visual studio 2015\Projects\CorsoMVCDatabaseRipasso\CorsoMVCDatabaseRipasso\Models\FattureEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Fatture];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VendorSet'
CREATE TABLE [dbo].[VendorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [PIVA] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Invoice_T'
CREATE TABLE [dbo].[Invoice_T] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [VendorId] int  NOT NULL
);
GO

-- Creating table 'Invoice_P'
CREATE TABLE [dbo].[Invoice_P] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Material] nvarchar(max)  NOT NULL,
    [Quantity] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [UMA] nvarchar(max)  NOT NULL,
    [Invoice_TId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'VendorSet'
ALTER TABLE [dbo].[VendorSet]
ADD CONSTRAINT [PK_VendorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Invoice_T'
ALTER TABLE [dbo].[Invoice_T]
ADD CONSTRAINT [PK_Invoice_T]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Invoice_P'
ALTER TABLE [dbo].[Invoice_P]
ADD CONSTRAINT [PK_Invoice_P]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VendorId] in table 'Invoice_T'
ALTER TABLE [dbo].[Invoice_T]
ADD CONSTRAINT [FK_Vendor_Invoice_T]
    FOREIGN KEY ([VendorId])
    REFERENCES [dbo].[VendorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vendor_Invoice_T'
CREATE INDEX [IX_FK_Vendor_Invoice_T]
ON [dbo].[Invoice_T]
    ([VendorId]);
GO

-- Creating foreign key on [Invoice_TId] in table 'Invoice_P'
ALTER TABLE [dbo].[Invoice_P]
ADD CONSTRAINT [FK_Invoice_T_Invoice_P]
    FOREIGN KEY ([Invoice_TId])
    REFERENCES [dbo].[Invoice_T]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Invoice_T_Invoice_P'
CREATE INDEX [IX_FK_Invoice_T_Invoice_P]
ON [dbo].[Invoice_P]
    ([Invoice_TId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------