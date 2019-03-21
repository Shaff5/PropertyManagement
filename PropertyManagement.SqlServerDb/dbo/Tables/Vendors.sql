CREATE TABLE [dbo].[Vendors] (
    [VendorId]      INT          IDENTITY (1, 1) NOT NULL,
    [CreatedOn]     DATETIME     NOT NULL,
    [CreatedBy]     INT          NOT NULL,
    [LastUpdatedOn] DATETIME     NOT NULL,
    [LastUpdatedBy] INT          NOT NULL,
    [Ts]            ROWVERSION   NOT NULL,
    [IsDeleted]     BIT          NOT NULL,
    [VendorName]    VARCHAR (75) NOT NULL,
    CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([VendorId] ASC)
);



