CREATE PROCEDURE Create_Category
	@CategoryName nvarchar(50)
AS
INSERT INTO Category
           ([Name])
     VALUES
           (@CategoryName)