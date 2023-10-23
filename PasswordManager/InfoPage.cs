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
    public partial class InfoPage : Form
    {
        private AccountList list;
        private String selectedAccount;
        private Account acc;
        private String usern;
        private String pass;
        public InfoPage()
        {
            InitializeComponent();
            list = new AccountList();
            acc = new Account();
        }

        public InfoPage(ref HttpClient client, ref User user, ref AccountList aList)
        {
            list = aList;
            InitializeComponent();
            int size = list.Count();
            for (int i = 0; i<size;i++)
            {
                AccountListBox.Items.Add(aList.getAccountName(i));
            }
            acc = aList.getAccount(0);
            usern = "error";
            pass = "error";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedAccount = AccountListBox.GetItemText(AccountListBox.SelectedItem);
                acc = list.searchAccount(selectedAccount);
                label3.Text = selectedAccount;
                usern = acc.getUsername();
                pass = acc.getPassword();
            }

            catch(Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InfoPage_Load(object sender, EventArgs e)
        {
            
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            ModifyAccountPage modify = new ModifyAccountPage(ref acc);
            this.Hide();
            modify.ShowDialog();
            this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            list.removeAccount(acc);
            this.Close();
        }

        private void getPasswordButton_Click(object sender, EventArgs e)
        {
            PasswordScreen passwordscreen = new PasswordScreen(usern,pass);
            this.Hide();
            passwordscreen.ShowDialog();
            this.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
