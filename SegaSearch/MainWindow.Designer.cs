namespace SegaSearch
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCopiesSold = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDevelopmentTeam = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPlatform = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCharacters = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFranchise = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RangeChoices = new System.Windows.Forms.GroupBox();
            this.GroupByChoices = new System.Windows.Forms.GroupBox();
            this.btnFranchise = new System.Windows.Forms.CheckBox();
            this.btnDevelopmentTeam = new System.Windows.Forms.CheckBox();
            this.btnCharacters = new System.Windows.Forms.CheckBox();
            this.btnPlatform = new System.Windows.Forms.CheckBox();
            this.btnGenre = new System.Windows.Forms.CheckBox();
            this.SortingChoices = new System.Windows.Forms.GroupBox();
            this.btnYear = new System.Windows.Forms.RadioButton();
            this.btnCopiesSold = new System.Windows.Forms.RadioButton();
            this.btnRating = new System.Windows.Forms.RadioButton();
            this.btnName = new System.Windows.Forms.RadioButton();
            this.grdResults = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GroupByChoices.SuspendLayout();
            this.SortingChoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCopiesSold);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtRating);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDevelopmentTeam);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPlatform);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCharacters);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGenre);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFranchise);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 637);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add or Modify Games on the List";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 552);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 88);
            this.label1.TabIndex = 0;
            this.label1.Text = "If a game\'s Name and Release Year match with one on the database, the game will b" +
    "e treated as the same game and update it accordingly";
            // 
            // txtCopiesSold
            // 
            this.txtCopiesSold.Location = new System.Drawing.Point(6, 222);
            this.txtCopiesSold.Name = "txtCopiesSold";
            this.txtCopiesSold.Size = new System.Drawing.Size(279, 27);
            this.txtCopiesSold.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "CopiesSold";
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(6, 169);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(279, 27);
            this.txtRating.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "MetaCritic Rating (0-100)";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(6, 116);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(279, 27);
            this.txtYear.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Release Year";
            // 
            // txtDevelopmentTeam
            // 
            this.txtDevelopmentTeam.Location = new System.Drawing.Point(6, 515);
            this.txtDevelopmentTeam.Name = "txtDevelopmentTeam";
            this.txtDevelopmentTeam.Size = new System.Drawing.Size(279, 27);
            this.txtDevelopmentTeam.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(279, 49);
            this.label7.TabIndex = 11;
            this.label7.Text = "Development Team(s) - Separated By Commas";
            // 
            // txtPlatform
            // 
            this.txtPlatform.Location = new System.Drawing.Point(6, 433);
            this.txtPlatform.Name = "txtPlatform";
            this.txtPlatform.Size = new System.Drawing.Size(279, 27);
            this.txtPlatform.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Platform(s) - Separated By Commas";
            // 
            // txtCharacters
            // 
            this.txtCharacters.Location = new System.Drawing.Point(6, 327);
            this.txtCharacters.Name = "txtCharacters";
            this.txtCharacters.Size = new System.Drawing.Size(279, 27);
            this.txtCharacters.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Character(s) - Separated By Commas";
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(6, 380);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(279, 27);
            this.txtGenre.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Genre(s) - Separated by Commas";
            // 
            // txtFranchise
            // 
            this.txtFranchise.Location = new System.Drawing.Point(6, 275);
            this.txtFranchise.Name = "txtFranchise";
            this.txtFranchise.Size = new System.Drawing.Size(279, 27);
            this.txtFranchise.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Franchise";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 27);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RangeChoices);
            this.groupBox2.Controls.Add(this.GroupByChoices);
            this.groupBox2.Controls.Add(this.SortingChoices);
            this.groupBox2.Location = new System.Drawing.Point(309, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 640);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query List of Games";
            // 
            // RangeChoices
            // 
            this.RangeChoices.Location = new System.Drawing.Point(6, 371);
            this.RangeChoices.Name = "RangeChoices";
            this.RangeChoices.Size = new System.Drawing.Size(250, 199);
            this.RangeChoices.TabIndex = 9;
            this.RangeChoices.TabStop = false;
            this.RangeChoices.Text = "Ranges (MaybeImplementIDK)";
            // 
            // GroupByChoices
            // 
            this.GroupByChoices.Controls.Add(this.btnFranchise);
            this.GroupByChoices.Controls.Add(this.btnDevelopmentTeam);
            this.GroupByChoices.Controls.Add(this.btnCharacters);
            this.GroupByChoices.Controls.Add(this.btnPlatform);
            this.GroupByChoices.Controls.Add(this.btnGenre);
            this.GroupByChoices.Location = new System.Drawing.Point(6, 26);
            this.GroupByChoices.Name = "GroupByChoices";
            this.GroupByChoices.Size = new System.Drawing.Size(229, 182);
            this.GroupByChoices.TabIndex = 2;
            this.GroupByChoices.TabStop = false;
            this.GroupByChoices.Text = "Group By:";
            // 
            // btnFranchise
            // 
            this.btnFranchise.AutoSize = true;
            this.btnFranchise.Location = new System.Drawing.Point(6, 26);
            this.btnFranchise.Name = "btnFranchise";
            this.btnFranchise.Size = new System.Drawing.Size(92, 24);
            this.btnFranchise.TabIndex = 2;
            this.btnFranchise.Text = "Franchise";
            this.btnFranchise.UseVisualStyleBackColor = true;
            this.btnFranchise.CheckedChanged += new System.EventHandler(this.btnFranchise_CheckedChanged);
            // 
            // btnDevelopmentTeam
            // 
            this.btnDevelopmentTeam.AutoSize = true;
            this.btnDevelopmentTeam.Location = new System.Drawing.Point(6, 146);
            this.btnDevelopmentTeam.Name = "btnDevelopmentTeam";
            this.btnDevelopmentTeam.Size = new System.Drawing.Size(161, 24);
            this.btnDevelopmentTeam.TabIndex = 6;
            this.btnDevelopmentTeam.Text = "Development Team";
            this.btnDevelopmentTeam.UseVisualStyleBackColor = true;
            this.btnDevelopmentTeam.CheckedChanged += new System.EventHandler(this.btnDevelopmentTeam_CheckedChanged);
            // 
            // btnCharacters
            // 
            this.btnCharacters.AutoSize = true;
            this.btnCharacters.Location = new System.Drawing.Point(6, 56);
            this.btnCharacters.Name = "btnCharacters";
            this.btnCharacters.Size = new System.Drawing.Size(100, 24);
            this.btnCharacters.TabIndex = 3;
            this.btnCharacters.Text = "Characters";
            this.btnCharacters.UseVisualStyleBackColor = true;
            this.btnCharacters.CheckedChanged += new System.EventHandler(this.btnCharacters_CheckedChanged);
            // 
            // btnPlatform
            // 
            this.btnPlatform.AutoSize = true;
            this.btnPlatform.Location = new System.Drawing.Point(6, 116);
            this.btnPlatform.Name = "btnPlatform";
            this.btnPlatform.Size = new System.Drawing.Size(88, 24);
            this.btnPlatform.TabIndex = 5;
            this.btnPlatform.Text = "Platform";
            this.btnPlatform.UseVisualStyleBackColor = true;
            this.btnPlatform.CheckedChanged += new System.EventHandler(this.btnPlatform_CheckedChanged);
            // 
            // btnGenre
            // 
            this.btnGenre.AutoSize = true;
            this.btnGenre.Location = new System.Drawing.Point(6, 86);
            this.btnGenre.Name = "btnGenre";
            this.btnGenre.Size = new System.Drawing.Size(70, 24);
            this.btnGenre.TabIndex = 4;
            this.btnGenre.Text = "Genre";
            this.btnGenre.UseVisualStyleBackColor = true;
            this.btnGenre.CheckedChanged += new System.EventHandler(this.btnGenre_CheckedChanged);
            // 
            // SortingChoices
            // 
            this.SortingChoices.Controls.Add(this.btnYear);
            this.SortingChoices.Controls.Add(this.btnCopiesSold);
            this.SortingChoices.Controls.Add(this.btnRating);
            this.SortingChoices.Controls.Add(this.btnName);
            this.SortingChoices.Location = new System.Drawing.Point(6, 214);
            this.SortingChoices.Name = "SortingChoices";
            this.SortingChoices.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SortingChoices.Size = new System.Drawing.Size(260, 151);
            this.SortingChoices.TabIndex = 8;
            this.SortingChoices.TabStop = false;
            this.SortingChoices.Text = "Sort By:";
            // 
            // btnYear
            // 
            this.btnYear.AutoSize = true;
            this.btnYear.Location = new System.Drawing.Point(6, 116);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(249, 24);
            this.btnYear.TabIndex = 3;
            this.btnYear.TabStop = true;
            this.btnYear.Text = "Release Year (Only if Ungrouped)";
            this.btnYear.UseVisualStyleBackColor = true;
            // 
            // btnCopiesSold
            // 
            this.btnCopiesSold.AutoSize = true;
            this.btnCopiesSold.Location = new System.Drawing.Point(6, 86);
            this.btnCopiesSold.Name = "btnCopiesSold";
            this.btnCopiesSold.Size = new System.Drawing.Size(109, 24);
            this.btnCopiesSold.TabIndex = 2;
            this.btnCopiesSold.TabStop = true;
            this.btnCopiesSold.Text = "Copies Sold";
            this.btnCopiesSold.UseVisualStyleBackColor = true;
            // 
            // btnRating
            // 
            this.btnRating.AutoSize = true;
            this.btnRating.Location = new System.Drawing.Point(6, 56);
            this.btnRating.Name = "btnRating";
            this.btnRating.Size = new System.Drawing.Size(217, 24);
            this.btnRating.TabIndex = 1;
            this.btnRating.TabStop = true;
            this.btnRating.Text = "Rating (Average if Grouped)";
            this.btnRating.UseVisualStyleBackColor = true;
            // 
            // btnName
            // 
            this.btnName.AutoSize = true;
            this.btnName.Location = new System.Drawing.Point(6, 26);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(70, 24);
            this.btnName.TabIndex = 0;
            this.btnName.TabStop = true;
            this.btnName.Text = "Name";
            this.btnName.UseVisualStyleBackColor = true;
            // 
            // grdResults
            // 
            this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResults.Location = new System.Drawing.Point(607, 20);
            this.grdResults.Name = "grdResults";
            this.grdResults.RowHeadersWidth = 51;
            this.grdResults.RowTemplate.Height = 29;
            this.grdResults.Size = new System.Drawing.Size(440, 632);
            this.grdResults.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 654);
            this.Controls.Add(this.grdResults);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "SegaSearch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.GroupByChoices.ResumeLayout(false);
            this.GroupByChoices.PerformLayout();
            this.SortingChoices.ResumeLayout(false);
            this.SortingChoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox btnDevelopmentTeam;
        private CheckBox btnPlatform;
        private CheckBox btnGenre;
        private CheckBox btnCharacters;
        private CheckBox btnFranchise;
        private GroupBox SortingChoices;
        private RadioButton btnRating;
        private RadioButton btnName;
        private GroupBox GroupByChoices;
        private RadioButton btnYear;
        private RadioButton btnCopiesSold;
        private Label label1;
        private GroupBox RangeChoices;
        private TextBox txtFranchise;
        private Label label3;
        private TextBox txtName;
        private Label label2;
        private TextBox txtCopiesSold;
        private Label label10;
        private TextBox txtRating;
        private Label label9;
        private TextBox txtYear;
        private Label label8;
        private TextBox txtDevelopmentTeam;
        private Label label7;
        private TextBox txtPlatform;
        private Label label6;
        private TextBox txtCharacters;
        private Label label5;
        private TextBox txtGenre;
        private Label label4;
        private DataGridView grdResults;
    }
}