CREATE TABLE [dbo].[Buildings] (
    [BuildingId]    INT             IDENTITY (1, 1) NOT NULL,
    [BuildingName]  VARCHAR (75)    NOT NULL,
    [AddressLine1]  VARCHAR (50)    NOT NULL,
    [AddressLine2]  VARCHAR (50)    NULL,
    [AddressLine3]  VARCHAR (50)    NULL,
    [City]          VARCHAR (50)    NOT NULL,
    [State]         CHAR (2)        NOT NULL,
    [ZipCode]       VARCHAR (10)    NOT NULL,
    [PurchaseDate]  DATETIME        NOT NULL,
    [PurchasePrice] DECIMAL (11, 2) NOT NULL,
    [SellDate]      DATETIME        NULL,
    [SellPrice]     DECIMAL (11, 2) NULL,
    [NumberOfUnits] DECIMAL (6, 1)  NOT NULL,
    [CreatedOn]     DATETIME        NOT NULL,
    [CreatedBy]     INT             NOT NULL,
    [LastUpdatedOn] DATETIME        NOT NULL,
    [LastUpdatedBy] INT             NOT NULL,
    [Ts]            ROWVERSION      NOT NULL,
    CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED ([BuildingId] ASC)
);










GO



-- =============================================
-- Author:		Sean Shaffer
-- Create date: 9/11/14
-- Description:	Audit trigger - insert
-- =============================================
CREATE TRIGGER [dbo].[InsertBuildingTrigger] 
   ON  [dbo].[Buildings] 
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @OutputTable TABLE (HistoryHeaderId bigint, RecordId int)

    INSERT dbo.HistoryHeader (TableName, RecordId, [Action], ModifiedBy, ModifiedOn)
	OUTPUT INSERTED.HistoryHeaderId, INSERTED.RecordId INTO @OutputTable
	SELECT DISTINCT 'Buildings', ins.BuildingId, 'INSERT', ins.CreatedBy, ins.CreatedOn FROM INSERTED ins
	
	INSERT dbo.HistoryDetail (HistoryHeaderId, ColumnName, OldValue, NewValue)
	SELECT DISTINCT o.HistoryHeaderId, 'BuildingName', NULL, ins.BuildingName
	FROM INSERTED ins
	INNER JOIN @OutputTable o ON o.RecordId = ins.BuildingId    

END