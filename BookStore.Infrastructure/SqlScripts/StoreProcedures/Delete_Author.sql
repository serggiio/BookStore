CREATE PROCEDURE Delete_Author
	@AuthorId int
AS
DELETE FROM Author
      WHERE Author.Id = @AuthorId