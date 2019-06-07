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

            //creat json schema
            //string jsSchema = File.ReadAllText(path4);
            //JSchema schema = JSchema.Parse(jsSchema);

            //JObject person = JObject.Parse(accout3);
            //IList<string> messages;

            //if (!person.IsValid(schema, out messages))
            //{
            //    foreach(var i in messages)
            //    Console.WriteLine(i);

            //}
            //head format
            Console.WriteLine("PASSWORD MANAGEMENT SYSTEM\n");
            for (int i = 1; i < 120; ++i)
                Console.Write("-");
            Console.WriteLine("\n\t\t\t\t\tAccount Entries");
            for (int i = 1; i < 120; ++i)
                Console.Write("-");
            Console.WriteLine();
            //outout menu
            for (int i=0; i<lAccouts.Count;++i)
            {
                Console.WriteLine($"  {i+1}.{lAccouts[i].description}");
            }
            for (int i = 1; i < 120; ++i)  //line
                Console.Write("-");
            Console.WriteLine();
            //inform 
            Console.WriteLine("  Press # from the above list to select an entry.");         
            Console.WriteLine("  Press A to add a new entry.");
            Console.WriteLine("  Press X to quit.");
           
            for (int i = 1; i < 120; ++i)  //line
                Console.Write("-");
            Console.Write("\n\nEnter a command   ");
            //get input
            string input = Console.ReadLine();
            switch (input)
            {
                case "#":
                    selectEntry(lAccouts);
                    break;
                case "A":
                    break;
                case "X":
                    break;
            }

        }

        public static void selectEntry(List<Account> lAccouts)
        {
            bool flag; ;
            do
            {
                flag = false;
                Console.Write("\nplease enter a number of the Account ");
                string numSeleted = Console.ReadLine();
                int index = int.Parse(numSeleted);
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
            for (int i = 1; i < 120; ++i)  //line
                Console.Write("-");
            Console.WriteLine();
            Console.WriteLine($"  {index}. {accout.description}");
            for (int i = 1; i < 120; ++i)  //line
                Console.Write("-");
            Console.WriteLine("\n {0,-25} {1,-25}", "User ID:", accout.userId);
            Console.WriteLine("\n {0,-25} {1,-25}", "Password:", accout.password.value);
            Console.WriteLine("\n {0,-25} {1,-25}", "Password Strength:", accout.password.strengthText + "(" + accout.password.strengthNum + "%)");
            Console.WriteLine("\n {0,-25} {1,-25}", "Password Reset:", accout.password.lastReset);
            Console.WriteLine("\n {0,-25} {1,-25}", "Login url", accout.loginUrl);
            Console.WriteLine("\n {0,-25} {1,-25}", "Account #", accout.accountNum);

            }
        }
}
