namespace Курсовая_работа_ООП
{
    partial class MainForm
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartMicrowaveButton = new System.Windows.Forms.Button();
            this.StopMicrowaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IncreasePowerButton = new System.Windows.Forms.Button();
            this.ReducePowerButton = new System.Windows.Forms.Button();
            this.PowerLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartMicrowaveButton
            // 
            this.StartMicrowaveButton.Location = new System.Drawing.Point(996, 474);
            this.StartMicrowaveButton.Name = "StartMicrowaveButton";
            this.StartMicrowaveButton.Size = new System.Drawing.Size(83, 23);
            this.StartMicrowaveButton.TabIndex = 1;
            this.StartMicrowaveButton.Text = "Старт";
            this.StartMicrowaveButton.UseVisualStyleBackColor = true;
            this.StartMicrowaveButton.Click += new System.EventHandler(this.StartMicrowaveButton_Click);
            // 
            // StopMicrowaveButton
            // 
            this.StopMicrowaveButton.Location = new System.Drawing.Point(1086, 474);
            this.StopMicrowaveButton.Name = "StopMicrowaveButton";
            this.StopMicrowaveButton.Size = new System.Drawing.Size(83, 23);
            this.StopMicrowaveButton.TabIndex = 2;
            this.StopMicrowaveButton.Text = "Стоп";
            this.StopMicrowaveButton.UseVisualStyleBackColor = true;
            this.StopMicrowaveButton.Click += new System.EventHandler(this.StopMicrowaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1051, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Мощность";
            // 
            // IncreasePowerButton
            // 
            this.IncreasePowerButton.Location = new System.Drawing.Point(1086, 431);
            this.IncreasePowerButton.Name = "IncreasePowerButton";
            this.IncreasePowerButton.Size = new System.Drawing.Size(25, 23);
            this.IncreasePowerButton.TabIndex = 4;
            this.IncreasePowerButton.Text = "+";
            this.IncreasePowerButton.UseVisualStyleBackColor = true;
            this.IncreasePowerButton.Click += new System.EventHandler(this.IncreasePowerButton_Click);
            // 
            // ReducePowerButton
            // 
            this.ReducePowerButton.Location = new System.Drawing.Point(1054, 431);
            this.ReducePowerButton.Name = "ReducePowerButton";
            this.ReducePowerButton.Size = new System.Drawing.Size(25, 23);
            this.ReducePowerButton.TabIndex = 5;
            this.ReducePowerButton.Text = "-";
            this.ReducePowerButton.UseVisualStyleBackColor = true;
            this.ReducePowerButton.Click += new System.EventHandler(this.ReducePowerButton_Click);
            // 
            // PowerLabel
            // 
            this.PowerLabel.AutoSize = true;
            this.PowerLabel.Location = new System.Drawing.Point(1076, 410);
            this.PowerLabel.Name = "PowerLabel";
            this.PowerLabel.Size = new System.Drawing.Size(0, 13);
            this.PowerLabel.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 646);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Вода";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 646);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Суп";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PowerLabel);
            this.Controls.Add(this.ReducePowerButton);
            this.Controls.Add(this.IncreasePowerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StopMicrowaveButton);
            this.Controls.Add(this.StartMicrowaveButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartMicrowaveButton;
        private System.Windows.Forms.Button StopMicrowaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button IncreasePowerButton;
        private System.Windows.Forms.Button ReducePowerButton;
        private System.Windows.Forms.Label PowerLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

