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

namespace PasswordManager
{
    public partial class CreatePage : Form
    {
        private AccountList list;
        private Account account;
        private bool[] canCreate;
        public CreatePage()
        {
            InitializeComponent();
            list = new AccountList();
            account = new Account();
        }

        public CreatePage(ref HttpClient client, ref User user, ref AccountList aList)
        {
            InitializeComponent();
            list = aList;
            account = new Account();
            canCreate = new bool[3];
            
        }

        public CreatePage(ref HttpClient client, ref int userID)
        {
            InitializeComponent();
        }

        private void CreatePage_Load(object sender, EventArgs e)
        {
            label4.Hide();
            label5.Hide();
            label6.Hide();
            accountName.Clear();
            usernameField.Clear();
            passwordField.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (usernameField.Text.Count() >= 1)
            {
                if (String.IsNullOrEmpty(usernameField.Text))
                {
                    canCreate[1] = false;
                    label5.Show();
                }
                else
                    try
                {
                    account.setUser(usernameField.Text);
                    label5.Hide();
                    canCreate[1] = true;
                }

                catch (Exception)
                {

                }
            }
            else
            {
                label5.Show();
                canCreate[1] = false;
            }
        }

        private void passwordField_TextChanged(object sender, EventArgs e)
        {
            if (passwordField.Text.Count() >= 3)
            {
                if (String.IsNullOrEmpty(passwordField.Text))
                {
                    label4.Show();
                    canCreate[2] = false;
                }
                else
                    try
                {
                    
                    account.setPass(passwordField.Text);
                    label4.Hide();
                    canCreate[2] = true;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                label4.Show();
                canCreate[2] = false;
            }
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void accountName_TextChanged(object sender, EventArgs e)
        {
            if (accountName.Text.Count() >= 1)
            {
                if (String.IsNullOrEmpty(accountName.Text))
                {
                    label6.Show();
                    canCreate[0] = false;
                }
                else
                    try
                {
                    
                    account.setAccountName(accountName.Text);
                    label6.Hide();
                    canCreate[0] = true;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                label6.Show();
                canCreate[0] = false;
            }
        }

        private void createAccButton_Click(object sender, EventArgs e)
        {
            String message = "";
            bool cont = true;
            try
            {
                message += account.getAccountName() + ": " + account.getAccountName().Count() + ", ";
                //canCreate[0] = true;
                message += account.getUsername() + ": " + account.getUsername().Count() + ", ";
                //canCreate[1] = true;
                message += account.getPassword() + ": " + account.getPassword().Count();
               // canCreate[2] = true;
            }

            catch (Exception)
            {
                cont = false;
            }
            if (cont)
                if (canCreate[0] && canCreate[1] && canCreate[2])
                {

                    list.addAccount(account);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Fields must meet requirements!");
                }
            else
                MessageBox.Show("Fields cannot be empty!");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
