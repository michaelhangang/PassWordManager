using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.IO;


namespace PasswordManager
{
    public class Class1
    {
      

        static void Main(string[] args)
        {
          //json files path
            string path1 = @"E:\\Level 4\\INFO3138 Declarative Language\\Project1\\PasswordManager\\PasswordManager\\account-data 1.json";
            string path2 = @"E:\\Level 4\\INFO3138 Declarative Language\\Project1\\PasswordManager\\PasswordManager\\account-data 2.json";
            string path3 = @"E:\\Level 4\\INFO3138 Declarative Language\\Project1\\PasswordManager\\PasswordManager\\account-data 3.json";
            string path4 = @"E:\\Level 4\\INFO3138 Declarative Language\\Project1\\PasswordManager\\PasswordManager\\account-schema.json";
         //variable
            string accout1="", accout2="", accout3="";
            Account acc1 = new Account(), acc2 = new Account(), acc3 = new Account();
            List<Account> lAccouts = new List<Account>();

            //check if files exist
            if (File.Exists(path1))
            {
                //Console.WriteLine("json file exists");
                accout1 = File.ReadAllText(path1);
                acc1 = JsonConvert.DeserializeObject<Account>(accout1);
                lAccouts.Add(acc1);
            }
            if (File.Exists(path2))
            {
                //Console.WriteLine("json file exists");
                accout2 = File.ReadAllText(path2);
                acc2 = JsonConvert.DeserializeObject<Account>(accout2);
                lAccouts.Add(acc2);

            }
            if (File.Exists(path1))
            {
                //Console.WriteLine("json file exists");
                accout3 = File.ReadAllText(path3);
                acc3 = JsonConvert.DeserializeObject<Account>(accout3);
                lAccouts.Add(acc3);
            }

         
            //head format
            bool returnAccEntries = true;
            Console.WriteLine("PASSWORD MANAGEMENT SYSTEM\n");
            while (returnAccEntries)
            {
                setLine();
                Console.WriteLine("\t\t\t\t\tAccount Entries");
                setLine();
                //create menu
                for (int i = 0; i < lAccouts.Count; ++i)
                {
                    Console.WriteLine($"  {i + 1}.{lAccouts[i].Description}");
                }
                setLine();
                //inform 
                Console.WriteLine("  Press # from the above list to select an entry.");
                Console.WriteLine("  Press A to add a new entry.");
                Console.WriteLine("  Press X to quit.");

                setLine();
                Console.Write("\nEnter a command   ");
                //get input
                string input = Console.ReadLine();
                switch (input)
                {
                    case "#":
                        int index = 0;
                        selectEntry(ref index, lAccouts);
                        setLine();
                        Console.WriteLine("  Press P to change this password.\n" +
                                          "  Press D to delete this entry.\n" +
                                          "  Press M to return to the main menu.");
                        setLine();
                        updateAccout(index, lAccouts);
                        break;
                    case "A":
                        //creat json schema
                        string jsSchema = File.ReadAllText(path4);
                        JSchema schema = JSchema.Parse(jsSchema);
                        addAccount(schema, lAccouts);
                        break;
                    case "X":
                        returnAccEntries = false;
                        break;
                    default:
                        break;
                }
            }// end switch
          
           
        }//end main
          




        public static void setLine()
        {
            for (int i = 1; i < 120; ++i)  //line
                Console.Write("-");
            Console.WriteLine();
        }
        public static void selectEntry(ref int index, List<Account> lAccouts)
        {
            bool flag; ;
            do
            {
                flag = false;
                Console.Write("\nplease enter a number of the Account ");
                string numSeleted = Console.ReadLine();
                index = int.Parse(numSeleted);
                if (index <= 0 || index > lAccouts.Count)
                {
                    Console.WriteLine("\nSorry, the number is invalid, please try again");
                    flag = true;
                }
                else
                {
                    showAccout(index,lAccouts);
                }
            } while (flag);
           
        }

        public static void showAccout(int index, List<Account> listAcct)
        {
            Account accout = listAcct[index - 1];
            setLine();
            Console.WriteLine($"  {index}. {accout.Description}");
            setLine();
            Console.WriteLine(" {0,-25} {1,-25}", "User ID:", accout.UserId);
            Console.WriteLine(" {0,-25} {1,-25}", "Password:", accout.Password.Value);
            Console.WriteLine(" {0,-25} {1,-25}", "Password Strength:", accout.Password.StrengthText + "(" + accout.Password.StrengthNum + "%)");
            Console.WriteLine(" {0,-25} {1,-25}", "Password Reset:", accout.Password.LastReset);
            Console.WriteLine(" {0,-25} {1,-25}", "Login url", accout.LoginUrl);
            Console.WriteLine(" {0,-25} {1,-25}", "Account #", accout.AccountNum);
            }

        public static void updateAccout(int index, List<Account> listAcct)
        {
            Console.Write("Enter a command: ");
            string com = Console.ReadLine();
            switch (com)
            {
                case "P":
                    changePassword(index,listAcct);
                    break;
                case "D":
                    deletePassword(index, listAcct);
                    break;
                case "M":
                    break;
                default:
                    break;
            }
        }

        public static void changePassword(int index, List<Account> listAcct)
        {
            Account acc = listAcct[index-1];
            Console.Write("new password: ");
            string newPassword = Console.ReadLine();
            try
            {
                // PasswordTester class demonstration
                DateTime dateNow = DateTime.Now;
                PasswordTester pw = new PasswordTester(newPassword);
                acc.Password.Value = newPassword;
                acc.Password.StrengthText =pw.StrengthLabel;
                acc.Password.StrengthNum=   pw.StrengthPercent;
                acc.Password.LastReset = dateNow.ToShortDateString();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ERROR: Invalid password format");
            }
        }

        public static void deletePassword(int index, List<Account> listAcct)
        {
            Console.Write("Delete? (Y/N): ");
            string com = Console.ReadLine();
            if(com =="Y")
            listAcct.RemoveAt(index-1);
        }

        public static void addAccount(JSchema schema,List<Account> lAccouts)
        {
            bool flagAddNew;
            do
            {
                flagAddNew = false;
                Account newAcc = new Account();
                Console.WriteLine("\nPlease key-in values for the following fields...\n");
                Console.Write("{0,-25}", "Description:");
                newAcc.Description = Console.ReadLine(); ;
                Console.Write("{0,-25}", "User ID:");
                newAcc.UserId = Console.ReadLine();
                Console.Write("{0,-25}", "Password:");
                newAcc.Password.Value = Console.ReadLine();
                PasswordTester pw = new PasswordTester(newAcc.Password.Value);
                newAcc.Password.StrengthText = pw.StrengthLabel;
                newAcc.Password.StrengthNum = pw.StrengthPercent;
                Console.Write("{0,-25}", "Login url:");
                newAcc.LoginUrl = Console.ReadLine();
                Console.Write("{0,-25}", "Account #:");
                newAcc.AccountNum = Console.ReadLine();

                string nAcc = JsonConvert.SerializeObject(newAcc);
                JObject JnewAcc = JObject.Parse(nAcc);
              

                if (!JnewAcc.IsValid(schema))
                {
                    Console.WriteLine("ERROR: Invalid account information entered. Please try again.");
                    flagAddNew = true;
                }
                else
                {
                    lAccouts.Add(newAcc);
                    string path = newAcc.Description + ".json";
                    using (File.Create(path)) { } 
                    using (StreamWriter sWriter = new StreamWriter(path)) {
                        sWriter.WriteLine(nAcc);
                    } 
                  
                }
            } while (flagAddNew);//end while

        }
    }
}
