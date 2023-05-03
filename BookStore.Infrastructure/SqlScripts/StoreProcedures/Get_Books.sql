CREATE PROCEDURE Get_Books
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
ORDER BY
	Book.Id DESC