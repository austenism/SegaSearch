drop table if exists Sega.GamePlatform
drop table if exists Sega.GameGenre
drop table if exists Sega.GameTeam


drop table if exists Sega.Genre
drop table if exists Sega.Game
drop table if exists Sega.DevelopmentTeam

drop table if exists Sega.Franchise

Create Table Sega.Franchise
(
	FranchiseID Int Not Null Identity(1, 1) Primary Key,
	Name NVarChar(100) Not Null
);

Create table Sega.DevelopmentTeam
(
    TeamID Int Not Null Identity(1, 1) Primary Key,
    Name NVarChar(64) Not Null
)

Create Table Sega.Game
(
	GameID Int Not Null Identity(1, 1) Primary Key,
	FranchiseID Int Not Null Foreign Key
		References Sega.Franchise(FranchiseID),
	
	Name NVarChar(100) Not Null
);

Create Table Sega.Genre
(
	GenreID Int Not Null Identity(1, 1) Primary Key,
	Name NVarChar(64) Not Null
);

Create Table Sega.GamePlatform
(
	GameID Int Not Null Foreign Key
		References Sega.Game(GameID),
	PlatformID Int Not Null Foreign Key
		References Sega.Platform(PlatformID),
    ReleaseDate DateTimeOffset Not Null,
	Rating Int Constraint CHK_Rating Check (Rating <= 100 AND Rating >= 0),
	QuantitySold Int,
	unique(GameID, PlatformID)
);
Create Table Sega.GameGenre
(
	GameID Int Not Null Foreign Key
		References Sega.Game(GameID),
	GenreID Int Not Null Foreign Key
		References Sega.Genre(GenreID),
	unique(GameID, GenreID)
);
Create Table Sega.GameTeam
(
	GameID Int Not Null Foreign Key
		References Sega.Game(GameID),
	TeamID Int Not Null Foreign Key
		References Sega.DevelopmentTeam(TeamID),
	unique(GameID, TeamID)
);

go