-- =============================================
-- Author:		Sean Shaffer
-- Create date: 9/5/2014
-- Description:	Insert a Rent record
-- =============================================
CREATE PROCEDURE [dbo].[InsertRent] 
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

    INSERT INTO dbo.Rents (UnitId, StartDate, EndDate, Amount, CreatedOn, CreatedBy,
		LastUpdatedOn, LastUpdatedBy)
	VALUES (@UnitId, @StartDate, @EndDate, @Amount, @CreatedOn, @CreatedBy,
		@LastUpdatedOn, @LastUpdatedBy)

	SELECT SCOPE_IDENTITY() AS RentId WHERE @@ROWCOUNT > 0

END