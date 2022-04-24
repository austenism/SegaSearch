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
            this.AddButton = new System.Windows.Forms.Button();
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
            this.grdResults = new System.Windows.Forms.DataGridView();
            this.GroupByChoices = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnGame = new System.Windows.Forms.RadioButton();
            this.RangeChoices = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.GroupByChoices.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddButton);
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
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 683);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add or Modify Games on the List";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(6, 643);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(107, 29);
            this.AddButton.TabIndex = 19;
            this.AddButton.Text = "Add/Modify";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
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
            this.txtCopiesSold.Location = new System.Drawing.Point(6, 221);
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
            this.label9.Location = new System.Drawing.Point(6, 147);
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
            this.label6.Location = new System.Drawing.Point(6, 411);
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
            // grdResults
            // 
            this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResults.Location = new System.Drawing.Point(607, 20);
            this.grdResults.Name = "grdResults";
            this.grdResults.RowHeadersWidth = 51;
            this.grdResults.RowTemplate.Height = 29;
            this.grdResults.Size = new System.Drawing.Size(883, 675);
            this.grdResults.TabIndex = 2;
            // 
            // GroupByChoices
            // 
            this.GroupByChoices.Controls.Add(this.txtSearch);
            this.GroupByChoices.Controls.Add(this.radioButton1);
            this.GroupByChoices.Controls.Add(this.btnGame);
            this.GroupByChoices.Location = new System.Drawing.Point(6, 26);
            this.GroupByChoices.Name = "GroupByChoices";
            this.GroupByChoices.Size = new System.Drawing.Size(229, 276);
            this.GroupByChoices.TabIndex = 2;
            this.GroupByChoices.TabStop = false;
            this.GroupByChoices.Text = "Group By:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 243);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(217, 27);
            this.txtSearch.TabIndex = 11;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 56);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(117, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnGame
            // 
            this.btnGame.AutoSize = true;
            this.btnGame.Location = new System.Drawing.Point(6, 26);
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(69, 24);
            this.btnGame.TabIndex = 0;
            this.btnGame.TabStop = true;
            this.btnGame.Text = "Game";
            this.btnGame.UseVisualStyleBackColor = true;
            // 
            // RangeChoices
            // 
            this.RangeChoices.Location = new System.Drawing.Point(6, 371);
            this.RangeChoices.Name = "RangeChoices";
            this.RangeChoices.Size = new System.Drawing.Size(247, 224);
            this.RangeChoices.TabIndex = 9;
            this.RangeChoices.TabStop = false;
            this.RangeChoices.Text = "Ranges (MaybeImplementIDK)";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(6, 643);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(94, 29);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "Query!";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnQuery);
            this.groupBox2.Controls.Add(this.RangeChoices);
            this.groupBox2.Controls.Add(this.GroupByChoices);
            this.groupBox2.Location = new System.Drawing.Point(309, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 683);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query List of Games";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 704);
            this.Controls.Add(this.grdResults);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "SegaSearch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.GroupByChoices.ResumeLayout(false);
            this.GroupByChoices.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
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
        private Button AddButton;
        private GroupBox GroupByChoices;
        private RadioButton btnGame;
        private GroupBox RangeChoices;
        private Button btnQuery;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private TextBox txtSearch;
    }
}