CREATE PROCEDURE Create_Author
	@AuthorName nvarchar(50),
	@AuthorCountry nvarchar(50)
AS
INSERT INTO Author
           ([Name]
           ,Country)
     VALUES
           (@AuthorName,
           @AuthorCountry)