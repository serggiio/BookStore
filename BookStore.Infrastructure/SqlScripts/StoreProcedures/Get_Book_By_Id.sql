CREATE PROCEDURE Get_Book_By_Id
	@BookId int
AS
SELECT 
	Id,
	Title,
	Pages,
	[Description],
	Publisher,
	ReleaseDate,
	CreationDate,
	ModificationDate
FROM
	Book
WHERE Book.Id = @BookId
ORDER BY
	Book.Id DESC