using System;

/// <summary>
/// A class representing an instance of a Game, and it's associated properties
/// </summary>

public class Game
{
	public string Name { get; set; }

	public int ReleaseYear { get; set; }

	public int MetaCriticRating { get; set; }

	public int CopiesSold { get; set; }

	public string Franchise { get; set; }

	public string[] Characters { get; set; }

	public string[] Genres { get; set; }

	public string[] Platforms { get; set; }

	public string[] DevelopmentTeams { get; set; }

	public Game(string name, int year, int rating, int copies, string franchise, string[] characters, string[] genres, string[] platforms, string[] devTeams)
	{
		Name = name;
		ReleaseYear = year;
		MetaCriticRating = rating;
		CopiesSold = copies;
		Franchise = franchise;
		Characters = characters;
		Genres = genres;
		Platforms = platforms;
		DevelopmentTeams = devTeams;
	}
}
