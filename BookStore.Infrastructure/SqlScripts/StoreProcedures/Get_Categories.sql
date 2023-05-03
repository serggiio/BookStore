CREATE PROCEDURE Get_Categories
AS
SELECT 
	Id,
	[Name]
FROM
	Category
ORDER BY
	Category.Id DESC