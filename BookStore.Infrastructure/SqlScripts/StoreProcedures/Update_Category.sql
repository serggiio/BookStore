CREATE PROCEDURE Update_Category
	@CategoryId int,
	@CategoryName nvarchar(50)
AS
UPDATE Category
   SET [Name] = @CategoryName
 WHERE Category.Id = @CategoryId