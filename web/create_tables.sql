CREATE TABLE Category
(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Name nchar(128) NOT NULL,
	Parent int NULL FOREIGN KEY REFERENCES Category(Id)
)

CREATE TABLE Item
(
	Id int PRIMARY KEY IDENTITY(1,1),
	CategoryId int NULL FOREIGN KEY REFERENCES Category(Id),
	[User] nchar(128) NOT NULL,
	Name nchar(128) NOT NULL,
	[Description] nchar(128) NULL,
	ImageUrl nchar(128) NULL,
	[Type] nchar(32) NOT NULL,
	[Address] nchar(256) NULL,
	[Version] int DEFAULT 0 NOT NULL,
	FriendlyVersion nchar(128) NOT NULL,
    Approved bit DEFAULT 0 NOT NULL
)

ALTER TABLE Category ADD FeaturedItem int NULL FOREIGN KEY REFERENCES Item(Id);

CREATE TABLE Blob
(
	Id int PRIMARY KEY IDENTITY(1, 1),
	DownloadUrl nchar(512) NOT NULL,
	DestinationPath nchar(512) NOT NULL,
	ItemId int NOT NULL FOREIGN KEY REFERENCES Item(Id)
)

CREATE TABLE Dependency
(
	Id int PRIMARY KEY IDENTITY(1, 1),
	DependentItem int NOT NULL FOREIGN KEY REFERENCES Item(Id),
	DependencyItem int NOT NULL FOREIGN KEY REFERENCES Item(Id)
)
GO
