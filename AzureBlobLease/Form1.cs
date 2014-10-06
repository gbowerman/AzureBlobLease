/*
 * Azure Blob Lease Tool
 * 
 * To do: 
 *   Improve display and framing
 *   Add support for highlighting multiple blobs
 *   
 *   For questions contact: guybo@outlook.com
 *   Last modified: 5/21/13
 */

using System;
using System.Windows.Forms;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Configuration;
using System.Collections.Generic;

namespace AzureBlobLease
{
    public partial class AzureBlob : Form
    {
        String accountName = null;
        String accountKey = null;
        CloudBlobClient blobClient = null;
        string containerName = null;
        string policyName = null;
        string keyStoreDir = ".";
        string configFile = "AzureBlobLease.config";
        List<string> keyList = new List<string>();
        
        public AzureBlob()
        {
            InitializeComponent();

            // set up a file to store app data in key pair format
            // establish the key store file location and set to current working directory
            try
            {
                keyStoreDir = System.Environment.GetEnvironmentVariable("LOCALAPPDATA");
                if (keyStoreDir == null)
                    keyStoreDir = System.Environment.GetEnvironmentVariable("APPDATA");
                if (keyStoreDir == null) keyStoreDir = ".";
                keyStoreDir += "\\AzureBlob\\AzureBlobLease";
                if (!Directory.Exists(keyStoreDir))
                {
                    Directory.CreateDirectory(keyStoreDir);
                }
                Directory.SetCurrentDirectory(keyStoreDir);

                if (!File.Exists(configFile)) File.Create(configFile);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Unable to set the key store folder. Error: " +
                    Ex.Message + ". Using current working directory",
                    "App data create exception");
            }

        }

        private void AzureBlob_Load(object sender, EventArgs e)
        {
            // load application settings
            System.Configuration.Configuration cfg = 
                ConfigurationManager.OpenExeConfiguration(configFile);
            int count = cfg.AppSettings.Settings.Count;

            // populate storage accounts list
            for (int accountIndex = 0; accountIndex < count; accountIndex++)
            {
                if (cfg.AppSettings.Settings.AllKeys[accountIndex].StartsWith("Account"))
                {
                    string value = cfg.AppSettings.Settings.AllKeys[accountIndex];
                    accountList.Items.Add(cfg.AppSettings.Settings[value].Value);
                    accountIndex++;
                    value = cfg.AppSettings.Settings.AllKeys[accountIndex];
                    keyList.Add(cfg.AppSettings.Settings[value].Value);
                }
            }
            
            // highlight the last one added - may need to improve this logic later
            if (accountList.Items.Count > 0)
            {
                int listIndex = accountList.Items.Count - 1;
                accountList.SetSelected(listIndex, true);

                // now set the accountText and KeyText to the selected values    
                accountText.Text = accountList.Items[listIndex].ToString();
                keyText.Text = keyList[listIndex];
            }
            
            if (accountText.Text.Length > 0)
            {
                storageAccNameLabel.Text = "- " + accountText.Text;

                // might as well try and connect and list containers at this point
                listContainers();
            }
        }

        private void connectStorageButton_Click(object sender, EventArgs e)
        {
            // clear lists
            containerList.Items.Clear(); 
            policyList.Items.Clear();
            blobList.Items.Clear();

            listContainers();
        }

