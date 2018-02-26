CREATE TABLE [dbo].[PhoneTypes] (
    [Id]          TINYINT      IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (25) NOT NULL,
    CONSTRAINT [PK_PhoneTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);



