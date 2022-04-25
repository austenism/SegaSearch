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
            txtCharacters.Enabled = false;
            txtCharacters.Text = "Update to new version to add characters...";
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            String query;
            String searchTerm = txtSearch.Text;
            int yearFrom;
            int yearTo;

            if (txtFrom.Text != "")
            {
                yearFrom = Int32.Parse(txtFrom.Text);
            }
            else
            {
                yearFrom = 1999;
            }
            if (txtTo.Text != "")
            {

                yearTo = Int32.Parse(txtTo.Text);
            }
            else
            {
                yearTo = 20000000;
            }
            

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
                    "Sum(GP.QuantitySold) as [Copies Sold] " +
                    "FROM Sega.Game G " +
                        "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                        "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                        "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                        "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                        "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                        "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                        "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                    $"Where (J.Name Like('%{searchTerm}%') Or G.Name Like('%{searchTerm}%') Or T.Name like('%{searchTerm}%') or P.Name like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= {yearFrom} AND Year(GP.ReleaseDate) <= {yearTo} " +
                    "GROUP BY G.Name, G.GameID, F.Name " +
                    "Order By G.Name ";
                #endregion
            }
            else if (btnGenre.Checked)
            {
                #region GenreQuery
                query =
                "select J.Name as [Genre], Avg(GP.Rating) as [Average Rating], Sum(GP.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made] " +
                "from Sega.Game G " +
                    "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                    "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                    "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                    "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                    "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                $"Where (J.Name Like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= {yearFrom} AND Year(GP.ReleaseDate) <= {yearTo} " +
                "group by J.Name " +
                "order by [Number of Sega Games Made] Desc ";
                #endregion
            }
            else if (btnTeam.Checked)
            {
                #region TeamQuery
                query =
                "select T.Name as [Development Team], Avg(GP.Rating) as [Average Rating], Sum(GP.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made] " +
                "from Sega.Game G " +
                    "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                    "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                    "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                    "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                    "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                $"Where (T.Name Like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= {yearFrom} AND Year(GP.ReleaseDate) <= {yearTo} " +
                "group by T.Name " +
                "order by [Number of Sega Games Made] Desc ";
                #endregion
            }
            else if (btnPlatform.Checked)
            {
                #region PlatformQuery
                query =
                "select P.Name as Platform, Avg(GP.Rating) as [Average Rating], Sum(GP.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made] " +
                "from Sega.Game G " +
                    "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                    "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                    "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                    "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                    "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                $"Where (P.Name Like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= {yearFrom} AND Year(GP.ReleaseDate) <= {yearTo} " +
                "group by P.Name " +
                "order by [Number of Sega Games Made] Desc ";
                #endregion
            }
            else if (btnManufacturer.Checked)
            {
                #region ManufacturerQuery
                query =
                "select P.Manufacturer, Avg(GP.Rating) as [Average Rating], Sum(GP.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made] " +
                "from Sega.Game G " +
                    "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                    "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                    "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                    "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                    "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                $"Where (P.Manufacturer Like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= {yearFrom} AND Year(GP.ReleaseDate) <= {yearTo} " +
                "group by P.Manufacturer " +
                "order by [Number of Sega Games Made] Desc ";
                #endregion
            }
            else if (btnFranchise.Checked)
            {
                #region FranchiseQuery
                query =
                "select F.Name as Franchise, Avg(GP.Rating) as [Average Rating], Sum(GP.QuantitySold) as [Games Sold], Count(Distinct G.Name) as [Number of Sega Games Made] " +
                "from Sega.Game G " +
                    "join Sega.GameTeam GT on G.GameID = GT.GameID " +
                    "join Sega.DevelopmentTeam T on GT.TeamID = T.TeamID " +
                    "join Sega.GameGenre GJ on GJ.GameID = G.GameID " +
                    "join Sega.Genre J on J.GenreID = GJ.GenreID " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                    "join Sega.Franchise F on F.FranchiseID = G.FranchiseID " +
                $"Where (F.Name Like('%{searchTerm}%')) AND Year(GP.ReleaseDate) >= {yearFrom} AND Year(GP.ReleaseDate) <= {yearTo} " +
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
            if ((txtName.Text != null && txtName.Text.Trim().Equals("")) && (txtYear.Text != null && txtYear.Text.Trim().Equals("")))
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
                    //if game exists
                    #region ModifyingQueries
                    if (sqlDa.Fill(dtbl) > 0)
                    {

                        query = "WITH SourceCTE (GameID, FranchiseID, ReleaseDate, PlatformID) AS" +
                            "(SELECT G.GameID, G.FranchiseID, GP.ReleaseDate, GP.PlatformID" +
                            "FROM Sega.Game G" +
                            "   INNER JOIN Sega.GamePlatform GP ON GP.GameID = G.GameID" +
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
                        if ((txtPlatform.Text.Split(',') != null && txtPlatform.Text.Split(',').Count() >= 1))
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
                                            "INSERT Sega.GamePlatform(GameID, PlatformID, ReleaseDate)" +
                                            "SELECT S.GameID, P.PlatformID, dateadd(YEAR, (" + txtYear.Text + " - YEAR(SYSDATETIMEOFFSET())), SYSDATETIMEOFFSET())" +
                                            "FROM SourceCTE S" +
                                            $"   INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%');";
                                    }
                                    else
                                    {
                                        qBuild += "INSERT Sega.GamePlatform(GameID, PlatformID, ReleaseDate)" +
                                            "SELECT S.GameID, P.PlatformID, dateadd(YEAR, (" + txtYear.Text + " - YEAR(SYSDATETIMEOFFSET())), SYSDATETIMEOFFSET())" +
                                            "FROM SourceCTE S" +
                                            $"   INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%');";
                                    }
                                }
                            }
                        }
                        else if ((txtPlatform.Text != null && !txtPlatform.Text.Trim().Equals("")))
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
                                        "INSERT Sega.GamePlatform(GameID, PlatformID, ReleaseDate)" +
                                            "SELECT S.GameID, P.PlatformID, dateadd(YEAR, (" + txtYear.Text + " - YEAR(SYSDATETIMEOFFSET())), SYSDATETIMEOFFSET())" +
                                            "FROM SourceCTE S" +
                                            $"   INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%');";
                                }
                                else
                                {
                                    qBuild += "INSERT Sega.GamePlatform(GameID, PlatformID, ReleaseDate)" +
                                            "SELECT S.GameID, P.PlatformID, dateadd(YEAR, (" + txtYear.Text + " - YEAR(SYSDATETIMEOFFSET())), SYSDATETIMEOFFSET())" +
                                            "FROM SourceCTE S" +
                                            $"   INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%');";
                                }
                            }
                        }
                        #endregion
                        #region DevTeamAdd/ModifyQuery
                        if (txtDevelopmentTeam.Text.Split(',') != null && txtDevelopmentTeam.Text.Split(',').Count() >= 1)
                        {
                            foreach (string s in txtDevelopmentTeam.Text.Split(','))
                            {
                                string dName = s.Trim();
                                sqlDa = new SqlDataAdapter(query + "SELECT *" +
                                    "FROM Sega.GameTeam GT" +
                                    "   INNER JOIN SourceCTE S ON S.GameID = GT.GameID" +
                                    "   INNER JOIN Sega.DevelopmentTeam T ON T.TeamID = GT.TeamID" +
                                    $"WHERE G.[Name] LIKE(N'%{dName}%');", sqlCon);
                                dtbl = new DataTable();
                                if (sqlDa.Fill(dtbl) == 0)
                                {
                                    sqlDa = new SqlDataAdapter("SELECT *" +
                                        "FROM Sega.DevelopmentTeam T" +
                                        $"WHERE T.[Name] LIKE(N'%{dName}%');", sqlCon);
                                    dtbl = new DataTable();
                                    if (sqlDa.Fill(dtbl) == 0)
                                    {
                                        qBuild += $"INSERT Sega.DevelopmentTeam([Name]) VALUES(N'%{dName}%');" +
                                            "INSERT Sega.GameTeam(GameID, TeamID)" +
                                            "SELECT S.GameID, T.TeamID" +
                                            "FROM SourceCTE S" +
                                            $"   INNER JOIN Sega.DevelopmentTeam T ON T.[Name] LIKE(N'%{dName}%');";
                                    }
                                    else
                                    {
                                        qBuild += "INSERT Sega.GameTeam(GameID, TeamID)" +
                                            "SELECT S.GameID, T.TeamID" +
                                            "FROM SourceCTE S" +
                                            $"   INNER JOIN Sega.DevelopmentTeam T ON T.[Name] LIKE(N'%{dName}%');";
                                    }
                                }
                            }
                        }
                        else if (txtDevelopmentTeam.Text != null && !txtDevelopmentTeam.Text.Trim().Equals(""))
                        {
                            string dName = txtDevelopmentTeam.Text.Trim();
                            sqlDa = new SqlDataAdapter(query + "SELECT *" +
                                    "FROM Sega.GameTeam GT" +
                                    "   INNER JOIN SourceCTE S ON S.GameID = GT.GameID" +
                                    "   INNER JOIN Sega.DevelopmentTeam T ON T.TeamID = GT.TeamID" +
                                    $"WHERE G.[Name] LIKE(N'%{dName}%');", sqlCon);
                            dtbl = new DataTable();
                            if (sqlDa.Fill(dtbl) == 0)
                            {
                                sqlDa = new SqlDataAdapter("SELECT *" +
                                    "FROM Sega.DevelopmentTeam T" +
                                    $"WHERE T.[Name] LIKE(N'%{dName}%');", sqlCon);
                                dtbl = new DataTable();
                                if (sqlDa.Fill(dtbl) == 0)
                                {
                                    qBuild += $"INSERT Sega.DevelopmentTeam([Name]) VALUES(N'%{dName}%');" +
                                        "INSERT Sega.GameTeam(GameID, TeamID)" +
                                        "SELECT S.GameID, T.TeamID" +
                                        "FROM SourceCTE S" +
                                        $"   INNER JOIN Sega.DevelopmentTeam T ON T.[Name] LIKE(N'%{dName}%');";
                                }
                                else
                                {
                                    qBuild += "INSERT Sega.GameTeam(GameID, TeamID)" +
                                        "SELECT S.GameID, T.TeamID" +
                                        "FROM SourceCTE S" +
                                        $"   INNER JOIN Sega.DevelopmentTeam T ON T.[Name] LIKE(N'%{dName}%');";
                                }
                            }
                        }
                        #endregion
                        if ((txtCopiesSold.Text != null && !txtCopiesSold.Text.Trim().Equals("")))
                        {
                            qBuild += "UPDATE Sega.GamePlatform" + "SET    QuantitySold = " + txtCopiesSold.Text + "FROM SourceCTE S" +
                                "WHERE GameID = S.GameID AND PlatformID = S.PlatformID;";
                        }
                        if (txtRating.Text != null && !txtRating.Text.Trim().Equals(""))
                        {
                            qBuild += "UPDATE Sega.GamePlatform" + "SET    Rating = " + txtRating.Text + "FROM SourceCTE S" +
                            "WHERE GameID = S.GameID AND PlatformID = S.PlatformID;";
                        }
                        if (txtFranchise.Text != null && !txtFranchise.Text.Trim().Equals(""))
                        {
                            qBuild += "UPDATE Sega.Franchise" + $"SET    [Name] = N'%{txtFranchise.Text}%' FROM SourceCTE S" +
                            $"WHERE FranchiseID = S.FranchiseID AND [Name] NOT LIKE(N'%{txtFranchise.Text}%')" + ";";
                        }

                        sqlDa = new SqlDataAdapter(qBuild, sqlCon);
                        dtbl = new DataTable();
                        sqlDa.Fill(dtbl);

                        sqlDa = new SqlDataAdapter("SELECT *    FROM Sega.Game G INNER JOIN SourceCTE S ON S.GameID = G.GameID", sqlCon);
                        dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                        grdResults.DataSource = dtbl;
                        MessageBox.Show("Game, " + txtName.Text + ", with Release Year: " + txtYear.Text +
                            "was changed in the database\n" + "Shown in grid table.");
                    }
                    #endregion
                    //game does not exist
                    #region AddingQueries
                    else
                    {
                        //Check for input in all boxes, since adding a new game
                        if ((txtRating.Text != null && !txtRating.Text.Trim().Equals("")) && (txtCopiesSold.Text != null && !txtCopiesSold.Text.Trim().Equals(""))
                            && (txtFranchise.Text != null && !txtFranchise.Text.Trim().Equals("")) && (txtGenre.Text != null && !txtGenre.Text.Trim().Equals(""))
                            && (txtPlatform.Text != null && !txtPlatform.Text.Trim().Equals("")) && (txtDevelopmentTeam.Text != null && !txtDevelopmentTeam.Text.Trim().Equals("")))
                        {
                            query = "WITH CheckFranchise(FranchiseID, [Name]) AS" +
                                $"(SELECT F.FranchiseID, F.[Name]    FROM Sega.Franchise F   WHERE F.[Name] LIKE(N'%{txtFranchise.Text}%'))";
                            sqlDa = new SqlDataAdapter(query + "SELECT *    FROM CheckFranchise;", sqlCon);
                            dtbl = new DataTable();
                            if (sqlDa.Fill(dtbl) > 0) //if the franchise exists
                            {
                                //adding the game to the table
                                qBuild = query + "INSERT Sega.Game(FranchiseID, [Name])" +
                                    $"SELECT CF.FranchiseID, N'%{txtName.Text}%'" +
                                    "FROM CheckFranchise CF;";
                                qBuild += $"WITH GetGameID(GameID) AS (SELECT G.GameID   FROM Sega.Game G   WHERE G.[Name] LIKE(N'%{txtName.Text}%'))";
                            }
                            else //franchise does not exist
                            {
                                qBuild = $"INSERT INTO Sega.Franchise([Name]) VALUES ('%{txtFranchise.Text}%');";//adding franchise
                                qBuild += "WITH GetFranchiseID(FranchiseID) AS " +  //CLE to access FranchiseID
                                    "(" +
                                    $"SELECT F.FranchiseID   FROM Sega.Franchise F   WHERE F.[Name] LIKE('%{txtFranchise.Text}%')" +
                                    ")";
                                qBuild += "INSERT Sega.Game(FranchiseID, [Name])" +       //adding game, includes copies sold
                                    $"SELECT GF.FranchiseID, N'%{txtName.Text}%' FROM GetFranchiseID GF;";
                                qBuild += $"WITH GetGameID(GameID) AS (SELECT G.GameID   FROM Sega.Game G   WHERE G.[Name] LIKE(N'%{txtName.Text}%'))"; //CLE to get GameID
                            }
                            //adding to gamePlatform
                            #region AddGamePlatform
                            if (txtPlatform.Text.Split(',') != null && txtPlatform.Text.Split(',').Count() >= 1)
                            {
                                foreach (string s in txtPlatform.Text.Split(','))
                                {
                                    string pName = s.Trim();
                                    query = $"SELECT *   FROM Sega.Platform P    WHERE P.[Name] LIKE('%{pName}%');";
                                    dtbl = new DataTable();
                                    sqlDa = new SqlDataAdapter(query, sqlCon);
                                    if (sqlDa.Fill(dtbl) == 0)
                                    {
                                        qBuild += $"INSERT Sega.Platform([Name], Manufacturer) VALUES(N'%{pName}%', N'Unknown(user input)');" +
                                        "INSERT Sega.GamePlatform(GameID, PlatformID, ReleaseDate, Rating, QuantitySold)" +
                                        "SELECT G.GameID, P.PlatformID, dateadd(YEAR, (" + txtYear.Text + " - YEAR(SYSDATETIMEOFFSET())), SYSDATETIMEOFFSET()), " + txtRating.Text + ", " + txtCopiesSold +
                                        "FROM GetGameID G" +
                                        $"   INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%');";
                                    }
                                    else
                                    {
                                        qBuild += "INSERT Sega.GamePlatform(GameID, PlatformID, ReleaseDate, Rating, QuantitySold)" +
                                            "SELECT G.GameID, P.PlatformID, dateadd(YEAR, (" + txtYear.Text + " - YEAR(SYSDATETIMEOFFSET())), SYSDATETIMEOFFSET()), " + txtRating.Text + ", " + txtCopiesSold +
                                            "FROM GetGameID G" +
                                            $"   INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%');";
                                    }
                                }
                            }
                            else
                            {
                                string pName = txtPlatform.Text.Trim();
                                query = $"SELECT *   FROM Sega.Platform P    WHERE P.[Name] LIKE('%{pName}%');";
                                dtbl = new DataTable();
                                sqlDa = new SqlDataAdapter(query, sqlCon);
                                if (sqlDa.Fill(dtbl) == 0)
                                {
                                    qBuild += $"INSERT Sega.Platform([Name], Manufacturer) VALUES(N'%{pName}%', N'Unknown(user input)');" +
                                    "INSERT Sega.GamePlatform(GameID, PlatformID, ReleaseDate, Rating, QuantitySold)" +
                                    "SELECT G.GameID, P.PlatformID, dateadd(YEAR, (" + txtYear.Text + " - YEAR(SYSDATETIMEOFFSET())), SYSDATETIMEOFFSET()), " + txtRating.Text + ", " + txtCopiesSold +
                                    "FROM GetGameID G" +
                                    $"   INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%');";
                                }
                                else
                                {
                                    qBuild += "INSERT Sega.GamePlatform(GameID, PlatformID, ReleaseDate, Rating, QuantitySold)" +
                                        "SELECT G.GameID, P.PlatformID, dateadd(YEAR, (" + txtYear.Text + " - YEAR(SYSDATETIMEOFFSET())), SYSDATETIMEOFFSET()), " + txtRating.Text + ", " + txtCopiesSold +
                                        "FROM GetGameID G" +
                                        $"   INNER JOIN Sega.Platform P ON P.[Name] LIKE(N'%{pName}%');";
                                }
                            }
                            #endregion
                            //Add to GameGenre
                            #region AddGameGenre
                            if (txtGenre.Text.Split(',') != null && txtGenre.Text.Split(',').Count() >= 1)
                            {
                                foreach (string s in txtGenre.Text.Split(','))
                                {
                                    string gName = s.Trim();
                                    query = $"SELECT *   FROM Sega.Genre g    WHERE G.[Name] LIKE('%{gName}%');";
                                    dtbl = new DataTable();
                                    sqlDa = new SqlDataAdapter(query, sqlCon);
                                    if (sqlDa.Fill(dtbl) == 0)
                                    {
                                        qBuild += $"INSERT Sega.Genre([Name]) VALUES(N'%{gName}%');" +
                                        "INSERT Sega.GameGenre(GameID, GenreID)" +
                                        "SELECT G.GameID, GR.GenreID" +
                                        "FROM GetGameID G" +
                                        $"   INNER JOIN Sega.Genre GR ON GR.[Name] LIKE(N'%{gName}%');";
                                    }
                                    else
                                    {
                                        qBuild += "INSERT Sega.GameGenre(GameID, GenreID)" +
                                        "SELECT G.GameID, GR.GenreID" +
                                        "FROM GetGameID G" +
                                        $"   INNER JOIN Sega.Genre GR ON GR.[Name] LIKE(N'%{gName}%');";
                                    }
                                }
                            }
                            else
                            {
                                string gName = txtGenre.Text.Trim();
                                query = $"SELECT *   FROM Sega.Genre g    WHERE G.[Name] LIKE('%{gName}%');";
                                dtbl = new DataTable();
                                sqlDa = new SqlDataAdapter(query, sqlCon);
                                if (sqlDa.Fill(dtbl) == 0)
                                {
                                    qBuild += $"INSERT Sega.Genre([Name]) VALUES(N'%{gName}%');" +
                                    "INSERT Sega.GameGenre(GameID, GenreID)" +
                                    "SELECT G.GameID, GR.GenreID" +
                                    "FROM GetGameID G" +
                                    $"   INNER JOIN Sega.Genre GR ON GR.[Name] LIKE(N'%{gName}%');";
                                }
                                else
                                {
                                    qBuild += "INSERT Sega.GameGenre(GameID, GenreID)" +
                                    "SELECT G.GameID, GR.GenreID" +
                                    "FROM GetGameID G" +
                                    $"   INNER JOIN Sega.Genre GR ON GR.[Name] LIKE(N'%{gName}%');";
                                }
                            }
                            #endregion
                            //Add to GameTeam
                            #region AddGameTeam
                            if (txtDevelopmentTeam.Text.Split(',') != null && txtDevelopmentTeam.Text.Split(',').Count() >= 1)
                            {
                                foreach (string s in txtDevelopmentTeam.Text.Split(','))
                                {
                                    string dName = s.Trim();
                                    query = $"SELECT *   FROM Sega.DevelopmentTeam T    WHERE T.[Name] LIKE('%{dName}%');";
                                    dtbl = new DataTable();
                                    sqlDa = new SqlDataAdapter(query, sqlCon);
                                    if (sqlDa.Fill(dtbl) == 0)
                                    {
                                        qBuild += $"INSERT Sega.DevelopmentTeam([Name]) VALUES(N'%{dName}%');" +
                                        "INSERT Sega.GameTeam(GameID, TeamID)" +
                                        "SELECT G.GameID, T.TeamID" +
                                        "FROM GetGameID G" +
                                        $"   INNER JOIN Sega.DevelopmentTeam T ON T.[Name] LIKE(N'%{dName}%');";
                                    }
                                    else
                                    {
                                        qBuild += "INSERT Sega.GameTeam(GameID, TeamID)" +
                                        "SELECT G.GameID, T.TeamID" +
                                        "FROM GetGameID G" +
                                        $"   INNER JOIN Sega.DevelopmentTeam T ON T.[Name] LIKE(N'%{dName}%');";
                                    }
                                }
                            }
                            else
                            {
                                string dName = txtDevelopmentTeam.Text.Trim();
                                query = $"SELECT *   FROM Sega.DevelopmentTeam T    WHERE T.[Name] LIKE('%{dName}%');";
                                dtbl = new DataTable();
                                sqlDa = new SqlDataAdapter(query, sqlCon);
                                if (sqlDa.Fill(dtbl) == 0)
                                {
                                    qBuild += $"INSERT Sega.DevelopmentTeam([Name]) VALUES(N'%{dName}%');" +
                                    "INSERT Sega.GameTeam(GameID, TeamID)" +
                                    "SELECT G.GameID, T.TeamID" +
                                    "FROM GetGameID G" +
                                    $"   INNER JOIN Sega.DevelopmentTeam T ON T.[Name] LIKE(N'%{dName}%');";
                                }
                                else
                                {
                                    qBuild += "INSERT Sega.GameTeam(GameID, TeamID)" +
                                    "SELECT G.GameID, T.TeamID" +
                                    "FROM GetGameID G" +
                                    $"   INNER JOIN Sega.DevelopmentTeam T ON T.[Name] LIKE(N'%{dName}%');";
                                }
                            }
                            #endregion

                            sqlDa = new SqlDataAdapter(qBuild, sqlCon);
                            dtbl = new DataTable();
                            sqlDa.Fill(dtbl);

                            sqlDa = new SqlDataAdapter("SELECT *    FROM Sega.Game G INNER JOIN GetGameID GG ON GG.GameID = G.GameID", sqlCon);
                            dtbl = new DataTable();
                            sqlDa.Fill(dtbl);
                            grdResults.DataSource = dtbl;
                            MessageBox.Show("Game, " + txtName.Text + ", was added to the database\n" +
                                "Shown in grid table.");

                        }
                        //Invalid input, meaning, empty box
                        else
                        {
                            MessageBox.Show("Error: see grid for details");
                            TextBox invalid = new TextBox();
                            invalid.Text = "Must input all information when adding a game not in the list, game not added, if RATING and QUANTITY SOLD are unknown, input 0, ignore Character(s) for older versions";
                            invalid.ForeColor = Color.Red;
                            invalid.BackColor = Color.White;
                            grdResults.DataSource = invalid;
                        }
                    }
                    #endregion
                }
            }
            #region MissingNameOrYear
            else
            {
                MessageBox.Show("Error: see grid for details");
                TextBox invalid = new TextBox();
                invalid.Text = "Must input NAME and RELEASE YEAR, at the least to modify a game, otherwise fill all information to add a game, ignore Character(s)";
                invalid.ForeColor = Color.Red;
                invalid.BackColor = Color.White;
                grdResults.DataSource = invalid;
            }
            #endregion
        }
    }
}