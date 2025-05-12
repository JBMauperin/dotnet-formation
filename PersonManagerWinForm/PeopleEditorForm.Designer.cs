namespace PersonManagerWinForm
{
    partial class PeopleEditorForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            emailTextBox = new TextBox();
            ageTextBox = new TextBox();
            validateBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 29);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Prénom :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 57);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Nom:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 87);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Email :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 117);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 3;
            label4.Text = "Âge :";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(86, 26);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(218, 23);
            firstNameTextBox.TabIndex = 4;
            firstNameTextBox.KeyUp += textBox_KeyUp;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(86, 54);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(218, 23);
            lastNameTextBox.TabIndex = 5;
            lastNameTextBox.KeyUp += textBox_KeyUp;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(86, 83);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(218, 23);
            emailTextBox.TabIndex = 6;
            emailTextBox.KeyUp += textBox_KeyUp;
            // 
            // ageTextBox
            // 
            ageTextBox.Location = new Point(86, 112);
            ageTextBox.Name = "ageTextBox";
            ageTextBox.Size = new Size(53, 23);
            ageTextBox.TabIndex = 7;
            ageTextBox.TextChanged += ageTextBox_TextChanged;
            ageTextBox.KeyUp += textBox_KeyUp;
            // 
            // validateBtn
            // 
            validateBtn.BackgroundImage = Properties.Resources.icons8_coche_emoji_48;
            validateBtn.Location = new Point(189, 174);
            validateBtn.Name = "validateBtn";
            validateBtn.Size = new Size(47, 48);
            validateBtn.TabIndex = 8;
            validateBtn.UseVisualStyleBackColor = true;
            validateBtn.Click += validateBtn_Click;
            // 
            // PeopleEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 234);
            Controls.Add(validateBtn);
            Controls.Add(ageTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PeopleEditorForm";
            Text = "Veuillez saisir les infos de la personne...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox emailTextBox;
        private TextBox ageTextBox;
        private Button validateBtn;
    }
}