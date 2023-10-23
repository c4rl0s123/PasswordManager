using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class ModifyAccountPage : Form
    {
        private String accName;
        private String userName;
        private String password;
        private Account account;
        private String accountToModify;
        private bool[] canCreate;
        public ModifyAccountPage()
        {
            account = new Account();
            InitializeComponent();
        }
        public ModifyAccountPage(ref Account acc)
        {
            account =  acc;
            InitializeComponent();
            accName = ""; userName = ""; password = "";
            accountToModify = account.getAccountName();
            label4.Text = "Modifying Account: " + accountToModify;
            canCreate = new bool[3];
            
        }

        private void ModifyAccountPage_Load(object sender, EventArgs e)
        {
            accountNameField.Clear();
            usernameField.Clear();
            passwordField.Clear();
            label5.Hide();
            label6.Hide();
            label7.Hide();
        }

        private void passwordField_TextChanged(object sender, EventArgs e)
        {
            if (passwordField.Text.Count() >= 3)
            {
                password = this.passwordField.Text;
                label7.Hide();
                canCreate[2] = true;
            }
            else
            {
                label7.Show();
                canCreate[2] = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (accountNameField.Text.Count() < 1)
            {
                label5.Show();
                canCreate[0] = false;
            }
            else
            {
                accName = this.accountNameField.Text;
                canCreate[0] = true;
                label5.Hide();
            }
        }

        private void usernameField_TextChanged(object sender, EventArgs e)
        {
            if (usernameField.Text.Count() < 1)
            {
                canCreate[1] = false;
                label6.Show();
            }
            else
            {
                userName = this.usernameField.Text;
                canCreate[1] = true;
                label6.Hide();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            bool cont = true;
            String check = "";
            try
            {
                check += accName + ": " + accName.Count() + ", ";
                check += userName + ": " + userName.Count() + ", ";
                check += password + ": " + password.Count();
            }
            catch (Exception)
            {
                cont = false;
                MessageBox.Show("Fields cannot be blank!");
                
            }
            if (cont)
            {
                if(canCreate[0] && canCreate[1] && canCreate[2])
                try
                {
                    account.setAll(accName, userName, password);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error! Account Corrupted!");
                }
                else
                    MessageBox.Show("Fields must meet requirements!");
            }
           /* String message = "";
            message += account.getAccountName() + ", " + account.getUsername() + ", " + account.getPassword();
            MessageBox.Show(message);*/
            
        }

        private void cancelButton2_Click(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
