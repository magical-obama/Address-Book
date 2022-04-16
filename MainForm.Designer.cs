namespace Address_Book
{
    partial class MainForm
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
            this.addContactButton = new System.Windows.Forms.Button();
            this.addressListBox = new System.Windows.Forms.ListBox();
            this.previewGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.previewNameLabel = new System.Windows.Forms.Label();
            this.previewAddressLabel = new System.Windows.Forms.Label();
            this.previewTelephoneLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.telephoneLabel = new System.Windows.Forms.Label();
            this.editContactButton = new System.Windows.Forms.Button();
            this.deleteContactButton = new System.Windows.Forms.Button();
            this.previewGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addContactButton
            // 
            this.addContactButton.Location = new System.Drawing.Point(216, 12);
            this.addContactButton.Name = "addContactButton";
            this.addContactButton.Size = new System.Drawing.Size(119, 23);
            this.addContactButton.TabIndex = 1;
            this.addContactButton.Text = "Add New Contact";
            this.addContactButton.UseVisualStyleBackColor = true;
            this.addContactButton.Click += new System.EventHandler(this.addContactButton_Click);
            // 
            // addressListBox
            // 
            this.addressListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addressListBox.FormattingEnabled = true;
            this.addressListBox.ItemHeight = 15;
            this.addressListBox.Location = new System.Drawing.Point(12, 12);
            this.addressListBox.Name = "addressListBox";
            this.addressListBox.Size = new System.Drawing.Size(198, 184);
            this.addressListBox.Sorted = true;
            this.addressListBox.TabIndex = 2;
            this.addressListBox.SelectedIndexChanged += new System.EventHandler(this.addressListBox_SelectedIndexChanged);
            this.addressListBox.SelectedValueChanged += new System.EventHandler(this.addressListBox_SelectedValueChanged);
            this.addressListBox.DoubleClick += new System.EventHandler(this.addressListBox_DoubleClick);
            // 
            // previewGroupBox
            // 
            this.previewGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.previewGroupBox.Location = new System.Drawing.Point(341, 12);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(283, 70);
            this.previewGroupBox.TabIndex = 3;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Preview";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.35379F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.64621F));
            this.tableLayoutPanel1.Controls.Add(this.previewNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.previewAddressLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.previewTelephoneLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nameLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.addressLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.telephoneLabel, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(277, 48);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // previewNameLabel
            // 
            this.previewNameLabel.AutoSize = true;
            this.previewNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewNameLabel.Location = new System.Drawing.Point(3, 0);
            this.previewNameLabel.Name = "previewNameLabel";
            this.previewNameLabel.Size = new System.Drawing.Size(67, 15);
            this.previewNameLabel.TabIndex = 0;
            this.previewNameLabel.Text = "Name:";
            // 
            // previewAddressLabel
            // 
            this.previewAddressLabel.AutoSize = true;
            this.previewAddressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewAddressLabel.Location = new System.Drawing.Point(3, 15);
            this.previewAddressLabel.Name = "previewAddressLabel";
            this.previewAddressLabel.Size = new System.Drawing.Size(67, 15);
            this.previewAddressLabel.TabIndex = 1;
            this.previewAddressLabel.Text = "Address:";
            // 
            // previewTelephoneLabel
            // 
            this.previewTelephoneLabel.AutoSize = true;
            this.previewTelephoneLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewTelephoneLabel.Location = new System.Drawing.Point(3, 30);
            this.previewTelephoneLabel.Name = "previewTelephoneLabel";
            this.previewTelephoneLabel.Size = new System.Drawing.Size(67, 18);
            this.previewTelephoneLabel.TabIndex = 2;
            this.previewTelephoneLabel.Text = "Telephone:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoEllipsis = true;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameLabel.Location = new System.Drawing.Point(76, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(198, 15);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressLabel.Location = new System.Drawing.Point(76, 15);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(198, 15);
            this.addressLabel.TabIndex = 4;
            this.addressLabel.Text = "Address";
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telephoneLabel.Location = new System.Drawing.Point(76, 30);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(198, 18);
            this.telephoneLabel.TabIndex = 5;
            this.telephoneLabel.Text = "Telephone";
            // 
            // editContactButton
            // 
            this.editContactButton.Location = new System.Drawing.Point(216, 42);
            this.editContactButton.Name = "editContactButton";
            this.editContactButton.Size = new System.Drawing.Size(119, 40);
            this.editContactButton.TabIndex = 4;
            this.editContactButton.Text = "Edit Selected Contact";
            this.editContactButton.UseVisualStyleBackColor = true;
            this.editContactButton.Click += new System.EventHandler(this.editContactButton_Click);
            // 
            // deleteContactButton
            // 
            this.deleteContactButton.Location = new System.Drawing.Point(216, 88);
            this.deleteContactButton.Name = "deleteContactButton";
            this.deleteContactButton.Size = new System.Drawing.Size(119, 40);
            this.deleteContactButton.TabIndex = 5;
            this.deleteContactButton.Text = "Delete Selected Contact";
            this.deleteContactButton.UseVisualStyleBackColor = true;
            this.deleteContactButton.Click += new System.EventHandler(this.deleteContactButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 217);
            this.Controls.Add(this.deleteContactButton);
            this.Controls.Add(this.editContactButton);
            this.Controls.Add(this.previewGroupBox);
            this.Controls.Add(this.addressListBox);
            this.Controls.Add(this.addContactButton);
            this.Name = "MainForm";
            this.Text = "Address Book";
            this.previewGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button addContactButton;
        private ListBox addressListBox;
        private GroupBox previewGroupBox;
        private Label previewNameLabel;
        private Label previewAddressLabel;
        private Label previewTelephoneLabel;
        private Button editContactButton;
        private Button deleteContactButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Label nameLabel;
        private Label addressLabel;
        private Label telephoneLabel;
    }
}