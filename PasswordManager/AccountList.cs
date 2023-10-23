using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    [Serializable]
    public class AccountList
    {
        public List<Account> accountList { get; set; }

        /*public AccountList()
        {
            accountList = new List<Account>();
        }*/

       
        public int Count()
        {
           return accountList.Count;
        }
        public Boolean isEmpty()
        {
            return !accountList.Any();
        }
        public void addAccount(Account acc)
        {
            accountList.Add(acc);
        }
        public void removeAccount(Account acc)
        {
            accountList.Remove(acc);
        }
        public Account getAccount(int index)
        {
            return accountList.ElementAt(index);
        }

        public void replaceAccount(Account acc, int index)
        {
            accountList[index] = acc;
        }
        public String getAccountName(int index)
        {
            return accountList.ElementAt(index).getAccountName();
        }

        public Account searchAccount(String nameAcc)
        {
            for (int i = 0; i < accountList.Count; i++)
            {
                if (accountList.ElementAt(i).getAccountName().Equals(nameAcc))
                {
                    return accountList.ElementAt(i);
                }
            }

            return null;
        }
    }
}
