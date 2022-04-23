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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
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
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(255, 512);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add or Modify Games on the List";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(5, 482);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(94, 22);
            this.AddButton.TabIndex = 19;
            this.AddButton.Text = "Add/Modify";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "If a game\'s Name and Release Year match with one on the database, the game will b" +
    "e treated as the same game and update it accordingly";
            // 
            // txtCopiesSold
            // 
            this.txtCopiesSold.Location = new System.Drawing.Point(5, 166);
            this.txtCopiesSold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCopiesSold.Name = "txtCopiesSold";
            this.txtCopiesSold.Size = new System.Drawing.Size(245, 23);
            this.txtCopiesSold.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "CopiesSold";
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(5, 127);
            this.txtRating.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(245, 23);
            this.txtRating.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "MetaCritic Rating (0-100)";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(5, 87);
            this.txtYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(245, 23);
            this.txtYear.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Release Year";
            // 
            // txtDevelopmentTeam
            // 
            this.txtDevelopmentTeam.Location = new System.Drawing.Point(5, 386);
            this.txtDevelopmentTeam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDevelopmentTeam.Name = "txtDevelopmentTeam";
            this.txtDevelopmentTeam.Size = new System.Drawing.Size(245, 23);
            this.txtDevelopmentTeam.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(5, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(244, 37);
            this.label7.TabIndex = 11;
            this.label7.Text = "Development Team(s) - Separated By Commas";
            // 
            // txtPlatform
            // 
            this.txtPlatform.Location = new System.Drawing.Point(5, 325);
            this.txtPlatform.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlatform.Name = "txtPlatform";
            this.txtPlatform.Size = new System.Drawing.Size(245, 23);
            this.txtPlatform.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Platform(s) - Separated By Commas";
            // 
            // txtCharacters
            // 
            this.txtCharacters.Location = new System.Drawing.Point(5, 245);
            this.txtCharacters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCharacters.Name = "txtCharacters";
            this.txtCharacters.Size = new System.Drawing.Size(245, 23);
            this.txtCharacters.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Character(s) - Separated By Commas";
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(5, 285);
            this.txtGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(245, 23);
            this.txtGenre.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Genre(s) - Separated by Commas";
            // 
            // txtFranchise
            // 
            this.txtFranchise.Location = new System.Drawing.Point(5, 206);
            this.txtFranchise.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFranchise.Name = "txtFranchise";
            this.txtFranchise.Size = new System.Drawing.Size(245, 23);
            this.txtFranchise.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Franchise";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(5, 47);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(245, 23);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnQuery);
            this.groupBox2.Controls.Add(this.RangeChoices);
            this.groupBox2.Controls.Add(this.GroupByChoices);
            this.groupBox2.Controls.Add(this.SortingChoices);
            this.groupBox2.Location = new System.Drawing.Point(270, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(256, 512);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query List of Games";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(5, 482);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(82, 22);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "Query!";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // RangeChoices
            // 
            this.RangeChoices.Location = new System.Drawing.Point(5, 278);
            this.RangeChoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RangeChoices.Name = "RangeChoices";
            this.RangeChoices.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RangeChoices.Size = new System.Drawing.Size(216, 168);
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
            this.GroupByChoices.Location = new System.Drawing.Point(5, 20);
            this.GroupByChoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupByChoices.Name = "GroupByChoices";
            this.GroupByChoices.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupByChoices.Size = new System.Drawing.Size(200, 136);
            this.GroupByChoices.TabIndex = 2;
            this.GroupByChoices.TabStop = false;
            this.GroupByChoices.Text = "Group By:";
            // 
            // btnFranchise
            // 
            this.btnFranchise.AutoSize = true;
            this.btnFranchise.Location = new System.Drawing.Point(5, 20);
            this.btnFranchise.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFranchise.Name = "btnFranchise";
            this.btnFranchise.Size = new System.Drawing.Size(76, 19);
            this.btnFranchise.TabIndex = 2;
            this.btnFranchise.Text = "Franchise";
            this.btnFranchise.UseVisualStyleBackColor = true;
            this.btnFranchise.CheckedChanged += new System.EventHandler(this.btnFranchise_CheckedChanged);
            // 
            // btnDevelopmentTeam
            // 
            this.btnDevelopmentTeam.AutoSize = true;
            this.btnDevelopmentTeam.Location = new System.Drawing.Point(5, 110);
            this.btnDevelopmentTeam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDevelopmentTeam.Name = "btnDevelopmentTeam";
            this.btnDevelopmentTeam.Size = new System.Drawing.Size(128, 19);
            this.btnDevelopmentTeam.TabIndex = 6;
            this.btnDevelopmentTeam.Text = "Development Team";
            this.btnDevelopmentTeam.UseVisualStyleBackColor = true;
            this.btnDevelopmentTeam.CheckedChanged += new System.EventHandler(this.btnDevelopmentTeam_CheckedChanged);
            // 
            // btnCharacters
            // 
            this.btnCharacters.AutoSize = true;
            this.btnCharacters.Location = new System.Drawing.Point(5, 42);
            this.btnCharacters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCharacters.Name = "btnCharacters";
            this.btnCharacters.Size = new System.Drawing.Size(82, 19);
            this.btnCharacters.TabIndex = 3;
            this.btnCharacters.Text = "Characters";
            this.btnCharacters.UseVisualStyleBackColor = true;
            this.btnCharacters.CheckedChanged += new System.EventHandler(this.btnCharacters_CheckedChanged);
            // 
            // btnPlatform
            // 
            this.btnPlatform.AutoSize = true;
            this.btnPlatform.Location = new System.Drawing.Point(5, 87);
            this.btnPlatform.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPlatform.Name = "btnPlatform";
            this.btnPlatform.Size = new System.Drawing.Size(72, 19);
            this.btnPlatform.TabIndex = 5;
            this.btnPlatform.Text = "Platform";
            this.btnPlatform.UseVisualStyleBackColor = true;
            this.btnPlatform.CheckedChanged += new System.EventHandler(this.btnPlatform_CheckedChanged);
            // 
            // btnGenre
            // 
            this.btnGenre.AutoSize = true;
            this.btnGenre.Location = new System.Drawing.Point(5, 64);
            this.btnGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenre.Name = "btnGenre";
            this.btnGenre.Size = new System.Drawing.Size(57, 19);
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
            this.SortingChoices.Location = new System.Drawing.Point(5, 160);
            this.SortingChoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SortingChoices.Name = "SortingChoices";
            this.SortingChoices.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SortingChoices.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SortingChoices.Size = new System.Drawing.Size(228, 113);
            this.SortingChoices.TabIndex = 8;
            this.SortingChoices.TabStop = false;
            this.SortingChoices.Text = "Sort By:";
            // 
            // btnYear
            // 
            this.btnYear.AutoSize = true;
            this.btnYear.Location = new System.Drawing.Point(5, 87);
            this.btnYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(198, 19);
            this.btnYear.TabIndex = 3;
            this.btnYear.TabStop = true;
            this.btnYear.Text = "Release Year (Only if Ungrouped)";
            this.btnYear.UseVisualStyleBackColor = true;
            // 
            // btnCopiesSold
            // 
            this.btnCopiesSold.AutoSize = true;
            this.btnCopiesSold.Location = new System.Drawing.Point(5, 64);
            this.btnCopiesSold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopiesSold.Name = "btnCopiesSold";
            this.btnCopiesSold.Size = new System.Drawing.Size(87, 19);
            this.btnCopiesSold.TabIndex = 2;
            this.btnCopiesSold.TabStop = true;
            this.btnCopiesSold.Text = "Copies Sold";
            this.btnCopiesSold.UseVisualStyleBackColor = true;
            // 
            // btnRating
            // 
            this.btnRating.AutoSize = true;
            this.btnRating.Location = new System.Drawing.Point(5, 42);
            this.btnRating.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRating.Name = "btnRating";
            this.btnRating.Size = new System.Drawing.Size(172, 19);
            this.btnRating.TabIndex = 1;
            this.btnRating.TabStop = true;
            this.btnRating.Text = "Rating (Average if Grouped)";
            this.btnRating.UseVisualStyleBackColor = true;
            // 
            // btnName
            // 
            this.btnName.AutoSize = true;
            this.btnName.Location = new System.Drawing.Point(5, 20);
            this.btnName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(57, 19);
            this.btnName.TabIndex = 0;
            this.btnName.TabStop = true;
            this.btnName.Text = "Name";
            this.btnName.UseVisualStyleBackColor = true;
            // 
            // grdResults
            // 
            this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResults.Location = new System.Drawing.Point(531, 15);
            this.grdResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdResults.Name = "grdResults";
            this.grdResults.RowHeadersWidth = 51;
            this.grdResults.RowTemplate.Height = 29;
            this.grdResults.Size = new System.Drawing.Size(612, 506);
            this.grdResults.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 528);
            this.Controls.Add(this.grdResults);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private Button btnQuery;
        private Button AddButton;
    }
}