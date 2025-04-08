using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ModelLibrary;
using Database;
using System.Collections.Generic;

namespace ClientManagementApp
{
    public partial class Form1 : Form
    {
        // Constants for validation
        private const int MAX_NAME_LENGTH = 15;
        private Panel leftMenuPanel;
        private Button btnShowClients;
        private Button btnShowTickets;
        private Button btnClientRegistration;
        private Panel mainContentPanel;
        private Label lblTitle;
        private DataGridView dgvClients;
        private Client[] clients;

        // Components for client registration
        private Label[,] lblClientInfo;
        private TextBox txtClientId;
        private TextBox txtClientName;
        private TextBox txtClientLastName;
        private ComboBox cmbAccountType;
        private Button btnAddClient;
        private Button btnRefreshClient;
        private Dictionary<Control, Label> errorLabels;

        // Components for refresh buttons
        private Button btnRefreshClients;
        private Button btnRefreshTickets;

        public Form1()
        {
            // Initialize form manually
            this.Text = "Client Management";
            this.Size = new Size(1000, 600); // Increased size to accommodate the left menu
            this.BackColor = Color.FromArgb(240, 248, 255); // Light off-white background for a clean look
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            errorLabels = new Dictionary<Control, Label>();

            InitializeComponents();

            // Set the default view to Show Clients
            ShowClientsView();
        }

        private void InitializeComponents()
        {
            // Create the left menu panel
            leftMenuPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(200, 600),
                BackColor = Color.FromArgb(50, 62, 72) // Dark background for the menu
            };

            // Create main content panel
            mainContentPanel = new Panel
            {
                Location = new Point(200, 0),
                Size = new Size(800, 600),
                BackColor = Color.FromArgb(240, 248, 255)
            };

            // Initialize menu buttons
            btnShowClients = CreateMenuButton("Show Clients", 0);
            btnShowTickets = CreateMenuButton("Show Tickets", 1);
            btnClientRegistration = CreateMenuButton("Client Registration", 2);

            // Add event handlers for buttons
            btnShowClients.Click += (s, e) => ShowClientsView();
            btnShowTickets.Click += (s, e) => ShowTicketsView();
            btnClientRegistration.Click += (s, e) => ShowClientRegistrationView();

            // Add buttons to the left menu panel
            leftMenuPanel.Controls.Add(btnShowClients);
            leftMenuPanel.Controls.Add(btnShowTickets);
            leftMenuPanel.Controls.Add(btnClientRegistration);

            // Initialize title label with a refined look
            lblTitle = new Label()
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkSlateGray // Modern, darker text color for readability
            };
            mainContentPanel.Controls.Add(lblTitle);

