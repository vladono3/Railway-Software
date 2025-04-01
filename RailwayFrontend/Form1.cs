using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ModelLibrary;
using Database;

namespace ClientManagementApp
{
    public partial class Form1 : Form
    {
        private Label lblTitle;
        private DataGridView dgvClients;
        private Client[] clients;

        public Form1()
        {
            // Initialize form manually
            this.Text = "Client Management";
            this.Size = new Size(800, 500); // Increased size for better view
            this.BackColor = Color.FromArgb(240, 248, 255); // Light off-white background for a clean look
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Initialize title label with a refined look
            lblTitle = new Label()
            {
                Text = "Client Management",
                Location = new Point(250, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkSlateGray // Modern, darker text color for readability
            };

            // Initialize DataGridView for displaying clients with professional styling
            dgvClients = new DataGridView()
            {
                Location = new Point(50, 80),
                Size = new Size(700, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BorderStyle = BorderStyle.None, // Remove border for a cleaner look
                BackgroundColor = Color.White,
                GridColor = Color.FromArgb(224, 224, 224), // Subtle grid lines for separation
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    BackColor = Color.FromArgb(33, 150, 243), // Professional blue header color
                    ForeColor = Color.White
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10),
                    BackColor = Color.White, // White rows for clarity
                    ForeColor = Color.DarkSlateGray, // Dark text for contrast
                    SelectionBackColor = Color.FromArgb(224, 235, 255), // Subtle selection highlight
                    SelectionForeColor = Color.Black // Black text when selected
                }
            };

            // Add columns for Client Information
            dgvClients.Columns.Add("ClientID", "Client ID");
            dgvClients.Columns.Add("Name", "Name");
            dgvClients.Columns.Add("LastName", "Last Name");
            dgvClients.Columns.Add("AccountType", "Account Type");

            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(dgvClients);

            // Load client data
            LoadClients();
        }

        private void LoadClients()
        {
            // Get the file name from the app settings
            string fileName = ConfigurationManager.AppSettings["clients"];
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("File name is not specified in the configuration.");
                return;
            }

            // Calculate the full path to the file
            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fullPath = Path.Combine(solutionDirectory, fileName);

            ClientsAdministration clientDataManager = new ClientsAdministration(fullPath);
            int clientCount = 0;
            clients = clientDataManager.GetClients(out clientCount);

            // Clear any existing rows in DataGridView
            dgvClients.Rows.Clear();

            // Populate DataGridView with client data
            foreach (var client in clients)
            {
                if (client != null)  // Ensure client object is not null
                {
                    dgvClients.Rows.Add(client.id, client.name, client.last_name, client.accountType);
                }
            }
        }
    }
}
