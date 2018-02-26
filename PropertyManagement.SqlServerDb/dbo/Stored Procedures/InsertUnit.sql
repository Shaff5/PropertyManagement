-- =============================================
-- Author:		Sean Shaffer
-- Create date: 9/5/2014
-- Description:	Insert a Unit record
-- =============================================
CREATE PROCEDURE [dbo].[InsertUnit] 
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

    INSERT INTO dbo.Units (UnitName, BuildingId, SquareFootage, NumberOfBedrooms,
		NumberOfBathrooms, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES (@UnitName, @BuildingId, @SquareFootage, @NumberOfBedrooms,
		@NumberOfBathrooms, @CreatedOn, @CreatedBy, @LastUpdatedOn, @LastUpdatedBy)

	SELECT SCOPE_IDENTITY() AS UnitId WHERE @@ROWCOUNT > 0

END