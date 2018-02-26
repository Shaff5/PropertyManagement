CREATE TABLE [dbo].[HistoryHeader] (
    [HistoryHeaderId] BIGINT       IDENTITY (1, 1) NOT NULL,
    [TableName]       VARCHAR (50) NOT NULL,
    [RecordId]        INT          NOT NULL,
    [Action]          VARCHAR (10) NOT NULL,
    [ModifiedBy]      INT          NOT NULL,
    [ModifiedOn]      DATETIME     NOT NULL,
    CONSTRAINT [PK_HistoryHeader] PRIMARY KEY CLUSTERED ([HistoryHeaderId] ASC)
);



