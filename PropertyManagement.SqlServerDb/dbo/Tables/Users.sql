CREATE TABLE [dbo].[Users] (
    [UserId]        INT          IDENTITY (1, 1) NOT NULL,
    [CreatedOn]     DATETIME     NOT NULL,
    [CreatedBy]     INT          NOT NULL,
    [LastUpdatedOn] DATETIME     NOT NULL,
    [LastUpdatedBy] INT          NOT NULL,
    [Ts]            ROWVERSION   NOT NULL,
    [IsDeleted]     BIT          NOT NULL,
    [UserName]      VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

