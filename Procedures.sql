--NOTE: This file is never used, it is simply a collection of the code used to work with the database within the application
--This file simply exists for the grader more specification on the use of the SQL code is in the application.

--This first section is code to query the database

--Query to return games based on the search or year filters
 SELECT G.Name as Game, 
                    F.Name as Franchise, 
                    Stuff((SELECT ', ' + J.Name 
                        FROM Sega.GameGenre GJ 
                            join Sega.Genre J on J.GenreID = GJ.GenreID 
                        WHERE GJ.GameID = G.GameID
                        FOR XML PATH('')), 1, 1, '') as Genre,
                    Stuff((SELECT ', ' + T.Name 
                        FROM Sega.GameTeam GT
                            join Sega.DevelopmentTeam T on T.TeamID = GT.TeamID
                        WHERE GT.GameID = G.GameID
                        FOR XML PATH('')), 1, 1, '') as [Development Team],
                    Stuff((SELECT ', ' + P.Name, ' (' + Cast(Year(GP.ReleaseDate) as NVarChar(64)) + ')' 
                        FROM Sega.GamePlatform GP 
                            join Sega.Platform P on P.PlatformID = GP.PlatformID
                        WHERE GP.GameID = G.GameID
                        FOR XML PATH('')), 1, 1, '') as 'Platforms', 
                    Sum(GP.QuantitySold) as [Copies Sold],
                    AVG(GP.Rating) as [Average Rating]
                    FROM Sega.Game G
                        join Sega.GameTeam GT on G.GameID = GT.GameID
                        join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID  
                        join Sega.GameGenre GJ on GJ.GameID = G.GameID  
                        join Sega.Genre J on J.GenreID = GJ.GenreID  
                        join Sega.GamePlatform GP on GP.GameID = G.GameID  
                        join Sega.Platform P on P.PlatformID = GP.PlatformID  
                        join Sega.Franchise F on F.FranchiseID = G.FranchiseID  
                    Where (J.Name Like('%{searchTerm}%') Or G.Name Like('%{searchTerm}%') Or T.Name like('%{searchTerm}%') or P.Name like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= 'yearFrom' AND Year(GP.ReleaseDate) <= 'yearTo'
                    GROUP BY G.Name, G.GameID, F.Name  
                    Order By G.Name ;

--Query to return genres
select J.Name as [Genre], Avg(GP.Rating) as [Average Rating], Sum(GP.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made]  
                from Sega.Game G  
                    join Sega.GameTeam GT on G.GameID = GT.GameID  
                    join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID  
                    join Sega.GameGenre GJ on GJ.GameID = G.GameID  
                    join Sega.Genre J on J.GenreID = GJ.GenreID  
                    join Sega.GamePlatform GP on GP.GameID = G.GameID  
                    join Sega.Platform P on P.PlatformID = GP.PlatformID  
                    join Sega.Franchise F on F.FranchiseID = G.FranchiseID  
                Where (J.Name Like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= 'yearFrom' AND Year(GP.ReleaseDate) <= 'yearTo'  
                group by J.Name  
                order by [Number of Sega Games Made] Desc ;

--Query to return teams
select T.Name as [Development Team], Avg(GP.Rating) as [Average Rating], Sum(GP.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made]  
                from Sega.Game G  
                    join Sega.GameTeam GT on G.GameID = GT.GameID  
                    join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID  
                    join Sega.GameGenre GJ on GJ.GameID = G.GameID  
                    join Sega.Genre J on J.GenreID = GJ.GenreID  
                    join Sega.GamePlatform GP on GP.GameID = G.GameID  
                    join Sega.Platform P on P.PlatformID = GP.PlatformID  
                    join Sega.Franchise F on F.FranchiseID = G.FranchiseID  
                Where (T.Name Like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= 'yearFrom' AND Year(GP.ReleaseDate) <= 'yearTo'  
                group by T.Name  
                order by [Number of Sega Games Made] Desc ;

--Query to return platforms
select P.Name as Platform, Avg(GP.Rating) as [Average Rating], Sum(GP.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made]  
                from Sega.Game G  
                    join Sega.GameTeam GT on G.GameID = GT.GameID  
                    join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID  
                    join Sega.GameGenre GJ on GJ.GameID = G.GameID  
                    join Sega.Genre J on J.GenreID = GJ.GenreID  
                    join Sega.GamePlatform GP on GP.GameID = G.GameID  
                    join Sega.Platform P on P.PlatformID = GP.PlatformID  
                    join Sega.Franchise F on F.FranchiseID = G.FranchiseID  
                Where (P.Name Like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= 'yearFrom' AND Year(GP.ReleaseDate) <= 'yearTo'  
                group by P.Name  
                order by [Number of Sega Games Made] Desc ;

--Query to return manufacturers
select P.Manufacturer, Avg(GP.Rating) as [Average Rating], Sum(GP.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made]  
                from Sega.Game G  
                    join Sega.GameTeam GT on G.GameID = GT.GameID  
                    join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID  
                    join Sega.GameGenre GJ on GJ.GameID = G.GameID  
                    join Sega.Genre J on J.GenreID = GJ.GenreID  
                    join Sega.GamePlatform GP on GP.GameID = G.GameID  
                    join Sega.Platform P on P.PlatformID = GP.PlatformID  
                    join Sega.Franchise F on F.FranchiseID = G.FranchiseID  
                Where (P.Manufacturer Like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= 'yearFrom' AND Year(GP.ReleaseDate) <= 'yearTo'  
                group by P.Manufacturer  
                order by [Number of Sega Games Made] Desc 

--Query to return franchises
select F.Name as Franchise, Avg(GP.Rating) as [Average Rating], Sum(GP.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made]  
                from Sega.Game G  
                    join Sega.GameTeam GT on G.GameID = GT.GameID  
                    join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID  
                    join Sega.GameGenre GJ on GJ.GameID = G.GameID  
                    join Sega.Genre J on J.GenreID = GJ.GenreID  
                    join Sega.GamePlatform GP on GP.GameID = G.GameID  
                    join Sega.Platform P on P.PlatformID = GP.PlatformID  
                    join Sega.Franchise F on F.FranchiseID = G.FranchiseID  
                Where (F.Name Like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= 'yearFrom' AND Year(GP.ReleaseDate) <= 'yearTo'  
                group by F.Name  
                order by [Number of Sega Games Made] Desc ;

--This next section is for code used to manipulate the database / modify

--Check if franchise exists
select Count(*)  
                from Sega.Franchise F  
                    where F.Name Like('{name}');

--Check if Genre exists
select Count(*)  
                from Sega.Genre J  
                    where J.Name Like('{name}') ;

--Check if team exists
select Count(*)  
                from Sega.DevelopmentTeam T  
                    where T.Name Like('{name}') ;

--Check if platform exists
 select Count(*)  
                from Sega.Platform P  
                    where P.Name Like('{name}');

--Adding a franchise
Insert into Sega.Franchise(Name)  
                Values('{name}');

--Adding a genre
Insert into Sega.Genre(Name) 
                Values('{name}');

--Adding a team
Insert into Sega.DevelopmentTeam(Name)  
                Values('{name}');

--Adding a platform
Insert into Sega.Platform(Name, Manufacturer)
                Values('{name}', '{Manufacturer}'); 

--Adding a game
Insert into Sega.Game(Name, FranchiseID)
                Values('{name}', 'franchiseID');

--adding to gamePlatform
Insert Into Sega.GamePlatform(GameID, PlatformID, ReleaseDate, Rating, QuantitySold)  
            Values('gameID', 'platformID', '{releaseYear}-01-01 12:00:00.00000', '{rating}', '{quantitySold}');

--adding to gameGenre
Insert Into Sega.GameGenre(GameID, GenreID)  
            Values('gameID', 'genreID');

--adding to gameTeam
Insert Into Sega.GameTeam(GameID, TeamID)
            Values('gameID', 'teamID');

--Getting the GameID
select G.GameID  
                  from Sega.Game G  
                  where G.Name = '{gameName}';

--Getting FranchiseID
select F.FranchiseID  
                  from Sega.Franchise F  
                  where F.Name Like('{franchiseName}');

--Getting PlatformID
select P.PlatformID  
                  from Sega.Platform P  
                  where P.Name = '{platformName}';

--Getting GenreID
select G.GenreID  
                  from Sega.Genre G  
                  where G.Name = '{genreName}';

--Getting TeamID
select T.TeamID  
                  from Sega.DevelopmentTeam T  
                  where T.Name = '{teamName}';

--Deleting and updating tables

--Deleting from GameTeam
delete  
                from Sega.GameTeam 
                where GameID = '{gameID}';

--Deleting from GameGenre
delete  
                from Sega.GameGenre 
                where GameID = '{gameID}';

--updating Game
update Sega.Game 
                set FranchiseID = '{franchiseID}'
                where GameID = '{gameID}';

--Updating GamePlatform
update Sega.GamePlatform
                set ReleaseDate = '{year}-01-01 12:00:00.00000', Rating = 'rating', QuantitySold = 'quantitySold'
                where GameID = 'gameID';