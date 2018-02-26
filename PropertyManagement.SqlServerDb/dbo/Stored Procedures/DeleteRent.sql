-- =============================================
-- Author:		Sean Shaffer
-- Create date: 9/5/2014
-- Description:	Delete a Rent record
-- =============================================
CREATE PROCEDURE [dbo].[DeleteRent] 
	@RentId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE dbo.Rents WHERE RentId = @RentId
	
END