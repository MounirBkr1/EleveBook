
namespace Eleve_Book.FM
{
    partial class UC_Arret_List
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Arret_List));
            this.pnlALL = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvArret = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDroit = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.groupTREIER = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTriDate = new System.Windows.Forms.Button();
            this.btnTriPunition = new System.Windows.Forms.Button();
            this.btnTtriNom = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRapportTOUT = new MaterialSkin.Controls.MaterialButton();
            this.lblRapport = new System.Windows.Forms.Label();
            this.pnlRapport = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHaut = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecherche = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbRecheche = new MaterialSkin.Controls.MaterialComboBox();
            this.btnSupprimer = new MaterialSkin.Controls.MaterialButton();
            this.btnModifier = new MaterialSkin.Controls.MaterialButton();
            this.btnAjouter = new MaterialSkin.Controls.MaterialButton();
            this.pnlALL.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArret)).BeginInit();
            this.pnlDroit.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupTREIER.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlRapport.SuspendLayout();
            this.pnlHaut.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlALL
            // 
            this.pnlALL.Controls.Add(this.pnlContent);
            this.pnlALL.Controls.Add(this.pnlDroit);
            this.pnlALL.Controls.Add(this.pnlHaut);
            this.pnlALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlALL.Location = new System.Drawing.Point(0, 0);
            this.pnlALL.Name = "pnlALL";
            this.pnlALL.Size = new System.Drawing.Size(950, 594);
            this.pnlALL.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvArret);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 76);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(796, 518);
            this.pnlContent.TabIndex = 2;
            // 
            // dgvArret
            // 
            this.dgvArret.AllowDrop = true;
            this.dgvArret.AllowUserToAddRows = false;
            this.dgvArret.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArret.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArret.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArret.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArret.ColumnHeadersHeight = 30;
            this.dgvArret.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvArret.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column10,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgvArret.EnableHeadersVisualStyles = false;
            this.dgvArret.Location = new System.Drawing.Point(0, 0);
            this.dgvArret.Name = "dgvArret";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArret.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArret.RowHeadersVisible = false;
            this.dgvArret.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Almarai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvArret.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvArret.Size = new System.Drawing.Size(796, 518);
            this.dgvArret.TabIndex = 4;
            this.dgvArret.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvArret_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "SELECT";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 76;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "N°";
            this.Column10.Name = "Column10";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "NOM";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "PRENOM";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "PUNITION INFLIGEE";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "MOTIF PUNITION";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "DATE";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "AUTORITE";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "AUTRES";
            this.Column9.Name = "Column9";
            // 
            // pnlDroit
            // 
            this.pnlDroit.Controls.Add(this.tableLayoutPanel1);
            this.pnlDroit.Controls.Add(this.groupTREIER);
            this.pnlDroit.Controls.Add(this.panel5);
            this.pnlDroit.Controls.Add(this.pnlRapport);
            this.pnlDroit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDroit.Location = new System.Drawing.Point(796, 76);
            this.pnlDroit.Name = "pnlDroit";
            this.pnlDroit.Size = new System.Drawing.Size(154, 518);
            this.pnlDroit.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnExcel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImprimer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 453);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(154, 65);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(80, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(71, 59);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnImprimer
            // 
            this.btnImprimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImprimer.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimer.Image")));
            this.btnImprimer.Location = new System.Drawing.Point(3, 3);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(71, 59);
            this.btnImprimer.TabIndex = 0;
            this.btnImprimer.UseVisualStyleBackColor = true;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
            // 
            // groupTREIER
            // 
            this.groupTREIER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupTREIER.Controls.Add(this.tableLayoutPanel3);
            this.groupTREIER.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupTREIER.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupTREIER.ForeColor = System.Drawing.Color.Blue;
            this.groupTREIER.Location = new System.Drawing.Point(0, 104);
            this.groupTREIER.Name = "groupTREIER";
            this.groupTREIER.Size = new System.Drawing.Size(154, 130);
            this.groupTREIER.TabIndex = 6;
            this.groupTREIER.TabStop = false;
            this.groupTREIER.Text = "Trier";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnTriDate, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnTriPunition, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnTtriNom, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(148, 108);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnTriDate
            // 
            this.btnTriDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTriDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTriDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTriDate.ForeColor = System.Drawing.Color.Black;
            this.btnTriDate.Location = new System.Drawing.Point(3, 75);
            this.btnTriDate.Name = "btnTriDate";
            this.btnTriDate.Size = new System.Drawing.Size(142, 30);
            this.btnTriDate.TabIndex = 2;
            this.btnTriDate.Text = "Date";
            this.btnTriDate.UseVisualStyleBackColor = false;
            this.btnTriDate.Click += new System.EventHandler(this.btnTriDate_Click);
            // 
            // btnTriPunition
            // 
            this.btnTriPunition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTriPunition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTriPunition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTriPunition.ForeColor = System.Drawing.Color.Black;
            this.btnTriPunition.Location = new System.Drawing.Point(3, 39);
            this.btnTriPunition.Name = "btnTriPunition";
            this.btnTriPunition.Size = new System.Drawing.Size(142, 30);
            this.btnTriPunition.TabIndex = 1;
            this.btnTriPunition.Text = "Punition";
            this.btnTriPunition.UseVisualStyleBackColor = false;
            this.btnTriPunition.Click += new System.EventHandler(this.btnTriPunition_Click);
            // 
            // btnTtriNom
            // 
            this.btnTtriNom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTtriNom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTtriNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTtriNom.ForeColor = System.Drawing.Color.Black;
            this.btnTtriNom.Location = new System.Drawing.Point(3, 3);
            this.btnTtriNom.Name = "btnTtriNom";
            this.btnTtriNom.Size = new System.Drawing.Size(142, 30);
            this.btnTtriNom.TabIndex = 0;
            this.btnTtriNom.Text = "Nom";
            this.btnTtriNom.UseVisualStyleBackColor = false;
            this.btnTtriNom.Click += new System.EventHandler(this.btnTtriNom_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel2);
            this.panel5.Controls.Add(this.lblRapport);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 58);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(154, 46);
            this.panel5.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnRapportTOUT, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(154, 46);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnRapportTOUT
            // 
            this.btnRapportTOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRapportTOUT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRapportTOUT.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnRapportTOUT.Depth = 0;
            this.btnRapportTOUT.DrawShadows = false;
            this.btnRapportTOUT.FlatAppearance.BorderSize = 0;
            this.btnRapportTOUT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRapportTOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRapportTOUT.HighEmphasis = true;
            this.btnRapportTOUT.Icon = null;
            this.btnRapportTOUT.Location = new System.Drawing.Point(11, 6);
            this.btnRapportTOUT.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRapportTOUT.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRapportTOUT.Name = "btnRapportTOUT";
            this.btnRapportTOUT.Size = new System.Drawing.Size(139, 34);
            this.btnRapportTOUT.TabIndex = 0;
            this.btnRapportTOUT.Text = "Liste Complète";
            this.btnRapportTOUT.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRapportTOUT.UseAccentColor = false;
            this.btnRapportTOUT.UseVisualStyleBackColor = false;
            this.btnRapportTOUT.Click += new System.EventHandler(this.btnRapportTOUT_Click);
            // 
            // lblRapport
            // 
            this.lblRapport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRapport.AutoSize = true;
            this.lblRapport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRapport.Location = new System.Drawing.Point(0, 0);
            this.lblRapport.Name = "lblRapport";
            this.lblRapport.Size = new System.Drawing.Size(120, 24);
            this.lblRapport.TabIndex = 0;
            this.lblRapport.Text = "RAPPORTS";
            // 
            // pnlRapport
            // 
            this.pnlRapport.Controls.Add(this.label1);
            this.pnlRapport.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRapport.Location = new System.Drawing.Point(0, 0);
            this.pnlRapport.Name = "pnlRapport";
            this.pnlRapport.Size = new System.Drawing.Size(154, 58);
            this.pnlRapport.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "RAPPORTS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHaut
            // 
            this.pnlHaut.Controls.Add(this.label2);
            this.pnlHaut.Controls.Add(this.txtRecherche);
            this.pnlHaut.Controls.Add(this.cmbRecheche);
            this.pnlHaut.Controls.Add(this.btnSupprimer);
            this.pnlHaut.Controls.Add(this.btnModifier);
            this.pnlHaut.Controls.Add(this.btnAjouter);
            this.pnlHaut.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHaut.Location = new System.Drawing.Point(0, 0);
            this.pnlHaut.Name = "pnlHaut";
            this.pnlHaut.Size = new System.Drawing.Size(950, 76);
            this.pnlHaut.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "RI_ARRETS";
            // 
            // txtRecherche
            // 
            this.txtRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecherche.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecherche.Depth = 0;
            this.txtRecherche.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtRecherche.ForeColor = System.Drawing.Color.Silver;
            this.txtRecherche.Location = new System.Drawing.Point(779, 18);
            this.txtRecherche.MaxLength = 50;
            this.txtRecherche.MouseState = MaterialSkin.MouseState.OUT;
            this.txtRecherche.Multiline = false;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(157, 36);
            this.txtRecherche.TabIndex = 6;
            this.txtRecherche.Text = "Rechercher";
            this.txtRecherche.UseTallSize = false;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            this.txtRecherche.Enter += new System.EventHandler(this.txtRecherche_Enter);
            this.txtRecherche.Leave += new System.EventHandler(this.txtRecherche_Leave);
            // 
            // cmbRecheche
            // 
            this.cmbRecheche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRecheche.AutoResize = false;
            this.cmbRecheche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbRecheche.Depth = 0;
            this.cmbRecheche.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbRecheche.DropDownHeight = 118;
            this.cmbRecheche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecheche.DropDownWidth = 121;
            this.cmbRecheche.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbRecheche.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbRecheche.FormattingEnabled = true;
            this.cmbRecheche.IntegralHeight = false;
            this.cmbRecheche.ItemHeight = 29;
            this.cmbRecheche.Items.AddRange(new object[] {
            "--Selectionner --",
            "NOM",
            "DATE ",
            "PUNITION",
            "MOTIF",
            "AUTORITE"});
            this.cmbRecheche.Location = new System.Drawing.Point(582, 19);
            this.cmbRecheche.MaxDropDownItems = 4;
            this.cmbRecheche.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbRecheche.Name = "cmbRecheche";
            this.cmbRecheche.Size = new System.Drawing.Size(168, 35);
            this.cmbRecheche.TabIndex = 5;
            this.cmbRecheche.UseTallSize = false;
            this.cmbRecheche.SelectedIndexChanged += new System.EventHandler(this.cmbRecheche_SelectedIndexChanged);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.AutoSize = false;
            this.btnSupprimer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSupprimer.Depth = 0;
            this.btnSupprimer.DrawShadows = true;
            this.btnSupprimer.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSupprimer.HighEmphasis = true;
            this.btnSupprimer.Icon = null;
            this.btnSupprimer.Location = new System.Drawing.Point(403, 12);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSupprimer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(118, 42);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "SUPPRIMER";
            this.btnSupprimer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSupprimer.UseAccentColor = false;
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.AutoSize = false;
            this.btnModifier.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnModifier.Depth = 0;
            this.btnModifier.DrawShadows = true;
            this.btnModifier.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnModifier.HighEmphasis = true;
            this.btnModifier.Icon = null;
            this.btnModifier.Location = new System.Drawing.Point(219, 12);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnModifier.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(141, 42);
            this.btnModifier.TabIndex = 1;
            this.btnModifier.Text = "EDITER /MODIFIER";
            this.btnModifier.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnModifier.UseAccentColor = false;
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.AutoSize = false;
            this.btnAjouter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAjouter.Depth = 0;
            this.btnAjouter.DrawShadows = true;
            this.btnAjouter.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAjouter.HighEmphasis = true;
            this.btnAjouter.Icon = null;
            this.btnAjouter.Location = new System.Drawing.Point(72, 12);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAjouter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(118, 42);
            this.btnAjouter.TabIndex = 0;
            this.btnAjouter.Text = "AJOUTER";
            this.btnAjouter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAjouter.UseAccentColor = false;
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // UC_Arret_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlALL);
            this.Name = "UC_Arret_List";
            this.Size = new System.Drawing.Size(950, 594);
            this.Load += new System.EventHandler(this.UC_Arret_List_Load);
            this.pnlALL.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArret)).EndInit();
            this.pnlDroit.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupTREIER.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlRapport.ResumeLayout(false);
            this.pnlRapport.PerformLayout();
            this.pnlHaut.ResumeLayout(false);
            this.pnlHaut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlALL;
        private System.Windows.Forms.Panel pnlDroit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnImprimer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialButton btnRapportTOUT;
        private System.Windows.Forms.Label lblRapport;
        private System.Windows.Forms.Panel pnlHaut;
        private MaterialSkin.Controls.MaterialTextBox txtRecherche;
        private MaterialSkin.Controls.MaterialComboBox cmbRecheche;
        private MaterialSkin.Controls.MaterialButton btnSupprimer;
        private MaterialSkin.Controls.MaterialButton btnModifier;
        private MaterialSkin.Controls.MaterialButton btnAjouter;
        private System.Windows.Forms.Panel pnlRapport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlContent;
        public System.Windows.Forms.DataGridView dgvArret;
        private System.Windows.Forms.GroupBox groupTREIER;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnTriDate;
        private System.Windows.Forms.Button btnTriPunition;
        private System.Windows.Forms.Button btnTtriNom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}