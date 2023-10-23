using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using RestSharp;

namespace PasswordManager
{
    public partial class LoginPage : Form
    {
        private WebClient webClient;
        private HttpClient client;
        private User user;
        private string html;
        private string url;
        public LoginPage()
        {
            InitializeComponent();
            html = string.Empty;
            url = "http://localhost:50960/api/Users";
        }

        public LoginPage(ref HttpClient client,  ref User user)  : this()
        {
            
            this.user = user; this.client = client;
            html = string.Empty;
            url = "http://localhost:50960/api/Users";
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            webClient = new WebClient();
            string result;
            webClient.QueryString.Add("m", emailTextBox.Text);
            webClient.QueryString.Add("w", textBox1.Text);
            result = webClient.DownloadString(url);
            
            MessageBox.Show(result);
            if (Int32.Parse(result) == 0)
            {
                MessageBox.Show("Account not found.");
            }
            else
            {
                var restclient = new RestClient("http://localhost:50960/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded", 
                    "grant_type=password&userName=" + "giggity@yahoo.com" + "&password=" + "gquag123", 
                    ParameterType.RequestBody);
                IRestResponse response = restclient.Execute(request);
                MessageBox.Show(response.Content);
                webClient = new WebClient();
                webClient.QueryString.Add("m", emailTextBox.Text);
                webClient.QueryString.Add("w", textBox1.Text);
                webClient.QueryString.Add("x", "0");
                result = webClient.DownloadString(url);
            
                user = new JavaScriptSerializer().Deserialize<User>(result);
                MessageBox.Show(result);
                MessageBox.Show("ID: " + user.id + "Name: " + user.name + 
                    ", Email: " + user.email
                    + ", Password: " + user.password);
                MainPage main = new MainPage(ref client, ref user);
                this.Hide();
                main.ShowDialog();
                this.Close();
            }
            

        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            CreateAccount create = new CreateAccount();
            this.Hide();
            create.ShowDialog();
            this.Show(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
