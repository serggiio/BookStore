CREATE PROCEDURE Add_Category_Book
	@CategoryId int,
	@BookId int
AS
INSERT INTO Book_Category
           (CategoryId
           ,BookId)
     VALUES
           (@CategoryId,
           @BookId)