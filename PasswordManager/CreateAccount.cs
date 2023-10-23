using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using System.Net;

namespace PasswordManager
{
    public partial class CreateAccount : Form
    {
        private HttpClient client;
        private WebClient webClient;
        private string url = "http://localhost:50960/api/Users";
        public CreateAccount()
        {
            client = new HttpClient();
            InitializeComponent();
        }
        public CreateAccount(ref HttpClient client)
        {
            InitializeComponent();
            this.client = client;
        }

        private async Task postAsync(string name, string email, string password)
        {
            var values = new Dictionary<string, string>
            {
                { "name", name },
                { "email", email },
                {"password", password }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(url, content);

            var responseString = await response.Content.ReadAsStringAsync();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Equals(confirmPasswordTextBox.Text))
            {
                webClient = new WebClient();
                string result;
                webClient.QueryString.Add("m", emailTextBox.Text);
                result = webClient.DownloadString(url);

                if (Int32.Parse(result) != 0)
                {
                    MessageBox.Show("Email already in use. Please login");
                }
                else
                {


                    postAsync(nameTextBox.Text, emailTextBox.Text, confirmPasswordTextBox.Text);
                    MessageBox.Show("Thank you for creating your Password Manager Account!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("The passwords do not match! Please Try again.");
                confirmPasswordTextBox.Clear();
                passwordTextBox.Clear();
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
