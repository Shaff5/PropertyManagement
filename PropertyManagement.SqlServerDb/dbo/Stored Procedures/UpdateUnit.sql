-- =============================================
-- Author:		Sean Shaffer
-- Create date: 9/5/2014
-- Description:	Update a Unit record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUnit] 
	@UnitId int,
	@UnitName varchar(50),
	@BuildingId int, 
	@SquareFootage decimal(6, 1),
	@NumberOfBedrooms decimal(3, 1),
	@NumberOfBathrooms decimal(3, 1),
	@CreatedOn datetime,
	@CreatedBy int,
	@LastUpdatedOn datetime,
	@LastUpdatedBy int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE dbo.Units
		SET UnitName = @UnitName,
			BuildingId = @BuildingId,
			SquareFootage = @SquareFootage,
			NumberOfBedrooms = @NumberOfBedrooms,
			NumberOfBathrooms = @NumberOfBathrooms,
			CreatedOn = @CreatedOn,
			CreatedBy = @CreatedBy,
			LastUpdatedOn = @LastUpdatedOn,
			LastUpdatedBy = @LastUpdatedBy
	WHERE UnitId = @UnitId

END