-- =============================================
-- Author:		Sean Shaffer
-- Create date: 9/5/2014
-- Description:	Update a Building record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBuilding] 
	@BuildingId int,
	@BuildingName varchar(75),
	@AddressLine1 varchar(50),
	@AddressLine2 varchar(50),
	@AddressLine3 varchar(50),
	@City varchar(50),
	@State char(2),
	@ZipCode varchar(10),
	@PurchaseDate datetime,
	@PurchasePrice decimal(11, 2),
	@SellDate datetime,
	@SellPrice decimal(11, 2),
	@NumberOfUnits decimal(6, 1),
	@CreatedOn datetime,
	@CreatedBy int,
	@LastUpdatedOn datetime,
	@LastUpdatedBy int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE dbo.Buildings
		SET BuildingName = @BuildingName,
			AddressLine1 = @AddressLine1,
			AddressLine2 = @AddressLine2,
			AddressLine3 = @AddressLine3,
			City = @City,
			[State] = @State,
			ZipCode = @ZipCode,
			PurchaseDate = @PurchaseDate,
			PurchasePrice = @PurchasePrice,
			SellDate = @SellDate,
			SellPrice = @SellPrice,
			NumberOfUnits = @NumberOfUnits,
			CreatedOn = @CreatedOn,
			CreatedBy = @CreatedBy,
			LastUpdatedOn = @LastUpdatedOn,
			LastUpdatedBy = @LastUpdatedBy
	 WHERE BuildingId = @BuildingId

END