/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS(SELECT BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill')
BEGIN
	INSERT Buildings(BuildingName, AddressLine1, AddressLine2, AddressLine3,
		City, [State], ZipCode, PurchaseDate, PurchasePrice, SellDate, SellPrice,
		NumberOfUnits, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES('1 Haverhill', '1 Haverhill Street', NULL, NULL,
		'Lawrence', 'MA', '01841', '1/8/2013', 340000.00, NULL, NULL,
		8.0, GETDATE(), 1, GETDATE(), 1)
END
GO
IF NOT EXISTS(SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #1'
				AND BuildingId = (SELECT BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'))
BEGIN
	DECLARE @BuildingId int
	SELECT @BuildingId = BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'

	INSERT Units(UnitName, BuildingId, SquareFootage, NumberOfBedrooms, NumberOfBathrooms,
		CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES('1 Haverhill #1', @BuildingId, 900.0, 3.0, 1.0,
		GETDATE(), 1, GETDATE(), 1)
END
GO
IF NOT EXISTS(SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #2A'
				AND BuildingId = (SELECT BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'))
BEGIN
	DECLARE @BuildingId int
	SELECT @BuildingId = BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'

	INSERT Units(UnitName, BuildingId, SquareFootage, NumberOfBedrooms, NumberOfBathrooms,
		CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES('1 Haverhill #2A', @BuildingId, 450.0, 1.0, 1.0,
		GETDATE(), 1, GETDATE(), 1)
END
GO
IF NOT EXISTS(SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #2B'
				AND BuildingId = (SELECT BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'))
BEGIN
	DECLARE @BuildingId int
	SELECT @BuildingId = BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'

	INSERT Units(UnitName, BuildingId, SquareFootage, NumberOfBedrooms, NumberOfBathrooms,
		CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES('1 Haverhill #2B', @BuildingId, 450.0, 1.0, 1.0,
		GETDATE(), 1, GETDATE(), 1)
END
GO
IF NOT EXISTS(SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #3'
				AND BuildingId = (SELECT BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'))
BEGIN
	DECLARE @BuildingId int
	SELECT @BuildingId = BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'

	INSERT Units(UnitName, BuildingId, SquareFootage, NumberOfBedrooms, NumberOfBathrooms,
		CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES('1 Haverhill #3', @BuildingId, 900.0, 3.0, 1.0,
		GETDATE(), 1, GETDATE(), 1)
END
GO
IF NOT EXISTS(SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #4A'
				AND BuildingId = (SELECT BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'))
BEGIN
	DECLARE @BuildingId int
	SELECT @BuildingId = BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'

	INSERT Units(UnitName, BuildingId, SquareFootage, NumberOfBedrooms, NumberOfBathrooms,
		CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES('1 Haverhill #4A', @BuildingId, 450.0, 1.0, 1.0,
		GETDATE(), 1, GETDATE(), 1)
END
GO
IF NOT EXISTS(SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #4B'
				AND BuildingId = (SELECT BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'))
BEGIN
	DECLARE @BuildingId int
	SELECT @BuildingId = BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'

	INSERT Units(UnitName, BuildingId, SquareFootage, NumberOfBedrooms, NumberOfBathrooms,
		CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES('1 Haverhill #4B', @BuildingId, 450.0, 1.0, 1.0,
		GETDATE(), 1, GETDATE(), 1)
END
GO
IF NOT EXISTS(SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #5'
				AND BuildingId = (SELECT BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'))
BEGIN
	DECLARE @BuildingId int
	SELECT @BuildingId = BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'

	INSERT Units(UnitName, BuildingId, SquareFootage, NumberOfBedrooms, NumberOfBathrooms,
		CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES('1 Haverhill #5', @BuildingId, 900.0, 3.0, 1.0,
		GETDATE(), 1, GETDATE(), 1)
END
GO
IF NOT EXISTS(SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #6'
				AND BuildingId = (SELECT BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'))
BEGIN
	DECLARE @BuildingId int
	SELECT @BuildingId = BuildingId FROM Buildings WHERE BuildingName = '1 Haverhill'

	INSERT Units(UnitName, BuildingId, SquareFootage, NumberOfBedrooms, NumberOfBathrooms,
		CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES('1 Haverhill #6', @BuildingId, 900.0, 3.0, 1.0,
		GETDATE(), 1, GETDATE(), 1)
END
GO

IF NOT EXISTS(SELECT RentId FROM Rents WHERE UnitId = (SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #1'))
BEGIN
	DECLARE @UnitId int
	SELECT @UnitId = UnitId FROM Units WHERE UnitName = '1 Haverhill #1'

	INSERT Rents(UnitId, StartDate, EndDate, Amount, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES(@UnitId, GETDATE(), NULL, 1100.00, GETDATE(), 1, GETDATE(), 1)
END
GO

IF NOT EXISTS(SELECT RentId FROM Rents WHERE UnitId = (SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #2A'))
BEGIN
	DECLARE @UnitId int
	SELECT @UnitId = UnitId FROM Units WHERE UnitName = '1 Haverhill #2A'

	INSERT Rents(UnitId, StartDate, EndDate, Amount, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES(@UnitId, GETDATE(), NULL, 600.00, GETDATE(), 1, GETDATE(), 1)
END
GO

IF NOT EXISTS(SELECT RentId FROM Rents WHERE UnitId = (SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #2B'))
BEGIN
	DECLARE @UnitId int
	SELECT @UnitId = UnitId FROM Units WHERE UnitName = '1 Haverhill #2B'

	INSERT Rents(UnitId, StartDate, EndDate, Amount, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES(@UnitId, GETDATE(), NULL, 650.00, GETDATE(), 1, GETDATE(), 1)
END
GO

IF NOT EXISTS(SELECT RentId FROM Rents WHERE UnitId = (SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #3'))
BEGIN
	DECLARE @UnitId int
	SELECT @UnitId = UnitId FROM Units WHERE UnitName = '1 Haverhill #3'

	INSERT Rents(UnitId, StartDate, EndDate, Amount, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES(@UnitId, GETDATE(), NULL, 1200.00, GETDATE(), 1, GETDATE(), 1)
END
GO

IF NOT EXISTS(SELECT RentId FROM Rents WHERE UnitId = (SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #4A'))
BEGIN
	DECLARE @UnitId int
	SELECT @UnitId = UnitId FROM Units WHERE UnitName = '1 Haverhill #4A'

	INSERT Rents(UnitId, StartDate, EndDate, Amount, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES(@UnitId, GETDATE(), NULL, 650.00, GETDATE(), 1, GETDATE(), 1)
END
GO

IF NOT EXISTS(SELECT RentId FROM Rents WHERE UnitId = (SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #4B'))
BEGIN
	DECLARE @UnitId int
	SELECT @UnitId = UnitId FROM Units WHERE UnitName = '1 Haverhill #4B'

	INSERT Rents(UnitId, StartDate, EndDate, Amount, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES(@UnitId, GETDATE(), NULL, 650.00, GETDATE(), 1, GETDATE(), 1)
END
GO

IF NOT EXISTS(SELECT RentId FROM Rents WHERE UnitId = (SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #5'))
BEGIN
	DECLARE @UnitId int
	SELECT @UnitId = UnitId FROM Units WHERE UnitName = '1 Haverhill #5'

	INSERT Rents(UnitId, StartDate, EndDate, Amount, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES(@UnitId, GETDATE(), NULL, 825.00, GETDATE(), 1, GETDATE(), 1)
END
GO

IF NOT EXISTS(SELECT RentId FROM Rents WHERE UnitId = (SELECT UnitId FROM Units WHERE UnitName = '1 Haverhill #6'))
BEGIN
	DECLARE @UnitId int
	SELECT @UnitId = UnitId FROM Units WHERE UnitName = '1 Haverhill #6'

	INSERT Rents(UnitId, StartDate, EndDate, Amount, CreatedOn, CreatedBy, LastUpdatedOn, LastUpdatedBy)
	VALUES(@UnitId, GETDATE(), NULL, 800.00, GETDATE(), 1, GETDATE(), 1)
END
GO

