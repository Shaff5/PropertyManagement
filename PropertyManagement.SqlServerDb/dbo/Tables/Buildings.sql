CREATE TABLE [dbo].[Buildings] (
    [BuildingId]    INT             IDENTITY (1, 1) NOT NULL,
    [CreatedOn]     DATETIME        NOT NULL,
    [CreatedBy]     INT             NOT NULL,
    [LastUpdatedOn] DATETIME        NOT NULL,
    [LastUpdatedBy] INT             NOT NULL,
    [Ts]            ROWVERSION      NOT NULL,
    [IsDeleted]     BIT             NOT NULL,
    [BuildingName]  VARCHAR (75)    NOT NULL,
    [AddressLine1]  VARCHAR (50)    NOT NULL,
    [AddressLine2]  VARCHAR (50)    NULL,
    [AddressLine3]  VARCHAR (50)    NULL,
    [City]          VARCHAR (50)    NOT NULL,
    [State]         CHAR (2)        NOT NULL,
    [ZipCode]       VARCHAR (10)    NOT NULL,
    [PurchaseDate]  DATETIME        NOT NULL,
    [PurchasePrice] DECIMAL (11, 2) NOT NULL,
    [SellDate]      DATETIME        NULL,
    [SellPrice]     DECIMAL (11, 2) NULL,
    [NumberOfUnits] DECIMAL (6, 1)  NOT NULL,
    CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED ([BuildingId] ASC),
    CONSTRAINT [FK_BuildingsCreatedBy_Users] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_BuildingsLastUpdatedBy_Users] FOREIGN KEY ([LastUpdatedBy]) REFERENCES [dbo].[Users] ([UserId])
);












GO
