namespace TotalCommander
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SettinPanel = new System.Windows.Forms.Panel();
            this.CreateWorkPlace = new System.Windows.Forms.Button();
            this.ColorForFileCard = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.FontButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.TwoPanelsSplitConteiner = new System.Windows.Forms.SplitContainer();
            this.SettinPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TwoPanelsSplitConteiner)).BeginInit();
            this.TwoPanelsSplitConteiner.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettinPanel
            // 
            this.SettinPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SettinPanel.Controls.Add(this.CreateWorkPlace);
            this.SettinPanel.Controls.Add(this.ColorForFileCard);
            this.SettinPanel.Controls.Add(this.ColorButton);
            this.SettinPanel.Controls.Add(this.FontButton);
            this.SettinPanel.Controls.Add(this.CopyButton);
            this.SettinPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettinPanel.Location = new System.Drawing.Point(0, 0);
            this.SettinPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SettinPanel.Name = "SettinPanel";
            this.SettinPanel.Size = new System.Drawing.Size(1020, 100);
            this.SettinPanel.TabIndex = 0;
            // 
            // CreateWorkPlace
            // 
            this.CreateWorkPlace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateWorkPlace.BackColor = System.Drawing.Color.White;
            this.CreateWorkPlace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CreateWorkPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateWorkPlace.Location = new System.Drawing.Point(615, 46);
            this.CreateWorkPlace.Margin = new System.Windows.Forms.Padding(4);
            this.CreateWorkPlace.Name = "CreateWorkPlace";
            this.CreateWorkPlace.Size = new System.Drawing.Size(129, 47);
            this.CreateWorkPlace.TabIndex = 4;
            this.CreateWorkPlace.Text = "Раб. Поле";
            this.CreateWorkPlace.UseVisualStyleBackColor = false;
            this.CreateWorkPlace.Click += new System.EventHandler(this.CreateWorkPlace_Click);
            // 
            // ColorForFileCard
            // 
            this.ColorForFileCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorForFileCard.BackColor = System.Drawing.Color.White;
            this.ColorForFileCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColorForFileCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorForFileCard.Location = new System.Drawing.Point(762, 46);
            this.ColorForFileCard.Margin = new System.Windows.Forms.Padding(4);
            this.ColorForFileCard.Name = "ColorForFileCard";
            this.ColorForFileCard.Size = new System.Drawing.Size(120, 47);
            this.ColorForFileCard.TabIndex = 3;
            this.ColorForFileCard.Text = "Цвет окон";
            this.ColorForFileCard.UseVisualStyleBackColor = false;
            this.ColorForFileCard.Click += new System.EventHandler(this.ColorForFileCard_Click);
            // 
            // ColorButton
            // 
            this.ColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorButton.BackColor = System.Drawing.Color.White;
            this.ColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorButton.Location = new System.Drawing.Point(896, 46);
            this.ColorButton.Margin = new System.Windows.Forms.Padding(4);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(120, 47);
            this.ColorButton.TabIndex = 2;
            this.ColorButton.Text = "Цвет панелей";
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // FontButton
            // 
            this.FontButton.BackColor = System.Drawing.Color.White;
            this.FontButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FontButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontButton.Location = new System.Drawing.Point(142, 46);
            this.FontButton.Margin = new System.Windows.Forms.Padding(4);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new System.Drawing.Size(120, 48);
            this.FontButton.TabIndex = 1;
            this.FontButton.Text = "Шрифт";
            this.FontButton.UseVisualStyleBackColor = false;
            this.FontButton.Click += new System.EventHandler(this.FontButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.BackColor = System.Drawing.Color.White;
            this.CopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CopyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyButton.Location = new System.Drawing.Point(4, 46);
            this.CopyButton.Margin = new System.Windows.Forms.Padding(4);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(120, 48);
            this.CopyButton.TabIndex = 0;
            this.CopyButton.Text = "Копировать";
            this.CopyButton.UseVisualStyleBackColor = false;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // TwoPanelsSplitConteiner
            // 
            this.TwoPanelsSplitConteiner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TwoPanelsSplitConteiner.Location = new System.Drawing.Point(0, 100);
            this.TwoPanelsSplitConteiner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TwoPanelsSplitConteiner.MinimumSize = new System.Drawing.Size(0, 615);
            this.TwoPanelsSplitConteiner.Name = "TwoPanelsSplitConteiner";
            this.TwoPanelsSplitConteiner.Panel1MinSize = 300;
            this.TwoPanelsSplitConteiner.Panel2MinSize = 300;
            this.TwoPanelsSplitConteiner.Size = new System.Drawing.Size(1020, 615);
            this.TwoPanelsSplitConteiner.SplitterDistance = 400;
            this.TwoPanelsSplitConteiner.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 715);
            this.Controls.Add(this.TwoPanelsSplitConteiner);
            this.Controls.Add(this.SettinPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1035, 752);
            this.Name = "MainForm";
            this.Text = " TotalCommander";
            this.SettinPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TwoPanelsSplitConteiner)).EndInit();
            this.TwoPanelsSplitConteiner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SettinPanel;
        private System.Windows.Forms.SplitContainer TwoPanelsSplitConteiner;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button FontButton;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Button ColorForFileCard;
        private System.Windows.Forms.Button CreateWorkPlace;
    }
}
