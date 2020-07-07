namespace Timer
{
    partial class Timer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Timer));
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.TimeButton = new System.Windows.Forms.Button();
            this.ExpandButton = new System.Windows.Forms.Button();
            this.ConstrictionButton = new System.Windows.Forms.Button();
            this.Monday = new System.Windows.Forms.Label();
            this.Tuesday = new System.Windows.Forms.Label();
            this.Wednesday = new System.Windows.Forms.Label();
            this.Thursday = new System.Windows.Forms.Label();
            this.Friday = new System.Windows.Forms.Label();
            this.Saturday = new System.Windows.Forms.Label();
            this.Sunday = new System.Windows.Forms.Label();
            this.MondayHours = new System.Windows.Forms.NumericUpDown();
            this.MondayMinutes = new System.Windows.Forms.NumericUpDown();
            this.TuesdayHours = new System.Windows.Forms.NumericUpDown();
            this.TuesdayMinutes = new System.Windows.Forms.NumericUpDown();
            this.WednesdayHours = new System.Windows.Forms.NumericUpDown();
            this.WednesdayMinutes = new System.Windows.Forms.NumericUpDown();
            this.ThursdayHours = new System.Windows.Forms.NumericUpDown();
            this.ThursdayMinutes = new System.Windows.Forms.NumericUpDown();
            this.FridayHours = new System.Windows.Forms.NumericUpDown();
            this.FridayMinutes = new System.Windows.Forms.NumericUpDown();
            this.SaturdayHours = new System.Windows.Forms.NumericUpDown();
            this.SaturdayMinutes = new System.Windows.Forms.NumericUpDown();
            this.SundayHours = new System.Windows.Forms.NumericUpDown();
            this.SundayMinutes = new System.Windows.Forms.NumericUpDown();
            this.TimeProgressBar = new System.Windows.Forms.ProgressBar();
            this.Hours = new System.Windows.Forms.Label();
            this.Minutes = new System.Windows.Forms.Label();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.LabelTimerMode = new System.Windows.Forms.Label();
            this.LabelDayOfWeek = new System.Windows.Forms.Label();
            this.UpdateButoon = new System.Windows.Forms.Button();
            this.LabelRest = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MondayHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MondayMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuesdayHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuesdayMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WednesdayHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WednesdayMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThursdayHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThursdayMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FridayHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FridayMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturdayHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturdayMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SundayHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SundayMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Constantia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.Location = new System.Drawing.Point(178, 138);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(160, 43);
            this.Start.TabIndex = 1;
            this.Start.Text = "Старт";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Font = new System.Drawing.Font("Constantia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stop.Location = new System.Drawing.Point(12, 138);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(160, 43);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "Стоп";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // TimeButton
            // 
            this.TimeButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TimeButton.FlatAppearance.BorderSize = 0;
            this.TimeButton.Font = new System.Drawing.Font("Arial", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.TimeButton.Location = new System.Drawing.Point(12, 6);
            this.TimeButton.Name = "TimeButton";
            this.TimeButton.Size = new System.Drawing.Size(326, 93);
            this.TimeButton.TabIndex = 4;
            this.TimeButton.UseVisualStyleBackColor = false;
            // 
            // ExpandButton
            // 
            this.ExpandButton.Image = ((System.Drawing.Image)(resources.GetObject("ExpandButton.Image")));
            this.ExpandButton.Location = new System.Drawing.Point(344, 6);
            this.ExpandButton.Name = "ExpandButton";
            this.ExpandButton.Size = new System.Drawing.Size(25, 25);
            this.ExpandButton.TabIndex = 5;
            this.ExpandButton.UseVisualStyleBackColor = true;
            this.ExpandButton.Click += new System.EventHandler(this.ExpandButton_Click);
            // 
            // ConstrictionButton
            // 
            this.ConstrictionButton.Image = ((System.Drawing.Image)(resources.GetObject("ConstrictionButton.Image")));
            this.ConstrictionButton.Location = new System.Drawing.Point(344, 37);
            this.ConstrictionButton.Name = "ConstrictionButton";
            this.ConstrictionButton.Size = new System.Drawing.Size(25, 25);
            this.ConstrictionButton.TabIndex = 6;
            this.ConstrictionButton.UseVisualStyleBackColor = true;
            this.ConstrictionButton.Click += new System.EventHandler(this.ConstrictionButton_Click);
            // 
            // Monday
            // 
            this.Monday.AutoSize = true;
            this.Monday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Monday.Location = new System.Drawing.Point(375, 33);
            this.Monday.Name = "Monday";
            this.Monday.Size = new System.Drawing.Size(107, 16);
            this.Monday.TabIndex = 7;
            this.Monday.Text = "Понедельник";
            // 
            // Tuesday
            // 
            this.Tuesday.AutoSize = true;
            this.Tuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tuesday.Location = new System.Drawing.Point(375, 55);
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.Size = new System.Drawing.Size(70, 16);
            this.Tuesday.TabIndex = 8;
            this.Tuesday.Text = "Вторник";
            // 
            // Wednesday
            // 
            this.Wednesday.AutoSize = true;
            this.Wednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Wednesday.Location = new System.Drawing.Point(375, 77);
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.Size = new System.Drawing.Size(54, 16);
            this.Wednesday.TabIndex = 9;
            this.Wednesday.Text = "Среда";
            // 
            // Thursday
            // 
            this.Thursday.AutoSize = true;
            this.Thursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Thursday.Location = new System.Drawing.Point(375, 99);
            this.Thursday.Name = "Thursday";
            this.Thursday.Size = new System.Drawing.Size(69, 16);
            this.Thursday.TabIndex = 10;
            this.Thursday.Text = "Четверг";
            // 
            // Friday
            // 
            this.Friday.AutoSize = true;
            this.Friday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Friday.Location = new System.Drawing.Point(375, 121);
            this.Friday.Name = "Friday";
            this.Friday.Size = new System.Drawing.Size(71, 16);
            this.Friday.TabIndex = 11;
            this.Friday.Text = "Пятница";
            // 
            // Saturday
            // 
            this.Saturday.AutoSize = true;
            this.Saturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Saturday.Location = new System.Drawing.Point(375, 143);
            this.Saturday.Name = "Saturday";
            this.Saturday.Size = new System.Drawing.Size(71, 16);
            this.Saturday.TabIndex = 12;
            this.Saturday.Text = "Суббота";
            // 
            // Sunday
            // 
            this.Sunday.AutoSize = true;
            this.Sunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Sunday.Location = new System.Drawing.Point(375, 165);
            this.Sunday.Name = "Sunday";
            this.Sunday.Size = new System.Drawing.Size(104, 16);
            this.Sunday.TabIndex = 13;
            this.Sunday.Text = "Воскресенье";
            // 
            // MondayHours
            // 
            this.MondayHours.BackColor = System.Drawing.SystemColors.Window;
            this.MondayHours.Location = new System.Drawing.Point(492, 33);
            this.MondayHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.MondayHours.Name = "MondayHours";
            this.MondayHours.Size = new System.Drawing.Size(35, 20);
            this.MondayHours.TabIndex = 14;
            // 
            // MondayMinutes
            // 
            this.MondayMinutes.Location = new System.Drawing.Point(548, 33);
            this.MondayMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MondayMinutes.Name = "MondayMinutes";
            this.MondayMinutes.Size = new System.Drawing.Size(35, 20);
            this.MondayMinutes.TabIndex = 15;
            // 
            // TuesdayHours
            // 
            this.TuesdayHours.Location = new System.Drawing.Point(492, 55);
            this.TuesdayHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.TuesdayHours.Name = "TuesdayHours";
            this.TuesdayHours.Size = new System.Drawing.Size(35, 20);
            this.TuesdayHours.TabIndex = 16;
            // 
            // TuesdayMinutes
            // 
            this.TuesdayMinutes.Location = new System.Drawing.Point(548, 55);
            this.TuesdayMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.TuesdayMinutes.Name = "TuesdayMinutes";
            this.TuesdayMinutes.Size = new System.Drawing.Size(35, 20);
            this.TuesdayMinutes.TabIndex = 17;
            // 
            // WednesdayHours
            // 
            this.WednesdayHours.Location = new System.Drawing.Point(492, 77);
            this.WednesdayHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.WednesdayHours.Name = "WednesdayHours";
            this.WednesdayHours.Size = new System.Drawing.Size(35, 20);
            this.WednesdayHours.TabIndex = 18;
            // 
            // WednesdayMinutes
            // 
            this.WednesdayMinutes.Location = new System.Drawing.Point(548, 77);
            this.WednesdayMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.WednesdayMinutes.Name = "WednesdayMinutes";
            this.WednesdayMinutes.Size = new System.Drawing.Size(35, 20);
            this.WednesdayMinutes.TabIndex = 19;
            // 
            // ThursdayHours
            // 
            this.ThursdayHours.Location = new System.Drawing.Point(492, 99);
            this.ThursdayHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.ThursdayHours.Name = "ThursdayHours";
            this.ThursdayHours.Size = new System.Drawing.Size(35, 20);
            this.ThursdayHours.TabIndex = 20;
            // 
            // ThursdayMinutes
            // 
            this.ThursdayMinutes.Location = new System.Drawing.Point(548, 99);
            this.ThursdayMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.ThursdayMinutes.Name = "ThursdayMinutes";
            this.ThursdayMinutes.Size = new System.Drawing.Size(35, 20);
            this.ThursdayMinutes.TabIndex = 21;
            // 
            // FridayHours
            // 
            this.FridayHours.Location = new System.Drawing.Point(492, 121);
            this.FridayHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.FridayHours.Name = "FridayHours";
            this.FridayHours.Size = new System.Drawing.Size(35, 20);
            this.FridayHours.TabIndex = 22;
            // 
            // FridayMinutes
            // 
            this.FridayMinutes.Location = new System.Drawing.Point(548, 121);
            this.FridayMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.FridayMinutes.Name = "FridayMinutes";
            this.FridayMinutes.Size = new System.Drawing.Size(35, 20);
            this.FridayMinutes.TabIndex = 23;
            // 
            // SaturdayHours
            // 
            this.SaturdayHours.Location = new System.Drawing.Point(492, 143);
            this.SaturdayHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.SaturdayHours.Name = "SaturdayHours";
            this.SaturdayHours.Size = new System.Drawing.Size(35, 20);
            this.SaturdayHours.TabIndex = 24;
            // 
            // SaturdayMinutes
            // 
            this.SaturdayMinutes.Location = new System.Drawing.Point(548, 143);
            this.SaturdayMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.SaturdayMinutes.Name = "SaturdayMinutes";
            this.SaturdayMinutes.Size = new System.Drawing.Size(35, 20);
            this.SaturdayMinutes.TabIndex = 25;
            // 
            // SundayHours
            // 
            this.SundayHours.Location = new System.Drawing.Point(492, 165);
            this.SundayHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.SundayHours.Name = "SundayHours";
            this.SundayHours.Size = new System.Drawing.Size(35, 20);
            this.SundayHours.TabIndex = 26;
            // 
            // SundayMinutes
            // 
            this.SundayMinutes.Location = new System.Drawing.Point(548, 165);
            this.SundayMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.SundayMinutes.Name = "SundayMinutes";
            this.SundayMinutes.Size = new System.Drawing.Size(35, 20);
            this.SundayMinutes.TabIndex = 27;
            // 
            // TimeProgressBar
            // 
            this.TimeProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.TimeProgressBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.TimeProgressBar.Location = new System.Drawing.Point(12, 107);
            this.TimeProgressBar.Name = "TimeProgressBar";
            this.TimeProgressBar.Size = new System.Drawing.Size(326, 23);
            this.TimeProgressBar.TabIndex = 28;
            // 
            // Hours
            // 
            this.Hours.AutoSize = true;
            this.Hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Hours.Location = new System.Drawing.Point(486, 5);
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(45, 16);
            this.Hours.TabIndex = 29;
            this.Hours.Text = "Часы";
            // 
            // Minutes
            // 
            this.Minutes.AutoSize = true;
            this.Minutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Minutes.Location = new System.Drawing.Point(533, 5);
            this.Minutes.Name = "Minutes";
            this.Minutes.Size = new System.Drawing.Size(65, 16);
            this.Minutes.TabIndex = 30;
            this.Minutes.Text = "Минуты";
            // 
            // MyTimer
            // 
            this.MyTimer.Interval = 1000;
            this.MyTimer.Tick += new System.EventHandler(this.MyTimer_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Timer";
            this.notifyIcon1.Visible = true;
            // 
            // LabelTimerMode
            // 
            this.LabelTimerMode.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelTimerMode.Enabled = false;
            this.LabelTimerMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelTimerMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(120)))), ((int)(((byte)(50)))));
            this.LabelTimerMode.Location = new System.Drawing.Point(21, 12);
            this.LabelTimerMode.Name = "LabelTimerMode";
            this.LabelTimerMode.Size = new System.Drawing.Size(310, 16);
            this.LabelTimerMode.TabIndex = 31;
            this.LabelTimerMode.Text = "Сверхурочные";
            this.LabelTimerMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelDayOfWeek
            // 
            this.LabelDayOfWeek.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelDayOfWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelDayOfWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.LabelDayOfWeek.Location = new System.Drawing.Point(21, 75);
            this.LabelDayOfWeek.Name = "LabelDayOfWeek";
            this.LabelDayOfWeek.Size = new System.Drawing.Size(310, 16);
            this.LabelDayOfWeek.TabIndex = 32;
            this.LabelDayOfWeek.Text = "День недели";
            this.LabelDayOfWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateButoon
            // 
            this.UpdateButoon.AutoSize = true;
            this.UpdateButoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateButoon.Location = new System.Drawing.Point(376, 6);
            this.UpdateButoon.Name = "UpdateButoon";
            this.UpdateButoon.Size = new System.Drawing.Size(91, 26);
            this.UpdateButoon.TabIndex = 33;
            this.UpdateButoon.Text = "Обновить";
            this.UpdateButoon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UpdateButoon.UseVisualStyleBackColor = true;
            this.UpdateButoon.Click += new System.EventHandler(this.Update_Click);
            // 
            // LabelRest
            // 
            this.LabelRest.AutoSize = true;
            this.LabelRest.BackColor = System.Drawing.Color.Black;
            this.LabelRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelRest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(225)))));
            this.LabelRest.Location = new System.Drawing.Point(17, 12);
            this.LabelRest.Name = "LabelRest";
            this.LabelRest.Size = new System.Drawing.Size(69, 13);
            this.LabelRest.TabIndex = 34;
            this.LabelRest.Text = "Отдохните";
            // 
            // Timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 189);
            this.Controls.Add(this.LabelRest);
            this.Controls.Add(this.UpdateButoon);
            this.Controls.Add(this.LabelDayOfWeek);
            this.Controls.Add(this.LabelTimerMode);
            this.Controls.Add(this.Minutes);
            this.Controls.Add(this.Hours);
            this.Controls.Add(this.TimeProgressBar);
            this.Controls.Add(this.SundayMinutes);
            this.Controls.Add(this.SundayHours);
            this.Controls.Add(this.SaturdayMinutes);
            this.Controls.Add(this.SaturdayHours);
            this.Controls.Add(this.FridayMinutes);
            this.Controls.Add(this.FridayHours);
            this.Controls.Add(this.ThursdayMinutes);
            this.Controls.Add(this.ThursdayHours);
            this.Controls.Add(this.WednesdayMinutes);
            this.Controls.Add(this.WednesdayHours);
            this.Controls.Add(this.TuesdayMinutes);
            this.Controls.Add(this.TuesdayHours);
            this.Controls.Add(this.MondayMinutes);
            this.Controls.Add(this.MondayHours);
            this.Controls.Add(this.Sunday);
            this.Controls.Add(this.Saturday);
            this.Controls.Add(this.Friday);
            this.Controls.Add(this.Thursday);
            this.Controls.Add(this.Wednesday);
            this.Controls.Add(this.Tuesday);
            this.Controls.Add(this.Monday);
            this.Controls.Add(this.ConstrictionButton);
            this.Controls.Add(this.ExpandButton);
            this.Controls.Add(this.TimeButton);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Timer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTimer_Closing);
            this.Load += new System.EventHandler(this.Timer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MondayHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MondayMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuesdayHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuesdayMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WednesdayHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WednesdayMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThursdayHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThursdayMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FridayHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FridayMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturdayHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturdayMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SundayHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SundayMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button TimeButton;
        private System.Windows.Forms.Button ExpandButton;
        private System.Windows.Forms.Button ConstrictionButton;
        private System.Windows.Forms.Label Monday;
        private System.Windows.Forms.Label Tuesday;
        private System.Windows.Forms.Label Wednesday;
        private System.Windows.Forms.Label Thursday;
        private System.Windows.Forms.Label Friday;
        private System.Windows.Forms.Label Saturday;
        private System.Windows.Forms.Label Sunday;
        private System.Windows.Forms.NumericUpDown MondayHours;
        private System.Windows.Forms.NumericUpDown MondayMinutes;
        private System.Windows.Forms.NumericUpDown TuesdayHours;
        private System.Windows.Forms.NumericUpDown TuesdayMinutes;
        private System.Windows.Forms.NumericUpDown WednesdayHours;
        private System.Windows.Forms.NumericUpDown WednesdayMinutes;
        private System.Windows.Forms.NumericUpDown ThursdayHours;
        private System.Windows.Forms.NumericUpDown ThursdayMinutes;
        private System.Windows.Forms.NumericUpDown FridayHours;
        private System.Windows.Forms.NumericUpDown FridayMinutes;
        private System.Windows.Forms.NumericUpDown SaturdayHours;
        private System.Windows.Forms.NumericUpDown SaturdayMinutes;
        private System.Windows.Forms.NumericUpDown SundayHours;
        private System.Windows.Forms.NumericUpDown SundayMinutes;
        private System.Windows.Forms.ProgressBar TimeProgressBar;
        private System.Windows.Forms.Label Hours;
        private System.Windows.Forms.Label Minutes;
        private System.Windows.Forms.Timer MyTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label LabelTimerMode;
        private System.Windows.Forms.Label LabelDayOfWeek;
        private System.Windows.Forms.Button UpdateButoon;
        private System.Windows.Forms.Label LabelRest;
    }
}

