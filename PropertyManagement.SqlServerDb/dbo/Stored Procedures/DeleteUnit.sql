-- =============================================
-- Author:		Sean Shaffer
-- Create date: 9/5/2014
-- Description:	Delete a Unit record
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnit] 
	@UnitId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE dbo.Units WHERE UnitId = @UnitId
	
END