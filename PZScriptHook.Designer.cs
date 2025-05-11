namespace ZomboidBackupManager
{
    partial class PZScriptHook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PZScriptHook));
            StartStopButton = new Button();
            txtLog = new ListBox();
            LoadedSavegameInfoPanel = new Panel();
            AutoDeleteCheckbox = new CheckBox();
            AddToTaskBarCheckbox = new CheckBox();
            ChangeSelectionLabelText = new Label();
            SavegameComboBox = new ComboBox();
            GamemodesComboBox = new ComboBox();
            AlwaysOnTopCheckbox = new CheckBox();
            LoadedSavegameInfoLabel = new Label();
            SavegameNameTextLabel = new Label();
            SavegameNameValueLabel = new Label();
            MinimizedNotifyIcon = new NotifyIcon(components);
            TaskbarIconMenuStrip = new ContextMenuStrip(components);
            statusInfosToolStripMenuItem = new ToolStripMenuItem();
            TaskbarStatusMenu = new ContextMenuStrip(components);
            ContextMenuStatusLabel = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            ToolStripGamemodeTextBox = new ToolStripTextBox();
            ToolStripSavegameTextBox = new ToolStripTextBox();
            toggleTrackingToolStripMenuItem = new ToolStripMenuItem();
            ToggleTrackingContextMenu = new ContextMenuStrip(components);
            ToggleTrackingMenuItem = new ToolStripMenuItem();
            maximizeToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            PZScriptHookTooltip = new ToolTip(components);
            CloseScriptHookButton = new Button();
            LoadedSavegameInfoPanel.SuspendLayout();
            TaskbarIconMenuStrip.SuspendLayout();
            TaskbarStatusMenu.SuspendLayout();
            ToggleTrackingContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // StartStopButton
            // 
            StartStopButton.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartStopButton.Location = new Point(427, 510);
            StartStopButton.Margin = new Padding(5);
            StartStopButton.Name = "StartStopButton";
            StartStopButton.Size = new Size(139, 33);
            StartStopButton.TabIndex = 0;
            StartStopButton.Text = "Start Tracker";
            StartStopButton.UseVisualStyleBackColor = true;
            StartStopButton.Click += StartStopButton_Click;
            // 
            // txtLog
            // 
            txtLog.Font = new Font("Ubuntu Mono", 10F);
            txtLog.FormattingEnabled = true;
            txtLog.Items.AddRange(new object[] { " " });
            txtLog.Location = new Point(14, 268);
            txtLog.Margin = new Padding(5);
            txtLog.Name = "txtLog";
            txtLog.SelectionMode = SelectionMode.None;
            txtLog.Size = new Size(552, 228);
            txtLog.TabIndex = 1;
            // 
            // LoadedSavegameInfoPanel
            // 
            LoadedSavegameInfoPanel.BackColor = SystemColors.ControlDarkDark;
            LoadedSavegameInfoPanel.Controls.Add(AutoDeleteCheckbox);
            LoadedSavegameInfoPanel.Controls.Add(AddToTaskBarCheckbox);
            LoadedSavegameInfoPanel.Controls.Add(ChangeSelectionLabelText);
            LoadedSavegameInfoPanel.Controls.Add(SavegameComboBox);
            LoadedSavegameInfoPanel.Controls.Add(GamemodesComboBox);
            LoadedSavegameInfoPanel.Controls.Add(AlwaysOnTopCheckbox);
            LoadedSavegameInfoPanel.Controls.Add(LoadedSavegameInfoLabel);
            LoadedSavegameInfoPanel.Controls.Add(SavegameNameTextLabel);
            LoadedSavegameInfoPanel.Controls.Add(SavegameNameValueLabel);
            LoadedSavegameInfoPanel.Location = new Point(14, 12);
            LoadedSavegameInfoPanel.Name = "LoadedSavegameInfoPanel";
            LoadedSavegameInfoPanel.Size = new Size(552, 248);
            LoadedSavegameInfoPanel.TabIndex = 13;
            // 
            // AutoDeleteCheckbox
            // 
            AutoDeleteCheckbox.Font = new Font("Bahnschrift", 12F);
            AutoDeleteCheckbox.ForeColor = SystemColors.ControlLightLight;
            AutoDeleteCheckbox.Location = new Point(412, 209);
            AutoDeleteCheckbox.Margin = new Padding(5, 5, 5, 2);
            AutoDeleteCheckbox.Name = "AutoDeleteCheckbox";
            AutoDeleteCheckbox.RightToLeft = RightToLeft.Yes;
            AutoDeleteCheckbox.Size = new Size(130, 23);
            AutoDeleteCheckbox.TabIndex = 18;
            AutoDeleteCheckbox.Text = "Autodelete";
            AutoDeleteCheckbox.TextAlign = ContentAlignment.MiddleCenter;
            PZScriptHookTooltip.SetToolTip(AutoDeleteCheckbox, "Enable/Disable \"Autodelete\" feature. For more information,\r\ngo back to: Main Window -> Settings -> Autodelete");
            AutoDeleteCheckbox.UseVisualStyleBackColor = true;
            AutoDeleteCheckbox.Click += AutoDeleteCheckbox_Click;
            // 
            // AddToTaskBarCheckbox
            // 
            AddToTaskBarCheckbox.Checked = true;
            AddToTaskBarCheckbox.CheckState = CheckState.Checked;
            AddToTaskBarCheckbox.Font = new Font("Bahnschrift", 12F);
            AddToTaskBarCheckbox.ForeColor = SystemColors.Control;
            AddToTaskBarCheckbox.Location = new Point(10, 179);
            AddToTaskBarCheckbox.Margin = new Padding(5, 5, 5, 2);
            AddToTaskBarCheckbox.Name = "AddToTaskBarCheckbox";
            AddToTaskBarCheckbox.Size = new Size(150, 23);
            AddToTaskBarCheckbox.TabIndex = 17;
            AddToTaskBarCheckbox.Text = "Add to taskbar";
            AddToTaskBarCheckbox.TextAlign = ContentAlignment.MiddleCenter;
            PZScriptHookTooltip.SetToolTip(AddToTaskBarCheckbox, "If checked, hide this window from taskbar when minimizing\r\nand add an icon to the taskbar notification area (the area e.g. \r\nwhere your volume/sound icon & steam icon is present)");
            AddToTaskBarCheckbox.UseVisualStyleBackColor = true;
            AddToTaskBarCheckbox.CheckedChanged += AddToTaskBarCheckbox_CheckedChanged;
            // 
            // ChangeSelectionLabelText
            // 
            ChangeSelectionLabelText.AutoSize = true;
            ChangeSelectionLabelText.Font = new Font("Bahnschrift", 12F);
            ChangeSelectionLabelText.ForeColor = SystemColors.Control;
            ChangeSelectionLabelText.Location = new Point(10, 9);
            ChangeSelectionLabelText.Margin = new Padding(10, 5, 10, 5);
            ChangeSelectionLabelText.Name = "ChangeSelectionLabelText";
            ChangeSelectionLabelText.Size = new Size(149, 19);
            ChangeSelectionLabelText.TabIndex = 16;
            ChangeSelectionLabelText.Text = "Change Savegame:";
            ChangeSelectionLabelText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SavegameComboBox
            // 
            SavegameComboBox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SavegameComboBox.FormattingEnabled = true;
            SavegameComboBox.Location = new Point(10, 69);
            SavegameComboBox.Name = "SavegameComboBox";
            SavegameComboBox.Size = new Size(532, 27);
            SavegameComboBox.TabIndex = 15;
            SavegameComboBox.SelectedIndexChanged += SavegameComboBox_SelectedIndexChanged;
            // 
            // GamemodesComboBox
            // 
            GamemodesComboBox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GamemodesComboBox.FormattingEnabled = true;
            GamemodesComboBox.Location = new Point(10, 34);
            GamemodesComboBox.Margin = new Padding(10, 5, 10, 5);
            GamemodesComboBox.Name = "GamemodesComboBox";
            GamemodesComboBox.Size = new Size(532, 27);
            GamemodesComboBox.TabIndex = 14;
            GamemodesComboBox.SelectedIndexChanged += GamemodesComboBox_SelectedIndexChanged;
            // 
            // AlwaysOnTopCheckbox
            // 
            AlwaysOnTopCheckbox.Font = new Font("Bahnschrift", 12F);
            AlwaysOnTopCheckbox.ForeColor = SystemColors.ControlLight;
            AlwaysOnTopCheckbox.Location = new Point(10, 209);
            AlwaysOnTopCheckbox.Margin = new Padding(5, 5, 5, 2);
            AlwaysOnTopCheckbox.Name = "AlwaysOnTopCheckbox";
            AlwaysOnTopCheckbox.Size = new Size(130, 23);
            AlwaysOnTopCheckbox.TabIndex = 13;
            AlwaysOnTopCheckbox.Text = "Always on top";
            AlwaysOnTopCheckbox.TextAlign = ContentAlignment.MiddleCenter;
            AlwaysOnTopCheckbox.UseVisualStyleBackColor = true;
            AlwaysOnTopCheckbox.CheckedChanged += AlwaysOnTopCheckbox_CheckedChanged;
            // 
            // LoadedSavegameInfoLabel
            // 
            LoadedSavegameInfoLabel.AutoSize = true;
            LoadedSavegameInfoLabel.Font = new Font("Bahnschrift", 12F);
            LoadedSavegameInfoLabel.ForeColor = SystemColors.Control;
            LoadedSavegameInfoLabel.Location = new Point(10, 99);
            LoadedSavegameInfoLabel.Name = "LoadedSavegameInfoLabel";
            LoadedSavegameInfoLabel.Size = new Size(140, 19);
            LoadedSavegameInfoLabel.TabIndex = 12;
            LoadedSavegameInfoLabel.Text = "Currently Loaded:";
            LoadedSavegameInfoLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SavegameNameTextLabel
            // 
            SavegameNameTextLabel.BackColor = SystemColors.Control;
            SavegameNameTextLabel.BorderStyle = BorderStyle.FixedSingle;
            SavegameNameTextLabel.Font = new Font("Bahnschrift", 10F);
            SavegameNameTextLabel.Location = new Point(10, 123);
            SavegameNameTextLabel.Margin = new Padding(10, 5, 10, 5);
            SavegameNameTextLabel.Name = "SavegameNameTextLabel";
            SavegameNameTextLabel.Size = new Size(86, 28);
            SavegameNameTextLabel.TabIndex = 10;
            SavegameNameTextLabel.Text = "Savegame:";
            SavegameNameTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SavegameNameValueLabel
            // 
            SavegameNameValueLabel.BackColor = SystemColors.Control;
            SavegameNameValueLabel.BorderStyle = BorderStyle.FixedSingle;
            SavegameNameValueLabel.Font = new Font("Bahnschrift", 10F);
            SavegameNameValueLabel.Location = new Point(95, 123);
            SavegameNameValueLabel.Margin = new Padding(10, 5, 10, 5);
            SavegameNameValueLabel.Name = "SavegameNameValueLabel";
            SavegameNameValueLabel.Size = new Size(447, 28);
            SavegameNameValueLabel.TabIndex = 11;
            SavegameNameValueLabel.Text = "-";
            SavegameNameValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MinimizedNotifyIcon
            // 
            MinimizedNotifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
            MinimizedNotifyIcon.BalloonTipText = "You minimized the Backup Manager without starting\r\nto listen to PZ. This way, the ingame hotkey mod\r\nwon't work.";
            MinimizedNotifyIcon.BalloonTipTitle = "Warning!";
            MinimizedNotifyIcon.ContextMenuStrip = TaskbarIconMenuStrip;
            MinimizedNotifyIcon.Icon = (Icon)resources.GetObject("MinimizedNotifyIcon.Icon");
            MinimizedNotifyIcon.Text = "PZBackupManager";
            MinimizedNotifyIcon.MouseDoubleClick += MinimizedNotifyIcon_MouseDoubleClick;
            // 
            // TaskbarIconMenuStrip
            // 
            TaskbarIconMenuStrip.BackColor = SystemColors.ControlDarkDark;
            TaskbarIconMenuStrip.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TaskbarIconMenuStrip.Items.AddRange(new ToolStripItem[] { statusInfosToolStripMenuItem, toggleTrackingToolStripMenuItem, maximizeToolStripMenuItem, closeToolStripMenuItem });
            TaskbarIconMenuStrip.Name = "contextMenuStrip1";
            TaskbarIconMenuStrip.ShowImageMargin = false;
            TaskbarIconMenuStrip.Size = new Size(148, 92);
            // 
            // statusInfosToolStripMenuItem
            // 
            statusInfosToolStripMenuItem.BackColor = SystemColors.ControlDark;
            statusInfosToolStripMenuItem.DropDown = TaskbarStatusMenu;
            statusInfosToolStripMenuItem.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusInfosToolStripMenuItem.ForeColor = Color.Cornsilk;
            statusInfosToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            statusInfosToolStripMenuItem.Name = "statusInfosToolStripMenuItem";
            statusInfosToolStripMenuItem.Size = new Size(147, 22);
            statusInfosToolStripMenuItem.Text = "Status Infos";
            // 
            // TaskbarStatusMenu
            // 
            TaskbarStatusMenu.AutoSize = false;
            TaskbarStatusMenu.BackColor = SystemColors.ControlDark;
            TaskbarStatusMenu.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TaskbarStatusMenu.Items.AddRange(new ToolStripItem[] { ContextMenuStatusLabel, toolStripSeparator1, ToolStripGamemodeTextBox, ToolStripSavegameTextBox });
            TaskbarStatusMenu.LayoutStyle = ToolStripLayoutStyle.Table;
            TaskbarStatusMenu.Name = "TaskbarStatusMenu";
            TaskbarStatusMenu.OwnerItem = statusInfosToolStripMenuItem;
            TaskbarStatusMenu.ShowImageMargin = false;
            TaskbarStatusMenu.Size = new Size(270, 150);
            // 
            // ContextMenuStatusLabel
            // 
            ContextMenuStatusLabel.AutoSize = false;
            ContextMenuStatusLabel.BackColor = SystemColors.ControlLight;
            ContextMenuStatusLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ContextMenuStatusLabel.ForeColor = Color.DarkCyan;
            ContextMenuStatusLabel.Name = "ContextMenuStatusLabel";
            ContextMenuStatusLabel.Size = new Size(250, 35);
            ContextMenuStatusLabel.Text = "Status";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(266, 6);
            // 
            // ToolStripGamemodeTextBox
            // 
            ToolStripGamemodeTextBox.AutoSize = false;
            ToolStripGamemodeTextBox.BackColor = SystemColors.ControlDarkDark;
            ToolStripGamemodeTextBox.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ToolStripGamemodeTextBox.ForeColor = SystemColors.Info;
            ToolStripGamemodeTextBox.Name = "ToolStripGamemodeTextBox";
            ToolStripGamemodeTextBox.Size = new Size(250, 25);
            ToolStripGamemodeTextBox.Text = "Gamemode:";
            // 
            // ToolStripSavegameTextBox
            // 
            ToolStripSavegameTextBox.AutoSize = false;
            ToolStripSavegameTextBox.BackColor = SystemColors.ControlDarkDark;
            ToolStripSavegameTextBox.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ToolStripSavegameTextBox.ForeColor = SystemColors.Info;
            ToolStripSavegameTextBox.Name = "ToolStripSavegameTextBox";
            ToolStripSavegameTextBox.Size = new Size(250, 25);
            ToolStripSavegameTextBox.Text = "Savegame:";
            // 
            // toggleTrackingToolStripMenuItem
            // 
            toggleTrackingToolStripMenuItem.BackColor = SystemColors.ControlDark;
            toggleTrackingToolStripMenuItem.DropDown = ToggleTrackingContextMenu;
            toggleTrackingToolStripMenuItem.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toggleTrackingToolStripMenuItem.ForeColor = Color.Cornsilk;
            toggleTrackingToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            toggleTrackingToolStripMenuItem.Name = "toggleTrackingToolStripMenuItem";
            toggleTrackingToolStripMenuItem.Size = new Size(147, 22);
            toggleTrackingToolStripMenuItem.Text = "ToggleTracking";
            // 
            // ToggleTrackingContextMenu
            // 
            ToggleTrackingContextMenu.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ToggleTrackingContextMenu.Items.AddRange(new ToolStripItem[] { ToggleTrackingMenuItem });
            ToggleTrackingContextMenu.Name = "contextMenuStrip1";
            ToggleTrackingContextMenu.OwnerItem = toggleTrackingToolStripMenuItem;
            ToggleTrackingContextMenu.Size = new Size(140, 34);
            ToggleTrackingContextMenu.Text = "ToggleTrackingContextMenu";
            // 
            // ToggleTrackingMenuItem
            // 
            ToggleTrackingMenuItem.BackColor = SystemColors.ControlDarkDark;
            ToggleTrackingMenuItem.CheckOnClick = true;
            ToggleTrackingMenuItem.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ToggleTrackingMenuItem.ForeColor = Color.Cornsilk;
            ToggleTrackingMenuItem.Image = (Image)resources.GetObject("ToggleTrackingMenuItem.Image");
            ToggleTrackingMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            ToggleTrackingMenuItem.ImageTransparentColor = Color.Transparent;
            ToggleTrackingMenuItem.Name = "ToggleTrackingMenuItem";
            ToggleTrackingMenuItem.RightToLeft = RightToLeft.No;
            ToggleTrackingMenuItem.Size = new Size(139, 30);
            ToggleTrackingMenuItem.Text = "Tracking";
            ToggleTrackingMenuItem.CheckedChanged += ToggleTrackingMenuItem_CheckedChanged;
            // 
            // maximizeToolStripMenuItem
            // 
            maximizeToolStripMenuItem.BackColor = SystemColors.ControlDark;
            maximizeToolStripMenuItem.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            maximizeToolStripMenuItem.ForeColor = Color.Cornsilk;
            maximizeToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            maximizeToolStripMenuItem.Name = "maximizeToolStripMenuItem";
            maximizeToolStripMenuItem.Size = new Size(147, 22);
            maximizeToolStripMenuItem.Text = "Maximize";
            maximizeToolStripMenuItem.MouseDown += maximizeToolStripMenuItem_OnMouseDown;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.BackColor = SystemColors.ControlDark;
            closeToolStripMenuItem.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            closeToolStripMenuItem.ForeColor = Color.Cornsilk;
            closeToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(147, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // CloseScriptHookButton
            // 
            CloseScriptHookButton.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CloseScriptHookButton.Location = new Point(14, 510);
            CloseScriptHookButton.Margin = new Padding(5);
            CloseScriptHookButton.Name = "CloseScriptHookButton";
            CloseScriptHookButton.Size = new Size(139, 33);
            CloseScriptHookButton.TabIndex = 14;
            CloseScriptHookButton.Text = "Close";
            CloseScriptHookButton.UseVisualStyleBackColor = true;
            CloseScriptHookButton.Click += CloseScriptHookButton_Click;
            // 
            // PZScriptHook
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 557);
            Controls.Add(CloseScriptHookButton);
            Controls.Add(txtLog);
            Controls.Add(StartStopButton);
            Controls.Add(LoadedSavegameInfoPanel);
            Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "PZScriptHook";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Project Zomboid Manager Script Hook";
            FormClosing += PZScriptHook_FormClosing;
            Shown += PZScriptHook_Shown;
            Resize += OnMinimizingWindow;
            LoadedSavegameInfoPanel.ResumeLayout(false);
            LoadedSavegameInfoPanel.PerformLayout();
            TaskbarIconMenuStrip.ResumeLayout(false);
            TaskbarStatusMenu.ResumeLayout(false);
            TaskbarStatusMenu.PerformLayout();
            ToggleTrackingContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button StartStopButton;
        private ListBox txtLog;
        private Panel LoadedSavegameInfoPanel;
        private Label SavegameNameTextLabel;
        private Label SavegameNameValueLabel;
        private Label LoadedSavegameInfoLabel;
        private CheckBox AlwaysOnTopCheckbox;
        private ComboBox GamemodesComboBox;
        private ComboBox SavegameComboBox;
        private Label ChangeSelectionLabelText;
        private NotifyIcon MinimizedNotifyIcon;
        private CheckBox AddToTaskBarCheckbox;
        private ToolTip PZScriptHookTooltip;
        private ContextMenuStrip TaskbarIconMenuStrip;
        private ToolStripMenuItem statusInfosToolStripMenuItem;
        private ToolStripMenuItem toggleTrackingToolStripMenuItem;
        private ToolStripMenuItem maximizeToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ContextMenuStrip ToggleTrackingContextMenu;
        private ToolStripMenuItem ToggleTrackingMenuItem;
        private ContextMenuStrip TaskbarStatusMenu;
        private ToolStripTextBox ContextMenuStatusLabel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox ToolStripGamemodeTextBox;
        private ToolStripTextBox ToolStripSavegameTextBox;
        private CheckBox AutoDeleteCheckbox;
        private Button CloseScriptHookButton;
    }
}