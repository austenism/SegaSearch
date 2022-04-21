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

namespace SegaSearch
{
    public partial class MainWindow : Form
    {

        string connetionString;
        System.Data.SqlClient.SqlConnection cnn;

        public MainWindow()
        {
            InitializeComponent(); 
            //login stuff for the database
            connetionString = 
                @"Data Source=WIN-mssql.cs.ksu.edu;
                    Initial Catalog=cis560_team19;
                    User ID=austenism;
                    Password=joelsuxlol42069";
            
            cnn = new SqlConnection(connetionString);
           
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
    }
}