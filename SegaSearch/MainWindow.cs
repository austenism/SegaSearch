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

namespace SegaSearch
{
    public partial class MainWindow : Form
    {

        string connetionString;


        public MainWindow()
        {
            InitializeComponent();
            btnGame.Checked = true;
            //login stuff for the database
            connetionString =
                @"Data Source=mssql.cs.ksu.edu;
                    Initial Catalog=cis560_team19;
                    User ID=austenism;
                    Password=joelsuxlol42069";
            //cis560_team19

        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            String query;
            String searchTerm = txtSearch.Text;

            if (btnGame.Checked)
            {
                //use the query for gamu
                #region GameQuery
                query =
                    "SELECT G.Name as Game, " +
                    "F.Name as Franchise, " +
                    "Stuff((SELECT ', ' + J.Name " +
                        "FROM Sega.GameGenre GJ " +
                            "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                        "WHERE GJ.GameID = G.GameID " +
                        "FOR XML PATH('')), 1, 1, '') as Genre, " +
                    "Stuff((SELECT ', ' + T.Name " +
                        "FROM Sega.GameTeam GT " +
                            "join Sega.DevelopmentTeam T on T.TeamID = GT.TeamID " +
                        "WHERE GT.GameID = G.GameID " +
                        "FOR XML PATH('')), 1, 1, '') as [Development Team], " +
                    "Stuff((SELECT ', ' + P.Name, ' (' + Cast(Year(GP.ReleaseDate) as NVarChar(64)) + ')' " +
                        "FROM Sega.GamePlatform GP " +
                            "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                        "WHERE GP.GameID = G.GameID " +
                        "FOR XML PATH('')), 1, 1, '') as 'Platforms', " +
                    "Sum(G.QuantitySold) as [Copies Sold] " +
                    "FROM Sega.Game G " +
                        "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                        "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                        "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                        "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                        "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                        "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                        "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                    $"Where J.Name Like('%{searchTerm}%') Or G.Name Like('%{searchTerm}%') Or T.Name like('%{searchTerm}%') or P.Name like('%{searchTerm}%') " +
                    "GROUP BY G.Name, G.GameID, F.Name " +
                    "Order By G.Name ";
                #endregion
            }
            else if (btnGenre.Checked)
            {
                #region GenreQuery
                query =
                "select J.Name as [Genre], Avg(GP.Rating) as [Average Rating], Sum(G.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made] " +
                "from Sega.Game G " +
                    "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                    "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                    "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                    "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                    "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                $"Where J.Name Like('%{searchTerm}%') " +
                "group by J.Name " +
                "order by [Number of Sega Games Made] Desc ";
                #endregion
            }
            else if (btnTeam.Checked)
            {
                #region TeamQuery
                query =
                "select T.Name as [Development Team], Avg(GP.Rating) as [Average Rating], Sum(G.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made] " +
                "from Sega.Game G " +
                    "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                    "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                    "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                    "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                    "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                $"Where T.Name Like('%{searchTerm}%') " +
                "group by T.Name " +
                "order by [Number of Sega Games Made] Desc ";
                #endregion
            }
            else if (btnPlatform.Checked)
            {
                #region PlatformQuery
                query =
                "select P.Name as Platform, Avg(GP.Rating) as [Average Rating], Sum(G.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made] " +
                "from Sega.Game G " +
                    "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                    "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                    "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                    "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                    "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                $"Where P.Name Like('%{searchTerm}%') " +
                "group by P.Name " +
                "order by [Number of Sega Games Made] Desc ";
                #endregion
            }
            else if (btnManufacturer.Checked)
            {
                #region ManufacturerQuery
                query =
                "select P.Manufacturer, Avg(GP.Rating) as [Average Rating], Sum(G.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made] " +
                "from Sega.Game G " +
                    "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                    "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                    "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                    "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                    "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                $"Where P.Manufacturer Like('%{searchTerm}%') " +
                "group by P.Manufacturer " +
                "order by [Number of Sega Games Made] Desc ";
                #endregion
            }
            else if (btnFranchise.Checked)
            {
                #region FranchiseQuery
                query =
                "select F.Name as Franchise, Avg(GP.Rating) as [Average Rating], Sum(G.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made] " +
                "from Sega.Game G " +
                    "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                    "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                    "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                    "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                    "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                $"Where F.Name Like('%{searchTerm}%') " +
                "group by F.Name " +
                "order by [Number of Sega Games Made] Desc ";
                #endregion
            }
            else
            {
                throw new Exception("wat");
            }



            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                grdResults.DataSource = dtbl;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connetionString))
            {
                sqlCon.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT G.[Name], GP.ReleaseDate" +
                    "FROM Sega.Game G" +
                    "   INNER JOIN Sega.GamePlateform GP ON GP.GameID = G.GameID" +
                    $"WHERE G.[Name] LIKE(N'%{txtName.Text}%')" + " AND YEAR(GP.ReleaseDate) = " + txtYear.Text + ";", sqlCon);
                DataTable dtbl = new DataTable();
                string query;
                string qBuild;
                if (sqlDa.Fill(dtbl) > 0)
                {

                    query = "WITH SourceCTE (GameID, FranchiseID, ReleaseDate) AS" +
                        "(SELECT G.GameID, G.FranchiseID, GP.ReleaseDate" +
                        "FROM Sega.Game G" +
                        "   INNER JOIN Sega.GamePlateform GP ON GP.GameID = G.GameID" +
                        $"WHERE G.[Name] LIKE(N'%{txtName.Text}%') " +
                        "AND YEAR(GP.ReleaseDate) = " + txtYear.Text + ")";
                    qBuild = query;
                    #region GenreAdd/ModifyQuery
                    if (txtGenre.Text.Split(',') != null && txtGenre.Text.Split(',').Count() >= 1)
                    {
                        foreach (string s in txtGenre.Text.Split(','))
                        {
                            string gName = s.Trim();
                            sqlDa = new SqlDataAdapter(query + "SELECT *" +
                                "FROM Sega.GameGenre GG" +
                                "   INNER JOIN SourceCTE S ON S.GameID = GG.GameID" +
                                "   INNER JOIN Sega.Genre G ON G.GenreID = GG.GenreID" +
                                $"WHERE G.[Name] LIKE(N'%{gName}%');", sqlCon);
                            dtbl = new DataTable();
                            if (sqlDa.Fill(dtbl) == 0)
                            {
                                sqlDa = new SqlDataAdapter("SELECT *" +
                                    "FROM Sega.Genre G" +
                                    $"WHERE G.[Name] LIKE(N'%{gName}%');", sqlCon);
                                dtbl = new DataTable();
                                if (sqlDa.Fill(dtbl) == 0)
                                {
                                    qBuild += $"INSERT Sega.Genre([Name]) VALUES(N'%{gName}%');" +
                                        "INSERT Sega.GameGenre(GameID, GenreID)" +
                                        "SELECT S.GameID, G.GenreID" +
                                        "FROM SourceCTE S" +
                                        $"   INNER JOIN Sega.Genre G ON G.[Name] LIKE(N'%{gName}%');";
                                }
                                else
                                {
                                    qBuild += "INSERT Sega.GameGenre(GameID, GenreID)" +
                                        "SELECT S.GameID, G.GenreID" +
                                        "FROM SourceCTE S" +
                                        $"   INNER JOIN Sega.Genre G ON G.[Name] LIKE(N'%{gName}%');";
                                }
                            }
                        }
                    }
                    else if (txtGenre.Text != null && !txtGenre.Text.Trim().Equals(""))
                    {
                        string gName = txtGenre.Text.Trim();
                        sqlDa = new SqlDataAdapter(query + "SELECT *" +
                                "FROM Sega.GameGenre GG" +
                                "   INNER JOIN SourceCTE S ON S.GameID = GG.GameID" +
                                "   INNER JOIN Sega.Genre G ON G.GenreID = GG.GenreID" +
                                $"WHERE G.[Name] LIKE(N'%{gName}%');", sqlCon);
                        dtbl = new DataTable();
                        if (sqlDa.Fill(dtbl) == 0)
                        {
                            sqlDa = new SqlDataAdapter("SELECT *" +
                                    "FROM Sega.Genre G" +
                                    $"WHERE G.[Name] LIKE(N'%{gName}%');", sqlCon);
                            dtbl = new DataTable();
                            if (sqlDa.Fill(dtbl) == 0)
                            {
                                qBuild += $"INSERT Sega.Genre([Name]) VALUES(N'%{gName}%');" +
                                    "INSERT Sega.GameGenre(GameID, GenreID)" +
                                    "SELECT S.GameID, G.GenreID" +
                                    "FROM SourceCTE S" +
                                    $"   INNER JOIN Sega.Genre G ON G.[Name] LIKE(N'%{gName}%');";
                            }
                            else
                            {
                                qBuild += "INSERT Sega.GameGenre(GameID, GenreID)" +
                                    "SELECT S.GameID, G.GenreID" +
                                    "FROM SourceCTE S" +
                                    $"   INNER JOIN Sega.Genre G ON G.[Name] LIKE(N'%{gName}%');";
                            }
                        }
                    }
                    #endregion
                    #region PlatformAdd/ModifyQuery
                    if (txtPlatform.Text.Split(',') != null && txtPlatform.Text.Split(',').Count() >= 1)
                    {
                        foreach (string s in txtPlatform.Text.Split(','))
                        {
                            string pName = s.Trim();
                            sqlDa = new SqlDataAdapter(query + "SELECT *" +
                                "FROM Sega.GamePlatform GP" +
                                "   INNER JOIN SourceCTE S ON S.GameID = GP.GameID" +
                                "   INNER JOIN Sega.Platform P ON P.PlatformID = GP.PlatformID" +
                                $"WHERE P.[Name] LIKE(N'%{pName}%');", sqlCon);
                            dtbl = new DataTable();
                            if (sqlDa.Fill(dtbl) == 0)
                            {
                                sqlDa = new SqlDataAdapter("SELECT *" +
                                    "FROM Sega.Platform P" +
                                    $"WHERE P.[Name] LIKE(N'%{pName}%');", sqlCon);
                                dtbl = new DataTable();
                                if (sqlDa.Fill(dtbl) == 0)
                                {
                                    qBuild += $"INSERT Sega.Platform([Name], Manufacturer) VALUES(N'%{pName}%', N'Unknown(user input)');" +
                                        "INSERT Sega.GamePlatform(GameID, PlatformID, ReleaseDate, Rating)" +
                                        "SELECT S.GameID, P.PlatformID, dateadd(YEAR, (" + txtYear.Text + " - YEAR(SYSDATETIMEOFFSET())), SYSDATETIMEOFFSET()), " + txtRating.Text +
                                        "FROM SourceCTE S" +
                                        $"   INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%');";
                                }
                                else
                                {
                                    qBuild += "UPDATE Sega.GamePlatform SET Rating = " + txtRating +
                                        $"FROM SourceCTE S INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%')" +
                                        "WHERE GameID = S.GameID AND PlatformID = P.PlatformID;";
                                }
                            }
                        }
                    }
                    else if (txtPlatform.Text != null && !txtPlatform.Text.Trim().Equals(""))
                    {
                        string pName = txtPlatform.Text.Trim();
                        sqlDa = new SqlDataAdapter(query + "SELECT *" +
                                "FROM Sega.GamePlatform GP" +
                                "   INNER JOIN SourceCTE S ON S.GameID = GP.GameID" +
                                "   INNER JOIN Sega.Platform P ON P.PlatformID = GP.PlatformID" +
                                $"WHERE P.[Name] LIKE(N'%{pName}%');", sqlCon);
                        dtbl = new DataTable();
                        if (sqlDa.Fill(dtbl) == 0)
                        {
                            sqlDa = new SqlDataAdapter("SELECT *" +
                                "FROM Sega.Platform P" +
                                $"WHERE P.[Name] LIKE(N'%{pName}%');", sqlCon);
                            dtbl = new DataTable();
                            if (sqlDa.Fill(dtbl) == 0)
                            {
                                qBuild += $"INSERT Sega.Platform([Name], Manufacturer) VALUES(N'%{pName}%', N'Unknown(user input)');" +
                                    "INSERT Sega.GamePlatform(GameID, PlatformID, ReleaseDate, Rating)" +
                                    "SELECT S.GameID, P.PlatformID, dateadd(YEAR, (" + txtYear.Text + " - YEAR(SYSDATETIMEOFFSET())), SYSDATETIMEOFFSET()), " + txtRating.Text +
                                    "FROM SourceCTE S" +
                                    $"   INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%');";
                            }
                            else
                            {
                                qBuild += "UPDATE Sega.GamePlatform SET Rating = " + txtRating +
                                    $"FROM SourceCTE S INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%')" +
                                    "WHERE GameID = S.GameID AND PlatformID = P.PlatformID;";
                            }
                        }
                    }
                    #endregion
                    if (txtCopiesSold.Text != null && !txtCopiesSold.Text.Trim().Equals(""))
                    {
                        qBuild += "UPDATE Sega.Game" + "SET    QuantitySold = " + txtCopiesSold.Text + "FROM SourceCTE S" + 
                            "WHERE GameID = S.GameID AND QuantitySold <> " + txtCopiesSold.Text + ";";
                    }
                    if (txtRating.Text != null && !txtRating.Text.Trim().Equals(""))
                    {
                        qBuild += "UPDATE Sega.GamePlatform" + "SET    Rating = " + txtRating.Text + "FROM SourceCTE S" +
                        "WHERE GameID = S.GameID AND RATING <> " + txtRating.Text + ";";
                    }
                    if (txtFranchise.Text != null && !txtFranchise.Text.Trim().Equals(""))
                    {
                        qBuild += "UPDATE Sega.Franchise" + "SET    [Name] = " + txtFranchise.Text + "FROM SourceCTE S" +
                        $"WHERE FranchiseID = S.FranchiseID AND [Name] NOT LIKE('%{txtFranchise.Text}%')" + ";";
                    }
                }
            }
        }
    }
}