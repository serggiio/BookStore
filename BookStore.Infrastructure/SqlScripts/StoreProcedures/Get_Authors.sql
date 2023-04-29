CREATE PROCEDURE Get_Authors
AS
SELECT 
	Id,
	[Name],
	Country
FROM
	Author
ORDER BY
	Author.Id DESC