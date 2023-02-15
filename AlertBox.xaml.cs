using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ContactAppWPF
{
    public partial class AlertBox : Window
    {
        public Contact NewContact { get; private set; }

        public AlertBox()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtSurname.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtId.Text) ||
                !dateBirthdate.SelectedDate.HasValue)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            NewContact = new Contact
            {
                firstName = txtName.Text,
                lastName = txtSurname.Text,
                email = txtEmail.Text,
                gender = (string)((ComboBoxItem)comboGender.SelectedItem).Content,
                id = int.Parse(txtId.Text),
                birthDate = dateBirthdate.SelectedDate.Value
            };

            // Close the dialog window
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the dialog window
            DialogResult = false;
            Close();
        }

    }
}
