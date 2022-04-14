namespace Address_Book
{
    partial class Form1
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
            this.previewTelephoneLabel = new System.Windows.Forms.Label();
            this.previewAddressLabel = new System.Windows.Forms.Label();
            this.previewNameLabel = new System.Windows.Forms.Label();
            this.previewGroupBox.SuspendLayout();
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
            // 
            // addressListBox
            // 
            this.addressListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addressListBox.FormattingEnabled = true;
            this.addressListBox.ItemHeight = 15;
            this.addressListBox.Location = new System.Drawing.Point(12, 12);
            this.addressListBox.Name = "addressListBox";
            this.addressListBox.Size = new System.Drawing.Size(198, 424);
            this.addressListBox.TabIndex = 2;
            this.addressListBox.SelectedIndexChanged += new System.EventHandler(this.addressListBox_SelectedIndexChanged);
            this.addressListBox.DoubleClick += new System.EventHandler(this.addressListBox_DoubleClick);
            // 
            // previewGroupBox
            // 
            this.previewGroupBox.Controls.Add(this.previewTelephoneLabel);
            this.previewGroupBox.Controls.Add(this.previewAddressLabel);
            this.previewGroupBox.Controls.Add(this.previewNameLabel);
            this.previewGroupBox.Location = new System.Drawing.Point(341, 12);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(200, 74);
            this.previewGroupBox.TabIndex = 3;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Preview";
            // 
            // previewTelephoneLabel
            // 
            this.previewTelephoneLabel.AutoSize = true;
            this.previewTelephoneLabel.Location = new System.Drawing.Point(6, 49);
            this.previewTelephoneLabel.Name = "previewTelephoneLabel";
            this.previewTelephoneLabel.Size = new System.Drawing.Size(64, 15);
            this.previewTelephoneLabel.TabIndex = 2;
            this.previewTelephoneLabel.Text = "Telephone:";
            // 
            // previewAddressLabel
            // 
            this.previewAddressLabel.AutoSize = true;
            this.previewAddressLabel.Location = new System.Drawing.Point(6, 34);
            this.previewAddressLabel.Name = "previewAddressLabel";
            this.previewAddressLabel.Size = new System.Drawing.Size(52, 15);
            this.previewAddressLabel.TabIndex = 1;
            this.previewAddressLabel.Text = "Address:";
            // 
            // previewNameLabel
            // 
            this.previewNameLabel.AutoSize = true;
            this.previewNameLabel.Location = new System.Drawing.Point(6, 19);
            this.previewNameLabel.Name = "previewNameLabel";
            this.previewNameLabel.Size = new System.Drawing.Size(42, 15);
            this.previewNameLabel.TabIndex = 0;
            this.previewNameLabel.Text = "Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 461);
            this.Controls.Add(this.previewGroupBox);
            this.Controls.Add(this.addressListBox);
            this.Controls.Add(this.addContactButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.previewGroupBox.ResumeLayout(false);
            this.previewGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button addContactButton;
        private ListBox addressListBox;
        private GroupBox previewGroupBox;
        private Label previewNameLabel;
        private Label previewAddressLabel;
        private Label previewTelephoneLabel;
    }
}