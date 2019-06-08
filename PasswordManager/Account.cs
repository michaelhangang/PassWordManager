using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PasswordManager
{
    public class Password{

        public string Value;
        public ushort StrengthNum;
        public string StrengthText;
        public string LastReset;

        public Password()
        {
            this.Value = "";
            this.StrengthNum = 0;
            this.StrengthText = "";
            this.LastReset = "";
        }

    }
   public class Account
    {
        public string Description;
        public string UserId;
        public string LoginUrl;
        public string AccountNum;
        public Password Password;
       

        public Account()
        {
            this.Description = "";
            this.UserId = "";
            this.LoginUrl = "";
            this.AccountNum = "";
            this.Password = new Password();
         
        }

    }
}
