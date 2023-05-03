CREATE TABLE Author (
	Id INT IDENTITY (1,1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Country VARCHAR(50) NOT NULL,
);

CREATE TABLE Book (
	Id INT IDENTITY (1,1) PRIMARY KEY,
	Title VARCHAR(100) NOT NULL,
	Pages INT NOT NULL,
	[Description] VARCHAR(150) NOT NULL,
	Publisher VARCHAR(100) NOT NULL,
	ReleaseDate DATE,
	CreationDate DATE,
	ModificationDate DATE,
);

CREATE TABLE Category (
	Id INT IDENTITY (1,1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
);

CREATE TABLE Author_Book (
	Id INT IDENTITY (1,1) PRIMARY KEY,
	AuthorId INT FOREIGN KEY REFERENCES Author(Id) ON DELETE CASCADE,
	BookId INT FOREIGN KEY REFERENCES Book(Id) ON DELETE CASCADE
);

CREATE TABLE Book_Category (
	Id INT IDENTITY (1,1) PRIMARY KEY,
	BookId INT FOREIGN KEY REFERENCES Book(Id) ON DELETE CASCADE,
	CategoryId INT FOREIGN KEY REFERENCES Category(Id) ON DELETE CASCADE
);

