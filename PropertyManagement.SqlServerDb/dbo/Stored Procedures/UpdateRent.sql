-- =============================================
-- Author:		Sean Shaffer
-- Create date: 9/5/2014
-- Description:	Update a Rent record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateRent] 
	@RentId int,
	@UnitId int,
	@StartDate datetime, 
	@EndDate datetime,
	@Amount decimal(10, 2),
	@CreatedOn datetime,
	@CreatedBy int,
	@LastUpdatedOn datetime,
	@LastUpdatedBy int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE dbo.Rents
		SET UnitId = @UnitId,
			StartDate = @StartDate,
			EndDate = @EndDate,
			Amount = @Amount,
			CreatedOn = @CreatedOn,
			CreatedBy = @CreatedBy,
			LastUpdatedOn = @LastUpdatedOn,
			LastUpdatedBy = @LastUpdatedBy
	WHERE RentId = @RentId

END