CREATE PROCEDURE Delete_Category_Book
	@CategoryId int,
	@BookId int
AS
DELETE FROM Book_Category
WHERE 
	Book_Category.CategoryId = @CategoryId AND 
	Book_Category.BookId = @BookId