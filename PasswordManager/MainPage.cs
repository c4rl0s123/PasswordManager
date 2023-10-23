using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace PasswordManager
{
    public partial class MainPage : Form
    {
        private AccountList list;
        private string response;
        private HttpClient client;
        private WebClient webClient;
        private User user;
        private string url = "http://localhost:50960/api/UserAccounts/";
        public MainPage()
        {
            InitializeComponent();
            list = new AccountList();
        }

        public MainPage(ref HttpClient client, ref User user)
        {
            //InitializeComponent();
            this.client = client; this.user = user;
            response = string.Empty;
            webClient = new WebClient();
            url += user.id;
            MessageBox.Show(url);
            response = webClient.DownloadString(url);
            list = new JavaScriptSerializer().Deserialize<AccountList>(response);
            MessageBox.Show(response);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            CreatePage create = new CreatePage(ref client, ref user, ref list);
            this.Hide();
            create.ShowDialog();
            this.Show();
        }

        private void accountsInfo_Click(object sender, EventArgs e)
        {
            InfoPage info;
            if (list.isEmpty())
            {
                MessageBox.Show("Error! No accounts found. Please create an account.");
            }
            else
            {
                info = new InfoPage(ref client, ref user, ref list);
                this.Hide();
                info.ShowDialog();
                this.Show();
            }
                
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a simple and secure program for storing passwords using AES encryption.");
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
