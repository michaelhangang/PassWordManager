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


        }
    }
}
