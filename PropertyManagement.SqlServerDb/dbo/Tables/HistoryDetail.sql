CREATE TABLE [dbo].[HistoryDetail] (
    [HistoryDetailId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [HistoryHeaderId] BIGINT        NOT NULL,
    [ColumnName]      VARCHAR (100) NOT NULL,
    [OldValue]        VARCHAR (MAX) NULL,
    [NewValue]        VARCHAR (MAX) NULL,
    CONSTRAINT [PK_HistoryDetail] PRIMARY KEY CLUSTERED ([HistoryDetailId] ASC),
    CONSTRAINT [FK_HistoryDetail_HistoryHeader] FOREIGN KEY ([HistoryHeaderId]) REFERENCES [dbo].[HistoryHeader] ([HistoryHeaderId])
);



