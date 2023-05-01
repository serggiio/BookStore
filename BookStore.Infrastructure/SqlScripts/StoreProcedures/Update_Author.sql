CREATE PROCEDURE Update_Author
	@AuthorId int,
	@AuthorName nvarchar(50),
	@AuthorCountry nvarchar(50)
AS
UPDATE Author
   SET [Name] = @AuthorName,
   Country = @AuthorCountry
 WHERE Author.Id = @AuthorId