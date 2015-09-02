namespace FQ.DbScrambler
{
    partial class DbScrambler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tvDBStructure = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerateScramblingSql = new System.Windows.Forms.Button();
            this.rtbScramlingSql = new System.Windows.Forms.RichTextBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.chbIntegratedAuthentication = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.gbSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.label4);
            this.gbSettings.Controls.Add(this.tbUser);
            this.gbSettings.Controls.Add(this.chbIntegratedAuthentication);
            this.gbSettings.Controls.Add(this.btnTestConnection);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.tbPassword);
            this.gbSettings.Controls.Add(this.tbDatabase);
            this.gbSettings.Controls.Add(this.tbServer);
            this.gbSettings.Controls.Add(this.btnLoad);
            this.gbSettings.Location = new System.Drawing.Point(12, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbSettings.Size = new System.Drawing.Size(955, 63);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "DB Connection";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(50, 30);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(88, 20);
            this.tbServer.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(874, 28);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tvDBStructure
            // 
            this.tvDBStructure.CheckBoxes = true;
            this.tvDBStructure.Location = new System.Drawing.Point(6, 29);
            this.tvDBStructure.Name = "tvDBStructure";
            this.tvDBStructure.Size = new System.Drawing.Size(299, 443);
            this.tvDBStructure.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvDBStructure);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(309, 478);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB Structure";
            // 
            // btnGenerateScramblingSql
            // 
            this.btnGenerateScramblingSql.Location = new System.Drawing.Point(6, 29);
            this.btnGenerateScramblingSql.Name = "btnGenerateScramblingSql";
            this.btnGenerateScramblingSql.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateScramblingSql.TabIndex = 4;
            this.btnGenerateScramblingSql.Text = "Generate Scrambling SQL";
            this.btnGenerateScramblingSql.UseVisualStyleBackColor = true;
            this.btnGenerateScramblingSql.Click += new System.EventHandler(this.btnGenerateScramblingSql_Click);
            // 
            // rtbScramlingSql
            // 
            this.rtbScramlingSql.Location = new System.Drawing.Point(6, 58);
            this.rtbScramlingSql.Name = "rtbScramlingSql";
            this.rtbScramlingSql.Size = new System.Drawing.Size(634, 414);
            this.rtbScramlingSql.TabIndex = 3;
            this.rtbScramlingSql.Text = "";
            // 
            // tbDatabase
            // 
            this.tbDatabase.Location = new System.Drawing.Point(217, 30);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(93, 20);
            this.tbDatabase.TabIndex = 2;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(663, 30);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(87, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Database";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(604, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGenerateScramblingSql);
            this.groupBox2.Controls.Add(this.rtbScramlingSql);
            this.groupBox2.Location = new System.Drawing.Point(327, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(640, 478);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scrambling SQL";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(771, 28);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(97, 23);
            this.btnTestConnection.TabIndex = 7;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // chbIntegratedAuthentication
            // 
            this.chbIntegratedAuthentication.AutoSize = true;
            this.chbIntegratedAuthentication.Location = new System.Drawing.Point(321, 32);
            this.chbIntegratedAuthentication.Name = "chbIntegratedAuthentication";
            this.chbIntegratedAuthentication.Size = new System.Drawing.Size(145, 17);
            this.chbIntegratedAuthentication.TabIndex = 8;
            this.chbIntegratedAuthentication.Text = "Integrated Authentication";
            this.chbIntegratedAuthentication.UseVisualStyleBackColor = true;
            this.chbIntegratedAuthentication.CheckedChanged += new System.EventHandler(this.chbIntegratedAuthentication_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(474, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "User";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(510, 30);
            this.tbUser.Name = "tbUser";
            this.tbUser.PasswordChar = '*';
            this.tbUser.Size = new System.Drawing.Size(87, 20);
            this.tbUser.TabIndex = 9;
            // 
            // DbScrambler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 565);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSettings);
            this.Name = "DbScrambler";
            this.Text = "1stQuad Data Scrambling Tool";
            this.Load += new System.EventHandler(this.DbScrambler_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TreeView tvDBStructure;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbScramlingSql;
        private System.Windows.Forms.Button btnGenerateScramblingSql;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.CheckBox chbIntegratedAuthentication;
    }
}

