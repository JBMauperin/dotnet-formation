namespace PersonManagerWinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            personsListView = new ListView();
            Nom = new ColumnHeader();
            Prénom = new ColumnHeader();
            Email = new ColumnHeader();
            Age = new ColumnHeader();
            addPersonBtn = new Button();
            editBtn = new Button();
            deleteBtn = new Button();
            SuspendLayout();
            // 
            // personsListView
            // 
            personsListView.Columns.AddRange(new ColumnHeader[] { Nom, Prénom, Email, Age });
            personsListView.Location = new Point(12, 83);
            personsListView.Name = "personsListView";
            personsListView.Size = new Size(776, 355);
            personsListView.TabIndex = 0;
            personsListView.UseCompatibleStateImageBehavior = false;
            personsListView.View = View.Details;
            // 
            // Nom
            // 
            Nom.Text = "Nom";
            // 
            // Prénom
            // 
            Prénom.Text = "Prénom";
            // 
            // Email
            // 
            Email.Text = "Email";
            // 
            // Age
            // 
            Age.Text = "Âge";
            // 
            // addPersonBtn
            // 
            addPersonBtn.BackgroundImage = Properties.Resources.icons8_plus_48;
            addPersonBtn.Location = new Point(12, 28);
            addPersonBtn.Name = "addPersonBtn";
            addPersonBtn.Size = new Size(48, 49);
            addPersonBtn.TabIndex = 1;
            addPersonBtn.UseVisualStyleBackColor = true;
            addPersonBtn.Click += addPersonBtn_Click;
            // 
            // editBtn
            // 
            editBtn.BackgroundImage = (Image)resources.GetObject("editBtn.BackgroundImage");
            editBtn.Location = new Point(66, 25);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(52, 52);
            editBtn.TabIndex = 2;
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.BackgroundImage = (Image)resources.GetObject("deleteBtn.BackgroundImage");
            deleteBtn.Location = new Point(124, 28);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(48, 49);
            deleteBtn.TabIndex = 3;
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(deleteBtn);
            Controls.Add(editBtn);
            Controls.Add(addPersonBtn);
            Controls.Add(personsListView);
            Name = "Form1";
            Text = "Person Manager";
            ResumeLayout(false);
        }

        #endregion

        private ListView personsListView;
        private ColumnHeader Nom;
        private ColumnHeader Prénom;
        private ColumnHeader Email;
        private ColumnHeader Age;
        private Button addPersonBtn;
        private Button editBtn;
        private Button deleteBtn;
    }
}
