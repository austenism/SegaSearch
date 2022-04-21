Use cis560_team19

Drop Table if Exists Sega.GameCharacter
Drop Table if Exists Sega.GamePlatform
Drop Table if Exists Sega.GameGenre
Drop Table if Exists Sega.GamePerson
Drop Table if Exists Sega.Character
Drop Table if Exists Sega.Platform
Drop Table if Exists Sega.Genre
Drop Table if Exists Sega.Person
Drop Table if Exists Sega.Game
Drop Table if Exists Sega.Franchise

/****Main Tables*******/
Create Table Sega.Franchise
(
	FranchiseID Int Not Null Identity(1, 1) Primary Key,
	Name NVarChar(64) Not Null
);
Create Table Sega.Game
(
	GameID Int Not Null Identity(1, 1) Primary Key,
	FranchiseID Int Not Null Foreign Key
		References Sega.Franchise(FranchiseID),
	
	Name NVarChar(64) Not Null,
	ReleaseDate DateTimeOffset Not Null,
	Rating Int Constraint CHK_Rating Check (Rating <= 100 AND Rating >= 0),
	QuantitySold Int Not Null
);


/******Smaller Main Tables********/
Create Table Sega.Character
(
	CharacterID Int Not Null Identity(1, 1) Primary Key,
	Name NVarChar(64) Not Null
);
Create Table Sega.Platform
(
	PlatformID Int Not Null Identity(1, 1) Primary Key,
	Name NVarChar(64) Not Null,
	Manufacturer NVarChar(64) Not Null
);
Create Table Sega.Genre
(
	GenreID Int Not Null Identity(1, 1) Primary Key,
	Name NVarChar(64) Not Null
);
Create Table Sega.Person
(
	PersonID Int Not Null Identity(1, 1) Primary Key,
	Name NVarChar(64) Not Null,
	Position NVarChar(64) Not Null
);

/*********Many to Many Table Intermediates****************/
Create Table Sega.GameCharacter
(
	GameID Int Not Null Foreign Key
		References Sega.Game(GameID),
	CharacterID Int Not Null Foreign Key
		References Sega.Character(CharacterID)
);
Create Table Sega.GamePlatform
(
	GameID Int Not Null Foreign Key
		References Sega.Game(GameID),
	PlatformID Int Not Null Foreign Key
		References Sega.Platform(PlatformID)
);
Create Table Sega.GameGenre
(
	GameID Int Not Null Foreign Key
		References Sega.Game(GameID),
	GenreID Int Not Null Foreign Key
		References Sega.Genre(GenreID)
);
Create Table Sega.GamePerson
(
	GameID Int Not Null Foreign Key
		References Sega.Game(GameID),
	PersonID Int Not Null Foreign Key
		References Sega.Person(PersonID)
);
