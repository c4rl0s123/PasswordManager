using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    [Serializable]
    public class Account
    {
        private int id;
        private int user_id;
        private String account_name;
        private String account_username;
        private String account_password;

        public String getAccountName()
        {
            return account_name;
        }
        public String getUsername()
        {
            return account_username;
        }
        
        public String getPassword()
        {
            return account_password;
        }

        public void setUser(String user)
        {
            account_username = user;
        }

        public void setPass(String pass)
        {
            Crypto crypto = new Crypto();
            String newPass = crypto.Encrypt(pass);
            account_password = newPass;
        }
        public void setAccountName(String accName)
        {
            account_name = accName;
        }

        public void setAll(String accName, String user, String Pass)
        {
            account_name = accName; account_username = user;
            setPass(Pass);
        }
        
    }
}
