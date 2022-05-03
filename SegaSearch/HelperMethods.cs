using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Types;
using SegaSearch;

namespace SegaSearch
{
    public static class HelperMethods
    {
        public static string connetionString =
            @"Data Source=mssql.cs.ksu.edu;
                    Initial Catalog=cis560_team19;
                    User ID=austenism;
                    Password=joelsuxlol42069";
        //cis560_team19
        public static int CheckForFranchise(string name)
        {
            //get and return count of specified franchise
            return GetTableCount(
                "select Count(*) " +
                "from Sega.Franchise F " +
                    $"where F.Name Like('{name}') ");
        }
        public static int CheckForGenre(string name)
        {
            //get and return count of specified genre
            return GetTableCount(
                "select Count(*) " +
                "from Sega.Genre J " +
                    $"where J.Name Like('{name}') ");
        }
        public static int CheckForTeam(string name)
        {
            //get and return count of specified Team
            return GetTableCount(
                "select Count(*) " +
                "from Sega.DevelopmentTeam T " +
                    $"where T.Name Like('{name}') ");
        }
        public static int CheckForPlatform(string name)
        {
            //get and return count of specified Platform
            return GetTableCount(
                "select Count(*) " +
                "from Sega.Platform P " +
                    $"where P.Name Like('{name}') ");
        }

        public static void AddFranchise(string name)
        {
            RunCommand(
            "Insert into Sega.Franchise(Name) " +
                $"Values('{name}') "
                );
        }
        public static void AddGenre(string name)
        {
            RunCommand(
            "Insert into Sega.Genre(Name) " +
                $"Values('{name}') "
                );
        }
        public static void AddTeam(string name)
        {
            RunCommand(
            "Insert into Sega.DevelopmentTeam(Name) " +
                $"Values('{name}') "
                );
        }
        public static void AddPlatform(string name)
        {
            string Manufacturer = "";
            Input.InputBox("Add Platform", $"Enter the Manufacturer of {name}", ref Manufacturer);

            RunCommand(
            "Insert into Sega.Platform(Name, Manufacturer) " +
                $"Values('{name}', '{Manufacturer}') "
                );
        }
        public static void AddGame(string name, string franchiseName)
        {
            //lets get the franchise id for it
            int franchiseID = HelperMethods.GetFranchiseID(franchiseName);

            RunCommand(
                "Insert into Sega.Game(Name, FranchiseID) " +
                $"Values('{name}', {franchiseID}) "
                );
        }
        
        public static void MakeGamePlatform(string gameName, string platformName, int releaseYear, int rating, int quantitySold)
        {
            int gameID = GetGameID(gameName);
            int platformID = GetPlatformID(platformName);

            string query =
            "Insert Into Sega.GamePlatform(GameID, PlatformID, ReleaseDate, Rating, QuantitySold) " +
            $"Values({gameID}, {platformID}, '{releaseYear}-01-01 12:00:00.00000', {rating}, {quantitySold})";

            RunCommand(query);
        }
        public static void MakeGameGenre(string gameName, string genreName)
        {
            int gameID = GetGameID(gameName);
            int genreID = GetGenreID(genreName);

            string query =
            "Insert Into Sega.GameGenre(GameID, GenreID) " +
            $"Values({gameID}, {genreID})";

            RunCommand(query);
        }
        public static void MakeGameTeam(string gameName, string TeamName)
        {
            int gameID = GetGameID(gameName);
            int teamID = GetTeamID(TeamName);

            string query =
            "Insert Into Sega.GameTeam(GameID, TeamID) " +
            $"Values({gameID}, {teamID})";

            RunCommand(query);
        }
       
        //gets the most recently created gameId of the specified name
        public static int GetGameID(string gameName)
        {
            int id = -1;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                SqlCommand command = new SqlCommand(
                  "select G.GameID " +
                  "from Sega.Game G " +
                  $"where G.Name = '{gameName}' ",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                else
                {
                    throw new Exception("problem in GetGameID");
                }
                reader.Close();
            }
            if (id != -1)
            {
                return id;
            }
            else
            {
                throw new Exception("problem in GetGameID");
            }
        }
        //these ones instead get the first ID on the list of the specified name, in case there are some duplicates
        public static int GetFranchiseID(string franchiseName)
        {
            int id = -1;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                SqlCommand command = new SqlCommand(
                  "select F.FranchiseID " +
                  "from Sega.Franchise F " +
                  $"where F.Name Like('{franchiseName}') ",
                  connection) ;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                else
                {
                    throw new Exception("problem in GetFranchiseID");
                }
                reader.Close();
            }
            if (id != -1)
            {
                return id;
            }
            else
            {
                throw new Exception("problem in GetFranchiseID");
            }
        }
        public static int GetPlatformID(string platformName)
        {
            int id = -1;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                SqlCommand command = new SqlCommand(
                  "select P.PlatformID " +
                  "from Sega.Platform P " +
                  $"where P.Name = '{platformName}' ",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                else
                {
                    throw new Exception("problem in GetPLatformID");
                }
                reader.Close();
            }
            if (id != -1)
            {
                return id;
            }
            else
            {
                throw new Exception("problem in GetPlatformID");
            }
        }
        public static int GetGenreID(string genreName)
        {
            int id = -1;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                SqlCommand command = new SqlCommand(
                  "select G.GenreID " +
                  "from Sega.Genre G " +
                  $"where G.Name = '{genreName}' ",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                else
                {
                    throw new Exception("problem in GetGenreID");
                }
                reader.Close();
            }
            if (id != -1)
            {
                return id;
            }
            else
            {
                throw new Exception("problem in GetGenreID");
            }
        }
        public static int GetTeamID(string teamName)
        {
            int id = -1;
            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                SqlCommand command = new SqlCommand(
                  "select T.TeamID " +
                  "from Sega.DevelopmentTeam T " +
                  $"where T.Name = '{teamName}' ",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                else
                {
                    throw new Exception("problem in GetTeamID");
                }
                reader.Close();
            }
            if (id != -1)
            {
                return id;
            }
            else
            {
                throw new Exception("problem in GetTeamID");
            }
        }

        public static void RunCommand(string query)
        {
            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                sqlCon.Open();
                SqlCommand command = new SqlCommand(query, sqlCon);
                command.ExecuteNonQuery();
            }
        }
        public static int GetTableCount(string query)
        {
            int count = 0;

            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(query, sqlCon))
                {
                    sqlCon.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;

        }
        public static DataTable RunQuery(String query)
        {
            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                return dtbl;
            }
        }
    }
}
