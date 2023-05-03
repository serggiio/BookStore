CREATE PROCEDURE Delete_Category
	@CategoryId int
AS
DELETE FROM Category
      WHERE Category.Id = @CategoryId