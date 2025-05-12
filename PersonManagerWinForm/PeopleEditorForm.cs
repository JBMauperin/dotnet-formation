using System.Text.RegularExpressions;

namespace PersonManagerWinForm
{
    public partial class PeopleEditorForm : Form
    {
        public string firstName;
        public string lastName;
        public string email;
        public int age;

        public PeopleEditorForm()
        {
            InitializeComponent();
        }

        public void LoadPersonData(string lastName, string firstName, string email, string age)
        {
            lastNameTextBox.Text = lastName;
            firstNameTextBox.Text = firstName;
            emailTextBox.Text = email;
            ageTextBox.Text = age;
        }

        private void ageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(ageTextBox.Text, out int age))
            {
                if (age < 0 || age > 120)
                {
                    MessageBox.Show("Please enter a valid age between 0 and 120.");
                    ageTextBox.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number for age.");
                ageTextBox.Focus();
            }
        }

        private void validateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox.Text))
            {
                MessageBox.Show("Merci de saisir un prénom.");
                return;
            }

            if (string.IsNullOrEmpty(lastNameTextBox.Text))
            {
                MessageBox.Show("Merci de saisir un nom.");
                return;
            }

            if (string.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Merci de saisir un email.");
                return;
            }
            else if(!Regex.IsMatch(emailTextBox.Text, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Merci de saisir un email valide.");
                return;
            }

            if (string.IsNullOrEmpty(ageTextBox.Text))
            {
                MessageBox.Show("Merci de saisir un âge.");
                return;
            }

            firstName = firstNameTextBox.Text;
            lastName = lastNameTextBox.Text;
            email = emailTextBox.Text;
            age = int.Parse(ageTextBox.Text);

            Close();
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validateBtn_Click(sender, e);
            }
        }
    }
}
