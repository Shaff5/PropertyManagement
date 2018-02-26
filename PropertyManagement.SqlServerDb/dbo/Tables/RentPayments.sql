CREATE TABLE [dbo].[RentPayments] (
    [RentPaymentId] INT             IDENTITY (1, 1) NOT NULL,
    [UnitId]        INT             NOT NULL,
    [TenantId]      INT             NOT NULL,
    [Amount]        DECIMAL (10, 2) NOT NULL,
    [StartDate]     DATETIME        NOT NULL,
    [EndDate]       DATETIME        NOT NULL,
    [CreatedOn]     DATETIME        NOT NULL,
    [CreatedBy]     INT             NOT NULL,
    [LastUpdatedOn] DATETIME        NOT NULL,
    [LastUpdatedBy] INT             NOT NULL,
    [Ts]            ROWVERSION      NOT NULL,
    CONSTRAINT [PK_RentPayments] PRIMARY KEY CLUSTERED ([RentPaymentId] ASC),
    CONSTRAINT [FK_RentPayments_Units] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Units] ([UnitId])
);

