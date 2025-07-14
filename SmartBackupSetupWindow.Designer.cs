namespace ZomboidBackupManager
{
    partial class SmartBackupSetupWindow
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartBackupSetupWindow));
            MainPanel = new Panel();
            OptionCategorySubPanel = new Panel();
            TopPanel = new Panel();
            TopLeftPanel = new Panel();
            ControlAreaSubPanel = new Panel();
            DisplayDatabaseDataInfoRadioButton = new RadioButton();
            DisplayDatabaseRadioButton = new RadioButton();
            ToggleSmartBackupPanel = new Panel();
            EnableSmartBackupRadioButton = new RadioButton();
            DisableSmartBackupRadioButton = new RadioButton();
            TopRightMainPanel = new Panel();
            DatabaseListBoxPanel = new Panel();
            DatabaseListboxLabel = new Label();
            DatabaseListBox = new ListBox();
            TopRightSubPanel = new Panel();
            SavegameSelectionToolstrip = new ToolStrip();
            SetupButton = new ToolStripButton();
            TSProgressbar = new ToolStripProgressBar();
            CreateButton = new ToolStripButton();
            DeletePresetButton = new ToolStripButton();
            SavegameComboBox = new ComboBox();
            SavegameLabel = new Label();
            GamemodeComboBox = new ComboBox();
            GamemodeLabel = new Label();
            DatabaseSetupPanel = new Panel();
            DatabaseInfoGridView = new DataGridView();
            DatabaseDisplayGridView = new DataGridView();
            BottomPanel = new Panel();
            BottomSubPanel = new Panel();
            BottomOptionToolStripBar = new ToolStrip();
            MaxDataGridRowsComboBox = new ToolStripComboBox();
            TS_SmartBackupSettingsButton = new ToolStripDropDownButton();
            SmartBackupSettingsMenuStrip = new ContextMenuStrip(components);
            AutoLoadDatabaseMenuOption = new ToolStripMenuItem();
            BottomTS_SeparatorB = new ToolStripSeparator();
            PreviousPageButton = new ToolStripButton();
            GridViewPageTextBox = new ToolStripTextBox();
            BottomTS_SeparatorA = new ToolStripSeparator();
            NextPageButton = new ToolStripButton();
            CancelSetupButton = new Button();
            DoneButton = new Button();
            MainPanel.SuspendLayout();
            OptionCategorySubPanel.SuspendLayout();
            TopPanel.SuspendLayout();
            TopLeftPanel.SuspendLayout();
            ControlAreaSubPanel.SuspendLayout();
            ToggleSmartBackupPanel.SuspendLayout();
            TopRightMainPanel.SuspendLayout();
            DatabaseListBoxPanel.SuspendLayout();
            TopRightSubPanel.SuspendLayout();
            SavegameSelectionToolstrip.SuspendLayout();
            DatabaseSetupPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DatabaseInfoGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DatabaseDisplayGridView).BeginInit();
            BottomPanel.SuspendLayout();
            BottomSubPanel.SuspendLayout();
            BottomOptionToolStripBar.SuspendLayout();
            SmartBackupSettingsMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = SystemColors.ControlDarkDark;
            MainPanel.BorderStyle = BorderStyle.Fixed3D;
            MainPanel.Controls.Add(OptionCategorySubPanel);
            MainPanel.Controls.Add(BottomPanel);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(2, 2);
            MainPanel.Name = "MainPanel";
            MainPanel.Padding = new Padding(5);
            MainPanel.Size = new Size(730, 557);
            MainPanel.TabIndex = 0;
            // 
            // OptionCategorySubPanel
            // 
            OptionCategorySubPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            OptionCategorySubPanel.BackColor = Color.DimGray;
            OptionCategorySubPanel.BorderStyle = BorderStyle.Fixed3D;
            OptionCategorySubPanel.Controls.Add(TopPanel);
            OptionCategorySubPanel.Controls.Add(DatabaseSetupPanel);
            OptionCategorySubPanel.Dock = DockStyle.Top;
            OptionCategorySubPanel.Location = new Point(5, 5);
            OptionCategorySubPanel.MaximumSize = new Size(716, 490);
            OptionCategorySubPanel.MinimumSize = new Size(716, 490);
            OptionCategorySubPanel.Name = "OptionCategorySubPanel";
            OptionCategorySubPanel.Padding = new Padding(5);
            OptionCategorySubPanel.Size = new Size(716, 490);
            OptionCategorySubPanel.TabIndex = 4;
            // 
            // TopPanel
            // 
            TopPanel.AutoSize = true;
            TopPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopPanel.Controls.Add(TopLeftPanel);
            TopPanel.Controls.Add(TopRightMainPanel);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(5, 5);
            TopPanel.MaximumSize = new Size(702, 134);
            TopPanel.MinimumSize = new Size(702, 134);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(702, 134);
            TopPanel.TabIndex = 4;
            // 
            // TopLeftPanel
            // 
            TopLeftPanel.Controls.Add(ControlAreaSubPanel);
            TopLeftPanel.Controls.Add(ToggleSmartBackupPanel);
            TopLeftPanel.Dock = DockStyle.Left;
            TopLeftPanel.Location = new Point(0, 0);
            TopLeftPanel.Name = "TopLeftPanel";
            TopLeftPanel.Size = new Size(200, 134);
            TopLeftPanel.TabIndex = 2;
            // 
            // ControlAreaSubPanel
            // 
            ControlAreaSubPanel.AutoSize = true;
            ControlAreaSubPanel.BackColor = SystemColors.ControlDark;
            ControlAreaSubPanel.BorderStyle = BorderStyle.Fixed3D;
            ControlAreaSubPanel.Controls.Add(DisplayDatabaseDataInfoRadioButton);
            ControlAreaSubPanel.Controls.Add(DisplayDatabaseRadioButton);
            ControlAreaSubPanel.Dock = DockStyle.Top;
            ControlAreaSubPanel.Location = new Point(0, 55);
            ControlAreaSubPanel.Margin = new Padding(15);
            ControlAreaSubPanel.MaximumSize = new Size(200, 75);
            ControlAreaSubPanel.MinimumSize = new Size(200, 75);
            ControlAreaSubPanel.Name = "ControlAreaSubPanel";
            ControlAreaSubPanel.Padding = new Padding(7, 5, 7, 5);
            ControlAreaSubPanel.Size = new Size(200, 75);
            ControlAreaSubPanel.TabIndex = 2;
            // 
            // DisplayDatabaseDataInfoRadioButton
            // 
            DisplayDatabaseDataInfoRadioButton.AutoCheck = false;
            DisplayDatabaseDataInfoRadioButton.AutoSize = true;
            DisplayDatabaseDataInfoRadioButton.BackColor = Color.Brown;
            DisplayDatabaseDataInfoRadioButton.Checked = true;
            DisplayDatabaseDataInfoRadioButton.Dock = DockStyle.Bottom;
            DisplayDatabaseDataInfoRadioButton.FlatAppearance.CheckedBackColor = Color.Black;
            DisplayDatabaseDataInfoRadioButton.Font = new Font("Bahnschrift", 10F, FontStyle.Bold);
            DisplayDatabaseDataInfoRadioButton.ForeColor = Color.White;
            DisplayDatabaseDataInfoRadioButton.Location = new Point(7, 6);
            DisplayDatabaseDataInfoRadioButton.MaximumSize = new Size(182, 30);
            DisplayDatabaseDataInfoRadioButton.MinimumSize = new Size(182, 30);
            DisplayDatabaseDataInfoRadioButton.Name = "DisplayDatabaseDataInfoRadioButton";
            DisplayDatabaseDataInfoRadioButton.Padding = new Padding(15, 2, 15, 2);
            DisplayDatabaseDataInfoRadioButton.Size = new Size(182, 30);
            DisplayDatabaseDataInfoRadioButton.TabIndex = 1;
            DisplayDatabaseDataInfoRadioButton.TabStop = true;
            DisplayDatabaseDataInfoRadioButton.Text = "Display Preset Info";
            DisplayDatabaseDataInfoRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            DisplayDatabaseDataInfoRadioButton.UseVisualStyleBackColor = true;
            DisplayDatabaseDataInfoRadioButton.Click += DisplayDatabaseDataInfoRadioButton_Click;
            // 
            // DisplayDatabaseRadioButton
            // 
            DisplayDatabaseRadioButton.AutoCheck = false;
            DisplayDatabaseRadioButton.AutoSize = true;
            DisplayDatabaseRadioButton.BackColor = Color.Maroon;
            DisplayDatabaseRadioButton.Dock = DockStyle.Bottom;
            DisplayDatabaseRadioButton.Font = new Font("Bahnschrift", 10F, FontStyle.Bold);
            DisplayDatabaseRadioButton.ForeColor = Color.White;
            DisplayDatabaseRadioButton.Location = new Point(7, 36);
            DisplayDatabaseRadioButton.MaximumSize = new Size(182, 30);
            DisplayDatabaseRadioButton.MinimumSize = new Size(182, 30);
            DisplayDatabaseRadioButton.Name = "DisplayDatabaseRadioButton";
            DisplayDatabaseRadioButton.Padding = new Padding(15, 2, 15, 2);
            DisplayDatabaseRadioButton.Size = new Size(182, 30);
            DisplayDatabaseRadioButton.TabIndex = 0;
            DisplayDatabaseRadioButton.Text = "Display Database";
            DisplayDatabaseRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            DisplayDatabaseRadioButton.UseVisualStyleBackColor = true;
            DisplayDatabaseRadioButton.Click += DisplayDatabaseRadioButton_Click;
            // 
            // ToggleSmartBackupPanel
            // 
            ToggleSmartBackupPanel.AutoSize = true;
            ToggleSmartBackupPanel.BackColor = SystemColors.ControlDark;
            ToggleSmartBackupPanel.BorderStyle = BorderStyle.Fixed3D;
            ToggleSmartBackupPanel.Controls.Add(EnableSmartBackupRadioButton);
            ToggleSmartBackupPanel.Controls.Add(DisableSmartBackupRadioButton);
            ToggleSmartBackupPanel.Dock = DockStyle.Top;
            ToggleSmartBackupPanel.Location = new Point(0, 0);
            ToggleSmartBackupPanel.MaximumSize = new Size(200, 55);
            ToggleSmartBackupPanel.MinimumSize = new Size(200, 55);
            ToggleSmartBackupPanel.Name = "ToggleSmartBackupPanel";
            ToggleSmartBackupPanel.Padding = new Padding(5);
            ToggleSmartBackupPanel.Size = new Size(200, 55);
            ToggleSmartBackupPanel.TabIndex = 0;
            // 
            // EnableSmartBackupRadioButton
            // 
            EnableSmartBackupRadioButton.AutoCheck = false;
            EnableSmartBackupRadioButton.AutoSize = true;
            EnableSmartBackupRadioButton.BackColor = SystemColors.ControlLight;
            EnableSmartBackupRadioButton.BackgroundImage = Properties.Resources.RadioSwitchBackgroundTexture_Green;
            EnableSmartBackupRadioButton.BackgroundImageLayout = ImageLayout.Stretch;
            EnableSmartBackupRadioButton.CheckAlign = ContentAlignment.MiddleCenter;
            EnableSmartBackupRadioButton.Dock = DockStyle.Top;
            EnableSmartBackupRadioButton.Font = new Font("Bahnschrift", 10F, FontStyle.Bold);
            EnableSmartBackupRadioButton.Location = new Point(5, 26);
            EnableSmartBackupRadioButton.Margin = new Padding(10);
            EnableSmartBackupRadioButton.Name = "EnableSmartBackupRadioButton";
            EnableSmartBackupRadioButton.Padding = new Padding(15, 0, 15, 0);
            EnableSmartBackupRadioButton.Size = new Size(186, 21);
            EnableSmartBackupRadioButton.TabIndex = 0;
            EnableSmartBackupRadioButton.Text = "ON";
            EnableSmartBackupRadioButton.UseVisualStyleBackColor = false;
            EnableSmartBackupRadioButton.MouseClick += EnableSmartBackupRadioButton_MouseClick;
            // 
            // DisableSmartBackupRadioButton
            // 
            DisableSmartBackupRadioButton.AutoCheck = false;
            DisableSmartBackupRadioButton.AutoSize = true;
            DisableSmartBackupRadioButton.BackColor = SystemColors.ControlLight;
            DisableSmartBackupRadioButton.BackgroundImage = Properties.Resources.RadioSwitchBackgroundTexture_Yellow;
            DisableSmartBackupRadioButton.BackgroundImageLayout = ImageLayout.Stretch;
            DisableSmartBackupRadioButton.CheckAlign = ContentAlignment.MiddleCenter;
            DisableSmartBackupRadioButton.Checked = true;
            DisableSmartBackupRadioButton.Dock = DockStyle.Top;
            DisableSmartBackupRadioButton.Font = new Font("Bahnschrift", 10F, FontStyle.Bold);
            DisableSmartBackupRadioButton.Location = new Point(5, 5);
            DisableSmartBackupRadioButton.Margin = new Padding(10);
            DisableSmartBackupRadioButton.Name = "DisableSmartBackupRadioButton";
            DisableSmartBackupRadioButton.Padding = new Padding(15, 0, 15, 0);
            DisableSmartBackupRadioButton.Size = new Size(186, 21);
            DisableSmartBackupRadioButton.TabIndex = 1;
            DisableSmartBackupRadioButton.TabStop = true;
            DisableSmartBackupRadioButton.Text = "OFF";
            DisableSmartBackupRadioButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            DisableSmartBackupRadioButton.UseVisualStyleBackColor = false;
            DisableSmartBackupRadioButton.MouseClick += DisableSmartBackupRadioButton_MouseClick;
            // 
            // TopRightMainPanel
            // 
            TopRightMainPanel.AutoSize = true;
            TopRightMainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopRightMainPanel.BackColor = SystemColors.ControlLightLight;
            TopRightMainPanel.BorderStyle = BorderStyle.Fixed3D;
            TopRightMainPanel.Controls.Add(DatabaseListBoxPanel);
            TopRightMainPanel.Controls.Add(TopRightSubPanel);
            TopRightMainPanel.Dock = DockStyle.Right;
            TopRightMainPanel.Location = new Point(206, 0);
            TopRightMainPanel.MaximumSize = new Size(496, 131);
            TopRightMainPanel.MinimumSize = new Size(496, 131);
            TopRightMainPanel.Name = "TopRightMainPanel";
            TopRightMainPanel.Padding = new Padding(5);
            TopRightMainPanel.Size = new Size(496, 131);
            TopRightMainPanel.TabIndex = 3;
            // 
            // DatabaseListBoxPanel
            // 
            DatabaseListBoxPanel.AutoSize = true;
            DatabaseListBoxPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DatabaseListBoxPanel.BorderStyle = BorderStyle.Fixed3D;
            DatabaseListBoxPanel.Controls.Add(DatabaseListboxLabel);
            DatabaseListBoxPanel.Controls.Add(DatabaseListBox);
            DatabaseListBoxPanel.Dock = DockStyle.Left;
            DatabaseListBoxPanel.Location = new Point(5, 5);
            DatabaseListBoxPanel.Margin = new Padding(0);
            DatabaseListBoxPanel.MaximumSize = new Size(202, 117);
            DatabaseListBoxPanel.MinimumSize = new Size(202, 117);
            DatabaseListBoxPanel.Name = "DatabaseListBoxPanel";
            DatabaseListBoxPanel.Padding = new Padding(2);
            DatabaseListBoxPanel.Size = new Size(202, 117);
            DatabaseListBoxPanel.TabIndex = 3;
            // 
            // DatabaseListboxLabel
            // 
            DatabaseListboxLabel.AutoSize = true;
            DatabaseListboxLabel.BackColor = SystemColors.ControlLight;
            DatabaseListboxLabel.Dock = DockStyle.Top;
            DatabaseListboxLabel.Font = new Font("Bahnschrift", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DatabaseListboxLabel.Location = new Point(2, 2);
            DatabaseListboxLabel.MaximumSize = new Size(198, 20);
            DatabaseListboxLabel.MinimumSize = new Size(198, 20);
            DatabaseListboxLabel.Name = "DatabaseListboxLabel";
            DatabaseListboxLabel.Size = new Size(198, 20);
            DatabaseListboxLabel.TabIndex = 3;
            DatabaseListboxLabel.Text = "Presets:";
            DatabaseListboxLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DatabaseListBox
            // 
            DatabaseListBox.BorderStyle = BorderStyle.FixedSingle;
            DatabaseListBox.Dock = DockStyle.Bottom;
            DatabaseListBox.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DatabaseListBox.FormattingEnabled = true;
            DatabaseListBox.Items.AddRange(new object[] { " " });
            DatabaseListBox.Location = new Point(2, 25);
            DatabaseListBox.Margin = new Padding(0);
            DatabaseListBox.MaximumSize = new Size(198, 95);
            DatabaseListBox.MinimumSize = new Size(198, 95);
            DatabaseListBox.Name = "DatabaseListBox";
            DatabaseListBox.Size = new Size(198, 86);
            DatabaseListBox.TabIndex = 2;
            DatabaseListBox.SelectedIndexChanged += DatabaseListBox_SelectedIndexChanged;
            // 
            // TopRightSubPanel
            // 
            TopRightSubPanel.AutoSize = true;
            TopRightSubPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopRightSubPanel.BackColor = Color.Brown;
            TopRightSubPanel.BorderStyle = BorderStyle.Fixed3D;
            TopRightSubPanel.Controls.Add(SavegameSelectionToolstrip);
            TopRightSubPanel.Controls.Add(SavegameComboBox);
            TopRightSubPanel.Controls.Add(SavegameLabel);
            TopRightSubPanel.Controls.Add(GamemodeComboBox);
            TopRightSubPanel.Controls.Add(GamemodeLabel);
            TopRightSubPanel.Dock = DockStyle.Right;
            TopRightSubPanel.Location = new Point(212, 5);
            TopRightSubPanel.MaximumSize = new Size(275, 117);
            TopRightSubPanel.MinimumSize = new Size(275, 117);
            TopRightSubPanel.Name = "TopRightSubPanel";
            TopRightSubPanel.Padding = new Padding(5);
            TopRightSubPanel.Size = new Size(275, 117);
            TopRightSubPanel.TabIndex = 1;
            // 
            // SavegameSelectionToolstrip
            // 
            SavegameSelectionToolstrip.BackColor = Color.Maroon;
            SavegameSelectionToolstrip.CanOverflow = false;
            SavegameSelectionToolstrip.Dock = DockStyle.Bottom;
            SavegameSelectionToolstrip.Font = new Font("Bahnschrift", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SavegameSelectionToolstrip.GripStyle = ToolStripGripStyle.Hidden;
            SavegameSelectionToolstrip.Items.AddRange(new ToolStripItem[] { SetupButton, TSProgressbar, CreateButton, DeletePresetButton });
            SavegameSelectionToolstrip.Location = new Point(5, 82);
            SavegameSelectionToolstrip.MaximumSize = new Size(261, 26);
            SavegameSelectionToolstrip.MinimumSize = new Size(261, 26);
            SavegameSelectionToolstrip.Name = "SavegameSelectionToolstrip";
            SavegameSelectionToolstrip.Size = new Size(261, 26);
            SavegameSelectionToolstrip.TabIndex = 4;
            // 
            // SetupButton
            // 
            SetupButton.BackColor = Color.Transparent;
            SetupButton.BackgroundImage = Properties.Resources.ButtonBackgroundTexture90x38;
            SetupButton.BackgroundImageLayout = ImageLayout.Stretch;
            SetupButton.Font = new Font("Bahnschrift SemiCondensed", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SetupButton.Image = Properties.Resources.StarCharButton;
            SetupButton.ImageTransparentColor = Color.Magenta;
            SetupButton.MergeAction = MergeAction.MatchOnly;
            SetupButton.Name = "SetupButton";
            SetupButton.Overflow = ToolStripItemOverflow.Never;
            SetupButton.Size = new Size(51, 23);
            SetupButton.Text = "Setup";
            SetupButton.ToolTipText = "Click, to create a database of the\r\nselected preset.";
            SetupButton.Click += SetupButton_Click;
            // 
            // TSProgressbar
            // 
            TSProgressbar.AutoSize = false;
            TSProgressbar.BackColor = Color.LightCoral;
            TSProgressbar.ForeColor = Color.Red;
            TSProgressbar.Margin = new Padding(14, 2, 14, 1);
            TSProgressbar.MergeAction = MergeAction.MatchOnly;
            TSProgressbar.Name = "TSProgressbar";
            TSProgressbar.Overflow = ToolStripItemOverflow.Never;
            TSProgressbar.Size = new Size(125, 23);
            TSProgressbar.Step = 1;
            TSProgressbar.Style = ProgressBarStyle.Continuous;
            // 
            // CreateButton
            // 
            CreateButton.Alignment = ToolStripItemAlignment.Right;
            CreateButton.BackColor = Color.Transparent;
            CreateButton.BackgroundImage = Properties.Resources.ButtonBackgroundTexture90x38;
            CreateButton.BackgroundImageLayout = ImageLayout.Stretch;
            CreateButton.Font = new Font("Bahnschrift SemiCondensed", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateButton.Image = Properties.Resources.SquareWithPlusIconImage;
            CreateButton.ImageTransparentColor = Color.Magenta;
            CreateButton.MergeAction = MergeAction.Replace;
            CreateButton.MergeIndex = 0;
            CreateButton.Name = "CreateButton";
            CreateButton.RightToLeft = RightToLeft.Yes;
            CreateButton.Size = new Size(55, 23);
            CreateButton.Text = "Create";
            CreateButton.ToolTipText = "Click, to create an empty preset,\r\nfor the savegame selected above.";
            CreateButton.Click += CreateButton_Click;
            // 
            // DeletePresetButton
            // 
            DeletePresetButton.Alignment = ToolStripItemAlignment.Right;
            DeletePresetButton.BackColor = Color.Transparent;
            DeletePresetButton.BackgroundImage = Properties.Resources.ButtonBackgroundTexture90x38;
            DeletePresetButton.BackgroundImageLayout = ImageLayout.Stretch;
            DeletePresetButton.Font = new Font("Bahnschrift SemiCondensed", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeletePresetButton.Image = Properties.Resources.TrashbinIconImage;
            DeletePresetButton.ImageTransparentColor = Color.Magenta;
            DeletePresetButton.MergeAction = MergeAction.Replace;
            DeletePresetButton.MergeIndex = 1;
            DeletePresetButton.Name = "DeletePresetButton";
            DeletePresetButton.RightToLeft = RightToLeft.Yes;
            DeletePresetButton.Size = new Size(54, 23);
            DeletePresetButton.Text = "Delete";
            DeletePresetButton.ToolTipText = "Click, to create an empty preset,\r\nfor the savegame selected above.";
            DeletePresetButton.Visible = false;
            DeletePresetButton.Click += DeletePresetButton_Click;
            // 
            // SavegameComboBox
            // 
            SavegameComboBox.Dock = DockStyle.Top;
            SavegameComboBox.FormattingEnabled = true;
            SavegameComboBox.Location = new Point(5, 57);
            SavegameComboBox.Name = "SavegameComboBox";
            SavegameComboBox.Size = new Size(261, 22);
            SavegameComboBox.TabIndex = 1;
            SavegameComboBox.SelectedIndexChanged += SavegameComboBox_SelectedIndexChanged;
            // 
            // SavegameLabel
            // 
            SavegameLabel.AutoSize = true;
            SavegameLabel.BackColor = SystemColors.Control;
            SavegameLabel.BorderStyle = BorderStyle.Fixed3D;
            SavegameLabel.Dock = DockStyle.Top;
            SavegameLabel.Font = new Font("Bahnschrift", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SavegameLabel.Location = new Point(5, 42);
            SavegameLabel.MaximumSize = new Size(261, 0);
            SavegameLabel.MinimumSize = new Size(261, 0);
            SavegameLabel.Name = "SavegameLabel";
            SavegameLabel.Size = new Size(261, 15);
            SavegameLabel.TabIndex = 2;
            SavegameLabel.Text = "Savegame";
            SavegameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GamemodeComboBox
            // 
            GamemodeComboBox.BackColor = SystemColors.Window;
            GamemodeComboBox.Dock = DockStyle.Top;
            GamemodeComboBox.FormattingEnabled = true;
            GamemodeComboBox.Location = new Point(5, 20);
            GamemodeComboBox.Name = "GamemodeComboBox";
            GamemodeComboBox.Size = new Size(261, 22);
            GamemodeComboBox.TabIndex = 0;
            GamemodeComboBox.SelectedIndexChanged += GamemodeComboBox_SelectedIndexChanged;
            // 
            // GamemodeLabel
            // 
            GamemodeLabel.AutoSize = true;
            GamemodeLabel.BackColor = SystemColors.Control;
            GamemodeLabel.BorderStyle = BorderStyle.Fixed3D;
            GamemodeLabel.Dock = DockStyle.Top;
            GamemodeLabel.Font = new Font("Bahnschrift", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GamemodeLabel.Location = new Point(5, 5);
            GamemodeLabel.MaximumSize = new Size(261, 0);
            GamemodeLabel.MinimumSize = new Size(261, 0);
            GamemodeLabel.Name = "GamemodeLabel";
            GamemodeLabel.Size = new Size(261, 15);
            GamemodeLabel.TabIndex = 3;
            GamemodeLabel.Text = "Gamemode";
            GamemodeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DatabaseSetupPanel
            // 
            DatabaseSetupPanel.AutoSize = true;
            DatabaseSetupPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DatabaseSetupPanel.BackColor = SystemColors.ControlLightLight;
            DatabaseSetupPanel.BorderStyle = BorderStyle.Fixed3D;
            DatabaseSetupPanel.Controls.Add(DatabaseInfoGridView);
            DatabaseSetupPanel.Controls.Add(DatabaseDisplayGridView);
            DatabaseSetupPanel.Dock = DockStyle.Bottom;
            DatabaseSetupPanel.Location = new Point(5, 133);
            DatabaseSetupPanel.MaximumSize = new Size(702, 348);
            DatabaseSetupPanel.MinimumSize = new Size(702, 348);
            DatabaseSetupPanel.Name = "DatabaseSetupPanel";
            DatabaseSetupPanel.Padding = new Padding(5);
            DatabaseSetupPanel.Size = new Size(702, 348);
            DatabaseSetupPanel.TabIndex = 3;
            // 
            // DatabaseInfoGridView
            // 
            DatabaseInfoGridView.AllowUserToAddRows = false;
            DatabaseInfoGridView.AllowUserToDeleteRows = false;
            DatabaseInfoGridView.AllowUserToResizeRows = false;
            DatabaseInfoGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DatabaseInfoGridView.BackgroundColor = SystemColors.ControlLight;
            DatabaseInfoGridView.BorderStyle = BorderStyle.Fixed3D;
            DatabaseInfoGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            DatabaseInfoGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DatabaseInfoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DatabaseInfoGridView.DefaultCellStyle = dataGridViewCellStyle2;
            DatabaseInfoGridView.Dock = DockStyle.Fill;
            DatabaseInfoGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            DatabaseInfoGridView.GridColor = Color.Brown;
            DatabaseInfoGridView.Location = new Point(5, 5);
            DatabaseInfoGridView.MaximumSize = new Size(688, 334);
            DatabaseInfoGridView.MinimumSize = new Size(688, 334);
            DatabaseInfoGridView.MultiSelect = false;
            DatabaseInfoGridView.Name = "DatabaseInfoGridView";
            DatabaseInfoGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DatabaseInfoGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DatabaseInfoGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            DatabaseInfoGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DatabaseInfoGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DatabaseInfoGridView.RowTemplate.DefaultCellStyle.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DatabaseInfoGridView.RowTemplate.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            DatabaseInfoGridView.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            DatabaseInfoGridView.RowTemplate.ReadOnly = true;
            DatabaseInfoGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            DatabaseInfoGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DatabaseInfoGridView.ShowCellErrors = false;
            DatabaseInfoGridView.ShowEditingIcon = false;
            DatabaseInfoGridView.ShowRowErrors = false;
            DatabaseInfoGridView.Size = new Size(688, 334);
            DatabaseInfoGridView.TabIndex = 0;
            DatabaseInfoGridView.CellClick += SmartBackupDataGridView_CellClick;
            // 
            // DatabaseDisplayGridView
            // 
            DatabaseDisplayGridView.AllowUserToAddRows = false;
            DatabaseDisplayGridView.AllowUserToDeleteRows = false;
            DatabaseDisplayGridView.AllowUserToResizeRows = false;
            DatabaseDisplayGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DatabaseDisplayGridView.BackgroundColor = SystemColors.ControlLight;
            DatabaseDisplayGridView.BorderStyle = BorderStyle.Fixed3D;
            DatabaseDisplayGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            DatabaseDisplayGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            DatabaseDisplayGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            DatabaseDisplayGridView.DefaultCellStyle = dataGridViewCellStyle6;
            DatabaseDisplayGridView.Dock = DockStyle.Fill;
            DatabaseDisplayGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            DatabaseDisplayGridView.GridColor = Color.Brown;
            DatabaseDisplayGridView.Location = new Point(5, 5);
            DatabaseDisplayGridView.MaximumSize = new Size(688, 334);
            DatabaseDisplayGridView.MinimumSize = new Size(688, 334);
            DatabaseDisplayGridView.MultiSelect = false;
            DatabaseDisplayGridView.Name = "DatabaseDisplayGridView";
            DatabaseDisplayGridView.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            DatabaseDisplayGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            DatabaseDisplayGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            DatabaseDisplayGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            DatabaseDisplayGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DatabaseDisplayGridView.RowTemplate.DefaultCellStyle.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DatabaseDisplayGridView.RowTemplate.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            DatabaseDisplayGridView.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            DatabaseDisplayGridView.RowTemplate.ReadOnly = true;
            DatabaseDisplayGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            DatabaseDisplayGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DatabaseDisplayGridView.ShowCellErrors = false;
            DatabaseDisplayGridView.ShowEditingIcon = false;
            DatabaseDisplayGridView.ShowRowErrors = false;
            DatabaseDisplayGridView.Size = new Size(688, 334);
            DatabaseDisplayGridView.TabIndex = 1;
            // 
            // BottomPanel
            // 
            BottomPanel.AutoSize = true;
            BottomPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BottomPanel.BackColor = SystemColors.ControlDark;
            BottomPanel.BackgroundImageLayout = ImageLayout.Center;
            BottomPanel.BorderStyle = BorderStyle.FixedSingle;
            BottomPanel.Controls.Add(BottomSubPanel);
            BottomPanel.Controls.Add(CancelSetupButton);
            BottomPanel.Controls.Add(DoneButton);
            BottomPanel.Dock = DockStyle.Bottom;
            BottomPanel.Font = new Font("Bahnschrift", 11F);
            BottomPanel.Location = new Point(5, 499);
            BottomPanel.MaximumSize = new Size(716, 49);
            BottomPanel.MinimumSize = new Size(716, 49);
            BottomPanel.Name = "BottomPanel";
            BottomPanel.Padding = new Padding(1);
            BottomPanel.Size = new Size(716, 49);
            BottomPanel.TabIndex = 1;
            // 
            // BottomSubPanel
            // 
            BottomSubPanel.AutoSize = true;
            BottomSubPanel.BackColor = SystemColors.ButtonHighlight;
            BottomSubPanel.Controls.Add(BottomOptionToolStripBar);
            BottomSubPanel.Dock = DockStyle.Top;
            BottomSubPanel.Location = new Point(126, 1);
            BottomSubPanel.MaximumSize = new Size(462, 45);
            BottomSubPanel.MinimumSize = new Size(462, 45);
            BottomSubPanel.Name = "BottomSubPanel";
            BottomSubPanel.Padding = new Padding(3);
            BottomSubPanel.Size = new Size(462, 45);
            BottomSubPanel.TabIndex = 3;
            // 
            // BottomOptionToolStripBar
            // 
            BottomOptionToolStripBar.BackColor = Color.Transparent;
            BottomOptionToolStripBar.BackgroundImage = Properties.Resources.RedBarAlternative;
            BottomOptionToolStripBar.BackgroundImageLayout = ImageLayout.Stretch;
            BottomOptionToolStripBar.Dock = DockStyle.Bottom;
            BottomOptionToolStripBar.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BottomOptionToolStripBar.GripStyle = ToolStripGripStyle.Hidden;
            BottomOptionToolStripBar.ImageScalingSize = new Size(32, 32);
            BottomOptionToolStripBar.Items.AddRange(new ToolStripItem[] { MaxDataGridRowsComboBox, TS_SmartBackupSettingsButton, BottomTS_SeparatorB, PreviousPageButton, GridViewPageTextBox, BottomTS_SeparatorA, NextPageButton });
            BottomOptionToolStripBar.Location = new Point(3, 0);
            BottomOptionToolStripBar.MaximumSize = new Size(456, 42);
            BottomOptionToolStripBar.MinimumSize = new Size(456, 42);
            BottomOptionToolStripBar.Name = "BottomOptionToolStripBar";
            BottomOptionToolStripBar.Padding = new Padding(5, 2, 5, 2);
            BottomOptionToolStripBar.Size = new Size(456, 42);
            BottomOptionToolStripBar.TabIndex = 4;
            BottomOptionToolStripBar.Text = "Max. Rows / Page";
            // 
            // MaxDataGridRowsComboBox
            // 
            MaxDataGridRowsComboBox.AutoSize = false;
            MaxDataGridRowsComboBox.AutoToolTip = true;
            MaxDataGridRowsComboBox.BackColor = Color.MistyRose;
            MaxDataGridRowsComboBox.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MaxDataGridRowsComboBox.ForeColor = SystemColors.ControlText;
            MaxDataGridRowsComboBox.Items.AddRange(new object[] { "1", "2", "5", "10", "20", "50", "100", "150", "200", "250", "500" });
            MaxDataGridRowsComboBox.Margin = new Padding(5, 0, 1, 0);
            MaxDataGridRowsComboBox.MaxDropDownItems = 11;
            MaxDataGridRowsComboBox.MergeAction = MergeAction.MatchOnly;
            MaxDataGridRowsComboBox.Name = "MaxDataGridRowsComboBox";
            MaxDataGridRowsComboBox.Overflow = ToolStripItemOverflow.Never;
            MaxDataGridRowsComboBox.RightToLeft = RightToLeft.No;
            MaxDataGridRowsComboBox.Size = new Size(50, 26);
            MaxDataGridRowsComboBox.Text = "50";
            MaxDataGridRowsComboBox.ToolTipText = "Change the amount of rows,\r\nthat can be displayed at onec\r\n\r\n(Max = 500 - Loads very long)\r\n(Recommend = 100 )";
            MaxDataGridRowsComboBox.SelectedIndexChanged += MaxDataGridRowsComboBox_SelectedIndexChanged;
            // 
            // TS_SmartBackupSettingsButton
            // 
            TS_SmartBackupSettingsButton.BackgroundImage = Properties.Resources.ButtonBackgroundTexture90x38;
            TS_SmartBackupSettingsButton.BackgroundImageLayout = ImageLayout.Stretch;
            TS_SmartBackupSettingsButton.DropDown = SmartBackupSettingsMenuStrip;
            TS_SmartBackupSettingsButton.Font = new Font("Bahnschrift SemiCondensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TS_SmartBackupSettingsButton.Image = Properties.Resources.Gear2Color_BW;
            TS_SmartBackupSettingsButton.ImageScaling = ToolStripItemImageScaling.None;
            TS_SmartBackupSettingsButton.ImageTransparentColor = Color.Magenta;
            TS_SmartBackupSettingsButton.Margin = new Padding(5, 0, 3, 0);
            TS_SmartBackupSettingsButton.MergeAction = MergeAction.MatchOnly;
            TS_SmartBackupSettingsButton.Name = "TS_SmartBackupSettingsButton";
            TS_SmartBackupSettingsButton.Overflow = ToolStripItemOverflow.Never;
            TS_SmartBackupSettingsButton.Padding = new Padding(5, 0, 0, 0);
            TS_SmartBackupSettingsButton.RightToLeft = RightToLeft.Yes;
            TS_SmartBackupSettingsButton.ShowDropDownArrow = false;
            TS_SmartBackupSettingsButton.Size = new Size(90, 38);
            TS_SmartBackupSettingsButton.Text = "Settings";
            TS_SmartBackupSettingsButton.ToolTipText = "Some General Settings";
            // 
            // SmartBackupSettingsMenuStrip
            // 
            SmartBackupSettingsMenuStrip.AllowMerge = false;
            SmartBackupSettingsMenuStrip.BackColor = Color.Firebrick;
            SmartBackupSettingsMenuStrip.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SmartBackupSettingsMenuStrip.Items.AddRange(new ToolStripItem[] { AutoLoadDatabaseMenuOption });
            SmartBackupSettingsMenuStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            SmartBackupSettingsMenuStrip.Name = "SmartBackupSettingsMenuStrip";
            SmartBackupSettingsMenuStrip.OwnerItem = TS_SmartBackupSettingsButton;
            SmartBackupSettingsMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            SmartBackupSettingsMenuStrip.RightToLeft = RightToLeft.Yes;
            SmartBackupSettingsMenuStrip.ShowCheckMargin = true;
            SmartBackupSettingsMenuStrip.ShowImageMargin = false;
            SmartBackupSettingsMenuStrip.Size = new Size(216, 28);
            // 
            // AutoLoadDatabaseMenuOption
            // 
            AutoLoadDatabaseMenuOption.Alignment = ToolStripItemAlignment.Right;
            AutoLoadDatabaseMenuOption.AutoToolTip = true;
            AutoLoadDatabaseMenuOption.BackColor = Color.Maroon;
            AutoLoadDatabaseMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AutoLoadDatabaseMenuOption.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AutoLoadDatabaseMenuOption.ForeColor = Color.White;
            AutoLoadDatabaseMenuOption.ImageScaling = ToolStripItemImageScaling.None;
            AutoLoadDatabaseMenuOption.ImageTransparentColor = Color.Maroon;
            AutoLoadDatabaseMenuOption.MergeAction = MergeAction.MatchOnly;
            AutoLoadDatabaseMenuOption.Name = "AutoLoadDatabaseMenuOption";
            AutoLoadDatabaseMenuOption.RightToLeft = RightToLeft.Yes;
            AutoLoadDatabaseMenuOption.Size = new Size(215, 24);
            AutoLoadDatabaseMenuOption.Text = "Auto-Load On Click";
            AutoLoadDatabaseMenuOption.ToolTipText = "Automatic Loads the Database Data\r\nof a Preset, when you select it\r\nin a List or Drop down.\r\n\r\n(Also includes auto-loading in the\r\nmain window)\r\n\r\n\r\n";
            AutoLoadDatabaseMenuOption.Click += AutoLoadDatabaseMenuOption_Click;
            // 
            // BottomTS_SeparatorB
            // 
            BottomTS_SeparatorB.AutoSize = false;
            BottomTS_SeparatorB.MergeAction = MergeAction.MatchOnly;
            BottomTS_SeparatorB.Name = "BottomTS_SeparatorB";
            BottomTS_SeparatorB.Overflow = ToolStripItemOverflow.Never;
            BottomTS_SeparatorB.Size = new Size(15, 45);
            // 
            // PreviousPageButton
            // 
            PreviousPageButton.BackgroundImageLayout = ImageLayout.Center;
            PreviousPageButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            PreviousPageButton.Image = Properties.Resources.ArrowLeftIcon;
            PreviousPageButton.ImageScaling = ToolStripItemImageScaling.None;
            PreviousPageButton.ImageTransparentColor = Color.Magenta;
            PreviousPageButton.Name = "PreviousPageButton";
            PreviousPageButton.Size = new Size(36, 35);
            PreviousPageButton.Text = "Next Page";
            PreviousPageButton.Click += PreviousPageButton_Click;
            // 
            // GridViewPageTextBox
            // 
            GridViewPageTextBox.Alignment = ToolStripItemAlignment.Right;
            GridViewPageTextBox.AutoSize = false;
            GridViewPageTextBox.AutoToolTip = true;
            GridViewPageTextBox.BackColor = Color.MistyRose;
            GridViewPageTextBox.Font = new Font("Bahnschrift", 10.5F, FontStyle.Bold);
            GridViewPageTextBox.ForeColor = SystemColors.ControlText;
            GridViewPageTextBox.Margin = new Padding(1, 0, 5, 0);
            GridViewPageTextBox.MaxLength = 8;
            GridViewPageTextBox.MergeAction = MergeAction.MatchOnly;
            GridViewPageTextBox.Name = "GridViewPageTextBox";
            GridViewPageTextBox.Overflow = ToolStripItemOverflow.Never;
            GridViewPageTextBox.Size = new Size(100, 24);
            GridViewPageTextBox.Text = " 0  / 0 ";
            GridViewPageTextBox.TextBoxTextAlign = HorizontalAlignment.Center;
            GridViewPageTextBox.ToolTipText = "Current Displayed Page\r\n\r\n(Enter Target Page &\r\nPress Enter, To Jump\r\nTo Entered Page)";
            GridViewPageTextBox.Leave += GridViewPageTextBox_Leave;
            GridViewPageTextBox.KeyDown += GridViewPageTextBox_KeyDown;
            GridViewPageTextBox.MouseDown += GridViewPageTextBox_MouseDown;
            // 
            // BottomTS_SeparatorA
            // 
            BottomTS_SeparatorA.Alignment = ToolStripItemAlignment.Right;
            BottomTS_SeparatorA.AutoSize = false;
            BottomTS_SeparatorA.MergeAction = MergeAction.MatchOnly;
            BottomTS_SeparatorA.Name = "BottomTS_SeparatorA";
            BottomTS_SeparatorA.Overflow = ToolStripItemOverflow.Never;
            BottomTS_SeparatorA.RightToLeft = RightToLeft.Yes;
            BottomTS_SeparatorA.Size = new Size(15, 45);
            // 
            // NextPageButton
            // 
            NextPageButton.Alignment = ToolStripItemAlignment.Right;
            NextPageButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            NextPageButton.Image = Properties.Resources.ArrowRightIcon;
            NextPageButton.ImageScaling = ToolStripItemImageScaling.None;
            NextPageButton.ImageTransparentColor = Color.Magenta;
            NextPageButton.MergeAction = MergeAction.MatchOnly;
            NextPageButton.Name = "NextPageButton";
            NextPageButton.Overflow = ToolStripItemOverflow.Never;
            NextPageButton.Size = new Size(36, 35);
            NextPageButton.Text = "Next Page";
            NextPageButton.Click += NextPageButton_Click;
            // 
            // CancelSetupButton
            // 
            CancelSetupButton.BackColor = SystemColors.Control;
            CancelSetupButton.DialogResult = DialogResult.Cancel;
            CancelSetupButton.Dock = DockStyle.Left;
            CancelSetupButton.Font = new Font("Bahnschrift", 11F, FontStyle.Bold);
            CancelSetupButton.Location = new Point(1, 1);
            CancelSetupButton.Margin = new Padding(0);
            CancelSetupButton.MaximumSize = new Size(125, 45);
            CancelSetupButton.MinimumSize = new Size(125, 45);
            CancelSetupButton.Name = "CancelSetupButton";
            CancelSetupButton.Size = new Size(125, 45);
            CancelSetupButton.TabIndex = 1;
            CancelSetupButton.Text = "Cancel";
            CancelSetupButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            CancelSetupButton.UseVisualStyleBackColor = false;
            CancelSetupButton.Click += CancelButton_Click;
            // 
            // DoneButton
            // 
            DoneButton.BackColor = SystemColors.Control;
            DoneButton.DialogResult = DialogResult.OK;
            DoneButton.Dock = DockStyle.Right;
            DoneButton.Font = new Font("Bahnschrift", 11F, FontStyle.Bold);
            DoneButton.Location = new Point(588, 1);
            DoneButton.Margin = new Padding(0);
            DoneButton.MaximumSize = new Size(125, 45);
            DoneButton.MinimumSize = new Size(125, 45);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new Size(125, 45);
            DoneButton.TabIndex = 0;
            DoneButton.Text = "Done";
            DoneButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            DoneButton.UseVisualStyleBackColor = false;
            DoneButton.Click += DoneButton_Click;
            // 
            // SmartBackupSetupWindow
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(734, 561);
            Controls.Add(MainPanel);
            DoubleBuffered = true;
            Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(750, 600);
            MinimizeBox = false;
            MinimumSize = new Size(750, 600);
            Name = "SmartBackupSetupWindow";
            Padding = new Padding(2);
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Smart Backup Setup";
            TopMost = true;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            OptionCategorySubPanel.ResumeLayout(false);
            OptionCategorySubPanel.PerformLayout();
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            TopLeftPanel.ResumeLayout(false);
            TopLeftPanel.PerformLayout();
            ControlAreaSubPanel.ResumeLayout(false);
            ControlAreaSubPanel.PerformLayout();
            ToggleSmartBackupPanel.ResumeLayout(false);
            ToggleSmartBackupPanel.PerformLayout();
            TopRightMainPanel.ResumeLayout(false);
            TopRightMainPanel.PerformLayout();
            DatabaseListBoxPanel.ResumeLayout(false);
            DatabaseListBoxPanel.PerformLayout();
            TopRightSubPanel.ResumeLayout(false);
            TopRightSubPanel.PerformLayout();
            SavegameSelectionToolstrip.ResumeLayout(false);
            SavegameSelectionToolstrip.PerformLayout();
            DatabaseSetupPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DatabaseInfoGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)DatabaseDisplayGridView).EndInit();
            BottomPanel.ResumeLayout(false);
            BottomPanel.PerformLayout();
            BottomSubPanel.ResumeLayout(false);
            BottomSubPanel.PerformLayout();
            BottomOptionToolStripBar.ResumeLayout(false);
            BottomOptionToolStripBar.PerformLayout();
            SmartBackupSettingsMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private Panel ToggleSmartBackupPanel;
        private RadioButton EnableSmartBackupRadioButton;
        private RadioButton DisableSmartBackupRadioButton;
        private Panel BottomPanel;
        private Button DoneButton;
        private Panel ControlAreaSubPanel;
        private Panel DatabaseSetupPanel;
        private Panel OptionCategorySubPanel;
        private DataGridView DatabaseInfoGridView;
        private Panel TopPanel;
        private Panel TopRightMainPanel;
        private Panel TopLeftPanel;
        private Panel TopRightSubPanel;
        private ComboBox GamemodeComboBox;
        private ComboBox SavegameComboBox;
        private Label SavegameLabel;
        private Label GamemodeLabel;
        private ToolStrip SavegameSelectionToolstrip;
        private ToolStripButton CreateButton;
        private ToolStripProgressBar TSProgressbar;
        private ToolStripButton SetupButton;
        private ListBox DatabaseListBox;
        private Panel DatabaseListBoxPanel;
        private Label DatabaseListboxLabel;
        private DataGridView DatabaseDisplayGridView;
        private Button CancelSetupButton;
        private ContextMenuStrip SmartBackupSettingsMenuStrip;
        private ToolStripMenuItem AutoLoadDatabaseMenuOption;
        private RadioButton DisplayDatabaseRadioButton;
        private RadioButton DisplayDatabaseDataInfoRadioButton;
        private Panel BottomSubPanel;
        private ToolStrip BottomOptionToolStripBar;
        private ToolStripComboBox MaxDataGridRowsComboBox;
        private ToolStripDropDownButton TS_SmartBackupSettingsButton;
        private ToolStripSeparator BottomTS_SeparatorB;
        private ToolStripButton PreviousPageButton;
        private ToolStripSeparator BottomTS_SeparatorA;
        private ToolStripButton NextPageButton;
        private ToolStripTextBox GridViewPageTextBox;
        private ToolStripButton DeletePresetButton;
    }
}