            // Initialize DataGridView for displaying clients with professional styling
            dgvClients = new DataGridView()
            {
                Size = new Size(700, 400),
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
                },
                Visible = false
            };

            // Add columns for Client Information
            dgvClients.Columns.Add("ClientID", "Client ID");
            dgvClients.Columns.Add("Name", "Name");
            dgvClients.Columns.Add("LastName", "Last Name");
            dgvClients.Columns.Add("AccountType", "Account Type");
            mainContentPanel.Controls.Add(dgvClients);

            // Initialize refresh buttons
            btnRefreshClients = CreateButton("Refresh", new Point(650, 20), new Size(100, 30));
            btnRefreshClients.Click += (s, e) => LoadClients();

            btnRefreshTickets = CreateButton("Refresh", new Point(650, 20), new Size(100, 30));
            btnRefreshTickets.Click += (s, e) => RefreshTickets();

            // Initialize Client Registration components
            InitializeClientRegistrationComponents();

            // Add panels to the form
            this.Controls.Add(leftMenuPanel);
            this.Controls.Add(mainContentPanel);
        }

        private void InitializeClientRegistrationComponents()
        {
            // Create 2D array of labels for client info sections (3 rows, 2 columns)
            lblClientInfo = new Label[3, 2];

            // Define properties and labels
            string[] propertyNames = { "Client ID:", "Name:", "Last Name:" };

            // Initialize labels for each property
            for (int i = 0; i < propertyNames.Length; i++)
            {
                // Property name label
                lblClientInfo[i, 0] = new Label
                {
                    Text = propertyNames[i],
                    Location = new Point(50, 100 + i * 50),
                    Size = new Size(100, 30),
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleRight
                };

                // Error message label (initially empty)
                lblClientInfo[i, 1] = new Label
                {
                    Text = "",
                    Location = new Point(350, 100 + i * 50),
                    Size = new Size(300, 30),
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.Red,
                    TextAlign = ContentAlignment.MiddleLeft
                };
            }

            // Create input fields
            txtClientId = new TextBox
            {
                Location = new Point(160, 100),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10)
            };

            txtClientName = new TextBox
            {
                Location = new Point(160, 150),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10)
            };

            txtClientLastName = new TextBox
            {
                Location = new Point(160, 200),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10)
            };

            // Account type ComboBox
            Label lblAccountType = new Label
            {
                Text = "Account Type:",
                Location = new Point(50, 250),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleRight
            };

            cmbAccountType = new ComboBox
            {
                Location = new Point(160, 250),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbAccountType.Items.Add("Adult");
            cmbAccountType.Items.Add("Student");
            cmbAccountType.Items.Add("Children");
            cmbAccountType.Items.Add("Retired");
            cmbAccountType.SelectedIndex = 0;

            // Error label for account type
            Label lblAccountTypeError = new Label
            {
                Text = "",
                Location = new Point(350, 250),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Add and Refresh buttons
            btnAddClient = CreateButton("Add Client", new Point(160, 320), new Size(120, 40));
            btnRefreshClient = CreateButton("Refresh", new Point(290, 320), new Size(120, 40));

            // Wire up event handlers
            btnAddClient.Click += BtnAddClient_Click;
            btnRefreshClient.Click += BtnRefreshClient_Click;

            // Store error labels for validation
            errorLabels[txtClientId] = lblClientInfo[0, 1];
            errorLabels[txtClientName] = lblClientInfo[1, 1];
            errorLabels[txtClientLastName] = lblClientInfo[2, 1];
            errorLabels[cmbAccountType] = lblAccountTypeError;
        }

        private Button CreateButton(string text, Point location, Size size)
        {
            return new Button
            {
                Text = text,
                Location = location,
                Size = size,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
        }

        private Button CreateMenuButton(string text, int position)
        {
            Button button = new Button
            {
                Text = text,
                Location = new Point(0, 100 + position * 60),
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 12),
                BackColor = Color.FromArgb(50, 62, 72),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            // Add hover effect
            button.MouseEnter += (s, e) => button.BackColor = Color.FromArgb(80, 92, 102);
            button.MouseLeave += (s, e) => button.BackColor = Color.FromArgb(50, 62, 72);

            return button;
        }

        private void ShowClientsView()
        {
            // Update title and visibility
            lblTitle.Text = "Client Management";
            lblTitle.Location = new Point(250, 20);

            // Position and show the clients grid
            dgvClients.Location = new Point(50, 60);
            dgvClients.Visible = true;

            // Clear main panel and add back controls for this view
            RefreshMainPanel();
            mainContentPanel.Controls.Add(lblTitle);
            mainContentPanel.Controls.Add(dgvClients);
            mainContentPanel.Controls.Add(btnRefreshClients);

            // Highlight the selected button
            SetActiveButton(btnShowClients);

            // Load client data
            LoadClients();
        }

        private void ShowTicketsView()
        {
            // Update title and visibility
            lblTitle.Text = "Tickets Management";
            lblTitle.Location = new Point(250, 20);
            dgvClients.Visible = false;

            // Clear main panel and add back controls for this view
            RefreshMainPanel();
            mainContentPanel.Controls.Add(lblTitle);
            mainContentPanel.Controls.Add(btnRefreshTickets);

            // Add placeholder label for tickets view (to be implemented)
            Label placeholderLabel = new Label
            {
                Text = "Tickets Management view will be implemented here.",
                Location = new Point(250, 200),
                AutoSize = true,
                Font = new Font("Segoe UI", 12)
            };
            mainContentPanel.Controls.Add(placeholderLabel);

            // Highlight the selected button
            SetActiveButton(btnShowTickets);
        }

        private void ShowClientRegistrationView()
        {
            // Update title and visibility
            lblTitle.Text = "Client Registration";
            lblTitle.Location = new Point(250, 20);
            dgvClients.Visible = false;

            // Clear main panel and add back controls for this view
            RefreshMainPanel();
            mainContentPanel.Controls.Add(lblTitle);

            // Add client registration form controls
            for (int i = 0; i < 3; i++)
            {
                mainContentPanel.Controls.Add(lblClientInfo[i, 0]);
                mainContentPanel.Controls.Add(lblClientInfo[i, 1]);
            }

            mainContentPanel.Controls.Add(txtClientId);
            mainContentPanel.Controls.Add(txtClientName);
            mainContentPanel.Controls.Add(txtClientLastName);

            // Add account type dropdown
            Label lblAccountType = new Label
            {
                Text = "Account Type:",
                Location = new Point(50, 250),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleRight
            };
            mainContentPanel.Controls.Add(lblAccountType);
            mainContentPanel.Controls.Add(cmbAccountType);
            mainContentPanel.Controls.Add(errorLabels[cmbAccountType]);

            // Add buttons
            mainContentPanel.Controls.Add(btnAddClient);
            mainContentPanel.Controls.Add(btnRefreshClient);

            // Highlight the selected button
            SetActiveButton(btnClientRegistration);
        }

        private void RefreshMainPanel()
        {
            // Clear all controls from the main panel
            mainContentPanel.Controls.Clear();
        }

        private void SetActiveButton(Button activeButton)
        {
            // Reset all buttons to default state
            btnShowClients.BackColor = Color.FromArgb(50, 62, 72);
            btnShowTickets.BackColor = Color.FromArgb(50, 62, 72);
            btnClientRegistration.BackColor = Color.FromArgb(50, 62, 72);

            // Highlight the active button
            activeButton.BackColor = Color.FromArgb(33, 150, 243);
        }

        private void LoadClients()
        {
            try
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
                        // Convert account type to string for display
                        string accountTypeString = client.accountType.ToString();

                        dgvClients.Rows.Add(
                            client.id.ToString(),
                            client.name,
                            client.last_name,
                            accountTypeString
                        );
                    }
                }

                // Show confirmation message
                MessageBox.Show("Client data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshTickets()
        {
            // Placeholder for ticket refresh functionality
            MessageBox.Show("Tickets refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event handler for Add Client button
        private void BtnAddClient_Click(object sender, EventArgs e)
        {
            // Reset error messages and label colors
            ResetValidation();

            // Validate input
            if (!ValidateClientInput())
            {
                return; // Validation failed
            }

            try
            {
                // Create new client - with type conversions as needed
                Client newClient = new Client();

                // Convert id to int if needed (assuming Client.id is int)
                if (int.TryParse(txtClientId.Text, out int clientId))
                {
                    newClient.id = clientId;
                }
                else
                {
                    SetValidationError(txtClientId, "Client ID must be a number");
                    return;
                }

                // Set string properties
                newClient.name = txtClientName.Text;
                newClient.last_name = txtClientLastName.Text;

                // Set account type based on selection (using Enum.Parse if it's an enum)
                string selectedAccountType = cmbAccountType.SelectedItem.ToString();

                // If accountType is an enum in ModelLibrary.Enums namespace
                // Convert string to enum value
                if (Enum.TryParse(selectedAccountType, out ModelLibrary.Enums.AccountType accountType))
                {
                    newClient.accountType = accountType;
                }

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

                // Add client to file
                ClientsAdministration clientDataManager = new ClientsAdministration(fullPath);
                clientDataManager.AddClient(newClient);

                // Show success message
                MessageBox.Show("Client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form fields
                ClearClientForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for Refresh Client button
        private void BtnRefreshClient_Click(object sender, EventArgs e)
        {
            try
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

                // Get last client from file
                ClientsAdministration clientDataManager = new ClientsAdministration(fullPath);
                int clientCount = 0;
                clients = clientDataManager.GetClients(out clientCount);

                if (clientCount > 0 && clients[clientCount - 1] != null)
                {
                    Client lastClient = clients[clientCount - 1];

                    // Display last client's data in form - with appropriate type conversions
                    txtClientId.Text = lastClient.id.ToString(); // Convert int to string if needed
                    txtClientName.Text = lastClient.name;
                    txtClientLastName.Text = lastClient.last_name;

                    // Find and select the matching account type
                    string accountTypeString = lastClient.accountType.ToString();
                    for (int i = 0; i < cmbAccountType.Items.Count; i++)
                    {
                        if (cmbAccountType.Items[i].ToString() == accountTypeString)
                        {
                            cmbAccountType.SelectedIndex = i;
                            break;
                        }
                    }

                    MessageBox.Show("Last client data loaded successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No clients found in the database.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing client data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validate client input data
        private bool ValidateClientInput()
        {
            bool isValid = true;

            // Validate Client ID
            if (string.IsNullOrWhiteSpace(txtClientId.Text))
            {
                SetValidationError(txtClientId, "Client ID is required");
                isValid = false;
            }
            else if (!int.TryParse(txtClientId.Text, out _))
            {
                SetValidationError(txtClientId, "Client ID must be a number");
                isValid = false;
            }

            // Validate Name
            if (string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                SetValidationError(txtClientName, "Name is required");
                isValid = false;
            }
            else if (txtClientName.Text.Length > MAX_NAME_LENGTH)
            {
                SetValidationError(txtClientName, $"Name cannot exceed {MAX_NAME_LENGTH} characters");
                isValid = false;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(txtClientLastName.Text))
            {
                SetValidationError(txtClientLastName, "Last Name is required");
                isValid = false;
            }
            else if (txtClientLastName.Text.Length > MAX_NAME_LENGTH)
            {
                SetValidationError(txtClientLastName, $"Last Name cannot exceed {MAX_NAME_LENGTH} characters");
                isValid = false;
            }

            // Validate Account Type
            if (cmbAccountType.SelectedIndex == -1)
            {
                SetValidationError(cmbAccountType, "Account Type is required");
                isValid = false;
            }

            return isValid;
        }

        // Set validation error for a control
        private void SetValidationError(Control control, string errorMessage)
        {
            if (control == txtClientId)
                lblClientInfo[0, 0].ForeColor = Color.Red;
            else if (control == txtClientName)
                lblClientInfo[1, 0].ForeColor = Color.Red;
            else if (control == txtClientLastName)
                lblClientInfo[2, 0].ForeColor = Color.Red;

            if (errorLabels.ContainsKey(control))
            {
                errorLabels[control].Text = errorMessage;
            }
        }

        // Reset validation state
        private void ResetValidation()
        {
            // Reset label colors
            for (int i = 0; i < 3; i++)
            {
                lblClientInfo[i, 0].ForeColor = Color.Black;
                lblClientInfo[i, 1].Text = "";
            }

            // Reset error for account type
            errorLabels[cmbAccountType].Text = "";
        }

        // Clear client form
        private void ClearClientForm()
        {
            txtClientId.Text = "";
            txtClientName.Text = "";
            txtClientLastName.Text = "";
            cmbAccountType.SelectedIndex = 0;
            ResetValidation();
        }
    }
}
