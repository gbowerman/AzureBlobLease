namespace AzureBlobLease
{
    partial class AzureBlob
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.storageTab = new System.Windows.Forms.TabPage();
            this.deletePolicy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.newPolicyText = new System.Windows.Forms.TextBox();
            this.policyList = new System.Windows.Forms.ListBox();
            this.getSASButton = new System.Windows.Forms.Button();
            this.deletePolicyButton = new System.Windows.Forms.Button();
            this.breakLeaseButton = new System.Windows.Forms.Button();
            this.acquireLeaseButton = new System.Windows.Forms.Button();
            this.newContainerText = new System.Windows.Forms.TextBox();
            this.deleteBlobButton = new System.Windows.Forms.Button();
            this.storageAccNameLabel = new System.Windows.Forms.Label();
            this.connectStorageButton = new System.Windows.Forms.Button();
            this.blobList = new System.Windows.Forms.ListBox();
            this.filesLabel = new System.Windows.Forms.Label();
            this.deleteContainerButton = new System.Windows.Forms.Button();
            this.createContainerButton = new System.Windows.Forms.Button();
            this.containerLabel = new System.Windows.Forms.Label();
            this.containerList = new System.Windows.Forms.ListBox();
            this.storageAccLabel = new System.Windows.Forms.Label();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.accountList = new System.Windows.Forms.ListBox();
            this.saveStorageAccButton = new System.Windows.Forms.Button();
            this.keyText = new System.Windows.Forms.TextBox();
            this.keyLabel = new System.Windows.Forms.Label();
            this.accountText = new System.Windows.Forms.TextBox();
            this.accountLabel = new System.Windows.Forms.Label();
            this.storageLabel = new System.Windows.Forms.Label();
            this.deleteAccountBtn = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.storageTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.storageTab);
            this.tabControl.Controls.Add(this.settingsTab);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 2);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(464, 341);
            this.tabControl.TabIndex = 0;
            // 
            // storageTab
            // 
            this.storageTab.BackColor = System.Drawing.Color.Azure;
            this.storageTab.Controls.Add(this.deletePolicy);
            this.storageTab.Controls.Add(this.label1);
            this.storageTab.Controls.Add(this.newPolicyText);
            this.storageTab.Controls.Add(this.policyList);
            this.storageTab.Controls.Add(this.getSASButton);
            this.storageTab.Controls.Add(this.deletePolicyButton);
            this.storageTab.Controls.Add(this.breakLeaseButton);
            this.storageTab.Controls.Add(this.acquireLeaseButton);
            this.storageTab.Controls.Add(this.newContainerText);
            this.storageTab.Controls.Add(this.deleteBlobButton);
            this.storageTab.Controls.Add(this.storageAccNameLabel);
            this.storageTab.Controls.Add(this.connectStorageButton);
            this.storageTab.Controls.Add(this.blobList);
            this.storageTab.Controls.Add(this.filesLabel);
            this.storageTab.Controls.Add(this.deleteContainerButton);
            this.storageTab.Controls.Add(this.createContainerButton);
            this.storageTab.Controls.Add(this.containerLabel);
            this.storageTab.Controls.Add(this.containerList);
            this.storageTab.Controls.Add(this.storageAccLabel);
            this.storageTab.Location = new System.Drawing.Point(4, 22);
            this.storageTab.Margin = new System.Windows.Forms.Padding(2);
            this.storageTab.Name = "storageTab";
            this.storageTab.Padding = new System.Windows.Forms.Padding(2);
            this.storageTab.Size = new System.Drawing.Size(456, 315);
            this.storageTab.TabIndex = 0;
            this.storageTab.Text = "Storage";
            // 
            // deletePolicy
            // 
            this.deletePolicy.BackColor = System.Drawing.Color.LightSteelBlue;
            this.deletePolicy.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePolicy.Location = new System.Drawing.Point(321, 153);
            this.deletePolicy.Margin = new System.Windows.Forms.Padding(2);
            this.deletePolicy.Name = "deletePolicy";
            this.deletePolicy.Size = new System.Drawing.Size(83, 20);
            this.deletePolicy.TabIndex = 41;
            this.deletePolicy.Text = "Delete Policy";
            this.deletePolicy.UseVisualStyleBackColor = false;
            this.deletePolicy.Click += new System.EventHandler(this.deletePolicyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 14);
            this.label1.TabIndex = 40;
            this.label1.Text = "Policies";
            // 
            // newPolicyText
            // 
            this.newPolicyText.Location = new System.Drawing.Point(216, 128);
            this.newPolicyText.Name = "newPolicyText";
            this.newPolicyText.Size = new System.Drawing.Size(100, 19);
            this.newPolicyText.TabIndex = 39;
            this.newPolicyText.Text = "<policy name>";
            this.newPolicyText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.newPolicyText_MouseClick);
            // 
            // policyList
            // 
            this.policyList.FormattingEnabled = true;
            this.policyList.Location = new System.Drawing.Point(216, 56);
            this.policyList.Name = "policyList";
            this.policyList.Size = new System.Drawing.Size(203, 69);
            this.policyList.TabIndex = 38;
            // 
            // getSASButton
            // 
            this.getSASButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.getSASButton.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getSASButton.Location = new System.Drawing.Point(343, 36);
            this.getSASButton.Margin = new System.Windows.Forms.Padding(2);
            this.getSASButton.Name = "getSASButton";
            this.getSASButton.Size = new System.Drawing.Size(76, 20);
            this.getSASButton.TabIndex = 37;
            this.getSASButton.Text = "Get SAS";
            this.getSASButton.UseVisualStyleBackColor = false;
            this.getSASButton.Click += new System.EventHandler(this.getSASButton_Click);
            // 
            // deletePolicyButton
            // 
            this.deletePolicyButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.deletePolicyButton.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePolicyButton.Location = new System.Drawing.Point(321, 128);
            this.deletePolicyButton.Margin = new System.Windows.Forms.Padding(2);
            this.deletePolicyButton.Name = "deletePolicyButton";
            this.deletePolicyButton.Size = new System.Drawing.Size(83, 20);
            this.deletePolicyButton.TabIndex = 36;
            this.deletePolicyButton.Text = "New Policy";
            this.deletePolicyButton.UseVisualStyleBackColor = false;
            this.deletePolicyButton.Click += new System.EventHandler(this.newPolicyButton_Click);
            // 
            // breakLeaseButton
            // 
            this.breakLeaseButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.breakLeaseButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breakLeaseButton.Location = new System.Drawing.Point(192, 288);
            this.breakLeaseButton.Name = "breakLeaseButton";
            this.breakLeaseButton.Size = new System.Drawing.Size(88, 20);
            this.breakLeaseButton.TabIndex = 35;
            this.breakLeaseButton.Text = "Break Lease";
            this.breakLeaseButton.UseVisualStyleBackColor = false;
            this.breakLeaseButton.Click += new System.EventHandler(this.breakLeaseButton_Click);
            // 
            // acquireLeaseButton
            // 
            this.acquireLeaseButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.acquireLeaseButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acquireLeaseButton.Location = new System.Drawing.Point(98, 288);
            this.acquireLeaseButton.Name = "acquireLeaseButton";
            this.acquireLeaseButton.Size = new System.Drawing.Size(88, 20);
            this.acquireLeaseButton.TabIndex = 34;
            this.acquireLeaseButton.Text = "Acquire lease";
            this.acquireLeaseButton.UseVisualStyleBackColor = false;
            this.acquireLeaseButton.Click += new System.EventHandler(this.leaseButton_Click);
            // 
            // newContainerText
            // 
            this.newContainerText.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newContainerText.Location = new System.Drawing.Point(4, 129);
            this.newContainerText.Margin = new System.Windows.Forms.Padding(2);
            this.newContainerText.Name = "newContainerText";
            this.newContainerText.Size = new System.Drawing.Size(101, 20);
            this.newContainerText.TabIndex = 20;
            this.newContainerText.Text = "<new container>";
            this.newContainerText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.newContainerText_MouseClick);
            // 
            // deleteBlobButton
            // 
            this.deleteBlobButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.deleteBlobButton.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBlobButton.Location = new System.Drawing.Point(5, 288);
            this.deleteBlobButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteBlobButton.Name = "deleteBlobButton";
            this.deleteBlobButton.Size = new System.Drawing.Size(88, 20);
            this.deleteBlobButton.TabIndex = 19;
            this.deleteBlobButton.Text = "Delete blob";
            this.deleteBlobButton.UseVisualStyleBackColor = false;
            this.deleteBlobButton.Click += new System.EventHandler(this.deleteBlobButton_Click);
            // 
            // storageAccNameLabel
            // 
            this.storageAccNameLabel.AutoSize = true;
            this.storageAccNameLabel.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storageAccNameLabel.Location = new System.Drawing.Point(95, 14);
            this.storageAccNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.storageAccNameLabel.Name = "storageAccNameLabel";
            this.storageAccNameLabel.Size = new System.Drawing.Size(12, 13);
            this.storageAccNameLabel.TabIndex = 16;
            this.storageAccNameLabel.Text = "- ";
            // 
            // connectStorageButton
            // 
            this.connectStorageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.connectStorageButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.connectStorageButton.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectStorageButton.Location = new System.Drawing.Point(199, 10);
            this.connectStorageButton.Margin = new System.Windows.Forms.Padding(2);
            this.connectStorageButton.Name = "connectStorageButton";
            this.connectStorageButton.Size = new System.Drawing.Size(64, 20);
            this.connectStorageButton.TabIndex = 15;
            this.connectStorageButton.Text = "Connect";
            this.connectStorageButton.UseVisualStyleBackColor = false;
            this.connectStorageButton.Click += new System.EventHandler(this.connectStorageButton_Click);
            // 
            // blobList
            // 
            this.blobList.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blobList.FormattingEnabled = true;
            this.blobList.Location = new System.Drawing.Point(4, 202);
            this.blobList.Margin = new System.Windows.Forms.Padding(2);
            this.blobList.Name = "blobList";
            this.blobList.Size = new System.Drawing.Size(444, 82);
            this.blobList.TabIndex = 9;
            // 
            // filesLabel
            // 
            this.filesLabel.AutoSize = true;
            this.filesLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesLabel.Location = new System.Drawing.Point(2, 185);
            this.filesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.filesLabel.Name = "filesLabel";
            this.filesLabel.Size = new System.Drawing.Size(34, 14);
            this.filesLabel.TabIndex = 8;
            this.filesLabel.Text = "Blobs";
            // 
            // deleteContainerButton
            // 
            this.deleteContainerButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.deleteContainerButton.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteContainerButton.Location = new System.Drawing.Point(109, 153);
            this.deleteContainerButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteContainerButton.Name = "deleteContainerButton";
            this.deleteContainerButton.Size = new System.Drawing.Size(102, 20);
            this.deleteContainerButton.TabIndex = 4;
            this.deleteContainerButton.Text = "Delete Container";
            this.deleteContainerButton.UseVisualStyleBackColor = false;
            this.deleteContainerButton.Click += new System.EventHandler(this.deleteContainerButton_Click);
            // 
            // createContainerButton
            // 
            this.createContainerButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.createContainerButton.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createContainerButton.Location = new System.Drawing.Point(109, 129);
            this.createContainerButton.Margin = new System.Windows.Forms.Padding(2);
            this.createContainerButton.Name = "createContainerButton";
            this.createContainerButton.Size = new System.Drawing.Size(102, 20);
            this.createContainerButton.TabIndex = 3;
            this.createContainerButton.Text = "Create Container";
            this.createContainerButton.UseVisualStyleBackColor = false;
            this.createContainerButton.Click += new System.EventHandler(this.createContainerButton_Click);
            // 
            // containerLabel
            // 
            this.containerLabel.AutoSize = true;
            this.containerLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.containerLabel.Location = new System.Drawing.Point(2, 40);
            this.containerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.containerLabel.Name = "containerLabel";
            this.containerLabel.Size = new System.Drawing.Size(59, 14);
            this.containerLabel.TabIndex = 2;
            this.containerLabel.Text = "Containers";
            // 
            // containerList
            // 
            this.containerList.FormattingEnabled = true;
            this.containerList.Location = new System.Drawing.Point(4, 56);
            this.containerList.Margin = new System.Windows.Forms.Padding(2);
            this.containerList.Name = "containerList";
            this.containerList.Size = new System.Drawing.Size(202, 69);
            this.containerList.TabIndex = 1;
            this.containerList.SelectedValueChanged += new System.EventHandler(this.containerList_SelectedValueChanged);
            // 
            // storageAccLabel
            // 
            this.storageAccLabel.AutoSize = true;
            this.storageAccLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storageAccLabel.Location = new System.Drawing.Point(5, 13);
            this.storageAccLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.storageAccLabel.Name = "storageAccLabel";
            this.storageAccLabel.Size = new System.Drawing.Size(86, 14);
            this.storageAccLabel.TabIndex = 0;
            this.storageAccLabel.Text = "Storage account";
            // 
            // settingsTab
            // 
            this.settingsTab.BackColor = System.Drawing.Color.AliceBlue;
            this.settingsTab.Controls.Add(this.deleteAccountBtn);
            this.settingsTab.Controls.Add(this.accountList);
            this.settingsTab.Controls.Add(this.saveStorageAccButton);
            this.settingsTab.Controls.Add(this.keyText);
            this.settingsTab.Controls.Add(this.keyLabel);
            this.settingsTab.Controls.Add(this.accountText);
            this.settingsTab.Controls.Add(this.accountLabel);
            this.settingsTab.Controls.Add(this.storageLabel);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Margin = new System.Windows.Forms.Padding(2);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(2);
            this.settingsTab.Size = new System.Drawing.Size(456, 315);
            this.settingsTab.TabIndex = 1;
            this.settingsTab.Text = "Accounts";
            // 
            // accountList
            // 
            this.accountList.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountList.FormattingEnabled = true;
            this.accountList.Location = new System.Drawing.Point(8, 93);
            this.accountList.Margin = new System.Windows.Forms.Padding(2);
            this.accountList.Name = "accountList";
            this.accountList.Size = new System.Drawing.Size(122, 95);
            this.accountList.TabIndex = 13;
            this.accountList.SelectedIndexChanged += new System.EventHandler(this.accountList_Click);
            this.accountList.SelectedValueChanged += new System.EventHandler(this.accountList_SelectedValueChanged);
            // 
            // saveStorageAccButton
            // 
            this.saveStorageAccButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.saveStorageAccButton.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveStorageAccButton.Location = new System.Drawing.Point(173, 8);
            this.saveStorageAccButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveStorageAccButton.Name = "saveStorageAccButton";
            this.saveStorageAccButton.Size = new System.Drawing.Size(50, 19);
            this.saveStorageAccButton.TabIndex = 12;
            this.saveStorageAccButton.Text = "Save";
            this.saveStorageAccButton.UseVisualStyleBackColor = false;
            this.saveStorageAccButton.Click += new System.EventHandler(this.saveStorageAccButton_Click);
            // 
            // keyText
            // 
            this.keyText.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyText.Location = new System.Drawing.Point(7, 53);
            this.keyText.Margin = new System.Windows.Forms.Padding(2);
            this.keyText.Name = "keyText";
            this.keyText.PasswordChar = '*';
            this.keyText.Size = new System.Drawing.Size(330, 20);
            this.keyText.TabIndex = 11;
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyLabel.Location = new System.Drawing.Point(5, 37);
            this.keyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(27, 13);
            this.keyLabel.TabIndex = 10;
            this.keyLabel.Text = "Key:";
            // 
            // accountText
            // 
            this.accountText.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountText.Location = new System.Drawing.Point(83, 7);
            this.accountText.Margin = new System.Windows.Forms.Padding(2);
            this.accountText.Name = "accountText";
            this.accountText.Size = new System.Drawing.Size(86, 20);
            this.accountText.TabIndex = 9;
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountLabel.Location = new System.Drawing.Point(3, 7);
            this.accountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(77, 13);
            this.accountLabel.TabIndex = 8;
            this.accountLabel.Text = "Account name:";
            // 
            // storageLabel
            // 
            this.storageLabel.AutoSize = true;
            this.storageLabel.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storageLabel.Location = new System.Drawing.Point(8, 78);
            this.storageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.storageLabel.Name = "storageLabel";
            this.storageLabel.Size = new System.Drawing.Size(83, 13);
            this.storageLabel.TabIndex = 1;
            this.storageLabel.Text = "Storage Account";
            // 
            // deleteAccountBtn
            // 
            this.deleteAccountBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.deleteAccountBtn.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAccountBtn.Location = new System.Drawing.Point(136, 93);
            this.deleteAccountBtn.Name = "deleteAccountBtn";
            this.deleteAccountBtn.Size = new System.Drawing.Size(64, 20);
            this.deleteAccountBtn.TabIndex = 14;
            this.deleteAccountBtn.Text = "Delete";
            this.deleteAccountBtn.UseVisualStyleBackColor = false;
            this.deleteAccountBtn.Click += new System.EventHandler(this.deleteAccountBtn_Click);
            // 
            // AzureBlob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(468, 342);
            this.Controls.Add(this.tabControl);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AzureBlob";
            this.Text = "Azure blob editor";
            this.Load += new System.EventHandler(this.AzureBlob_Load);
            this.tabControl.ResumeLayout(false);
            this.storageTab.ResumeLayout(false);
            this.storageTab.PerformLayout();
            this.settingsTab.ResumeLayout(false);
            this.settingsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage storageTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.Label storageLabel;

        private System.Windows.Forms.ListBox blobList;
        private System.Windows.Forms.Label filesLabel;

        private System.Windows.Forms.Button deleteContainerButton;
        private System.Windows.Forms.Button createContainerButton;
        private System.Windows.Forms.Label containerLabel;
        private System.Windows.Forms.ListBox containerList;
        private System.Windows.Forms.Label storageAccLabel;
        private System.Windows.Forms.TextBox keyText;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.TextBox accountText;
        private System.Windows.Forms.Label accountLabel;

        private System.Windows.Forms.Button connectStorageButton;
        private System.Windows.Forms.Label storageAccNameLabel;
        private System.Windows.Forms.Button saveStorageAccButton;

        private System.Windows.Forms.Button deleteBlobButton;
        private System.Windows.Forms.TextBox newContainerText;

        private System.Windows.Forms.ListBox accountList;
        private System.Windows.Forms.Button acquireLeaseButton;
        private System.Windows.Forms.Button breakLeaseButton;
        private System.Windows.Forms.Button getSASButton;
        private System.Windows.Forms.Button deletePolicyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newPolicyText;
        private System.Windows.Forms.ListBox policyList;
        private System.Windows.Forms.Button deletePolicy;
        private System.Windows.Forms.Button deleteAccountBtn;
    }
}

