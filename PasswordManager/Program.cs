using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    static class Program
    {
        private static HttpClient client = new HttpClient();
        private static User user;
        private static WebClient webClient;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Mutex mutex = new System.Threading.Mutex(false, "MyMutex");

            try {
                if (mutex.WaitOne(0, false))
                {


                    AccountList accounts = new AccountList();
                    Stream stream;
                    IFormatter formatter = new BinaryFormatter();
                    String filename = "Accounts.txt";

                    try
                    {
                        stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                        accounts = (AccountList)formatter.Deserialize(stream);
                        /* String accountStrings = "";
                         for (int i = 0; i<accounts.Count(); i++)
                         {
                             accountStrings += accounts.getAccountName(i) + ", ";
                         }
                         MessageBox.Show(accountStrings); */
                        stream.Close();
                    }

                    catch (Exception e)
                    {
                        MessageBox.Show("No account Data found!");

                    }


                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new LoginPage(ref client, ref user));
                    MessageBox.Show("Application closed! Saving Data");
                   /* Application.Run(new MainPage(ref accounts));
                    MessageBox.Show("Application closed! Saving Data");*/

                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                    }
                    stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
                    formatter.Serialize(stream, accounts);
                    stream.Close();
                }
                else
                {
                    MessageBox.Show("An instance of the application is already running.");
                }
        }//end first try
            finally
            {
                if (mutex!= null)
                {
                    mutex.Close();
                    mutex = null;
                }
            }//end finally
        }//end main
    }
}
