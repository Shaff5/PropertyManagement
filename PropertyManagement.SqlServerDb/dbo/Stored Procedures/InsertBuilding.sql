-- =============================================
-- Author:		Sean Shaffer
-- Create date: 4/14/2014
-- Description:	Insert a Building record
-- =============================================
CREATE PROCEDURE [dbo].[InsertBuilding] 
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

    INSERT INTO dbo.Buildings (BuildingName, AddressLine1, AddressLine2, AddressLine3,
		City, [State], ZipCode, PurchaseDate, PurchasePrice, SellDate, SellPrice,
		NumberOfUnits, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES (@BuildingName, @AddressLine1, @AddressLine2, @AddressLine3,
		@City, @State, @ZipCode, @PurchaseDate, @PurchasePrice, @SellDate, @SellPrice,
		@NumberOfUnits, @CreatedOn, @CreatedBy, @LastUpdatedOn, @LastUpdatedBy)

	SELECT SCOPE_IDENTITY() AS BuildingId WHERE @@ROWCOUNT > 0

END