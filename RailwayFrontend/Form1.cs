using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ModelLibrary;
using ModelLibrary.Enums;
using Database;

namespace RailwayFrontend
{
    public partial class Form1 : Form
    {
        private ClientsAdministration adminClients;
        private TrainAdministration trainAdmin;
        private Client currentClient = new Client();
        private int nrClients = 0;

        public Form1()
        {
            InitializeComponent();
            string fileName = ConfigurationManager.AppSettings["clients"] ?? "clients.txt";
            adminClients = new ClientsAdministration(fileName);
            trainAdmin = new TrainAdministration();

            // Make sure the tab and group box texts are correct
            tabPurchasedTickets.Text = "Purchased Tickets";
            grpPurchasedTickets.Text = "All Purchased Tickets";

            LoadClients();
            LoadAvailableTicketTemplates();
            LoadPurchasedTickets();
            LoadTrains();
            LoadClientSelector();
            LoadTrainSelector();
        }

        private void LoadClients()
        {
            Client[] clients = adminClients.GetClients(out nrClients);
            lstClients.Items.Clear();
            foreach (Client client in clients)
            {
                lstClients.Items.Add($"{client.id}: {client.name} {client.last_name}");
            }

            // Also refresh the client selector dropdown
            LoadClientSelector();
        }

        private void LoadClientSelector()
        {
            Client[] clients = adminClients.GetClients(out _);
            cboClientSelector.Items.Clear();
            foreach (Client client in clients)
            {
                cboClientSelector.Items.Add($"{client.id}: {client.name} {client.last_name}");
            }
        }

        private void LoadTrainSelector()
        {
            Train[] trains = trainAdmin.GetTrains();
            cboTrainSelector.Items.Clear();
            cboTrainSelector.Items.Add("0: No Train");
            foreach (Train train in trains)
            {
                cboTrainSelector.Items.Add($"{train.Id}: {train.Name}");
            }

            if (cboTrainSelector.Items.Count > 0)
                cboTrainSelector.SelectedIndex = 0;
        }

        private void LoadTrains()
        {
            Train[] trains = trainAdmin.GetTrains();
            lstTrains.Items.Clear();
            foreach (Train train in trains)
            {
                lstTrains.Items.Add(train.Info());
            }
        }

        private void LoadAvailableTicketTemplates()
        {
            Ticket[] availableTickets = TicketsAdministration.GetTicketTemplates();
            lstAvailableTickets.Items.Clear();
            foreach (Ticket ticket in availableTickets)
            {
                lstAvailableTickets.Items.Add(ticket.Info());
            }
        }

        private void LoadPurchasedTickets()
        {
            Ticket[] purchasedTickets = TicketsAdministration.GetPurchasedTickets();
            lstPurchasedTickets.Items.Clear();
            foreach (Ticket ticket in purchasedTickets)
            {
                lstPurchasedTickets.Items.Add(ticket.Info());
            }
        }

        private void LoadClientTickets()
        {
            if (currentClient.id <= 0)
            {
                MessageBox.Show("Please select a client first!");
                return;
            }

            Ticket[] clientTickets = TicketsAdministration.GetTicketsByClientId(currentClient.id);

            // Filter tickets in the purchased tickets list to show only those for the current client
            lstPurchasedTickets.Items.Clear();
            foreach (Ticket ticket in clientTickets)
            {
                lstPurchasedTickets.Items.Add(ticket.Info());
            }
        }

        private void btnRegisterClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter name and last name.");
                return;
            }

            try
            {
                int age = Convert.ToInt32(txtAge.Text);
                currentClient = new Client(txtName.Text, txtLastName.Text, age);

                // Set account type
                if (rbAdult.Checked)
                    currentClient.accountType = AccountType.Adult;
                else if (rbStudent.Checked)
                    currentClient.accountType = AccountType.Student;
                else if (rbChildren.Checked)
                    currentClient.accountType = AccountType.Children;
                else if (rbRetired.Checked)
                    currentClient.accountType = AccountType.Retired;
                else
                {
                    MessageBox.Show("Please select an account type.");
                    return;
                }

                // Save the client
                currentClient.id = ++nrClients;
                adminClients.AddClient(currentClient);

                MessageBox.Show($"Client registered successfully with ID: {currentClient.id}");
                LoadClients();
                ClearClientInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ClearClientInputs()
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtAge.Text = "";
            rbAdult.Checked = false;
            rbStudent.Checked = false;
            rbChildren.Checked = false;
            rbRetired.Checked = false;
        }

