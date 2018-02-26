CREATE TABLE [dbo].[Vendors] (
    [VendorId]   INT          IDENTITY (1, 1) NOT NULL,
    [VendorName] VARCHAR (75) NOT NULL,
    CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([VendorId] ASC)
);

