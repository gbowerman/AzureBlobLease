/*
 * Azure Blob Lease Tool
 * 
 * To do: 
 *   Improve display and framing
 *   Add support for container profiles
 *   
 *   For questions contact: guybo@outlook.com
 *   Last modified: 4/27/13
 */

using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using Microsoft.WindowsAzure.Storage.Auth;
using System.IO;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace AzureBlobLease
{
    public partial class AzureBlob : Form
    {
        String accountName = null;
        String accountKey = null;
        CloudBlobClient blobClient = null;
        string containerName = null;
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
            listContainers();
        }

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
                CloudStorageAccount storageAccount = 
                    new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
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

        private void containerList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBlobs();
        }

        private void listBlobs()
        {
            if (containerList.SelectedItem == null) return;
            containerName = containerList.SelectedItem.ToString();

            // now list blobs for this container
            // retrieve reference to a previously created container
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // display the name of each blob in the container (could be block or page blobs)
            blobList.Items.Clear();
            foreach (var blobItem in container.ListBlobs())
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

        // Save storage key to a filename determined by account name, in local app storage
        private void saveStorageAccButton_Click(object sender, EventArgs e)
        {
            string accountName = null;

            if (accountText.Text.Length < 1 || keyText.Text.Length < 1)
            {
                MessageBox.Show("You need to enter an account and key in order to save.", "Nothing to save");
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
                MessageBox.Show("Enter a value for the new container first.", "No container");
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
    }
}
