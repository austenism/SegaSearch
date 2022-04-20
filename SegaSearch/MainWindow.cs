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
            //fix this later once the database is properly set up
            /*connetionString = 
                @"Data Source=WIN-50GP30FGO75;
                    Initial Catalog=Demodb;
                    User ID=sa;
                    Password=demol23";
            
            cnn = new SqlConnection(connetionString);
           */
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