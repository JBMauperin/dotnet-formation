using PersonManagerWinForm.Models;
using PersonManagerWinForm.Services;

namespace PersonManagerWinForm
{
    public partial class Form1 : Form
    {
        private PersonManager _personManager = new PersonManager();
        private Person _editedPerson = null;

        public Form1()
        {
            InitializeComponent();

            RefreshPersonsList();
        }

        private void addPersonBtn_Click(object sender, EventArgs e)
        {
            PeopleEditorForm editorForm = new PeopleEditorForm();
            editorForm.FormClosed += onPeopleEditorClose;

            editorForm.ShowDialog();
        }

        private void onPeopleEditorClose(object sender, EventArgs e)
        {
            var editorForm = (PeopleEditorForm)sender;
            if(_editedPerson != null)
            {
                _personManager.EditPerson(_editedPerson, editorForm.lastName, editorForm.firstName, editorForm.email, editorForm.age);
            }
            else
            {
                _personManager.AddPerson(editorForm.lastName, editorForm.firstName, editorForm.email, editorForm.age);
            }

            RefreshPersonsList();
        }

        private void RefreshPersonsList()
        {
            List<Person> persons = _personManager.GetAllPersons();
            personsListView.Items.Clear();
            foreach (var person in persons)
            {
                ListViewItem itemName = new ListViewItem(person.LastName);
                itemName.SubItems.Add(person.FirstName);
                itemName.SubItems.Add(person.Email);
                itemName.SubItems.Add(person.Age.ToString());

                personsListView.Items.Add(itemName);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (personsListView.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Merci de sélectionner une personne à supprimer.");
            }

            var answer = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette personne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.No)
            {
                return;
            }

            var selectedItem = personsListView.SelectedItems[0];
            var firstName = selectedItem.SubItems[1].Text;
            var lastName = selectedItem.SubItems[0].Text;

            _personManager.Delete(lastName, firstName);
            RefreshPersonsList();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if(personsListView.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Merci de sélectionner une personne à modifier.");
                return;
            }

            PeopleEditorForm editorForm = new PeopleEditorForm();
            _editedPerson = new Person
            {
                LastName = personsListView.SelectedItems[0].SubItems[0].Text,
                FirstName = personsListView.SelectedItems[0].SubItems[1].Text,
                Email = personsListView.SelectedItems[0].SubItems[2].Text,
                Age = int.Parse(personsListView.SelectedItems[0].SubItems[3].Text)
            };

            editorForm.LoadPersonData(personsListView.SelectedItems[0].SubItems[0].Text, personsListView.SelectedItems[0].SubItems[1].Text, personsListView.SelectedItems[0].SubItems[2].Text, personsListView.SelectedItems[0].SubItems[3].Text);

            editorForm.FormClosed += onPeopleEditorClose;

            editorForm.ShowDialog();
        }
    }
}
