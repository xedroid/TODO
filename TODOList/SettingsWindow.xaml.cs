using System;
using System.Windows;
using TODOList.Models;
using TODOList.Utilities;

namespace TODOList
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            Settings s = new SettingsManager().Get(1);
            if (s != null)
            {
                txtEmail.Text = s.Email;
                txtNumerDays.Text = s.NumberDays.ToString();
            }
        }

        private bool isNumber(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^\d+$");
        }

        private string Validate()
        {
            string errorContent = "";

            if(string.IsNullOrEmpty(txtNumerDays.Text) || !isNumber(txtNumerDays.Text)) errorContent += "Please enter the number of days.\n";
            if(!EmailManager.isValidEmail(txtEmail.Text)) errorContent += "Invalid format email address.\n";
            return errorContent;
        }

        private void btnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            string validateError = Validate();
            if (validateError != "")
            {
                MessageBox.Show("Error occurred while saving settings:\n" + validateError, "Validate error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Settings s = new SettingsManager().Get(1);
            if (s == null) s = new Settings();

            s.Email = txtEmail.Text;
            s.NumberDays = Convert.ToInt32(txtNumerDays.Text);
            s.SaveOrUpdate();

            MessageBox.Show("Settings have been saved.","Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnSendNotification_Click(object sender, RoutedEventArgs e)
        {
            EmailManager em = new EmailManager();
            string error = em.SendNotification();
            if (error == "")
            {
                MessageBox.Show("Notification have been saved.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else {
                MessageBox.Show("Error occurred while sending notification : " + error, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
