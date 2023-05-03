CREATE PROCEDURE Update_Book
	@BookId int,
	@BookTitle nvarchar(50),
	@BookPages int,
	@BookDescription nvarchar(150),
	@BookPublisher nvarchar(50),
	@BookReleaseDate Date
AS
UPDATE Book
   SET 
	Title = @BookTitle,
	Pages = @BookPages,
	[Description] = @BookDescription,
	Publisher = @BookPublisher,
	ReleaseDate = @BookReleaseDate
 WHERE Book.Id = @BookId