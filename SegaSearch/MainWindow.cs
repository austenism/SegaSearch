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
    public partial class MainWindow : Form
    {

        string connetionString;


        public MainWindow()
        {
            InitializeComponent();
            btnGame.Checked = true;
            //login stuff for the database
            connetionString = HelperMethods.connetionString;
            
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
                    "Sum(GP.QuantitySold) as [Copies Sold], " +
                    "AVG(GP.Rating) as [Average Rating]" +
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

            grdResults.DataSource = HelperMethods.RunQuery(query);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {   //search and see if there already exists any of the specified Game-Platform Pairs based on Name
            if (txtName.Text != "" && txtPlatform.Text != "") //if the needed text boxes are filled 
            {
                string[] genres = { };
                string[] teams = { };

                int GamePlatformCount = HelperMethods.GetTableCount(
                "select Count(*) " +
                "from Sega.Game G " +
                    "join Sega.GamePlatform GP on GP.GameID = G.GameID " +
                    "join Sega.Platform P on P.PlatformID = GP.PlatformID " +
                $"where G.Name = '{txtName.Text}' AND P.Name = '{txtPlatform.Text}' ");

                if (GamePlatformCount == 1) //we want to modify
                {
                    #region Modify
                    if (txtFranchise.Text != "")
                    {
                        if (HelperMethods.CheckForFranchise(txtFranchise.Text) == 0) //if Franchise does not exist
                        {//add it
                            HelperMethods.AddFranchise(txtFranchise.Text);
                        }
                    }
                    if (txtGenre.Text != "")
                    {
                        genres = txtGenre.Text.Split(',');
                        foreach (string g in genres)
                        {
                            if (HelperMethods.CheckForGenre(g) == 0) //if genre does not exist
                            {//add it
                                HelperMethods.AddGenre(g);
                            }
                        }
                    }
                    if (txtDevelopmentTeam.Text != "")
                    {
                        teams = txtDevelopmentTeam.Text.Split(',');
                        foreach (string t in teams)
                        {
                            if (HelperMethods.CheckForTeam(t) == 0) //if team does not exist
                            {//add it
                                HelperMethods.AddTeam(t);
                            }
                        }
                    }

                    //this should not be true but just checkin
                    if (HelperMethods.CheckForPlatform(txtPlatform.Text) == 0)
                    {
                        throw new Exception();
                    }

                    //Delete the many-to-many tables so they can be readded
                    HelperMethods.DeleteTables(txtName.Text);
                    //then re-add
                    if (txtGenre.Text != "")
                    {
                        foreach (string s in genres)
                        {
                            HelperMethods.MakeGameGenre(txtName.Text, s);
                        }
                    }
                    if (txtDevelopmentTeam.Text != "")
                    {
                        foreach (string s in teams)
                        {
                            HelperMethods.MakeGameTeam(txtName.Text, s);
                        }
                    }

                    //now lets do the actual Updating cause we dont want to delete the game table entry
                    HelperMethods.UpdateTables(txtName.Text, txtFranchise.Text, Int32.Parse(txtYear.Text), Int32.Parse(txtRating.Text), Int32.Parse(txtCopiesSold.Text));

                    MessageBox.Show("Table Updated");

                    #endregion
                }

                else if (GamePlatformCount == 0) //game does not exist so add
                {
                #region AddGame
                //lets check and see if all the parts needed exist. If they do not, add them
                    if (txtFranchise.Text != "")
                    {
                        if (HelperMethods.CheckForFranchise(txtFranchise.Text) == 0) //if Franchise does not exist
                        {//add it
                            HelperMethods.AddFranchise(txtFranchise.Text);
                        }
                    }
                    if (txtGenre.Text != "")
                    {
                        genres = txtGenre.Text.Split(',');
                        foreach (string g in genres)
                        {
                            if (HelperMethods.CheckForGenre(g) == 0) //if genre does not exist
                            {//add it
                                HelperMethods.AddGenre(g);
                            }
                        }
                    }
                    if (txtDevelopmentTeam.Text != "")
                    {
                        teams = txtDevelopmentTeam.Text.Split(',');
                        foreach (string t in teams)
                        {
                            if (HelperMethods.CheckForTeam(t) == 0) //if team does not exist
                            {//add it
                                HelperMethods.AddTeam(t);
                            }
                        }
                    }

                    //lets add the platform real quick if its not there already
                    if (HelperMethods.CheckForPlatform(txtPlatform.Text) == 0)
                    {
                        HelperMethods.AddPlatform(txtPlatform.Text);
                    }//this will prompt for manufacturer if adding

                    //next lets add the game itself
                    //we already know the game does not exist at least with this platform combo so we can add it as new
                    HelperMethods.AddGame(txtName.Text, txtFranchise.Text);

                    //we shall now add the relations to thier respective tables

                    //platform first cause this will take the longest and its got all those properties
                    HelperMethods.MakeGamePlatform(txtName.Text, txtPlatform.Text, Int32.Parse(txtYear.Text), Int32.Parse(txtRating.Text), Int32.Parse(txtCopiesSold.Text));
                    //next is GameGenre
                    if (txtGenre.Text != "")
                    {
                        foreach (string s in genres)
                        {
                            HelperMethods.MakeGameGenre(txtName.Text, s);
                        }
                    }
                    //finally we do GameTeam
                    if (txtDevelopmentTeam.Text != "")
                    {
                        foreach (string s in teams)
                        {
                            HelperMethods.MakeGameTeam(txtName.Text, s);
                        }
                    }

                    MessageBox.Show("Game Added");
                    #endregion
                }

                //else //more than one was returned, which shouldnt happen
                //{
                //    throw new Exception("More than one Game was returned, or it came back negative");
                //}
            }
            else //boxes are empty oops
            {
                MessageBox.Show("Name and/or Platform are Empty");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String query;

            String name = txtName.Text;

            query = "delete " +
                    "from Sega.GamePlatform " +
                    "where GameId in " +
                    "( " +
                        "select G.GameID " +
                        "from  Sega.Game G " +
                        $"where G.Name = '{name}' " +
                    ") " +
                    "delete " +
                    "from Sega.GameGenre " +
                    "where GameId in " +
                    "( " +
                        "select G.GameID " +
                        "from  Sega.Game G " +
                        $"where G.Name = '{name}' " +
                    ") " +
                    "delete " +
                    "from Sega.GameTeam " +
                    "where GameId in " +
                    "( " +
                        "select G.GameID " +
                        "from  Sega.Game G " +
                        $"where G.Name = '{name}' " +
                    ") " +

                    "delete from Sega.Game " +
                    $"where Name = '{name}' ";


            
            grdResults.DataSource = HelperMethods.RunQuery(query);
            MessageBox.Show("Deleted");
        }
    }
}