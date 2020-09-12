namespace PréfacturationWiilog
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filialeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomclientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montantmensuelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modifier = new System.Windows.Forms.DataGridViewButtonColumn();
            this.eNTComptesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sélectionnerLeFichierDactivitéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramétrageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNTComptesBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.filialeDataGridViewTextBoxColumn,
            this.nomclientDataGridViewTextBoxColumn,
            this.montantmensuelDataGridViewTextBoxColumn,
            this.Contact,
            this.Email,
            this.Modifier});
            this.dataGridView1.DataSource = this.eNTComptesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(11, 101);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(786, 311);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // filialeDataGridViewTextBoxColumn
            // 
            this.filialeDataGridViewTextBoxColumn.DataPropertyName = "Filiale";
            this.filialeDataGridViewTextBoxColumn.HeaderText = "Filiale";
            this.filialeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.filialeDataGridViewTextBoxColumn.Name = "filialeDataGridViewTextBoxColumn";
            this.filialeDataGridViewTextBoxColumn.ReadOnly = true;
            this.filialeDataGridViewTextBoxColumn.Width = 125;
            // 
            // nomclientDataGridViewTextBoxColumn
            // 
            this.nomclientDataGridViewTextBoxColumn.DataPropertyName = "Nomclient";
            this.nomclientDataGridViewTextBoxColumn.HeaderText = "Nom client";
            this.nomclientDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomclientDataGridViewTextBoxColumn.Name = "nomclientDataGridViewTextBoxColumn";
            this.nomclientDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomclientDataGridViewTextBoxColumn.Width = 125;
            // 
            // montantmensuelDataGridViewTextBoxColumn
            // 
            this.montantmensuelDataGridViewTextBoxColumn.DataPropertyName = "Montantmensuel";
            this.montantmensuelDataGridViewTextBoxColumn.HeaderText = "Montant Mensuel";
            this.montantmensuelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.montantmensuelDataGridViewTextBoxColumn.Name = "montantmensuelDataGridViewTextBoxColumn";
            this.montantmensuelDataGridViewTextBoxColumn.ReadOnly = true;
            this.montantmensuelDataGridViewTextBoxColumn.Width = 125;
            // 
            // Contact
            // 
            this.Contact.DataPropertyName = "Contact";
            this.Contact.HeaderText = "Contact";
            this.Contact.MinimumWidth = 6;
            this.Contact.Name = "Contact";
            this.Contact.ReadOnly = true;
            this.Contact.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 125;
            // 
            // Modifier
            // 
            this.Modifier.HeaderText = "Modifier";
            this.Modifier.MinimumWidth = 6;
            this.Modifier.Name = "Modifier";
            this.Modifier.ReadOnly = true;
            this.Modifier.Text = "Modifier";
            this.Modifier.ToolTipText = "Mod";
            this.Modifier.Width = 125;
            // 
            // eNTComptesBindingSource
            // 
            this.eNTComptesBindingSource.DataSource = typeof(PréfacturationWiilog.ENT_Comptes);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(592, 52);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "Générer factures";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sélection du mois";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sélectionnerLeFichierDactivitéToolStripMenuItem,
            this.paramétrageToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // sélectionnerLeFichierDactivitéToolStripMenuItem
            // 
            this.sélectionnerLeFichierDactivitéToolStripMenuItem.Name = "sélectionnerLeFichierDactivitéToolStripMenuItem";
            this.sélectionnerLeFichierDactivitéToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.sélectionnerLeFichierDactivitéToolStripMenuItem.Text = "Importer le fichier d\'activité CSV";
            this.sélectionnerLeFichierDactivitéToolStripMenuItem.Click += new System.EventHandler(this.SélectionnerLeFichierDactivitéToolStripMenuItem_Click);
            // 
            // paramétrageToolStripMenuItem
            // 
            this.paramétrageToolStripMenuItem.Name = "paramétrageToolStripMenuItem";
            this.paramétrageToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.paramétrageToolStripMenuItem.Text = "Paramétrage";
            this.paramétrageToolStripMenuItem.Click += new System.EventHandler(this.paramétrageToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Liste des abonnements";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 52);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(154, 52);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(62, 21);
            this.comboBox3.TabIndex = 23;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(808, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 27);
            this.button1.TabIndex = 28;
            this.button1.Text = "Créer compte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 449);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Préfacturation Wiilog";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNTComptesBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sélectionnerLeFichierDactivitéToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ToolStripMenuItem paramétrageToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.BindingSource eNTComptesBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filialeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomclientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montantmensuelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewButtonColumn Modifier;
    }
}

