CREATE PROCEDURE Get_Author_By_Id
	@AuthorId int
AS
SELECT 
	Id,
	[Name],
	Country
FROM
	Author
WHERE Author.Id = @AuthorId
ORDER BY
	Author.Id DESC