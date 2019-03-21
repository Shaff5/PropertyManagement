CREATE TABLE [dbo].[Contacts] (
    [ContactId]     INT          IDENTITY (1, 1) NOT NULL,
    [CreatedOn]     DATETIME     NOT NULL,
    [CreatedBy]     INT          NOT NULL,
    [LastUpdatedOn] DATETIME     NOT NULL,
    [LastUpdatedBy] INT          NOT NULL,
    [Ts]            ROWVERSION   NOT NULL,
    [IsDeleted]     BIT          NOT NULL,
    [FirstName]     VARCHAR (50) NOT NULL,
    [LastName]      VARCHAR (50) NOT NULL,
    [MiddleName]    VARCHAR (50) NULL,
    [Phone1]        CHAR (10)    NULL,
    [Phone1Type]    TINYINT      NULL,
    [Phone2]        CHAR (10)    NULL,
    [Phone2Type]    TINYINT      NULL,
    [Phone3]        CHAR (10)    NULL,
    [Phone3Type]    TINYINT      NULL,
    [Email1]        VARCHAR (50) NULL,
    [Email1Type]    TINYINT      NULL,
    [Email2]        VARCHAR (50) NULL,
    [Email2Type]    TINYINT      NULL,
    [Email3]        VARCHAR (50) NULL,
    [Email3Type]    TINYINT      NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED ([ContactId] ASC)
);



