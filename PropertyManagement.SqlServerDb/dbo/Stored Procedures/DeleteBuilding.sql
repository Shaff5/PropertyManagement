-- =============================================
-- Author:		Sean Shaffer
-- Create date: 9/5/2014
-- Description:	Delete a Building record
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBuilding] 
	@BuildingId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE dbo.Buildings WHERE BuildingId = @BuildingId

END