        private void btnCreateTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDeparture.Text) || string.IsNullOrWhiteSpace(txtDestination.Text))
                {
                    MessageBox.Show("Please enter departure and destination stations.");
                    return;
                }

                int price = Convert.ToInt32(txtPrice.Text);

                TicketFeatures features = TicketFeatures.None;
                if (chkWifi.Checked) features |= TicketFeatures.WiFi;
                if (chkMeal.Checked) features |= TicketFeatures.MealIncluded;
                if (chkFirstClass.Checked) features |= TicketFeatures.FirstClass;
                if (chkSleeper.Checked) features |= TicketFeatures.SleeperCar;

                Ticket ticket = new Ticket(
                    0,
                    txtDeparture.Text,
                    txtDestination.Text,
                    dtpDeparture.Value,
                    dtpArrival.Value,
                    price,
                    features
                );

                TicketsAdministration.AddTicket(ticket);
                MessageBox.Show("Ticket template created successfully!");
                LoadAvailableTicketTemplates();
                ClearTicketInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ClearTicketInputs()
        {
            txtDeparture.Text = "";
            txtDestination.Text = "";
            txtPrice.Text = "";
            chkWifi.Checked = false;
            chkMeal.Checked = false;
            chkFirstClass.Checked = false;
            chkSleeper.Checked = false;
        }

        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            if (cboClientSelector.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a client from the dropdown!");
                return;
            }

            if (lstAvailableTickets.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a ticket template to purchase!");
                return;
            }

            try
            {
                // Get the selected client ID and name from the dropdown
                string selectedClientText = cboClientSelector.SelectedItem.ToString();
                int clientId = int.Parse(selectedClientText.Substring(0, selectedClientText.IndexOf(':')));
                string clientName = selectedClientText.Substring(selectedClientText.IndexOf(':') + 1).Trim();

                // Get selected ticket template ID
                string selectedTicket = lstAvailableTickets.SelectedItem.ToString();
                int ticketId = int.Parse(selectedTicket.Substring(selectedTicket.IndexOf('#') + 1,
                                                                selectedTicket.IndexOf(':') - selectedTicket.IndexOf('#') - 1));

                // Get selected train ID
                int trainId = 0;
                if (cboTrainSelector.SelectedIndex > 0) // Skip "No Train" option
                {
                    string selectedTrainText = cboTrainSelector.SelectedItem.ToString();
                    trainId = int.Parse(selectedTrainText.Substring(0, selectedTrainText.IndexOf(':')));
                }

                bool success = TicketsAdministration.BuyTicket(ticketId, clientId, trainId, clientName);

                if (success)
                {
                    MessageBox.Show("Ticket purchased successfully!");
                    // The ticket template remains available
                    LoadAvailableTicketTemplates();
                    // Update the purchased tickets list
                    LoadPurchasedTickets();

                    // Update the current client to the selected one and load their tickets
                    Client[] clients = adminClients.GetClients(out _);
                    currentClient = clients.FirstOrDefault(c => c.id == clientId) ?? new Client();
                    LoadClientTickets();
                }
                else
                {
                    MessageBox.Show("Failed to purchase ticket. Template ticket not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClients.SelectedIndex != -1)
            {
                string selectedClient = lstClients.SelectedItem.ToString();
                int clientId = int.Parse(selectedClient.Substring(0, selectedClient.IndexOf(':')));

                // Get client information from database
                Client[] clients = adminClients.GetClients(out _);
                currentClient = clients.FirstOrDefault(c => c.id == clientId) ?? new Client();

                // Display client information
                lblSelectedClient.Text = $"Selected Client: {currentClient.name} {currentClient.last_name}";

                // Load tickets for this client
                LoadClientTickets();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadClients();
            LoadAvailableTicketTemplates();
            LoadPurchasedTickets();
            LoadClientTickets();
            LoadTrains();
            LoadTrainSelector();
        }

        private void btnAddTrain_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTrainName.Text))
                {
                    MessageBox.Show("Please enter a train name.");
                    return;
                }

                int seats = Convert.ToInt32(txtSeats.Text);
                int wagons = Convert.ToInt32(txtWagons.Text);

                FuelType fuelType = rbDiesel.Checked ? FuelType.Diesel : FuelType.Gasoline;

                Train train = new Train(0, txtTrainName.Text, seats, wagons, fuelType);
                trainAdmin.AddTrain(train);

                MessageBox.Show("Train added successfully!");
                LoadTrains();
                LoadTrainSelector();
                ClearTrainInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ClearTrainInputs()
        {
            txtTrainName.Text = "";
            txtSeats.Text = "";
            txtWagons.Text = "";
            rbDiesel.Checked = true;
            rbGasoline.Checked = false;
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            currentClient = new Client();
            lblSelectedClient.Text = "Selected Client: None";

            // Update purchased tickets to show all tickets again
            LoadPurchasedTickets();
        }
    }
}