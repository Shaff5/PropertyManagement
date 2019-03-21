CREATE TABLE [dbo].[Rents] (
    [RentId]        INT             IDENTITY (1, 1) NOT NULL,
    [CreatedOn]     DATETIME        NOT NULL,
    [CreatedBy]     INT             NOT NULL,
    [LastUpdatedOn] DATETIME        NOT NULL,
    [LastUpdatedBy] INT             NOT NULL,
    [Ts]            ROWVERSION      NOT NULL,
    [IsDeleted]     BIT             NOT NULL,
    [UnitId]        INT             NOT NULL,
    [StartDate]     DATETIME        NOT NULL,
    [EndDate]       DATETIME        NULL,
    [Amount]        DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_Rents] PRIMARY KEY CLUSTERED ([RentId] ASC),
    CONSTRAINT [FK_Rents_Units] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Units] ([UnitId])
);



