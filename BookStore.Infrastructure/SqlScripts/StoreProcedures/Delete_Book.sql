CREATE PROCEDURE Delete_Book
	@BookId int
AS
DELETE FROM Book
      WHERE Book.Id = @BookId