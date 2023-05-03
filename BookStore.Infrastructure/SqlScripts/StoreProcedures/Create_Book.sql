CREATE PROCEDURE Create_Book
	@BookTitle nvarchar(50),
	@BookPages int,
	@BookDescription nvarchar(150),
	@BookPublisher nvarchar(50),
	@BookReleaseDate Date
AS
INSERT INTO Book
           (Title,
		   Pages,
		   [Description],
		   Publisher,
		   ReleaseDate,
		   CreationDate)
     VALUES
           (@BookTitle,
			@BookPages,
			@BookDescription,
			@BookPublisher,
			@BookReleaseDate,
			GETDATE())