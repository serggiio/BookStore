CREATE PROCEDURE Get_Categories_By_Book_Id
	@BookId int
AS
SELECT Category.Id
      ,[Name]
  FROM [BOOK_STORE].[dbo].[Category]
  INNER JOIN Book_Category ON Book_Category.CategoryId = Category.Id
  WHERE Book_Category.BookId = @BookId;