using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactAppWPF
{
    public partial class MainWindow : Window
    {
        string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "database.txt");

        public MainWindow()
        {
            InitializeComponent();

            listContacts.ItemsSource = ReadContacts();
            listContacts.SelectionChanged += ContactListView_SelectionChanged;
        }

        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listContacts.SelectedItem != null)
            {
                Contact selectedContact = (Contact)listContacts.SelectedItem;
                firstNameTextBlock.Text = selectedContact.firstName;
                lastNameTextBlock.Text = selectedContact.lastName;
                emailTextBlock.Text = selectedContact.email;
                genderTextBlock.Text = selectedContact.gender.ToString();
                idTextBlock.Text = selectedContact.id.ToString();
                birthDateTextBlock.Text = selectedContact.birthDate.ToString("dd/MM/yyyy");
            }
            else
            {
                firstNameTextBlock.Text = "";
                lastNameTextBlock.Text = "";
                birthDateTextBlock.Text = "";
                idTextBlock.Text = "";
                genderTextBlock.Text = "";
                emailTextBlock.Text = "";
            }
        }
        private List<Contact> ReadContacts()
        {
            List<Contact> contacts = new List<Contact>();

            using (Stream fileStream = File.Open(path, FileMode.Open))
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line = null;
                do
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    string[] parts = line.Split(',');

                    Contact contact = new Contact()
                    {
                        firstName = parts[1],
                        lastName = parts[2],
                        email = parts[3],
                        gender = parts[4],
                        id = int.Parse(parts[0]),
                        birthDate = DateTime.Parse(parts[5]),
                    };
                    contacts.Add(contact);
                } while (true);
            } 
            return contacts;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Contact selectedContact = (Contact)listContacts.SelectedItem;
            List<Contact> contacts = ReadContacts();

            if (selectedContact == null)
            {
                MessageBox.Show("Please select a contact to edit.");
                return;
            }

            AlertBox editContactDialog = new AlertBox();
            editContactDialog.Title = "Edit Contact";
            editContactDialog.btnSave.Content = "Update";
            editContactDialog.txtName.Text = selectedContact.firstName;
            editContactDialog.txtSurname.Text = selectedContact.lastName;
            editContactDialog.txtEmail.Text = selectedContact.email;
            editContactDialog.txtId.Text = selectedContact.id.ToString();
            editContactDialog.dateBirthdate.SelectedDate = selectedContact.birthDate;
            editContactDialog.comboGender.SelectedItem = editContactDialog.comboGender
                .Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(item => (string)item.Content == selectedContact.gender);

            if (editContactDialog.ShowDialog() == true)
            {
                selectedContact.firstName = editContactDialog.txtName.Text;
                selectedContact.lastName = editContactDialog.txtSurname.Text;
                selectedContact.email = editContactDialog.txtEmail.Text;
                selectedContact.id = int.Parse(editContactDialog.txtId.Text);
                selectedContact.birthDate = editContactDialog.dateBirthdate.SelectedDate.Value;
                selectedContact.gender = (string)((ComboBoxItem)editContactDialog.comboGender.SelectedItem).Content;

                listContacts.Items.Refresh();

                SaveContacts(contacts);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listContacts.SelectedItem != null)
            {
                Contact selectedContact = (Contact)listContacts.SelectedItem;
                List<Contact> contacts = ReadContacts();
                contacts.Remove(selectedContact);
                SaveContacts(contacts);
                listContacts.Items.Refresh();

                listContacts.ItemsSource = contacts;
            }
        }
        private void SaveContacts(List<Contact> contacts)
        {;
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Contact contact in contacts)
                {
                    writer.WriteLine($"{contact.id},{contact.firstName},{contact.lastName},{contact.email},{contact.gender.ToString()},{contact.birthDate.ToString()}");
                }
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AlertBox dialog = new AlertBox();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                Contact newContact = dialog.NewContact;
                List<Contact> contacts = ReadContacts();
                contacts.Add(newContact);
                SaveContacts(contacts);

                listContacts.ItemsSource = contacts;
            }
        }
    }
}