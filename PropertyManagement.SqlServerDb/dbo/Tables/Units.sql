CREATE TABLE [dbo].[Units] (
    [UnitId]            INT            IDENTITY (1, 1) NOT NULL,
    [UnitName]          VARCHAR (50)   NOT NULL,
    [BuildingId]        INT            NOT NULL,
    [SquareFootage]     DECIMAL (6, 1) NOT NULL,
    [NumberOfBedrooms]  DECIMAL (3, 1) NOT NULL,
    [NumberOfBathrooms] DECIMAL (3, 1) NOT NULL,
    [CreatedOn]         DATETIME       NOT NULL,
    [CreatedBy]         INT            NOT NULL,
    [LastUpdatedOn]     DATETIME       NOT NULL,
    [LastUpdatedBy]     INT            NOT NULL,
    [Ts]                ROWVERSION     NOT NULL,
    CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED ([UnitId] ASC),
    CONSTRAINT [FK_Units_Buildings] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Buildings] ([BuildingId])
);