        /* 
           listContainers():
           - First connects to a storage account
           - then lists the containers
           - then higlights the 1st container,
             which triggers event handler that does blob and policy enumeration
         */
        private void listContainers()
        {
            if (accountText.Text.Length > 0 && keyText.Text.Length > 0)
            {
                accountName = accountText.Text;
                accountKey = keyText.Text;
            }
            else
            {
                MessageBox.Show("Go to Settings tab and make sure Azure storage account and key are set",
                    "Missing storage settings");
                return;
            }
            try
            {
                Uri blobEndpoint = new Uri("https://" + accountName + ".blob.core.windows.net/");

                // create storage account object and blob client
                Microsoft.WindowsAzure.Storage.CloudStorageAccount storageAccount =
                    new Microsoft.WindowsAzure.Storage.CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(accountName, accountKey), true);
                blobClient = storageAccount.CreateCloudBlobClient();
            
                //List all containers in this storage account.
                containerList.Items.Clear();
                foreach (var container in blobClient.ListContainers())
                {
                    containerList.Items.Add(container.Name);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Invalid cloud blob client: " + Ex.Message + 
                    " - check storage account credentials",
                    "Blob client error");
                return;
            }
            // highlight the first listbox item
            if (containerList.Items.Count > 0)
                containerList.SetSelected(0, true);
        }

        // someone clicks on a container - list the blobs and policies for that container
        private void containerList_SelectedValueChanged(object sender, EventArgs e)
        {
            listContainerPolicies();
            listBlobs();
        }

        // Enumerate the policies associated with a selected container and populate the policies listbox
        private void listContainerPolicies()
        {
            if (containerList.SelectedItem == null) return;
            containerName = containerList.SelectedItem.ToString();

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // now list the policies for this container
            policyList.Items.Clear();

            BlobContainerPermissions containerPermissions = container.GetPermissions();
            if (containerPermissions.SharedAccessPolicies.Count < 1) return;

            foreach (string policyName in containerPermissions.SharedAccessPolicies.Keys)
            {
                policyList.Items.Add(policyName);
            }

        }

        // Enumerate the blobs in a selected container and populate the blobs listbox
        private void listBlobs()
        {
            if (containerList.SelectedItem == null) return;
            containerName = containerList.SelectedItem.ToString();

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // now list blobs for this container
            // retrieve reference to a previously created container

            // display the name of each blob in the container (could be block or page blobs)
            blobList.Items.Clear();
            foreach (var blobItem in container.ListBlobs(null, true))
            {
                if (blobItem is CloudPageBlob)
                {
                    blobList.Items.Add(((CloudPageBlob)blobItem).Name);
                }
                else if (blobItem is CloudBlockBlob)
                {
                    blobList.Items.Add(((CloudBlockBlob)blobItem).Name);
                }
                else
                {
                    blobList.Items.Add(blobItem.Uri);
                }
            }
        }



        string[] GetBlobListWithPaths()
        {
            throw new NotImplementedException();
        }

        // Save storage key to a filename determined by account name, in local app storage
        private void saveStorageAccButton_Click(object sender, EventArgs e)
        {
            string accountName = null;

            if (accountText.Text.Length < 1 || keyText.Text.Length < 1)
            {
                MessageBox.Show("You need to enter an account name and key in order to save.", "Nothing to save");
                return;
            }
            else accountName = accountText.Text;

            // assign a unique name to the keys to store in the config file
            int accNumber = accountList.Items.Count;
            string accKeyName = "Account" + accNumber;
            string keyKeyName = "Key" + accNumber;

            System.Configuration.Configuration cfg = 
                ConfigurationManager.OpenExeConfiguration(configFile);
            cfg.AppSettings.Settings.Add(accKeyName, accountName);
            cfg.AppSettings.Settings.Add(keyKeyName, keyText.Text);

            // Save the configuration file.
            cfg.Save(ConfigurationSaveMode.Full, true);

            // Add it to the account list box
            accountList.Items.Add(accountName);

            // add it to the key list
            keyList.Add(keyText.Text);

            // highlight the new listbox item
            int index = accountList.FindStringExact(accountName);
            if (index != -1)
                accountList.SetSelected(index, true);

            // Update the current storage account name
            storageAccNameLabel.Text = "- " + accountName;

            // clear any existing listBox entries
            containerList.Items.Clear();
            policyList.Items.Clear();
            blobList.Items.Clear();

            // ask if user wants to connect to the new storage account
            DialogResult answer = MessageBox.Show("Do you want to connect to the new storage account: "
    + accountName + "?", "Confirm connect", MessageBoxButtons.YesNo);
            if (answer.Equals(DialogResult.No)) return;
            
            // connect and list containers
            listContainers();
        }

        private void deleteBlobButton_Click(object sender, EventArgs e)
        {
            String blobName = null;

            // get blob name
            if (blobList.SelectedItem == null)
            {
                MessageBox.Show("No blob selected.", "No blob");
                return;
            }
            else blobName = blobList.SelectedItem.ToString();

            // confirm user really wants to do this
            DialogResult answer = MessageBox.Show("Are you sure you want to delete blob: "
                + blobName + "?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (answer.Equals(DialogResult.No)) return;

            // Retrieve reference to a previously created container
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Retrieve reference blob
            var blob = container.GetPageBlobReference(blobName);

            // Delete the blob
            try
            {
                blob.Delete();
            }
            catch (Exception ex)
            {
                StorageException storageException = ex as StorageException;
                // Look at the status code - 412 = active lease  
                if (storageException != null && storageException.RequestInformation.HttpStatusCode == 412)
                {
                    DialogResult answer2 =
                     MessageBox.Show("There is an open lease on this blob. Do you want to break the lease and delete it?",
                      "Confirm Delete", MessageBoxButtons.YesNo);
                    if (answer2.Equals(DialogResult.No)) return;
                    try
                    {
                        blob.BreakLease(TimeSpan.FromSeconds(0));
                        blob.Delete();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.ToString(), "Exception breaking lease " + ex2.GetType().FullName);
                    }
                }
                else
                {
                    MessageBox.Show(ex.ToString(), ex.GetType().FullName);
                }
            }

            // re-display the list of blobs
            listBlobs();
        }

        private void newContainerText_MouseClick(object sender, MouseEventArgs e)
        {
            newContainerText.SelectAll();
        }

        private void createContainerButton_Click(object sender, EventArgs e)
        {
            if (newContainerText.Text == null || newContainerText.Text.StartsWith("<"))
            {
                MessageBox.Show("Enter a name for the new container first.", "No container");
                return;
            }

            string newContainer = newContainerText.Text;

            if (blobClient == null)
            {
                MessageBox.Show("Connect to your storage account first.", "No connection");
                return;
            }

            // get the container reference
            CloudBlobContainer container = blobClient.GetContainerReference(newContainer);

            // create the container if it doesn't already exist
            container.CreateIfNotExists();

            listContainers();

            // highlight the new listbox item
            int index = containerList.FindStringExact(newContainer);
            if (index != -1)
                containerList.SetSelected(index, true);
        }

        private void deleteContainerButton_Click(object sender, EventArgs e)
        {
            // get container name
            if (containerList.SelectedItem == null)
            {
                MessageBox.Show("No container selected.", "No container");
                return;
            }
            else
            {
                containerName = containerList.SelectedItem.ToString();
            }

            // confirm user really wants to do this
            DialogResult answer = MessageBox.Show("Are you sure you want to delete container: "
                + containerName + "?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (answer.Equals(DialogResult.No)) return;

            // get container reference
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            if (container != null)
            {
                container.Delete();
            }
            listContainers();
        }

        private void accountList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (accountList.SelectedItem == null) return;
            accountText.Text = accountList.SelectedItem.ToString();
            keyText.Text = keyList[accountList.SelectedIndex];
        }

        // prevent this blob from being deleted by acquiring a lease on it
        private void leaseButton_Click(object sender, EventArgs e)
        {
            String blobName = null;

            // get blob name
            if (blobList.SelectedItem == null)
            {
                MessageBox.Show("No blob selected.", "No blob");
                return;
            }
            else
            {
                blobName = blobList.SelectedItem.ToString();
            }

            // get container reference
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // get blob reference
            CloudPageBlob blob = container.GetPageBlobReference(blobName);

            // acquire lease
            try
            {
                string newLeaseId = Guid.NewGuid().ToString();
                blob.AcquireLease(null, newLeaseId);
                MessageBox.Show("Lease " + newLeaseId + " acquired.", "Lease success");
            }
            catch (Exception ex)
            {
                // check if there is already a lease on the blob - status code 409
                StorageException storageException = ex as StorageException; 
                if (storageException != null && storageException.RequestInformation.HttpStatusCode == 409)
                {
                    DialogResult answer2 =
                    MessageBox.Show("There already a lease on this blob", "Lease exists");
                }
                else
                MessageBox.Show("Error acquiring lease: " + ex.ToString(), ex.GetType().FullName);
            }
        }

        private void breakLeaseButton_Click(object sender, EventArgs e)
        {
            String blobName = null;

            // get blob name
            if (blobList.SelectedItem == null)
            {
                MessageBox.Show("No blob selected.", "No blob");
                return;
            }
            else
            {
                blobName = blobList.SelectedItem.ToString();
            }

            // get container reference
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // get blob reference
            CloudPageBlob blob = container.GetPageBlobReference(blobName);
            try
            {
                blob.BreakLease(TimeSpan.FromSeconds(0));
                MessageBox.Show("Lease removed.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error breaking lease: " + ex.ToString(), ex.GetType().FullName);
            }
        }

        private void accountList_Click(object sender, EventArgs e)
        {
            // set the highlighted storage account in the list
            if (accountList.SelectedItem == null) return;

            accountName = accountList.SelectedItem.ToString();
            accountText.Text = accountName;
            storageAccNameLabel.Text = "- " + accountName;
            // update the key too in case someone clicks Save
            int listIndex = accountList.SelectedIndex;
            accountKey = keyList[listIndex];
            keyText.Text = accountKey;
            
            // don't automatically connect, to avoid a delay if the credentials are incorrect
            //listContainers();
        }

        // get the SAS for a selected container policy
        private void getSASButton_Click(object sender, EventArgs e)
        {
            // get the highlighted policy
            if (policyList.SelectedItem == null) 
            {
                MessageBox.Show("No policy selected.", "No policy");
                return;
            }

            policyName = policyList.SelectedItem.ToString();
            containerName = containerList.SelectedItem.ToString();

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            BlobContainerPermissions containerPermissions = container.GetPermissions();
            
            string sas = container.GetSharedAccessSignature(new Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPolicy(), policyName);
            // compensate for a bug in GetSharedAccessSignature that returns the SAS with a leading '?'
            sas = sas.TrimStart('?');
            Clipboard.SetText(sas, TextDataFormat.Text);
            MessageBox.Show("SAS: \"" + sas + "\" copied to clipboard.", "Container SAS");
        }

        // create a new policy for the highlighted container
        private void newPolicyButton_Click(object sender, EventArgs e)
        {
            // check policy name has been entered
            if (newPolicyText.Text == null || newPolicyText.Text.StartsWith("<"))
            {
                MessageBox.Show("Enter a name for the new policy first.", "No policy");
                return;
            }
            string newPolicy = newPolicyText.Text;

            // check container name is highlighted
            if (containerList.SelectedItem == null)
            {
                MessageBox.Show("No container selected.", "No container");
                return;
            }
            containerName = containerList.SelectedItem.ToString();

            if (blobClient == null)
            {
                MessageBox.Show("Connect to your storage account first.", "No connection");
                return;
            }

            // get the container reference
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            BlobContainerPermissions containerPermissions = container.GetPermissions();
            containerPermissions.SharedAccessPolicies.Add(newPolicy, new Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPolicy()
            {
                SharedAccessStartTime = DateTime.Now.AddMinutes(-5),
                SharedAccessExpiryTime = DateTime.Now.AddYears(2),
                Permissions = Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions.Write | Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions.Read |
                          Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions.List | Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions.Delete
            });
            container.SetPermissions(containerPermissions);

            // redisplay the container policies
            listContainerPolicies();
        }

        private void newPolicyText_MouseClick(object sender, MouseEventArgs e)
        {
            newPolicyText.SelectAll();
        }

        private void deletePolicyButton_Click(object sender, EventArgs e)
        {

            // check policy name is highlighted
            if (policyList.SelectedItem == null)
            {
                MessageBox.Show("No policy selected.", "No policy");
                return;
            }

            policyName = policyList.SelectedItem.ToString();
            containerName = containerList.SelectedItem.ToString();

            if (blobClient == null)
            {
                MessageBox.Show("Connect to your storage account first.", "No connection");
                return;
            }

            // confirm user really wants to do this
            DialogResult answer = MessageBox.Show("Are you sure you want to delete policy: "
                + policyName + "?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (answer.Equals(DialogResult.No)) return;

            // get the container reference
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            BlobContainerPermissions containerPermissions = container.GetPermissions();

            containerPermissions.SharedAccessPolicies.Remove(policyName);
            container.SetPermissions(containerPermissions);

            // redisplay the container policies
            listContainerPolicies();
        }

        private void deleteAccountBtn_Click(object sender, EventArgs e)
        {
            // check account is highlighted
            if (accountList.SelectedItem == null)
            {
                MessageBox.Show("No account selected.", "No account");
                return;
            }

            // confirm user really wants to do this
            DialogResult answer = MessageBox.Show("Are you sure you want to delete storage account: "
                + accountName + "?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (answer.Equals(DialogResult.No)) return;

            // Since account was highlighted, accountName and accountKey will have been 
            //  assigned the values to delete by the accountList Click event handler
          
            // delete account
            // work out the name to the keys in the config file
            int accNumber = accountList.SelectedIndex;
            string accKeyName = "Account" + accNumber;
            string keyKeyName = "Key" + accNumber;

            System.Configuration.Configuration cfg =
                ConfigurationManager.OpenExeConfiguration(configFile);
            cfg.AppSettings.Settings.Remove(accKeyName);
            cfg.AppSettings.Settings.Remove(keyKeyName);

            // Save the configuration file.
            cfg.Save(ConfigurationSaveMode.Full, true);

            // remove it from the account list box
            accountList.Items.Remove(accountName);

            // remove it from the key list
            keyList.Remove(keyText.Text);

            // clear the account name and key texts
            accountText.Clear();
            keyText.Clear();

            // clear listBoxes
            containerList.Items.Clear();
            policyList.Items.Clear();
            blobList.Items.Clear();

            // confirmation dialog
            MessageBox.Show("Account deleted", "Success");
        }
    }
}
