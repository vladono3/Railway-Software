namespace RailwayFrontend
{
    partial class Form1
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
            this.tabClients = new System.Windows.Forms.TabPage();
            this.tabTickets = new System.Windows.Forms.TabPage();
            this.tabPurchasedTickets = new System.Windows.Forms.TabPage();
            this.tabTrains = new System.Windows.Forms.TabPage();
            this.grpRegisterClient = new System.Windows.Forms.GroupBox();
            this.btnRegisterClient = new System.Windows.Forms.Button();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.rbRetired = new System.Windows.Forms.RadioButton();
            this.rbChildren = new System.Windows.Forms.RadioButton();
            this.rbStudent = new System.Windows.Forms.RadioButton();
            this.rbAdult = new System.Windows.Forms.RadioButton();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpClientList = new System.Windows.Forms.GroupBox();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.lblSelectedClient = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpCreateTicket = new System.Windows.Forms.GroupBox();
            this.chkSleeper = new System.Windows.Forms.CheckBox();
            this.chkFirstClass = new System.Windows.Forms.CheckBox();
            this.chkMeal = new System.Windows.Forms.CheckBox();
            this.chkWifi = new System.Windows.Forms.CheckBox();
            this.lblFeatures = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.dtpArrival = new System.Windows.Forms.DateTimePicker();
            this.lblArrival = new System.Windows.Forms.Label();
            this.dtpDeparture = new System.Windows.Forms.DateTimePicker();
            this.lblDeparture = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.txtDeparture = new System.Windows.Forms.TextBox();
            this.lblDepartureStation = new System.Windows.Forms.Label();
            this.btnCreateTicket = new System.Windows.Forms.Button();
            this.grpAvailableTickets = new System.Windows.Forms.GroupBox();
            this.lblTrainSelect = new System.Windows.Forms.Label();
            this.cboTrainSelector = new System.Windows.Forms.ComboBox();
            this.lblClientSelect = new System.Windows.Forms.Label();
            this.cboClientSelector = new System.Windows.Forms.ComboBox();
            this.btnBuyTicket = new System.Windows.Forms.Button();
            this.lstAvailableTickets = new System.Windows.Forms.ListBox();
            this.grpPurchasedTickets = new System.Windows.Forms.GroupBox();
            this.lstPurchasedTickets = new System.Windows.Forms.ListBox();
            this.grpAddTrain = new System.Windows.Forms.GroupBox();
            this.btnAddTrain = new System.Windows.Forms.Button();
            this.lblFuelType = new System.Windows.Forms.Label();
            this.rbGasoline = new System.Windows.Forms.RadioButton();
            this.rbDiesel = new System.Windows.Forms.RadioButton();
            this.txtWagons = new System.Windows.Forms.TextBox();
            this.lblWagons = new System.Windows.Forms.Label();
            this.txtSeats = new System.Windows.Forms.TextBox();
            this.lblSeats = new System.Windows.Forms.Label();
            this.txtTrainName = new System.Windows.Forms.TextBox();
            this.lblTrainName = new System.Windows.Forms.Label();
            this.grpTrainList = new System.Windows.Forms.GroupBox();
            this.lstTrains = new System.Windows.Forms.ListBox();

            this.tabControl.SuspendLayout();
            this.tabClients.SuspendLayout();
            this.grpRegisterClient.SuspendLayout();
            this.grpClientList.SuspendLayout();
            this.tabTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpCreateTicket.SuspendLayout();
            this.grpAvailableTickets.SuspendLayout();
            this.tabPurchasedTickets.SuspendLayout();
            this.grpPurchasedTickets.SuspendLayout();
            this.tabTrains.SuspendLayout();
            this.grpAddTrain.SuspendLayout();
            this.grpTrainList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabClients);
            this.tabControl.Controls.Add(this.tabTickets);
            this.tabControl.Controls.Add(this.tabPurchasedTickets);
            this.tabControl.Controls.Add(this.tabTrains);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabClients
            // 
            this.tabClients.Controls.Add(this.grpRegisterClient);
            this.tabClients.Controls.Add(this.grpClientList);
            this.tabClients.Location = new System.Drawing.Point(4, 22);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabClients.Size = new System.Drawing.Size(792, 424);
            this.tabClients.TabIndex = 0;
            this.tabClients.Text = "Clients";
            this.tabClients.UseVisualStyleBackColor = true;
            // 
            // grpRegisterClient
            // 
            this.grpRegisterClient.Controls.Add(this.btnRegisterClient);
            this.grpRegisterClient.Controls.Add(this.lblAccountType);
            this.grpRegisterClient.Controls.Add(this.rbRetired);
            this.grpRegisterClient.Controls.Add(this.rbChildren);
            this.grpRegisterClient.Controls.Add(this.rbStudent);
            this.grpRegisterClient.Controls.Add(this.rbAdult);
            this.grpRegisterClient.Controls.Add(this.txtAge);
            this.grpRegisterClient.Controls.Add(this.lblAge);
            this.grpRegisterClient.Controls.Add(this.txtLastName);
            this.grpRegisterClient.Controls.Add(this.lblLastName);
            this.grpRegisterClient.Controls.Add(this.txtName);
            this.grpRegisterClient.Controls.Add(this.lblName);
            this.grpRegisterClient.Location = new System.Drawing.Point(8, 6);
            this.grpRegisterClient.Name = "grpRegisterClient";
            this.grpRegisterClient.Size = new System.Drawing.Size(309, 410);
            this.grpRegisterClient.TabIndex = 0;
            this.grpRegisterClient.TabStop = false;
            this.grpRegisterClient.Text = "Register New Client";
            // 
            // btnRegisterClient
            // 
            this.btnRegisterClient.Location = new System.Drawing.Point(21, 354);
            this.btnRegisterClient.Name = "btnRegisterClient";
            this.btnRegisterClient.Size = new System.Drawing.Size(266, 37);
            this.btnRegisterClient.TabIndex = 11;
            this.btnRegisterClient.Text = "Register Client";
            this.btnRegisterClient.UseVisualStyleBackColor = true;
            this.btnRegisterClient.Click += new System.EventHandler(this.btnRegisterClient_Click);
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(18, 184);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(77, 13);
            this.lblAccountType.TabIndex = 10;
            this.lblAccountType.Text = "Account Type:";
            // 
            // rbRetired
            // 
            this.rbRetired.AutoSize = true;
            this.rbRetired.Location = new System.Drawing.Point(21, 299);
            this.rbRetired.Name = "rbRetired";
            this.rbRetired.Size = new System.Drawing.Size(60, 17);
            this.rbRetired.TabIndex = 9;
            this.rbRetired.TabStop = true;
            this.rbRetired.Text = "Retired";
            this.rbRetired.UseVisualStyleBackColor = true;
            // 
            // rbChildren
            // 
            this.rbChildren.AutoSize = true;
            this.rbChildren.Location = new System.Drawing.Point(21, 263);
            this.rbChildren.Name = "rbChildren";
            this.rbChildren.Size = new System.Drawing.Size(64, 17);
            this.rbChildren.TabIndex = 8;
            this.rbChildren.TabStop = true;
            this.rbChildren.Text = "Children";
            this.rbChildren.UseVisualStyleBackColor = true;
            // 
            // rbStudent
            // 
            this.rbStudent.AutoSize = true;
            this.rbStudent.Location = new System.Drawing.Point(21, 227);
            this.rbStudent.Name = "rbStudent";
            this.rbStudent.Size = new System.Drawing.Size(62, 17);
            this.rbStudent.TabIndex = 7;
            this.rbStudent.TabStop = true;
            this.rbStudent.Text = "Student";
            this.rbStudent.UseVisualStyleBackColor = true;
            // 
            // rbAdult
            // 
            this.rbAdult.AutoSize = true;
            this.rbAdult.Location = new System.Drawing.Point(21, 204);
            this.rbAdult.Name = "rbAdult";
            this.rbAdult.Size = new System.Drawing.Size(49, 17);
            this.rbAdult.TabIndex = 6;
            this.rbAdult.TabStop = true;
            this.rbAdult.Text = "Adult";
            this.rbAdult.UseVisualStyleBackColor = true;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(21, 144);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(266, 20);
            this.txtAge.TabIndex = 5;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(18, 127);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(29, 13);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "Age:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(21, 92);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(266, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(18, 75);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(21, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(266, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(18, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // grpClientList
            // 
            this.grpClientList.Controls.Add(this.btnClearSelection);
            this.grpClientList.Controls.Add(this.lblSelectedClient);
            this.grpClientList.Controls.Add(this.btnRefresh);
            this.grpClientList.Controls.Add(this.lstClients);
            this.grpClientList.Location = new System.Drawing.Point(323, 6);
            this.grpClientList.Name = "grpClientList";
            this.grpClientList.Size = new System.Drawing.Size(461, 410);
            this.grpClientList.TabIndex = 1;
            this.grpClientList.TabStop = false;
            this.grpClientList.Text = "Client List";
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(244, 348);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(211, 23);
            this.btnClearSelection.TabIndex = 3;
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // lblSelectedClient
            // 
            this.lblSelectedClient.AutoSize = true;
            this.lblSelectedClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedClient.Location = new System.Drawing.Point(6, 26);
            this.lblSelectedClient.Name = "lblSelectedClient";
            this.lblSelectedClient.Size = new System.Drawing.Size(144, 15);
            this.lblSelectedClient.TabIndex = 2;
            this.lblSelectedClient.Text = "Selected Client: None";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 348);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(211, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.Location = new System.Drawing.Point(6, 53);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(449, 277);
            this.lstClients.TabIndex = 0;
            this.lstClients.SelectedIndexChanged += new System.EventHandler(this.lstClients_SelectedIndexChanged);
            // 
            // tabTickets
            // 
            this.tabTickets.Controls.Add(this.splitContainer1);
            this.tabTickets.Location = new System.Drawing.Point(4, 22);
            this.tabTickets.Name = "tabTickets";
            this.tabTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabTickets.Size = new System.Drawing.Size(792, 424);
            this.tabTickets.TabIndex = 1;
            this.tabTickets.Text = "Tickets";
            this.tabTickets.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpCreateTicket);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpAvailableTickets);
            this.splitContainer1.Size = new System.Drawing.Size(786, 418);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpCreateTicket
            // 
            this.grpCreateTicket.Controls.Add(this.chkSleeper);
            this.grpCreateTicket.Controls.Add(this.chkFirstClass);
            this.grpCreateTicket.Controls.Add(this.chkMeal);
            this.grpCreateTicket.Controls.Add(this.chkWifi);
            this.grpCreateTicket.Controls.Add(this.lblFeatures);
            this.grpCreateTicket.Controls.Add(this.txtPrice);
            this.grpCreateTicket.Controls.Add(this.lblPrice);
            this.grpCreateTicket.Controls.Add(this.dtpArrival);
            this.grpCreateTicket.Controls.Add(this.lblArrival);
            this.grpCreateTicket.Controls.Add(this.dtpDeparture);
            this.grpCreateTicket.Controls.Add(this.lblDeparture);
            this.grpCreateTicket.Controls.Add(this.txtDestination);
            this.grpCreateTicket.Controls.Add(this.lblDestination);
            this.grpCreateTicket.Controls.Add(this.txtDeparture);
            this.grpCreateTicket.Controls.Add(this.lblDepartureStation);
            this.grpCreateTicket.Controls.Add(this.btnCreateTicket);
            this.grpCreateTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCreateTicket.Location = new System.Drawing.Point(0, 0);
            this.grpCreateTicket.Name = "grpCreateTicket";
            this.grpCreateTicket.Size = new System.Drawing.Size(394, 418);
            this.grpCreateTicket.TabIndex = 0;
            this.grpCreateTicket.TabStop = false;
            this.grpCreateTicket.Text = "Create Ticket";
            // 
            // chkSleeper
            // 
            this.chkSleeper.AutoSize = true;
            this.chkSleeper.Location = new System.Drawing.Point(202, 273);
            this.chkSleeper.Name = "chkSleeper";
            this.chkSleeper.Size = new System.Drawing.Size(80, 17);
            this.chkSleeper.TabIndex = 15;
            this.chkSleeper.Text = "Sleeper Car";
            this.chkSleeper.UseVisualStyleBackColor = true;
            // 
            // chkFirstClass
            // 
            this.chkFirstClass.AutoSize = true;
            this.chkFirstClass.Location = new System.Drawing.Point(202, 249);
            this.chkFirstClass.Name = "chkFirstClass";
            this.chkFirstClass.Size = new System.Drawing.Size(75, 17);
            this.chkFirstClass.TabIndex = 14;
            this.chkFirstClass.Text = "First Class";
            this.chkFirstClass.UseVisualStyleBackColor = true;
            // 
            // chkMeal
            // 
            this.chkMeal.AutoSize = true;
            this.chkMeal.Location = new System.Drawing.Point(94, 273);
            this.chkMeal.Name = "chkMeal";
            this.chkMeal.Size = new System.Drawing.Size(94, 17);
            this.chkMeal.TabIndex = 13;
            this.chkMeal.Text = "Meal Included";
            this.chkMeal.UseVisualStyleBackColor = true;
            // 
            // chkWifi
            // 
            this.chkWifi.AutoSize = true;
            this.chkWifi.Location = new System.Drawing.Point(94, 249);
            this.chkWifi.Name = "chkWifi";
            this.chkWifi.Size = new System.Drawing.Size(46, 17);
            this.chkWifi.TabIndex = 12;
            this.chkWifi.Text = "WiFi";
            this.chkWifi.UseVisualStyleBackColor = true;
            // 
            // lblFeatures
            // 
            this.lblFeatures.AutoSize = true;
            this.lblFeatures.Location = new System.Drawing.Point(15, 249);
            this.lblFeatures.Name = "lblFeatures";
            this.lblFeatures.Size = new System.Drawing.Size(51, 13);
            this.lblFeatures.TabIndex = 11;
            this.lblFeatures.Text = "Features:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(94, 211);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(279, 20);
            this.txtPrice.TabIndex = 10;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(15, 214);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = "Price:";
            // 
            // dtpArrival
            // 
            this.dtpArrival.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpArrival.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArrival.Location = new System.Drawing.Point(94, 175);
            this.dtpArrival.Name = "dtpArrival";
            this.dtpArrival.Size = new System.Drawing.Size(279, 20);
            this.dtpArrival.TabIndex = 8;
            // 
            // lblArrival
            // 
            this.lblArrival.AutoSize = true;
            this.lblArrival.Location = new System.Drawing.Point(15, 178);
            this.lblArrival.Name = "lblArrival";
            this.lblArrival.Size = new System.Drawing.Size(68, 13);
            this.lblArrival.TabIndex = 7;
            this.lblArrival.Text = "Arrival Date:";
            // 
            // dtpDeparture
            // 
            this.dtpDeparture.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeparture.Location = new System.Drawing.Point(94, 139);
            this.dtpDeparture.Name = "dtpDeparture";
            this.dtpDeparture.Size = new System.Drawing.Size(279, 20);
            this.dtpDeparture.TabIndex = 6;
            // 
            // lblDeparture
            // 
            this.lblDeparture.AutoSize = true;
            this.lblDeparture.Location = new System.Drawing.Point(15, 142);
            this.lblDeparture.Name = "lblDeparture";
            this.lblDeparture.Size = new System.Drawing.Size(74, 13);
            this.lblDeparture.TabIndex = 5;
            this.lblDeparture.Text = "Departure Date:";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(94, 103);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(279, 20);
            this.txtDestination.TabIndex = 4;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(15, 106);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(63, 13);
            this.lblDestination.TabIndex = 3;
            this.lblDestination.Text = "Destination:";
            // 
            // txtDeparture
            // 
            this.txtDeparture.Location = new System.Drawing.Point(94, 67);
            this.txtDeparture.Name = "txtDeparture";
            this.txtDeparture.Size = new System.Drawing.Size(279, 20);
            this.txtDeparture.TabIndex = 2;
            // 
            // lblDepartureStation
            // 
            this.lblDepartureStation.AutoSize = true;
            this.lblDepartureStation.Location = new System.Drawing.Point(15, 70);
            this.lblDepartureStation.Name = "lblDepartureStation";
            this.lblDepartureStation.Size = new System.Drawing.Size(60, 13);
            this.lblDepartureStation.TabIndex = 1;
            this.lblDepartureStation.Text = "Departure:";
            // 
            // btnCreateTicket
            // 
            this.btnCreateTicket.Location = new System.Drawing.Point(18, 352);
            this.btnCreateTicket.Name = "btnCreateTicket";
            this.btnCreateTicket.Size = new System.Drawing.Size(355, 37);
            this.btnCreateTicket.TabIndex = 0;
            this.btnCreateTicket.Text = "Create Ticket";
            this.btnCreateTicket.UseVisualStyleBackColor = true;
            this.btnCreateTicket.Click += new System.EventHandler(this.btnCreateTicket_Click);
            // 
            // grpAvailableTickets
            // 
            this.grpAvailableTickets.Controls.Add(this.lblTrainSelect);
            this.grpAvailableTickets.Controls.Add(this.cboTrainSelector);
            this.grpAvailableTickets.Controls.Add(this.lblClientSelect);
            this.grpAvailableTickets.Controls.Add(this.cboClientSelector);
            this.grpAvailableTickets.Controls.Add(this.btnBuyTicket);
            this.grpAvailableTickets.Controls.Add(this.lstAvailableTickets);
            this.grpAvailableTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAvailableTickets.Location = new System.Drawing.Point(0, 0);
            this.grpAvailableTickets.Name = "grpAvailableTickets";
            this.grpAvailableTickets.Size = new System.Drawing.Size(388, 418);
            this.grpAvailableTickets.TabIndex = 0;
            this.grpAvailableTickets.TabStop = false;
            this.grpAvailableTickets.Text = "Available Tickets";
            // 
            // lblTrainSelect
            // 
            this.lblTrainSelect.AutoSize = true;
            this.lblTrainSelect.Location = new System.Drawing.Point(15, 309);
            this.lblTrainSelect.Name = "lblTrainSelect";
            this.lblTrainSelect.Size = new System.Drawing.Size(70, 13);
            this.lblTrainSelect.TabIndex = 5;
            this.lblTrainSelect.Text = "Select Train:";
            // 
            // cboTrainSelector
            // 
            this.cboTrainSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainSelector.FormattingEnabled = true;
            this.cboTrainSelector.Location = new System.Drawing.Point(97, 306);
            this.cboTrainSelector.Name = "cboTrainSelector";
            this.cboTrainSelector.Size = new System.Drawing.Size(273, 21);
            this.cboTrainSelector.TabIndex = 4;
            // 
            // lblClientSelect
            // 
            this.lblClientSelect.AutoSize = true;
            this.lblClientSelect.Location = new System.Drawing.Point(15, 339);
            this.lblClientSelect.Name = "lblClientSelect";
            this.lblClientSelect.Size = new System.Drawing.Size(76, 13);
            this.lblClientSelect.TabIndex = 3;
            this.lblClientSelect.Text = "Select Client:";
            // 
            // cboClientSelector
            // 
            this.cboClientSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientSelector.FormattingEnabled = true;
            this.cboClientSelector.Location = new System.Drawing.Point(97, 336);
            this.cboClientSelector.Name = "cboClientSelector";
            this.cboClientSelector.Size = new System.Drawing.Size(273, 21);
            this.cboClientSelector.TabIndex = 2;
            // 
            // btnBuyTicket
            // 
            this.btnBuyTicket.Location = new System.Drawing.Point(15, 363);
            this.btnBuyTicket.Name = "btnBuyTicket";
            this.btnBuyTicket.Size = new System.Drawing.Size(355, 37);
            this.btnBuyTicket.TabIndex = 1;
            this.btnBuyTicket.Text = "Buy Selected Ticket";
            this.btnBuyTicket.UseVisualStyleBackColor = true;
            this.btnBuyTicket.Click += new System.EventHandler(this.btnBuyTicket_Click);
            // 
            // lstAvailableTickets
            // 
            this.lstAvailableTickets.FormattingEnabled = true;
            this.lstAvailableTickets.Location = new System.Drawing.Point(15, 30);
            this.lstAvailableTickets.Name = "lstAvailableTickets";
            this.lstAvailableTickets.Size = new System.Drawing.Size(355, 264);
            this.lstAvailableTickets.TabIndex = 0;
            // 
            // tabPurchasedTickets
            // 
            this.tabPurchasedTickets.Controls.Add(this.grpPurchasedTickets);
            this.tabPurchasedTickets.Location = new System.Drawing.Point(4, 22);
            this.tabPurchasedTickets.Name = "tabPurchasedTickets";
            this.tabPurchasedTickets.Size = new System.Drawing.Size(792, 424);
            this.tabPurchasedTickets.TabIndex = 2;
            this.tabPurchasedTickets.Text = "Purchased Tickets";
            this.tabPurchasedTickets.UseVisualStyleBackColor = true;
            // 
            // grpPurchasedTickets
            // 
            this.grpPurchasedTickets.Controls.Add(this.lstPurchasedTickets);
            this.grpPurchasedTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPurchasedTickets.Location = new System.Drawing.Point(0, 0);
            this.grpPurchasedTickets.Name = "grpPurchasedTickets";
            this.grpPurchasedTickets.Size = new System.Drawing.Size(792, 424);
            this.grpPurchasedTickets.TabIndex = 0;
            this.grpPurchasedTickets.TabStop = false;
            this.grpPurchasedTickets.Text = "All Purchased Tickets";
            // 
            // lstPurchasedTickets
            // 
            this.lstPurchasedTickets.FormattingEnabled = true;
            this.lstPurchasedTickets.Location = new System.Drawing.Point(18, 30);
            this.lstPurchasedTickets.Name = "lstPurchasedTickets";
            this.lstPurchasedTickets.Size = new System.Drawing.Size(756, 368);
            this.lstPurchasedTickets.TabIndex = 0;
            // 
            // tabTrains
            // 
            this.tabTrains.Controls.Add(this.grpAddTrain);
            this.tabTrains.Controls.Add(this.grpTrainList);
            this.tabTrains.Location = new System.Drawing.Point(4, 22);
            this.tabTrains.Name = "tabTrains";
            this.tabTrains.Size = new System.Drawing.Size(792, 424);
            this.tabTrains.TabIndex = 3;
            this.tabTrains.Text = "Trains";
            this.tabTrains.UseVisualStyleBackColor = true;
            // 
            // grpAddTrain
            // 
            this.grpAddTrain.Controls.Add(this.btnAddTrain);
            this.grpAddTrain.Controls.Add(this.lblFuelType);
            this.grpAddTrain.Controls.Add(this.rbGasoline);
            this.grpAddTrain.Controls.Add(this.rbDiesel);
            this.grpAddTrain.Controls.Add(this.txtWagons);
            this.grpAddTrain.Controls.Add(this.lblWagons);
            this.grpAddTrain.Controls.Add(this.txtSeats);
            this.grpAddTrain.Controls.Add(this.lblSeats);
            this.grpAddTrain.Controls.Add(this.txtTrainName);
            this.grpAddTrain.Controls.Add(this.lblTrainName);
            this.grpAddTrain.Location = new System.Drawing.Point(8, 6);
            this.grpAddTrain.Name = "grpAddTrain";
            this.grpAddTrain.Size = new System.Drawing.Size(315, 410);
            this.grpAddTrain.TabIndex = 0;
            this.grpAddTrain.TabStop = false;
            this.grpAddTrain.Text = "Add New Train";
            // 
            // lblTrainName
            // 
            this.lblTrainName.AutoSize = true;
            this.lblTrainName.Location = new System.Drawing.Point(18, 26);
            this.lblTrainName.Name = "lblTrainName";
            this.lblTrainName.Size = new System.Drawing.Size(38, 13);
            this.lblTrainName.TabIndex = 0;
            this.lblTrainName.Text = "Name:";
            // 
            // txtTrainName
            // 
            this.txtTrainName.Location = new System.Drawing.Point(21, 43);
            this.txtTrainName.Name = "txtTrainName";
            this.txtTrainName.Size = new System.Drawing.Size(266, 20);
            this.txtTrainName.TabIndex = 1;
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.Location = new System.Drawing.Point(18, 75);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(92, 13);
            this.lblSeats.TabIndex = 2;
            this.lblSeats.Text = "Number of Seats:";
            // 
            // txtSeats
            // 
            this.txtSeats.Location = new System.Drawing.Point(21, 92);
            this.txtSeats.Name = "txtSeats";
            this.txtSeats.Size = new System.Drawing.Size(266, 20);
            this.txtSeats.TabIndex = 3;
            // 
            // lblWagons
            // 
            this.lblWagons.AutoSize = true;
            this.lblWagons.Location = new System.Drawing.Point(18, 127);
            this.lblWagons.Name = "lblWagons";
            this.lblWagons.Size = new System.Drawing.Size(104, 13);
            this.lblWagons.TabIndex = 4;
            this.lblWagons.Text = "Number of Wagons:";
            // 
            // txtWagons
            // 
            this.txtWagons.Location = new System.Drawing.Point(21, 144);
            this.txtWagons.Name = "txtWagons";
            this.txtWagons.Size = new System.Drawing.Size(266, 20);
            this.txtWagons.TabIndex = 5;
            // 
            // lblFuelType
            // 
            this.lblFuelType.AutoSize = true;
            this.lblFuelType.Location = new System.Drawing.Point(18, 184);
            this.lblFuelType.Name = "lblFuelType";
            this.lblFuelType.Size = new System.Drawing.Size(60, 13);
            this.lblFuelType.TabIndex = 6;
            this.lblFuelType.Text = "Fuel Type:";
            // 
            // rbDiesel
            // 
            this.rbDiesel.AutoSize = true;
            this.rbDiesel.Checked = true;
            this.rbDiesel.Location = new System.Drawing.Point(21, 204);
            this.rbDiesel.Name = "rbDiesel";
            this.rbDiesel.Size = new System.Drawing.Size(54, 17);
            this.rbDiesel.TabIndex = 7;
            this.rbDiesel.TabStop = true;
            this.rbDiesel.Text = "Diesel";
            this.rbDiesel.UseVisualStyleBackColor = true;
            // 
            // rbGasoline
            // 
            this.rbGasoline.AutoSize = true;
            this.rbGasoline.Location = new System.Drawing.Point(21, 227);
            this.rbGasoline.Name = "rbGasoline";
            this.rbGasoline.Size = new System.Drawing.Size(67, 17);
            this.rbGasoline.TabIndex = 8;
            this.rbGasoline.Text = "Gasoline";
            this.rbGasoline.UseVisualStyleBackColor = true;
            // 
            // btnAddTrain
            // 
            this.btnAddTrain.Location = new System.Drawing.Point(21, 354);
            this.btnAddTrain.Name = "btnAddTrain";
            this.btnAddTrain.Size = new System.Drawing.Size(266, 37);
            this.btnAddTrain.TabIndex = 9;
            this.btnAddTrain.Text = "Add Train";
            this.btnAddTrain.UseVisualStyleBackColor = true;
            this.btnAddTrain.Click += new System.EventHandler(this.btnAddTrain_Click);
            // 
            // grpTrainList
            // 
            this.grpTrainList.Controls.Add(this.lstTrains);
            this.grpTrainList.Location = new System.Drawing.Point(329, 6);
            this.grpTrainList.Name = "grpTrainList";
            this.grpTrainList.Size = new System.Drawing.Size(455, 410);
            this.grpTrainList.TabIndex = 1;
            this.grpTrainList.TabStop = false;
            this.grpTrainList.Text = "Train List";
            // 
            // lstTrains
            // 
            this.lstTrains.FormattingEnabled = true;
            this.lstTrains.Location = new System.Drawing.Point(6, 19);
            this.lstTrains.Name = "lstTrains";
            this.lstTrains.Size = new System.Drawing.Size(443, 368);
            this.lstTrains.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Railway Management System";
            this.tabControl.ResumeLayout(false);
            this.tabClients.ResumeLayout(false);
            this.grpRegisterClient.ResumeLayout(false);
            this.grpRegisterClient.PerformLayout();
            this.grpClientList.ResumeLayout(false);
            this.grpClientList.PerformLayout();
            this.tabTickets.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpCreateTicket.ResumeLayout(false);
            this.grpCreateTicket.PerformLayout();
            this.grpAvailableTickets.ResumeLayout(false);
            this.grpAvailableTickets.PerformLayout();
            this.tabPurchasedTickets.ResumeLayout(false);
            this.grpPurchasedTickets.ResumeLayout(false);
            this.tabTrains.ResumeLayout(false);
            this.grpAddTrain.ResumeLayout(false);
            this.grpAddTrain.PerformLayout();
            this.grpTrainList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.TabPage tabTickets;
        private System.Windows.Forms.TabPage tabPurchasedTickets;
        private System.Windows.Forms.TabPage tabTrains;
        private System.Windows.Forms.GroupBox grpRegisterClient;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox grpClientList;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.RadioButton rbRetired;
        private System.Windows.Forms.RadioButton rbChildren;
        private System.Windows.Forms.RadioButton rbStudent;
        private System.Windows.Forms.RadioButton rbAdult;
        private System.Windows.Forms.Button btnRegisterClient;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpCreateTicket;
        private System.Windows.Forms.GroupBox grpAvailableTickets;
        private System.Windows.Forms.TextBox txtDeparture;
        private System.Windows.Forms.Label lblDepartureStation;
        private System.Windows.Forms.Button btnCreateTicket;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.DateTimePicker dtpArrival;
        private System.Windows.Forms.Label lblArrival;
        private System.Windows.Forms.DateTimePicker dtpDeparture;
        private System.Windows.Forms.Label lblDeparture;
        private System.Windows.Forms.CheckBox chkSleeper;
        private System.Windows.Forms.CheckBox chkFirstClass;
        private System.Windows.Forms.CheckBox chkMeal;
        private System.Windows.Forms.CheckBox chkWifi;
        private System.Windows.Forms.Label lblFeatures;
        private System.Windows.Forms.Button btnBuyTicket;
        private System.Windows.Forms.ListBox lstAvailableTickets;
        private System.Windows.Forms.GroupBox grpPurchasedTickets;
        private System.Windows.Forms.ListBox lstPurchasedTickets;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblSelectedClient;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.GroupBox grpAddTrain;
        private System.Windows.Forms.Button btnAddTrain;
        private System.Windows.Forms.TextBox txtTrainName;
        private System.Windows.Forms.Label lblTrainName;
        private System.Windows.Forms.TextBox txtSeats;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.TextBox txtWagons;
        private System.Windows.Forms.Label lblWagons;
        private System.Windows.Forms.RadioButton rbDiesel;
        private System.Windows.Forms.RadioButton rbGasoline;
        private System.Windows.Forms.Label lblFuelType;
        private System.Windows.Forms.GroupBox grpTrainList;
        private System.Windows.Forms.ListBox lstTrains;
        private System.Windows.Forms.ComboBox cboClientSelector;
        private System.Windows.Forms.Label lblClientSelect;
        private System.Windows.Forms.ComboBox cboTrainSelector;
        private System.Windows.Forms.Label lblTrainSelect;
    }
}