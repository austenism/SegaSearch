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
            //login stuff for the database
            connetionString =
                @"Data Source=mssql.cs.ksu.edu;
                    Initial Catalog=WideWorldImporters;
                    User ID=austenism;
                    Password=joelsuxlol42069";
            //cis560_team19
           
        }
        #region CheckBoxes CheckChanged Groups
        private void btnFranchise_CheckedChanged(object sender, EventArgs e)
        {
            if (btnFranchise.Checked)
            {
                if (btnYear.Checked)
                    btnYear.Checked = false;
                btnYear.Enabled = false;
            }
            else
            {
                bool allUnchecked = true;
                foreach(CheckBox cb in GroupByChoices.Controls)
                {
                    if (cb.Checked)
                        allUnchecked = false;
                }
                if (allUnchecked)
                {
                    btnYear.Enabled = true;
                }
            }
        }

        private void btnCharacters_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCharacters.Checked)
            {
                if (btnYear.Checked)
                    btnYear.Checked = false;
                btnYear.Enabled = false;
            }
            else
            {
                bool allUnchecked = true;
                foreach (CheckBox cb in GroupByChoices.Controls)
                {
                    if (cb.Checked)
                        allUnchecked = false;
                }
                if (allUnchecked)
                {
                    btnYear.Enabled = true;
                }
            }
        }

        private void btnGenre_CheckedChanged(object sender, EventArgs e)
        {
            if (btnGenre.Checked)
            {
                if (btnYear.Checked)
                    btnYear.Checked = false;
                btnYear.Enabled = false;
            }
            else
            {
                bool allUnchecked = true;
                foreach (CheckBox cb in GroupByChoices.Controls)
                {
                    if (cb.Checked)
                        allUnchecked = false;
                }
                if (allUnchecked)
                {
                    btnYear.Enabled = true;
                }
            }
        }

        private void btnPlatform_CheckedChanged(object sender, EventArgs e)
        {
            if (btnPlatform.Checked)
            {
                if (btnYear.Checked)
                    btnYear.Checked = false;
                btnYear.Enabled = false;
            }
            else
            {
                bool allUnchecked = true;
                foreach (CheckBox cb in GroupByChoices.Controls)
                {
                    if (cb.Checked)
                        allUnchecked = false;
                }
                if (allUnchecked)
                {
                    btnYear.Enabled = true;
                }
            }
        }

        private void btnDevelopmentTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDevelopmentTeam.Checked)
            {
                if (btnYear.Checked)
                    btnYear.Checked = false;
                btnYear.Enabled = false;
            }
            else
            {
                bool allUnchecked = true;
                foreach (CheckBox cb in GroupByChoices.Controls)
                {
                    if (cb.Checked)
                        allUnchecked = false;
                }
                if (allUnchecked)
                {
                    btnYear.Enabled = true;
                }
            }
        }

        #endregion

        private void btnQuery_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connetionString)) 
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Sales.Customers", sqlCon);
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
                    "WHERE G.[Name] = " + txtName + " AND YEAR(GP.ReleaseDate) = " + txtYear, sqlCon);
                DataTable dtbl = new DataTable();
                if(sqlDa.Fill(dtbl) >= 1)
                {
                    sqlDa = new SqlDataAdapter("WITH SourceCTE (GameID, FranchiseID, ReleaseDate) AS" +
                        "(SELECT G.GameID, G.FranchiseID, GP.ReleaseDate" +
                        "FROM Sega.Game G" +
                        "   INNER JOIN Sega.GamePlateform GP ON GP.GameID = G.GameID" +
                        "WHERE G.[Name] = " + txtName + " AND YEAR(GP.ReleaseDate) = " + txtYear + ")" +
                        "UPDATE Sega.Game" + "SET    QuantitySold = " + txtCopiesSold + "FROM SourceCTE S" +
                        "WHERE GameID = S.GameID;" +
                        "UPDATE Sega.GamePlatform" + "SET    Rating = " + txtRating + "FROM SourceCTE S" +
                        "WHERE GameID = S.GameID;" +
                        "UPDATE Sega.Franchise" + "SET    [Name] = " + txtFranchise + "FROM SourceCTE S" +
                        "WHERE FranchiseID = S.FranchiseID AND[Name] <> " + txtFranchise + ";", sqlCon);
                }
            }
        }
    }
}